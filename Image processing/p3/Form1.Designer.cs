namespace p3
{
    partial class Form1
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            algorithmsGroupBox = new GroupBox();
            loadButton = new Button();
            refreshButton = new Button();
            popularityAlgorithmButton = new RadioButton();
            orderedDitheringRelativeButton = new RadioButton();
            orderedDitheringRandomButton = new RadioButton();
            errorDiffusionDitheringButton = new RadioButton();
            averageDitheringButton = new RadioButton();
            paramsDitheringGroupBox = new GroupBox();
            labelKb = new Label();
            labelKg = new Label();
            labelKr = new Label();
            KbControl = new NumericUpDown();
            KgControl = new NumericUpDown();
            KrControl = new NumericUpDown();
            paramsPopularityGroupBox = new GroupBox();
            labelK = new Label();
            KControl = new NumericUpDown();
            originalPictureBox = new PictureBox();
            reductionPictureBox = new PictureBox();
            labelOriginal = new Label();
            labelReduction = new Label();
            openFileDialog = new OpenFileDialog();
            createButton = new Button();
            algorithmsGroupBox.SuspendLayout();
            paramsDitheringGroupBox.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)KbControl).BeginInit();
            ((System.ComponentModel.ISupportInitialize)KgControl).BeginInit();
            ((System.ComponentModel.ISupportInitialize)KrControl).BeginInit();
            paramsPopularityGroupBox.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)KControl).BeginInit();
            ((System.ComponentModel.ISupportInitialize)originalPictureBox).BeginInit();
            ((System.ComponentModel.ISupportInitialize)reductionPictureBox).BeginInit();
            SuspendLayout();
            // 
            // algorithmsGroupBox
            // 
            algorithmsGroupBox.Controls.Add(loadButton);
            algorithmsGroupBox.Controls.Add(refreshButton);
            algorithmsGroupBox.Controls.Add(popularityAlgorithmButton);
            algorithmsGroupBox.Controls.Add(orderedDitheringRelativeButton);
            algorithmsGroupBox.Controls.Add(orderedDitheringRandomButton);
            algorithmsGroupBox.Controls.Add(errorDiffusionDitheringButton);
            algorithmsGroupBox.Controls.Add(averageDitheringButton);
            algorithmsGroupBox.Location = new Point(12, 12);
            algorithmsGroupBox.Name = "algorithmsGroupBox";
            algorithmsGroupBox.Size = new Size(236, 232);
            algorithmsGroupBox.TabIndex = 0;
            algorithmsGroupBox.TabStop = false;
            algorithmsGroupBox.Text = "Algorithms";
            // 
            // loadButton
            // 
            loadButton.Location = new Point(10, 186);
            loadButton.Name = "loadButton";
            loadButton.Size = new Size(106, 29);
            loadButton.TabIndex = 6;
            loadButton.Text = "Load Picture";
            loadButton.UseVisualStyleBackColor = true;
            loadButton.Click += loadButton_Click;
            // 
            // refreshButton
            // 
            refreshButton.Location = new Point(122, 186);
            refreshButton.Name = "refreshButton";
            refreshButton.Size = new Size(103, 29);
            refreshButton.TabIndex = 5;
            refreshButton.Text = "Refresh";
            refreshButton.UseVisualStyleBackColor = true;
            refreshButton.Click += refreshButton_Click;
            // 
            // popularityAlgorithmButton
            // 
            popularityAlgorithmButton.AutoSize = true;
            popularityAlgorithmButton.Location = new Point(6, 146);
            popularityAlgorithmButton.Name = "popularityAlgorithmButton";
            popularityAlgorithmButton.Size = new Size(165, 24);
            popularityAlgorithmButton.TabIndex = 4;
            popularityAlgorithmButton.TabStop = true;
            popularityAlgorithmButton.Text = "Popularity algorithm";
            popularityAlgorithmButton.UseVisualStyleBackColor = true;
            // 
            // orderedDitheringRelativeButton
            // 
            orderedDitheringRelativeButton.AutoSize = true;
            orderedDitheringRelativeButton.Location = new Point(6, 116);
            orderedDitheringRelativeButton.Name = "orderedDitheringRelativeButton";
            orderedDitheringRelativeButton.Size = new Size(202, 24);
            orderedDitheringRelativeButton.TabIndex = 3;
            orderedDitheringRelativeButton.TabStop = true;
            orderedDitheringRelativeButton.Text = "Ordered dithering relative";
            orderedDitheringRelativeButton.UseVisualStyleBackColor = true;
            // 
            // orderedDitheringRandomButton
            // 
            orderedDitheringRandomButton.AutoSize = true;
            orderedDitheringRandomButton.Location = new Point(6, 86);
            orderedDitheringRandomButton.Name = "orderedDitheringRandomButton";
            orderedDitheringRandomButton.Size = new Size(205, 24);
            orderedDitheringRandomButton.TabIndex = 2;
            orderedDitheringRandomButton.TabStop = true;
            orderedDitheringRandomButton.Text = "Ordered dithering random";
            orderedDitheringRandomButton.UseVisualStyleBackColor = true;
            // 
            // errorDiffusionDitheringButton
            // 
            errorDiffusionDitheringButton.AutoSize = true;
            errorDiffusionDitheringButton.Location = new Point(6, 56);
            errorDiffusionDitheringButton.Name = "errorDiffusionDitheringButton";
            errorDiffusionDitheringButton.Size = new Size(188, 24);
            errorDiffusionDitheringButton.TabIndex = 1;
            errorDiffusionDitheringButton.TabStop = true;
            errorDiffusionDitheringButton.Text = "Error diffusion dithering";
            errorDiffusionDitheringButton.UseVisualStyleBackColor = true;
            // 
            // averageDitheringButton
            // 
            averageDitheringButton.AutoSize = true;
            averageDitheringButton.Location = new Point(6, 26);
            averageDitheringButton.Name = "averageDitheringButton";
            averageDitheringButton.Size = new Size(149, 24);
            averageDitheringButton.TabIndex = 0;
            averageDitheringButton.TabStop = true;
            averageDitheringButton.Text = "Average dithering";
            averageDitheringButton.UseVisualStyleBackColor = true;
            // 
            // paramsDitheringGroupBox
            // 
            paramsDitheringGroupBox.Controls.Add(labelKb);
            paramsDitheringGroupBox.Controls.Add(labelKg);
            paramsDitheringGroupBox.Controls.Add(labelKr);
            paramsDitheringGroupBox.Controls.Add(KbControl);
            paramsDitheringGroupBox.Controls.Add(KgControl);
            paramsDitheringGroupBox.Controls.Add(KrControl);
            paramsDitheringGroupBox.Location = new Point(12, 250);
            paramsDitheringGroupBox.Name = "paramsDitheringGroupBox";
            paramsDitheringGroupBox.Size = new Size(236, 175);
            paramsDitheringGroupBox.TabIndex = 1;
            paramsDitheringGroupBox.TabStop = false;
            paramsDitheringGroupBox.Text = "Params for dithering";
            // 
            // labelKb
            // 
            labelKb.AutoSize = true;
            labelKb.Location = new Point(10, 102);
            labelKb.Name = "labelKb";
            labelKb.Size = new Size(27, 20);
            labelKb.TabIndex = 5;
            labelKb.Text = "Kb";
            // 
            // labelKg
            // 
            labelKg.AutoSize = true;
            labelKg.Location = new Point(10, 69);
            labelKg.Name = "labelKg";
            labelKg.Size = new Size(27, 20);
            labelKg.TabIndex = 4;
            labelKg.Text = "Kg";
            // 
            // labelKr
            // 
            labelKr.AutoSize = true;
            labelKr.Location = new Point(10, 34);
            labelKr.Name = "labelKr";
            labelKr.Size = new Size(23, 20);
            labelKr.TabIndex = 3;
            labelKr.Text = "Kr";
            // 
            // KbControl
            // 
            KbControl.Location = new Point(43, 100);
            KbControl.Maximum = new decimal(new int[] { 255, 0, 0, 0 });
            KbControl.Minimum = new decimal(new int[] { 2, 0, 0, 0 });
            KbControl.Name = "KbControl";
            KbControl.Size = new Size(150, 27);
            KbControl.TabIndex = 2;
            KbControl.Value = new decimal(new int[] { 2, 0, 0, 0 });
            // 
            // KgControl
            // 
            KgControl.Location = new Point(43, 67);
            KgControl.Maximum = new decimal(new int[] { 255, 0, 0, 0 });
            KgControl.Minimum = new decimal(new int[] { 2, 0, 0, 0 });
            KgControl.Name = "KgControl";
            KgControl.Size = new Size(150, 27);
            KgControl.TabIndex = 1;
            KgControl.Value = new decimal(new int[] { 2, 0, 0, 0 });
            // 
            // KrControl
            // 
            KrControl.Location = new Point(43, 32);
            KrControl.Maximum = new decimal(new int[] { 255, 0, 0, 0 });
            KrControl.Minimum = new decimal(new int[] { 2, 0, 0, 0 });
            KrControl.Name = "KrControl";
            KrControl.Size = new Size(150, 27);
            KrControl.TabIndex = 0;
            KrControl.Value = new decimal(new int[] { 2, 0, 0, 0 });
            // 
            // paramsPopularityGroupBox
            // 
            paramsPopularityGroupBox.Controls.Add(labelK);
            paramsPopularityGroupBox.Controls.Add(KControl);
            paramsPopularityGroupBox.Location = new Point(12, 433);
            paramsPopularityGroupBox.Name = "paramsPopularityGroupBox";
            paramsPopularityGroupBox.Size = new Size(236, 72);
            paramsPopularityGroupBox.TabIndex = 2;
            paramsPopularityGroupBox.TabStop = false;
            paramsPopularityGroupBox.Text = "Params for popularity algorithm";
            // 
            // labelK
            // 
            labelK.AutoSize = true;
            labelK.Location = new Point(15, 29);
            labelK.Name = "labelK";
            labelK.Size = new Size(18, 20);
            labelK.TabIndex = 4;
            labelK.Text = "K";
            // 
            // KControl
            // 
            KControl.Location = new Point(43, 27);
            KControl.Maximum = new decimal(new int[] { 2000, 0, 0, 0 });
            KControl.Minimum = new decimal(new int[] { 1, 0, 0, 0 });
            KControl.Name = "KControl";
            KControl.Size = new Size(150, 27);
            KControl.TabIndex = 1;
            KControl.Value = new decimal(new int[] { 100, 0, 0, 0 });
            // 
            // originalPictureBox
            // 
            originalPictureBox.Location = new Point(268, 38);
            originalPictureBox.Name = "originalPictureBox";
            originalPictureBox.Size = new Size(495, 498);
            originalPictureBox.TabIndex = 3;
            originalPictureBox.TabStop = false;
            // 
            // reductionPictureBox
            // 
            reductionPictureBox.Location = new Point(769, 38);
            reductionPictureBox.Name = "reductionPictureBox";
            reductionPictureBox.Size = new Size(495, 498);
            reductionPictureBox.TabIndex = 4;
            reductionPictureBox.TabStop = false;
            reductionPictureBox.Paint += reductionPictureBox_Paint;
            // 
            // labelOriginal
            // 
            labelOriginal.AutoSize = true;
            labelOriginal.Location = new Point(268, 15);
            labelOriginal.Name = "labelOriginal";
            labelOriginal.Size = new Size(111, 20);
            labelOriginal.TabIndex = 5;
            labelOriginal.Text = "Original image:";
            // 
            // labelReduction
            // 
            labelReduction.AutoSize = true;
            labelReduction.Location = new Point(769, 15);
            labelReduction.Name = "labelReduction";
            labelReduction.Size = new Size(225, 20);
            labelReduction.TabIndex = 6;
            labelReduction.Text = "Image after reduction algorithm:";
            // 
            // openFileDialog
            // 
            openFileDialog.FileName = "openFileDialog1";
            // 
            // createButton
            // 
            createButton.Location = new Point(22, 527);
            createButton.Name = "createButton";
            createButton.Size = new Size(94, 29);
            createButton.TabIndex = 7;
            createButton.Text = "Create";
            createButton.UseVisualStyleBackColor = true;
            createButton.Click += createButton_Click;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1273, 591);
            Controls.Add(createButton);
            Controls.Add(labelReduction);
            Controls.Add(labelOriginal);
            Controls.Add(reductionPictureBox);
            Controls.Add(originalPictureBox);
            Controls.Add(paramsPopularityGroupBox);
            Controls.Add(paramsDitheringGroupBox);
            Controls.Add(algorithmsGroupBox);
            Name = "Form1";
            Text = "Color reduction algorithms";
            algorithmsGroupBox.ResumeLayout(false);
            algorithmsGroupBox.PerformLayout();
            paramsDitheringGroupBox.ResumeLayout(false);
            paramsDitheringGroupBox.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)KbControl).EndInit();
            ((System.ComponentModel.ISupportInitialize)KgControl).EndInit();
            ((System.ComponentModel.ISupportInitialize)KrControl).EndInit();
            paramsPopularityGroupBox.ResumeLayout(false);
            paramsPopularityGroupBox.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)KControl).EndInit();
            ((System.ComponentModel.ISupportInitialize)originalPictureBox).EndInit();
            ((System.ComponentModel.ISupportInitialize)reductionPictureBox).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private GroupBox algorithmsGroupBox;
        private RadioButton popularityAlgorithmButton;
        private RadioButton orderedDitheringRelativeButton;
        private RadioButton orderedDitheringRandomButton;
        private RadioButton errorDiffusionDitheringButton;
        private RadioButton averageDitheringButton;
        private GroupBox paramsDitheringGroupBox;
        private Label labelKb;
        private Label labelKg;
        private Label labelKr;
        private NumericUpDown KbControl;
        private NumericUpDown KgControl;
        private NumericUpDown KrControl;
        private GroupBox paramsPopularityGroupBox;
        private Label labelK;
        private NumericUpDown KControl;
        private PictureBox originalPictureBox;
        private PictureBox reductionPictureBox;
        private Label labelOriginal;
        private Label labelReduction;
        private Button loadButton;
        private Button refreshButton;
        private OpenFileDialog openFileDialog;
        private Button createButton;
    }
}