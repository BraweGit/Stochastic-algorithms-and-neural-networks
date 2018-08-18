namespace NAVY
{
    partial class Form1
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea7 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Legend legend7 = new System.Windows.Forms.DataVisualization.Charting.Legend();
            System.Windows.Forms.DataVisualization.Charting.Series series7 = new System.Windows.Forms.DataVisualization.Charting.Series();
            this.button1 = new System.Windows.Forms.Button();
            this.tabControl = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.annPictureBox = new System.Windows.Forms.PictureBox();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.label4 = new System.Windows.Forms.Label();
            this.numInputValue = new System.Windows.Forms.NumericUpDown();
            this.button4 = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            this.comboInputs = new System.Windows.Forms.ComboBox();
            this.button3 = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.perceptronPictureBox = new System.Windows.Forms.PictureBox();
            this.tabPage3 = new System.Windows.Forms.TabPage();
            this.errorChart = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.removeLayerIndex = new System.Windows.Forms.NumericUpDown();
            this.label2 = new System.Windows.Forms.Label();
            this.newLayerNeurons = new System.Windows.Forms.NumericUpDown();
            this.label1 = new System.Windows.Forms.Label();
            this.textNeuralOutput = new System.Windows.Forms.TextBox();
            this.textNeuralExpected = new System.Windows.Forms.TextBox();
            this.textNeuralInput = new System.Windows.Forms.TextBox();
            this.btnNoAugment = new System.Windows.Forms.Button();
            this.btnNeuronDefault = new System.Windows.Forms.Button();
            this.btnNeuronRandom = new System.Windows.Forms.Button();
            this.btnSynapsesNone = new System.Windows.Forms.Button();
            this.btnSynapsesRandom = new System.Windows.Forms.Button();
            this.btnRemoveLayer = new System.Windows.Forms.Button();
            this.btnAddLayer = new System.Windows.Forms.Button();
            this.dataGridNeurons = new System.Windows.Forms.DataGridView();
            this.clmnNeuron = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.clmnLearningRate = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.clmnBias = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.textBoxSynapses = new System.Windows.Forms.TextBox();
            this.toolStripMenu = new System.Windows.Forms.ToolStrip();
            this.toolStripButton1 = new System.Windows.Forms.ToolStripButton();
            this.labelHiddenLayers = new System.Windows.Forms.ToolStripLabel();
            this.toolStripButton2 = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.toolStripButton3 = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.toolStripComboBoxLayer = new System.Windows.Forms.ToolStripComboBox();
            this.btnAddNeuron = new System.Windows.Forms.ToolStripButton();
            this.labelNeuron = new System.Windows.Forms.ToolStripLabel();
            this.btnRemoveNeuron = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator3 = new System.Windows.Forms.ToolStripSeparator();
            this.comboTrainType = new System.Windows.Forms.ToolStripComboBox();
            this.toolStripSeparator4 = new System.Windows.Forms.ToolStripSeparator();
            this.btnTrain = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator5 = new System.Windows.Forms.ToolStripSeparator();
            this.btnTrainingSet = new System.Windows.Forms.ToolStripButton();
            this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.txtMinError = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.numEpochs = new System.Windows.Forms.NumericUpDown();
            this.tabPage4 = new System.Windows.Forms.TabPage();
            this.picHopfieldValues = new System.Windows.Forms.PictureBox();
            this.comboHopfield = new System.Windows.Forms.ComboBox();
            this.btnClearHopfield = new System.Windows.Forms.Button();
            this.btnTrainHopfield = new System.Windows.Forms.Button();
            this.btnClassifyHopfield = new System.Windows.Forms.Button();
            this.tabControl.SuspendLayout();
            this.tabPage1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.annPictureBox)).BeginInit();
            this.tabPage2.SuspendLayout();
            this.groupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numInputValue)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.perceptronPictureBox)).BeginInit();
            this.tabPage3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.errorChart)).BeginInit();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.removeLayerIndex)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.newLayerNeurons)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridNeurons)).BeginInit();
            this.toolStripMenu.SuspendLayout();
            this.groupBox3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numEpochs)).BeginInit();
            this.tabPage4.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picHopfieldValues)).BeginInit();
            this.SuspendLayout();
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(898, 172);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(125, 28);
            this.button1.TabIndex = 0;
            this.button1.Text = "Show";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.btnAnnShow_Click);
            // 
            // tabControl
            // 
            this.tabControl.Controls.Add(this.tabPage1);
            this.tabControl.Controls.Add(this.tabPage2);
            this.tabControl.Controls.Add(this.tabPage3);
            this.tabControl.Controls.Add(this.tabPage4);
            this.tabControl.Location = new System.Drawing.Point(0, 163);
            this.tabControl.Name = "tabControl";
            this.tabControl.SelectedIndex = 0;
            this.tabControl.Size = new System.Drawing.Size(1137, 453);
            this.tabControl.TabIndex = 1;
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.annPictureBox);
            this.tabPage1.Location = new System.Drawing.Point(4, 22);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(1129, 427);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "Neural Network";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // annPictureBox
            // 
            this.annPictureBox.Dock = System.Windows.Forms.DockStyle.Fill;
            this.annPictureBox.Location = new System.Drawing.Point(3, 3);
            this.annPictureBox.Name = "annPictureBox";
            this.annPictureBox.Size = new System.Drawing.Size(1123, 421);
            this.annPictureBox.SizeMode = System.Windows.Forms.PictureBoxSizeMode.CenterImage;
            this.annPictureBox.TabIndex = 0;
            this.annPictureBox.TabStop = false;
            // 
            // tabPage2
            // 
            this.tabPage2.Controls.Add(this.groupBox2);
            this.tabPage2.Controls.Add(this.perceptronPictureBox);
            this.tabPage2.Location = new System.Drawing.Point(4, 22);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage2.Size = new System.Drawing.Size(1129, 427);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "Perceptron";
            this.tabPage2.UseVisualStyleBackColor = true;
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.label4);
            this.groupBox2.Controls.Add(this.numInputValue);
            this.groupBox2.Controls.Add(this.button4);
            this.groupBox2.Controls.Add(this.label3);
            this.groupBox2.Controls.Add(this.comboInputs);
            this.groupBox2.Controls.Add(this.button3);
            this.groupBox2.Controls.Add(this.button2);
            this.groupBox2.Location = new System.Drawing.Point(923, 6);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(200, 490);
            this.groupBox2.TabIndex = 1;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Parameters";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(116, 76);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(34, 13);
            this.label4.TabIndex = 8;
            this.label4.Text = "Value";
            // 
            // numInputValue
            // 
            this.numInputValue.Location = new System.Drawing.Point(119, 92);
            this.numInputValue.Name = "numInputValue";
            this.numInputValue.Size = new System.Drawing.Size(73, 20);
            this.numInputValue.TabIndex = 7;
            // 
            // button4
            // 
            this.button4.Location = new System.Drawing.Point(119, 119);
            this.button4.Name = "button4";
            this.button4.Size = new System.Drawing.Size(75, 23);
            this.button4.TabIndex = 6;
            this.button4.Text = "Add";
            this.button4.UseVisualStyleBackColor = true;
            this.button4.Click += new System.EventHandler(this.button4_Click);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(6, 76);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(31, 13);
            this.label3.TabIndex = 2;
            this.label3.Text = "Input";
            // 
            // comboInputs
            // 
            this.comboInputs.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboInputs.FormattingEnabled = true;
            this.comboInputs.Location = new System.Drawing.Point(6, 92);
            this.comboInputs.Name = "comboInputs";
            this.comboInputs.Size = new System.Drawing.Size(98, 21);
            this.comboInputs.TabIndex = 4;
            this.comboInputs.SelectedIndexChanged += new System.EventHandler(this.comboInputs_SelectedIndexChanged);
            // 
            // button3
            // 
            this.button3.Location = new System.Drawing.Point(119, 19);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(75, 23);
            this.button3.TabIndex = 3;
            this.button3.Text = "Train";
            this.button3.UseVisualStyleBackColor = true;
            this.button3.Click += new System.EventHandler(this.button3_Click);
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(6, 19);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(98, 23);
            this.button2.TabIndex = 2;
            this.button2.Text = "File";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // perceptronPictureBox
            // 
            this.perceptronPictureBox.Dock = System.Windows.Forms.DockStyle.Left;
            this.perceptronPictureBox.Location = new System.Drawing.Point(3, 3);
            this.perceptronPictureBox.Name = "perceptronPictureBox";
            this.perceptronPictureBox.Size = new System.Drawing.Size(914, 421);
            this.perceptronPictureBox.SizeMode = System.Windows.Forms.PictureBoxSizeMode.CenterImage;
            this.perceptronPictureBox.TabIndex = 0;
            this.perceptronPictureBox.TabStop = false;
            // 
            // tabPage3
            // 
            this.tabPage3.Controls.Add(this.errorChart);
            this.tabPage3.Location = new System.Drawing.Point(4, 22);
            this.tabPage3.Name = "tabPage3";
            this.tabPage3.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage3.Size = new System.Drawing.Size(1129, 427);
            this.tabPage3.TabIndex = 2;
            this.tabPage3.Text = "Error Progress";
            this.tabPage3.UseVisualStyleBackColor = true;
            // 
            // errorChart
            // 
            chartArea7.Name = "ChartArea1";
            this.errorChart.ChartAreas.Add(chartArea7);
            this.errorChart.Dock = System.Windows.Forms.DockStyle.Fill;
            legend7.Name = "Legend1";
            this.errorChart.Legends.Add(legend7);
            this.errorChart.Location = new System.Drawing.Point(3, 3);
            this.errorChart.Name = "errorChart";
            series7.ChartArea = "ChartArea1";
            series7.Legend = "Legend1";
            series7.Name = "Series1";
            this.errorChart.Series.Add(series7);
            this.errorChart.Size = new System.Drawing.Size(1123, 421);
            this.errorChart.TabIndex = 0;
            this.errorChart.Text = "chart1";
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.removeLayerIndex);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.newLayerNeurons);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.textNeuralOutput);
            this.groupBox1.Controls.Add(this.textNeuralExpected);
            this.groupBox1.Controls.Add(this.textNeuralInput);
            this.groupBox1.Controls.Add(this.btnNoAugment);
            this.groupBox1.Controls.Add(this.btnNeuronDefault);
            this.groupBox1.Controls.Add(this.btnNeuronRandom);
            this.groupBox1.Controls.Add(this.btnSynapsesNone);
            this.groupBox1.Controls.Add(this.btnSynapsesRandom);
            this.groupBox1.Controls.Add(this.btnRemoveLayer);
            this.groupBox1.Controls.Add(this.btnAddLayer);
            this.groupBox1.Controls.Add(this.button1);
            this.groupBox1.Controls.Add(this.dataGridNeurons);
            this.groupBox1.Controls.Add(this.textBoxSynapses);
            this.groupBox1.Location = new System.Drawing.Point(1031, 41);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(23, 23);
            this.groupBox1.TabIndex = 2;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Controls";
            this.groupBox1.Visible = false;
            // 
            // removeLayerIndex
            // 
            this.removeLayerIndex.Location = new System.Drawing.Point(112, 47);
            this.removeLayerIndex.Name = "removeLayerIndex";
            this.removeLayerIndex.Size = new System.Drawing.Size(107, 20);
            this.removeLayerIndex.TabIndex = 18;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(6, 47);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(36, 13);
            this.label2.TabIndex = 17;
            this.label2.Text = "Layer:";
            // 
            // newLayerNeurons
            // 
            this.newLayerNeurons.Location = new System.Drawing.Point(112, 20);
            this.newLayerNeurons.Name = "newLayerNeurons";
            this.newLayerNeurons.Size = new System.Drawing.Size(107, 20);
            this.newLayerNeurons.TabIndex = 16;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(6, 19);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(77, 13);
            this.label1.TabIndex = 15;
            this.label1.Text = "Layer neurons:";
            // 
            // textNeuralOutput
            // 
            this.textNeuralOutput.Location = new System.Drawing.Point(898, 19);
            this.textNeuralOutput.Multiline = true;
            this.textNeuralOutput.Name = "textNeuralOutput";
            this.textNeuralOutput.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.textNeuralOutput.Size = new System.Drawing.Size(125, 146);
            this.textNeuralOutput.TabIndex = 13;
            // 
            // textNeuralExpected
            // 
            this.textNeuralExpected.Location = new System.Drawing.Point(774, 19);
            this.textNeuralExpected.Multiline = true;
            this.textNeuralExpected.Name = "textNeuralExpected";
            this.textNeuralExpected.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.textNeuralExpected.Size = new System.Drawing.Size(118, 146);
            this.textNeuralExpected.TabIndex = 12;
            // 
            // textNeuralInput
            // 
            this.textNeuralInput.Location = new System.Drawing.Point(657, 20);
            this.textNeuralInput.Multiline = true;
            this.textNeuralInput.Name = "textNeuralInput";
            this.textNeuralInput.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.textNeuralInput.Size = new System.Drawing.Size(111, 145);
            this.textNeuralInput.TabIndex = 11;
            // 
            // btnNoAugment
            // 
            this.btnNoAugment.Location = new System.Drawing.Point(373, 171);
            this.btnNoAugment.Name = "btnNoAugment";
            this.btnNoAugment.Size = new System.Drawing.Size(67, 28);
            this.btnNoAugment.TabIndex = 10;
            this.btnNoAugment.Text = "No BIAS";
            this.btnNoAugment.UseVisualStyleBackColor = true;
            // 
            // btnNeuronDefault
            // 
            this.btnNeuronDefault.Location = new System.Drawing.Point(297, 171);
            this.btnNeuronDefault.Name = "btnNeuronDefault";
            this.btnNeuronDefault.Size = new System.Drawing.Size(59, 29);
            this.btnNeuronDefault.TabIndex = 9;
            this.btnNeuronDefault.Text = "Default";
            this.btnNeuronDefault.UseVisualStyleBackColor = true;
            // 
            // btnNeuronRandom
            // 
            this.btnNeuronRandom.Location = new System.Drawing.Point(231, 172);
            this.btnNeuronRandom.Name = "btnNeuronRandom";
            this.btnNeuronRandom.Size = new System.Drawing.Size(59, 28);
            this.btnNeuronRandom.TabIndex = 8;
            this.btnNeuronRandom.Text = "Random";
            this.btnNeuronRandom.UseVisualStyleBackColor = true;
            this.btnNeuronRandom.Click += new System.EventHandler(this.btnNeuronRandom_Click);
            // 
            // btnSynapsesNone
            // 
            this.btnSynapsesNone.Location = new System.Drawing.Point(551, 172);
            this.btnSynapsesNone.Name = "btnSynapsesNone";
            this.btnSynapsesNone.Size = new System.Drawing.Size(99, 28);
            this.btnSynapsesNone.TabIndex = 7;
            this.btnSynapsesNone.Text = "None";
            this.btnSynapsesNone.UseVisualStyleBackColor = true;
            // 
            // btnSynapsesRandom
            // 
            this.btnSynapsesRandom.Location = new System.Drawing.Point(446, 172);
            this.btnSynapsesRandom.Name = "btnSynapsesRandom";
            this.btnSynapsesRandom.Size = new System.Drawing.Size(99, 28);
            this.btnSynapsesRandom.TabIndex = 6;
            this.btnSynapsesRandom.Text = "Random";
            this.btnSynapsesRandom.UseVisualStyleBackColor = true;
            // 
            // btnRemoveLayer
            // 
            this.btnRemoveLayer.Location = new System.Drawing.Point(112, 171);
            this.btnRemoveLayer.Name = "btnRemoveLayer";
            this.btnRemoveLayer.Size = new System.Drawing.Size(113, 29);
            this.btnRemoveLayer.TabIndex = 5;
            this.btnRemoveLayer.Text = "Remove Layer";
            this.btnRemoveLayer.UseVisualStyleBackColor = true;
            this.btnRemoveLayer.Click += new System.EventHandler(this.btnRemoveLayer_Click);
            // 
            // btnAddLayer
            // 
            this.btnAddLayer.Location = new System.Drawing.Point(6, 171);
            this.btnAddLayer.Name = "btnAddLayer";
            this.btnAddLayer.Size = new System.Drawing.Size(100, 29);
            this.btnAddLayer.TabIndex = 4;
            this.btnAddLayer.Text = "Add Layer";
            this.btnAddLayer.UseVisualStyleBackColor = true;
            this.btnAddLayer.Click += new System.EventHandler(this.btnAddLayer_Click);
            // 
            // dataGridNeurons
            // 
            this.dataGridNeurons.BackgroundColor = System.Drawing.Color.White;
            this.dataGridNeurons.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridNeurons.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.clmnNeuron,
            this.clmnLearningRate,
            this.clmnBias});
            this.dataGridNeurons.Location = new System.Drawing.Point(231, 18);
            this.dataGridNeurons.Name = "dataGridNeurons";
            this.dataGridNeurons.RowHeadersVisible = false;
            this.dataGridNeurons.Size = new System.Drawing.Size(209, 146);
            this.dataGridNeurons.TabIndex = 2;
            this.dataGridNeurons.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView1_CellContentClick);
            // 
            // clmnNeuron
            // 
            this.clmnNeuron.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.clmnNeuron.HeaderText = "Neuron";
            this.clmnNeuron.MinimumWidth = 55;
            this.clmnNeuron.Name = "clmnNeuron";
            // 
            // clmnLearningRate
            // 
            this.clmnLearningRate.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.clmnLearningRate.HeaderText = "Learn Rate";
            this.clmnLearningRate.MinimumWidth = 45;
            this.clmnLearningRate.Name = "clmnLearningRate";
            // 
            // clmnBias
            // 
            this.clmnBias.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.clmnBias.HeaderText = "Bias";
            this.clmnBias.MinimumWidth = 65;
            this.clmnBias.Name = "clmnBias";
            // 
            // textBoxSynapses
            // 
            this.textBoxSynapses.Location = new System.Drawing.Point(446, 19);
            this.textBoxSynapses.Multiline = true;
            this.textBoxSynapses.Name = "textBoxSynapses";
            this.textBoxSynapses.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.textBoxSynapses.Size = new System.Drawing.Size(204, 146);
            this.textBoxSynapses.TabIndex = 3;
            this.textBoxSynapses.TextChanged += new System.EventHandler(this.textBox1_TextChanged);
            // 
            // toolStripMenu
            // 
            this.toolStripMenu.ImageScalingSize = new System.Drawing.Size(25, 25);
            this.toolStripMenu.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripButton1,
            this.labelHiddenLayers,
            this.toolStripButton2,
            this.toolStripSeparator1,
            this.toolStripButton3,
            this.toolStripSeparator2,
            this.toolStripComboBoxLayer,
            this.btnAddNeuron,
            this.labelNeuron,
            this.btnRemoveNeuron,
            this.toolStripSeparator3,
            this.comboTrainType,
            this.toolStripSeparator4,
            this.btnTrain,
            this.toolStripSeparator5,
            this.btnTrainingSet});
            this.toolStripMenu.Location = new System.Drawing.Point(0, 0);
            this.toolStripMenu.Name = "toolStripMenu";
            this.toolStripMenu.Size = new System.Drawing.Size(1131, 32);
            this.toolStripMenu.TabIndex = 3;
            this.toolStripMenu.Text = "toolStripMenu";
            // 
            // toolStripButton1
            // 
            this.toolStripButton1.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolStripButton1.Image = global::NAVY.Properties.Resources.plusIcon;
            this.toolStripButton1.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButton1.Name = "toolStripButton1";
            this.toolStripButton1.Size = new System.Drawing.Size(29, 29);
            this.toolStripButton1.Click += new System.EventHandler(this.toolStripButton1_Click);
            // 
            // labelHiddenLayers
            // 
            this.labelHiddenLayers.Name = "labelHiddenLayers";
            this.labelHiddenLayers.Size = new System.Drawing.Size(0, 29);
            // 
            // toolStripButton2
            // 
            this.toolStripButton2.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolStripButton2.Image = global::NAVY.Properties.Resources.minusIcon;
            this.toolStripButton2.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButton2.Name = "toolStripButton2";
            this.toolStripButton2.Size = new System.Drawing.Size(29, 29);
            this.toolStripButton2.Text = "toolStripButton2";
            this.toolStripButton2.Click += new System.EventHandler(this.toolStripButton2_Click);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(6, 32);
            // 
            // toolStripButton3
            // 
            this.toolStripButton3.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolStripButton3.Image = global::NAVY.Properties.Resources.showIcon;
            this.toolStripButton3.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButton3.Name = "toolStripButton3";
            this.toolStripButton3.Size = new System.Drawing.Size(29, 29);
            this.toolStripButton3.Text = "toolStripButton3";
            this.toolStripButton3.Click += new System.EventHandler(this.toolStripButton3_Click);
            // 
            // toolStripSeparator2
            // 
            this.toolStripSeparator2.Name = "toolStripSeparator2";
            this.toolStripSeparator2.Size = new System.Drawing.Size(6, 32);
            // 
            // toolStripComboBoxLayer
            // 
            this.toolStripComboBoxLayer.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.toolStripComboBoxLayer.Name = "toolStripComboBoxLayer";
            this.toolStripComboBoxLayer.Size = new System.Drawing.Size(121, 32);
            // 
            // btnAddNeuron
            // 
            this.btnAddNeuron.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.btnAddNeuron.Image = global::NAVY.Properties.Resources.plusIcon;
            this.btnAddNeuron.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnAddNeuron.Name = "btnAddNeuron";
            this.btnAddNeuron.Size = new System.Drawing.Size(29, 29);
            this.btnAddNeuron.Text = "toolStripButton4";
            this.btnAddNeuron.Click += new System.EventHandler(this.btnAddNeuron_Click);
            // 
            // labelNeuron
            // 
            this.labelNeuron.Name = "labelNeuron";
            this.labelNeuron.Size = new System.Drawing.Size(55, 29);
            this.labelNeuron.Text = "NEURON";
            // 
            // btnRemoveNeuron
            // 
            this.btnRemoveNeuron.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.btnRemoveNeuron.Image = global::NAVY.Properties.Resources.minusIcon;
            this.btnRemoveNeuron.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnRemoveNeuron.Name = "btnRemoveNeuron";
            this.btnRemoveNeuron.Size = new System.Drawing.Size(29, 29);
            this.btnRemoveNeuron.Text = "toolStripButton5";
            this.btnRemoveNeuron.Click += new System.EventHandler(this.btnRemoveNeuron_Click);
            // 
            // toolStripSeparator3
            // 
            this.toolStripSeparator3.Name = "toolStripSeparator3";
            this.toolStripSeparator3.Size = new System.Drawing.Size(6, 32);
            // 
            // comboTrainType
            // 
            this.comboTrainType.Name = "comboTrainType";
            this.comboTrainType.Size = new System.Drawing.Size(121, 32);
            this.comboTrainType.SelectedIndexChanged += new System.EventHandler(this.comboTrainType_SelectedIndexChanged);
            // 
            // toolStripSeparator4
            // 
            this.toolStripSeparator4.Name = "toolStripSeparator4";
            this.toolStripSeparator4.Size = new System.Drawing.Size(6, 32);
            // 
            // btnTrain
            // 
            this.btnTrain.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.btnTrain.Image = global::NAVY.Properties.Resources.Exercise_48;
            this.btnTrain.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnTrain.Name = "btnTrain";
            this.btnTrain.Size = new System.Drawing.Size(29, 29);
            this.btnTrain.Text = "Train";
            this.btnTrain.Click += new System.EventHandler(this.btnTrain_Click);
            // 
            // toolStripSeparator5
            // 
            this.toolStripSeparator5.Name = "toolStripSeparator5";
            this.toolStripSeparator5.Size = new System.Drawing.Size(6, 32);
            // 
            // btnTrainingSet
            // 
            this.btnTrainingSet.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.btnTrainingSet.Image = global::NAVY.Properties.Resources.File_Filled_50;
            this.btnTrainingSet.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnTrainingSet.Name = "btnTrainingSet";
            this.btnTrainingSet.Size = new System.Drawing.Size(29, 29);
            this.btnTrainingSet.Text = "Training Set";
            this.btnTrainingSet.Click += new System.EventHandler(this.btnTrainingSet_Click);
            // 
            // openFileDialog1
            // 
            this.openFileDialog1.FileName = "openFileDialog1";
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.txtMinError);
            this.groupBox3.Controls.Add(this.label6);
            this.groupBox3.Controls.Add(this.label5);
            this.groupBox3.Controls.Add(this.numEpochs);
            this.groupBox3.Location = new System.Drawing.Point(12, 41);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(1107, 116);
            this.groupBox3.TabIndex = 5;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Parameters";
            // 
            // txtMinError
            // 
            this.txtMinError.Location = new System.Drawing.Point(153, 47);
            this.txtMinError.Name = "txtMinError";
            this.txtMinError.Size = new System.Drawing.Size(59, 20);
            this.txtMinError.TabIndex = 3;
            this.txtMinError.Text = "0";
            this.txtMinError.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.txtMinError.Leave += new System.EventHandler(this.txtMinError_Leave);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(150, 22);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(29, 13);
            this.label6.TabIndex = 2;
            this.label6.Text = "Error";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(6, 22);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(43, 13);
            this.label5.TabIndex = 1;
            this.label5.Text = "Epochs";
            // 
            // numEpochs
            // 
            this.numEpochs.Location = new System.Drawing.Point(9, 47);
            this.numEpochs.Maximum = new decimal(new int[] {
            1000000000,
            0,
            0,
            0});
            this.numEpochs.Name = "numEpochs";
            this.numEpochs.Size = new System.Drawing.Size(120, 20);
            this.numEpochs.TabIndex = 0;
            this.numEpochs.Value = new decimal(new int[] {
            2000,
            0,
            0,
            0});
            this.numEpochs.ValueChanged += new System.EventHandler(this.numEpochs_ValueChanged);
            // 
            // tabPage4
            // 
            this.tabPage4.Controls.Add(this.btnClassifyHopfield);
            this.tabPage4.Controls.Add(this.btnTrainHopfield);
            this.tabPage4.Controls.Add(this.btnClearHopfield);
            this.tabPage4.Controls.Add(this.comboHopfield);
            this.tabPage4.Controls.Add(this.picHopfieldValues);
            this.tabPage4.Location = new System.Drawing.Point(4, 22);
            this.tabPage4.Name = "tabPage4";
            this.tabPage4.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage4.Size = new System.Drawing.Size(1129, 427);
            this.tabPage4.TabIndex = 3;
            this.tabPage4.Text = "Hopfield";
            this.tabPage4.UseVisualStyleBackColor = true;
            // 
            // picHopfieldValues
            // 
            this.picHopfieldValues.Location = new System.Drawing.Point(3, 6);
            this.picHopfieldValues.Name = "picHopfieldValues";
            this.picHopfieldValues.Size = new System.Drawing.Size(251, 351);
            this.picHopfieldValues.TabIndex = 0;
            this.picHopfieldValues.TabStop = false;
            this.picHopfieldValues.Click += new System.EventHandler(this.picHopfieldValues_Click);
            // 
            // comboHopfield
            // 
            this.comboHopfield.FormattingEnabled = true;
            this.comboHopfield.Location = new System.Drawing.Point(6, 371);
            this.comboHopfield.Name = "comboHopfield";
            this.comboHopfield.Size = new System.Drawing.Size(121, 21);
            this.comboHopfield.TabIndex = 1;
            this.comboHopfield.SelectedIndexChanged += new System.EventHandler(this.comboHopfield_SelectedIndexChanged);
            // 
            // btnClearHopfield
            // 
            this.btnClearHopfield.Location = new System.Drawing.Point(137, 369);
            this.btnClearHopfield.Name = "btnClearHopfield";
            this.btnClearHopfield.Size = new System.Drawing.Size(50, 23);
            this.btnClearHopfield.TabIndex = 3;
            this.btnClearHopfield.Text = "Clear";
            this.btnClearHopfield.UseVisualStyleBackColor = true;
            this.btnClearHopfield.Click += new System.EventHandler(this.btnClearHopfield_Click);
            // 
            // btnTrainHopfield
            // 
            this.btnTrainHopfield.Location = new System.Drawing.Point(193, 369);
            this.btnTrainHopfield.Name = "btnTrainHopfield";
            this.btnTrainHopfield.Size = new System.Drawing.Size(61, 23);
            this.btnTrainHopfield.TabIndex = 4;
            this.btnTrainHopfield.Text = "Train";
            this.btnTrainHopfield.UseVisualStyleBackColor = true;
            this.btnTrainHopfield.Click += new System.EventHandler(this.btnTrainHopfield_Click);
            // 
            // btnClassifyHopfield
            // 
            this.btnClassifyHopfield.Location = new System.Drawing.Point(137, 398);
            this.btnClassifyHopfield.Name = "btnClassifyHopfield";
            this.btnClassifyHopfield.Size = new System.Drawing.Size(117, 23);
            this.btnClassifyHopfield.TabIndex = 5;
            this.btnClassifyHopfield.Text = "Classify";
            this.btnClassifyHopfield.UseVisualStyleBackColor = true;
            this.btnClassifyHopfield.Click += new System.EventHandler(this.btnClassifyHopfield_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1131, 613);
            this.Controls.Add(this.groupBox3);
            this.Controls.Add(this.toolStripMenu);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.tabControl);
            this.Name = "Form1";
            this.Text = "NAVY";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.tabControl.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.annPictureBox)).EndInit();
            this.tabPage2.ResumeLayout(false);
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numInputValue)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.perceptronPictureBox)).EndInit();
            this.tabPage3.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.errorChart)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.removeLayerIndex)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.newLayerNeurons)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridNeurons)).EndInit();
            this.toolStripMenu.ResumeLayout(false);
            this.toolStripMenu.PerformLayout();
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numEpochs)).EndInit();
            this.tabPage4.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.picHopfieldValues)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.TabControl tabControl;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.PictureBox annPictureBox;
        private System.Windows.Forms.TabPage tabPage2;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.DataGridView dataGridNeurons;
        private System.Windows.Forms.TextBox textBoxSynapses;
        private System.Windows.Forms.Button btnRemoveLayer;
        private System.Windows.Forms.Button btnAddLayer;
        private System.Windows.Forms.Button btnNoAugment;
        private System.Windows.Forms.Button btnNeuronDefault;
        private System.Windows.Forms.Button btnNeuronRandom;
        private System.Windows.Forms.Button btnSynapsesNone;
        private System.Windows.Forms.Button btnSynapsesRandom;
        private System.Windows.Forms.TextBox textNeuralOutput;
        private System.Windows.Forms.TextBox textNeuralExpected;
        private System.Windows.Forms.TextBox textNeuralInput;
        private System.Windows.Forms.DataGridViewTextBoxColumn clmnNeuron;
        private System.Windows.Forms.DataGridViewTextBoxColumn clmnLearningRate;
        private System.Windows.Forms.DataGridViewTextBoxColumn clmnBias;
        private System.Windows.Forms.NumericUpDown removeLayerIndex;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.NumericUpDown newLayerNeurons;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ToolStrip toolStripMenu;
        private System.Windows.Forms.ToolStripButton toolStripButton1;
        private System.Windows.Forms.ToolStripLabel labelHiddenLayers;
        private System.Windows.Forms.ToolStripButton toolStripButton2;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripButton toolStripButton3;
        private System.Windows.Forms.ToolStripComboBox toolStripComboBoxLayer;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator2;
        private System.Windows.Forms.ToolStripButton btnAddNeuron;
        private System.Windows.Forms.ToolStripLabel labelNeuron;
        private System.Windows.Forms.ToolStripButton btnRemoveNeuron;
        private System.Windows.Forms.PictureBox perceptronPictureBox;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.OpenFileDialog openFileDialog1;
        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.ComboBox comboInputs;
        private System.Windows.Forms.Button button4;
        private System.Windows.Forms.NumericUpDown numInputValue;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator3;
        private System.Windows.Forms.ToolStripComboBox comboTrainType;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator4;
        private System.Windows.Forms.ToolStripButton btnTrain;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.TextBox txtMinError;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.NumericUpDown numEpochs;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator5;
        private System.Windows.Forms.ToolStripButton btnTrainingSet;
        private System.Windows.Forms.TabPage tabPage3;
        private System.Windows.Forms.DataVisualization.Charting.Chart errorChart;
        private System.Windows.Forms.TabPage tabPage4;
        private System.Windows.Forms.PictureBox picHopfieldValues;
        private System.Windows.Forms.Button btnClassifyHopfield;
        private System.Windows.Forms.Button btnTrainHopfield;
        private System.Windows.Forms.Button btnClearHopfield;
        private System.Windows.Forms.ComboBox comboHopfield;
    }
}

