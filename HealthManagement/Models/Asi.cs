using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

#nullable disable

namespace HealthManagement.Models
{
    [Table("Asi")]
    public partial class Asi
    {
        public Asi()
        {
            CovidDurumus = new HashSet<CovidDurumu>();
        }

        [Key]
        [Column("AsiID")]
        public int AsiId { get; set; }
        [Required]
        [StringLength(50)]
        public string AsiIsim { get; set; }

        [InverseProperty(nameof(CovidDurumu.Asi))]
        public virtual ICollection<CovidDurumu> CovidDurumus { get; set; }
    }
}
