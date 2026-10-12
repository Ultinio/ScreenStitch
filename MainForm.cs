using System;
using System.IO;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace ScreenStitch
{
    public partial class MainForm : Form
    {
        public int inMatchingRows = 70; // minimum matching rows for a stitch
        public int inIndexPotential = 1; // index of potential stitch
        public int inNbColumns = 17; // number of columns to validate a same row
        public int inColorFlexibility = 1; // weird but possible: same element can have diff values on the image
        public int inSpacesMax = 20; // height of maximum empty space


        public MainForm()
        {
            InitializeComponent();

            this.Text += " " + Application.ProductVersion;

            textBoxMatchingRows.Text = inMatchingRows.ToString();
            textBoxPotential.Text = inIndexPotential.ToString();
            textBoxColumns.Text = inNbColumns.ToString();
            textBoxFlexibility.Text = inColorFlexibility.ToString();
            textBoxSpacesMax.Text = inSpacesMax.ToString();

            textBoxPatternStitch.Text = "#_FILE_BOTTOM_#_Stitch(px#_HEIGHT_#-match#_OVERPX_#)";
            textBoxPatternSpaces.Text = "#_FILE_#_Spaces(px#_HEIGHT_#-sv#_SAVED_#-nb#_SPOTS_#)";
        }


        string filenameStitchTop;
        string filenameStitchBottom;
        string filenameClean;


        public void SetInfo(string text1, string text2)
        {
            if(text1 != "")
                labelInfo1.Text = text1;
            if (text2 != "")
                labelInfo2.Text = text2;
        }


        void Stitch_DragEnter(object sender, DragEventArgs e)
        {
            e.Effect = e.Data.GetDataPresent(DataFormats.FileDrop) ? DragDropEffects.Copy : DragDropEffects.None;
        }


        void Stitch_DragDrop(object sender, DragEventArgs e)
        {
            // Extract the data from the DataObject-Container into a string list
            string[] FileList = (string[])e.Data.GetData(DataFormats.FileDrop, false);

            // Do something with the data...
            if (FileList.Length != 2)
            {
                SetInfo("", "Drop 2 PNG images !");
                return;
            }

            SetInfo("", "Analysing Image Dimensions ...");
            Application.DoEvents();

            SetAppFiles(FileList[0], FileList[1]);
            SetInfo("", "New Images Dropped");

            buttonStitch.Enabled = true;
        }


        void Clean_DragEnter(object sender, DragEventArgs e)
        {
            e.Effect = e.Data.GetDataPresent(DataFormats.FileDrop) ? DragDropEffects.Copy : DragDropEffects.None;
        }


        void Clean_DragDrop(object sender, DragEventArgs e)
        {
            // Extract the data from the DataObject-Container into a string list
            string[] FileList = (string[])e.Data.GetData(DataFormats.FileDrop, false);

            // Do something with the data...
            if (FileList.Length != 1)
            {
                SetInfo("", "Drop 1 PNG image ONLY !");
                return;
            }

            SetInfo("", "Analysing Image Dimensions ...");
            Application.DoEvents();

            labelImageClean.Text = Path.GetFileName(FileList[0]);
            filenameClean = FileList[0];
            SetInfo("", "Cleaning Ready");

            buttonClean.Enabled = true;
        }


        bool CheckFileExist(string filename)
        {
            if (File.Exists(filename))
            {
                return true;
            }
            else
            {
                SetInfo("", "Image Does Not Exist");
                return false;
            }
        }


        string GetImageText(string text, string filename)
        {
            return "(" + text + ")   " + Path.GetFileName(filename);
        }


        bool SetAppFiles(string filenameTop, string filenameBottom)
        {
            filenameStitchTop = filenameTop;
            filenameStitchBottom = filenameBottom;

            if (!CheckFileExist(filenameTop) || !CheckFileExist(filenameBottom))
                return false;


            labelFolderValue.Text = Path.GetDirectoryName(filenameTop) + "\\";
            labelImageTop.Text = GetImageText("Analysing", filenameTop);
            labelImageBottom.Text = GetImageText("Analysing", filenameBottom);

            Application.DoEvents();

            Program.Dims dimsTop = Program.getImageDimensions(filenameTop);
            labelImageTop.Text = GetImageText("" + dimsTop.Width + " x " + dimsTop.Height, filenameTop);

            Program.Dims dimsBottom = Program.getImageDimensions(filenameBottom);
            labelImageBottom.Text = GetImageText("" + dimsBottom.Width + " x " + dimsBottom.Height, filenameBottom);

            if (dimsBottom.Height > dimsTop.Height)
                MessageBox.Show("Bottom Image Height is bigger than Top Image !", this.Text);

            return true;
        }


        private void buttonStitch_Click(object sender, EventArgs e)
        {
            buttonStitch.Enabled = false;

            int.TryParse(textBoxMatchingRows.Text, out inMatchingRows);
            int.TryParse(textBoxPotential.Text, out inIndexPotential);
            int.TryParse(textBoxColumns.Text, out inNbColumns);
            int.TryParse(textBoxFlexibility.Text, out inColorFlexibility);


            Program.StartStitch(
                textBoxPatternStitch.Text, filenameStitchTop, filenameStitchBottom,
                inMatchingRows, inIndexPotential);

            buttonStitch.Enabled = true;
        }


        void CreateFileDefinition(string filenameImage)
        {
            int.TryParse(textBoxColumns.Text, out inNbColumns);

            if (CheckFileExist(filenameImage))
            {
                string filenameOut = filenameImage + "_" + inNbColumns + "cols.txt";
                Program.CreateFileDefinition(filenameImage, filenameOut);
                SetInfo("Image Description Created", Path.GetFileName(filenameOut));
            }
        }


        void CleanSpaces(string filenameImage)
        {
            int.TryParse(textBoxSpacesMax.Text, out inSpacesMax);
            int.TryParse(textBoxColumns.Text, out inNbColumns);
            int.TryParse(textBoxFlexibility.Text, out inColorFlexibility);

            if (inSpacesMax < 3)
            {
                inSpacesMax = 15;
                MessageBox.Show("Spaces < 3 -> Set to 15", this.Text);
            }

            Program.CleanEmptySpaces(
                textBoxPatternSpaces.Text, filenameImage,
                inSpacesMax);
        }
 

        private void labelFolderTitle_Click(object sender, EventArgs e)
        {
            if (SetAppFiles(filenameStitchBottom, filenameStitchTop))
                SetInfo("", "Images Switched");
        }


        private void buttonDescription_Click(object sender, EventArgs e)
        {
            CreateFileDefinition(filenameStitchTop);
            CreateFileDefinition(filenameStitchBottom);
        }

        private void buttonClean_Click(object sender, EventArgs e)
        {
            CleanSpaces(filenameClean);
        }

    }
}
