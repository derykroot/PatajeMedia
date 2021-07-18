using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

using static PatageMedia.globalmod;
using static PatageMedia.Fms;

namespace PatageMedia
{

    public partial class FrPlay : Form
    {
        public static FrPlay othis = new FrPlay();  

        int prevposx;
        int prevposy;
        private bool OpenFileShowing = false;

        public PVS.MediaPlayer.Player mplay = new PVS.MediaPlayer.Player();

        public FrPlay()
        {
            InitializeComponent();
        }

        private void FrPlay_Load(object sender, EventArgs e)
        {
            mplay.Sliders.Position.TrackBar = oFrCtl.TBPos;
            mplay.Sliders.AudioVolume = oFrCtl.TrackBVol;

            AddEvents();
        }

        private void AddEvents()
        {
            // ----- move form
            this.MouseMove += new System.Windows.Forms.MouseEventHandler(ctl_mousemove);
            LbOM.MouseMove += new System.Windows.Forms.MouseEventHandler(ctl_mousemove);

            // ------ Mplay Cp
            mplay.Events.MediaEnded += new EventHandler<PVS.MediaPlayer.EndedEventArgs>(mediaend);
            mplay.Events.MediaStarted += new EventHandler(mediastart);
            mplay.Events.MediaPositionChanged += new EventHandler<PVS.MediaPlayer.PositionEventArgs>(mediaposchanged);

            // ----- Cps
            this.Shown += new System.EventHandler(FrPlay_Shown);
            TSMOpenMedia.Click += new System.EventHandler(TSMOpenMedia_Click);
            TSMSettings.Click += new System.EventHandler(TSMSettings_Click);
            LbOM.DragEnter += new System.Windows.Forms.DragEventHandler(LbOM_DragEnter);
            LbOM.DragDrop += new System.Windows.Forms.DragEventHandler(LbOM_DragDrop);
            this.DragEnter += new System.Windows.Forms.DragEventHandler(LbOM_DragEnter);
            this.DragDrop += new System.Windows.Forms.DragEventHandler(LbOM_DragDrop);
        }

        private void ctl_mousemove(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                if (OpenFileShowing) return;
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

        private void FrPlay_Shown(object sender, EventArgs e)
        {
            Adjustposctl();
        }

        private void TSMOpenMedia_Click(object sender, EventArgs e)
        {
            OpenFileShowing = true;
            Application.DoEvents();
            if (OpenFileDiag.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                Application.DoEvents();
                OpenFileShowing = false;
                LoadMedia(OpenFileDiag.FileName);
            }
        }
        private void TSMSettings_Click(object sender, EventArgs e)
        {
            Fms.oFrVideoAdjusts.Show();
        }

        private void LbOM_DragEnter(object sender, DragEventArgs e)
        {
            if (e.Data.GetDataPresent(DataFormats.FileDrop))
                e.Effect = DragDropEffects.All;
        }
        private void LbOM_DragDrop(object sender, DragEventArgs e)
        {
            if (e.Data.GetDataPresent(DataFormats.FileDrop))
            {
                string arq = (e.Data.GetData(DataFormats.FileDrop) as string[])[0];
                LoadMedia(arq);
            }
        }

        public void Adjustposctl()
        {
            Fms.oFrCtl.Location = new Point(this.Location.X - 5, this.Location.Y + this.Size.Height);
            if ((Fms.oFrCtl.Location.Y + Fms.oFrCtl.Size.Height) > System.Windows.Forms.Screen.PrimaryScreen.WorkingArea.Height)
            {
                Fms.oFrCtl.Location = new Point(Fms.oFrCtl.Location.X, System.Windows.Forms.Screen.PrimaryScreen.WorkingArea.Height - Fms.oFrCtl.Size.Height);
                Fms.oFrCtl.Focus();
            }
        }

        private void FrmAdjustShow()
        {
            LbOM.Visible = false;
            if (this.FormBorderStyle != System.Windows.Forms.FormBorderStyle.None)
                this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            if (this.BackColor != Color.Black)
                this.BackColor = Color.Black;
        }

        public string extreplace(string fl, string ext)
        {
            var sts = fl.Split('.');
            if (sts.Length < 2)
                return fl + "." + ext;
            var res = sts[0];
            for (var i = 1; i <= sts.Length - 2; i++)
                res += "." + sts[i];
            res += "." + ext;
            return res;
        }

        public void openVid(string fl, bool resetres = true)
        {
            SetFileOpen(fl);
            FrmAdjustShow();

            this.BackgroundImage = null;
            mplay.Stop();
            mplay.Paused = false;

            Fms.oFrCtl.btplay.BackgroundImage = PatageMedia.Properties.Resources.pause;

            mplay.Play(fl, this);
            // mplay.Subtitles.FileName = extreplace(fl, "srt")
            // MsgBox(mplay.Subtitles.Exists & mplay.Subtitles.FileName & mplay.Subtitles.Count)
            if (resetres)
                this.Size = getmaxsize(mplay.Media.VideoSourceSize);
            if (Fms.oFrCtl.Location.Y < (this.Size.Height + this.Location.Y))
                Adjustposctl();
        }
        public void openImg(string fl)
        {
            SetFileOpen(fl);
            FrmAdjustShow();
            // mplay.Play(fl, Me)
            mplay.Stop();
            Application.DoEvents();
            this.BackgroundImage = new Bitmap(fl);
            this.BackgroundImageLayout = ImageLayout.Stretch;
            this.Size = getmaxsize(this.BackgroundImage.Size);
            if (Fms.oFrCtl.Location.Y < (this.Size.Height + this.Location.Y))
                Adjustposctl();
        }

        public void LoadMedia(string dest, bool resetres = true)
        {
            // MsgBox(OpenFileDiag.FileName)
            if (IsVideo(dest))
                openVid(dest, resetres);
            else if (IsImage(dest))
                openImg(dest);
        }

        private void mediaend(object sender, PVS.MediaPlayer.EndedEventArgs e)
        {
            oFrCtl.btplay.BackgroundImage = PatageMedia.Properties.Resources.play;
            oFrCtl.played = false;
        }
        private void mediastart(object sender, EventArgs e)
        {
            oFrCtl.btplay.BackgroundImage = PatageMedia.Properties.Resources.pause;
            oFrCtl.played = true;
        }
        private void mediaposchanged(object sender, PVS.MediaPlayer.PositionEventArgs e)
        {
            var fromStart = TimeSpan.FromTicks(e.FromStart);
            var toStop = TimeSpan.FromTicks(e.ToStop);

            oFrCtl.lbTm.Text = tmformat(fromStart) + " / " + tmformat(toStop.Add(fromStart));
            oFrCtl.lbTm.Refresh(); Application.DoEvents();
        }


    }
}
