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
	[DefaultEvent("_TextChanged")]
	public partial class CustomTextbox : UserControl
	{
		private Color borderColor = Color.Black;
		private int borderSize = 2;
		private bool underlineStyle = false;
		private Color focusBorderColor = Color.Black;
		private Color tempColor = Color.Black;
		public CustomTextbox()
		{
			InitializeComponent();
			this.Enter += TransparentTextbox_Enter;
			this.Leave += TransparentTextbox_Leave;
		}

		public event EventHandler _TextChanged;

		public Color BorderColor { get { return borderColor; } set { borderColor = value; this.Invalidate(); } }
		public int BorderSize { get { return borderSize; } set { borderSize = value; this.Invalidate(); } }
		public bool UnderlineStyle { get { return underlineStyle; } set { underlineStyle = value; this.Invalidate(); } }
		public Color FocusBorderColor { get { return focusBorderColor; } set { focusBorderColor = value; } }
		public char PasswordChar { get { return textBox1.PasswordChar; } set { textBox1.PasswordChar = value; } }
		public override Color BackColor { get { return base.BackColor; } set { base.BackColor = value; textBox1.BackColor = value; } }
		public override Color ForeColor { get { return base.ForeColor; } set { base.ForeColor = value; } }
		public override Font Font
		{
			get { return base.Font; }
			set
			{
				base.Font = value;
				if (this.DesignMode)
				{
					UpdateControlHeight();
				}
			}
		}
		public bool ReadOnly
		{
			get { return textBox1.ReadOnly; }
			set { textBox1.ReadOnly = value; }
		}

		public string Texts
		{
			get { return textBox1.Text; }
			set { textBox1.Text = value; }
		}

		protected override void OnPaint(PaintEventArgs e)
		{
			base.OnPaint(e);
			Graphics graph = e.Graphics;

			using (Pen penBorder = new Pen(BorderColor, borderSize))
			{
				penBorder.Alignment = System.Drawing.Drawing2D.PenAlignment.Inset;
				if (underlineStyle)
				{
					graph.DrawLine(penBorder, 0, this.Height - 1, this.Width, this.Height - 1);
				}
				else
				{
					graph.DrawRectangle(penBorder, 0, 0, this.Width - 0.5f, this.Height - 0.5f);
				}
			}
		}

		protected override void OnResize(EventArgs e)
		{
			base.OnResize(e);
			if (this.DesignMode)
			{
				UpdateControlHeight();
			}
		}

		protected override void OnLoad(EventArgs e)
		{
			base.OnLoad(e);
			UpdateControlHeight();
		}

		private void UpdateControlHeight()
		{
			if (textBox1.Multiline == false)
			{
				int textHeght = TextRenderer.MeasureText("Text", this.Font).Height + 1;
				textBox1.Multiline = true;
				textBox1.MinimumSize = new Size(0, textHeght);
				textBox1.Multiline = false;
				this.Height = textBox1.Height + this.Padding.Top + this.Padding.Bottom;
			}
		}

		private void TransparentTextbox_Leave(object sender, EventArgs e)
		{
			BorderColor = tempColor;
			this.OnMouseLeave(e);
		}

		private void TransparentTextbox_Enter(object sender, EventArgs e)
		{
			tempColor = BorderColor;
			BorderColor = FocusBorderColor;
		}

		private void textBox1_TextChanged(object sender, EventArgs e)
		{
			_TextChanged?.Invoke(sender, e);
		}

	}
}
