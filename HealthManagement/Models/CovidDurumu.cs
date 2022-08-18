using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

#nullable disable

namespace HealthManagement.Models
{
    [Table("CovidDurumu")]
    public partial class CovidDurumu
    {
        [Key]
        [Column("CovidDurumuID")]
        public int CovidDurumuId { get; set; }
        [Column(TypeName = "date")]
        public DateTime? CovidBaslangic { get; set; }
        [Column(TypeName = "date")]
        public DateTime? CovidBitis { get; set; }
        public bool? Covid { get; set; }
        public bool? KronikHastalık { get; set; }
        [Column("BelirtiID")]
        public int? BelirtiId { get; set; }
        [Column("AsiID")]
        public int? AsiId { get; set; }
        [Key]
        [Column("ElemanID")]
        public int ElemanId { get; set; }

        [ForeignKey(nameof(AsiId))]
        [InverseProperty("CovidDurumus")]
        public virtual Asi Asi { get; set; }
        [ForeignKey(nameof(BelirtiId))]
        [InverseProperty("CovidDurumus")]
        public virtual Belirti Belirti { get; set; }
        [ForeignKey(nameof(ElemanId))]
        [InverseProperty("CovidDurumus")]
        public virtual Eleman Eleman { get; set; }
    }
}
