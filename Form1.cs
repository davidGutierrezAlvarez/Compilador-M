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
    public partial class Form1 : Form {
		Lexico lex = new Lexico();
        public Form1() {
            InitializeComponent();
        }

        private void richTextBox_TextChanged(object sender, EventArgs e) {
            drawTokens();
        }

        void drawTokens() {
			//cabiar foco
			//this.Focus();

			List<Token> ltokens = lex.scaner(richTextBox.Text);
			int pos = richTextBox.SelectionStart;
			int length = richTextBox.SelectionLength;

			foreach (Token token in ltokens) {
				if (token.Pos == -1 || token.Lexeme.Length == -1)
					continue;
				richTextBox.Select(token.Pos, token.Lexeme.Length);
				//textBox.Find(token.TokenName, RichTextBoxFinds.None);
				if (token.State == "int" || token.State == "list" || token.State == "del") {
					richTextBox.SelectionColor = Color.Red;
				} else {
					richTextBox.SelectionColor = Color.Black;
				}
			}

			richTextBox.Select(pos, length);

			//recuperar foco
			//richTextBox.Focus();
		}
    }
}
