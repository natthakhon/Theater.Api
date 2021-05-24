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
        [Required]
        [MaxLength(50)]
        public string Name { get; set; }
    }
}
