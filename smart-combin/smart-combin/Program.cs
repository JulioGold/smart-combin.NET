using System;
using System.Text;

namespace smart_combin
{
    class Program
    {
        static void Main(string[] args)
        {
            // Quero gerar todas as combinações destes 7 elementos em grupos de 5 elementos cada.
            string[] str = { "44", "16", "49", "53", "04", "52", "39" };
            //string[] str = { "01", "02", "03", "04", "05", "06", "07", "08", "09", "10", "11", "12", "13", "14", "15", "16", "17", "18" };

            Combinacao combinacao = new Combinacao(str, 5);

            StringBuilder sb = new StringBuilder();
            int count = default(int);
            string[] saida;

            while (combinacao.HasNext())
            {
                count++;
                saida = combinacao.Next();
                sb.AppendLine($"{saida[0]},{saida[1]},{saida[2]},{saida[3]},{saida[4]}");
                //sb.AppendLine($"{saida[0]},{saida[1]},{saida[2]},{saida[3]},{saida[4]},{saida[5]},{saida[6]},{saida[7]},{saida[8]},{saida[9]},{saida[10]},{saida[11]},{saida[12]},{saida[13]},{saida[14]}");
            }
            
            Console.WriteLine(sb);
            Console.WriteLine($"Total: {count}");
            Console.ReadKey();
        }
    }
}
