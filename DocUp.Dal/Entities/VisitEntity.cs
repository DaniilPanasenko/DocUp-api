using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DocUp.Dal.Entities
{
    [Table("Visits")]
    public class VisitEntity
    {
        [Key]
        [Required]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        [Required]
        public int PatientId { get; set; }

        [ForeignKey("PatientId")]
        public virtual PatientEntity Patient { get; set; }

        [Required]
        public DateTimeOffset DateTime { get; set; }

        [MaxLength(64)]
        public string Status { get; set; }

        [MaxLength(2048)]
        public string Note { get; set; }
    }
}
