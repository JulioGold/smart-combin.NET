using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace smart_combin
{
    public class Combinacao
    {
        private int r;
        private string[] entrada;
        private int MAX;
        private int N;

        /// <summary>
        /// Se r é zero então iremos fazer todas as combinações (com qualquer quantidade de elementos).
        /// </summary>
        /// <param name="entrada"></param>
        /// <param name="r"></param>
        public Combinacao(string[] entrada, int r)
        {
            this.r = r;
            this.entrada = entrada;
            this.MAX = ~(1 << entrada.Length);
            this.N = 1;
        }

        /// <summary>
        /// Retorna true quando há pelo menos uma combinação disponível.
        /// </summary>
        /// <returns></returns>
        public bool HasNext()
        {
            if (this.r != 0)
            {
                while (((this.N & this.MAX) != 0) && (CountBits() != this.r))
                {
                    this.N += 1;
                }
            }
            return (this.N & this.MAX) != 0;
        }

        /// <summary>
        /// Retorna a quantidade de bits ativos (= 1) de N.
        /// </summary>
        /// <returns></returns>
        private int CountBits()
        {
            int i;
            int c;
            i = 1;
            c = 0;
            while ((this.MAX & i) != 0)
            {
                if ((this.N & i) != 0)
                {
                    c++;
                }
                i = i << 1;
            }
            return c;
        }

        /// <summary>
        /// Util para obter o tamanho da saída.
        /// Esse tamanho é o número de posições do vetor retornado por next.
        /// </summary>
        public int SaidaLength
        {
            get
            {
                if (this.r != 0)
                {
                    return this.r;
                }
                return this.CountBits();
            }
        }

        /// <summary>
        /// Retorna uma combinação.
        /// ATENÇÃO: Sempre use next() quando se tem certeza que há uma combinação disponível.
        /// Ou seja, sempre use next() quando hasNext() retornar true.
        /// </summary>
        /// <returns></returns>
        public string[] Next()
        {
            int saida_index, entrada_index, i;

            string[] saida = new string[this.SaidaLength];

            entrada_index = 0;
            saida_index = 0;
            i = 1;

            while ((this.MAX & i) != 0)
            {
                if ((this.N & i) != 0)
                {
                    saida[saida_index] = entrada[entrada_index];
                    saida_index += 1;
                }
                entrada_index += 1;
                i = i << 1;
            }

            this.N += 1;

            return saida;
        }
    }
}
