using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

#nullable disable

namespace HealthManagement.Models
{
    [Table("HastalikKaydi")]
    public partial class HastalikKaydi
    {
        [Key]
        [Column("HastalikKaydiID")]
        public int HastalikKaydiId { get; set; }
        [Column("SemptomID")]
        public int SemptomId { get; set; }
        [Column("HastalikID")]
        public int HastalikId { get; set; }
        [Column("IlacID")]
        public int IlacId { get; set; }
        [Column(TypeName = "date")]
        public DateTime HastalikTarih { get; set; }
        [Key]
        [Column("ElemanID")]
        public int ElemanId { get; set; }

        [ForeignKey(nameof(ElemanId))]
        [InverseProperty("HastalikKaydis")]
        public virtual Eleman Eleman { get; set; }
        [ForeignKey(nameof(HastalikId))]
        [InverseProperty(nameof(Hastaliklar.HastalikKaydis))]
        public virtual Hastaliklar Hastalik { get; set; }
        [ForeignKey(nameof(IlacId))]
        [InverseProperty(nameof(Recete.HastalikKaydis))]
        public virtual Recete Ilac { get; set; }
        [ForeignKey(nameof(SemptomId))]
        [InverseProperty("HastalikKaydis")]
        public virtual Semptom Semptom { get; set; }
    }
}
