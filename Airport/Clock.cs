using System.Threading;

namespace Airport
{
    public class Clock
    {
        private int sleepingTime = 10;
        private bool running = true;
        private PassengerProducer producer;
        private PassengerConsumer consumer;
        private long millis;
  
        public Clock(PassengerProducer producer, PassengerConsumer consumer, Time startTime) {
            this.producer = producer;
            this.consumer = consumer;
            this.millis = startTime.GetMillis();
        }
  
        public void stop() {
            running = false;
        }
  
        public Time getTime() {
            return new Time(millis);
        }
        
        public void Run() {
            while (running) {
                Thread.Sleep(sleepingTime);
                producer.Tick(this);
                consumer.Tick(this);
                millis += 1000;
            }
        }
    }
}