using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace graphs
{
    class Dijkstra
    {
        public static List<Vertex> dijkstra_algo(Graph graph, Vertex start_vertex, Vertex end_vertex)
        {
            List<adjElement> adj_list = get_adj_list(graph);
            int n = adj_list.Count;
            List<int> distance = get_init_array(n);
            List<int> path = get_init_array(n);
            init_algo(distance, path, adj_list, start_vertex);

            bool[] used = new bool[n];
            for(int i = 0; i < n; i++)
            {
                int current_vertex = -1;
                for (int j=0; j < n; j++)
                {
                    if(!used[j] && (current_vertex == -1 || distance[j] < distance[current_vertex]))
                    {
                        current_vertex = j;
                    }
                }

                if (distance[current_vertex] == Int32.MaxValue)
                {
                    break;
                }

                used[current_vertex] = true;
                for(int j = 0; j < adj_list[current_vertex].Adj_vertices.Count; j++)
                {
                    int index_to_vertex = get_vertex_index(adj_list, adj_list[current_vertex].Adj_vertices[j].Vertex);
                    if(distance[current_vertex] + adj_list[current_vertex].Adj_vertices[j].Length < distance[index_to_vertex])
                    {
                        distance[index_to_vertex] = distance[current_vertex] + adj_list[current_vertex].Adj_vertices[j].Length;
                        path[index_to_vertex] = current_vertex;
                    }
                }
            }
            return get_short_path(adj_list, start_vertex, end_vertex, path);
        }

        private static List<Vertex> get_short_path(List<adjElement> adj_list, Vertex start_vertex, Vertex end_vertex, List<int> path)
        {
            List<Vertex> short_path = new List<Vertex>();
            int start_index = get_vertex_index(adj_list, start_vertex);
            int end_index = get_vertex_index(adj_list, end_vertex);

            while(path[end_index] != start_index)
            {
                short_path.Add(adj_list[end_index].Vertex);
                end_index = path[end_index];
            }

            short_path.Add(adj_list[end_index].Vertex);
            short_path.Add(adj_list[start_index].Vertex);
            return short_path;
        }

        private static void init_algo(List<int> distance, List<int> path, List<adjElement> adj_list, Vertex start_vertex)
        {
            int index_start_vertex = get_vertex_index(adj_list, start_vertex);
            if(index_start_vertex == -1)
            {
                return;
            }
            for(int i = 0; i < adj_list[index_start_vertex].Adj_vertices.Count; i++)
            {
                int index_cur_to_vertex = get_vertex_index(adj_list, adj_list[index_start_vertex].Adj_vertices[i].Vertex);
                distance[index_cur_to_vertex] = adj_list[index_start_vertex].Adj_vertices[i].Length;
                path[index_cur_to_vertex] = index_start_vertex;
            }

            distance[index_start_vertex] = 0;
        }

        private static List<int> get_init_array(int n)
        {
            List<int> array = new List<int>();
            for (int i = 0; i < n; i++)
            {
                array.Add(Int32.MaxValue);
            }
            return array;
        }
        private static int get_vertex_index(List<adjElement> adjList, Vertex vertex)
        {
            for (int i = 0; i < adjList.Count; i++)
            {
                if (adjList[i].Vertex.Equals(vertex))
                {
                    return i;
                }
            }
            return -1;
        }

        private static void add_adj_elem(List<adjElement> adjList, Vertex x, Vertex y, int length)
        {
            int index = get_vertex_index(adjList, x);
            if(index == -1)
            {
                return;
            }
            adjList[index].Adj_vertices.Add(new Pair(y,length));
        }

        private static List<adjElement> get_adj_list(Graph graph)
        {
            List<adjElement> adjList = new List<adjElement>();
            for(int i = 0; i < graph.Vertices.Count; i++)
            {
                adjList.Add(new adjElement(graph.Vertices[i]));
            }
            for(int i = 0; i < graph.Edges.Count; i++)
            {
                add_adj_elem(adjList, graph.Edges[i].X, graph.Edges[i].Y, graph.Edges[i].Length);
                add_adj_elem(adjList, graph.Edges[i].Y, graph.Edges[i].X, graph.Edges[i].Length);
            }
            return adjList;
        }
    }
}
