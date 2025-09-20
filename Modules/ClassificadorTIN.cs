using System.Text.Json;
using ToolKit.Interfaces;

namespace ToolKit.Modules
{
    public class ClassificadorTIN : IModulo
    {
        private class ItemProblema
        {
            public int Id { get; set; }
            public string Problema { get; set; } = string.Empty;
            public string Classificacao { get; set; } = string.Empty;
        }

        public void Executar()
        {
            Console.Clear();
            Console.WriteLine("=== CLASSIFICADOR T/I/N ===");

            string json = @"[
                {""id"": 1, ""problema"": ""Problema do Caminho Hamiltoniano"", ""classificacao"": ""I""},
                {""id"": 2, ""problema"": ""Problema da Parada"", ""classificacao"": ""N""},
                {""id"": 3, ""problema"": ""Ordenação de Lista"", ""classificacao"": ""T""},
                {""id"": 4, ""problema"": ""Problema do Caixeiro Viajante"", ""classificacao"": ""I""},
                {""id"": 5, ""problema"": ""Problema da Correspondência de Post"", ""classificacao"": ""N""}
            ]";

            List<ItemProblema> problemas = JsonSerializer.Deserialize<List<ItemProblema>>(json)!;
            int acertos = 0;
            int total = problemas.Count;

            foreach (var problema in problemas)
            {
                Console.WriteLine($"\nProblema: {problema.Problema}");
                Console.Write("Classifique como (T/I/N): ");
                string? resposta = Console.ReadLine()?.ToUpper().Trim();

                if (resposta == problema.Classificacao)
                {
                    Console.WriteLine("✓ CORRETO!");
                    acertos++;
                }
                else
                {
                    Console.WriteLine($"✗ ERRADO! A classificação correta é: {problema.Classificacao}");
                }
            }

            Console.WriteLine($"\n=== RESUMO ===");
            Console.WriteLine($"Acertos: {acertos}/{total}");
            Console.WriteLine($"Percentual: {(acertos * 100.0 / total):F1}%");

            Console.WriteLine("Pressione qualquer tecla para continuar...");
            Console.ReadKey();
        }
    }
}