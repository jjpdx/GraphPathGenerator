using GraphPathGenerator.Components;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GraphPathGenerator.Core.Models
{
    public class ProximityIndex
    {
        public List<Vertex> Vertices { get; set; }
        public List<Edge> Edges { get; set; }
    }
}
