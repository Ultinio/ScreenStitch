using System;
using System.IO;
using System.Drawing;
using System.Collections.Generic;
using System.Windows.Forms;

namespace ScreenStitch
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            mainForm = new MainForm();
            Application.Run(mainForm);
        }

        static MainForm mainForm;
        public struct Dims
        {
            public int Width;
            public int Height;
        };


        struct PotentialStitch
        {
            public int tried;
            public int start;
            public int same;
        };


        struct Crop
        {
            public int row;
            public int nb;
        };



        static public Dims getImageDimensions(string filename)
        {
            using (Bitmap image = new Bitmap(filename))
            {
                Dims dims;
                dims.Width = image.Width;
                dims.Height = image.Height;
                return dims;
            }
        }


        static int[] CreateColumnList(int width, int nbColumns)
        {
            int[] rows = new int[nbColumns];
            float gap = width / (nbColumns + 1);

            for (int i = 0; i < nbColumns; i++)
            {
                rows[i] = (int)(gap * (i + 1));
            }

            return rows;
        }


        static Color[][] getImageDescription(string filename)
        {
            using (Bitmap image = new Bitmap(filename))
            {
                int nbColumns = mainForm.inNbColumns;

                int[] columns = CreateColumnList(image.Width, nbColumns);

                int height = image.Height;
                Color[][] description = new Color[height][];

                for (int i = 0; i < height; i++)
                {
                    description[i] = new Color[nbColumns];
                    for (int c = 0; c < nbColumns; c++)
                    {
                        description[i][c] = image.GetPixel(columns[c], i);
                    }
                }

                return description;
            }
        }


        static public void CreateFileDefinition(string filename, string filenameOut)
        {
            using (StreamWriter file = new StreamWriter(filenameOut))
            {
                Color[][] desc = getImageDescription(filename);

                int nbColumns = mainForm.inNbColumns;

                int iRow = 0;
                int[] columnList = CreateColumnList(getImageDimensions(filename).Width, nbColumns);
                foreach (Color[] row in desc)
                {
                    file.Write("Row {0} ", iRow++);
                    int iColumn = 0;
                    foreach (Color pixel in row)
                    {
                        file.Write("  col.{0}({1},{2},{3})",
                            columnList[iColumn++], pixel.R, pixel.G, pixel.B);
                    }
                    file.WriteLine();
                }
            }
        }


        static bool IsSameRow(Color[] row1, Color[] row2, int colorFlexibility)
        {
            int length = row1.Length;

            if (length != row2.Length)
                return false;

            for (int i = 0; i < length; i++)
            {
                Color c1 = row1[i];
                Color c2 = row2[i];

                int dR = Math.Abs(c1.R - c2.R);
                int dG = Math.Abs(c1.G - c2.G);
                int dB = Math.Abs(c1.B - c2.B);

                //if (!row1[i].Equals(row2[i]))
                if (dR > colorFlexibility || dG > colorFlexibility && dB > colorFlexibility)
                    return false;
            }

            return true;
        }


        static PotentialStitch GetPotentialStichForPosition(
            Color[][] descImageTop, Color[][] descImageBottom, int nbCommon)
        {
            int max = 0;
            int offset = 0;

            int colorFlexibility = mainForm.inColorFlexibility;

            int nb = 0;
            int rowStartForTop = descImageTop.Length - nbCommon;

            // DEBUG !!!
            // Check the 2 description files: height img2 - (img1 row - img2 row)
            // Height img2 - img1 row + img2 row.
            // Ex: 960 - 850 + 238 = 348

            for (int iRow = 0; iRow < nbCommon; iRow++)
            {
                if (IsSameRow(descImageBottom[iRow], descImageTop[rowStartForTop + iRow], colorFlexibility))
                {
                    nb++;
                }
                else
                {
                    nb = 0;
                }

                if (nb > max)
                {
                    max = nb;
                    offset = iRow - nb;
                }
            }

            PotentialStitch potentialStitch;

            potentialStitch.tried = nbCommon;
            potentialStitch.start = offset;
            potentialStitch.same = max;

            return potentialStitch;
        }


        static public void StartStitch(string patternOut, string filenameTop, string filenameBottom,
            int matchingRowsThreshold, int potentialNum)
        {
            Dims dimsTop = getImageDimensions(filenameTop);
            Dims dimsBottom = getImageDimensions(filenameBottom);

            if (dimsTop.Width != dimsBottom.Width)
            {
                MessageBox.Show("Different Width !", mainForm.Text);
                mainForm.SetInfo("", "Different Width");
                return;
            }

            mainForm.SetInfo("Analysing Images ...", "");
            Application.DoEvents();


            Color[][] descImageTop = getImageDescription(filenameTop);
            Color[][] descImageBottom = getImageDescription(filenameBottom);


            List<PotentialStitch> potentialStitchList = new List<PotentialStitch>();

            int nbPotential = 0;
            int matchingRowsMin = 5;
            int iCommonMax = Math.Min(dimsTop.Height, dimsBottom.Height) - matchingRowsMin;

            for (int iCommon = matchingRowsMin; iCommon < iCommonMax; iCommon++)
            {
                PotentialStitch potentialStich = GetPotentialStichForPosition(
                    descImageTop, descImageBottom, iCommon);

                if (potentialStich.same >= matchingRowsMin)
                    potentialStitchList.Add(potentialStich);

                if (potentialStich.same >= matchingRowsThreshold)
                    nbPotential++;
            }

            potentialStitchList.Sort(
                delegate(PotentialStitch a, PotentialStitch b)
                {
                    return b.same.CompareTo(a.same);
                    //return a.start.CompareTo(b.start);
                }
            );


            int nbPotentialAboveMin = potentialStitchList.Count;
            if (nbPotentialAboveMin == 0)
            {
                mainForm.SetInfo("No Potential Stitch Found", "Cancelled");
                return;
            }


            if (potentialNum > nbPotentialAboveMin)
            {
                mainForm.SetInfo("Potential Num Is Too High (" + nbPotentialAboveMin + " Max)", "Cancelled");
                return;
            }


            PotentialStitch potentialStitch = potentialStitchList[potentialNum - 1];

            int matchingRows = potentialStitch.same;
            if (matchingRows < matchingRowsThreshold)
            {
                string txt = "Matching Rows (" + matchingRows + ") below thresold";
                if (MessageBox.Show(txt + "\nContinue ?", mainForm.Text,
                       MessageBoxButtons.YesNo) == DialogResult.No)
                {
                    mainForm.SetInfo(txt, "Cancelled");
                    return;
                }
            }



            int middle = (int)(potentialStitch.same / 2);
            int offsetImageTop = dimsTop.Height - potentialStitch.tried + potentialStitch.start + middle;
            int offsetImageBottom = potentialStitch.start + middle;
            int finalHeight = offsetImageTop + dimsBottom.Height - offsetImageBottom;


            string filenameOut = patternOut
                        .Replace("#_FILE_TOP_#", Path.GetFileNameWithoutExtension(filenameTop))
                        .Replace("#_FILE_BOTTOM_#", Path.GetFileNameWithoutExtension(filenameBottom))
                        .Replace("#_HEIGHT_#", finalHeight.ToString())
                        .Replace("#_OVERPX_#", potentialStitch.same.ToString())
                        + ".png";

            if (!Path.IsPathRooted(filenameOut))
                filenameOut = Path.Combine(Path.GetDirectoryName(filenameBottom), filenameOut);


            string sameRowsText = "over " + potentialStitch.same + " px (";
            if (nbPotential > 1)
                sameRowsText += "WARNING: ";
            sameRowsText += nbPotential + " Potential)";


            if(File.Exists(filenameOut))
            {
                if (MessageBox.Show("File already exists :\n" + filenameOut + "\nIt will be overwritten !", mainForm.Text,
                    MessageBoxButtons.OKCancel) == DialogResult.Cancel)
                {
                    mainForm.SetInfo("Cancelled cause File already exists", filenameOut);
                    return;
                }
            }


            mainForm.SetInfo("STITCHING " + sameRowsText + " ...", Path.GetFileName(filenameOut));
            Application.DoEvents();


            StitchImages(
                filenameOut, finalHeight,
                filenameTop, offsetImageTop,
                filenameBottom, offsetImageBottom);


            mainForm.SetInfo("DONE " + sameRowsText, "");
        }


        static void StitchImages(string filenameOut, int finalHeight,
                    string filenameTop, int offsetImageTop,
                    string filenameBottom, int offsetImageBottom)
        {
            int heightForBottom = finalHeight - offsetImageTop;

            using (Bitmap imageTop = new Bitmap(filenameTop))
            {
                using (Bitmap imageBottom = new Bitmap(filenameBottom))
                {
                    using (Bitmap finalImage = new Bitmap(imageTop.Width, finalHeight))
                    {
                        using (System.Drawing.Graphics g = System.Drawing.Graphics.FromImage(finalImage))
                        {
                            //set background color
                            //g.Clear(System.Drawing.Color.Black);

                            g.DrawImage(imageTop,
                                new Rectangle(0, 0, imageTop.Width, offsetImageTop),
                                new Rectangle(0, 0, imageTop.Width, offsetImageTop),
                                GraphicsUnit.Pixel);

                            g.DrawImage(imageBottom,
                                new Rectangle(0, offsetImageTop, imageBottom.Width, heightForBottom),
                                new Rectangle(0, offsetImageBottom, imageBottom.Width, heightForBottom),
                                GraphicsUnit.Pixel);

                            finalImage.Save(filenameOut, System.Drawing.Imaging.ImageFormat.Png);

                        }
                    }
                }
            }
        }


        static public void CleanEmptySpaces(string patternOut, string filename, int spacesMax)
        {
            int colorFlexibility = mainForm.inColorFlexibility;

            mainForm.SetInfo("Analysing Image for Spaces ...", "");
            Application.DoEvents();


            Color[][] descImage = getImageDescription(filename);

            List<Crop> crops = new List<Crop>();
            Crop tmpCrop;
 
            int height = descImage.Length;
            int iRowMax = height - spacesMax;
            int savedTotal = 0;
            for (int iRow = 0; iRow < iRowMax;)
            {
                Color[] modelRow = descImage[iRow];

                int add = 1;
                while (iRow + add < height  &&  IsSameRow(modelRow, descImage[iRow + add], colorFlexibility))
                    add++;

                int saved = add - 1 - spacesMax;
                
                if (saved > 0)
                {
                    tmpCrop.row = iRow;
                    tmpCrop.nb = saved;

                    crops.Add(tmpCrop);
                    //Save iRow and add
                    savedTotal += saved;
                }

                iRow += add;
            }


            int nbCrops = crops.Count;
            if (nbCrops == 0)
            {
                mainForm.SetInfo("No Empty Space found ...", "Canceled");
                return;
            }


            int finalHeight = height - savedTotal;

            string filenameOut = patternOut
                .Replace("#_FILE_#", Path.GetFileNameWithoutExtension(filename))
                .Replace("#_HEIGHT_#", finalHeight.ToString())
                .Replace("#_SAVED_#", savedTotal.ToString())
                .Replace("#_SPOTS_#", nbCrops.ToString())
                + ".png";

            if (!Path.IsPathRooted(filenameOut))
                filenameOut = Path.Combine(Path.GetDirectoryName(filename), filenameOut);


            mainForm.SetInfo("CROPPING ... Saving " + savedTotal + "px in " + nbCrops + " places",
                Path.GetFileName(filenameOut));


            // adding for last cropping
            tmpCrop.row = height;
            tmpCrop.nb = 1;
            crops.Add(tmpCrop);


            using (Bitmap image = new Bitmap(filename))
            {
                int width = image.Width;
                using (Bitmap finalImage = new Bitmap(width, finalHeight))
                {
                    using (System.Drawing.Graphics g = System.Drawing.Graphics.FromImage(finalImage))
                    {
                        int iRowDest = 0;
                        int iRowSrc = 0;
                        foreach (Crop crop in crops)
                        {
                            int cropHeight = crop.row - iRowSrc;
                            g.DrawImage(image,
                                new Rectangle(0, iRowDest, width, cropHeight),
                                new Rectangle(0, iRowSrc, width, cropHeight),
                                GraphicsUnit.Pixel);

                            iRowDest += cropHeight;
                            iRowSrc += cropHeight + crop.nb;
                        }
                        /*
                        int finalCropHeight = height - iRowSrc;
                        g.DrawImage(image,
                            new Rectangle(0, iRowDest, width, finalCropHeight),
                            new Rectangle(0, iRowSrc, width, finalCropHeight),
                            GraphicsUnit.Pixel);
                        */

                        finalImage.Save(filenameOut, System.Drawing.Imaging.ImageFormat.Png);
                    }
                }
            }

            mainForm.SetInfo("DONE ! Saved " + savedTotal + "px in " + nbCrops + " places", "");
        }
    }
}
