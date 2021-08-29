namespace KMLParser.Models
{
    public struct Coordinate
    {
        public double Y; public double X; public Coordinate(double y, double x) => (Y, X) = (y, x);
    }
}