using System.Collections.Generic;

namespace KDBS.Models
{
    public class PreviewPoint
    {
        public string Id { get; set; }
        
        public double Latitude { get; set; }
        
        public double Longitude { get; set; }
        
        public List<string> Jobs { get; set; }
    }
}
