using System;
using System.Collections.Generic;
using System.Text;

namespace Theater.Domain.Movie
{
    public class TimeSlots
    {
        public string Name { set; get; }
        public List<TimeSlot> Slots { set; get; }
    }
}
