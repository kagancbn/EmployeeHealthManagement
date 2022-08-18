using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

#nullable disable

namespace HealthManagement.Models
{
    [Table("KanGrubu")]
    public partial class KanGrubu
    {
        public KanGrubu()
        {
            Elemen = new HashSet<Eleman>();
        }

        [Key]
        [Column("KanGrubuID")]
        public int KanGrubuId { get; set; }
        [Required]
        [Column("KanGrubu")]
        [StringLength(50)]
        public string KanGrubu1 { get; set; }

        [InverseProperty(nameof(Eleman.KanGrubu))]
        public virtual ICollection<Eleman> Elemen { get; set; }
    }
}
