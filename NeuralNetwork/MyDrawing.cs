using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace NeuralNetwork
{
    public class MyDrawing
    {
        private int PerceptronWidth { get; set; }
        private int PerceptronHeight { get; set; }

        public void DrawPerceptron(Perceptron perceptron, PictureBox picBox)
        {
            PerceptronHeight = 100;
            PerceptronWidth = 100;

            var inputCount = perceptron.TrainingSet[0].Item1.Length;
            var inputHeight = picBox.Height / inputCount;
            var inputSpace = 50;

            var pic = new Bitmap(picBox.Height, picBox.Width);
            var g = Graphics.FromImage(pic);
            var penNeuron = new Pen(Color.Black, 2);
            var penInput = new Pen(Color.Black, 1);
            var penRect = new Pen(Color.Black, 1);
            var brush = Brushes.Orange;

            g.InterpolationMode = System.Drawing.Drawing2D.InterpolationMode.HighQualityBicubic;
            g.TextRenderingHint = System.Drawing.Text.TextRenderingHint.AntiAliasGridFit;
            g.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.AntiAlias;

            var centerX = (pic.Width / 2) - (PerceptronWidth / 2);
            var centerY = (pic.Height / 2) - (PerceptronHeight / 2);
            var picCenterX = (pic.Width / 2);
            var picCenterY = (pic.Height / 2);
            g.DrawEllipse(penNeuron, centerX, centerY, PerceptronWidth, PerceptronHeight);

            var centerPoint = new PointF(picCenterX, picCenterY);


            //var connectionPoint = new PointF(PerceptronWidth / 10, (pic.Height / 3));
            //var intersectPoint = ClosestIntersection(picCenterX, picCenterY, PerceptronWidth/2, connectionPoint, centerPoint);
            //g.DrawLine(pen, connectionPoint, intersectPoint);
            //connectionPoint = new PointF(PerceptronWidth / 10, pic.Height / 3);
            //intersectPoint = LineIntersectEllipse(centerPoint, connectionPoint, PerceptronHeight, PerceptronWidth);

            // X = 0, Y = 461
            // X = 0; Y = 661
            var linePoints = (inputCount - 1) * inputSpace;
            var inputX = 50;
            var inputY = picCenterY - (linePoints / 2);

            var pointA = new PointF();
            var pointB = new PointF();

            #region Inputs
            for (int i = 0; i < perceptron.TrainingSet.Count; i++)
            {
                for (int j = 0; j < perceptron.TrainingSet[i].Item1.Length; j++)
                {
                    pointA = new PointF(inputX, inputY + (inputSpace * j));
                    pointB = ClosestIntersection(picCenterX, picCenterY, PerceptronWidth / 2, pointA, centerPoint);
                    //var rect = new RectangleF(inputX -50, inputY + (inputSpace * j) - (inputSpace / 4), 50, 25);
                    //g.DrawString("Input " + (j+1), new Font("Arial", 10, FontStyle.Regular), Brushes.Black, rect);
                    //g.DrawRectangle(penRect, Rectangle.Round(rect));
                    g.DrawEllipse(penNeuron, inputX - inputSpace, inputY + (inputSpace * j) - (inputSpace / 2), 50, 50);
                    g.DrawString("Input " + (j + 1), new Font("Arial", 8, FontStyle.Regular), Brushes.Black, inputX - 40,
                        inputY + (inputSpace * j) - (inputSpace / 5));
                    g.DrawLine(penInput, pointA, pointB);
                    g.DrawString("Weight " + (j + 1) + ": " + Math.Round(perceptron.PerceptronNeuron.InputSynapses[j].Weight, 2), new Font("Arial", 8, FontStyle.Regular), Brushes.Black, inputX + (inputSpace / 5), inputY + (inputSpace * j) + (inputSpace / 5));
                    //g.DrawString(value.ToString("0.00"), new Font("Arial", 7), Brushes.Green, X + 5, Y + 10);

                }
            }
            #endregion

            #region Output

            pointA = new PointF(picCenterX + (PerceptronWidth/2), picCenterY);
            pointB = new PointF(picCenterX + (PerceptronWidth/2) + 75, picCenterY);
            g.DrawLine(penInput, pointA, pointB);
            g.DrawEllipse(penNeuron, picCenterX + (PerceptronWidth/2) + 75, picCenterY - (50/2), 50, 50);
            g.DrawString("Out: " + perceptron.PerceptronNeuron.Output, new Font("Arial", 8, FontStyle.Regular), Brushes.Black, picCenterX + (PerceptronWidth / 2) + 85,
                        picCenterY - (50/6));

            #endregion

            //var pointA = new PointF(inputX, inputY);
            //var pointB = new PointF(inputX, inputY + inputSpace);
            //g.DrawLine(pen, pointA, pointB);
            //pointA = new PointF(25, picCenterY - (PerceptronWidth / 2));
            //pointB = new PointF(25, picCenterY + (PerceptronWidth / 2));
            //g.DrawLine(pen, pointA, pointB);


            picBox.Image = pic;

        }

        public PointF ClosestIntersection(float cx, float cy, float radius,
                    PointF lineStart, PointF lineEnd)
        {
            PointF intersection1;
            PointF intersection2;
            int intersections = FindLineCircleIntersections(cx, cy, radius, lineStart, lineEnd, out intersection1, out intersection2);

            if (intersections == 1)
                return intersection1;//one intersection

            if (intersections == 2)
            {
                double dist1 = Distance(intersection1, lineStart);
                double dist2 = Distance(intersection2, lineStart);

                if (dist1 < dist2)
                    return intersection1;
                else
                    return intersection2;
            }

            return PointF.Empty;// no intersections at all
        }

        private double Distance(PointF p1, PointF p2)
        {
            return Math.Sqrt(Math.Pow(p2.X - p1.X, 2) + Math.Pow(p2.Y - p1.Y, 2));
        }

        // Find the points of intersection.
        private int FindLineCircleIntersections(float cx, float cy, float radius,
            PointF point1, PointF point2, out PointF intersection1, out PointF intersection2)
        {
            float dx, dy, A, B, C, det, t;

            dx = point2.X - point1.X;
            dy = point2.Y - point1.Y;

            A = dx * dx + dy * dy;
            B = 2 * (dx * (point1.X - cx) + dy * (point1.Y - cy));
            C = (point1.X - cx) * (point1.X - cx) + (point1.Y - cy) * (point1.Y - cy) - radius * radius;

            det = B * B - 4 * A * C;
            if ((A <= 0.0000001) || (det < 0))
            {
                // No real solutions.
                intersection1 = new PointF(float.NaN, float.NaN);
                intersection2 = new PointF(float.NaN, float.NaN);
                return 0;
            }
            else if (det == 0)
            {
                // One solution.
                t = -B / (2 * A);
                intersection1 = new PointF(point1.X + t * dx, point1.Y + t * dy);
                intersection2 = new PointF(float.NaN, float.NaN);
                return 1;
            }
            else
            {
                // Two solutions.
                t = (float)((-B + Math.Sqrt(det)) / (2 * A));
                intersection1 = new PointF(point1.X + t * dx, point1.Y + t * dy);
                t = (float)((-B - Math.Sqrt(det)) / (2 * A));
                intersection2 = new PointF(point1.X + t * dx, point1.Y + t * dy);
                return 2;
            }
        }

        public Bitmap ToBitmap()
        {

            //#region inputs
            //int inheight = inputs * nodeheight;
            //Point startpos = new Point(30, picheight / 2 - inheight / 2);
            //g.Clear(Color.Transparent);
            //for (int i = 0; i < inputs; i++)
            //{
            //    drawInputNode(g, startpos.X, startpos.Y + i * nodeheight, InputLayer.Neurons[i].Output);
            //    // STRING CHANGE
            //    g.DrawString(InputLayer.Neurons[i].Output.ToString("0.00"), new Font("Arial", 7), Brushes.Black, 5, startpos.Y + 10 + i * nodeheight);
            //}
            //#endregion

            //#region layers
            //for (int u = 0; u < layercount; u++)
            //{
            //    inheight = hiddenLayers[u].Neurons.Count * nodeheight;
            //    startpos = new Point(30 + nodewidth * (1 + u), picheight / 2 - inheight / 2);

            //    for (int i = 0; i < hiddenLayers[u].Neurons.Count; i++)
            //    {
            //        drawnode(g, startpos.X, startpos.Y + i * nodeheight, hiddenLayers[u].Neurons[i].Output);


            //        if (u == 0)
            //        {
            //            Point laststart = new Point(30, picheight / 2 - inputs * nodeheight / 2);
            //            int lastcount = inputs;
            //            connectnode(g, startpos.X, startpos.Y + i * nodeheight, lastcount, laststart);
            //        }
            //        else
            //        {
            //            Point laststart = new Point(30 + nodewidth * (1 + u - 1), picheight / 2 - hiddenLayers[u - 1].Neurons.Count * nodeheight / 2);
            //            int lastcount = hiddenLayers[u - 1].Neurons.Count;
            //            connectnode(g, startpos.X, startpos.Y + i * nodeheight, lastcount, laststart);
            //        }
            //    }
            //}
            //#endregion

            //#region end

            //Point endpos = new Point(30 + (layercount + 1) * nodewidth, picheight / 2 - outputs * nodeheight / 2);
            //for (int i = 0; i < outputs; i++)
            //{

            //    drawOutputNode(g, endpos.X, endpos.Y + i * nodeheight, OutputLayer.Neurons[i].Output);
            //    g.DrawString(OutputLayer.Neurons[i].Output.ToString("0.00"), new Font("Arial", 7), Brushes.Black, endpos.X + 35, endpos.Y + i * nodeheight + 10);

            //    if (layers == 0)
            //    {
            //        connectnode(g, endpos.X, endpos.Y + i * nodeheight, InputLayer.Neurons.Count(), new Point(30 + layercount * nodewidth, picheight / 2 - InputLayer.Neurons.Count() * nodeheight / 2));
            //    }
            //    else
            //    {
            //        connectnode(g, endpos.X, endpos.Y + i * nodeheight, hiddenLayers.Last().Neurons.Count, new Point(30 + layercount * nodewidth, picheight / 2 - hiddenLayers.Last().Neurons.Count * nodeheight / 2));
            //    }
            //}

            //#endregion


            //return pic;
            return null;
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
    }
}
