using KMLParser.Encoders;
using KMLParser.Models;
using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Windows;
using System.Xml.Serialization;

namespace KMLParser
{
    public partial class MainWindow : Window
    {
        private string _readedKml = null;
        private List<Coordinate> _kmlCoordinates = null;

        public MainWindow()
        {
            InitializeComponent();
        }

        #region Methods

        private void ReadKML(string fileName, Stream fileStream)
        {
            FileNameTextBlock.Text = fileName;

            var serializer = new XmlSerializer(typeof(Kml));
            Kml kml = (Kml)serializer.Deserialize(fileStream);
            _readedKml = kml.Document.Placemark.Polygon.OuterBoundaryIs.LinearRing.Coordinates.Trim();

            _kmlCoordinates = new List<Coordinate>();

            try
            {
                var kmlCoordinates = _readedKml;
                var pairs = kmlCoordinates.Split(' ');
                foreach (var pair in pairs)
                {
                    var latlng = pair.Split(',');
                    var lat = Math.Round(double.Parse(latlng[1]), 5);
                    var lng = Math.Round(double.Parse(latlng[0]), 5);
                    _kmlCoordinates.Add(new Coordinate(lat, lng));
                }
            }
            catch (Exception)
            {
                _kmlCoordinates = null;
            }

            if (_kmlCoordinates is null || _kmlCoordinates.Count < 4)
            {
                MessageBox.Show("Invalid KML coordinates format");
                _kmlCoordinates = new List<Coordinate>();
            }
        }

        private void OpenKMLButton_Click(object sender, RoutedEventArgs e)
        {
            var ofd = new OpenFileDialog();
            ofd.Filter = "Archivos KML (*.kml)|*.kml";
            var result = ofd.ShowDialog();
            if (result.HasValue && result.Value)
            {
                var fileStream = ofd.OpenFile();
                if (fileStream != null)
                {
                    ReadKML(ofd.FileName, fileStream);
                    EncodeAsJSON();
                    EncodeAsGooglePolylineAndGeometry();

                    OperationTextBox.Text = Guid.NewGuid().ToString().Split('-')[0];
                }
            }
        }

        private void EncodeAsJSON(int maxLength = 8000)
        {
            if (_kmlCoordinates is null || _kmlCoordinates.Count == 0)
                return;

            if (_kmlCoordinates.First().X == _kmlCoordinates.Last().X && _kmlCoordinates.First().Y == _kmlCoordinates.Last().Y)
                _kmlCoordinates.RemoveAt(_kmlCoordinates.Count - 1);

            JSONMiddleTextBox.Text = string.Format("{0},{1}", _kmlCoordinates.Sum(x => x.Y) / _kmlCoordinates.Count, _kmlCoordinates.Sum(x => x.X) / _kmlCoordinates.Count);

            string json = JSONPointsEncoder.Encode(_kmlCoordinates).ToLowerInvariant();

            var coordinates = _kmlCoordinates;
            int reduceFactor = 2;
            if (json.Length > maxLength)
            {
                List<Coordinate> reducedList = null;
                do
                {
                    reducedList = coordinates.Where((_, i) => i % reduceFactor != 0).ToList();
                    json = JSONPointsEncoder.Encode(reducedList).ToLowerInvariant();
                    if (json.Length < maxLength)
                        reduceFactor++;
                    else
                        coordinates = reducedList;
                } while (json.Length > maxLength || reduceFactor < 1000);
            }

            JSONTextBox.Text = json;
            JsonLengthTextBlock.Text = string.Format("Length: {0}", json.Length);
        }

        private void EncodeAsGooglePolylineAndGeometry(int maxLength = 8000)
        {
            if (_kmlCoordinates is null || _kmlCoordinates.Count == 0)
                return;

            if (_kmlCoordinates.First().X == _kmlCoordinates.Last().X && _kmlCoordinates.First().Y == _kmlCoordinates.Last().Y)
                _kmlCoordinates.RemoveAt(_kmlCoordinates.Count - 1);

            string googlePolyline = GooglePolylineEncoder.Encode(_kmlCoordinates);

            var coordinates = _kmlCoordinates;
            int reduceFactor = 2;
            if (googlePolyline.Length > maxLength)
            {
                List<Coordinate> reducedList = null;
                do
                {
                    reducedList = coordinates.Where((_, i) => i % reduceFactor != 0).ToList();
                    googlePolyline = GooglePolylineEncoder.Encode(reducedList);

                    if (googlePolyline.Length < maxLength)
                        reduceFactor++;
                    else
                        coordinates = reducedList;
                } while (googlePolyline.Length > maxLength || reduceFactor < 1000);
            }

            EncodedPolylineTextBox.Text = googlePolyline;
            GoogleFormatLengthTextBlock.Text = string.Format("Length: {0}", googlePolyline.Length);

            GeometryTextBox.Text = PolygonGeometryDataTypeEncoder.Encode(coordinates);
            GeometryLengthTextBlock.Text = string.Format("Length: {0}", GeometryTextBox.Text.Length);
        }

        #endregion Methods
    }
}