/*
 * Debug console for Atom-Sha256 FPGA miner, powered by AtomMiner
 *
 * Copyright 2017 AtomMiner <info@atomminer.com>
 *
 * BTC donation: 3LwsJAzPd8weD1FypVWmkDFMwA7rgjPSif
 *
 * This program is free software; you can redistribute it and/or modify it
 * under the terms of the GNU General Public License as published by the Free
 * Software Foundation; either version 3 of the License, or (at your option)
 * any later version.  See COPYING for more details.
 */

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Threading;
using System.Windows.Forms;

namespace AtomDebug
{
	public class Form2 : Form
	{
		private delegate void ObjectDelegate(bool input, string log);

		private IContainer components = null;

		private TextBox textBox1;

		private Label label1;

		private Label label2;

		private TextBox textBox2;

		private Button btnSend;

		private Label lblInputStat;

		private Button btnClose;

		private BackgroundWorker backgroundWorker1;

		private CheckBox checkBox1;

		private bool _stopWorker = false;
        private bool _ignoreAtomOutput = false;

        private AtomControl frmControl;

        public void IgnoreOutput(bool bIgnore)
        {
            _ignoreAtomOutput = bIgnore;
        }

		protected override void Dispose(bool disposing)
		{
			if (disposing && this.components != null)
			{
				this.components.Dispose();
			}
			base.Dispose(disposing);
		}

		private void InitializeComponent()
		{
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.textBox2 = new System.Windows.Forms.TextBox();
            this.btnSend = new System.Windows.Forms.Button();
            this.lblInputStat = new System.Windows.Forms.Label();
            this.btnClose = new System.Windows.Forms.Button();
            this.backgroundWorker1 = new System.ComponentModel.BackgroundWorker();
            this.checkBox1 = new System.Windows.Forms.CheckBox();
            this.SuspendLayout();
            // 
            // textBox1
            // 
            this.textBox1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.textBox1.Location = new System.Drawing.Point(13, 30);
            this.textBox1.Multiline = true;
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(472, 144);
            this.textBox1.TabIndex = 0;
            this.textBox1.Text = "6e";
            this.textBox1.TextChanged += new System.EventHandler(this.textBox1_TextChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(13, 11);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(54, 13);
            this.label1.TabIndex = 1;
            this.label1.Text = "Command";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(13, 206);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(74, 13);
            this.label2.TabIndex = 2;
            this.label2.Text = "Device output";
            // 
            // textBox2
            // 
            this.textBox2.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.textBox2.Location = new System.Drawing.Point(13, 222);
            this.textBox2.Multiline = true;
            this.textBox2.Name = "textBox2";
            this.textBox2.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.textBox2.Size = new System.Drawing.Size(472, 165);
            this.textBox2.TabIndex = 3;
            // 
            // btnSend
            // 
            this.btnSend.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnSend.Location = new System.Drawing.Point(409, 183);
            this.btnSend.Name = "btnSend";
            this.btnSend.Size = new System.Drawing.Size(75, 23);
            this.btnSend.TabIndex = 4;
            this.btnSend.Text = "Send";
            this.btnSend.UseVisualStyleBackColor = true;
            this.btnSend.Click += new System.EventHandler(this.btnSend_Click);
            // 
            // lblInputStat
            // 
            this.lblInputStat.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lblInputStat.Location = new System.Drawing.Point(10, 183);
            this.lblInputStat.Name = "lblInputStat";
            this.lblInputStat.Size = new System.Drawing.Size(387, 23);
            this.lblInputStat.TabIndex = 5;
            this.lblInputStat.Text = "Characters: 0";
            this.lblInputStat.Click += new System.EventHandler(this.lblInputStat_Click);
            // 
            // btnClose
            // 
            this.btnClose.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnClose.Location = new System.Drawing.Point(408, 398);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(75, 23);
            this.btnClose.TabIndex = 6;
            this.btnClose.Text = "Close";
            this.btnClose.UseVisualStyleBackColor = true;
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // backgroundWorker1
            // 
            this.backgroundWorker1.DoWork += new System.ComponentModel.DoWorkEventHandler(this.backgroundWorker1_DoWork);
            // 
            // checkBox1
            // 
            this.checkBox1.AutoSize = true;
            this.checkBox1.Location = new System.Drawing.Point(363, 7);
            this.checkBox1.Name = "checkBox1";
            this.checkBox1.Size = new System.Drawing.Size(120, 17);
            this.checkBox1.TabIndex = 7;
            this.checkBox1.Text = "Autoclear command";
            this.checkBox1.UseVisualStyleBackColor = true;
            // 
            // Form2
            // 
            this.ClientSize = new System.Drawing.Size(497, 426);
            this.Controls.Add(this.checkBox1);
            this.Controls.Add(this.btnClose);
            this.Controls.Add(this.lblInputStat);
            this.Controls.Add(this.btnSend);
            this.Controls.Add(this.textBox2);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.textBox1);
            this.Name = "Form2";
            this.Text = "Device Control v1.3";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Form2_FormClosing);
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.Form2_FormClosed);
            this.Load += new System.EventHandler(this.Form2_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

		}

		public Form2()
		{
			this.InitializeComponent();
			this.backgroundWorker1.RunWorkerAsync();
		}

		public void addOutput(bool input, string log)
		{
			if (base.InvokeRequired)
			{
				Form2.ObjectDelegate method = new Form2.ObjectDelegate(this.addOutput);
				base.Invoke(method, new object[]
				{
					input,
					log
				});
			}
			else
			{
				string text;
				if (input)
				{
					text = "-> ";
				}
				else
				{
					text = "<- ";
				}
				text = text + log + "\r\n";
				this.textBox2.Text = this.textBox2.Text + text;
				if (this.textBox2.Text.Length > 4000)
				{
					this.textBox2.Text = this.textBox2.Text.Remove(0, 500);
				}
				this.textBox2.SelectionStart = this.textBox2.TextLength;
				this.textBox2.ScrollToCaret();
			}
		}

		private void backgroundWorker1_DoWork(object sender, DoWorkEventArgs e)
		{
			while (!this._stopWorker)
			{
                if(_ignoreAtomOutput)
                {
                    Thread.Sleep(100);
                    continue;
                }

				List<byte> list = new List<byte>();
				while (G.usbPort.BytesToRead > 0)
				{
					byte[] array = new byte[G.usbPort.BytesToRead];
					G.usbPort.Read(array, 0, G.usbPort.BytesToRead);
					string log = array.ToHex();
					this.addOutput(false, log);
				}
                Thread.Sleep(100);
			}
		}

		private void lblInputStat_Click(object sender, EventArgs e)
		{
		}

		private void Form2_Load(object sender, EventArgs e)
		{
			if (G.usbPort == null || !G.usbPort.IsOpen)
			{
				MessageBox.Show("Device can not be open or disconnected. Exiting...");
				this.btnClose_Click(sender, e);
			}
			else
			{
				this.textBox1.KeyPress += new KeyPressEventHandler(this.tb_KeyDown);
			}

            frmControl = new AtomControl(this);
            frmControl.Show(this);

			this.textBox2.Text = "BTC donation: 3LwsJAzPd8weD1FypVWmkDFMwA7rgjPSif\r\n";
		}

		private void tb_KeyDown(object sender, KeyPressEventArgs e)
		{
			if (e.KeyChar == '\r')
			{
				e.Handled = true;
				this.btnSend.PerformClick();
			}
		}

		private void btnClose_Click(object sender, EventArgs e)
		{
			this._stopWorker = true;
			if (sender != null)
			{
                frmControl.Close();
				base.Close();
			}
			G.frmDevices.Show();
		}

		private void textBox1_TextChanged(object sender, EventArgs e)
		{
			string text = this.textBox1.Text;
			text = text.Replace("\r\n", "").Replace(" ", "");
			this.lblInputStat.Text = "Characters: " + text.Length.ToString();
			if (text.Length % 2 != 0 || text.Length == 0)
			{
				this.btnSend.Enabled = false;
			}
			else
			{
				this.btnSend.Enabled = true;
			}
		}

        public void SendCmd(string s)
        {
            if (s.Length % 2 == 0 && s.Length != 0)
            {
                byte[] array = null;
                try
                {
                    array = G.StringToByteArray(s);
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                    return;
                }
                this.addOutput(true, s);
                G.usbPort.Write(array, 0, array.Length);
                if (this.checkBox1.Checked)
                {
                    this.textBox1.Text = "";
                }
            }
        }

		private void btnSend_Click(object sender, EventArgs e)
		{
			string text = this.textBox1.Text;
			text = text.Replace("\r\n", "").Replace(" ", "");

            SendCmd(text);
		}

		private void Form2_FormClosing(object sender, FormClosingEventArgs e)
		{
			this.btnClose_Click(null, null);
		}

        private void Form2_FormClosed(object sender, FormClosedEventArgs e)
        {
            if (frmControl != null && frmControl.Visible)
                frmControl.Close();

            try
            {
                G.usbPort.Close();
            }
            catch (Exception) { }
        }
	}
}
