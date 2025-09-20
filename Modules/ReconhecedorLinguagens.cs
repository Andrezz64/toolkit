using ToolKit.Interfaces;

namespace ToolKit.Modules
{
    public class ReconhecedorLinguagens : IModulo
    {
        public void Executar()
        {
            Console.Clear();
            Console.WriteLine("=== RECONHECEDOR DE LINGUAGENS ===");

            while (true)
            {
                Console.WriteLine("\nEscolha a linguagem:");
                Console.WriteLine("1. L_par_a - Número par de 'a's");
                Console.WriteLine("2. L = { w | w = a b* }");
                Console.WriteLine("3. Voltar ao menu principal");
                Console.Write("Opção: ");

                string? opcao = Console.ReadLine();

                if (opcao == "3") break;

                if (opcao != "1" && opcao != "2")
                {
                    Console.WriteLine("Opção inválida!");
                    continue;
                }

                Console.Write("Digite a cadeia: ");
                string? cadeia = Console.ReadLine();

                if (string.IsNullOrEmpty(cadeia))
                {
                    Console.WriteLine("Cadeia inválida! Não pode ser vazia.");
                    continue;
                }

                // Validar alfabeto
                if (!cadeia.All(c => c == 'a' || c == 'b'))
                {
                    Console.WriteLine("Cadeia inválida! Deve conter apenas 'a' e 'b'.");
                    continue;
                }

                bool aceita = opcao switch
                {
                    "1" => PertenceLParA(cadeia),
                    "2" => PertenceLABEstrela(cadeia),
                    _ => false
                };

                Console.WriteLine(aceita ? "ACEITA" : "REJEITA");
            }
        }

        private bool PertenceLParA(string cadeia)
        {
            int countA = cadeia.Count(c => c == 'a');
            return countA % 2 == 0;
        }

        private bool PertenceLABEstrela(string cadeia)
        {
            if (string.IsNullOrEmpty(cadeia))
                return false;

            // Deve começar com 'a' e depois zero ou mais 'b's
            if (cadeia[0] != 'a')
                return false;

            // Todos os caracteres após o primeiro devem ser 'b'
            for (int i = 1; i < cadeia.Length; i++)
            {
                if (cadeia[i] != 'b')
                    return false;
            }

            return true;
        }
    }
}