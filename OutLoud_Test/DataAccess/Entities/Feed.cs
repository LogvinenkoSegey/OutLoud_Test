using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace OutLoud_Test.DataAccess.Entities
{
    [Table("Feeds")]
    public class Feed : BaseEntity
    {
        [Column("Title")]
        [Required]
        [StringLength(100)]
        public string Title { get; set; }

        [Column("Description")]
        [Required]
        [StringLength(10000)]
        public string Description { get; set; }

        [Column("URL")]
        [Required]
        [StringLength(1000)]
        public string URL { get; set; }

        [Column("IsActive")]
        [Required]
        public bool IsActive { get; set; }

        public List<News> News { get; set; }
    }
}
