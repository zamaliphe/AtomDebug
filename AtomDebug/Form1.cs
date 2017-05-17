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
using System.IO.Ports;
using System.Windows.Forms;

namespace AtomDebug
{
	public class Form1 : Form
	{
		private List<string> _devices = new List<string>();

		private IContainer components = null;

		private ComboBox comboBox1;

		private Label label1;

		private Button button1;

		private Button button2;

		public Form1()
		{
			this.InitializeComponent();
			G.frmDevices = this;
		}

		private void label1_Click(object sender, EventArgs e)
		{
		}

		private void Form1_Load(object sender, EventArgs e)
		{
			this.DisableUI();
			this.RefreshDevices();
			this.EnableUI();
		}

		private void DisableUI()
		{
			this.label1.Text = "Refreshing device list...";
			this.comboBox1.Enabled = false;
			this.button1.Enabled = false;
			this.button2.Enabled = false;
		}

		private void EnableUI()
		{
			this.comboBox1.Enabled = true;
			this.button1.Enabled = true;
			if (this.comboBox1.SelectedIndex == 0)
			{
				this.button2.Enabled = false;
			}
			else
			{
				this.button2.Enabled = true;
			}
			this.label1.Text = "Device";
		}

		public void RefreshDevices()
		{
			this._devices = new List<string>();
			this.comboBox1.Items.Clear();
			this.comboBox1.Items.Add("Choose device");
			string[] portNames = SerialPort.GetPortNames();
			string[] array = portNames;
			for (int i = 0; i < array.Length; i++)
			{
				string item = array[i];
				this._devices.Add(item);
				this.comboBox1.Items.Add(item);
			}
			this.comboBox1.SelectedIndex = 0;
		}

		private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
		{
			if (this.comboBox1.SelectedIndex == 0)
			{
				this.button2.Enabled = false;
			}
			else
			{
				this.button2.Enabled = true;
			}
		}

		private void button1_Click(object sender, EventArgs e)
		{
			this.DisableUI();
			this.RefreshDevices();
			this.EnableUI();
		}

		private void button2_Click(object sender, EventArgs e)
		{
			try
			{
				G.usbPort = new SerialPort(this.comboBox1.SelectedItem.ToString(), 921600);
				G.usbPort.Parity = Parity.None;
				G.usbPort.DataBits = 8;
				G.usbPort.StopBits = StopBits.One;
				G.usbPort.DtrEnable = false;
				G.usbPort.Open();
			}
			catch (Exception ex)
			{
                MessageBox.Show(ex.Message);
				return;
			}
			Form2 form = new Form2();
			base.Hide();
			form.Show();
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
			this.comboBox1 = new ComboBox();
			this.label1 = new Label();
			this.button1 = new Button();
			this.button2 = new Button();
			base.SuspendLayout();
			this.comboBox1.DropDownStyle = ComboBoxStyle.DropDownList;
			this.comboBox1.FormattingEnabled = true;
			this.comboBox1.Location = new Point(12, 25);
			this.comboBox1.Name = "comboBox1";
			this.comboBox1.Size = new Size(284, 21);
			this.comboBox1.TabIndex = 0;
			this.comboBox1.SelectedIndexChanged += new EventHandler(this.comboBox1_SelectedIndexChanged);
			this.label1.AutoSize = true;
			this.label1.Location = new Point(12, 9);
			this.label1.Name = "label1";
			this.label1.Size = new Size(41, 13);
			this.label1.TabIndex = 1;
			this.label1.Text = "Device";
			this.label1.Click += new EventHandler(this.label1_Click);
			this.button1.Location = new Point(12, 52);
			this.button1.Name = "button1";
			this.button1.Size = new Size(75, 23);
			this.button1.TabIndex = 2;
			this.button1.Text = "Refresh";
			this.button1.UseVisualStyleBackColor = true;
			this.button1.Click += new EventHandler(this.button1_Click);
			this.button2.Location = new Point(221, 52);
			this.button2.Name = "button2";
			this.button2.Size = new Size(75, 23);
			this.button2.TabIndex = 3;
			this.button2.Text = "Go";
			this.button2.UseVisualStyleBackColor = true;
			this.button2.Click += new EventHandler(this.button2_Click);
			base.AcceptButton = this.button2;
			base.AutoScaleDimensions = new SizeF(6f, 13f);
			base.AutoScaleMode = AutoScaleMode.Font;
			base.ClientSize = new Size(308, 80);
			base.Controls.Add(this.button2);
			base.Controls.Add(this.button1);
			base.Controls.Add(this.label1);
			base.Controls.Add(this.comboBox1);
			base.Name = "Form1";
            this.Text = "Select Device " + G.appVersion;
			base.Load += new EventHandler(this.Form1_Load);
			base.ResumeLayout(false);
			base.PerformLayout();
		}
	}
}
