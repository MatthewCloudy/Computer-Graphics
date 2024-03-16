namespace p4
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
            pictureBox1 = new PictureBox();
            groupBox1 = new GroupBox();
            startButton = new Button();
            groupBox4 = new GroupBox();
            checkBox1 = new CheckBox();
            trackBar1 = new TrackBar();
            groupBox3 = new GroupBox();
            PhongShading = new RadioButton();
            GouroudShading = new RadioButton();
            ConstantShading = new RadioButton();
            groupBox2 = new GroupBox();
            MovingButton = new Button();
            staticDirectedButton = new Button();
            staticButton = new Button();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).BeginInit();
            groupBox1.SuspendLayout();
            groupBox4.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)trackBar1).BeginInit();
            groupBox3.SuspendLayout();
            groupBox2.SuspendLayout();
            SuspendLayout();
            // 
            // pictureBox1
            // 
            pictureBox1.Location = new Point(2, 5);
            pictureBox1.Name = "pictureBox1";
            pictureBox1.Size = new Size(400, 400);
            pictureBox1.TabIndex = 0;
            pictureBox1.TabStop = false;
            pictureBox1.Paint += pictureBox1_Paint;
            // 
            // groupBox1
            // 
            groupBox1.Controls.Add(startButton);
            groupBox1.Controls.Add(groupBox4);
            groupBox1.Controls.Add(groupBox3);
            groupBox1.Controls.Add(groupBox2);
            groupBox1.Location = new Point(567, 5);
            groupBox1.Name = "groupBox1";
            groupBox1.Size = new Size(230, 497);
            groupBox1.TabIndex = 1;
            groupBox1.TabStop = false;
            groupBox1.Text = "Menu";
            // 
            // startButton
            // 
            startButton.Location = new Point(25, 443);
            startButton.Name = "startButton";
            startButton.Size = new Size(193, 29);
            startButton.TabIndex = 3;
            startButton.Text = "Start";
            startButton.UseVisualStyleBackColor = true;
            startButton.Click += startButton_Click;
            // 
            // groupBox4
            // 
            groupBox4.Controls.Add(checkBox1);
            groupBox4.Controls.Add(trackBar1);
            groupBox4.Location = new Point(6, 307);
            groupBox4.Name = "groupBox4";
            groupBox4.Size = new Size(218, 113);
            groupBox4.TabIndex = 2;
            groupBox4.TabStop = false;
            groupBox4.Text = "Fog";
            // 
            // checkBox1
            // 
            checkBox1.AutoSize = true;
            checkBox1.Location = new Point(19, 69);
            checkBox1.Name = "checkBox1";
            checkBox1.Size = new Size(56, 24);
            checkBox1.TabIndex = 1;
            checkBox1.Text = "Fog";
            checkBox1.UseVisualStyleBackColor = true;
            // 
            // trackBar1
            // 
            trackBar1.Location = new Point(19, 26);
            trackBar1.Maximum = 20;
            trackBar1.Name = "trackBar1";
            trackBar1.Size = new Size(169, 56);
            trackBar1.TabIndex = 0;
            // 
            // groupBox3
            // 
            groupBox3.Controls.Add(PhongShading);
            groupBox3.Controls.Add(GouroudShading);
            groupBox3.Controls.Add(ConstantShading);
            groupBox3.Location = new Point(6, 163);
            groupBox3.Name = "groupBox3";
            groupBox3.Size = new Size(218, 128);
            groupBox3.TabIndex = 1;
            groupBox3.TabStop = false;
            groupBox3.Text = "Shading";
            // 
            // PhongShading
            // 
            PhongShading.AutoSize = true;
            PhongShading.Location = new Point(19, 86);
            PhongShading.Name = "PhongShading";
            PhongShading.Size = new Size(72, 24);
            PhongShading.TabIndex = 2;
            PhongShading.Text = "Phong";
            PhongShading.UseVisualStyleBackColor = true;
            // 
            // GouroudShading
            // 
            GouroudShading.AutoSize = true;
            GouroudShading.Location = new Point(19, 56);
            GouroudShading.Name = "GouroudShading";
            GouroudShading.Size = new Size(88, 24);
            GouroudShading.TabIndex = 1;
            GouroudShading.Text = "Gouroud";
            GouroudShading.UseVisualStyleBackColor = true;
            // 
            // ConstantShading
            // 
            ConstantShading.AutoSize = true;
            ConstantShading.Checked = true;
            ConstantShading.Location = new Point(19, 26);
            ConstantShading.Name = "ConstantShading";
            ConstantShading.Size = new Size(88, 24);
            ConstantShading.TabIndex = 0;
            ConstantShading.TabStop = true;
            ConstantShading.Text = "Constant";
            ConstantShading.UseVisualStyleBackColor = true;
            // 
            // groupBox2
            // 
            groupBox2.Controls.Add(MovingButton);
            groupBox2.Controls.Add(staticDirectedButton);
            groupBox2.Controls.Add(staticButton);
            groupBox2.Location = new Point(6, 26);
            groupBox2.Name = "groupBox2";
            groupBox2.Size = new Size(218, 131);
            groupBox2.TabIndex = 0;
            groupBox2.TabStop = false;
            groupBox2.Text = "Cameras";
            // 
            // MovingButton
            // 
            MovingButton.Location = new Point(19, 96);
            MovingButton.Name = "MovingButton";
            MovingButton.Size = new Size(193, 29);
            MovingButton.TabIndex = 5;
            MovingButton.Text = "Moving";
            MovingButton.UseVisualStyleBackColor = true;
            MovingButton.Click += MovingButton_Click;
            // 
            // staticDirectedButton
            // 
            staticDirectedButton.Location = new Point(19, 61);
            staticDirectedButton.Name = "staticDirectedButton";
            staticDirectedButton.Size = new Size(193, 29);
            staticDirectedButton.TabIndex = 4;
            staticDirectedButton.Text = "Static directed on object";
            staticDirectedButton.UseVisualStyleBackColor = true;
            staticDirectedButton.Click += staticDirectedButton_Click;
            // 
            // staticButton
            // 
            staticButton.Location = new Point(19, 26);
            staticButton.Name = "staticButton";
            staticButton.Size = new Size(193, 29);
            staticButton.TabIndex = 3;
            staticButton.Text = "Static";
            staticButton.UseVisualStyleBackColor = true;
            staticButton.Click += staticButton_Click;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(803, 514);
            Controls.Add(groupBox1);
            Controls.Add(pictureBox1);
            Name = "Form1";
            Text = "Form1";
            Load += Form1_Load;
            ((System.ComponentModel.ISupportInitialize)pictureBox1).EndInit();
            groupBox1.ResumeLayout(false);
            groupBox4.ResumeLayout(false);
            groupBox4.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)trackBar1).EndInit();
            groupBox3.ResumeLayout(false);
            groupBox3.PerformLayout();
            groupBox2.ResumeLayout(false);
            ResumeLayout(false);
        }

        #endregion

        private PictureBox pictureBox1;
        private GroupBox groupBox1;
        private GroupBox groupBox4;
        private TrackBar trackBar1;
        private GroupBox groupBox3;
        private RadioButton PhongShading;
        private RadioButton GouroudShading;
        private RadioButton ConstantShading;
        private GroupBox groupBox2;
        private Button startButton;
        private CheckBox checkBox1;
        private Button staticDirectedButton;
        private Button staticButton;
        private Button MovingButton;
    }
}