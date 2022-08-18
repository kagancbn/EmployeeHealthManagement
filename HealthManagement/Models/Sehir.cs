using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

#nullable disable

namespace HealthManagement.Models
{
    [Table("Sehir")]
    public partial class Sehir
    {
        public Sehir()
        {
            Elemen = new HashSet<Eleman>();
        }

        [Key]
        [Column("SehirID")]
        public int SehirId { get; set; }
        [Required]
        [StringLength(50)]
        public string Sehirİsim { get; set; }

        [InverseProperty(nameof(Eleman.Sehir))]
        public virtual ICollection<Eleman> Elemen { get; set; }
    }
}
