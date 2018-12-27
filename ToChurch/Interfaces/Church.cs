using Dapper.Contrib.Extensions;

namespace ToChurch.Interfaces
{
    [Table("5_hram")]
    public class Church
    {
        [Key]
        public int Id { get; set; }
        public string Type { get; set; }
        public int Prihod { get; set; }
        public string Hram { get; set; }
    }
}