using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

using static PatageMedia.Fms;

namespace PatageMedia
{
    public partial class FrVideoAdjusts : Form
    {
        public FrVideoAdjusts()
        {
            InitializeComponent();
        }

        private void FrVideoAdjusts_Load(object sender, EventArgs e)
        {
            oFrPlay.mplay.Sliders.Contrast = tckbConst;
            oFrPlay.mplay.Sliders.Saturation = tckbSat;
            oFrPlay.mplay.Sliders.Brightness = tckbBright;
            oFrPlay.mplay.Sliders.Hue = tckbHue;
        }
    }
}
