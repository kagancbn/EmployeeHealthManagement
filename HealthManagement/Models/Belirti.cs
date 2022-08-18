using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

#nullable disable

namespace HealthManagement.Models
{
    [Table("Belirti")]
    public partial class Belirti
    {
        public Belirti()
        {
            CovidDurumus = new HashSet<CovidDurumu>();
        }

        [Key]
        [Column("BelirtiID")]
        public int BelirtiId { get; set; }
        [Required]
        [StringLength(50)]
        public string BelirtiIsim { get; set; }

        [InverseProperty(nameof(CovidDurumu.Belirti))]
        public virtual ICollection<CovidDurumu> CovidDurumus { get; set; }
    }
}
