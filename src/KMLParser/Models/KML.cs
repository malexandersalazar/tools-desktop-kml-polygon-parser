using System.Collections.Generic;
using System.Xml.Serialization;

namespace KMLParser.Models
{
    [XmlRoot(ElementName = "SimpleField", Namespace = "http://www.opengis.net/kml/2.2")]
    public class SimpleField
    {
        [XmlElement(ElementName = "displayName", Namespace = "http://www.opengis.net/kml/2.2")]
        public string DisplayName { get; set; }

        [XmlAttribute(AttributeName = "type")]
        public string Type { get; set; }

        [XmlAttribute(AttributeName = "name")]
        public string Name { get; set; }
    }

    [XmlRoot(ElementName = "Schema", Namespace = "http://www.opengis.net/kml/2.2")]
    public class Schema
    {
        [XmlElement(ElementName = "SimpleField", Namespace = "http://www.opengis.net/kml/2.2")]
        public List<SimpleField> SimpleField { get; set; }

        [XmlAttribute(AttributeName = "name")]
        public string Name { get; set; }

        [XmlAttribute(AttributeName = "id")]
        public string Id { get; set; }
    }

    [XmlRoot(ElementName = "BalloonStyle", Namespace = "http://www.opengis.net/kml/2.2")]
    public class BalloonStyle
    {
        [XmlElement(ElementName = "text", Namespace = "http://www.opengis.net/kml/2.2")]
        public string Text { get; set; }
    }

    [XmlRoot(ElementName = "PolyStyle", Namespace = "http://www.opengis.net/kml/2.2")]
    public class PolyStyle
    {
        [XmlElement(ElementName = "colorMode", Namespace = "http://www.opengis.net/kml/2.2")]
        public string ColorMode { get; set; }
    }

    [XmlRoot(ElementName = "Style", Namespace = "http://www.opengis.net/kml/2.2")]
    public class Style
    {
        [XmlElement(ElementName = "BalloonStyle", Namespace = "http://www.opengis.net/kml/2.2")]
        public BalloonStyle BalloonStyle { get; set; }

        [XmlElement(ElementName = "PolyStyle", Namespace = "http://www.opengis.net/kml/2.2")]
        public PolyStyle PolyStyle { get; set; }

        [XmlAttribute(AttributeName = "id")]
        public string Id { get; set; }

        [XmlElement(ElementName = "IconStyle", Namespace = "http://www.opengis.net/kml/2.2")]
        public IconStyle IconStyle { get; set; }

        [XmlElement(ElementName = "LineStyle", Namespace = "http://www.opengis.net/kml/2.2")]
        public LineStyle LineStyle { get; set; }
    }

    [XmlRoot(ElementName = "IconStyle", Namespace = "http://www.opengis.net/kml/2.2")]
    public class IconStyle
    {
        [XmlElement(ElementName = "colorMode", Namespace = "http://www.opengis.net/kml/2.2")]
        public string ColorMode { get; set; }
    }

    [XmlRoot(ElementName = "LineStyle", Namespace = "http://www.opengis.net/kml/2.2")]
    public class LineStyle
    {
        [XmlElement(ElementName = "colorMode", Namespace = "http://www.opengis.net/kml/2.2")]
        public string ColorMode { get; set; }
    }

    [XmlRoot(ElementName = "SimpleData", Namespace = "http://www.opengis.net/kml/2.2")]
    public class SimpleData
    {
        [XmlAttribute(AttributeName = "name")]
        public string Name { get; set; }

        [XmlText]
        public string Text { get; set; }
    }

    [XmlRoot(ElementName = "SchemaData", Namespace = "http://www.opengis.net/kml/2.2")]
    public class SchemaData
    {
        [XmlElement(ElementName = "SimpleData", Namespace = "http://www.opengis.net/kml/2.2")]
        public List<SimpleData> SimpleData { get; set; }

        [XmlAttribute(AttributeName = "schemaUrl")]
        public string SchemaUrl { get; set; }
    }

    [XmlRoot(ElementName = "ExtendedData", Namespace = "http://www.opengis.net/kml/2.2")]
    public class ExtendedData
    {
        [XmlElement(ElementName = "SchemaData", Namespace = "http://www.opengis.net/kml/2.2")]
        public SchemaData SchemaData { get; set; }
    }

    [XmlRoot(ElementName = "LinearRing", Namespace = "http://www.opengis.net/kml/2.2")]
    public class LinearRing
    {
        [XmlElement(ElementName = "coordinates", Namespace = "http://www.opengis.net/kml/2.2")]
        public string Coordinates { get; set; }
    }

    [XmlRoot(ElementName = "outerBoundaryIs", Namespace = "http://www.opengis.net/kml/2.2")]
    public class OuterBoundaryIs
    {
        [XmlElement(ElementName = "LinearRing", Namespace = "http://www.opengis.net/kml/2.2")]
        public LinearRing LinearRing { get; set; }
    }

    [XmlRoot(ElementName = "Polygon", Namespace = "http://www.opengis.net/kml/2.2")]
    public class Polygon
    {
        [XmlElement(ElementName = "outerBoundaryIs", Namespace = "http://www.opengis.net/kml/2.2")]
        public OuterBoundaryIs OuterBoundaryIs { get; set; }
    }

    [XmlRoot(ElementName = "Placemark", Namespace = "http://www.opengis.net/kml/2.2")]
    public class Placemark
    {
        [XmlElement(ElementName = "name", Namespace = "http://www.opengis.net/kml/2.2")]
        public string Name { get; set; }

        [XmlElement(ElementName = "styleUrl", Namespace = "http://www.opengis.net/kml/2.2")]
        public string StyleUrl { get; set; }

        [XmlElement(ElementName = "Style", Namespace = "http://www.opengis.net/kml/2.2")]
        public Style Style { get; set; }

        [XmlElement(ElementName = "ExtendedData", Namespace = "http://www.opengis.net/kml/2.2")]
        public ExtendedData ExtendedData { get; set; }

        [XmlElement(ElementName = "Polygon", Namespace = "http://www.opengis.net/kml/2.2")]
        public Polygon Polygon { get; set; }
    }

    [XmlRoot(ElementName = "Document", Namespace = "http://www.opengis.net/kml/2.2")]
    public class Document
    {
        [XmlElement(ElementName = "name", Namespace = "http://www.opengis.net/kml/2.2")]
        public string Name { get; set; }

        [XmlElement(ElementName = "Schema", Namespace = "http://www.opengis.net/kml/2.2")]
        public Schema Schema { get; set; }

        [XmlElement(ElementName = "Style", Namespace = "http://www.opengis.net/kml/2.2")]
        public Style Style { get; set; }

        [XmlElement(ElementName = "Placemark", Namespace = "http://www.opengis.net/kml/2.2")]
        public Placemark Placemark { get; set; }
    }

    [XmlRoot(ElementName = "kml", Namespace = "http://www.opengis.net/kml/2.2")]
    public class Kml
    {
        [XmlElement(ElementName = "Document", Namespace = "http://www.opengis.net/kml/2.2")]
        public Document Document { get; set; }

        [XmlAttribute(AttributeName = "xmlns")]
        public string Xmlns { get; set; }

        [XmlAttribute(AttributeName = "gx", Namespace = "http://www.w3.org/2000/xmlns/")]
        public string Gx { get; set; }

        [XmlAttribute(AttributeName = "kml", Namespace = "http://www.w3.org/2000/xmlns/")]
        public string _kml { get; set; }

        [XmlAttribute(AttributeName = "atom", Namespace = "http://www.w3.org/2000/xmlns/")]
        public string Atom { get; set; }
    }
}