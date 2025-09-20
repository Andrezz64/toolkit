using ToolKit.Interfaces;

namespace ToolKit.Modules
{
    public class AvaliadorProposicional : IModulo
    {
        public void Executar()
        {
            Console.Clear();
            Console.WriteLine("=== AVALIADOR PROPOSICIONAL ===");

            while (true)
            {
                Console.WriteLine("\nEscolha uma fórmula:");
                Console.WriteLine("1. P ∧ Q ∧ R (Conjunção)");
                Console.WriteLine("2. P ∨ Q ∨ R (Disjunção)");
                Console.WriteLine("3. P → Q (Implicação)");
                Console.WriteLine("4. Voltar ao menu principal");
                Console.Write("Opção: ");

                string? opcao = Console.ReadLine();

                if (opcao == "4") break;

                if (opcao != "1" && opcao != "2" && opcao != "3")
                {
                    Console.WriteLine("Opção inválida!");
                    continue;
                }

                Console.WriteLine("\nDeseja ver a tabela-verdade completa? (S/N)");
                bool tabelaCompleta = Console.ReadLine()?.ToUpper() == "S";

                if (tabelaCompleta)
                {
                    GerarTabelaVerdade(opcao);
                }
                else
                {
                    AvaliarFormula(opcao);
                }
            }
        }

        private void AvaliarFormula(string opcaoFormula)
        {
            Console.WriteLine("\nDigite os valores verdade (V para verdadeiro, F para falso):");

            bool p = LerValor("P");
            bool q = LerValor("Q");
            bool r = LerValor("R");

            bool resultado = opcaoFormula switch
            {
                "1" => p && q && r,          // Conjunção
                "2" => p || q || r,          // Disjunção
                "3" => !p || q,              // Implicação
                _ => false
            };

            Console.WriteLine($"Resultado: {(resultado ? "VERDADEIRO" : "FALSO")}");
        }

        private bool LerValor(string variavel)
        {
            while (true)
            {
                Console.Write($"{variavel}: ");
                string? entrada = Console.ReadLine()?.ToUpper();

                if (entrada == "V") return true;
                if (entrada == "F") return false;

                Console.WriteLine("Valor inválido! Use V ou F.");
            }
        }

        private void GerarTabelaVerdade(string opcaoFormula)
        {
            Console.WriteLine("\n=== TABELA-VERDADE ===");
            Console.WriteLine("P\tQ\tR\tResultado");

            for (int i = 0; i < 8; i++)
            {
                bool p = (i & 4) != 0;
                bool q = (i & 2) != 0;
                bool r = (i & 1) != 0;

                bool resultado = opcaoFormula switch
                {
                    "1" => p && q && r,
                    "2" => p || q || r,
                    "3" => !p || q,
                    _ => false
                };

                Console.WriteLine($"{BoolParaString(p)}\t{BoolParaString(q)}\t{BoolParaString(r)}\t{BoolParaString(resultado)}");
            }
        }

        private string BoolParaString(bool valor)
        {
            return valor ? "V" : "F";
        }
    }
}