using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Theater.Domain.Movie;

namespace Theater.Domain.Validator.Movie
{
    public interface ITimeSlotsChecker
    {
        Task<bool> AreSlotsExisted(List<TimeSlot> timeSlots);
        Task<bool> IsNameExisted(string name);
    }
}
