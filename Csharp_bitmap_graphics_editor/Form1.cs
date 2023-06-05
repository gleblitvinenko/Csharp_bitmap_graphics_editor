using System.Windows.Forms;
using System.Xml.Serialization;

namespace Csharp_bitmap_graphics_editor
{
    public partial class Form1 : Form
    {
        private Stack<Bitmap> undoStack = new Stack<Bitmap>();
        private Stack<Bitmap> redoStack = new Stack<Bitmap>();
        public Form1()
        {

            InitializeComponent();
            this.KeyPreview = true;
            this.KeyDown += Form1_KeyDown;
            SetSize();
            pictureBox1.Image = map;
            undoStack.Push(new Bitmap(pictureBox1.Image));
            redoStack.Clear();
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
        private bool isMouse = false; //������ �� ���
        private void pictureBox1_MouseDown(object sender, MouseEventArgs e)
        {
            isMouse = true;
            if (e.Button == MouseButtons.Right)
            {
                toolStripMenuItem1.ShowDropDown();
            }

            if (e.Button == MouseButtons.Left)
            {
                isMouse = true;
                arrayPoints.ResetPoints();
            }
        }

        private void pictureBox1_MouseUp(object sender, MouseEventArgs e)
        {
            isMouse = false;
            arrayPoints.ResetPoints();

            if (e.Button == MouseButtons.Left)
            {
                isMouse = false;

                // ������� ����� ����� �������� �����������
                Bitmap currentImage = new Bitmap(pictureBox1.Image);
                // ��������� ������� ��������� ����������� � ����� "��������"
                undoStack.Push(currentImage);
                // ������� ���� "�������" ��� ������ ����� ��������
                redoStack.Clear();
            }
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
            // �����������, ��� � ��� ���� �����������, ������� ����� �����������
            Image imageToCopy = pictureBox1.Image;

            // ����������� ����������� � ����� ������
            Clipboard.SetImage(imageToCopy);
        }

        private void PasteImageFromClipboard()
        {
            // ���������, �������� �� ����� ������ �����������
            if (Clipboard.ContainsImage())
            {
                // �������� ����������� �� ������ ������
                Image imageToPaste = Clipboard.GetImage();

                // ��������� ����������� � ���������� map
                graphics.Clear(pictureBox1.BackColor);
                graphics.DrawImage(imageToPaste, 0, 0);
                pictureBox1.Image = map;
            }
        }
        private void Form1_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Control && (e.KeyCode == Keys.C || e.KeyCode == Keys.V))
            {
                // ������������ ������� ������ Ctrl+C � Ctrl+V
                switch (e.KeyCode)
                {
                    case Keys.C:
                        // ��������� �����������
                        CopyImageToClipboard();
                        break;
                    case Keys.V:
                        // ��������� �������
                        PasteImageFromClipboard();
                        break;
                }
            }
            if (e.Control && e.KeyCode == Keys.Z)
            {
                // ������������ ������� ������� Ctrl+Z ��� ������ ��������
                Undo();
                // ������������� ���������� ��������� ������� ������� �������
                e.Handled = true;
            }
            else if (e.Control && e.KeyCode == Keys.Y)
            {
                // ������������ ������� ������� Ctrl+Y ��� �������� ��������
                Redo();
                // ������������� ���������� ��������� ������� ������� �������
                e.Handled = true;
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

        private void undoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Undo();
        }

        private void redoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Redo();
        }
        private void Undo()
        {
            if (undoStack.Count > 1)
            {
                // ��������� ��������� ��������� �� ����� "��������"
                Bitmap previousImage = undoStack.Pop();
                // ��������� ������� ��������� � ���� "�������"
                redoStack.Push(new Bitmap(pictureBox1.Image));
                // ������������� ���������� ��������� � �������� �������� �����������
                pictureBox1.Image = new Bitmap(previousImage);
                pictureBox1.Refresh();
            }
        }
        private void Redo()
        {
            if (redoStack.Count > 0)
            {
                // ��������� ��������� ��������� �� ����� "�������"
                Bitmap nextImage = redoStack.Pop();
                // ��������� ������� ��������� � ���� "��������"
                undoStack.Push(new Bitmap(pictureBox1.Image));
                // ������������� ��������� ��������� � �������� �������� �����������
                pictureBox1.Image = new Bitmap(nextImage);
                pictureBox1.Refresh();
            }
        }
    }
}