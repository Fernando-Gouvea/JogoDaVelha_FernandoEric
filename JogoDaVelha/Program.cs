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
            while (true)
            {
                string[,] matriz = new string[3, 3];
                int vencedor = 0;
                string jogador1 = "", jogador2 = "";

                for (int i = 0, valor = 1; i < 3; i++)
                {
                    for (int j = 0; j < 3; j++)                     // for para popular a matriz
                    {
                        matriz[i, j] = Convert.ToString(valor);
                        valor++;
                    }
                }
                imprimir_jogo(matriz);

                Console.WriteLine("\nDigite o nome do/a jogador(a) 1: ");
                jogador1 = Console.ReadLine();
                testaJogador(ref jogador1);

                Console.WriteLine("\nDigite o nome do/a jogador(a) 2: ");
                jogador2 = Console.ReadLine();
                testaJogador(ref jogador2);

                jogada(matriz, jogador1, jogador2, ref vencedor);
                vencedor = verificaStatus(matriz);

                if (vencedor == 1)                      // linhas 41 - 53 mostra vencedor ou empate na tela
                {
                    Console.BackgroundColor = ConsoleColor.Red;
                    Console.ForegroundColor = ConsoleColor.Black;
                    Console.WriteLine("Jogador(a) 1: " + jogador1 + " é o/a Vencedor(a)");
                }
                else if (vencedor == 2)
                {
                    Console.BackgroundColor = ConsoleColor.Blue;
                    Console.ForegroundColor = ConsoleColor.Black;
                    Console.WriteLine("Jogador(a) 2: " + jogador2 + " é o/a Vencedor(a)");
                }
                else Console.WriteLine("Deu velha...nenhum vencedor");
                Console.ResetColor();
                Console.ReadKey();
            }
        }
        static void imprimir_jogo(string[,] matriz)
        {
            Console.Clear();
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("\n     <<<--Super Jogo da Velha-->>>\n");
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine("                  Fernando \n\n");
            Console.ResetColor();
            Console.WriteLine("    Escolha um numero para sua jogada\n    Para confirmar sua jogada aperte ENTER\n    OBS:");
            Console.WriteLine("    O número a ser digitado para a jogada deve ser inteiro e de 1 até 9!");
            for (int i = 2; i >= 0; i--)
            {
                Console.WriteLine("\t+===================+");
                for (int j = 0; j < 3; j++)
                {
                    Console.Write("\t| ");
                    if (matriz[i, j] == "X") Console.ForegroundColor = ConsoleColor.Red;
                    if (matriz[i, j] == "O") Console.ForegroundColor = ConsoleColor.Blue;
                    Console.Write(matriz[i, j]);
                    Console.ResetColor();
                    Console.Write(" | ");
                }
                Console.WriteLine();
            }
            Console.WriteLine("\t+===================+");
        }
        static void testaJogador(ref string jogador)
        {
            while (jogador == "")
            {
                Console.WriteLine("ERRO: O nome não pode ser deixado em branco.\nDigite um nome: ");
                jogador = Console.ReadLine();
            }
        }
        static void jogada(string[,] matriz, string jogador1, string jogador2, ref int vencedor)
        {
            bool verifica = false;
            string label;                       //função jogada: controla o ciclo de jogo com 9 jogadas no for
            int jogada = 0;
            for (int i = 1; i <= 9; i++)
            {
                verifica = false;
                if (i % 2 == 1)
                {
                    do
                    {
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.WriteLine("\nVez do " + jogador1 + " (X)\n");
                        if (int.TryParse(Console.ReadLine(), out jogada))
                        {
                            label = "X";
                            verificaPosicao(matriz, jogada, label, ref verifica);
                        }
                        else Console.WriteLine("Por favor, digite um valor inteiro de 1 até 9 para sua jogada!");
                    }
                    while ((jogada < 1) || (jogada > 9) || (verifica == false));
                    imprimir_jogo(matriz);
                }
                else
                {
                    do
                    {
                        Console.ForegroundColor = ConsoleColor.Blue;
                        Console.WriteLine("\nVez do " + jogador2 + " (O)\n");
                        if (int.TryParse(Console.ReadLine(), out jogada))
                        {
                            label = "O";
                            verificaPosicao(matriz, jogada, label, ref verifica);
                        }
                        else Console.WriteLine("Por favor, digite um valor inteiro de 1 até 9 para sua jogada!");
                    }
                    while ((jogada < 1) || (jogada > 9) || (verifica == false));
                    imprimir_jogo(matriz);
                }
                if (i >= 3) vencedor = verificaStatus(matriz);
                if ((vencedor == 1) || (vencedor == 2)) i = 10;
            }
        }
        static void verificaPosicao(string[,] matriz, int jogada, string label, ref Boolean verifica)
        {
            for (int i = 0, tstJogada = 1; i < 3; i++)
            {
                for (int j = 0; j < 3; j++)
                {
                    if ((jogada == tstJogada) && (matriz[i, j] != "X") && (matriz[i, j] != "O"))
                    {
                        verifica = true;
                        matriz[i, j] = label;
                    }
                    tstJogada++;
                }
            }
        }
        static int verificaStatus(string[,] matriz)
        {
            int vencedor = 0;
            for (int i = 0; i < 3; i++)
            {
                if ((matriz[i, 0] == matriz[i, 1]) && (matriz[i, 1] == matriz[i, 2]))
                {
                    if (matriz[i, 0] == "X") vencedor = 1;
                    else vencedor = 2;
                }
                if ((matriz[0, i] == matriz[1, i]) && (matriz[1, i] == matriz[2, i]))
                {
                    if (matriz[0, i] == "X") vencedor = 1;
                    else vencedor = 2;
                }
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