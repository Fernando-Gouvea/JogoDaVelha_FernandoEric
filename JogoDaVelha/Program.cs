using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace teste
{
    class Program
    {
        static void Main(string[] args)
        {
            string[,] matriz = new string[3, 3];
            int vencedor = 0;
            for (int i = 0, valor = 1; i < 3; i++)
            {
                for (int j = 0; j < 3; j++)
                {
                    matriz[i, j] = Convert.ToString(valor);
                    valor++;
                }
            }
            imprimir_jogo(matriz);
            Console.WriteLine("\nDigite o nome do/a jogador(a) 1: ");
            string jogador1 = Console.ReadLine();
            Console.WriteLine("\nDigite o nome do/a jogador(a) 2: ");
            string jogador2 = Console.ReadLine();
            jogada(matriz, jogador1, jogador2, ref vencedor);
            vencedor = verificaStatus(matriz);
            Console.BackgroundColor = ConsoleColor.Blue;
            Console.ForegroundColor = ConsoleColor.Yellow;
            if (vencedor == 1) Console.WriteLine("Jogador(a) 1: " + jogador1 + " é o/a Vencedor(a)");
            else if (vencedor == 2) Console.WriteLine("Jogador(a) 2: " + jogador2 + " é o/a Vencedor(a)");
            else Console.WriteLine("Deu velha...nenhum vencedor");
            Console.ReadKey();
        }
        static void imprimir_jogo(string[,] matriz)
        {
            Console.Clear();
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("\n     <<<--Super Jogo da Velha-->>>\n");
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine("           Fernando e Eric\n\n");
            Console.ResetColor();
            Console.WriteLine("    Escolha um numero para sua jogada\n    Para confirmar sua jogada aperte ENTER\n    OBS:");
            Console.WriteLine("    O número a ser digitado para a jogada deve ser inteiro e de 1 até 9!");
            for (int i = 2; i >= 0; i--)
            {
                Console.WriteLine("\t+===================+");
                for (int j = 0; j < 3; j++)
                {
                    Console.Write("\t| ");
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.Write(matriz[i, j]);
                    Console.ResetColor();
                    Console.Write(" | ");
                }
                Console.WriteLine();
            }
            Console.WriteLine("\t+===================+");
        }
        static void jogada(string[,] matriz, string jogador1, string jogador2, ref int vencedor)
        {
            bool verifica = false;
            string label;
            int jogada = 0;
            for (int i = 1; i <= 9; i++)
            {
                verifica = false;
                if (i % 2 == 1)
                {
                    do
                    {
                        try
                        {
                            Console.WriteLine("\nVez do " + jogador1 + "!!!\n");
                            jogada = int.Parse(Console.ReadLine());
                            label = "X";
                            verificaPosicao(matriz, jogada, label, ref verifica);
                        }
                        catch (Exception)
                        {
                            Console.WriteLine("Por favor, digite um valor inteiro de 1 até 9 para a sua jogada!");
                        }
                    }
                    while ((jogada < 1) || (jogada > 9) || (verifica == false));
                    imprimir_jogo(matriz);
                }
                else
                {
                    do
                    {
                        try
                        {
                            Console.WriteLine("\nVez do " + jogador2 + "!!!\n");
                            jogada = int.Parse(Console.ReadLine());
                            label = "O";
                            verificaPosicao(matriz, jogada, label, ref verifica);
                        }
                        catch (Exception)
                        {
                            Console.WriteLine("Por favor, digite um valor inteiro de 1 até 9 para sua jogada!");
                        }
                    }
                    while ((jogada < 1) || (jogada > 9) || (verifica == false));
                    imprimir_jogo(matriz);
                }
                vencedor = verificaStatus(matriz);
                if ((vencedor == 1) || (vencedor == 2)) i = 10;
            }
        }
        static void verificaPosicao(string[,] matriz, int jogada, string label, ref Boolean verifica)
        {
            if ((jogada <= 3) && (jogada >= 1))
            {
                if ((jogada == 1) && (matriz[0, 0] != "X") && (matriz[0, 0] != "O"))
                {
                    verifica = true;
                    matriz[0, 0] = label;
                }
                if ((jogada == 2) && (matriz[0, 1] != "X") && (matriz[0, 1] != "O"))
                {
                    verifica = true;
                    matriz[0, 1] = label;
                }
                if ((jogada == 3) && (matriz[0, 2] != "X") && (matriz[0, 2] != "O"))
                {
                    verifica = true;
                    matriz[0, 2] = label;
                }
            }
            if ((jogada <= 6) && (jogada >= 4))
            {
                if ((jogada == 4) && (matriz[1, 0] != "X") && (matriz[1, 0] != "O"))
                {
                    verifica = true;
                    matriz[1, 0] = label;
                }
                if ((jogada == 5) && (matriz[1, 1] != "X") && (matriz[1, 1] != "O"))
                {
                    verifica = true;
                    matriz[1, 1] = label;
                }
                if ((jogada == 6) && (matriz[1, 2] != "X") && (matriz[1, 2] != "O"))
                {
                    verifica = true;
                    matriz[1, 2] = label;
                }
            }
            if ((jogada <= 9) && (jogada >= 7))
            {
                if ((jogada == 7) && (matriz[2, 0] != "X") && (matriz[2, 0] != "O"))
                {
                    verifica = true;
                    matriz[2, 0] = label;
                }
                if ((jogada == 8) && (matriz[2, 1] != "X") && (matriz[2, 1] != "O"))
                {
                    verifica = true;
                    matriz[2, 1] = label;
                }
                if ((jogada == 9) && (matriz[2, 2] != "X") && (matriz[2, 2] != "O"))
                {
                    verifica = true;
                    matriz[2, 2] = label;
                }
            }
        }
        static int verificaStatus(string[,] matriz)
        {
            int vencedor = 0;

            if ((matriz[0, 0] == matriz[0, 1]) && (matriz[0, 1] == matriz[0, 2]))
            {
                if (matriz[0, 0] == "X") vencedor = 1;
                else vencedor = 2;
            }

            if ((matriz[1, 0] == matriz[1, 1]) && (matriz[1, 1] == matriz[1, 2]))
            {
                if (matriz[1, 0] == "X") vencedor = 1;
                else vencedor = 2;
            }

            if ((matriz[2, 0] == matriz[2, 1]) && (matriz[2, 1] == matriz[2, 2]))
            {
                if (matriz[2, 0] == "X") vencedor = 1;
                else vencedor = 2;
            }

            if ((matriz[0, 0] == matriz[1, 0]) && (matriz[1, 0] == matriz[2, 0]))
            {
                if (matriz[0, 0] == "X") vencedor = 1;
                else vencedor = 2;
            }

            if ((matriz[0, 1] == matriz[1, 1]) && (matriz[1, 1] == matriz[2, 1]))
            {
                if (matriz[0, 1] == "X") vencedor = 1;
                else vencedor = 2;
            }

            if ((matriz[0, 2] == matriz[1, 2]) && (matriz[1, 2] == matriz[2, 2]))
            {
                if (matriz[0, 2] == "X") vencedor = 1;
                else vencedor = 2;
            }

            if ((matriz[0, 0] == matriz[1, 1]) && (matriz[1, 1] == matriz[2, 2]))
            {
                if (matriz[0, 0] == "X") vencedor = 1;
                else vencedor = 2;
            }

            if ((matriz[0, 2] == matriz[1, 1]) && (matriz[1, 1] == matriz[2, 0]))
            {
                if (matriz[0, 2] == "X") vencedor = 1;
                else vencedor = 2;
            }
            return vencedor;
        }
    }
}