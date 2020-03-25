using System;

namespace Airport.queues
{
    public class PriorityQueue
    {
        public Passenger[,] Buckets;
        private int[] sizes;
        private int[] heads;
        private int[] tails;
        private int maxSize;

        public PriorityQueue(int size)
        {
            int numCategory = Enum.GetValues(typeof(Category)).Length;
            Buckets = new Passenger[numCategory, size];
            sizes = new int[numCategory];
            heads = new int[numCategory];
            tails = new int[numCategory];
            maxSize = size;
        }

        public void Enqueue(Passenger p)
        {
            int category = (int) p.GetCategory();

            if (sizes[category] == maxSize)
                throw new Exception("Cannot add to full queue");


            Buckets[category, tails[category]] = p;
            tails[category] = (tails[category] + 1) % maxSize;
            sizes[category]++;
        }

        public Passenger Dequeue()
        {
            for (int category = 0; category < Buckets.Length; category++)
            {
                if (sizes[category] > 0)
                {
                    Passenger p = Buckets[category, heads[category]];
                    heads[category] = (heads[category] + 1) % maxSize;
                    sizes[category]--;
                    return p;
                }
            }
            throw new Exception("Cannot remove from empty queue");
        }
        
        public Passenger Peek() {
            for (int category = 0; category < Buckets.Length; category++)
            {
                if (sizes[category] > 0)
                {
                    return Buckets[category, heads[category]];
                }
            }
            throw new Exception("Cannot peek into empty queue");
        }
    }
}