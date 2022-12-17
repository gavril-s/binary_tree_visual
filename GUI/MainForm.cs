using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Text;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GUI
{
    public partial class MainForm : Form
    {
        private BinaryTree.BinaryTree tree;

        public MainForm()
        {
            InitializeComponent();
            this.Resize += MainForm_Resize;
            addButton.Click += addButton_Click;
            removeButton.Click += removeButton_Click;
            tree = new BinaryTree.BinaryTree();
            drawTree();
        }

        private void drawTree()
        {
            List<int?> heap = tree.HeapStyle();

            Bitmap treeDrawing = new Bitmap(treePictureBox.Width, treePictureBox.Height);
            Graphics g = Graphics.FromImage(treeDrawing);

            g.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.AntiAlias;
            g.InterpolationMode = System.Drawing.Drawing2D.InterpolationMode.HighQualityBicubic;
            g.PixelOffsetMode = System.Drawing.Drawing2D.PixelOffsetMode.HighQuality;
            g.TextRenderingHint = TextRenderingHint.SingleBitPerPixelGridFit;

            StringFormat format = new StringFormat()
            {
                Alignment = StringAlignment.Center,
                LineAlignment = StringAlignment.Center,
                Trimming = StringTrimming.EllipsisCharacter,
                FormatFlags = StringFormatFlags.NoWrap
            };

            int h = tree.Depth();
            double base_n = 10;
            double n = base_n - (-1.0 / ((h / 5.0) + 1.0 / base_n) + base_n);
            Console.WriteLine(n);
            double r = treePictureBox.Width / (Math.Pow(2, h) + n * Math.Pow(2, h - 1) + n);

            List<(int?, int?)> allCenters = new List<(int?, int?)>();
            List<(int, int)> prevLayerCenters = new List<(int, int)>();
            List<(int, int)> layerCenters = new List<(int, int)>();

            double centerHeight = r;
            for (int l = 0; l < h; l++)
            {
                double centerWidth = 0;
                for (int j = 0; j < Math.Pow(2, l); j++)
                {
                    centerWidth += treePictureBox.Width / (Math.Pow(2, l) + 1);

                    int? parent = 0;
                    if (l == 1)
                    {
                        parent = heap[0];
                    }
                    else if (l != 0)
                    { 
                        parent = heap[(int)Math.Round(Math.Pow(2, l - 1)) - 1 + j / 2];
                    }

                    if (l == 0 || parent != null)
                    {
                        allCenters.Add((
                            (int)Math.Round(centerWidth),
                            (int)Math.Round(centerHeight)
                        ));
                    }
                    else
                    {
                        allCenters.Add((
                            null,
                            null
                        ));
                    }

                    if (l > 0 && parent != null)
                    {
                        Pen pen = new Pen(Color.Black, 2);
                        g.DrawLine(pen,
                            prevLayerCenters[j / 2].Item1,
                            prevLayerCenters[j / 2].Item2,
                            (int)Math.Round(centerWidth),
                            (int)Math.Round(centerHeight)
                            );
                    }
                    

                    layerCenters.Add(((int)Math.Round(centerWidth), (int)Math.Round(centerHeight)));
                }
                prevLayerCenters = new List<(int, int)>(layerCenters);
                layerCenters.Clear();
                centerHeight += treePictureBox.Height / h;
            }

            double textWidth = r * Math.Sqrt(3);
            double textHeight = r;

            int fontSize = 100;
            Font stringFont = new Font("Lato", fontSize);
            for (int i = 0; i < allCenters.Count; i++)
            {
                if (allCenters[i].Item1 != null &&
                    allCenters[i].Item2 != null)
                {
                    string s = (heap[i] == null ? "" : heap[i].ToString());
                    if (s != "")
                    {
                        SizeF stringSize = g.MeasureString(s, stringFont); 

                        int newFontSize = Math.Min((int)Math.Round((textWidth / stringSize.Width)  * fontSize),
                                                   (int)Math.Round((textHeight / stringSize.Height) * fontSize));
                        if (newFontSize < fontSize)
                        {
                            fontSize = newFontSize;
                            stringFont = new Font("Lato", fontSize);
                        }
                    }
                }
            }
            if (fontSize < 8)
            {
                fontSize = 8;
                stringFont = new Font("Lato", fontSize);
            }


            for (int i = 0; i < allCenters.Count; i++)
            {
                if (allCenters[i].Item1 != null &&
                    allCenters[i].Item2 != null)
                {
                    if (heap[i] == null)
                    {
                        g.DrawEllipse(Pens.Black, new Rectangle(
                                (int)Math.Round((int)allCenters[i].Item1 - r),
                                (int)Math.Round((int)allCenters[i].Item2 - r),
                                (int)Math.Round(2 * r),
                                (int)Math.Round(2 * r)));
                        g.FillEllipse(Brushes.Gray, new Rectangle(
                                (int)Math.Round((int)allCenters[i].Item1 - r),
                                (int)Math.Round((int)allCenters[i].Item2 - r),
                                (int)Math.Round(2 * r),
                                (int)Math.Round(2 * r)));
                    }
                    else
                    {
                        g.FillEllipse(Brushes.Black, new Rectangle(
                                (int)Math.Round((int)allCenters[i].Item1 - r),
                                (int)Math.Round((int)allCenters[i].Item2 - r),
                                (int)Math.Round(2 * r),
                                (int)Math.Round(2 * r)));
                    }

                    string s = (heap[i] == null ? "" : heap[i].ToString());
                    g.DrawString(s, stringFont, Brushes.White,
                        new Rectangle((int)allCenters[i].Item1 - (int)Math.Round(textWidth / 2),
                                      (int)allCenters[i].Item2 - (int)Math.Round(textHeight / 2),
                                      (int)Math.Round(textWidth),
                                      (int)Math.Round(textHeight)), format);
                }
            }

            treePictureBox.Image = treeDrawing;
        }

        private int? getIntFromTextBox(TextBox tx)
        {
            /*
             * Достаёт int из TextBox.
             * В случае неудачи возвращает
             * null
            */

            if (tx == null || tx.Text == "")
            {
                return null;
            }

            try
            {
                int res = int.Parse(tx.Text);
                return res;
            }
            catch (Exception)
            {
                return null;
            }
        }

        private void MainForm_Resize(object sender, System.EventArgs e)
        {
            drawTree();
        }

        private void addButton_Click(object sender, EventArgs e)
        {
            int? val = getIntFromTextBox(inputTextBox);
            if (val != null)
            {
                tree.Insert((int)val);
                drawTree();
            }
        }
         
        private void removeButton_Click(object sender, EventArgs e)
        {
            int? val = getIntFromTextBox(inputTextBox);
            if (val != null)
            {
                tree.Remove((int)val);
                drawTree();
            }
        }
    }
}
