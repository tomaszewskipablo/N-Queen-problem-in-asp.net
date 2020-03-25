﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ArtificialIntelligence.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;


namespace ArtificialIntelligence.Controllers
{
    public class NQueensProblemController : Controller
    {

        public IActionResult Index()
        {

            Chessboard chessboard = new Chessboard(6);
            return View(chessboard);
            //return View();
        }

        [HttpPost]
        public IActionResult NewSize(IFormCollection formCollection)
        {            
                int size = int.Parse(formCollection["size"]);

            var algorithm = formCollection["algorithm"];
            if (algorithm == "hillClimbing")
            {
                
            }
            else if(algorithm == "simulatedAnnealing")
            {
                var coolingFactor = formCollection["coolingFactor"];
                var startingTemperature = formCollection["startingTemperature"];
            }
            else if (algorithm == "localBeamSearch")
            {
                var numberOfStates = formCollection["numberOfStates"];
            }
            else  // geneticAlgorithms
            {
                var sizeOfASingleGeneration = formCollection["sizeOfASingleGeneration"];
                var percentOfElitism = formCollection["percentOfElitism"];
                var crossoverProbability = formCollection["crossoverProbability"];
                var mutationProbability = formCollection["mutationProbability"];
                var numberOfGenerations = formCollection["numberOfGenerations"];
            }


            Chessboard chessboard = new Chessboard(size);
                return View("Index", chessboard);           
        }

        public IActionResult displayChessboard()
        {
            Chessboard chessboard = new Chessboard(9);
            return View(chessboard);
        }
    }
}