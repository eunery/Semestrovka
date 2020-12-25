﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Semestrovka
{
    class Graph
    {
        public int LastId = 1;
        public int LastIdCorridor = 1;
        public List<GraphCorridor> Corridors { get;}
        public List<GraphNode> Nodes { get; }
        public Graph()
        {
            Corridors = new List<GraphCorridor>();
            Nodes = new List<GraphNode>();
        }

        public GraphNode FindNode(string nodeName)
        {
            return Nodes.FirstOrDefault(node => node.Name == nodeName);
            
        }
        /*
        public GraphCorridor FindCorridor(GraphNode nodeFirst, GraphNode nodeSecond)
        {
            
        }
        */
        public List<GraphNode> GetConnectedNodes(GraphNode node)
        {
            return node.Corridor.Select(corridor => corridor.ConnectedNode).ToList();
        }

        public void AddNode(string nodeName)
        {
            if (FindNode(nodeName) != null) Console.WriteLine($"Node:\"{nodeName}\" already exists");
            else
            {
                Nodes.Add(new GraphNode(LastId, nodeName));
                LastId++;
            }
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

        public void AddCorridor(string firstName, string secondName)
        {
            var nodeFirst = FindNode(firstName);
            var nodeSecond = FindNode(secondName);
            if (nodeFirst == null || nodeSecond == null) return;
            nodeFirst.AddCorridor(nodeSecond);
            nodeSecond.AddCorridor(nodeFirst);

            Corridors.Add(new GraphCorridor(LastIdCorridor, nodeFirst, nodeSecond));
            LastIdCorridor++;
        }

        public void RemoveCorridor(string First, string Second)
        {
            var node1 = FindNode(First);
            var node2 = FindNode(Second);
            if (node1 == null || node2 == null) return;
            RemoveCorridor(node1, node2);

            //Corridors.Remove();
        }

        public void RemoveCorridor(GraphNode node1, GraphNode node2)
        {
            node2.Corridor = node2.Corridor.Where(corridor => corridor.ConnectedNode != node1).ToList();
        }
    }
}
