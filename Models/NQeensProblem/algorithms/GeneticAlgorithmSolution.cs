﻿using ArtificialIntelligence.Models.NQeensProblem;
using ArtificialIntelligence.Models.NQeensProblem.Parameters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ArtificialIntelligence.Models
{
    public class GeneticAlgorithmSolution : ISolution
    {
        public int heuristicSum=0;
        public double sum = 0;
        GeneticAlgorithmParameters parameters;

        public Chessboard solve(Chessboard board, IParams iparams)
        {
            parameters = (GeneticAlgorithmParameters)iparams;
            board.steps = 0;
            
          
            List<Chessboard> Generation = new List<Chessboard>();
            List<Chessboard> NewGeneration = new List<Chessboard>();

            GenerateGenereation(Generation, parameters.sizeOfASingleGeneration, board.size);
            
            Sort(Generation);


            //check if solved
            if (Generation[0].finalHeuristic == 0)
            {
                board.board = Generation[0].board;
                board.isSolved = true;
                board.finalHeuristic = board.Heuristic();
                return board;
            }

            //NewGeneration.Add()

            //
            CountHeuristicOfWholePopulation(Generation);

            while (NewGeneration.Count != Generation.Count)
            {
                Chessboard child = new Chessboard(board.size);
                
                //selection
                Chessboard parentA = SelectParent(Generation);
                Chessboard parentB = SelectParent(Generation);

                //crossover
                child = Crossover(parentA, parentB);

                // mutate

                NewGeneration.Add(child);


            }

            return Generation[0];
        }
        private void GenerateGenereation(List<Chessboard> Generation, int sizeOfGeneration, int sizeOfBoard)
        {
            for (int i = 0; i < sizeOfGeneration; i++)
            {
                Generation.Add(new Chessboard(sizeOfBoard));
            }
        }
        private Chessboard SelectParent(List<Chessboard> Generation) 
        {
            Random rnd = new Random();
            int random = rnd.Next(0, (int)sum);

            double temp=0;

            for(int i=0;i< parameters.sizeOfASingleGeneration; i++)
            {
                temp += heuristicSum/Generation[i].finalHeuristic;
                if (random < temp)
                {
                    return Generation[i];
                }
                
            }
            return Generation[0];      
        }
        private Chessboard Crossover(Chessboard parentA, Chessboard parentB)
        {
            Chessboard child = new Chessboard(parentA.size);

            int split = parentA.size / 2;
            for (int i = 0; i < split; i++)
            {
                child.board[i] = parentA.board[i];
             }
            for (int i = split /2; i < parentA.size; i++)
            {
                child.board[i] = parentB.board[i];
            }
            return child;
        }
        private void Sort(List<Chessboard> Generation)
        {
            // BUBLE SORT
            Chessboard temp;
            for (int j = 0; j <= Generation.Count - 2; j++)
            {
                for (int i = 0; i <= Generation.Count - 2; i++)
                {
                    if (Generation[i].finalHeuristic > Generation[i + 1].finalHeuristic)
                    {
                        temp = Generation[i + 1];
                        Generation[i + 1] = Generation[i];
                        Generation[i] = temp;
                    }
                }
            }
        }
        private void CountHeuristicOfWholePopulation(List<Chessboard> Generation)
        {
            heuristicSum = 0;
            for (int i=0;i<parameters.sizeOfASingleGeneration; i++)
            {
                heuristicSum += Generation[i].finalHeuristic;                
            }
            for (int i = 0; i < parameters.sizeOfASingleGeneration; i++)
            {
                sum += (double)heuristicSum / Generation[i].finalHeuristic;
            }
        }

    }

}