using System;
using System.Numerics;

namespace smart_combin
{
    public class Combinacao
    {
        private readonly int _tamanhoGrupo;
        private readonly string[] _itensEntrada;
        private readonly BigInteger _maximo;
        private int _N = 1;

        /// <summary>
        /// Se r é zero então iremos fazer todas as combinações (com qualquer quantidade de elementos).
        /// </summary>
        /// <param name="itensEntrada"></param>
        /// <param name="tamanhoGrupo"></param>
        public Combinacao(string[] itensEntrada, int tamanhoGrupo)
        {
            _tamanhoGrupo = tamanhoGrupo;
            _itensEntrada = itensEntrada;
            _maximo = ~((BigInteger)Math.Pow(2, itensEntrada.Length));
        }

        /// <summary>
        /// Retorna true quando há pelo menos uma combinação disponível.
        /// </summary>
        /// <returns></returns>
        public bool HasNext()
        {
            if (_tamanhoGrupo != 0)
            {
                while (((_N & _maximo) != 0) && (CountBits() != _tamanhoGrupo))
                {
                    _N += 1;
                }
            }

            return (_N & _maximo) != 0;
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

            while ((_maximo & i) != 0)
            {
                if ((_N & i) != 0)
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
                if (_tamanhoGrupo != 0)
                {
                    return _tamanhoGrupo;
                }

                return CountBits();
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

            string[] saida = new string[SaidaLength];

            entrada_index = 0;
            saida_index = 0;
            i = 1;

            while ((_maximo & i) != 0)
            {
                if ((_N & i) != 0)
                {
                    saida[saida_index] = _itensEntrada[entrada_index];
                    saida_index += 1;
                }
                entrada_index += 1;
                i = i << 1;
            }

            _N += 1;

            return saida;
        }
    }
}
