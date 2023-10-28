using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using Microsoft.EntityFrameworkCore;

namespace BuildingManagement.API.Data.Entity
{
    public class Reading
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public int BuildingId { get; set; }
        public Building Building { get; set; }
        public int ObjectId { get; set; }
        public Objects Object { get; set; }
        public int DataFieldId { get; set; }
        public DataField DataField { get; set; }
        [Precision(18, 2)]
        public decimal Value { get; set; }
        public DateTime Timestamp { get; set; }
    }
}
