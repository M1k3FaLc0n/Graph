using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace graphs
{
    class Graph
    {
        List<Vertex> verticies;
        List<Edge> edges;
        public List<Vertex> Vertices
        {
            get
            {
                return verticies;
            }
        }
        public List<Edge> Edges
        {
            get
            {
                return edges;
            }
        }

        public Graph()
        {
            verticies = new List<Vertex>();
            edges = new List<Edge>();
        }

        public Graph(List<Vertex> _verticies, List<Edge> _edges)
        {
            verticies = _verticies;
            edges = _edges;
        }
    }
}
