using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DocUp.Dal.Entities
{
    [Table("Devices")]
    public class DeviceEntity
    {
        [Key]
        [Required]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        public int Seria { get; set; }

        public int? PatientIlnessId { get; set; }

        [ForeignKey("PatientIlnessId")]
        public virtual PatientIlnessEntity PatientIlness { get; set; }

        [Required]
        public int IlnessId { get; set; }

        [ForeignKey("IlnessId")]
        public virtual IlnessEntity Ilness { get; set; }

        public virtual ICollection<DeviceEntity> Devices { get; set; }
    }
}
