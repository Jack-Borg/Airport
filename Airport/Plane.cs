using System;
using System.Collections;
using System.Collections.Generic;

namespace Airport
{
    public class Plane
    {
        private Time departureTime;
        private int seatCount = 200;
        private List<Passenger> passengers = new List<Passenger>();
        
        public override string ToString() {
            return "Plane that leaves at "+departureTime;
        }

        public Plane(Time departureTime) {
            this.departureTime = departureTime;
        }

        public Time GetDepartureTime() {
            return departureTime;
        }

        public int GetSeatCount() {
            return seatCount;
        }

        public List<Passenger> GetPassengers() {
            return passengers;
        }

        public void SetSeatCount(int seatCount) {
            this.seatCount = seatCount;
        }
    }
}