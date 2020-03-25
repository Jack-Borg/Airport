using System;

namespace Airport.queues
{
    public class NotPrioritisingPassengerArrayQueue<TPassenger>
    {
        private Passenger[] items;
        private int size = 0;
        private int head = 0; // index of the current front item, if one exists
        private int tail = 0; // index of next item to be added

        public NotPrioritisingPassengerArrayQueue(int capacity)
        {
            //items = (T[])new Object[capacity];
            items = new Passenger[capacity];
        }

        public void Enqueue(Passenger item) {
            if (size == items.Length)
                throw new Exception("Cannot add to full queue");
            items[tail] = item;
            tail = (tail + 1) % items.Length;
            size++;
        }

        public Passenger Dequeue() {
            if (size == 0)
                throw new Exception("Cannot remove from empty queue");
            Passenger item = items[head];
            items[head] = null;
            head = (head + 1) % items.Length;
            size--;
            return item;
        }

        public Passenger Peek() {
            if (size == 0)
                throw new Exception("Cannot peek into empty queue");
            return items[head];
        }

        public int GetSize() { return size; }

        public bool IsEmpty() { return size < 1; }
    }
}