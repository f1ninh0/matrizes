namespace testeNuria
{
    internal class Program
    {
        static void Main(string[] args)
        {
            bool encerrar = false;
            while (!encerrar) {

                Console.WriteLine("Escolha entre as opcoes:");
                Console.WriteLine("1 - Para inverter matriz");
                Console.WriteLine("2 - Para encontrar sub matriz");
                Console.WriteLine("0 - Para sair");

                var opcao = 0;
                while (!int.TryParse(Console.ReadLine(), out opcao))
                {
                    Console.Clear();
                    Console.WriteLine("Opcao invalida");
                    Console.WriteLine("Escolha entre as opcoes:");
                    Console.WriteLine("1 - Para inverter matriz");
                    Console.WriteLine("2 - Para encontrar sub matriz");
                    Console.WriteLine("0 - Para sair");
                }

                switch (opcao)
                {
                    case 1:
                        {
                            Functions.InverteMatriz();
                            break;
                        }
                    case 2:
                        {
                            Functions.EncontrarSubMatriz();
                            break;
                        }
                    case 0:
                    default:
                        {
                            encerrar = true;
                            break;
                        }
                }
            }
        }
    }
}