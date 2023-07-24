using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FullMin.TravellingSalesman
{
    public class TSPNew
    {
        private Random random = new Random();
        public List<Point> SolveTSP(List<Point> locations)
        {
            int populationSize = 100;
            int generations = 1000;
            double mutationRate = 0.02;

            // Generate an initial population of random routes
            List<List<Point>> population = new List<List<Point>>();
            for (int i = 0; i < populationSize; i++)
            {
                List<Point> route = new List<Point>(locations);
                ShuffleRoute(route); // Shuffle the route to create a random path
                population.Add(route);
            }

            // Evolve the population through generations
            for (int gen = 0; gen < generations; gen++)
            {
                population = EvolvePopulation(population, mutationRate);
            }

            // Get the best route from the final population
            List<Point> bestRoute = population[0];

            return bestRoute;
        }

        private void ShuffleRoute(List<Point> route)
        {
            // Shuffle the route using Fisher-Yates algorithm
            int n = route.Count;
            while (n > 1)
            {
                n--;
                int k = random.Next(n + 1);
                Point temp = route[k];
                route[k] = route[n];
                route[n] = temp;
            }
        }

        private double CalculateDistance(Point p1, Point p2)
        {
            // Calculate the Euclidean distance between two points
            return Math.Sqrt(Math.Pow(p1.X - p2.X, 2) + Math.Pow(p1.Y - p2.Y, 2));
        }

        private double CalculateRouteDistance(List<Point> route)
        {
            double totalDistance = 0;
            for (int i = 0; i < route.Count - 1; i++)
            {
                totalDistance += CalculateDistance(route[i], route[i + 1]);
            }
            totalDistance += CalculateDistance(route[route.Count - 1], route[0]); // Return to the starting point
            return totalDistance;
        }

        private List<List<Point>> EvolvePopulation(List<List<Point>> population, double mutationRate)
        {
            List<List<Point>> newPopulation = new List<List<Point>>();

            // Get the best route and add it to the new population (elitism)
            List<Point> bestRoute = GetBestRoute(population);
            newPopulation.Add(bestRoute);

            // Create offspring through crossover and mutation
            while (newPopulation.Count < population.Count)
            {
                // Select two parents through tournament selection
                List<Point> parent1 = TournamentSelection(population);
                List<Point> parent2 = TournamentSelection(population);

                // Perform crossover to create a new route
                List<Point> child = Crossover(parent1, parent2);

                // Perform mutation
                if (random.NextDouble() < mutationRate)
                {
                    Mutate(child);
                }

                newPopulation.Add(child);
            }

            return newPopulation;
        }

        private List<Point> GetBestRoute(List<List<Point>> population)
        {
            // Find the route with the shortest distance in the population
            double shortestDistance = double.MaxValue;
            List<Point> bestRoute = null;

            foreach (List<Point> route in population)
            {
                double distance = CalculateRouteDistance(route);
                if (distance < shortestDistance)
                {
                    shortestDistance = distance;
                    bestRoute = new List<Point>(route);
                }
            }

            return bestRoute;
        }

        private List<Point> TournamentSelection(List<List<Point>> population)
        {
            // Select a random subset of the population and return the route with the shortest distance
            int tournamentSize = 10;
            List<List<Point>> tournament = new List<List<Point>>();
            for (int i = 0; i < tournamentSize; i++)
            {
                int index = random.Next(population.Count);
                tournament.Add(new List<Point>(population[index]));
            }
            return GetBestRoute(tournament);
        }

        private List<Point> Crossover(List<Point> parent1, List<Point> parent2)
        {
            // Perform ordered crossover to create a new route
            int startPos = random.Next(parent1.Count);
            int endPos = random.Next(startPos + 1, parent1.Count);

            List<Point> child = new List<Point>();

            for (int i = startPos; i < endPos; i++)
            {
                child.Add(parent1[i]);
            }

            foreach (Point location in parent2)
            {
                if (!child.Contains(location))
                {
                    child.Add(location);
                }
            }

            return child;
        }

        private void Mutate(List<Point> route)
        {
            // Perform swap mutation by randomly swapping two locations in the route
            int pos1 = random.Next(route.Count);
            int pos2 = random.Next(route.Count);

            Point temp = route[pos1];
            route[pos1] = route[pos2];
            route[pos2] = temp;
        }
    }
}
