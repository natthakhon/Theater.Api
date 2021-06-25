using System;
using System.Collections.Generic;
using System.Text;

namespace Theater.Domain.Movie
{
    public class Seat
    {
        public int Row { set; get; }
        public int Col { set; get; }
        public string SeatNo { get => this.Row.ToString() + this.Col.ToString(); }
        public bool IsSeated { set; get; }
    }
}
