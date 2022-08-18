using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

#nullable disable

namespace HealthManagement.Models
{
    [Table("Semptom")]
    public partial class Semptom
    {
        public Semptom()
        {
            HastalikKaydis = new HashSet<HastalikKaydi>();
        }

        [Key]
        [Column("SemptomID")]
        public int SemptomId { get; set; }
        [Required]
        [StringLength(50)]
        public string SemptomIsim { get; set; }

        [InverseProperty(nameof(HastalikKaydi.Semptom))]
        public virtual ICollection<HastalikKaydi> HastalikKaydis { get; set; }
    }
}
