using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace smart_combin
{
    class Program
    {
        static void Main(string[] args)
        {
            // Quero gerar todas as combinações destes 7 elementos em grupos de 5 elementos cada.
            string[] str = { "44", "16", "49", "53", "04", "52", "39" };
            Combinacao combinacao = new Combinacao(str, 5);

            string[] saida;
            while (combinacao.HasNext())
            {
                saida = combinacao.Next();
                Console.Out.WriteLine(saida[0] + "," + saida[1] + "," + saida[2] + "," + saida[3] + "," + saida[4]);
            }

            Console.ReadKey();
        }
    }
}
