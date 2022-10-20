﻿using Xadrez_Console.Board;
using Xadrez_Console.Board.Exceptions;
using Xadrez_Console.Chess;
using Xadrez_Console.Presentation;

namespace Xadrez_Console;

using static System.Console;

public class Program
{
    public static void Main(string[] args)
    {
        try
        {
            PartidaDeXadrez partida = new();

            while (partida.Encerrada is false)
            {
                Clear();
                Tela.ImprimirTabuleiro(partida.Tabuleiro);
                WriteLine($"Turno: {partida.Turno}");
                WriteLine($"Aguardando jogada: {partida.JogadorAtual}");

                Write("Origem: ");
                Posicao origem = Tela.LerPosicaoXadrez().FromPosicaoXadrezToPosicaoProgram();

                bool[,] posicoesPossiveis = partida.Tabuleiro.Peca(origem).MovimentosPossiveis();

                Clear();
                Tela.ImprimirTabuleiro(partida.Tabuleiro, posicoesPossiveis);


                Write("Destino: ");
                Posicao destino = Tela.LerPosicaoXadrez().FromPosicaoXadrezToPosicaoProgram();

                partida.RealizarJogada(origem, destino);
            }

        }
        catch (TabuleiroException ex)
        {
            WriteLine(ex.Message);
        }
    }
}