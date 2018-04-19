using System.ComponentModel.DataAnnotations;

namespace SpeysCloud.Main.DAL.Model
{
    public class Country
    {
        [Key]
        public string Iso { get; set; }

        public string Name { get; set; }
        public string PrintableName { get; set; }
        public string Iso3 { get; set; }
        public int NumCode { get; set; }
    }
}