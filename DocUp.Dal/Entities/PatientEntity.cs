using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DocUp.Dal.Entities
{
    [Table("Patients")]
    public class PatientEntity
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

        [MaxLength(20)]
        public string PhoneNumber { get; set; }

        [MaxLength(512)]
        public string Address { get; set; }

        public int Age { get; set; }

        [MaxLength(64)]
        public string WatcherName { get; set; }

        [MaxLength(64)]
        public string WatcherSurname { get; set; }

        [MaxLength(20)]
        public string WatcherPhoneNumber { get; set; }

        [Required]
        public int DoctorId { get; set; }

        [ForeignKey("DoctorId")]
        public virtual DoctorEntity Doctor { get; set; }

        public virtual ICollection<PatientIlnessEntity> Ilnesses { get; set; }

    }
}
