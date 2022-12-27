using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace OutLoud_Test.DataAccess.Entities
{
    [Table("News")]
    public class News : BaseEntity
    {
        [Column("Title")]
        [Required]
        [StringLength(100)]
        public string Title { get; set; }

        [Column("Content")]
        [Required]
        [StringLength(10000)]
        public string Content { get; set; }

        [Column("IsRead")]
        [Required]
        public bool IsRead { get; set; }

        [Column("NewsDate")]
        [Required]
        public DateTime NewsDate { get; set; }

        [Column("FeedId")]
        [Required]
        public long FeedId { get; set; }


        public Feed Feed { get; set; }
    }
}
