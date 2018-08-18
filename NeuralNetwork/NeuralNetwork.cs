using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Drawing.Configuration;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace NeuralNetwork
{
    public class Layer
    {
        public string Name { get; set; }
        public List<Neuron> Neurons { get; set; }
        public int Value { get; set; }
        public int Index { get; set; }
        public int Size { get; set; }
        public LayerType Type { get; set; }
        public override string ToString() { return this.Name; }

        public Layer()
        {
            Neurons = new List<Neuron>();
        }

        public void FillLayer()
        {
            for (var i = 0; i < Size; i++)
            {
                Neurons.Add(new Neuron(Index, i));
            }

        }

        public void Init(Layer prev)
        {
            //No input synapses
            if (prev == null) return;

            foreach (var pn in prev.Neurons)
            {
                //int inputIndex = 1;
                foreach (var n in Neurons)
                {
                    var synapse = new Synapse(pn, n, n.InputSynapses.Count + 1, Util.r.NextDouble());
                    pn.OutputSynapses.Add(synapse);
                    n.InputSynapses.Add(synapse);
                }
            }
        }
    }

    public class Perceptron
    {
        public Neuron PerceptronNeuron { get; set; }
        public List<Tuple<double[], double>> TrainingSet { get; set; }

        public Perceptron(List<Tuple<double[], double>> data)
        {
            PerceptronNeuron = new Neuron();
            TrainingSet = data;
            PerceptronNeuron.Initialize(data[0].Item1.Length);
        }

    }

    public class NeuralNetwork
    {
        public List<double> Errors { get; set; }
        private double LearnRate { get; set; }
        private double Momentum { get; set; }
        public List<Tuple<double[], double>> TrainingSet { get; set; }
        public BindingList<Layer> AllLayers { get; set; }

        public NeuralNetwork(int inputSize = Util.DEFAULT_INPUT_SIZE, int hiddenSize = Util.DEFAULT_HIDDEN_SIZE, int outputSize = Util.DEFAULT_OUTPUT_SIZE, double? learnRate = null, double? momentum = null)
        {
           
            LearnRate = learnRate ?? .4;
            Momentum = momentum ?? .9;
            AllLayers = new BindingList<Layer>();
            AllLayers.Add(new Layer { Index = 0, Size = inputSize, Value = 0, Name = "Input Layer", Type = LayerType.InputLayer, Neurons = new List<Neuron>() });
            AllLayers.Add(new Layer { Index = AllLayers.Count, Name = "Hidden Layer 1", Type = LayerType.HiddenLayer, Value = AllLayers.Count, Size = hiddenSize, Neurons = new List<Neuron>() });
            AllLayers.Add(new Layer { Index = AllLayers.Count, Size = outputSize, Value = AllLayers.Count, Name = "Output Layer", Type = LayerType.OutputLayer, Neurons = new List<Neuron>() });
            FillLayers();
            InitLayers();
        }

        #region Network

        public void Train(List<Tuple<double[], double>> trainingSet, int trainType, int numEpochs, double minError = 0)
        {
            Errors = new List<double>();
            if (trainType == 2)
            {
                TrainingSet = trainingSet;
                var de = new DifferentialEvolution(25, -2, 2, 1000, this);

                de.createFirstGeneration();
                for (var i = 0; i < 1000; i++)
                {
                    if (de.solutionFound == false)
                    {
                        de.NextGeneration();
                    }
                    else
                    {
                        var weights = new float[]
                        {
                            de.solution[0], de.solution[0],
                            de.solution[1], de.solution[1],
                            de.solution[2],
                            de.solution[3]
                        };

                        UpdateWeights(weights);
                        ForwardPropagate(1, 0);
                        break;
                    }

                }
                return;
            }


            if (minError == 0)
            {
                var errors = new List<double>();
                for (var i = 0; i < numEpochs; i++)
                {
                    for (var j = 0; j < trainingSet.Count; j++)
                    {
                        ForwardPropagate(trainingSet[j].Item1);
                        if (trainType == 1)
                            BackPropagate(trainingSet[j].Item2);
                        else if (trainType == 0) FixedIncremenet(trainingSet[j].Item2);
                        errors.Add(CalculateError(trainingSet[j].Item2));
                    }
                    Errors.Add(errors.Average());
                }
            }
            else
            {
                var error = 1.0;
                var epochCount = 0;
                var test = 10;
                while (error > minError && epochCount < 5000)
                {
                    var errors = new List<double>();
                    for (var j = 0; j < trainingSet.Count; j++)
                    {
                        ForwardPropagate(trainingSet[j].Item1);
                        if (trainType == 1)
                            BackPropagate(trainingSet[j].Item2);
                        else if (trainType == 0) FixedIncremenet(trainingSet[j].Item2);
                        errors.Add(CalculateError(trainingSet[j].Item2));
                    }
                    error = errors.Average();
                    Errors.Add(error);
                    epochCount++;
                }
            }

        }

        public void UpdateWeights(float[] weights)
        {
            var neurons = GetAllNeurons();
            var synapses = new List<Synapse>();
            foreach (var n in neurons)
            {
                synapses.AddRange(n.InputSynapses);
            }

            if (weights.Length != synapses.Count)
                return;

            for (int i = 0; i < weights.Length; i++)
            {
                synapses[i].Weight = weights[i];
            }

        }

        public List<Neuron> GetAllNeurons()
        {
            var neurons = new List<Neuron>();

            foreach (var l in GetHiddenLayers())
            {
                neurons.AddRange(l.Neurons);
            }

            neurons.AddRange(GetOutputLayer().Neurons);

            return neurons;
        }

        public double[] Compute(params double[] inputs)
        {
            ForwardPropagate(inputs);
            return GetOutputLayer().Neurons.Select(a => a.Output).ToArray();
        }

        private void ForwardPropagate(params double[] inputs)
        {
            var i = 0;
            GetInputLayer().Neurons.ForEach(a => a.Input = a.Output = inputs[i++]);
            foreach (var h in GetHiddenLayers())
            {
                h.Neurons.ForEach(a => a.GetOuputValue());
            }

            GetOutputLayer().Neurons.ForEach(a => a.GetOuputValue());
            Console.WriteLine("XOR {0}", GetOutputLayer().Neurons[0].GetOuputValue());
        }

        private void FixedIncremenet(double target)
        {
            var outputLayer = GetOutputLayer();
            outputLayer.Neurons.ForEach(n => n.CalculateError(target));
            var hiddenLayers = GetHiddenLayers();
            outputLayer.Neurons.ForEach(a => a.UpdateWeightsFixedIncrement());
            foreach (var h in hiddenLayers)
            {
                h.Neurons.ForEach(a => a.CalculateError(target));
            }
            foreach (var h in hiddenLayers)
            {
                h.Neurons.ForEach(a => a.UpdateWeightsFixedIncrement());
            }
        }

        private void BackPropagate(double target)
        {
            var outputLayer = GetOutputLayer();
            var hiddenLayers = GetHiddenLayers();
            GetOutputLayer().Neurons.ForEach(a => a.CalculateSigmoidError(target));
            outputLayer.Neurons.ForEach(a => a.UpdateWeights(LearnRate, Momentum));
            foreach (var h in hiddenLayers)
            {
                h.Neurons.ForEach(a => a.CalculateSigmoidError());
            }

            foreach (var h in hiddenLayers)
            {
                h.Neurons.ForEach(a => a.UpdateWeights(LearnRate, Momentum));
            }
        }

        private double CalculateError(params double[] targets)
        {
            var i = 0;
            return GetOutputLayer().Neurons.Sum(a => Math.Abs(a.CalculateError(targets[i++])));
        }

        public int CheckIndividualWeights(float[] individual)
        {
            var counter = 0;
            for (var i = 0; i < TrainingSet.Count; i++)
            {
                
                var temp1 = TrainingSet[i].Item1[0] * individual[0] + TrainingSet[i].Item1[1] * individual[0];
                var temp2 = TrainingSet[i].Item1[0] * individual[1] + TrainingSet[i].Item1[1] * individual[1];

                // first hidden layer
                if (temp1 >= 1)
                {
                    temp1 = 1;
                }
                else
                {
                    temp1 = 0;
                }

                if (temp2 >= 1)
                {
                    temp2 = 1;
                }
                else
                {
                    temp2 = 0;
                }

                // get value per connection
                var temp3 = temp1 * individual[2] +
                            temp2 * individual[3];

                // second hidden layer
                if (temp3 < 0)
                {
                    temp3 = 0;
                }
                else
                {
                    temp3 = 1;
                }

                // check if result is ok

                if ((int)TrainingSet[i].Item2 != temp3)
                {
                    //pass
                }
                else
                {
                    counter++;
                }


            }

            return counter;
        }


        private void FillLayers()
        {
            foreach (var l in AllLayers)
            {
                l.FillLayer();
            }
        }

        private void InitLayers()
        {
            var hiddenLayers = GetHiddenLayers();
            foreach (var h in hiddenLayers)
            {
                h.Init(AllLayers.FirstOrDefault(x => x.Index == h.Index - 1));
            }

            //Init output layer
            var outputLayer = GetOutputLayer();
            outputLayer.Init(hiddenLayers.LastOrDefault());
        }

        public void AddLayer(int size)
        {
            var newLayer = new Layer
            {
                Type = LayerType.HiddenLayer,
                Size = size,
                Neurons = new List<Neuron>(),
                Index = AllLayers.Where(x => x.Type == LayerType.HiddenLayer).ToList().Count + 1,
                Name = "Hidden Layer " + (AllLayers.Where(x => x.Type == LayerType.HiddenLayer).ToList().Count + 1),
                Value = AllLayers.Where(x => x.Type == LayerType.HiddenLayer).ToList().Count + 1
            };
            newLayer.FillLayer();
            AllLayers.Add(newLayer);
            InitLayers();
        }

        public void RemoveLayer(int index)
        {
            //Cant remove input/output layer
            if (index > -1)
            {
                var toRemove = AllLayers[index];
                if (toRemove.Type == LayerType.HiddenLayer)
                    AllLayers.Remove(toRemove);
            }
            InitLayers();
        }

        public void RemoveNeuron(Layer l)
        {
            if (l.Neurons.Count > 1)
                l.Neurons.RemoveAt(l.Neurons.Count - 1);

            InitLayers();
        }

        public Layer GetInputLayer()
        {
            return AllLayers.FirstOrDefault(x => x.Type == LayerType.InputLayer);
        }

        public Layer GetOutputLayer()
        {
            return AllLayers.FirstOrDefault(x => x.Type == LayerType.OutputLayer);
        }

        public List<Layer> GetHiddenLayers()
        {
            return AllLayers.Where(x => x.Type == LayerType.HiddenLayer).ToList();
        }

        public void AddNeuron(Layer l)
        {
            l.Neurons.Add(new Neuron(l.Index, l.Neurons.Count));
            InitLayers();
        }

        public int GetLayerCount()
        {
            return AllLayers.Count;
        }

        private int GetMaxLayer()
        {
            return AllLayers.Max(x => x.Neurons.Count);
        }

        public BindingList<Layer> GetAllLayers()
        {
            return new BindingList<Layer>(AllLayers.OrderBy(x => x.Type).ToList());
        }

        #endregion Network

        #region Visual

        public Bitmap ToBitmap()
        {
            var hiddenLayers = GetHiddenLayers();
            int layercount = GetHiddenLayers().Count;

            int nodewidth = 190;
            int nodeheight = 35;


            int picwidth = nodewidth * 2 + layercount * nodewidth + 30;

            int inputs = GetInputLayer().Neurons.Count;
            int outputs = GetOutputLayer().Neurons.Count;


            int layers = 0;
            if (layercount != 0)
            {
                layers = GetMaxLayer();
            }

            int maxheight = Math.Max(Math.Max(inputs, outputs), layers);

            int picheight = nodeheight * maxheight;


            Bitmap pic = new Bitmap(picwidth, picheight);
            Graphics g = Graphics.FromImage(pic);
            g.InterpolationMode = System.Drawing.Drawing2D.InterpolationMode.HighQualityBicubic;
            g.TextRenderingHint = System.Drawing.Text.TextRenderingHint.AntiAliasGridFit;
            g.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.AntiAlias;

            #region inputs
            int inheight = inputs * nodeheight;
            Point startpos = new Point(30, picheight / 2 - inheight / 2);
            g.Clear(Color.Transparent);
            for (int i = 0; i < inputs; i++)
            {
                drawInputNode(g, startpos.X, startpos.Y + i * nodeheight, GetInputLayer().Neurons[i].Output);
                // STRING CHANGE
                g.DrawString(GetInputLayer().Neurons[i].Output.ToString("0.00"), new Font("Arial", 7), Brushes.Black, 5, startpos.Y + 10 + i * nodeheight);
            }
            #endregion

            #region layers
            for (int u = 0; u < layercount; u++)
            {
                inheight = hiddenLayers[u].Neurons.Count * nodeheight;
                startpos = new Point(30 + nodewidth * (1 + u), picheight / 2 - inheight / 2);

                for (int i = 0; i < hiddenLayers[u].Neurons.Count; i++)
                {
                    drawnode(g, startpos.X, startpos.Y + i * nodeheight, hiddenLayers[u].Neurons[i].Output);


                    if (u == 0)
                    {
                        Point laststart = new Point(30, picheight / 2 - inputs * nodeheight / 2);
                        int lastcount = inputs;
                        connectnode(g, startpos.X, startpos.Y + i * nodeheight, lastcount, laststart);
                    }
                    else
                    {
                        Point laststart = new Point(30 + nodewidth * (1 + u - 1), picheight / 2 - hiddenLayers[u - 1].Neurons.Count * nodeheight / 2);
                        int lastcount = hiddenLayers[u - 1].Neurons.Count;
                        connectnode(g, startpos.X, startpos.Y + i * nodeheight, lastcount, laststart);
                    }
                }
            }
            #endregion

            #region end

            Point endpos = new Point(30 + (layercount + 1) * nodewidth, picheight / 2 - outputs * nodeheight / 2);
            for (int i = 0; i < outputs; i++)
            {

                drawOutputNode(g, endpos.X, endpos.Y + i * nodeheight, GetOutputLayer().Neurons[i].Output);
                g.DrawString(GetOutputLayer().Neurons[i].Output.ToString("0.00"), new Font("Arial", 7), Brushes.Black, endpos.X + 35, endpos.Y + i * nodeheight + 10);

                if (layers == 0)
                {
                    connectnode(g, endpos.X, endpos.Y + i * nodeheight, GetInputLayer().Neurons.Count(), new Point(30 + layercount * nodewidth, picheight / 2 - GetInputLayer().Neurons.Count() * nodeheight / 2));
                }
                else
                {
                    connectnode(g, endpos.X, endpos.Y + i * nodeheight, hiddenLayers.Last().Neurons.Count, new Point(30 + layercount * nodewidth, picheight / 2 - hiddenLayers.Last().Neurons.Count * nodeheight / 2));
                }
            }

            #endregion


            return pic;
        }

        void drawnode(Graphics g, int X, int Y, double value)
        {
            g.DrawEllipse(Pens.Black, X, Y, 30, 30);
            g.DrawString(value.ToString("0.00"), new Font("Arial", 7), Brushes.Red, X + 5, Y + 10);
        }

        void drawInputNode(Graphics g, int X, int Y, double value)
        {
            g.DrawEllipse(Pens.Green, X, Y, 30, 30);
            g.DrawString(value.ToString("0.00"), new Font("Arial", 7), Brushes.Red, X + 5, Y + 10);
        }

        void drawOutputNode(Graphics g, int X, int Y, double value)
        {
            g.DrawEllipse(Pens.Red, X, Y, 30, 30);
            g.DrawString(value.ToString("0.00"), new Font("Arial", 7), Brushes.Green, X + 5, Y + 10);
        }

        void connectnode(Graphics g, int X, int Y, int nrlastlayer, Point startlastlayer)
        {
            Pen pen = new Pen(Color.Orange);
            pen.Width = 0.10F;

            for (int i = 0; i < nrlastlayer; i++)
            {

                g.DrawLine(pen, X, Y + 15, startlastlayer.X + 30, startlastlayer.Y + 15 + i * 35);
            }
        }

        #endregion Visual
    }


}
