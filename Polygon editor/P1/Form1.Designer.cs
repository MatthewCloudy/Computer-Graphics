namespace P1
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
            Bitmap = new PictureBox();
            Settings = new GroupBox();
            groupBox1 = new GroupBox();
            addVertexButton = new RadioButton();
            addVertexOnEdge = new RadioButton();
            deleteRestrictionButton = new RadioButton();
            deleteVertexButton = new RadioButton();
            moveVertexButton = new RadioButton();
            moveEdgeButton = new RadioButton();
            setHorizontalEdge = new RadioButton();
            movePolygonButton = new RadioButton();
            setVerticalEdge = new RadioButton();
            offsetPolygonSettings = new GroupBox();
            setOffset = new Label();
            trackBar1 = new TrackBar();
            offsetPolygonButton = new CheckBox();
            lineSettings = new GroupBox();
            BresenhamAlgButton = new RadioButton();
            defaultAlgButton = new RadioButton();
            clearFieldButton = new Button();
            drawCircleButton = new RadioButton();
            ((System.ComponentModel.ISupportInitialize)Bitmap).BeginInit();
            Settings.SuspendLayout();
            groupBox1.SuspendLayout();
            offsetPolygonSettings.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)trackBar1).BeginInit();
            lineSettings.SuspendLayout();
            SuspendLayout();
            // 
            // Bitmap
            // 
            Bitmap.Dock = DockStyle.Fill;
            Bitmap.Location = new Point(0, 0);
            Bitmap.Name = "Bitmap";
            Bitmap.Size = new Size(1182, 753);
            Bitmap.TabIndex = 0;
            Bitmap.TabStop = false;
            Bitmap.Paint += Bitmap_Paint;
            Bitmap.MouseClick += Bitmap_MouseClick;
            Bitmap.MouseDown += Bitmap_MouseDown;
            Bitmap.MouseMove += Bitmap_MouseMove;
            Bitmap.MouseUp += Bitmap_MouseUp;
            // 
            // Settings
            // 
            Settings.Controls.Add(groupBox1);
            Settings.Controls.Add(offsetPolygonSettings);
            Settings.Controls.Add(lineSettings);
            Settings.Controls.Add(clearFieldButton);
            Settings.Dock = DockStyle.Right;
            Settings.Location = new Point(938, 0);
            Settings.Name = "Settings";
            Settings.Size = new Size(244, 753);
            Settings.TabIndex = 1;
            Settings.TabStop = false;
            Settings.Text = "Ustawienia";
            // 
            // groupBox1
            // 
            groupBox1.Controls.Add(drawCircleButton);
            groupBox1.Controls.Add(addVertexButton);
            groupBox1.Controls.Add(addVertexOnEdge);
            groupBox1.Controls.Add(deleteRestrictionButton);
            groupBox1.Controls.Add(deleteVertexButton);
            groupBox1.Controls.Add(moveVertexButton);
            groupBox1.Controls.Add(moveEdgeButton);
            groupBox1.Controls.Add(setHorizontalEdge);
            groupBox1.Controls.Add(movePolygonButton);
            groupBox1.Controls.Add(setVerticalEdge);
            groupBox1.Location = new Point(6, 26);
            groupBox1.Name = "groupBox1";
            groupBox1.Size = new Size(238, 329);
            groupBox1.TabIndex = 12;
            groupBox1.TabStop = false;
            groupBox1.Text = "Rysowanie";
            // 
            // addVertexButton
            // 
            addVertexButton.AutoSize = true;
            addVertexButton.Location = new Point(9, 26);
            addVertexButton.Name = "addVertexButton";
            addVertexButton.Size = new Size(153, 24);
            addVertexButton.TabIndex = 0;
            addVertexButton.TabStop = true;
            addVertexButton.Text = "Dodaj wierzchołek";
            addVertexButton.UseVisualStyleBackColor = true;
            // 
            // addVertexOnEdge
            // 
            addVertexOnEdge.AutoSize = true;
            addVertexOnEdge.Location = new Point(9, 56);
            addVertexOnEdge.Name = "addVertexOnEdge";
            addVertexOnEdge.Size = new Size(236, 24);
            addVertexOnEdge.TabIndex = 5;
            addVertexOnEdge.TabStop = true;
            addVertexOnEdge.Text = "Dodaj wierzchołek na krawędzi";
            addVertexOnEdge.UseVisualStyleBackColor = true;
            // 
            // deleteRestrictionButton
            // 
            deleteRestrictionButton.AutoSize = true;
            deleteRestrictionButton.Location = new Point(9, 266);
            deleteRestrictionButton.Name = "deleteRestrictionButton";
            deleteRestrictionButton.Size = new Size(214, 24);
            deleteRestrictionButton.TabIndex = 10;
            deleteRestrictionButton.TabStop = true;
            deleteRestrictionButton.Text = "Usuń ograniczenia krawędzi";
            deleteRestrictionButton.UseVisualStyleBackColor = true;
            // 
            // deleteVertexButton
            // 
            deleteVertexButton.AutoSize = true;
            deleteVertexButton.Location = new Point(10, 86);
            deleteVertexButton.Name = "deleteVertexButton";
            deleteVertexButton.Size = new Size(144, 24);
            deleteVertexButton.TabIndex = 4;
            deleteVertexButton.TabStop = true;
            deleteVertexButton.Text = "Usuń wierzchołek";
            deleteVertexButton.UseVisualStyleBackColor = true;
            // 
            // moveVertexButton
            // 
            moveVertexButton.AutoSize = true;
            moveVertexButton.Location = new Point(9, 116);
            moveVertexButton.Name = "moveVertexButton";
            moveVertexButton.Size = new Size(162, 24);
            moveVertexButton.TabIndex = 1;
            moveVertexButton.TabStop = true;
            moveVertexButton.Text = "Przesuń wierzchołek";
            moveVertexButton.UseVisualStyleBackColor = true;
            // 
            // moveEdgeButton
            // 
            moveEdgeButton.AutoSize = true;
            moveEdgeButton.Location = new Point(9, 146);
            moveEdgeButton.Name = "moveEdgeButton";
            moveEdgeButton.Size = new Size(139, 24);
            moveEdgeButton.TabIndex = 2;
            moveEdgeButton.TabStop = true;
            moveEdgeButton.Text = "Przesuń krawędź";
            moveEdgeButton.TextAlign = ContentAlignment.TopCenter;
            moveEdgeButton.UseVisualStyleBackColor = true;
            // 
            // setHorizontalEdge
            // 
            setHorizontalEdge.AutoSize = true;
            setHorizontalEdge.Location = new Point(10, 236);
            setHorizontalEdge.Name = "setHorizontalEdge";
            setHorizontalEdge.Size = new Size(192, 24);
            setHorizontalEdge.TabIndex = 7;
            setHorizontalEdge.TabStop = true;
            setHorizontalEdge.Text = "Ustaw krawędź poziomą";
            setHorizontalEdge.UseVisualStyleBackColor = true;
            // 
            // movePolygonButton
            // 
            movePolygonButton.AutoSize = true;
            movePolygonButton.Location = new Point(10, 176);
            movePolygonButton.Name = "movePolygonButton";
            movePolygonButton.Size = new Size(140, 24);
            movePolygonButton.TabIndex = 3;
            movePolygonButton.TabStop = true;
            movePolygonButton.Text = "Przesuń wielokąt";
            movePolygonButton.UseVisualStyleBackColor = true;
            // 
            // setVerticalEdge
            // 
            setVerticalEdge.AutoSize = true;
            setVerticalEdge.Location = new Point(10, 206);
            setVerticalEdge.Name = "setVerticalEdge";
            setVerticalEdge.Size = new Size(191, 24);
            setVerticalEdge.TabIndex = 6;
            setVerticalEdge.TabStop = true;
            setVerticalEdge.Text = "Ustaw krawędź pionową";
            setVerticalEdge.UseVisualStyleBackColor = true;
            // 
            // offsetPolygonSettings
            // 
            offsetPolygonSettings.Controls.Add(setOffset);
            offsetPolygonSettings.Controls.Add(trackBar1);
            offsetPolygonSettings.Controls.Add(offsetPolygonButton);
            offsetPolygonSettings.Location = new Point(6, 473);
            offsetPolygonSettings.Name = "offsetPolygonSettings";
            offsetPolygonSettings.Size = new Size(232, 161);
            offsetPolygonSettings.TabIndex = 11;
            offsetPolygonSettings.TabStop = false;
            offsetPolygonSettings.Text = "Wielokąt offsetowy";
            // 
            // setOffset
            // 
            setOffset.AutoSize = true;
            setOffset.Location = new Point(6, 62);
            setOffset.Name = "setOffset";
            setOffset.Size = new Size(94, 20);
            setOffset.TabIndex = 2;
            setOffset.Text = "Ustaw offset:";
            // 
            // trackBar1
            // 
            trackBar1.Location = new Point(6, 85);
            trackBar1.Maximum = 100;
            trackBar1.Minimum = 1;
            trackBar1.Name = "trackBar1";
            trackBar1.Size = new Size(208, 56);
            trackBar1.TabIndex = 1;
            trackBar1.Value = 1;
            trackBar1.Scroll += trackBar1_Scroll;
            // 
            // offsetPolygonButton
            // 
            offsetPolygonButton.AutoSize = true;
            offsetPolygonButton.Location = new Point(6, 26);
            offsetPolygonButton.Name = "offsetPolygonButton";
            offsetPolygonButton.Size = new Size(194, 24);
            offsetPolygonButton.TabIndex = 0;
            offsetPolygonButton.Text = "Rysuj wielokąt offsetowy";
            offsetPolygonButton.UseVisualStyleBackColor = true;
            offsetPolygonButton.CheckedChanged += offsetPolygonButton_CheckedChanged;
            // 
            // lineSettings
            // 
            lineSettings.Controls.Add(BresenhamAlgButton);
            lineSettings.Controls.Add(defaultAlgButton);
            lineSettings.Location = new Point(6, 361);
            lineSettings.Name = "lineSettings";
            lineSettings.Size = new Size(232, 106);
            lineSettings.TabIndex = 9;
            lineSettings.TabStop = false;
            lineSettings.Text = "Rysuj linie algorytmem";
            // 
            // BresenhamAlgButton
            // 
            BresenhamAlgButton.AutoSize = true;
            BresenhamAlgButton.Location = new Point(6, 56);
            BresenhamAlgButton.Name = "BresenhamAlgButton";
            BresenhamAlgButton.Size = new Size(111, 24);
            BresenhamAlgButton.TabIndex = 1;
            BresenhamAlgButton.TabStop = true;
            BresenhamAlgButton.Text = "Bresenhama";
            BresenhamAlgButton.UseVisualStyleBackColor = true;
            // 
            // defaultAlgButton
            // 
            defaultAlgButton.AutoSize = true;
            defaultAlgButton.Location = new Point(6, 26);
            defaultAlgButton.Name = "defaultAlgButton";
            defaultAlgButton.Size = new Size(124, 24);
            defaultAlgButton.TabIndex = 0;
            defaultAlgButton.TabStop = true;
            defaultAlgButton.Text = "bibliotecznym";
            defaultAlgButton.UseVisualStyleBackColor = true;
            // 
            // clearFieldButton
            // 
            clearFieldButton.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
            clearFieldButton.Location = new Point(6, 702);
            clearFieldButton.Name = "clearFieldButton";
            clearFieldButton.Size = new Size(227, 39);
            clearFieldButton.TabIndex = 8;
            clearFieldButton.Text = "Wyczyść kanwę";
            clearFieldButton.UseVisualStyleBackColor = true;
            clearFieldButton.Click += clearFieldButton_Click;
            // 
            // drawCircleButton
            // 
            drawCircleButton.AutoSize = true;
            drawCircleButton.Location = new Point(9, 296);
            drawCircleButton.Name = "drawCircleButton";
            drawCircleButton.Size = new Size(106, 24);
            drawCircleButton.TabIndex = 11;
            drawCircleButton.TabStop = true;
            drawCircleButton.Text = "Rysuj okrąg";
            drawCircleButton.UseVisualStyleBackColor = true;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1182, 753);
            Controls.Add(Settings);
            Controls.Add(Bitmap);
            Name = "Form1";
            Text = "Form1";
            ((System.ComponentModel.ISupportInitialize)Bitmap).EndInit();
            Settings.ResumeLayout(false);
            groupBox1.ResumeLayout(false);
            groupBox1.PerformLayout();
            offsetPolygonSettings.ResumeLayout(false);
            offsetPolygonSettings.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)trackBar1).EndInit();
            lineSettings.ResumeLayout(false);
            lineSettings.PerformLayout();
            ResumeLayout(false);
        }

        #endregion

        public PictureBox Bitmap;
        private GroupBox Settings;
        private RadioButton addVertexButton;
        private RadioButton moveEdgeButton;
        private RadioButton moveVertexButton;
        private RadioButton movePolygonButton;
        private RadioButton deleteVertexButton;
        private RadioButton addVertexOnEdge;
        private RadioButton setVerticalEdge;
        private RadioButton setHorizontalEdge;
        private Button clearFieldButton;
        private GroupBox lineSettings;
        private RadioButton BresenhamAlgButton;
        private RadioButton defaultAlgButton;
        private RadioButton deleteRestrictionButton;
        private GroupBox offsetPolygonSettings;
        private Label setOffset;
        private TrackBar trackBar1;
        private CheckBox offsetPolygonButton;
        private GroupBox groupBox1;
        private RadioButton drawCircleButton;
    }
}