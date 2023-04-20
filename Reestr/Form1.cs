using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Reestr
{
	public partial class Form1 : Form
	{
		public Form1()
		{
			InitializeComponent();
		}

		private void button1_Click(object sender, EventArgs e)
		{
			RegistryKey currentUserKey = Registry.CurrentUser;
			RegistryKey myKey = currentUserKey.CreateSubKey("MyKey");
			myKey.SetValue("name", "Daria");
			myKey.SetValue("age", "20");
			myKey.Close();

			
		}

		private void button2_Click(object sender, EventArgs e)
		{
			RegistryKey currentUserKey = Registry.CurrentUser;
			RegistryKey myKey = currentUserKey.OpenSubKey("MyKey");

			string login = myKey.GetValue("name").ToString();
			string password = myKey.GetValue("age").ToString();
			myKey.Close();
			richTextBox1.Text = login + '\n'+ password.ToString();
		}

		private void button3_Click(object sender, EventArgs e)
		{
			RegistryKey currentUserKey = Registry.CurrentUser;
			RegistryKey myKey = currentUserKey.OpenSubKey("MyKey", true);
			// удаляем значение из ключа
			myKey.DeleteValue("name");
			myKey.Close();
			// удаляем сам ключ
			currentUserKey.DeleteSubKey("MyKey");
		}
	}
}
