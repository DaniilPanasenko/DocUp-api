using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DocUp.Dal.Entities
{
    [Table("Doctors")]
    public class DoctorEntity
    {
        [Key]
        [Required]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        [Required]
        public int AccountId { get; set; }

        [ForeignKey("AccountId")]
        public virtual AccountEntity Account { get; set; }

        [MaxLength(64)]
        public string Name { get; set; }

        [MaxLength(64)]
        public string Surname { get; set; }

        [MaxLength(64)]
        public string Position { get; set; }

        [MaxLength(20)]
        public string PhoneNumber { get; set; }

        [Required]
        public int ClinicId { get; set; }

        [ForeignKey("ClinicId")]
        public virtual ClinicEntity Clinic { get; set; }

        public virtual ICollection<PatientEntity> Patients { get; set; }
    }
}
