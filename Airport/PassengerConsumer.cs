using System;
using System.Collections.Generic;
using Airport.queues;

namespace Airport
{
    public class PassengerConsumer
    {
        private List<Plane> planes;
        private NotPrioritisingPassengerArrayQueue<Passenger> queue;
        private int processingTicksLeft = 0;
        // Passenger being processed
        private Passenger passenger;

        public PassengerConsumer(List<Plane> planes, NotPrioritisingPassengerArrayQueue<Passenger> queue) {
            this.planes = planes;
            this.queue = queue;
        }
  
        public void Tick(Clock clock) {
            if (processingTicksLeft > 0) {
                processingTicksLeft--;
                return;
            }
    
            if (passenger != null) {
                Time now = clock.getTime();
                if (passenger.GetPlane().GetDepartureTime().CompareTo(now) < 0) {
                    passenger.SetStatus(Status.MissedPlane);
                    Console.WriteLine("Passenger "+passenger+" missed the plane");
                }
                else {
                    passenger.SetStatus(Status.Boarded);
                    Console.WriteLine("Passenger "+passenger+" has boarded");
                }
            }
    
            if (queue.IsEmpty()) return;
 
            passenger = queue.Dequeue();
            switch (passenger.GetCategory()) {
                case Category.LateToFlight:
                    processingTicksLeft = 60;
                    break;
                case Category.BusinessClass:
                    processingTicksLeft = 60;
                    break;
                case Category.Disabled:
                    processingTicksLeft = 180;
                    break;
                case Category.Family:
                    processingTicksLeft = 180;
                    break;
                case Category.Monkey:
                    processingTicksLeft = 60;
                    break;
            }
    
        }
    }
}