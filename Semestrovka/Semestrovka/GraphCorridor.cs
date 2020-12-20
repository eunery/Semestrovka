using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Semestrovka
{
    class GraphCorridor
    {
        //public int ID { get; set; }
        //public GraphNode First { get; }
        //public GraphNode Second { get; }
        public GraphNode ConnectedNode { get; }

        public GraphCorridor(GraphNode connectedNode)
        {
            ConnectedNode = connectedNode;
        }

        //public GraphCorridor(int id, GraphNode first, GraphNode second)
        //{
        //    ID = id;
        //    First = first;
        //    Second = second;
        //}
    }
}
