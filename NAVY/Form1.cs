using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Forms.DataVisualization.Charting;
using NeuralNetwork;

namespace NAVY
{
    public partial class Form1 : Form
    {
        private NeuralNetwork.NeuralNetwork _neuralNetwork;
        private NeuralNetwork.Perceptron _perceptron;
        private Bitmap _bitmap;
        private MyDrawing myDrawing;
        private List<Input> PerceptronInputs { get; set; }
        private int _numEpochs = 2000;
        private double _minError = 0.01;
        private string _path;
        private int _trainType;
        //Hopfield
        private Hopfield _hopfield;
        private List<double> _hopImage;

        public Form1()
        {
            InitializeComponent();
            PerceptronInputs = new List<Input>();
            myDrawing = new MyDrawing();
            // Transfer function 0 == binary, 1 == sigmoid
            _neuralNetwork = new NeuralNetwork.NeuralNetwork(2,2,1);
            _perceptron = new Perceptron(ParseData("AND.txt"));
            //_perceptron.PerceptronNeuron.TrainUntil(_perceptron.TrainingSet, 0.2);
            myDrawing.DrawPerceptron(_perceptron, perceptronPictureBox);
            InitControls();
            refreshNetwork();
            errorChart.Series.Clear();
            //Hopfield
            _hopfield = new Hopfield(5, 7, 50);
            _hopImage = new List<double>();
        }

        private List<Tuple<double[], double>> ParseData(string path)
        {
            var result = new List<Tuple<double[], double>>();
            string[] lines = System.IO.File.ReadAllLines(path);
            foreach (var line in lines)
            {
                var split = line.Split(';');
                result.Add(Tuple.Create(new double[] { Double.Parse(split[0]), Double.Parse(split[1]) }, Double.Parse(split[2])));
            }
            return result;
        }

        private void CreateChart()
        {
            errorChart.Series.Clear();
            var series = new Series("Global Error");
            series.ChartType = SeriesChartType.Line;
            series.Points.DataBindXY(Enumerable.Range(1, _neuralNetwork.Errors.Count).ToArray(), _neuralNetwork.Errors);
            errorChart.Series.Add(series);


        }

        private void btnAnnShow_Click(object sender, EventArgs e)
        {
            _bitmap = _neuralNetwork.ToBitmap();
            annPictureBox.Image = null;
            annPictureBox.Image = _bitmap;
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            tabControl.SelectedIndex = 0;
            UpdateControls();
            //Hopfield
            for (int i = 0; i < _hopfield.Width * _hopfield.Height; i++)
                _hopImage.Add(0);

            comboHopfield.DataSource = Hopfield.Symbols.Keys.ToList<char>();
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void btnAddLayer_Click(object sender, EventArgs e)
        {
            AddNewLayer();
        }

        private void InitControls()
        {
            toolStripComboBoxLayer.ComboBox.DataSource = _neuralNetwork.GetAllLayers();
            toolStripComboBoxLayer.ComboBox.ValueMember = "Value";
            toolStripComboBoxLayer.ComboBox.DisplayMember = "Name";
            openFileDialog1.Filter = "All Files (*.*)|*.*";
            openFileDialog1.FilterIndex = 1;
            comboInputs.ValueMember = "Value";
            comboInputs.DisplayMember = "Name";
            comboTrainType.ComboBox.DataSource = new List<TrainType>()
            {
                new TrainType("Fixed Increment", 0),
                new TrainType("BackPropagation", 1),
                new TrainType("Evolution Algorithm", 2)
            };
            comboTrainType.ComboBox.ValueMember = "Value";
            comboTrainType.ComboBox.DisplayMember = "Name";
            _trainType = 0;

        }

        private void UpdateControls()
        {
            if (_neuralNetwork == null)
                return;
            if (labelHiddenLayers != null)
                if (_neuralNetwork.GetHiddenLayers() != null)
                    labelHiddenLayers.Text = _neuralNetwork.GetHiddenLayers().Count + @" HIDDEN LAYERS";
                else
                {
                    labelHiddenLayers.Text = 0 + @" HIDDEN LAYERS";
                }

            toolStripComboBoxLayer.ComboBox?.Refresh();

            if (toolStripComboBoxLayer.ComboBox != null)
            {
                toolStripComboBoxLayer.ComboBox.DataSource = _neuralNetwork.GetAllLayers();
            }


        }

        private void AddNewLayer()
        {
            _neuralNetwork.AddLayer(Util.defaultNeuronsCount);
            UpdateControls();

        }

        private void btnRemoveLayer_Click(object sender, EventArgs e)
        {
            _neuralNetwork.RemoveLayer((int)removeLayerIndex.Value);
            UpdateControls();

        }

        private void btnNeuronRandom_Click(object sender, EventArgs e)
        {
        }

        private void toolStripButton1_Click(object sender, EventArgs e)
        {
            AddNewLayer();
            refreshNetwork();
        }

        private void refreshNetwork()
        {
            _bitmap = _neuralNetwork.ToBitmap();
            annPictureBox.Image = null;
            annPictureBox.Image = _bitmap;
        }

        private void toolStripButton3_Click(object sender, EventArgs e)
        {
            refreshNetwork();
        }

        private void toolStripButton2_Click(object sender, EventArgs e)
        {
            if (_neuralNetwork.GetHiddenLayers().Count != 0)
            {
                var toRemove = _neuralNetwork.GetHiddenLayers().Last();
                _neuralNetwork.AllLayers.Remove(toRemove);
                UpdateControls();
                refreshNetwork();
            }

        }

        private void btnAddNeuron_Click(object sender, EventArgs e)
        {
            var selectedLayer = (Layer)toolStripComboBoxLayer.SelectedItem;
            _neuralNetwork.AddNeuron(selectedLayer);
            UpdateControls();
            refreshNetwork();
        }

        private void btnRemoveNeuron_Click(object sender, EventArgs e)
        {
            Layer selectedLayer = (Layer)toolStripComboBoxLayer.SelectedItem;
            _neuralNetwork.RemoveNeuron(selectedLayer);
            UpdateControls();
            refreshNetwork();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                string sFileName = openFileDialog1.FileName;
                _perceptron = new Perceptron(ParseData(sFileName));

                PerceptronInputs.Clear();
                for (int i = 0; i < _perceptron.TrainingSet[0].Item1.Length; i++)
                {
                    PerceptronInputs.Add(new Input() { Index = (i + 1), Name = "Input " + (i + 1) });
                }

                comboInputs.DataSource = PerceptronInputs;
                myDrawing.DrawPerceptron(_perceptron, perceptronPictureBox);
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            _perceptron.PerceptronNeuron.TrainUntil(_perceptron.TrainingSet, 0.2);
            myDrawing.DrawPerceptron(_perceptron, perceptronPictureBox);
        }

        private void comboInputs_SelectedIndexChanged(object sender, EventArgs e)
        {
            var selectedItem = (Input)comboInputs.SelectedItem;
            numInputValue.Text = selectedItem.Value.ToString();
        }

        private void RedrawPerceptron()
        {
            myDrawing.DrawPerceptron(_perceptron, perceptronPictureBox);
        }

        private void button4_Click(object sender, EventArgs e)
        {
            var selectedItem = (Input)comboInputs.SelectedItem;
            if (!numInputValue.Text.Equals(""))
                selectedItem.Value = Double.Parse(numInputValue.Text);

            var arrValues = new double[PerceptronInputs.Count];
            var i = 0;
            foreach (var val in PerceptronInputs)
            {
                arrValues[i] = val.Value;
                i++;
            }

            _perceptron.PerceptronNeuron.GetBiaryOutputValue(arrValues);
            RedrawPerceptron();
        }

        private void btnTrain_Click(object sender, EventArgs e)
        {
            _minError = Double.Parse(txtMinError.Text, CultureInfo.InvariantCulture);
            _neuralNetwork.Train(ParseData(_path), _trainType, _numEpochs, _minError);
            refreshNetwork();
            CreateChart();
        }

        private void numEpochs_ValueChanged(object sender, EventArgs e)
        {
            _numEpochs = (int)numEpochs.Value;
        }

        private void txtMinError_Leave(object sender, EventArgs e)
        {
            _minError = Double.Parse(txtMinError.Text, CultureInfo.InvariantCulture);
        }

        private void btnTrainingSet_Click(object sender, EventArgs e)
        {
            if (openFileDialog1.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                _path = openFileDialog1.FileName;
            }
        }

        private void comboTrainType_SelectedIndexChanged(object sender, EventArgs e)
        {
            _trainType = (int) comboTrainType.ComboBox.SelectedValue;
        }

        private void picHopfieldValues_Click(object sender, EventArgs e)
        {
            int x = ((MouseEventArgs)e).X;
            int y = ((MouseEventArgs)e).Y;
            _hopImage[(int)(y / _hopfield.Unit) * _hopfield.Width + (int)(x / _hopfield.Unit)] = 1.0;
            RedrawHopfieldImage();
        }


        private void RedrawHopfieldImage()
        {

            Bitmap b = picHopfieldValues.Image != null ? new Bitmap(picHopfieldValues.Image) : new Bitmap(picHopfieldValues.Width, picHopfieldValues.Height);
            using (Graphics g = Graphics.FromImage(b))
            {
                g.Clear(Color.White);
                // draw squares
                for (int i = 0; i < _hopfield.Height; i++)
                for (int j = 0; j < _hopfield.Width; j++)
                {
                    double value = _hopImage[i * _hopfield.Width + j];
                    Brush color = new SolidBrush(Color.FromArgb(255, (int)(value * 255), (int)(value * 255), (int)(value * 255)));
                    g.FillRectangle(color, j * _hopfield.Unit, i * _hopfield.Unit, (j + 1) * _hopfield.Unit, (i + 1) * _hopfield.Unit);
                }

                for (int i = 0; i < _hopfield.Width + 1; i++) // cols
                    g.DrawLine(Pens.Gray, i * _hopfield.Unit, 0, i * _hopfield.Unit, b.Height);
                for (int i = 0; i < _hopfield.Height + 1; i++) // rows
                    g.DrawLine(Pens.Gray, 0, i * _hopfield.Unit, b.Width, i * _hopfield.Unit);
            }
            picHopfieldValues.Image = b;

        }

        private void btnClearHopfield_Click(object sender, EventArgs e)
        {
            for (int i = 0; i < _hopfield.Height; i++)
                for (int j = 0; j < _hopfield.Width; j++)
                    _hopImage[i * _hopfield.Width + j] = 0;
            RedrawHopfieldImage();
        }

        private void btnTrainHopfield_Click(object sender, EventArgs e)
        {
            _hopfield.Train(_hopImage);
        }

        private void btnClassifyHopfield_Click(object sender, EventArgs e)
        {
            _hopImage = (from x in _hopfield.Classify(_hopImage) select x).ToList<double>();
            RedrawHopfieldImage();
        }

        private void comboHopfield_SelectedIndexChanged(object sender, EventArgs e)
        {
            _hopImage = Hopfield.Symbols[comboHopfield.Text[0]].ToList<double>();
            RedrawHopfieldImage();
        }
    }
}
