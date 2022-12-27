using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace OutLoud_Test.DataAccess.Entities
{
    public class BaseEntity
    {
        [Key]
        public long Id { get; set; }

        [Column("CreatedDate")]
        public DateTime CreatedDate { get; set; }

        [Column("UpdatedDate")]
        public DateTime UpdatedDate { get; set; }
    }
}
