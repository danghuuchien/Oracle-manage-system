using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AdminApp.CustomControls
{
	public partial class ButtonMinimized : UserControl
	{
		public ButtonMinimized()
		{
			InitializeComponent();
		}

		private void button1_Click(object sender, EventArgs e)
		{
			Form f = this.FindForm();
			f.WindowState = FormWindowState.Minimized;
		}
	}
}
