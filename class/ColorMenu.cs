using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using System.Windows.Forms;

namespace M {
    public class ColorMenu : ProfessionalColorTable {
        int hover = 0x7800FF00;//(27, 27, 28)
        public ColorMenu() {
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


        public override Color ToolStripDropDownBackground {
            get { return Color.FromArgb(27, 27, 28); }
        }

        public override Color SeparatorDark {
            get { return Color.FromArgb(25, 45, 255); }
        }

        public override Color SeparatorLight  {
            get { return Color.FromArgb(255, 45, 0); }
        }


        public override Color ToolStripContentPanelGradientBegin
        {
            get { return Color.FromArgb(hover); }
        }

        public override Color ToolStripBorder
        {
            get { return Color.FromArgb(hover); }
        }

    }



    public partial class CustomToolStrip : MenuStrip {

        public CustomToolStrip() {
            this.RenderMode = ToolStripRenderMode.ManagerRenderMode;
            this.Renderer = new ToolStripProfessionalRenderer(new ColorMenu());
            this.BackColor = Color.FromArgb(45, 45, 48);
            this.ForeColor = Color.White;

        }

        public Color ToolStripForeColor {
            get { return Color.Red; }
        }


    }
}
