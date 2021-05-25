using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Theater.Data.Sqlite.Movie
{
    [Table("Movie")]
    public class Movie
    {
        [Key]
        [Required]
        [MaxLength(50)]
        public string Name { get; set; }
        public DateTime CreateDate { get; set; }
        public DateTime? UpdateDate { get; set; }
    }
}
