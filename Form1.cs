using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace M {
	public partial class Form : System.Windows.Forms.Form {
		Lexico lex = new Lexico();
		Font fontNormal = new Font("Consolas", 12F, FontStyle.Regular);
		Font fontUnderline = new Font("Consolas", 12F, FontStyle.Underline | FontStyle.Regular);
		SolidBrush brocha = new SolidBrush(Color.LightSkyBlue);
		Bitmap bmp;
		Graphics g;
		int counter = 0;
		bool isScri = false;
		public Form() {
			InitializeComponent();

			bmpResize();
			resize();
		}

		private void richTextBox_TextChanged(object sender, EventArgs e)
		{
			drawTokens();
			drawNumbers();
		}

		void bmpResize() {
			bmp = new Bitmap(pictureBox.Width, pictureBox.Height);
			pictureBox.Image = bmp;
			g = Graphics.FromImage(bmp);
		}

		void drawTokens() {
			//cabiar foco
			this.menuStrip1.Focus();
			if (!isScri) {
				counter++;
				isScri = true;
				label1.Text = counter.ToString();

				List<Token> ltokens = lex.scaner(richTextBox.Text);
				int pos = richTextBox.SelectionStart;
				int length = richTextBox.SelectionLength;

				foreach (Token token in ltokens) {
					if (token.Pos == -1 || token.Lexeme.Length == -1)
						continue;

					//selecciono el espacion del token
					richTextBox.Select(token.Pos, token.Lexeme.Length);
					//cambio de color al que pida el token
					richTextBox.SelectionColor = token.Color;

					if (token.State == "error") {
						//si es un token de error lo subrayo
						richTextBox.SelectionFont = fontUnderline;
						//marco el final del token
						richTextBox.Select(token.Pos + token.Lexeme.Length, 1);
					}
					//si el token es valido le quito el subrayado
					richTextBox.SelectionFont = fontNormal;
				}

				richTextBox.Select(pos, length);
				//recuperar foco
			}
			richTextBox.Focus();
		}

		void drawNumbers()
		{
			int caracter = 0;
			int h = richTextBox.GetPositionFromCharIndex(0).Y;

			if (richTextBox.Lines.Length > 0)
			{
				g.Clear(Color.Transparent);
				for (int i = 0; i < richTextBox.Lines.Length; i++)
				{
					if (h > -10 && h < this.Height)
					{
						g.DrawString((i + 1).ToString(), fontNormal, brocha, pictureBox.Width - g.MeasureString((i + 1).ToString(), richTextBox.Font).Width - 10, h);
					}
					caracter += richTextBox.Lines[i].Length + 1;
					h = richTextBox.GetPositionFromCharIndex(caracter).Y;
				}
				pictureBox.Refresh();
			}
			else
			{
				g.DrawString("1", fontNormal, brocha, pictureBox.Width - g.MeasureString("1", richTextBox.Font).Width - 10, h);
			}
		}

		void resize() {
			panelCentral.Width = this.Width - 80;
			panelCentral.Height = this.Height - 55;
			pictureBox.Top = panelCentral.Top;
			pictureBox.Height = panelCentral.Height;
			pictureBox.Left = panelCentral.Left - pictureBox.Width;
			//closed.Left = this.Width - 40;
		}

		private void Form_Resize(object sender, EventArgs e) {
			resize();
			bmpResize();
			drawNumbers();
		}

		private void button2_Click(object sender, EventArgs e)
		{
			this.Close();
		}

		private void richTextBox_VScroll(object sender, EventArgs e)
		{
			drawNumbers();
		}


		private void richTextBox_KeyPress(object sender, KeyPressEventArgs e)
		{
			if (e.KeyChar == (char)Keys.Tab)
			{
				e.Handled = true;
				richTextBox.SelectedText = new string(' ', 4);
			}
		}

        private void timer1_Tick(object sender, EventArgs e) {
			if(isScri) {
				isScri = false;
            }
        }
    }
}