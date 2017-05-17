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
 
using Microsoft.Win32;
using System;
using System.IO.Ports;
using System.Linq;

namespace AtomDebug
{
	public static class G
	{
        public static string appName = "AtomDebug";
        public static string appVersion = "1.3";

		public static Form1 frmDevices = null;

		public static SerialPort usbPort = null;

		public static byte[] StringToByteArray(string hex)
		{
			return Enumerable.ToArray<byte>(Enumerable.Select<int, byte>(Enumerable.Where<int>(Enumerable.Range(0, hex.Length), (int x) => x % 2 == 0), (int x) => Convert.ToByte(hex.Substring(x, 2), 16)));
		}

		public static string ToHex(this byte[] bytes)
		{
			char[] array = new char[bytes.Length * 2];
			int i = 0;
			int num = 0;
			while (i < bytes.Length)
			{
				byte b = (byte)(bytes[i] >> 4);
				array[num] = (char)((b > 9) ? (b + 55 + 32) : (b + 48));
				b = (byte)(bytes[i] & 15);
				array[++num] = (char)((b > 9) ? (b + 55 + 32) : (b + 48));
				i++;
				num++;
			}
			return new string(array);
		}

		public static byte[] HexToBytes(this string str)
		{
			byte[] result;
			if (str.Length == 0 || str.Length % 2 != 0)
			{
				result = new byte[0];
			}
			else
			{
				byte[] array = new byte[str.Length / 2];
				int i = 0;
				int num = 0;
				while (i < array.Length)
				{
					char c = str[num];
					array[i] = (byte)(((c > '9') ? ((c > 'Z') ? (c - 'a' + '\n') : (c - 'A' + '\n')) : (c - '0')) << 4);
					c = str[++num];
					byte[] expr_80_cp_0 = array;
					int expr_80_cp_1 = i;
					expr_80_cp_0[expr_80_cp_1] |= (byte)((c > '9') ? ((c > 'Z') ? (c - 'a' + '\n') : (c - 'A' + '\n')) : (c - '0'));
					i++;
					num++;
				}
				result = array;
			}
			return result;
		}

        private static RegistryKey _openKey()
        {
            RegistryKey key = RegistryKey.OpenBaseKey(RegistryHive.CurrentUser, RegistryView.Default);

            key.CreateSubKey(appName);
            key = key.OpenSubKey(appName, true);


            key.CreateSubKey(appVersion);
            key = key.OpenSubKey(appVersion, true);

            return key;
        }

        public static void SaveValue(string name, string v)
        {
            RegistryKey key = _openKey();

            key.SetValue(name, v, RegistryValueKind.String);
        }

        public static string LoadValue(string name, string def)
        {
            RegistryKey key = _openKey();

            return key.GetValue(name, def).ToString();
        }
	}
}
