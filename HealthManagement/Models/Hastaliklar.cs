using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

#nullable disable

namespace HealthManagement.Models
{
    [Table("Hastaliklar")]
    public partial class Hastaliklar
    {
        public Hastaliklar()
        {
            HastalikKaydis = new HashSet<HastalikKaydi>();
        }

        [Key]
        [Column("HastalikID")]
        public int HastalikId { get; set; }
        [Required]
        [StringLength(50)]
        public string HastalikIsim { get; set; }

        [InverseProperty(nameof(HastalikKaydi.Hastalik))]
        public virtual ICollection<HastalikKaydi> HastalikKaydis { get; set; }
    }
}
