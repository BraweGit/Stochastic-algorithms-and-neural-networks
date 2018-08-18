using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NeuralNetwork
{
    public class DifferentialEvolution
    {
        public float[][][] Generations;
        public int numberOfInviduals = 0;
        public int numberOfParams = 0;
        public float upperRange, lowerRange;
        public Random globalRandom;
        public int generationsLength;

        public float[] bestIndividual;

        int currentGeneration = 0;

        //Differential Evolution:
        public const float F = 0.5f;
        float CrossoverPossibility = 0.8f;

        NeuralNetwork nn;
        public bool solutionFound = false;
        public float[] solution = new float[] { 0, 0, 0, 0, };

        public DifferentialEvolution(int invidiuals, float minRange, float maxRange, int generations, NeuralNetwork nn)
        {
            this.generationsLength = generations;
            this.Generations = new float[this.generationsLength][][];
            this.numberOfInviduals = invidiuals;
            this.lowerRange = minRange;
            this.upperRange = maxRange;
            this.numberOfParams = 4;
            this.bestIndividual = new float[numberOfParams + 1];
            globalRandom = new Random();
            this.nn = nn;
        }

        public void createFirstGeneration()
        {
            Generations[0] = new float[numberOfInviduals][];

            for (uint individual = 0; individual < numberOfInviduals; individual++)
            {
                Generations[0][individual] = new float[numberOfParams + 1]; // + 1 = fitness
                for (uint parameter = 0; parameter < Generations[0][individual].Length - 1; parameter++)
                {
                    Generations[0][individual][parameter] = lowerRange + (float)globalRandom.NextDouble() * (upperRange - lowerRange);
                }
            }
        }

        public void FindBestIndividual()
        {
            foreach (var individual in Generations[currentGeneration])
            {
                if (individual[numberOfParams] <= bestIndividual[numberOfParams])
                {
                    for (var i = 0; i < individual.Length; i++)
                    {
                        bestIndividual[i] = individual[i];
                    }
                }
            }
        }

        public void TargetVector(float[][] executedGeneration, uint individual, int[] theChoosenOnes)
        {
            float[] individualVector = new float[numberOfParams + 1];

            for (var i = 0; i < executedGeneration[individual].Length - 1; i++)
            {
                // differential vector
                individualVector[i] = executedGeneration[theChoosenOnes[0]][i] - executedGeneration[theChoosenOnes[1]][i];

                // weight differential vector
                individualVector[i] *= F; // mutation

                // noise vector
                individualVector[i] += executedGeneration[theChoosenOnes[2]][i];

                // test vector
                if (globalRandom.NextDouble() > CrossoverPossibility)
                {
                    individualVector[i] = executedGeneration[individual][i]; // check crossover and pick one based on CR
                }
            }

            if (this.calculateFitnessIndividual(individualVector)
                <= this.calculateFitnessIndividual(executedGeneration[individual]))
            {
                executedGeneration[individual] = individualVector;
            }

        }

        public void NextGeneration()
        {
            currentGeneration++;

            Generations[currentGeneration] = new float[numberOfInviduals][];

            for (uint individual = 0; individual < numberOfInviduals; individual++)
            {
                Generations[currentGeneration][individual] = new float[numberOfParams + 1]; // + 1 = fitness
                for (uint parameter = 0; parameter < Generations[currentGeneration][individual].Length - 1; parameter++)
                {
                    Generations[currentGeneration][individual][parameter] = Generations[currentGeneration - 1][individual][parameter];
                }
            }

            // for each individual in generation (TARGET)

            for (uint individual = 0; individual < numberOfInviduals; individual++)
            {
                int[] rGen = new int[3]; // the choosen ones

                // choose three random individuals diffrent than target
                do
                {
                    rGen[0] = globalRandom.Next(0, numberOfInviduals);
                } while (rGen[0] == individual);

                do
                {
                    rGen[1] = globalRandom.Next(0, numberOfInviduals);
                } while (rGen[1] == individual || rGen[0] == rGen[1]);

                do
                {
                    rGen[2] = globalRandom.Next(0, numberOfInviduals);
                } while (rGen[2] == individual || rGen[0] == rGen[2] || rGen[1] == rGen[2]);


                // execute 
                TargetVector(Generations[currentGeneration], individual, rGen);
            }

            this.borderChecker();
        }


        public float calculateFitnessIndividual(float[] individual)
        {
            var x = nn.CheckIndividualWeights(individual);
            if (x == 3)
            {
                this.solutionFound = true;
                solution = individual;
            };
            return x;
        }

        public float[][] calculateFitness(dynamic function)
        {
            for (var i = 0; i < Generations[currentGeneration].Length; i++)
            {
                //Console.WriteLine(Generation[i]);
                Generations[currentGeneration][i][numberOfParams] = function(new float[] { Generations[currentGeneration][i][0], Generations[currentGeneration][i][1] });
            }
            if (currentGeneration == 0)
            {
                bestIndividual[0] = Generations[currentGeneration][0][0];
                bestIndividual[1] = Generations[currentGeneration][0][1];
                bestIndividual[2] = Generations[currentGeneration][0][2];
            }

            FindBestIndividual();
            return this.Generations[currentGeneration];
        }

        public void borderChecker()
        {
            bool change = false;
            foreach (var individual in Generations[currentGeneration])
            {
                for (var parameter = 0; parameter < individual.Length - 1; parameter++)
                {
                    if (individual[parameter] > upperRange || individual[parameter] < lowerRange)
                    {
                        individual[parameter] = lowerRange + (float)globalRandom.NextDouble() * (upperRange - lowerRange);
                        change = true;
                    }

                    if (change)
                    {
                        individual[individual.Length - 1] = this.calculateFitnessIndividual(individual);
                        change = false;
                    }

                }

            }
        }
    }
}
