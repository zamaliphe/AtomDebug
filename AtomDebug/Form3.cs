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
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Windows.Forms;

namespace AtomDebug
{
    public partial class AtomControl : Form
    {
        protected Form2 _parent;

        public AtomControl(Form2 p)
        {
            _parent = p;
            InitializeComponent();
        }

        private void _updateView()
        {
            int len;
            string sTarget = txtTarget.Text.Replace(" ", "").Replace("\n", "");
            string sBlock = txtBlock.Text.Replace(" ", "").Replace("\n", "");

            if (sTarget.IndexOf("54", 0) == 0)
                sTarget = sTarget.Substring(2);

            len = sTarget.Length / 2;
            lblTarget.Text = String.Format("Target {0} bytes", len);
            btnSendTarget.Enabled = (len == 32);


            if (sBlock.IndexOf("38", 0) == 0)
                sBlock = sBlock.Substring(2);

            len = sBlock.Length / 2;
            lblBlock.Text = String.Format("Block {0} bytes", len);
            btnSendBlock.Enabled = (len == 48);
        }

        private void _saveValues()
        {
            G.SaveValue("target", txtTarget.Text);
            G.SaveValue("block", txtBlock.Text);
            G.SaveValue("freq", comboFreq.SelectedIndex.ToString());
        }

        private void _readDeviceInfo()
        {
            _parent.IgnoreOutput(true);

            _parent.SendCmd("49");
            while (G.usbPort.BytesToRead < 32)
                Thread.Sleep(100);
            byte[] array = new byte[32];
            G.usbPort.Read(array, 0, 32);
            string ver = System.Text.Encoding.Default.GetString(array).Substring(0, 17);
            string log = array.ToHex();
            _parent.addOutput(false, log);

            _parent.SendCmd("53");
            while (G.usbPort.BytesToRead < 4)
                Thread.Sleep(100);
            array = new byte[4];
            G.usbPort.Read(array, 0, 4);
            int nFreq = 24 + (int)array[0];
            log = array.ToHex();
            _parent.addOutput(false, log);

            _parent.IgnoreOutput(false);

            lblDev.Text = String.Format("Connected device: {0} @ {1}Mhz", ver, nFreq);
        }

        private void AtomControl_Load(object sender, EventArgs e)
        {
            _readDeviceInfo();

            txtTarget.Text = G.LoadValue("target", "0000000000000000c68ef0b049f8d1a3cf8e499481993a99cf8279f543c466db");
            txtBlock.Text = G.LoadValue("block", "4170CACD2404388EF32D36D60FA88086F162F46EAF7AF910AD7AEC58F1B85791c605232b5c8c0553535f0119ccad1657");

            for (int i = 25; i < 121; i++)
                comboFreq.Items.Add(String.Format("{0} Mhz", i));

            comboFreq.SelectedIndex = Convert.ToInt32(G.LoadValue("freq", "0"));

            _updateView();
        }

        private void btnSet_Click(object sender, EventArgs e)
        {
            byte newFreq = (byte)(comboFreq.SelectedIndex + 1);
            _saveValues();

            _parent.SendCmd("34");
            _parent.SendCmd("31");
            _parent.SendCmd(String.Format("43{0:X2}", newFreq));
            _parent.SendCmd("31");

            _readDeviceInfo();
        }

        private void btnStop_Click(object sender, EventArgs e)
        {
            _parent.SendCmd("34");
            _parent.SendCmd("31");
        }

        private void btnSendTarget_Click(object sender, EventArgs e)
        {
            string sTarget = txtTarget.Text.Replace(" ", "").Replace("\n", "");
            
            _saveValues();

            _parent.SendCmd("54" + sTarget);
        }

        private void btnSendBlock_Click(object sender, EventArgs e)
        {
            string sBlock = txtBlock.Text.Replace(" ", "").Replace("\n", "");

            _saveValues();

            _parent.SendCmd("38" + sBlock);
        }

        private void btnStart_Click(object sender, EventArgs e)
        {
            _saveValues();

            _parent.SendCmd("32");
        }

        private void txtTarget_TextChanged(object sender, EventArgs e)
        {
            _updateView();
        }

        private void txtBlock_TextChanged(object sender, EventArgs e)
        {
            _updateView();
        }
    }
}
