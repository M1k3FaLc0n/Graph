using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace graphs
{
    class Vertex
    {
        Button btn;
        States state;
        public Button Btn
        {
            get
            {
                return btn;
            }
        }
        public States State
        {
            get
            {
                return state;
            }
        }

        public Vertex(Button _btn)
        {
            btn = _btn;
            state = States.medium;
        }

        public Vertex(Button _btn, States _state)
        {
            btn = _btn;
            state = _state;
        }
    }
}
