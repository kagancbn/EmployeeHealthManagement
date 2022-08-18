using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

#nullable disable

namespace HealthManagement.Models
{
    [Table("Recete")]
    public partial class Recete
    {
        public Recete()
        {
            HastalikKaydis = new HashSet<HastalikKaydi>();
        }

        [Key]
        [Column("IlacID")]
        public int IlacId { get; set; }
        [Required]
        [StringLength(50)]
        public string IlacIsim { get; set; }
        [Required]
        [StringLength(50)]
        public string IlacDoz { get; set; }

        [InverseProperty(nameof(HastalikKaydi.Ilac))]
        public virtual ICollection<HastalikKaydi> HastalikKaydis { get; set; }
    }
}
