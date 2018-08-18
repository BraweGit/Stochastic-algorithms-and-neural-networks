using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace NeuralNetwork
{
    public class Neuron
    {
        #region Properties
        public int Layer { get; set; }
        public int Index { get; set; }

        public double Bias { get; set; }
        public double BiasWeight { get; set; }
        public double LearningRate { get; set; }

        public List<Synapse> InputSynapses { get; set; }
        public List<Synapse> OutputSynapses { get; set; }

        public double Input { get; set; }
        public double Output { get; set; }

        public double TotalError { get; set; }
        public double Error { get; set; }

        // Fixed increment constant
        public double C { get; set; }
        #endregion

        public Neuron()
        {
            InputSynapses = new List<Synapse>();
            OutputSynapses = new List<Synapse>();
            Bias = 1;
            BiasWeight = Neuron.GetRandomBias();
            TotalError = 0;
            C = 1;
        }

        public Neuron(int layer, int index, double? bias = null) : this()
        {
            this.Layer = layer;
            this.Index = index;
            this.LearningRate = 1;
            this.BiasWeight = (bias == null) ? Neuron.GetRandomBias() : (double)bias;
            this.Output = 0;

            this.TotalError = 0;
        }

        public Neuron(int layer, int index, List<Synapse> inputs, List<Synapse> outputs, double? bias = null) : this()
        {
            this.Layer = layer;
            this.Index = index;
            this.LearningRate = 1;
            this.BiasWeight = (bias == null) ? Neuron.GetRandomBias() : (double)bias;
            this.Output = 0;
            InputSynapses = inputs;
            OutputSynapses = outputs;

            this.TotalError = 0;
        }

        public void Initialize(int numberInputs)
        {
            for (int i = 0; i < numberInputs; i++)
            {
                InputSynapses.Add(new Synapse(i + 1, this, Util.r.NextDouble()));
            }

            LearningRate = 1;
        }

        public double CalculateError(double target)
        {
            return Error = (target - Output);
        }

        public double CalculateSigmoidError(double? target = null)
        {
            if (target == null)
                return Error = OutputSynapses.Sum(a => a.OutputNeuron.Error * a.Weight) * Sigmoid.Derivative(Output);
            return Error = Sigmoid.Derivative(Output) * CalculateError(target.Value);
        }

        public void UpdateWeightsFixedIncrement()
        {
            // We will be adjusting weights
            C = 0;
            if (Error > 0)
                C = 1;
            else if(Error < 0) C = -1;

            foreach (var synapse in InputSynapses)
            {
                synapse.Weight += C * synapse.InputNeuron.Output;
            }
        }

        public void UpdateWeights(double learnRate, double momentum)
        {
            var prevDelta = BiasWeight;
            BiasWeight = learnRate * Error;
            Bias += BiasWeight + momentum * prevDelta;

            foreach (var synapse in InputSynapses)
            {
                prevDelta = synapse.WeightDelta;
                synapse.WeightDelta = learnRate * Error * synapse.InputNeuron.Output;
                synapse.Weight += synapse.WeightDelta + momentum * prevDelta;
            }
        }

        public void UpdateWeights()
        {
            for (int i = 0; i < InputSynapses.Count; i++)
            {
                InputSynapses[i].Weight += /* LearningRate **/ Error * InputSynapses[i].InputNeuron.Output;
            }
            BiasWeight += Error;
        }

        public void TrainOnce(double[] input, double target)
        {
            if(input.Length != InputSynapses.Count)
                throw new Exception("Invalid training data!");

            var sum = Sum(input);
            var val = GetBiaryOutputValue(sum);
            var error = CalculateError(target);

            for (int i = 0; i < InputSynapses.Count; i++)
            {
                InputSynapses[i].Weight += LearningRate*error*input[i];
            }

            BiasWeight += LearningRate*error*Bias;

            TotalError += Math.Abs(error);
        }

        public void Train(List<Tuple<double[], double>> data, int nTimes )
        {
            for (int n = 0; n < nTimes; n++)
            {
                for (int i = 0; i < data.Count; i++)
                {
                    TrainOnce(data[i].Item1, data[i].Item2);
                }
            }
        }

        public void TrainUntil(List<Tuple<double[], double>> data, double desiredError)
        {
            TotalError = 1;
            while (TotalError > desiredError)
            {
                TotalError = 0;
                for (int i = 0; i < data.Count; i++)
                {
                    TrainOnce(data[i].Item1, data[i].Item2);
                }
            }

        }

        private double Sum()
        {
            var input = 0.0;
            for (int i = 0; i < InputSynapses.Count; i++)
            {
                input += InputSynapses[i].InputNeuron.Output * InputSynapses[i].Weight;
            }

            Input += BiasWeight;
            Input = input;
            return Input;
        }

        private double Sum(double[] inputs)
        {
            var input = 0.0;
            for(int i = 0; i < inputs.Length; i++)
            {
                input += inputs[i]*InputSynapses[i].Weight;
            }

            input += Bias*BiasWeight;
            Input = input;
            return Input;
        }

        public double GetBiaryOutputValue(double sum)
        {
            return Output = (sum >= 0) ? 1 : 0;
        }

        public double GetBiaryOutputValue(double[] input)
        {
            return GetBiaryOutputValue(Sum(input));
        }

        public double GetOuputValue()
        {
            double sum = 0;
            for (int i = 0; i < InputSynapses.Count; i++)
            {
                sum += InputSynapses[i].Weight * InputSynapses[i].InputNeuron.Output;

            }
            return Output = Sigmoid.Output(InputSynapses.Sum(a => a.Weight * a.InputNeuron.Output) + BiasWeight);
        }




        public String GetName()
        {
            return String.Format("Neuron L:{0}, I:{1}", Layer, Index);
        }

        public void AddInput(Synapse input)
        {
            InputSynapses.Add(input);
        }

        public static double GetDefaultBias()
        {
            return 1;
        }

        public static double GetRandomBias()
        {
            return Util.r.NextDouble();
        }
    }
}
