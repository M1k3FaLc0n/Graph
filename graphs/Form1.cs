using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace graphs
{
    public partial class Form1 : Form
    {
        Graph graph;
        Button start;
        Button end;

        public Form1()
        {
            InitializeComponent();

            start = null;
            end = null;
            btnSearch.Enabled = false;
        }

        private List<Button> get_list_buttons()
        {
            List<Button> buttons = new List<Button>();
            buttons.Add(vertex1);
            buttons.Add(vertex2);
            buttons.Add(vertex3);
            buttons.Add(vertex4);
            buttons.Add(vertex5);
            buttons.Add(vertex6);
            buttons.Add(vertex7);
            buttons.Add(vertex8);
            buttons.Add(vertex9);
            buttons.Add(vertex10);
            buttons.Add(vertex11);
            return buttons;
        }

        private List<Edge> get_list_edges(List<Vertex> verticies)
        {
            List<Edge> edges = new List<Edge>();
            edges.Add(new Edge(verticies[0], verticies[1], DrawDirections.right));
            edges.Add(new Edge(verticies[0], verticies[2], DrawDirections.down));
            edges.Add(new Edge(verticies[2], verticies[3], DrawDirections.down));
            edges.Add(new Edge(verticies[3], verticies[7], DrawDirections.right));
            edges.Add(new Edge(verticies[4], verticies[7], DrawDirections.down));
            edges.Add(new Edge(verticies[4], verticies[5], DrawDirections.right));
            edges.Add(new Edge(verticies[5], verticies[6], DrawDirections.down));
            edges.Add(new Edge(verticies[6], verticies[8], DrawDirections.down));
            edges.Add(new Edge(verticies[7], verticies[8], DrawDirections.right));
            edges.Add(new Edge(verticies[8], verticies[9], DrawDirections.right));
            edges.Add(new Edge(verticies[9], verticies[10], DrawDirections.down));
            return edges;
        }

        private void init_graph()
        {
            List<Button> buttons = get_list_buttons();
            List<Vertex> verticies = new List<Vertex>();
            for(int i = 0; i < buttons.Count; i++)
            {
                verticies.Add(new Vertex(buttons[i]));
            }
            List<Edge> edges = get_list_edges(verticies);
            graph = new Graph(verticies, edges);
        }

        private void draw_horizontal_edge(PaintEventArgs e, Pen pen, Edge edge)
        {
            Size size_X = edge.X.Btn.Size;
            Size size_Y = edge.Y.Btn.Size;
            size_X.Height /= 2;
            size_Y.Height /= 2;
            Point p1 = edge.Y.Btn.Location;
            p1.Y += size_Y.Height;
            e.Graphics.DrawLine(pen, edge.X.Btn.Location + size_X, p1);
        }

        private void draw_vertical_edge(PaintEventArgs e, Pen pen, Edge edge)
        {
            Size size_X = edge.X.Btn.Size;
            Size size_Y = edge.Y.Btn.Size;
            size_X.Width /= 2;
            size_Y.Width /= 2;
            Point p1 = edge.X.Btn.Location + size_X;
            Point p2 = edge.Y.Btn.Location;
            p2.X += size_Y.Width;
            e.Graphics.DrawLine(pen, p1, p2);
        }

        protected override void OnPaint(PaintEventArgs e)
        {
            base.OnPaint(e);

            init_graph();

            using (var black_pen = new Pen(Color.Black, 15))
            {
                for (int i = 0; i < graph.Edges.Count; i++) 
                {
                    switch (graph.Edges[i].DrawDirection)
                    {
                        case DrawDirections.down:
                            draw_vertical_edge(e, black_pen, graph.Edges[i]);
                            graph.Edges[i].Length = Math.Abs(graph.Edges[i].X.Btn.Location.Y - graph.Edges[i].Y.Btn.Location.Y);
                            break;
                        case DrawDirections.right:
                            draw_horizontal_edge(e, black_pen, graph.Edges[i]);
                            graph.Edges[i].Length = Math.Abs(graph.Edges[i].X.Btn.Location.X - graph.Edges[i].Y.Btn.Location.X);
                            break;
                    }
                }
            }
        }

        private void btn_pressed(Button btn)
        {
            if(start != null)
            {
                start = btn;
                start.BackColor = Color.GreenYellow;
                return;
            }
            if(end != null)
            {
                end = btn;
                end.BackColor = Color.PaleVioletRed;
            }
            if(start != null && end != null)
            {
                btnSearch.Enabled = true;
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            btn_pressed(vertex1);
        }

        private void vertex2_Click(object sender, EventArgs e)
        {
            btn_pressed(vertex2);
        }

        private void vertex3_Click(object sender, EventArgs e)
        {
            btn_pressed(vertex3);
        }

        private void vertex4_Click(object sender, EventArgs e)
        {
            btn_pressed(vertex4);
        }

        private void vertex5_Click(object sender, EventArgs e)
        {
            btn_pressed(vertex5);
        }

        private void vertex6_Click(object sender, EventArgs e)
        {
            btn_pressed(vertex6);
        }

        private void vertex7_Click(object sender, EventArgs e)
        {
            btn_pressed(vertex7);
        }

        private void vertex8_Click(object sender, EventArgs e)
        {
            btn_pressed(vertex8);
        }

        private void vertex9_Click(object sender, EventArgs e)
        {
            btn_pressed(vertex9);
        }

        private void vertex10_Click(object sender, EventArgs e)
        {
            btn_pressed(vertex10);
        }

        private void vertex11_Click(object sender, EventArgs e)
        {
            btn_pressed(vertex11);
        }
    }
}
