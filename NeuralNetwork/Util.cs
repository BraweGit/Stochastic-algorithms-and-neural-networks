using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NeuralNetwork
{

    public class TrainType
    {
        public string Name { get; set; }
        public int Value { get; set; }

        public TrainType(string name, int value)
        {
            Name = name;
            Value = value;
        }
    }

    public static class Util
    {
        public static Random r = new Random();
        public const int defaultNeuronsCount = 2;
        public const int DEFAULT_INPUT_SIZE = 1;
        public const int DEFAULT_HIDDEN_SIZE = 2;
        public const int DEFAULT_OUTPUT_SIZE = 1;
    }
}
