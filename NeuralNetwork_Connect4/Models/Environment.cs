using System.Collections.Generic;
using System.Threading.Tasks;

namespace NeuralNetwork_Connect4.Models
{
    public static class Environment
    {

        public static async IAsyncEnumerable<EvolutionProgress> GetEvolutionProgressAsync()
        {
            for (uint generation = 0;
                 true;
                 generation++)
            {
                await Task.Delay(1000);

                var evolutionProgress = new EvolutionProgress(generation);
                if (evolutionProgress.IsEndConditionReached)
                {
                    yield break;
                }

                yield return evolutionProgress;
            }
        }
    }
}