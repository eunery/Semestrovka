using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Semestrovka
{
    class Graph
    {
        public int LastId = 1;
        public List<GraphNode> Nodes { get; }
        public Graph()
        {
            Nodes = new List<GraphNode>();
        }

        public void AddNode(string nodeName)
        {
            Nodes.Add(new GraphNode(LastId, nodeName));
            LastId++;
        }

        public GraphNode FindNode(string nodeName)
        {
            return Nodes.FirstOrDefault(node => node.Name == nodeName);
        }

        public void RemoveNode(string nodeName)
        {
            var node = FindNode(nodeName);
            if (node != null)
            {
                foreach (var connectedNode in GetConnectedNodes(node))
                {
                    RemoveCorridor(node, connectedNode);
                }
                Nodes.Remove(node);
            }

        }

        public void RemoveCorridor(GraphNode node1, GraphNode node2)
        {
            node2.Corridor = node2.Corridor.Where(corridor => corridor.ConnectedNode != node1).ToList();
        }

        public List<GraphNode> GetConnectedNodes(GraphNode node)
        {
            return node.Corridor.Select(corridor => corridor.ConnectedNode).ToList();
        }

        public void RemoveCorridor(string First, string Second)
        {
            var node1 = FindNode(First);
            var node2 = FindNode(Second);
            if (node1 == null || node2 == null) return;
            RemoveCorridor(node1, node2);
        }

        public void AddCorridor(string firstName, string secondName)
        {
            var nodeFirst = FindNode(firstName);
            var nodeSecond = FindNode(secondName);
            if (nodeFirst == null || nodeSecond == null) return;
            nodeFirst.AddCorridor(nodeSecond);
            nodeSecond.AddCorridor(nodeFirst);

        }
    }
}
