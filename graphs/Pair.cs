using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace graphs
{
    class Pair
    {
        Vertex vertex;
        int lenght;

        public Vertex Vertex
        {
            get { return vertex; }
        }

        public int Length
        {
            get { return lenght; }
        }

        public Pair(Vertex _vertex, int _length)
        {
            vertex = _vertex;
            lenght = _length;
        }

    }
}
