using System.Windows.Forms;
using System.Xml.Serialization;

namespace Csharp_bitmap_graphics_editor
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            this.KeyPreview = true;
            this.KeyDown += Form1_KeyDown;
            SetSize();
        }
        private class ArrayPoints
        {
            private int index = 0;
            private Point[] points;
            public ArrayPoints(int size)
            {
                if (size <= 0) { size = 2; }
                points = new Point[size];
            }

            public void SetPoint(int x, int y)
            {
                if (index >= points.Length)
                {
                    index = 0;
                }
                points[index] = new Point(x, y);
                index++;
            }

            public void ResetPoints()
            {
                index = 0;
            }

            public int GetCountPoints()
            {
                return index;
            }

            public Point[] GetPoints()
            {
                return points;
            }
        }
        private ArrayPoints arrayPoints = new ArrayPoints(2);

        Bitmap map = new Bitmap(100, 100);
        Graphics graphics;
        Pen pen = new Pen(Color.Black, 3f);
        private void SetSize()
        {
            Rectangle rectangle = Screen.PrimaryScreen.Bounds;
            map = new Bitmap(rectangle.Width, rectangle.Height);
            graphics = Graphics.FromImage(map);

            pen.StartCap = System.Drawing.Drawing2D.LineCap.Round;
            pen.EndCap = System.Drawing.Drawing2D.LineCap.Round;
        }
        private void flowLayoutPanel1_Paint(object sender, PaintEventArgs e)
        {

        }
        private bool isMouse = false; //Зажата ли лкм
        private void pictureBox1_MouseDown(object sender, MouseEventArgs e)
        {
            isMouse = true;
            if (e.Button == MouseButtons.Right)
            {
                toolStripMenuItem1.ShowDropDown();
            }
        }

        private void pictureBox1_MouseUp(object sender, MouseEventArgs e)
        {
            isMouse = false;
            arrayPoints.ResetPoints();
        }

        private void pictureBox1_MouseMove(object sender, MouseEventArgs e)
        {
            if (!isMouse) { return; }
            arrayPoints.SetPoint(e.X, e.Y);
            if (arrayPoints.GetCountPoints() >= 2)
            {
                graphics.DrawLines(pen, arrayPoints.GetPoints());
                pictureBox1.Image = map;
                arrayPoints.SetPoint(e.X, e.Y);
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            pen.Color = ((Button)sender).BackColor;
        }

        private void button12_Click(object sender, EventArgs e)
        {
            if (colorDialog1.ShowDialog() == DialogResult.OK)
            {
                pen.Color = colorDialog1.Color;
                ((Button)sender).BackColor = colorDialog1.Color;
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            graphics.Clear(pictureBox1.BackColor);
            pictureBox1.Image = map;
        }

        private void trackBar1_ValueChanged(object sender, EventArgs e)
        {
            pen.Width = trackBar1.Value;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            saveFileDialog1.Filter = "JPG(*.JPG)|*.jpg";
            if (saveFileDialog1.ShowDialog() == DialogResult.OK)
            {
                if (pictureBox1.Image != null)
                {
                    pictureBox1.Image.Save(saveFileDialog1.FileName);
                }
            }
        }
        private void CopyImageToClipboard()
        {
            // Предположим, что у вас есть изображение, которое нужно скопировать
            Image imageToCopy = pictureBox1.Image;

            // Копирование изображения в буфер обмена
            Clipboard.SetImage(imageToCopy);
        }

        private void PasteImageFromClipboard()
        {
            // Проверяем, содержит ли буфер обмена изображение
            if (Clipboard.ContainsImage())
            {
                // Получаем изображение из буфера обмена
                Image imageToPaste = Clipboard.GetImage();

                // Сохраняем изображение в переменную map
                graphics.Clear(pictureBox1.BackColor);
                graphics.DrawImage(imageToPaste, 0, 0);
                pictureBox1.Image = map;
            }
        }
        private void Form1_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Control && (e.KeyCode == Keys.C || e.KeyCode == Keys.V))
            {
                // Обрабатываем нажатие клавиш Ctrl+C и Ctrl+V
                switch (e.KeyCode)
                {
                    case Keys.C:
                        // Выполняем копирование
                        CopyImageToClipboard();
                        break;
                    case Keys.V:
                        // Выполняем вставку
                        PasteImageFromClipboard();
                        break;
                }
            }
        }

        private void pasteCTRLVToolStripMenuItem_Click(object sender, EventArgs e)
        {
            PasteImageFromClipboard();
        }

        private void copyToolStripMenuItem_Click(object sender, EventArgs e)
        {
            CopyImageToClipboard();
        }
    }
}