using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DocUp.Dal.Entities
{
    [Table("Clinics")]
    public class ClinicEntity
    {
        [Key]
        [Required]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        [Required]
        public int AccountId { get; set; }

        [ForeignKey("AccountId")]
        public virtual AccountEntity Account { get; set; }

        [MaxLength(512)]
        public string Name { get; set; }

        [MaxLength(512)]
        public string Place { get; set; }

        [Required]
        [MaxLength(20)]
        public string PhoneNumber { get; set; }

        public virtual ICollection<DoctorEntity> Doctors { get; set; }
    }
}
