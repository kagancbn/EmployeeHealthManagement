using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

#nullable disable

namespace HealthManagement.Models
{
    [Table("Egitim")]
    public partial class Egitim
    {
        public Egitim()
        {
            Elemen = new HashSet<Eleman>();
        }

        [Key]
        [Column("EgitimID")]
        public int EgitimId { get; set; }
        [Required]
        [StringLength(50)]
        public string EgitimDuzeyi { get; set; }

        [InverseProperty(nameof(Eleman.Egitim))]
        public virtual ICollection<Eleman> Elemen { get; set; }
    }
}
