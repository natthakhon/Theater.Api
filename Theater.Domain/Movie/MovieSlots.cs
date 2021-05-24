using System;
using System.Collections.Generic;
using System.Text;

namespace Theater.Domain.Movie
{
    public class MovieSlots
    {
        public Movie Movie { set; get; }
        public TimeSlots TimeSlots { set; get; }
    }
}
