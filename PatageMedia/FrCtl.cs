using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Windows.Forms;

using static PatageMedia.globalmod;
using static PatageMedia.Fms;

namespace PatageMedia
{
    public partial class FrCtl : Form
    {

        [DllImport("user32.dll", SetLastError = true, CharSet = CharSet.Auto)]
        public static extern bool SetWindowText(IntPtr hwnd, String lpString);

        [DllImport("user32.dll", SetLastError = true)]
        private static extern bool SetWindowPos(IntPtr hWnd, IntPtr hWndInsertAfter, int x, int y, int cx, int cy, uint uFlags);

        private int prevposx;
        private int prevposy;
        private int hlocked = 70;

        public bool played = false;

        public FrCtl()
        {
            InitializeComponent();

            // ----- move form
            pnbartop.MouseMove += new System.Windows.Forms.MouseEventHandler(pn_mousemove);
            pnmove.MouseMove += new System.Windows.Forms.MouseEventHandler(pn_mousemove);
        }

        private void pn_mousemove(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                var difx = prevposx - e.X;
                var dify = prevposy - e.Y;
                this.Location = new Point(this.Location.X - difx, this.Location.Y - dify);
            }
            else
            {
                prevposx = e.X;
                prevposy = e.Y;
            }
        }

        private void FrCtl_Load(object sender, EventArgs e)
        {
            Fms.oFrPlay.Show();

            this.btstop.Click += new System.EventHandler(Btplaystop_Click);
            this.btplay.Click += new System.EventHandler(Btplaystop_Click);
            this.btnext.Click += new System.EventHandler(btnextprev_Click);
            this.btprev.Click += new System.EventHandler(btnextprev_Click);
            this.btnextfrms.Click += new System.EventHandler(btfrms_Click);
            this.btprevfrms.Click += new System.EventHandler(btfrms_Click);

            this.lbsizeinc.MouseDown += new System.Windows.Forms.MouseEventHandler(lbsizeinc_MouseDown);
            this.lbsizereduc.MouseDown += new System.Windows.Forms.MouseEventHandler(lbsizereduc_MouseDown);

            this.lbsizeinc.MouseHover += new EventHandler(lbsizes_MouseHover);
            this.lbsizereduc.MouseHover += new EventHandler(lbsizes_MouseHover);
            this.lbsizeinc.MouseLeave += new EventHandler(lbsizes_MouseLeave);
            this.lbsizereduc.MouseLeave += new EventHandler(lbsizes_MouseLeave);
        }

        private void Btplaystop_Click(object sender, EventArgs e)
        {
            if (((Button)sender).Handle == btplay.Handle)
            {
                if (FileOpened == null) return;

                if (played)
                {
                    btplay.BackgroundImage = PatageMedia.Properties.Resources.play;
                    oFrPlay.mplay.Paused = true;
                    played = false;
                }
                else
                {
                    btplay.BackgroundImage = PatageMedia.Properties.Resources.pause;
                    // FrPlay.mplay.Paused = False
                    oFrPlay.mplay.Resume();
                    if (oFrPlay.mplay.Media.GetVideoTracks() == null && IsVideo(FileOpened))
                    oFrPlay.LoadMedia(FileOpened, false);
                    played = true;
                }
            }
            else // STOP
            {
                oFrPlay.mplay.Stop();
                played = false;
            }
        }

        private void btnextprev_Click(object sender, EventArgs e)
        {
            var fl = ((Button)sender).Handle == btnext.Handle ? getnextmedia() : getprevmedia();
            if (fl != null) oFrPlay.LoadMedia(fl);
        }
        private void btfrms_Click(object sender, EventArgs e)
        {
            oFrPlay.mplay.Position.Step(((Button)sender).Handle == btnextfrms.Handle ? 100 : -100);
        }

        private void lbsizeinc_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button != System.Windows.Forms.MouseButtons.Left)
                return;
            oFrPlay.Size = new Size(oFrPlay.Size.Width + (int)(oFrPlay.Size.Width * 0.25), oFrPlay.Size.Height + (int)(oFrPlay.Size.Height * 0.25));
            if (IsImage(FileOpened))
                ctdimgzoom += 1;
        }

        private void lbsizereduc_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button != System.Windows.Forms.MouseButtons.Left)
                return;
            oFrPlay.Size = new Size(oFrPlay.Size.Width - (int)(oFrPlay.Size.Width * 0.2), oFrPlay.Size.Height - (int)(oFrPlay.Size.Height * 0.2));
            if (IsImage(FileOpened))
                ctdimgzoom -= 1;
        }

        private void lbsizes_MouseHover(object sender, EventArgs e)
        {
            ((Control)sender).BackColor = Color.FromArgb(100, 130, 140);
        }
        private void lbsizes_MouseLeave(object sender, EventArgs e)
        {
            ((Control)sender).BackColor = Color.FromArgb(130, 160, 170);
        }

        private void BtExpand_Click(object sender, EventArgs e)
        {
            if (this.BtExpand.Text == "< >")
            {
                this.Size = new Size(System.Windows.Forms.Screen.PrimaryScreen.WorkingArea.Size.Width, this.Height);
                this.Location = new Point(0, this.Location.Y);
                this.BtExpand.Text = "> <";
            }
            else
            {
                this.Size = new Size(619, hlocked);
                this.Location = new Point(oFrPlay.Location.X, this.Location.Y);
                this.BtExpand.Text = "< >";
            }
        }

        private void BtExit_Click(object sender, EventArgs e)
        {
            // System.Environment.Exit(0);
            Application.Exit();
        }

    }
}
