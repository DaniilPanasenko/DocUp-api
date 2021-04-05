using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DocUp.Dal.Entities
{
    [Table("Readings")]
    public class ReadingEntity
    {
        [Key]
        [Required]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        public int DeviceId { get; set; }

        [ForeignKey("DeviceId")]
        public virtual DeviceEntity Device { get; set; }

        public int Percent { get; set; }

        public DateTimeOffset DateTime { get; set; }

        public string Data { get; set; }
    }
}
