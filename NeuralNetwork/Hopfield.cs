using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NeuralNetwork
{
    public class Hopfield
    {
        public int Unit { get; private set; }
        public int Height { get; private set; }
        public int Width { get; private set; }
        public int Size { get; private set; }

        Dictionary<int, List<double>> synapses = new Dictionary<int, List<double>>();
        public static Dictionary<char, List<double>> Symbols = new Dictionary<char, List<double>>
        {
            {' ', (new double[]
            {   0, 0, 0, 0, 0,
                0, 0, 0, 0, 0,
                0, 0, 0, 0, 0,
                0, 0, 0, 0, 0,
                0, 0, 0, 0, 0,
                0, 0, 0, 0, 0,
                0, 0, 0, 0, 0 }).ToList<double>()},
            { 'I', (new double[]
            {   0, 1, 1, 1, 0,
                0, 0, 1, 0, 0,
                0, 0, 1, 0, 0,
                0, 0, 1, 0, 0,
                0, 0, 1, 0, 0,
                0, 0, 1, 0, 0,
                0, 1, 1, 1, 0 }).ToList<double>() },
            { 'H', (new double[]
            {   1, 0, 0, 0, 1,
                1, 0, 0, 0, 1,
                1, 0, 0, 0, 1,
                1, 1, 1, 1, 1,
                1, 0, 0, 0, 1,
                1, 0, 0, 0, 1,
                1, 0, 0, 0, 1 }).ToList<double>()},
            { 'O', (new double[]
            {   0, 1, 1, 1, 0,
                0, 1, 0, 1, 0,
                1, 0, 0, 0, 1,
                1, 0, 0, 0, 1,
                1, 0, 0, 0, 1,
                0, 1, 0, 1, 0,
                0, 1, 1, 1, 0 }).ToList<double>()}
        };


        public Hopfield(int width, int height, int unit)
        {
            Width = width;
            Height = height;
            Unit = unit;
            Size = Height * Width;
            for (int i = 0; i < Size; i++)
            {
                synapses.Add(i, new List<double>());
                for (int j = 0; j < Size; j++)
                    synapses[i].Add(0);
            }

        }

        public void Train(List<double> values)
        {
            if (values.Count != Size)
                return;

            // input to bipolar matrix
            // 1 => will stay 1
            // 0 => will be -1
            Dictionary<int, List<double>> m2 = new Dictionary<int, List<double>>();
            for (int i = 0; i < Size; i++)
                m2.Add(i, (from x in values select x * 2 - 1).ToList<double>());

            // matrix multiplication with transposition
            Dictionary<int, List<double>> m3 = new Dictionary<int, List<double>>();
            for (int i = 0; i < Size; i++)
                m3.Add(i, (from x in m2[i] select m2[0][i] * x).ToList<double>());

            // add m3 to synapses
            for (int i = 0; i < Size; i++)
            for (int j = 0; j < Size; j++)
                synapses[i][j] += m3[i][j];
        }

        public List<double> Classify(List<double> values)
        {
            if (values.Count != Size || synapses == null)
                return values;
            // bipolarize
            for (int i = 0; i < values.Count; i++)
                values[i] = values[i] * 2 - 1;

            List<double> result = new List<double>();
            foreach (int neuron in synapses.Keys)
            {
                double sum = 0;
                for (int i = 0; i < Size; i++)
                    sum += values[i] * synapses[neuron][i];
                result.Add(sum > 0 ? 1 : 0);
            }
            return result;
        }
    }
}
