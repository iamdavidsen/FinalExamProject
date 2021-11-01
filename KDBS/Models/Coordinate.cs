namespace KDBS.Models
{
    public class Coordinate
    {
        public double Latitude;
        public double Longitude;
        public Coordinate() {}
        
        public Coordinate(double latitude, double longitude)
        {
            Latitude = latitude;
            Longitude = longitude;
        }
    }
}
