using ToolKit.Interfaces;

namespace ToolKit.Modules
{
    public class DecisorTerminaComB : IModulo
    {
        public void Executar()
        {
            Console.Clear();
            Console.WriteLine("=== DECISOR: TERMINA COM 'b'? ===");

            Console.Write("Digite uma cadeia sobre Σ={a,b}: ");
            string? cadeia = Console.ReadLine();

            if (string.IsNullOrEmpty(cadeia))
            {
                Console.WriteLine("Cadeia inválida! Não pode ser vazia.");
                return;
            }

            // Validar se a cadeia pertence ao alfabeto
            if (!cadeia.All(c => c == 'a' || c == 'b'))
            {
                Console.WriteLine("Cadeia inválida! Deve conter apenas 'a' e 'b'.");
            }
            else
            {
                bool terminaComB = TerminaComB(cadeia);
                Console.WriteLine(terminaComB ? "SIM" : "NAO");
            }

            Console.WriteLine("Pressione qualquer tecla para continuar...");
            Console.ReadKey();
        }

        private bool TerminaComB(string cadeia)
        {
            if (string.IsNullOrEmpty(cadeia))
                return false;

            return cadeia[^1] == 'b';
        }
    }
}