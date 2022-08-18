using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

#nullable disable

namespace HealthManagement.Models
{
    [Table("Eleman")]
    public partial class Eleman
    {
        public Eleman()
        {
            CovidDurumus = new HashSet<CovidDurumu>();
            HastalikKaydis = new HashSet<HastalikKaydi>();
        }

        [Key]
        [Column("ElemanID")]
        public int ElemanId { get; set; }
        [Required]
        [StringLength(50)]
        public string Isim { get; set; }
        [StringLength(50)]
        public string Soyisim { get; set; }
        [Required]
        [StringLength(50)]
        public string Maas { get; set; }
        public long TcNo { get; set; }
        [Required]
        [StringLength(50)]
        public string Pozisyon { get; set; }
        [StringLength(50)]
        public string Hobiler { get; set; }
        [Column("EgitimID")]
        public int EgitimId { get; set; }
        [Column("KanGrubuID")]
        public int KanGrubuId { get; set; }
        [Column("SehirID")]
        public int? SehirId { get; set; }

        [ForeignKey(nameof(EgitimId))]
        [InverseProperty("Elemen")]
        public virtual Egitim Egitim { get; set; }
        [ForeignKey(nameof(KanGrubuId))]
        [InverseProperty("Elemen")]
        public virtual KanGrubu KanGrubu { get; set; }
        [ForeignKey(nameof(SehirId))]
        [InverseProperty("Elemen")]
        public virtual Sehir Sehir { get; set; }
        [InverseProperty(nameof(CovidDurumu.Eleman))]
        public virtual ICollection<CovidDurumu> CovidDurumus { get; set; }
        [InverseProperty(nameof(HastalikKaydi.Eleman))]
        public virtual ICollection<HastalikKaydi> HastalikKaydis { get; set; }
    }
}
