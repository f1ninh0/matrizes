using System.Text;

namespace testeNuria
{
    static class Functions
    {
        public static void InverteMatriz()
        {
            Console.Write("Entre com o tamanho da matriz: ");
            var tam = 0;

            while (!int.TryParse(Console.ReadLine(), out tam))
            {
                Console.WriteLine("Boom, digite um numero valido da proxima vez!");
                Console.Write("Entre com o tamanho da matriz: ");
            }

            Console.WriteLine("Matriz com as diagonais invertidas...");
            InverteDiagonaisMatriz(RetornaMatrizQuadratica(tam));

            Console.WriteLine("Matriz com as diagonais trocadas...");
            TrocaDiagonaisMatriz(RetornaMatrizQuadratica(tam));
        }

        static List<int[]> RetornaMatrizQuadratica(int tamMatriz)
        {
            Random rnd = new();
            List<int[]> matriz = new();
            int[] values = new int[tamMatriz];
            for (int i = 0; i < tamMatriz; i++)
            {
                for (int j = 0; j < tamMatriz; j++)
                {
                    values[j] = rnd.Next(9);
                }
                matriz.Add(values);
                values = new int[tamMatriz];
            }
            MostarMatriz(matriz);
            return matriz;
        }

        static void InverteDiagonaisMatriz(List<int[]> matriz)
        {
            int val;
            int invertido;
            for (int i = 0; i < matriz.Count / 2; i++)
            {
                invertido = matriz.Count - i - 1;
                val = matriz[i][i];
                matriz[i][i] = matriz[invertido][invertido];
                matriz[invertido][invertido] = val;

                val = matriz[i][invertido];
                matriz[i][invertido] = matriz[invertido][i];
                matriz[invertido][i] = val;
            }
            MostarMatriz(matriz);
        }

        static void TrocaDiagonaisMatriz(List<int[]> matriz)
        {
            int val;
            int invertido;
            for (int i = 0; i < matriz.Count; i++)
            {
                invertido = matriz.Count - i - 1;
                val = matriz[i][i];
                matriz[i][i] = matriz[i][invertido];
                matriz[i][invertido] = val;
            }
            MostarMatriz(matriz);
        }

        static void MostarMatriz(List<int[]> matriz)
        {
            for (int i = 0; i < matriz.Count; i++)
            {
                var value = matriz[i];
                StringBuilder sb = new();
                for (int j = 0; j < value.Length; j++)
                {
                    sb.Append(value[j]);
                    sb.Append("  |  ");
                }
                Console.WriteLine(sb.ToString());
            }
            Console.WriteLine("");
        }

        public static void EncontrarSubMatriz()
        {
            Console.Write("Entre com o tamanho da matriz em Y: ");
            var tamY = 0;

            while (!int.TryParse(Console.ReadLine(), out tamY))
            {
                Console.WriteLine("Boom, digite um numero valido da proxima vez!");
                Console.Write("Entre com o tamanho da matriz em Y: ");
            }

            Console.Write("Entre com o tamanho da matriz em X: ");
            var tamX = 0;

            while (!int.TryParse(Console.ReadLine(), out tamX))
            {
                Console.WriteLine("Boom, digite um numero valido da proxima vez!");
                Console.Write("Entre com o tamanho da matriz em X: ");
            }

            Console.WriteLine("\n\nLembre-se que a sub matriz deve ser de um tamanho menor que a matriz");
            Console.Write("\nEntre com o tamanho da sub matriz em Y: ");
            var stamY = 0;

            while (!int.TryParse(Console.ReadLine(), out stamY) || stamY > tamY)
            {
                Console.WriteLine("Numero invalido ou maior que o tamanho Y da matriz!");
                Console.Write("Entre com o tamanho da sub matriz em Y: ");
            }

            Console.Write("Entre com o tamanho da sub matriz em X: ");
            var stamX = 0;

            while (!int.TryParse(Console.ReadLine(), out stamX) || stamX > tamX)
            {
                Console.WriteLine("Numero invalido ou maior que o tamanho X da matriz!");
                Console.Write("Entre com o tamanho da sub matriz em X: ");
            }

            Console.Write("Escolha o valor maximo do valor dos itens da matriz: ");
            var range = 0;

            while (!int.TryParse(Console.ReadLine(), out range))
            {
                Console.WriteLine("Numero invalido!");
                Console.Write("Escolha o valor maximo do valor dos itens da matriz: ");
            }

            var matriz = RetornaMatriz(tamY, tamX, range);
            var subMatriz = RetornaMatriz(stamY, stamX, range);

            ProcessaMatrizes(matriz, subMatriz);
        }

        static void ProcessaMatrizes(List<int[]> matriz, List<int[]> subMatriz)
        {
            List<int[]> posicoes = RetornaPosisoesIniciaisSubMatriz(matriz, subMatriz);

            int count = 0;
            foreach (var pos in posicoes)
            {
                if (ValidaSubMatrizExistente(pos, matriz, subMatriz)) count++;
            }

            Console.WriteLine("Submatrizes encontradas: {0}", count);
        }

        private static bool ValidaSubMatrizExistente(int[] pos, List<int[]> matriz, List<int[]> subMatriz)
        {
            var tamMatrizX = matriz.First().Length;
            var tamMatrizY = matriz.Count;

            var tamSubMatrizX = subMatriz.First().Length;
            var tamSubMatrizY = subMatriz.Count;

            if (pos[0] + tamSubMatrizY - 1 < tamMatrizY && pos[1] + tamSubMatrizX - 1 < tamMatrizX)
            {
                for (int y = 0; y < tamSubMatrizY; y++)
                {
                    for (int x = 0; x < tamSubMatrizX; x++)
                    {
                        if ((pos[0] + y <= tamMatrizY - 1 && pos[1] + x <= tamMatrizX - 1)
                            && (subMatriz[y][x] != matriz[pos[0] + y][pos[1] + x]))
                        {
                            return false;
                        }
                    }
                }
                return true;
            }

            return false;
        }

        private static List<int[]> RetornaPosisoesIniciaisSubMatriz(List<int[]> matriz, List<int[]> subMatriz)
        {
            var key = subMatriz[0][0];
            List<int[]> ret = new();
            for (int y = 0; y < matriz.Count; y++)
            {
                var row = matriz[y];
                for (int x = 0; x < row.Length; x++)
                {
                    if (row[x] == key)
                    {
                        ret.Add(new int[] { y, x });
                    }
                }
            }

            return ret;
        }

        static List<int[]> RetornaMatriz(int x, int y, int range)
        {
            Random rnd = new();
            List<int[]> matriz = new();
            int[] values = new int[y];
            for (int i = 0; i < x; i++)
            {
                for (int j = 0; j < y; j++)
                {
                    values[j] = rnd.Next(range+1);
                }
                matriz.Add(values);
                values = new int[y];
            }
            MostarMatriz(matriz);
            return matriz;
        }
    }
}
