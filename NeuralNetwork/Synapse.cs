using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NeuralNetwork
{
    public class Synapse
    {
        public Neuron InputNeuron { get; set; }
        public Neuron OutputNeuron { get; set; }
        public int InputIndex { get; set; } // an input-layer neuron index
        public double LastInput { get; set; }

        public double Weight { get; set; }
        public double WeightDelta { get; set; }

        public Synapse(Neuron source, Neuron target, int inputIndex, double weight)
        {
            this.InputNeuron = source;
            this.OutputNeuron = target;
            this.Weight = weight;
            InputIndex = inputIndex;
        }

        public Synapse(int inputIndex, Neuron target, double weight)
        {
            this.InputNeuron = null;
            this.OutputNeuron = target;
            this.Weight = weight;
            this.InputIndex = inputIndex;
        }

        public String GetName()
        {
            if (OutputNeuron != null)
                if (InputNeuron != null)
                    return String.Format("Source: {0}, Target: {1}", InputNeuron.GetName(), OutputNeuron.GetName());
                else
                    return String.Format("Input layer: {0}, Target: {1}", InputIndex, OutputNeuron.GetName()); //input 
            else
                return "";
        }

        public static double GetRandomWeight()
        {
            return Util.r.NextDouble();
        }
    }
}
;