using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace RomanConverter
{
    public class RomanConverter
    {
        /// <summary>
        /// Converte um número inteiro (1-3999) para algarismos romanos.
        /// </summary>
        /// <param name="num">Número inteiro a ser convertido</param>
        /// <returns>Representação em algarismos romanos</returns>
        /// <exception cref="ArgumentOutOfRangeException">Quando o número não está entre 1 e 3999</exception>
        public static string ToRoman(int num)
        {
            if (num < 1 || num > 3999)
            {
                throw new ArgumentOutOfRangeException(
                    nameof(num),
                    "Número deve ser um inteiro entre 1 e 3999"
                );
            }

            // Mapeamento de valores decimais para romanos em ordem decrescente
            var valores = new List<(int valor, string simbolo)>
            {
                (1000, "M"),
                (900, "CM"),
                (500, "D"),
                (400, "CD"),
                (100, "C"),
                (90, "XC"),
                (50, "L"),
                (40, "XL"),
                (10, "X"),
                (9, "IX"),
                (5, "V"),
                (4, "IV"),
                (1, "I"),
            };

            string resultado = "";

            foreach (var (valor, simbolo) in valores)
            {
                while (num >= valor)
                {
                    resultado += simbolo;
                    num -= valor;
                }
            }

            return resultado;
        }

        /// <summary>
        /// Lê o arquivo de teste e verifica se o método ToRoman está funcionando corretamente.
        /// </summary>
        public static void TestarComArquivo()
        {
            string arquivoTeste = "decimais_romanos_1_a_3999.txt";

            try
            {
                string[] linhas = File.ReadAllLines(arquivoTeste);

                Console.WriteLine($"Testando {linhas.Length} conversões...");
                Console.WriteLine(new string('-', 50));

                int erros = 0;
                int sucessos = 0;

                for (int i = 0; i < linhas.Length; i++)
                {
                    string linha = linhas[i].Trim();
                    if (string.IsNullOrEmpty(linha))
                        continue;

                    string[] partes = linha.Split(' ', 2);
                    if (partes.Length != 2)
                    {
                        Console.WriteLine($"Linha {i + 1} inválida: {linha}");
                        continue;
                    }

                    try
                    {
                        int numero = int.Parse(partes[0]);
                        string romanoEsperado = partes[1];
                        string romanoCalculado = ToRoman(numero);

                        if (romanoCalculado == romanoEsperado)
                        {
                            sucessos++;
                            // Mostra os primeiros 10 e depois a cada 100
                            if (i < 10 || (i + 1) % 100 == 0)
                            {
                                Console.WriteLine($"✓ {numero} → {romanoCalculado}");
                            }
                        }
                        else
                        {
                            erros++;
                            Console.WriteLine(
                                $"✗ {numero}: esperado '{romanoEsperado}', obtido '{romanoCalculado}'"
                            );
                        }
                    }
                    catch (Exception e)
                    {
                        erros++;
                        Console.WriteLine($"Erro na linha {i + 1}: {e.Message}");
                    }
                }

                Console.WriteLine(new string('-', 50));
                Console.WriteLine("Resultados do teste:");
                Console.WriteLine($"✓ Sucessos: {sucessos}");
                Console.WriteLine($"✗ Erros: {erros}");
                Console.WriteLine($"Total: {sucessos + erros}");

                if (erros == 0)
                {
                    Console.WriteLine(
                        "\n🎉 Todos os testes passaram! O método ToRoman está funcionando corretamente."
                    );
                }
                else
                {
                    Console.WriteLine($"\n⚠️  {erros} testes falharam. Verifique a implementação.");
                }
            }
            catch (FileNotFoundException)
            {
                Console.WriteLine($"Arquivo '{arquivoTeste}' não encontrado!");
            }
            catch (Exception e)
            {
                Console.WriteLine($"Erro ao processar arquivo: {e.Message}");
            }
        }

        /// <summary>
        /// Método principal para executar o conversor e os testes.
        /// </summary>
        public static void Main(string[] args)
        {
            Console.WriteLine("=== Conversor de Números para Algarismos Romanos ===\n");

            // Executar testes com o arquivo
            TestarComArquivo();
        }
    }
}
