﻿namespace Airport.queues
{
    public interface IQueue<T>
    {
        /**
        * Enqueue an item.
        * Add an element to the tail of the queue.
        * @param item to enqueue
        */
        void Enqueue(T item);

        /**
        * Dequeue an item.
        * Removes the item at the head of the queue and returns it.
        * @return the item dequeued
        * @throws java.util.NoSuchElementException if the queue is empty.
        */
        T Dequeue();

        /**
        * Peek at the first item in the queue.
        * @return the item at the head of the queue
        * @throws java.util.NoSuchElementException if the queue is empty.
        */
        T Peek();

        /**
        * Size of the queue.
        * @return the number of items currently in the queue.
        */
        int Size();

        /**
        * Is the queue empty.
        * @return whether the queue is empty.
        */
        bool IsEmpty() { return Size() == 0 ; }
    }
}