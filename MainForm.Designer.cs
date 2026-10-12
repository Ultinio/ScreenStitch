using System;
using System.IO;
using System.Windows.Forms;

namespace ScreenStitch
{
    partial class MainForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
            this.buttonStitch = new System.Windows.Forms.Button();
            this.labelFolderValue = new System.Windows.Forms.Label();
            this.labelTextTop = new System.Windows.Forms.Label();
            this.labelTextBottom = new System.Windows.Forms.Label();
            this.groupBoxStitch = new System.Windows.Forms.GroupBox();
            this.buttonDescription = new System.Windows.Forms.Button();
            this.labelFolderTitle = new System.Windows.Forms.Label();
            this.labelImageBottom = new System.Windows.Forms.Label();
            this.labelImageTop = new System.Windows.Forms.Label();
            this.textBoxPatternStitch = new System.Windows.Forms.TextBox();
            this.labelOutputStitch = new System.Windows.Forms.Label();
            this.textBoxPotential = new System.Windows.Forms.TextBox();
            this.labelPotential = new System.Windows.Forms.Label();
            this.labelColumns = new System.Windows.Forms.Label();
            this.labelFlexibility = new System.Windows.Forms.Label();
            this.textBoxFlexibility = new System.Windows.Forms.TextBox();
            this.labelMatchingRows = new System.Windows.Forms.Label();
            this.textBoxMatchingRows = new System.Windows.Forms.TextBox();
            this.textBoxColumns = new System.Windows.Forms.TextBox();
            this.textBoxPatternSpaces = new System.Windows.Forms.TextBox();
            this.labelOutputSpaces = new System.Windows.Forms.Label();
            this.labelCleaning = new System.Windows.Forms.Label();
            this.textBoxSpacesMax = new System.Windows.Forms.TextBox();
            this.labelInfo1 = new System.Windows.Forms.Label();
            this.labelInfo2 = new System.Windows.Forms.Label();
            this.groupBoxCleaning = new System.Windows.Forms.GroupBox();
            this.labelImageClean = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.buttonClean = new System.Windows.Forms.Button();
            this.groupBoxStitch.SuspendLayout();
            this.groupBoxCleaning.SuspendLayout();
            this.SuspendLayout();
            // 
            // buttonStitch
            // 
            this.buttonStitch.Enabled = false;
            this.buttonStitch.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonStitch.Location = new System.Drawing.Point(208, 154);
            this.buttonStitch.Name = "buttonStitch";
            this.buttonStitch.Size = new System.Drawing.Size(63, 23);
            this.buttonStitch.TabIndex = 9;
            this.buttonStitch.Text = "Stitch";
            this.buttonStitch.UseVisualStyleBackColor = true;
            this.buttonStitch.Click += new System.EventHandler(this.buttonStitch_Click);
            // 
            // labelFolderValue
            // 
            this.labelFolderValue.AutoSize = true;
            this.labelFolderValue.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelFolderValue.Location = new System.Drawing.Point(54, 20);
            this.labelFolderValue.Name = "labelFolderValue";
            this.labelFolderValue.Size = new System.Drawing.Size(163, 13);
            this.labelFolderValue.TabIndex = 3;
            this.labelFolderValue.Text = "Drag && Drop Here 2 PNG Images";
            // 
            // labelTextTop
            // 
            this.labelTextTop.AutoSize = true;
            this.labelTextTop.Cursor = System.Windows.Forms.Cursors.Hand;
            this.labelTextTop.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Underline, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelTextTop.Location = new System.Drawing.Point(20, 40);
            this.labelTextTop.Name = "labelTextTop";
            this.labelTextTop.Size = new System.Drawing.Size(32, 13);
            this.labelTextTop.TabIndex = 5;
            this.labelTextTop.Text = "Top :";
            // 
            // labelTextBottom
            // 
            this.labelTextBottom.AutoSize = true;
            this.labelTextBottom.Cursor = System.Windows.Forms.Cursors.Hand;
            this.labelTextBottom.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Underline, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelTextBottom.Location = new System.Drawing.Point(6, 60);
            this.labelTextBottom.Name = "labelTextBottom";
            this.labelTextBottom.Size = new System.Drawing.Size(46, 13);
            this.labelTextBottom.TabIndex = 6;
            this.labelTextBottom.Text = "Bottom :";
            // 
            // groupBoxStitch
            // 
            this.groupBoxStitch.AllowDrop = true;
            this.groupBoxStitch.Controls.Add(this.buttonDescription);
            this.groupBoxStitch.Controls.Add(this.labelFolderTitle);
            this.groupBoxStitch.Controls.Add(this.buttonStitch);
            this.groupBoxStitch.Controls.Add(this.labelImageBottom);
            this.groupBoxStitch.Controls.Add(this.labelImageTop);
            this.groupBoxStitch.Controls.Add(this.textBoxPatternStitch);
            this.groupBoxStitch.Controls.Add(this.labelTextTop);
            this.groupBoxStitch.Controls.Add(this.labelOutputStitch);
            this.groupBoxStitch.Controls.Add(this.labelTextBottom);
            this.groupBoxStitch.Controls.Add(this.textBoxPotential);
            this.groupBoxStitch.Controls.Add(this.labelFolderValue);
            this.groupBoxStitch.Controls.Add(this.labelPotential);
            this.groupBoxStitch.Controls.Add(this.labelColumns);
            this.groupBoxStitch.Controls.Add(this.labelFlexibility);
            this.groupBoxStitch.Controls.Add(this.textBoxFlexibility);
            this.groupBoxStitch.Controls.Add(this.labelMatchingRows);
            this.groupBoxStitch.Controls.Add(this.textBoxMatchingRows);
            this.groupBoxStitch.Controls.Add(this.textBoxColumns);
            this.groupBoxStitch.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBoxStitch.Location = new System.Drawing.Point(10, 12);
            this.groupBoxStitch.Name = "groupBoxStitch";
            this.groupBoxStitch.Size = new System.Drawing.Size(280, 185);
            this.groupBoxStitch.TabIndex = 7;
            this.groupBoxStitch.TabStop = false;
            this.groupBoxStitch.Text = "Stitching";
            this.groupBoxStitch.DragDrop += new System.Windows.Forms.DragEventHandler(this.Stitch_DragDrop);
            this.groupBoxStitch.DragEnter += new System.Windows.Forms.DragEventHandler(this.Stitch_DragEnter);
            // 
            // buttonDescription
            // 
            this.buttonDescription.Enabled = false;
            this.buttonDescription.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonDescription.Location = new System.Drawing.Point(6, 154);
            this.buttonDescription.Name = "buttonDescription";
            this.buttonDescription.Size = new System.Drawing.Size(106, 23);
            this.buttonDescription.TabIndex = 13;
            this.buttonDescription.Text = "Description Files";
            this.buttonDescription.UseVisualStyleBackColor = true;
            this.buttonDescription.Click += new System.EventHandler(this.buttonDescription_Click);
            // 
            // labelFolderTitle
            // 
            this.labelFolderTitle.AutoSize = true;
            this.labelFolderTitle.Cursor = System.Windows.Forms.Cursors.Hand;
            this.labelFolderTitle.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Underline, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelFolderTitle.Location = new System.Drawing.Point(10, 20);
            this.labelFolderTitle.Name = "labelFolderTitle";
            this.labelFolderTitle.Size = new System.Drawing.Size(42, 13);
            this.labelFolderTitle.TabIndex = 10;
            this.labelFolderTitle.Text = "Folder :";
            this.labelFolderTitle.Click += new System.EventHandler(this.labelFolderTitle_Click);
            // 
            // labelImageBottom
            // 
            this.labelImageBottom.AutoSize = true;
            this.labelImageBottom.Cursor = System.Windows.Forms.Cursors.Default;
            this.labelImageBottom.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelImageBottom.Location = new System.Drawing.Point(54, 60);
            this.labelImageBottom.Name = "labelImageBottom";
            this.labelImageBottom.Size = new System.Drawing.Size(16, 13);
            this.labelImageBottom.TabIndex = 9;
            this.labelImageBottom.Text = "...";
            // 
            // labelImageTop
            // 
            this.labelImageTop.AutoSize = true;
            this.labelImageTop.Cursor = System.Windows.Forms.Cursors.Default;
            this.labelImageTop.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelImageTop.Location = new System.Drawing.Point(54, 40);
            this.labelImageTop.Name = "labelImageTop";
            this.labelImageTop.Size = new System.Drawing.Size(171, 13);
            this.labelImageTop.TabIndex = 8;
            this.labelImageTop.Text = "Click on \"Folder\" to Switch Images";
            // 
            // textBoxPatternStitch
            // 
            this.textBoxPatternStitch.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBoxPatternStitch.Location = new System.Drawing.Point(51, 128);
            this.textBoxPatternStitch.Name = "textBoxPatternStitch";
            this.textBoxPatternStitch.Size = new System.Drawing.Size(220, 20);
            this.textBoxPatternStitch.TabIndex = 8;
            this.textBoxPatternStitch.TabStop = false;
            // 
            // labelOutputStitch
            // 
            this.labelOutputStitch.AutoSize = true;
            this.labelOutputStitch.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelOutputStitch.Location = new System.Drawing.Point(6, 131);
            this.labelOutputStitch.Name = "labelOutputStitch";
            this.labelOutputStitch.Size = new System.Drawing.Size(39, 13);
            this.labelOutputStitch.TabIndex = 3;
            this.labelOutputStitch.Text = "Output";
            // 
            // textBoxPotential
            // 
            this.textBoxPotential.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBoxPotential.Location = new System.Drawing.Point(247, 104);
            this.textBoxPotential.Name = "textBoxPotential";
            this.textBoxPotential.Size = new System.Drawing.Size(24, 20);
            this.textBoxPotential.TabIndex = 4;
            this.textBoxPotential.TabStop = false;
            this.textBoxPotential.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // labelPotential
            // 
            this.labelPotential.AutoSize = true;
            this.labelPotential.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelPotential.Location = new System.Drawing.Point(196, 107);
            this.labelPotential.Name = "labelPotential";
            this.labelPotential.Size = new System.Drawing.Size(48, 13);
            this.labelPotential.TabIndex = 12;
            this.labelPotential.Text = "Potential";
            // 
            // labelColumns
            // 
            this.labelColumns.AutoSize = true;
            this.labelColumns.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelColumns.Location = new System.Drawing.Point(54, 83);
            this.labelColumns.Name = "labelColumns";
            this.labelColumns.Size = new System.Drawing.Size(100, 13);
            this.labelColumns.TabIndex = 4;
            this.labelColumns.Text = "Columns to work on";
            // 
            // labelFlexibility
            // 
            this.labelFlexibility.AutoSize = true;
            this.labelFlexibility.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelFlexibility.Location = new System.Drawing.Point(196, 83);
            this.labelFlexibility.Name = "labelFlexibility";
            this.labelFlexibility.Size = new System.Drawing.Size(48, 13);
            this.labelFlexibility.TabIndex = 7;
            this.labelFlexibility.Text = "Flexibility";
            // 
            // textBoxFlexibility
            // 
            this.textBoxFlexibility.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBoxFlexibility.Location = new System.Drawing.Point(247, 80);
            this.textBoxFlexibility.Name = "textBoxFlexibility";
            this.textBoxFlexibility.Size = new System.Drawing.Size(24, 20);
            this.textBoxFlexibility.TabIndex = 7;
            this.textBoxFlexibility.TabStop = false;
            this.textBoxFlexibility.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // labelMatchingRows
            // 
            this.labelMatchingRows.AutoSize = true;
            this.labelMatchingRows.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelMatchingRows.Location = new System.Drawing.Point(53, 107);
            this.labelMatchingRows.Name = "labelMatchingRows";
            this.labelMatchingRows.Size = new System.Drawing.Size(101, 13);
            this.labelMatchingRows.TabIndex = 11;
            this.labelMatchingRows.Text = "Min Matching Rows";
            // 
            // textBoxMatchingRows
            // 
            this.textBoxMatchingRows.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBoxMatchingRows.Location = new System.Drawing.Point(157, 104);
            this.textBoxMatchingRows.Name = "textBoxMatchingRows";
            this.textBoxMatchingRows.Size = new System.Drawing.Size(28, 20);
            this.textBoxMatchingRows.TabIndex = 3;
            this.textBoxMatchingRows.TabStop = false;
            this.textBoxMatchingRows.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // textBoxColumns
            // 
            this.textBoxColumns.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBoxColumns.Location = new System.Drawing.Point(157, 80);
            this.textBoxColumns.Name = "textBoxColumns";
            this.textBoxColumns.Size = new System.Drawing.Size(26, 20);
            this.textBoxColumns.TabIndex = 6;
            this.textBoxColumns.TabStop = false;
            this.textBoxColumns.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // textBoxPatternSpaces
            // 
            this.textBoxPatternSpaces.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBoxPatternSpaces.Location = new System.Drawing.Point(51, 42);
            this.textBoxPatternSpaces.Name = "textBoxPatternSpaces";
            this.textBoxPatternSpaces.Size = new System.Drawing.Size(220, 20);
            this.textBoxPatternSpaces.TabIndex = 21;
            this.textBoxPatternSpaces.TabStop = false;
            // 
            // labelOutputSpaces
            // 
            this.labelOutputSpaces.AutoSize = true;
            this.labelOutputSpaces.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelOutputSpaces.Location = new System.Drawing.Point(6, 45);
            this.labelOutputSpaces.Name = "labelOutputSpaces";
            this.labelOutputSpaces.Size = new System.Drawing.Size(39, 13);
            this.labelOutputSpaces.TabIndex = 20;
            this.labelOutputSpaces.Text = "Output";
            // 
            // labelCleaning
            // 
            this.labelCleaning.AutoSize = true;
            this.labelCleaning.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelCleaning.Location = new System.Drawing.Point(6, 70);
            this.labelCleaning.Name = "labelCleaning";
            this.labelCleaning.Size = new System.Drawing.Size(100, 13);
            this.labelCleaning.TabIndex = 19;
            this.labelCleaning.Text = "Spaces Bigger than";
            // 
            // textBoxSpacesMax
            // 
            this.textBoxSpacesMax.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBoxSpacesMax.Location = new System.Drawing.Point(112, 67);
            this.textBoxSpacesMax.Name = "textBoxSpacesMax";
            this.textBoxSpacesMax.Size = new System.Drawing.Size(25, 20);
            this.textBoxSpacesMax.TabIndex = 14;
            this.textBoxSpacesMax.TabStop = false;
            this.textBoxSpacesMax.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // labelInfo1
            // 
            this.labelInfo1.Location = new System.Drawing.Point(9, 305);
            this.labelInfo1.Name = "labelInfo1";
            this.labelInfo1.Size = new System.Drawing.Size(279, 18);
            this.labelInfo1.TabIndex = 10;
            this.labelInfo1.Text = "No Tasks";
            this.labelInfo1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // labelInfo2
            // 
            this.labelInfo2.Location = new System.Drawing.Point(9, 325);
            this.labelInfo2.Name = "labelInfo2";
            this.labelInfo2.Size = new System.Drawing.Size(279, 18);
            this.labelInfo2.TabIndex = 11;
            this.labelInfo2.Text = "Select Images";
            this.labelInfo2.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // groupBoxCleaning
            // 
            this.groupBoxCleaning.AllowDrop = true;
            this.groupBoxCleaning.Controls.Add(this.labelImageClean);
            this.groupBoxCleaning.Controls.Add(this.label2);
            this.groupBoxCleaning.Controls.Add(this.buttonClean);
            this.groupBoxCleaning.Controls.Add(this.textBoxSpacesMax);
            this.groupBoxCleaning.Controls.Add(this.textBoxPatternSpaces);
            this.groupBoxCleaning.Controls.Add(this.labelCleaning);
            this.groupBoxCleaning.Controls.Add(this.labelOutputSpaces);
            this.groupBoxCleaning.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBoxCleaning.Location = new System.Drawing.Point(10, 203);
            this.groupBoxCleaning.Name = "groupBoxCleaning";
            this.groupBoxCleaning.Size = new System.Drawing.Size(280, 97);
            this.groupBoxCleaning.TabIndex = 12;
            this.groupBoxCleaning.TabStop = false;
            this.groupBoxCleaning.Text = "Cleaning";
            this.groupBoxCleaning.DragDrop += new System.Windows.Forms.DragEventHandler(this.Clean_DragDrop);
            this.groupBoxCleaning.DragEnter += new System.Windows.Forms.DragEventHandler(this.Clean_DragEnter);
            // 
            // labelImageClean
            // 
            this.labelImageClean.AutoSize = true;
            this.labelImageClean.Cursor = System.Windows.Forms.Cursors.Default;
            this.labelImageClean.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelImageClean.Location = new System.Drawing.Point(48, 21);
            this.labelImageClean.Name = "labelImageClean";
            this.labelImageClean.Size = new System.Drawing.Size(178, 13);
            this.labelImageClean.TabIndex = 14;
            this.labelImageClean.Text = "Drag && Drop an PNG image to clean";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Cursor = System.Windows.Forms.Cursors.Default;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Underline, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(6, 21);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(42, 13);
            this.label2.TabIndex = 13;
            this.label2.Text = "Image :";
            // 
            // buttonClean
            // 
            this.buttonClean.Enabled = false;
            this.buttonClean.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonClean.Location = new System.Drawing.Point(208, 68);
            this.buttonClean.Name = "buttonClean";
            this.buttonClean.Size = new System.Drawing.Size(63, 23);
            this.buttonClean.TabIndex = 18;
            this.buttonClean.Text = "Clean";
            this.buttonClean.UseVisualStyleBackColor = true;
            this.buttonClean.Click += new System.EventHandler(this.buttonClean_Click);
            // 
            // MainForm
            // 
            this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
            this.ClientSize = new System.Drawing.Size(300, 351);
            this.Controls.Add(this.groupBoxCleaning);
            this.Controls.Add(this.labelInfo2);
            this.Controls.Add(this.labelInfo1);
            this.Controls.Add(this.groupBoxStitch);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "MainForm";
            this.Text = "ScreenStitch";
            this.groupBoxStitch.ResumeLayout(false);
            this.groupBoxStitch.PerformLayout();
            this.groupBoxCleaning.ResumeLayout(false);
            this.groupBoxCleaning.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion


        private Button buttonStitch;
        private Label labelFolderValue;
        private Label labelTextTop;
        private Label labelTextBottom;
        private GroupBox groupBoxStitch;
        private TextBox textBoxPatternStitch;
        private Label labelOutputStitch;
        private Label labelFlexibility;
        private TextBox textBoxFlexibility;
        private TextBox textBoxColumns;
        private Label labelColumns;
        private Label labelMatchingRows;
        private TextBox textBoxMatchingRows;
        private Label labelImageTop;
        private Label labelInfo1;
        private TextBox textBoxPotential;
        private Label labelPotential;
        private TextBox textBoxSpacesMax;
        private Label labelInfo2;
        private Label labelFolderTitle;
        private TextBox textBoxPatternSpaces;
        private Label labelOutputSpaces;
        private Label labelCleaning;
        private GroupBox groupBoxCleaning;
        private Button buttonClean;
        private Button buttonDescription;
        private Label labelImageBottom;
        private Label labelImageClean;
        private Label label2;

    }
}

