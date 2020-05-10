using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace graphs
{
    class adjElement
    {
        Vertex vertex;
        List<Pair> adj_vertices;
        public Vertex Vertex
        {
            get { return vertex; }
        }

        public List<Pair> Adj_vertices 
        {
            get { return adj_vertices; }  
        }

        public adjElement(Vertex _vertex)
        {
            vertex = _vertex;
            adj_vertices = new List<Pair>();
        }

        public adjElement(Vertex _vertex, List<Pair> _adj_vertices)
        {
            vertex = _vertex;
            adj_vertices = _adj_vertices;
        }
    }
}
