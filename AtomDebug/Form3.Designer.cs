namespace AtomDebug
{
    partial class AtomControl
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
            this.lblDev = new System.Windows.Forms.Label();
            this.comboFreq = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.btnSet = new System.Windows.Forms.Button();
            this.btnStop = new System.Windows.Forms.Button();
            this.btnStart = new System.Windows.Forms.Button();
            this.txtTarget = new System.Windows.Forms.TextBox();
            this.lblTarget = new System.Windows.Forms.Label();
            this.lblBlock = new System.Windows.Forms.Label();
            this.txtBlock = new System.Windows.Forms.TextBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.btnSendTarget = new System.Windows.Forms.Button();
            this.btnSendBlock = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // lblDev
            // 
            this.lblDev.Location = new System.Drawing.Point(12, 13);
            this.lblDev.Name = "lblDev";
            this.lblDev.Size = new System.Drawing.Size(254, 23);
            this.lblDev.TabIndex = 0;
            this.lblDev.Text = "Connected Device:";
            // 
            // comboFreq
            // 
            this.comboFreq.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboFreq.FormattingEnabled = true;
            this.comboFreq.Location = new System.Drawing.Point(50, 39);
            this.comboFreq.Name = "comboFreq";
            this.comboFreq.Size = new System.Drawing.Size(136, 21);
            this.comboFreq.TabIndex = 1;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(13, 44);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(28, 13);
            this.label2.TabIndex = 2;
            this.label2.Text = "Freq";
            // 
            // btnSet
            // 
            this.btnSet.Location = new System.Drawing.Point(192, 37);
            this.btnSet.Name = "btnSet";
            this.btnSet.Size = new System.Drawing.Size(75, 23);
            this.btnSet.TabIndex = 3;
            this.btnSet.Text = "Set";
            this.btnSet.UseVisualStyleBackColor = true;
            this.btnSet.Click += new System.EventHandler(this.btnSet_Click);
            // 
            // btnStop
            // 
            this.btnStop.Location = new System.Drawing.Point(11, 239);
            this.btnStop.Name = "btnStop";
            this.btnStop.Size = new System.Drawing.Size(255, 23);
            this.btnStop.TabIndex = 4;
            this.btnStop.Text = "Stop";
            this.btnStop.UseVisualStyleBackColor = true;
            this.btnStop.Click += new System.EventHandler(this.btnStop_Click);
            // 
            // btnStart
            // 
            this.btnStart.Location = new System.Drawing.Point(11, 326);
            this.btnStart.Name = "btnStart";
            this.btnStart.Size = new System.Drawing.Size(255, 23);
            this.btnStart.TabIndex = 5;
            this.btnStart.Text = "Start";
            this.btnStart.UseVisualStyleBackColor = true;
            this.btnStart.Click += new System.EventHandler(this.btnStart_Click);
            // 
            // txtTarget
            // 
            this.txtTarget.Location = new System.Drawing.Point(11, 88);
            this.txtTarget.Multiline = true;
            this.txtTarget.Name = "txtTarget";
            this.txtTarget.Size = new System.Drawing.Size(255, 38);
            this.txtTarget.TabIndex = 6;
            this.txtTarget.Text = "0000000000000000c68ef0b049f8d1a3cf8e499481993a99cf8279f543c466db";
            this.txtTarget.TextChanged += new System.EventHandler(this.txtTarget_TextChanged);
            // 
            // lblTarget
            // 
            this.lblTarget.Location = new System.Drawing.Point(12, 67);
            this.lblTarget.Name = "lblTarget";
            this.lblTarget.Size = new System.Drawing.Size(254, 18);
            this.lblTarget.TabIndex = 7;
            this.lblTarget.Text = "Target";
            // 
            // lblBlock
            // 
            this.lblBlock.Location = new System.Drawing.Point(12, 129);
            this.lblBlock.Name = "lblBlock";
            this.lblBlock.Size = new System.Drawing.Size(254, 18);
            this.lblBlock.TabIndex = 9;
            this.lblBlock.Text = "Block";
            // 
            // txtBlock
            // 
            this.txtBlock.Location = new System.Drawing.Point(11, 150);
            this.txtBlock.Multiline = true;
            this.txtBlock.Name = "txtBlock";
            this.txtBlock.Size = new System.Drawing.Size(255, 64);
            this.txtBlock.TabIndex = 8;
            this.txtBlock.Text = "4170CACD2404388EF32D36D60FA88086F162F46EAF7AF910AD7AEC58F1B85791c605232b5c8c05535" +
    "35f0119ccad1657";
            this.txtBlock.TextChanged += new System.EventHandler(this.txtBlock_TextChanged);
            // 
            // groupBox1
            // 
            this.groupBox1.Location = new System.Drawing.Point(13, 220);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(254, 10);
            this.groupBox1.TabIndex = 10;
            this.groupBox1.TabStop = false;
            // 
            // btnSendTarget
            // 
            this.btnSendTarget.Location = new System.Drawing.Point(11, 268);
            this.btnSendTarget.Name = "btnSendTarget";
            this.btnSendTarget.Size = new System.Drawing.Size(255, 23);
            this.btnSendTarget.TabIndex = 11;
            this.btnSendTarget.Text = "Send Target";
            this.btnSendTarget.UseVisualStyleBackColor = true;
            this.btnSendTarget.Click += new System.EventHandler(this.btnSendTarget_Click);
            // 
            // btnSendBlock
            // 
            this.btnSendBlock.Location = new System.Drawing.Point(11, 297);
            this.btnSendBlock.Name = "btnSendBlock";
            this.btnSendBlock.Size = new System.Drawing.Size(255, 23);
            this.btnSendBlock.TabIndex = 12;
            this.btnSendBlock.Text = "Send Block";
            this.btnSendBlock.UseVisualStyleBackColor = true;
            this.btnSendBlock.Click += new System.EventHandler(this.btnSendBlock_Click);
            // 
            // AtomControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(279, 362);
            this.ControlBox = false;
            this.Controls.Add(this.btnSendBlock);
            this.Controls.Add(this.btnSendTarget);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.lblBlock);
            this.Controls.Add(this.txtBlock);
            this.Controls.Add(this.lblTarget);
            this.Controls.Add(this.txtTarget);
            this.Controls.Add(this.btnStart);
            this.Controls.Add(this.btnStop);
            this.Controls.Add(this.btnSet);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.comboFreq);
            this.Controls.Add(this.lblDev);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "AtomControl";
            this.ShowInTaskbar = false;
            this.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Hide;
            this.Tag = "";
            this.Text = "Atom Control";
            this.Load += new System.EventHandler(this.AtomControl_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblDev;
        private System.Windows.Forms.ComboBox comboFreq;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button btnSet;
        private System.Windows.Forms.Button btnStop;
        private System.Windows.Forms.Button btnStart;
        private System.Windows.Forms.TextBox txtTarget;
        private System.Windows.Forms.Label lblTarget;
        private System.Windows.Forms.Label lblBlock;
        private System.Windows.Forms.TextBox txtBlock;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Button btnSendTarget;
        private System.Windows.Forms.Button btnSendBlock;
    }
}