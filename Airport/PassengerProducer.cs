using System;
using System.Collections.Generic;
using Airport.queues;

namespace Airport
{
    public class PassengerProducer
    {
        private static int nextPassengerId = 1;
        private List<Plane> planes;
        private NotPrioritisingPassengerArrayQueue<Passenger> queue;
        private int processingTicksLeft = 0;
        private Random randomizer = new Random();
        private Time lastDeartureTime;
  
        public PassengerProducer(List<Plane> planes, NotPrioritisingPassengerArrayQueue<Passenger> queue) {
            this.planes = planes;
            this.queue = queue;
            lastDeartureTime = planes[^1].GetDepartureTime();
        }
  
        public void Tick(Clock clock) {
            if (processingTicksLeft > 0) {
                processingTicksLeft--;
                return;
            }
            Time now = clock.getTime();
            if (now.CompareTo(lastDeartureTime) >= 0) {
                clock.stop();
                return;
            }
            Plane plane = null;
            while (plane == null) {
                foreach (Plane p in planes)
                {
                    if (p.GetDepartureTime().CompareTo(now) < 0) continue;
                    if (randomizer.Next(3) == 0) {
                        plane = p;
                        break;
                    }
                }
            }
    
            int c = randomizer.Next(100);
            Category category;
            if (plane.GetDepartureTime().GetMillis() - now.GetMillis() < 15*60*1000)
                category = Category.LateToFlight;
            else if (c < 10) category = Category.BusinessClass;
            else if (c < 11) category = Category.Disabled;
            else if (c < 15) category = Category.Family;
            else category = Category.Monkey;
    
            Passenger passenger = new Passenger(nextPassengerId++, now, category, plane);
            Console.WriteLine("Passenger "+passenger+" added to queue");
            queue.Enqueue(passenger);
    
            processingTicksLeft = randomizer.Next(120);
        }
    }
}