using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace graphs
{
    class Edge
    {
        Vertex x;
        Vertex y;
        DrawDirections draw_direction;
        int length;
        public Vertex X
        {
            get
            {
                return x;
            }
        }
        public Vertex Y
        {
            get
            {
                return y;
            }
        }
        public int Length
        {
            get
            {
                return length;
            }
            set
            {
                length = value;
            }
        }
        public DrawDirections DrawDirection
        {
            get
            {
                return draw_direction;
            }
            set
            {
                draw_direction = value;
            }
        }

        public Edge(Vertex _x, Vertex _y)
        {
            x = _x;
            y = _y;
            draw_direction = DrawDirections.right;
            length = 0;
        }

        public Edge(Vertex _x, Vertex _y, DrawDirections _draw_direction)
        {
            x = _x;
            y = _y;
            draw_direction = _draw_direction;
            length = 0;
        }
        public Edge(Vertex _x, Vertex _y, DrawDirections _draw_direction, int _length)
        {
            x = _x;
            y = _y;
            draw_direction = _draw_direction;
            length = _length;
        }
    }
}
