using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FullMin.TravellingSalesman
{
    public class MST
    {
        public List<Point> MSTtoTSP(List<Point> cities)
        {
            // Calculate the Minimum Spanning Tree (MST) of the cities using Prim's algorithm
            List<Point> mst = PrimMST(cities);

            // Perform a Depth-First Search (DFS) traversal of the MST to generate the TSP tour
            List<Point> tour = new List<Point>();
            HashSet<Point> visited = new HashSet<Point>();
            DFS(mst[0], visited, tour, mst);

            // Return to the starting city to complete the tour
            //tour.Add(tour[0]);

            return tour;
        }

        private List<Point> PrimMST(List<Point> cities)
        {
            // Calculate the Minimum Spanning Tree (MST) of the cities using Prim's algorithm
            List<Point> mst = new List<Point>();
            HashSet<Point> visited = new HashSet<Point>();
            PriorityQueue<Edge> pq = new PriorityQueue<Edge>();

            // Start with the first city
            visited.Add(cities[0]);

            // Add edges from the first city to all other cities
            foreach (Point city in cities)
            {
                if (city != cities[0])
                {
                    pq.Enqueue(new Edge(cities[0], city, CalculateDistance(cities[0], city)));
                }
            }

            while (!pq.IsEmpty && visited.Count < cities.Count)
            {
                Edge edge = pq.Dequeue();
                if (!visited.Contains(edge.To))
                {
                    visited.Add(edge.To);
                    mst.Add(edge.To);

                    foreach (Point city in cities)
                    {
                        if (!visited.Contains(city))
                        {
                            pq.Enqueue(new Edge(edge.To, city, CalculateDistance(edge.To, city)));
                        }
                    }
                }
            }

            return mst;
        }

        private void DFS(Point currentCity, HashSet<Point> visited, List<Point> tour, List<Point> mst)
        {
            visited.Add(currentCity);
            tour.Add(currentCity);

            foreach (Point city in mst)
            {
                if (!visited.Contains(city))
                {
                    DFS(city, visited, tour, mst);
                }
            }
        }

        private double CalculateDistance(Point p1, Point p2)
        {
            // Calculate the Euclidean distance between two points
            return Math.Sqrt(Math.Pow(p1.X - p2.X, 2) + Math.Pow(p1.Y - p2.Y, 2));
        }
        private double CalculateTourDistance(List<Point> tour)
        {
            double totalDistance = 0;

            for (int i = 0; i < tour.Count - 1; i++)
            {
                totalDistance += CalculateDistance(tour[i], tour[i + 1]);
            }

            // Return to the starting city to complete the tour
            totalDistance += CalculateDistance(tour[tour.Count - 1], tour[0]);

            return totalDistance;
        }
        public List<Point> TwoOpt(List<Point> tour)
        {
            List<Point> bestTour = new List<Point>(tour);
            bool improvement = true;

            while (improvement)
            {
                improvement = false;

                for (int i = 0; i < tour.Count - 1; i++)
                {
                    for (int j = i + 1; j < tour.Count; j++)
                    {
                        List<Point> newTour = TwoOptSwap(tour, i, j);

                        double currentDistance = CalculateTourDistance(tour);
                        double newDistance = CalculateTourDistance(newTour);

                        if (newDistance < currentDistance)
                        {
                            tour = newTour;
                            improvement = true;
                        }
                    }
                }

                if (improvement)
                {
                    bestTour = new List<Point>(tour);
                }
            }

            return bestTour;
        }

        private List<Point> TwoOptSwap(List<Point> tour, int i, int j)
        {
            List<Point> newTour = new List<Point>(tour.Count);

            // Add tour[0] to tour[i-1] in order
            for (int k = 0; k <= i - 1; k++)
            {
                newTour.Add(tour[k]);
            }

            // Add tour[i] to tour[j] in reverse order
            for (int k = j; k >= i; k--)
            {
                newTour.Add(tour[k]);
            }

            // Add tour[j+1] to end of the tour in order
            for (int k = j + 1; k < tour.Count; k++)
            {
                newTour.Add(tour[k]);
            }

            return newTour;
        }
    }
    class Edge : IComparable<Edge>
    {
        public Point From { get; set; }
        public Point To { get; set; }
        public double Weight { get; set; }

        public Edge(Point from, Point to, double weight)
        {
            From = from;
            To = to;
            Weight = weight;
        }

        public int CompareTo(Edge other)
        {
            return Weight.CompareTo(other.Weight);
        }
    }

    // Priority queue implementation for Prim's algorithm
    class PriorityQueue<T> where T : IComparable<T>
    {
        private List<T> heap;

        public int Count { get { return heap.Count; } }
        public bool IsEmpty { get { return heap.Count == 0; } }

        public PriorityQueue()
        {
            heap = new List<T>();
        }

        public void Enqueue(T item)
        {
            heap.Add(item);
            HeapifyUp(heap.Count - 1);
        }

        public T Dequeue()
        {
            T item = heap[0];
            heap[0] = heap[heap.Count - 1];
            heap.RemoveAt(heap.Count - 1);
            HeapifyDown(0);
            return item;
        }

        private void HeapifyUp(int index)
        {
            int parent = (index - 1) / 2;
            while (index > 0 && heap[index].CompareTo(heap[parent]) < 0)
            {
                Swap(index, parent);
                index = parent;
                parent = (index - 1) / 2;
            }
        }

        private void HeapifyDown(int index)
        {
            int leftChild = index * 2 + 1;
            int rightChild = index * 2 + 2;
            int smallest = index;

            if (leftChild < heap.Count && heap[leftChild].CompareTo(heap[smallest]) < 0)
            {
                smallest = leftChild;
            }

            if (rightChild < heap.Count && heap[rightChild].CompareTo(heap[smallest]) < 0)
            {
                smallest = rightChild;
            }

            if (smallest != index)
            {
                Swap(index, smallest);
                HeapifyDown(smallest);
            }
        }

        private void Swap(int i, int j)
        {
            T temp = heap[i];
            heap[i] = heap[j];
            heap[j] = temp;
        }
    }
}
