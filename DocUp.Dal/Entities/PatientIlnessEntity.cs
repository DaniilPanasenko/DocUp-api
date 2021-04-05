using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DocUp.Dal.Entities
{
    [Table("PatientIlnesses")]
    public class PatientIlnessEntity
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
        public int IlnessId { get; set; }

        [ForeignKey("IlnessId")]
        public virtual IlnessEntity Ilness { get; set; }

        public int? DeviceId { get; set; }

        [ForeignKey("DeviceId")]
        public virtual DeviceEntity Device { get; set; }
    }
}
