using System;
using System.Collections.Generic;
using Airport.queues;

namespace Airport
{
    class Program
    {
        private static List<Plane> planes = new List<Plane>();
        private static PassengerProducer producer;
        private static PassengerConsumer consumer;
        private static NotPrioritisingPassengerArrayQueue<Passenger> queue;
        private static Clock clock;
  
        private static void Setup() {
            for (int hour = 7; hour <= 22; hour++) {
                planes.Add(new Plane(new Time(hour, 00, 00)));
            }
            queue = new NotPrioritisingPassengerArrayQueue<Passenger>(10000);
            producer = new PassengerProducer(planes, queue);
            consumer = new PassengerConsumer(planes, queue);
            clock = new Clock(producer, consumer, new Time(05, 00, 00));
        }
  
        public static void Main(String[] args) {
            Setup();
            Console.WriteLine("Hello Airport");
            //new Thread(clock).start();
        }
    }
}