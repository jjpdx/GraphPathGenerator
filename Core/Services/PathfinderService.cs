using GraphPathGenerator.Components;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GraphPathGenerator.Core.Services
{
    public class PathfinderService
    {
        //Creates a dictionary of each vertex with their Id as the key, the value of which is a tuple of their direct ancestor's Id and the overall distance from the start vertex.
        public Dictionary<Guid, Tuple<Guid, int>> GetProximityIndex(Guid StartVertex, List<Vertex> vertices, List<Edge> edges)
        {
            var result = new Dictionary<Guid, int>();

            result.Add(StartVertex, 0); // add starting vertex with distance 0
            var currentVertex = StartVertex;
            var distanceIndex = 1; //

            var currentDistanceQueue = new Queue<Guid>();
            currentDistanceQueue.Enqueue(StartVertex);

            while (result.Count < vertices.Count) //ends when all vertices are accounted for, currently assumes that all vertices are connected.
            {
                while(currentDistanceQueue.Count > 0) 
                    foreach (Guid g in FindAllAdjacentVertices(currentDistanceQueue.Dequeue(), vertices, edges))
                    {
                        if (!result.ContainsKey(g))
                        {
                            result.Add(g, distanceIndex);
                        }
                    }


                distanceIndex += 1;
            }


            return result;
        }

        public List<Guid> FindAllAdjacentVertices(Guid VertexId, List<Vertex> vertices, List<Edge> edges)
        {
            var result = new List<Guid>();
            foreach(Edge e in edges.Where(e => e.ContainsVertex(VertexId)))
            {
                result.Add(e.GetMatchingVertexPartner(VertexId));
            }
            return result;
        }
    }
}
