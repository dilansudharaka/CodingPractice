using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataStructures_Algorithms
{
    public class RunwayReservationSystem 
    {
        public static void Main(string[] args)
        {
            int mindistance = 3;
            RunwayReservationSystem reservationSystem = new RunwayReservationSystem(mindistance);
            Console.WriteLine(reservationSystem.RequestReservertaion(20));
            Console.WriteLine(reservationSystem.RequestReservertaion(10));
            Console.WriteLine(reservationSystem.RequestReservertaion(30));
            Console.WriteLine(reservationSystem.RequestReservertaion(2));
            Console.WriteLine(reservationSystem.RequestReservertaion(13));
            Console.WriteLine(reservationSystem.RequestReservertaion(7));
            Console.WriteLine(reservationSystem.RequestReservertaion(22));
            Console.WriteLine(reservationSystem.RequestReservertaion(24));

            Console.WriteLine(reservationSystem.GetLandingFlightCountWithinT(12));
            Console.WriteLine(reservationSystem.GetLandingFlightCountWithinT(22));
            Console.WriteLine(reservationSystem.GetLandingFlightCountWithinT(26));
            Console.WriteLine(reservationSystem.GetLandingFlightCountWithinT(35));
            Console.WriteLine(reservationSystem.GetLandingFlightCountWithinT(3));
            Console.WriteLine(reservationSystem.GetLandingFlightCountWithinT(20));

        }

        private int minDistance;

        private Node root;

        private class Node
        {
            public Node Left { get; set; }
            public Node Right { get; set; }

            public int LandingTime { get; private set; }

            public int FlightCount { get; set; }

            public Node(int landingTime)
            {
                this.LandingTime = landingTime;
                this.FlightCount = 1;
            }            
        }

        public int GetLandingFlightCountWithinT(int t)
        {
            if(t <= 0)
            {
                return 0;
            }

            int sum = 0;
            return this.GetFlightCountRecursive(this.root, t, 0);
        }

        private int GetFlightCountRecursive(Node current, int maxTime, int currentSum)
        {
            if(current == null)
            {
                return currentSum;
            }

            if(maxTime == current.LandingTime)
            {
                currentSum += current.Left != null ? current.Left.FlightCount + 1 : 1;
                return currentSum;
            }

            if(maxTime < current.LandingTime)
            {
                return this.GetFlightCountRecursive(current.Left, maxTime, currentSum);
            }

            currentSum += current.Left != null ? current.Left.FlightCount + 1 : 1;
            return GetFlightCountRecursive(current.Right, maxTime, currentSum);
        }

        public RunwayReservationSystem(int minimumDistanceBetweenLandings)
        {
            if(minimumDistanceBetweenLandings <= 0)
            {
                throw new ArgumentException("Minumum distance has to be greater than zero");
            }

            this.minDistance = minimumDistanceBetweenLandings;
        }

        public bool RequestReservertaion(int landingTime)
        {
            if(landingTime <= 0)
            {
                return false;
            }

            if(this.root == null)
            {
                this.root = new Node(landingTime);                
                return true;
            }

            return InsertRecursive(this.root, landingTime);
        }

        private bool InsertRecursive(Node current, int landingTime)
        {
            bool isValid = false;
            int timeDifference = current.LandingTime - landingTime;
            if(Math.Abs(timeDifference) < this.minDistance)
            {
                return false;
            }

            if(timeDifference >= 0)
            {
                if (current.Left == null)
                {
                    current.Left = new Node(landingTime);
                    current.FlightCount++;
                    return true;
                }

                isValid = InsertRecursive(current.Left, landingTime);
                if(isValid)
                {
                    current.FlightCount++;
                }

                return isValid;
            }

            if(current.Right == null)
            {
                current.Right = new Node(landingTime);
                current.FlightCount++;
                return true;
            }

            isValid = InsertRecursive(current.Right, landingTime);
            if(isValid)
            {
                current.FlightCount++;
            }

            return isValid;
        }
    }
}
