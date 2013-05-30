using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace _3.CustomExeption
{
    public class InvalidRangeExeption<T>:ApplicationException
    {
        private DateTime StartTime { get; set; }
        private DateTime EndTime { get; set; }
        private int StartInt { get; set; }
        private int EndInt { get; set; }
        public InvalidRangeExeption(DateTime start,DateTime end,string msg,Exception ex):base(msg,ex)
        {
            this.StartTime = start;
            this.EndTime = end;
        }
        public InvalidRangeExeption(int start, int end, string msg, Exception ex)
            : base(msg, ex)
        {
            this.StartInt = start;
            this.EndInt = end;
        }
        
        
    }
}