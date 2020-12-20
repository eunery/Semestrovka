using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Semestrovka
{
    class GraphNode
    {
        public int ID { get; set; }
        public string Name { get; }
        public List<GraphCorridor> Corridor { get; set; }
        
        public GraphNode(int id, string name)
        {
            ID = id;
            Name = name;
            Corridor = new List<GraphCorridor>();
        }

        public void AddCorridor(GraphCorridor corridor)
        {
            Corridor.Add(corridor);
        }

        public void AddCorridor(GraphNode node)
        {
            AddCorridor(new GraphCorridor(node));
        }
        public void RemoveCorridor(GraphCorridor corridor)
        {
            Corridor.Remove(corridor);
        }
    }
}
