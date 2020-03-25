using System;

namespace Airport
{
    public class Time: IComparable<Time>
    {
        private long millis;
  
        public Time(long millis) {
            this.millis = millis;
        }
  
        public Time(int hour, int minute, int second) {
            millis = ((((long)hour)*60 + minute)*60 + second)*1000;
        }

        public long GetMillis() {
            return millis;
        }

        private static String Two(long number) {
            if (number >= 10) return ""+number;
            return "0"+number;
        }  
        
        public override string ToString() {
            long s = millis/1000;
            long m = s/60;
            long h = m/60;
            s = s%60;
            m = m%60;
            return Two(h)+":"+Two(m)+":"+Two(s);
        }
        
        public int CompareTo(Time other) {
            if (this.millis < other.millis) return -1;
            if (this.millis > other.millis) return 1;
            return 0;
        }

    }
}