using ToolKit.Factory;

namespace ToolKit
{
    internal class Program
    {
        private static readonly ModuleFactory _factory = new();

        static void Main(string[] args)
        {
            ExibirMenuPrincipal();
        }

        static void ExibirMenuPrincipal()
        {
            while (true)
            {
                Console.Clear();
                Console.WriteLine("=== TOOLKIT - MENU PRINCIPAL ===");
                Console.WriteLine("1. Verificador de Alfabeto Σ={a,b}");
                Console.WriteLine("2. Classificador T/I/N por JSON");
                Console.WriteLine("3. Decisor: Termina com 'b'?");
                Console.WriteLine("4. Avaliador Proposicional");
                Console.WriteLine("5. Reconhecedor de Linguagens");
                Console.WriteLine("0. Sair");
                Console.Write("Escolha uma opção: ");

                string? opcao = Console.ReadLine();

                if (opcao == "0")
                {
                    Console.WriteLine("Encerrando aplicação...");
                    return;
                }

                if (int.TryParse(opcao, out int opcaoNumerica) && opcaoNumerica >= 1 && opcaoNumerica <= 5)
                {
                    try
                    {
                        var modulo = _factory.CriarModulo(opcaoNumerica);
                        modulo.Executar();
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine($"Erro ao executar o módulo: {ex.Message}");
                        Console.WriteLine("Pressione qualquer tecla para continuar...");
                        Console.ReadKey();
                    }
                }
                else
                {
                    Console.WriteLine("Opção inválida. Pressione qualquer tecla para continuar.");
                    Console.ReadKey();
                }
            }
        }
    }
}
