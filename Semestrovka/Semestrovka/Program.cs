using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Diagnostics;

namespace Semestrovka
{

    class Program
    {
        public static GraphNode[] ChangeStart(Graph graphName, GraphNode start, GraphNode[] queue)
        {
            if (!start.Equals(queue.First()))
            {
                GraphNode tmpNode = queue[0];
                queue[0] = null;
                for (int i = 0; i < queue.Length; i++)
                {
                    if (queue[i] == start)
                    {
                        queue[i] = tmpNode;
                        queue[0] = start;
                        i = queue.Length;
                    }
                }
            }
            return queue;
        }
        public static void FindHamiltonianCycle(Graph graphName, string start)
        {
            var nodeStart = graphName.FindNode(start);
            int p = 0;
            Random random = new Random();
            GraphNode[] queue = new GraphNode[graphName.Nodes.Count];
            List<GraphNode> CheckedNodes = new List<GraphNode>();
            foreach (var nodes in graphName.Nodes)
            {
                queue[p] = nodes;
                if (p == queue.Length) break;
                p++;
            }
            queue = ChangeStart(graphName, nodeStart, queue);
            int index;
            GraphNode tmp;
            int arrayIndex;
            for (int i = 0; i < queue.Length - 1; i++)
            {
                while (!graphName.isCorridorExists(queue[i], queue[i + 1]))
                {

                    index = random.Next(0, graphName.GetConnectedNodes(queue[i]).Count);
                    arrayIndex = Array.IndexOf(queue, graphName.GetConnectedNodes(queue[i])[index]);
                    tmp = queue[i + 1];
                    if (!CheckedNodes.Any(nodes => nodes == queue[arrayIndex]))
                    {
                        queue[i + 1] = queue[arrayIndex];
                        queue[arrayIndex] = tmp;
                    }
                }
                CheckedNodes.Add(queue[i]);
            }
            Console.WriteLine("\nHamiltonian Cycle:\n");
            for (int i = 0; i < queue.Length; i++)
            {
                Console.WriteLine(" "+queue[i].Name);
            }
        }

        static void Main(string[] args)
        {
            var graph = new Graph(); // ab ac af cd dk bc bd gd gh gk kr qf hr qr
            Stopwatch timer = new Stopwatch();
            
            timer.Start();
            graph.AddNode("Зал ожидания"); // a
            timer.Stop();
            Console.WriteLine("Creating node: "+timer.Elapsed + "\n");
            timer.Reset();

            graph.AddNode("Кухня"); // b
            graph.AddNode("Тронный зал"); // c
            graph.AddNode("Картинный зал"); // d
            graph.AddNode("Команата прислуги"); // f
            graph.AddNode("Охрана"); // g
            graph.AddNode("Покои короля"); // h
            graph.AddNode("Библиотека"); // k
            graph.AddNode("Обмундирование"); // q
            graph.AddNode("Балкон"); // r
            graph.AddNode("Сад"); // m

            timer.Start();
            graph.AddCorridor("Зал ожидания", "Кухня"); // ab
            timer.Stop();
            Console.WriteLine("Adding the corridor: "+timer.Elapsed + "\n");
            timer.Reset();

            graph.AddCorridor("Зал ожидания", "Тронный зал"); // ac
            graph.AddCorridor("Зал ожидания", "Команата прислуги"); // af
            graph.AddCorridor("Покои короля", "Библиотека"); // hk
            graph.AddCorridor("Кухня", "Тронный зал"); // bc
            graph.AddCorridor("Тронный зал", "Картинный зал"); // cd
            graph.AddCorridor("Кухня", "Картинный зал"); // bd
            graph.AddCorridor("Охрана", "Картинный зал"); // gd
            graph.AddCorridor("Охрана", "Покои короля"); // gh 
            
            graph.AddCorridor("Команата прислуги", "Обмундирование"); // fq 
            graph.AddCorridor("Библиотека", "Балкон"); // kr
            graph.AddCorridor("Покои короля", "Балкон"); // hr
            graph.AddCorridor("Обмундирование", "Балкон"); // qr
            graph.AddCorridor("Сад", "Балкон");

            timer.Start();
            graph.RemoveCorridor("Сад", "Балкон");
            timer.Stop();
            Console.WriteLine("Removing the corridor: " + timer.Elapsed + "\n");
            timer.Reset();

            timer.Start();
            graph.RemoveNode("Сад");
            timer.Stop();
            Console.WriteLine("Removing the node: " + timer.Elapsed + "\n");
            timer.Reset();

            Console.WriteLine("Checking corridor for Кухня and Балкон...");
            if (graph.isCorridorExists("Кухня", "балкон")) Console.WriteLine("Corridor exists");
            else Console.WriteLine("Corridor doesn't exists\n");

            FindHamiltonianCycle(graph, "Зал ожидания");

            Console.ReadKey();
            
        }
    }
}
