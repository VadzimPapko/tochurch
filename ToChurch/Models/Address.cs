using Dapper.Contrib.Extensions;

namespace ToChurch.Models
{
    [Table("address")]
    public class Address
    {
        [Key]
        public int Id { get; set; }
        public string Lat { get; set; }
        public string Lon { get; set; }
    }
}
