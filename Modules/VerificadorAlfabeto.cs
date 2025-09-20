using ToolKit.Interfaces;

namespace ToolKit.Modules
{
    public class VerificadorAlfabeto : IModulo
    {
        public void Executar()
        {
            Console.Clear();
            Console.WriteLine("=== VERIFICADOR DE ALFABETO Σ={a,b} ===");

            // Verificar símbolo individual
            Console.Write("Digite um símbolo: ");
            string simbolo = Console.ReadLine();

            if (ValidarSimbolo(simbolo))
            {
                Console.WriteLine($"Símbolo '{simbolo}' é VÁLIDO (pertence a Σ)");
            }
            else
            {
                Console.WriteLine($"Símbolo '{simbolo}' é INVÁLIDO (não pertence a Σ)");
            }

            // Verificar cadeia completa
            Console.Write("Digite uma cadeia: ");
            string cadeia = Console.ReadLine();

            if (ValidarCadeia(cadeia))
            {
                Console.WriteLine($"Cadeia '{cadeia}' é VÁLIDA (pertence a Σ*)");
            }
            else
            {
                Console.WriteLine($"Cadeia '{cadeia}' é INVÁLIDA (não pertence a Σ*)");
            }

            Console.WriteLine("Pressione qualquer tecla para continuar...");
            Console.ReadKey();
        }

        private bool ValidarSimbolo(string simbolo)
        {
            return simbolo == "a" || simbolo == "b";
        }

        private bool ValidarCadeia(string cadeia)
        {
            return cadeia.All(c => c == 'a' || c == 'b');
        }
    }
}