namespace p2
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
            colorDialog = new ColorDialog();
            openFileDialog = new OpenFileDialog();
            Menu = new GroupBox();
            ChangeControlButton = new Button();
            label8 = new Label();
            label7 = new Label();
            label6 = new Label();
            zPointControl = new TextBox();
            yPointControl = new TextBox();
            xPointControl = new TextBox();
            label5 = new Label();
            openFileButton = new Button();
            LightButton = new Button();
            ChooseColorButton = new Button();
            animationStartButton = new Button();
            drawTrianglesBox = new CheckBox();
            YtriangulationTrackBar = new TrackBar();
            mTrackBar = new TrackBar();
            label4 = new Label();
            label3 = new Label();
            label2 = new Label();
            label1 = new Label();
            ksTrackBar = new TrackBar();
            kdTrackBar = new TrackBar();
            XtriangulationTrackBar = new TrackBar();
            Bitmap = new PictureBox();
            splitContainer1 = new SplitContainer();
            animationStopButton = new Button();
            Menu.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)YtriangulationTrackBar).BeginInit();
            ((System.ComponentModel.ISupportInitialize)mTrackBar).BeginInit();
            ((System.ComponentModel.ISupportInitialize)ksTrackBar).BeginInit();
            ((System.ComponentModel.ISupportInitialize)kdTrackBar).BeginInit();
            ((System.ComponentModel.ISupportInitialize)XtriangulationTrackBar).BeginInit();
            ((System.ComponentModel.ISupportInitialize)Bitmap).BeginInit();
            ((System.ComponentModel.ISupportInitialize)splitContainer1).BeginInit();
            splitContainer1.Panel1.SuspendLayout();
            splitContainer1.Panel2.SuspendLayout();
            splitContainer1.SuspendLayout();
            SuspendLayout();
            // 
            // openFileDialog
            // 
            openFileDialog.FileName = "openFileDialog";
            // 
            // Menu
            // 
            Menu.Controls.Add(animationStopButton);
            Menu.Controls.Add(ChangeControlButton);
            Menu.Controls.Add(label8);
            Menu.Controls.Add(label7);
            Menu.Controls.Add(label6);
            Menu.Controls.Add(zPointControl);
            Menu.Controls.Add(yPointControl);
            Menu.Controls.Add(xPointControl);
            Menu.Controls.Add(label5);
            Menu.Controls.Add(openFileButton);
            Menu.Controls.Add(LightButton);
            Menu.Controls.Add(ChooseColorButton);
            Menu.Controls.Add(animationStartButton);
            Menu.Controls.Add(drawTrianglesBox);
            Menu.Controls.Add(YtriangulationTrackBar);
            Menu.Controls.Add(mTrackBar);
            Menu.Controls.Add(label4);
            Menu.Controls.Add(label3);
            Menu.Controls.Add(label2);
            Menu.Controls.Add(label1);
            Menu.Controls.Add(ksTrackBar);
            Menu.Controls.Add(kdTrackBar);
            Menu.Controls.Add(XtriangulationTrackBar);
            Menu.Dock = DockStyle.Fill;
            Menu.Location = new Point(0, 0);
            Menu.Name = "Menu";
            Menu.Size = new Size(224, 600);
            Menu.TabIndex = 0;
            Menu.TabStop = false;
            Menu.Text = "Menu";
            // 
            // ChangeControlButton
            // 
            ChangeControlButton.Location = new Point(106, 522);
            ChangeControlButton.Name = "ChangeControlButton";
            ChangeControlButton.Size = new Size(94, 29);
            ChangeControlButton.TabIndex = 21;
            ChangeControlButton.Text = "Zmień";
            ChangeControlButton.UseVisualStyleBackColor = true;
            ChangeControlButton.Click += ChangeControlButton_Click;
            // 
            // label8
            // 
            label8.AutoSize = true;
            label8.Location = new Point(82, 552);
            label8.Name = "label8";
            label8.Size = new Size(16, 20);
            label8.TabIndex = 20;
            label8.Text = "z";
            // 
            // label7
            // 
            label7.AutoSize = true;
            label7.Location = new Point(49, 552);
            label7.Name = "label7";
            label7.Size = new Size(16, 20);
            label7.TabIndex = 19;
            label7.Text = "y";
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Location = new Point(18, 552);
            label6.Name = "label6";
            label6.Size = new Size(16, 20);
            label6.TabIndex = 18;
            label6.Text = "x";
            // 
            // zPointControl
            // 
            zPointControl.Location = new Point(69, 522);
            zPointControl.Name = "zPointControl";
            zPointControl.Size = new Size(29, 27);
            zPointControl.TabIndex = 17;
            // 
            // yPointControl
            // 
            yPointControl.Location = new Point(36, 522);
            yPointControl.Name = "yPointControl";
            yPointControl.Size = new Size(29, 27);
            yPointControl.TabIndex = 16;
            // 
            // xPointControl
            // 
            xPointControl.Location = new Point(6, 522);
            xPointControl.Name = "xPointControl";
            xPointControl.Size = new Size(29, 27);
            xPointControl.TabIndex = 15;
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Location = new Point(6, 496);
            label5.Name = "label5";
            label5.Size = new Size(114, 20);
            label5.TabIndex = 14;
            label5.Text = "Punkt kontrolny:";
            // 
            // openFileButton
            // 
            openFileButton.Location = new Point(4, 228);
            openFileButton.Name = "openFileButton";
            openFileButton.Size = new Size(116, 29);
            openFileButton.TabIndex = 13;
            openFileButton.Text = "Wczytaj obraz";
            openFileButton.UseVisualStyleBackColor = true;
            openFileButton.Click += openFileButton_Click;
            // 
            // LightButton
            // 
            LightButton.Location = new Point(106, 158);
            LightButton.Name = "LightButton";
            LightButton.Size = new Size(106, 29);
            LightButton.TabIndex = 12;
            LightButton.Text = "Kolor światła";
            LightButton.UseVisualStyleBackColor = true;
            LightButton.Click += LightButton_Click;
            // 
            // ChooseColorButton
            // 
            ChooseColorButton.Location = new Point(3, 158);
            ChooseColorButton.Name = "ChooseColorButton";
            ChooseColorButton.Size = new Size(92, 29);
            ChooseColorButton.TabIndex = 11;
            ChooseColorButton.Text = "Kolor tła";
            ChooseColorButton.UseVisualStyleBackColor = true;
            ChooseColorButton.Click += ChooseColorButton_Click;
            // 
            // animationStartButton
            // 
            animationStartButton.Location = new Point(4, 193);
            animationStartButton.Name = "animationStartButton";
            animationStartButton.Size = new Size(94, 29);
            animationStartButton.TabIndex = 10;
            animationStartButton.Text = "Animacja";
            animationStartButton.UseVisualStyleBackColor = true;
            animationStartButton.Click += animationStartButton_Click;
            // 
            // drawTrianglesBox
            // 
            drawTrianglesBox.AutoSize = true;
            drawTrianglesBox.Location = new Point(18, 128);
            drawTrianglesBox.Name = "drawTrianglesBox";
            drawTrianglesBox.Size = new Size(111, 24);
            drawTrianglesBox.TabIndex = 9;
            drawTrianglesBox.Text = "Pokaż siatkę";
            drawTrianglesBox.UseVisualStyleBackColor = true;
            drawTrianglesBox.CheckedChanged += drawTrianglesBox_CheckedChanged;
            // 
            // YtriangulationTrackBar
            // 
            YtriangulationTrackBar.Location = new Point(18, 84);
            YtriangulationTrackBar.Maximum = 50;
            YtriangulationTrackBar.Minimum = 1;
            YtriangulationTrackBar.Name = "YtriangulationTrackBar";
            YtriangulationTrackBar.Size = new Size(130, 56);
            YtriangulationTrackBar.TabIndex = 8;
            YtriangulationTrackBar.Value = 5;
            YtriangulationTrackBar.ValueChanged += YtriangulationTrackBar_ValueChanged;
            // 
            // mTrackBar
            // 
            mTrackBar.Location = new Point(6, 460);
            mTrackBar.Maximum = 100;
            mTrackBar.Name = "mTrackBar";
            mTrackBar.Size = new Size(127, 56);
            mTrackBar.TabIndex = 7;
            mTrackBar.Value = 1;
            mTrackBar.ValueChanged += mTrackBar_ValueChanged;
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(12, 437);
            label4.Name = "label4";
            label4.Size = new Size(25, 20);
            label4.TabIndex = 6;
            label4.Text = "m:";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(12, 355);
            label3.Name = "label3";
            label3.Size = new Size(25, 20);
            label3.TabIndex = 5;
            label3.Text = "ks:";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(12, 278);
            label2.Name = "label2";
            label2.Size = new Size(28, 20);
            label2.TabIndex = 4;
            label2.Text = "kd:";
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(18, 29);
            label1.Name = "label1";
            label1.Size = new Size(92, 20);
            label1.TabIndex = 3;
            label1.Text = "Triangulacja:";
            // 
            // ksTrackBar
            // 
            ksTrackBar.Location = new Point(3, 378);
            ksTrackBar.Name = "ksTrackBar";
            ksTrackBar.Size = new Size(130, 56);
            ksTrackBar.TabIndex = 2;
            ksTrackBar.Value = 7;
            ksTrackBar.ValueChanged += ksTrackBar_ValueChanged;
            // 
            // kdTrackBar
            // 
            kdTrackBar.Location = new Point(3, 301);
            kdTrackBar.Name = "kdTrackBar";
            kdTrackBar.Size = new Size(130, 56);
            kdTrackBar.TabIndex = 1;
            kdTrackBar.Value = 7;
            kdTrackBar.ValueChanged += kdTrackBar_ValueChanged;
            // 
            // XtriangulationTrackBar
            // 
            XtriangulationTrackBar.Location = new Point(18, 52);
            XtriangulationTrackBar.Maximum = 50;
            XtriangulationTrackBar.Minimum = 1;
            XtriangulationTrackBar.Name = "XtriangulationTrackBar";
            XtriangulationTrackBar.Size = new Size(130, 56);
            XtriangulationTrackBar.TabIndex = 0;
            XtriangulationTrackBar.Value = 5;
            XtriangulationTrackBar.ValueChanged += XtriangulationTrackBar_ValueChanged;
            // 
            // Bitmap
            // 
            Bitmap.Location = new Point(0, 0);
            Bitmap.Name = "Bitmap";
            Bitmap.Size = new Size(800, 600);
            Bitmap.TabIndex = 0;
            Bitmap.TabStop = false;
            Bitmap.Paint += Bitmap_Paint;
            // 
            // splitContainer1
            // 
            splitContainer1.Dock = DockStyle.Fill;
            splitContainer1.Location = new Point(0, 0);
            splitContainer1.Name = "splitContainer1";
            // 
            // splitContainer1.Panel1
            // 
            splitContainer1.Panel1.Controls.Add(Bitmap);
            // 
            // splitContainer1.Panel2
            // 
            splitContainer1.Panel2.Controls.Add(Menu);
            splitContainer1.Size = new Size(1028, 600);
            splitContainer1.SplitterDistance = 800;
            splitContainer1.TabIndex = 0;
            // 
            // animationStopButton
            // 
            animationStopButton.Location = new Point(106, 193);
            animationStopButton.Name = "animationStopButton";
            animationStopButton.Size = new Size(106, 29);
            animationStopButton.TabIndex = 22;
            animationStopButton.Text = "Anim. stop";
            animationStopButton.UseVisualStyleBackColor = true;
            animationStopButton.Click += animationStopButton_Click;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1028, 600);
            Controls.Add(splitContainer1);
            Name = "Form1";
            Text = "Model Oświetlenia";
            Menu.ResumeLayout(false);
            Menu.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)YtriangulationTrackBar).EndInit();
            ((System.ComponentModel.ISupportInitialize)mTrackBar).EndInit();
            ((System.ComponentModel.ISupportInitialize)ksTrackBar).EndInit();
            ((System.ComponentModel.ISupportInitialize)kdTrackBar).EndInit();
            ((System.ComponentModel.ISupportInitialize)XtriangulationTrackBar).EndInit();
            ((System.ComponentModel.ISupportInitialize)Bitmap).EndInit();
            splitContainer1.Panel1.ResumeLayout(false);
            splitContainer1.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)splitContainer1).EndInit();
            splitContainer1.ResumeLayout(false);
            ResumeLayout(false);
        }

        #endregion
        private ColorDialog colorDialog;
        private OpenFileDialog openFileDialog;
        private GroupBox Menu;
        private Button openFileButton;
        private Button LightButton;
        private Button ChooseColorButton;
        private Button animationStartButton;
        private CheckBox drawTrianglesBox;
        private TrackBar YtriangulationTrackBar;
        private TrackBar mTrackBar;
        private Label label4;
        private Label label3;
        private Label label2;
        private Label label1;
        private TrackBar ksTrackBar;
        private TrackBar kdTrackBar;
        private TrackBar XtriangulationTrackBar;
        private PictureBox Bitmap;
        private SplitContainer splitContainer1;
        private Button ChangeControlButton;
        private Label label8;
        private Label label7;
        private Label label6;
        private TextBox zPointControl;
        private TextBox yPointControl;
        private TextBox xPointControl;
        private Label label5;
        private Button animationStopButton;
    }
}