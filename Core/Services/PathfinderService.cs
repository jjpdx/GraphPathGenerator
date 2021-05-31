using GraphPathGenerator.Components;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GraphPathGenerator.Core.Services
{
    public class PathfinderService
    {
        public LinkedList<Guid> GetShortestPath (Guid startVertex, Guid endVertex, List<Vertex> vertices, List<Edge> edges)
        {
            var proximityMap = GetProximityMap(startVertex, vertices, edges);
            var endMapNode = proximityMap.FirstOrDefault(n => n.Key == endVertex); //get end vertex from map
            var path = new LinkedList<Guid>();
            var currentNode = endMapNode;
            for (int i = endMapNode.Value.Item2; i >= 0 ; i--) //start at distance of endvertex, continue until distance is zero at startvertex
            {
                path.AddFirst(currentNode.Key);
                currentNode = proximityMap.FirstOrDefault(n => n.Key == currentNode.Value.Item1);; //set current node key to direct ancestor
            }

            return path;
        }

        //Creates a dictionary of each vertex with their Id as the key, the value of which is a tuple of their direct ancestor's Id and the overall distance from the start vertex.
        public Dictionary<Guid, Tuple<Guid, int>> GetProximityMap(Guid startVertex, List<Vertex> vertices, List<Edge> edges)
        {
            var result = new Dictionary<Guid, Tuple<Guid, int>>();

            result.Add(startVertex, Tuple.Create(Guid.Empty, 0)); // add starting vertex with distance 0
            var distanceIndex = 1; //index of all adjacent new vertices in map.

            var currentDistanceQueue = new Queue<Guid>(); //currently iterating vertices at distanceIndex from startvertex
            currentDistanceQueue.Enqueue(startVertex);

            var nextDistanceQueue = new List<Guid>(); //temp list to hold all vertices currently being identified at next increment of distance

            while (result.Count < vertices.Count) //ends when all vertices are accounted for or when there are no more connected vertices to explore
            {
                while (currentDistanceQueue.Count > 0) //while queue is not empty
                {
                    var currentVertex = currentDistanceQueue.Dequeue();
                    foreach (Guid g in FindAllAdjacentVertices(currentVertex, vertices, edges))
                    {
                        if (!result.ContainsKey(g)) //if key has not already been explored (any vertex that has already been added must have a shorter or equivalent length path from start vertex)
                        {
                            result.Add(g, Tuple.Create(currentVertex, distanceIndex));
                            nextDistanceQueue.Add(g);
                        }
                    }
                }

                distanceIndex += 1;
                foreach (Guid g in nextDistanceQueue)
                    currentDistanceQueue.Enqueue(g);

                if (nextDistanceQueue.Count == 0) //if there are no more adjacent vertices that haven't already been explored then end the loop.
                    break;

                nextDistanceQueue.Clear();
            }

            return result;
        }

        public List<Guid> FindAllAdjacentVertices(Guid vertexId, List<Vertex> vertices, List<Edge> edges)
        {
            var result = new List<Guid>();
            foreach(Edge e in edges.Where(e => e.ContainsVertex(vertexId)))
            {
                result.Add(e.GetMatchingVertexPartner(vertexId));
            }
            return result;
        }
    }
}
