using System;

namespace Airport
{
    public class Passenger: IComparable<Passenger>
    {
        private int id;
        private Time arrivalTime;
        private Plane plane;
        private Category category;
        private Status status = Status.Waiting;
        
        public Passenger(int id, Time arrivalTime, Category category, Plane plane) {
            this.id = id;
            this.arrivalTime = arrivalTime;
            this.category = category;
            this.plane = plane;
        }

        public override string ToString()  
        {  
            return ""+id+") arrived "+arrivalTime+" as "+category+" and is "+status;
        }

        public int GetId() { return id; }
  
        public Time GetArrivalTime() { return arrivalTime; }
  
        public Plane GetPlane() { return plane; }
  
        public Category GetCategory() { return category; }

        public Status GetStatus() {
            return status;
        }

        public void SetStatus(Status status) {
            this.status = status;
        }

        public int CompareTo(Passenger other) {
            if (category.CompareTo(other.category) != 0)
                return category.CompareTo(other.category);
            return arrivalTime.CompareTo(other.arrivalTime);
        }
    }
}