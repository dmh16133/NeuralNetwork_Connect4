using System.Collections.Generic;
using System.Linq;
using System.Windows.Documents;

namespace NeuralNetwork_Connect4.Models
{
    public static class Environment
    {
        public static async IAsyncEnumerable<EvolutionProgress> GetEvolutionProgressAsync()
        {
            List<Candidate> candidates = new List<Candidate>(); 
                
            for (uint generation = 0;
                 true;
                 generation++)
            {
                candidates = Hatchery.GetGenerationCandidateList(candidates);
                
                foreach (var iRedCandidate in candidates)
                {
                    foreach (var iBlueCandidate in candidates.Where(x=> x != iRedCandidate))
                    {
                        Game.PlayGame(iRedCandidate,
                                      iBlueCandidate);
                    }
                }

                if (generation > 5)
                {
                    yield break;
                }

                var topTwoCandidates = candidates.OrderBy(x => x.Score)
                                                 .Take(2);
                

                yield return new EvolutionProgress(generation,
                                                   new Game(topTwoCandidates[0],
                                                            topTwoCandidates[1]).GameBoard,
                                                   new Game(topTwoCandidates[1],
                                                            topTwoCandidates[0]).GameBoard);
                    );
            }
        }
    }
}