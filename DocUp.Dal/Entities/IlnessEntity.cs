using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DocUp.Dal.Entities
{
    [Table("Ilnesses")]
    public class IlnessEntity
    {
        [Key]
        [Required]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        [Required]
        public string Name { get; set; }

        [Required]
        public int ClinicCall { get; set; }

        [Required]
        public int DoctorCall { get; set; }

        [Required]
        public int WatcherCall { get; set; }
    }
}
