using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Documents;

namespace NeuralNetwork_Connect4.Models
{
    public static class Environment
    {
        public static IEnumerable<EvolutionProgress> GetEvolutionProgress(Random randomNumberGenerator)
        {
            List<Candidate> candidates = new List<Candidate>();
            var hatchery = new Hatchery(randomNumberGenerator);
                
            for (uint generation = 0;
                 true;
                 generation++)
            {
                candidates = hatchery.GetGenerationCandidateList(candidates);
                
                foreach (var iRedCandidate in candidates)
                {
                    foreach (var iBlueCandidate in candidates.Where(x=> x != iRedCandidate))
                    {
                        var game = new Game(iRedCandidate,
                                     iBlueCandidate);
                    }
                }

                if (generation > 5)
                {
                    yield break;
                }

                var topTwoCandidates = candidates.OrderBy(x => x.Score)
                                                 .TakeLast(2)
                                                 .ToList();

                yield return new EvolutionProgress(generation,
                                                   topTwoCandidates[0],
                                                   topTwoCandidates[1],
                                                   new Game(topTwoCandidates[0],
                                                            topTwoCandidates[1]).GameBoard,
                                                   new Game(topTwoCandidates[1],
                                                            topTwoCandidates[0]).GameBoard);
            }
        }
    }
}