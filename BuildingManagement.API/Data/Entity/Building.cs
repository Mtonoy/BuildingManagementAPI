using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Diagnostics.CodeAnalysis;

namespace BuildingManagement.API.Data.Entity
{
    public class Building
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        [NotNull]
        [MaxLength(50)]
        public string Name { get; set; }
        [MaxLength(50)]
        public string Location { get; set; }
    }
}
