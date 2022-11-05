using System;
using System.Collections.Generic;
using System.Linq;

namespace NeuralNetwork_Connect4.Models
{
    public class Hatchery
    {
        private Random _randomNumberGenerator;
        private int _maxCandidateId = 0;
        
        private const int NumberOfCandidatesFromLastGeneration = 50;
        private const int MinimumNumberOfCandidates = 100;

        private const int MutateInputWeightCutoff = 20;
        private const int MutateInternalBiasCutoff = 40;
        private const int MutateOutputWeightCutoff = 60;
        private const int MutateOutputBiasCutoff = 80;
        private const int MutateAddInternalNodeCutoff = 90;
        private const int MutateDeleteInternalNodeCutoff = 100;

        public Hatchery(Random randomNumberGenerator)
        {
            _randomNumberGenerator = randomNumberGenerator;
        }
        
        public List<Candidate> GetGenerationCandidateList(List<Candidate> initialCandidateList)
        {
            initialCandidateList = initialCandidateList.OrderBy(x => x.Score)
                                                       .TakeLast(NumberOfCandidatesFromLastGeneration)
                                                       .ToList();

            var returnList = new List<Candidate>();
            
            returnList.AddRange(CreateCandidatesViaCloning(initialCandidateList));
            returnList.AddRange(CreateCandidatesViaAsexualReproduction(initialCandidateList));
            returnList.AddRange(CreateCandidatesViaSexualReproduction(initialCandidateList));
            returnList.AddRange(CreateCandidatesViaSpontaneousGeneration(returnList));

            return returnList;
        }

        private List<Candidate> CreateCandidatesViaCloning(List<Candidate> initialCandidateList)
        {
            return initialCandidateList.Select(iInitialCandidate => new Candidate(iInitialCandidate))
                                       .ToList();
        }
        
        private List<Candidate> CreateCandidatesViaAsexualReproduction(List<Candidate> initialCandidateList)
        {
            var returnList = new List<Candidate>();

            foreach (var iCandidate in initialCandidateList)
            {
                var mutationStrategy = _randomNumberGenerator.Next(0,
                                                                   100);
            
                switch (mutationStrategy)
                {
                    case > 0: //MutateInputWeightCutoff:
                        returnList.Add(MutateInputWeight(iCandidate));
                        break;

                    case < MutateInternalBiasCutoff:
                        break;
                    
                    // case < MutateOutputWeightCutoff:
                    //     break;
                    //
                    // case < MutateOutputBiasCutoff:
                    //     break;
                    //
                    // case < MutateAddInternalNodeCutoff:
                    //     break;
                    //
                    // case < MutateDeleteInternalNodeCutoff:
                    //     break;
            
                    default:
                        throw new Exception("Unexpected value in switch statement");
                }
            }

            return returnList; 
        }

        private Candidate MutateInputWeight(Candidate iCandidate)
        {
            var newCandidate = new Candidate(_maxCandidateId++, iCandidate);
            var inputWeightIndex = _randomNumberGenerator.Next(0,
                                                               newCandidate.NeuralNetwork.InputWeights
                                                                   .Count);
            var oldInputWeight = newCandidate.NeuralNetwork.InputWeights[inputWeightIndex];

            double difference = _randomNumberGenerator.Next(0,
                                                            3) - 1;
            difference *= _randomNumberGenerator.NextDouble();

            newCandidate.NeuralNetwork.InputWeights[inputWeightIndex] =
                new Weight(oldInputWeight.StartNodeIndex,
                           oldInputWeight.EndNodeIndex,
                           oldInputWeight.WeightValue + difference);
            
            return newCandidate;
        }

        private List<Candidate> CreateCandidatesViaSexualReproduction(List<Candidate> initialCandidateList)
        {
            return new List<Candidate>();
            throw new System.NotImplementedException();
        }

        private List<Candidate> CreateCandidatesViaSpontaneousGeneration(List<Candidate> initialList)
        {
            var returnList = new List<Candidate>();
            
            int startingNumberOfCandidates = initialList.Count;
            
            for (int i = startingNumberOfCandidates;
                 i < MinimumNumberOfCandidates;
                 i++)
            {
                returnList.Add(new Candidate(_maxCandidateId++,
                                   _randomNumberGenerator));
            }

            return returnList;
        }
    }
}