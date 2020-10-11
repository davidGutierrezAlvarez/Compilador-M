using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using System.Windows.Forms;

namespace M {
    public class ColorMenu : ProfessionalColorTable {
        public ColorMenu()
        {
            // see notes
            base.UseSystemColors = false;
        }
        public override Color MenuBorder {
            get { return Color.FromArgb(27, 27, 28); }
        }

        public override Color MenuItemBorder {
            get { return Color.FromArgb(45, 45, 48); }
        }

        public override Color MenuItemSelected {
            get { return Color.FromArgb(62, 62, 64); }
        }


        public override Color MenuItemSelectedGradientBegin {
            get { return Color.FromArgb(62, 62, 64); }
        }

        public override Color MenuItemSelectedGradientEnd {
            get { return Color.FromArgb(62, 62, 64); }
        }


        public override Color MenuItemPressedGradientBegin {
            get { return Color.FromArgb(27, 27, 28); }
        }

        public override Color MenuItemPressedGradientEnd {
            get { return Color.FromArgb(27, 27, 28); }
        }


        public override Color ToolStripDropDownBackground
        {
            get { return Color.FromArgb(27, 27, 28); }
        }

        public override Color SeparatorDark {
            get { return Color.FromArgb(25, 45, 255); }
        }

        public override Color SeparatorLight 
        {
            get { return Color.FromArgb(255, 45, 0); }
        }




    }
}
