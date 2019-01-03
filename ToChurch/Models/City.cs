using Dapper.Contrib.Extensions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Dapper;

namespace ToChurch.Models
{
    [Table("city")]
    public class City
    {
        [Key]
        public int Id { get; set; }
        public int City_Id { get; set; }
        public string City_Name { get; set; }
    }
}
