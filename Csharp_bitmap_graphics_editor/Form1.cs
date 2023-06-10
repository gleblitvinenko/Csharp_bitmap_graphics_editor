using System.Windows.Forms;
using System.Xml.Serialization;

namespace Csharp_bitmap_graphics_editor
{
    public partial class Form1 : Form
    {
        private string saveFilePath = string.Empty;
        private Color backgroundColor = Color.White;

        private bool isDrawingRectangle = false;

        private bool isDrawingEllipse = false;
        private Point startPoint;

        Stack<Bitmap> undoStack = new Stack<Bitmap>();
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

            pictureBox1.BackColor = backgroundColor;

            pen.StartCap = System.Drawing.Drawing2D.LineCap.Round;
            pen.EndCap = System.Drawing.Drawing2D.LineCap.Round;

            undoStack.Push(new Bitmap(map));
        }
        private bool isMouse = false;
        private void pictureBox1_MouseDown(object sender, MouseEventArgs e)
        {
            isMouse = true;
            if (e.Button == MouseButtons.Right)
            {
                toolStripMenuItem1.ShowDropDown();
            }

            if (isDrawingEllipse)
            {
                startPoint = e.Location;
            }
            else if (isDrawingRectangle)
            {
                startPoint = e.Location;
            }
            else if (e.Button == MouseButtons.Right)
            {
                toolStripMenuItem1.ShowDropDown();
            }
        }

        private void pictureBox1_MouseUp(object sender, MouseEventArgs e)
        {
            isMouse = false;
            arrayPoints.ResetPoints();

            undoStack.Push(new Bitmap(map));

            if (isDrawingEllipse)
            {

                int width = Math.Abs(e.X - startPoint.X);
                int height = Math.Abs(e.Y - startPoint.Y);
                int x = Math.Min(startPoint.X, e.X);
                int y = Math.Min(startPoint.Y, e.Y);
                graphics.DrawEllipse(pen, x, y, width, height);
                pictureBox1.Image = map;


                isDrawingEllipse = false;
                ellipseButton.BackColor = SystemColors.Control;


                undoStack.Push(new Bitmap(map));
            }
            if (isDrawingRectangle)
            {
                int width = Math.Abs(e.X - startPoint.X);
                int height = Math.Abs(e.Y - startPoint.Y);
                int x = Math.Min(startPoint.X, e.X);
                int y = Math.Min(startPoint.Y, e.Y);
                graphics.DrawRectangle(pen, x, y, width, height);
                pictureBox1.Image = map;

                isDrawingRectangle = false;
                rectangleButton.BackColor = SystemColors.Control;

                undoStack.Push(new Bitmap(map));
            }
        }

        private void pictureBox1_MouseMove(object sender, MouseEventArgs e)
        {
            if (!isMouse) { return; }
            if (isDrawingEllipse)
            {

                Bitmap tempMap = new Bitmap(map);
                Graphics tempGraphics = Graphics.FromImage(tempMap);
                int width = Math.Abs(e.X - startPoint.X);
                int height = Math.Abs(e.Y - startPoint.Y);
                int x = Math.Min(startPoint.X, e.X);
                int y = Math.Min(startPoint.Y, e.Y);
                tempGraphics.DrawEllipse(pen, x, y, width, height);
                pictureBox1.Image = tempMap;
                tempGraphics.Dispose();
            }
            else if (isDrawingRectangle)
            {
                Bitmap tempMap = new Bitmap(map);
                Graphics tempGraphics = Graphics.FromImage(tempMap);
                int width = Math.Abs(e.X - startPoint.X);
                int height = Math.Abs(e.Y - startPoint.Y);
                int x = Math.Min(startPoint.X, e.X);
                int y = Math.Min(startPoint.Y, e.Y);
                tempGraphics.DrawRectangle(pen, x, y, width, height);
                pictureBox1.Image = tempMap;
                tempGraphics.Dispose();
            }
            else
            {
                arrayPoints.SetPoint(e.X, e.Y);
                if (arrayPoints.GetCountPoints() >= 2)
                {
                    graphics.DrawLines(pen, arrayPoints.GetPoints());
                    pictureBox1.Image = map;
                    arrayPoints.SetPoint(e.X, e.Y);
                }
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            pen.Color = ((Button)sender).BackColor;
            currentColorButton.BackColor = ((Button)sender).BackColor;
        }

        private void button12_Click(object sender, EventArgs e)
        {
            if (colorDialog1.ShowDialog() == DialogResult.OK)
            {
                pen.Color = colorDialog1.Color;
                ((Button)sender).BackColor = colorDialog1.Color;
                currentColorButton.BackColor = colorDialog1.Color;
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
            SaveImage(saveFilePath);
        }
        private void saveAsToolStripMenuItem_Click_1(object sender, EventArgs e)
        {
            saveFileDialog1.Filter = "JPG(*.JPG)|*.jpg";
            if (saveFileDialog1.ShowDialog() == DialogResult.OK)
            {
                saveFilePath = saveFileDialog1.FileName;
                SaveImage(saveFilePath);
            }
        }

        private void SaveImage(string filePath)
        {
            try
            {
                if (pictureBox1.Image != null)
                {
                    Bitmap imageToSave = new Bitmap(pictureBox1.Width, pictureBox1.Height);
                    using (Graphics g = Graphics.FromImage(imageToSave))
                    {
                        g.Clear(pictureBox1.BackColor);
                        g.DrawImage(pictureBox1.Image, 0, 0);
                    }
                    imageToSave.Save(filePath);
                }
            }
            catch (Exception ex)
            {
                saveFileDialog1.Filter = "JPG(*.JPG)|*.jpg";
                if (saveFileDialog1.ShowDialog() == DialogResult.OK)
                {
                    saveFilePath = saveFileDialog1.FileName;
                    SaveImage(saveFilePath);
                }
            }
        }
        private void CopyImageToClipboard()
        {

            Image imageToCopy = pictureBox1.Image;


            Clipboard.SetImage(imageToCopy);
        }

        private void PasteImageFromClipboard()
        {

            if (Clipboard.ContainsImage())
            {

                Image imageToPaste = Clipboard.GetImage();


                graphics.Clear(pictureBox1.BackColor);
                graphics.DrawImage(imageToPaste, 0, 0);
                pictureBox1.Image = map;
            }
        }
        private void Form1_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Control && (e.KeyCode == Keys.C || e.KeyCode == Keys.V))
            {
                // Ctrl+C и Ctrl+V
                switch (e.KeyCode)
                {
                    case Keys.C:

                        CopyImageToClipboard();
                        break;
                    case Keys.V:

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
        private void undoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Undo();
        }

        private void redoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //Redo();
        }
        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void Undo()
        {
            if (undoStack.Count > 1)
            {
                // Pop the current state from the stack
                undoStack.Pop();

                // Get the previous state from the stack
                Bitmap previousState = undoStack.Peek();

                // Restore the previous state as the current image
                map = new Bitmap(previousState);
                graphics = Graphics.FromImage(map);

                // Update the PictureBox with the restored image
                pictureBox1.Image = map;
            }
        }

        private void openToolStripMenuItem_Click(object sender, EventArgs e)
        {
            // OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog1.Filter = "Images|*.jpg;*.png;*.bmp|All Files|*.*";

            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                string selectedFilePath = openFileDialog1.FileName;
                OpenImage(selectedFilePath);
            }
        }
        private void OpenImage(string filePath)
        {
            try
            {
                Image openedImage = Image.FromFile(filePath);
                graphics.Clear(pictureBox1.BackColor);
                graphics.DrawImage(openedImage, 0, 0);
                pictureBox1.Image = map;
                undoStack.Push(new Bitmap(map));
            }
            catch (Exception ex)
            {
                MessageBox.Show("Ошибка при открытии файла: " + ex.Message);
            }
        }

        private void helpToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MessageBox.Show("The program was developed by student of the group KIUKI-21-5\nLytvynenko Glieb");
        }

        private void ellipseButton_Click(object sender, EventArgs e)
        {
            isDrawingEllipse = !isDrawingEllipse;

            if (isDrawingEllipse)
            {
                ellipseButton.BackColor = Color.LightGreen;
            }
            else
            {
                ellipseButton.BackColor = SystemColors.Control;
            }
        }

        private void eraserButton_Click(object sender, EventArgs e)
        {
            pen.Color = Color.White;
        }

        private void rectangleButton_Click(object sender, EventArgs e)
        {
            isDrawingRectangle = !isDrawingRectangle;

            if (isDrawingRectangle)
            {
                rectangleButton.BackColor = Color.LightGreen;
            }
            else
            {
                rectangleButton.BackColor = SystemColors.Control;
            }
        }

        private void pictureBox1_MouseDown_Rectangle(object sender, MouseEventArgs e)
        {
            
            // ...
        }

        private void pictureBox1_MouseUp_Rectangle(object sender, MouseEventArgs e)
        {
            // ...
            if (isDrawingRectangle)
            {
                int width = Math.Abs(e.X - startPoint.X);
                int height = Math.Abs(e.Y - startPoint.Y);
                int x = Math.Min(startPoint.X, e.X);
                int y = Math.Min(startPoint.Y, e.Y);
                graphics.DrawRectangle(pen, x, y, width, height);
                pictureBox1.Image = map;

                isDrawingRectangle = false;
                rectangleButton.BackColor = SystemColors.Control;

                undoStack.Push(new Bitmap(map));
            }
        }

        private void pictureBox1_MouseMove_Rectangle(object sender, MouseEventArgs e)
        {
            // ...
            if (isDrawingRectangle)
            {
                Bitmap tempMap = new Bitmap(map);
                Graphics tempGraphics = Graphics.FromImage(tempMap);
                int width = Math.Abs(e.X - startPoint.X);
                int height = Math.Abs(e.Y - startPoint.Y);
                int x = Math.Min(startPoint.X, e.X);
                int y = Math.Min(startPoint.Y, e.Y);
                tempGraphics.DrawRectangle(pen, x, y, width, height);
                pictureBox1.Image = tempMap;
                tempGraphics.Dispose();
            }
            // ...
        }
    }
}