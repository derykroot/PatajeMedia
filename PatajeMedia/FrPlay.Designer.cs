
namespace PatajeMedia
{
    partial class FrPlay
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrPlay));
            this.ContextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.TSMOpenMedia = new System.Windows.Forms.ToolStripMenuItem();
            this.TSMSettings = new System.Windows.Forms.ToolStripMenuItem();
            this.OpenFileDiag = new System.Windows.Forms.OpenFileDialog();
            this.LbOM = new System.Windows.Forms.Label();
            this.ContextMenuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // ContextMenuStrip1
            // 
            this.ContextMenuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.TSMOpenMedia,
            this.TSMSettings});
            this.ContextMenuStrip1.Name = "ContextMenuStrip1";
            this.ContextMenuStrip1.Size = new System.Drawing.Size(140, 48);
            // 
            // TSMOpenMedia
            // 
            this.TSMOpenMedia.Name = "TSMOpenMedia";
            this.TSMOpenMedia.Size = new System.Drawing.Size(139, 22);
            this.TSMOpenMedia.Text = "Open Media";
            // 
            // TSMSettings
            // 
            this.TSMSettings.Name = "TSMSettings";
            this.TSMSettings.Size = new System.Drawing.Size(139, 22);
            this.TSMSettings.Text = "Adjusts";
            // 
            // LbOM
            // 
            this.LbOM.AllowDrop = true;
            this.LbOM.ContextMenuStrip = this.ContextMenuStrip1;
            this.LbOM.Font = new System.Drawing.Font("Microsoft Sans Serif", 48F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LbOM.ForeColor = System.Drawing.SystemColors.ControlDark;
            this.LbOM.Location = new System.Drawing.Point(0, -2);
            this.LbOM.Margin = new System.Windows.Forms.Padding(0);
            this.LbOM.Name = "LbOM";
            this.LbOM.Padding = new System.Windows.Forms.Padding(30);
            this.LbOM.Size = new System.Drawing.Size(613, 442);
            this.LbOM.TabIndex = 1;
            this.LbOM.Text = "Drop or Right Mouse Click";
            this.LbOM.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // FrPlay
            // 
            this.AllowDrop = true;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(609, 440);
            this.ContextMenuStrip = this.ContextMenuStrip1;
            this.ControlBox = false;
            this.Controls.Add(this.LbOM);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "FrPlay";
            this.Load += new System.EventHandler(this.FrPlay_Load);
            this.ContextMenuStrip1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        internal System.Windows.Forms.ContextMenuStrip ContextMenuStrip1;
        internal System.Windows.Forms.ToolStripMenuItem TSMOpenMedia;
        internal System.Windows.Forms.ToolStripMenuItem TSMSettings;
        internal System.Windows.Forms.OpenFileDialog OpenFileDiag;
        internal System.Windows.Forms.Label LbOM;
    }
}