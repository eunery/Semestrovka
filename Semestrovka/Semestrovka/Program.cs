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
        public void GetMatrix(Graph graphName)
        {
            
        }

        public void FindHamiltonianCycle(Graph graphName)
        {
            
            
        }

        static void Main(string[] args)
        {
            var graph = new Graph(); // ab ac af bc bd df gd gh hk kq qf hr qr
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

            graph.AddCorridor("Кухня", "Тронный зал"); // bc
            graph.AddCorridor("Кухня", "Картинный зал"); // bd
            graph.AddCorridor("Картинный зал", "Команата прислуги"); // df
            graph.AddCorridor("Охрана", "Картинный зал"); // gd
            graph.AddCorridor("Охрана", "Покои короля"); // gh 
            graph.AddCorridor("Покои короля", "Библиотека"); // hk
            graph.AddCorridor("Библиотека", "Обмундирование"); // kq 
            graph.AddCorridor("Обмундирование", "Команата прислуги"); // qf 
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

            Console.Write("zaebalsya");
            
            Console.ReadKey();
            
        }
    }
}
