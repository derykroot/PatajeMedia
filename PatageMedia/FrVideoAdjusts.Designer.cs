
namespace PatageMedia
{
    partial class FrVideoAdjusts
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
            this.Label4 = new System.Windows.Forms.Label();
            this.tckbHue = new System.Windows.Forms.TrackBar();
            this.Label3 = new System.Windows.Forms.Label();
            this.tckbSat = new System.Windows.Forms.TrackBar();
            this.tckbConst = new System.Windows.Forms.TrackBar();
            this.Label2 = new System.Windows.Forms.Label();
            this.tckbBright = new System.Windows.Forms.TrackBar();
            this.Label1 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.tckbHue)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.tckbSat)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.tckbConst)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.tckbBright)).BeginInit();
            this.SuspendLayout();
            // 
            // Label4
            // 
            this.Label4.AutoSize = true;
            this.Label4.Location = new System.Drawing.Point(30, 188);
            this.Label4.Name = "Label4";
            this.Label4.Size = new System.Drawing.Size(27, 13);
            this.Label4.TabIndex = 17;
            this.Label4.Text = "Hue";
            // 
            // tckbHue
            // 
            this.tckbHue.Location = new System.Drawing.Point(96, 188);
            this.tckbHue.Name = "tckbHue";
            this.tckbHue.Size = new System.Drawing.Size(225, 45);
            this.tckbHue.TabIndex = 16;
            // 
            // Label3
            // 
            this.Label3.AutoSize = true;
            this.Label3.Location = new System.Drawing.Point(30, 137);
            this.Label3.Name = "Label3";
            this.Label3.Size = new System.Drawing.Size(55, 13);
            this.Label3.TabIndex = 15;
            this.Label3.Text = "Saturation";
            // 
            // tckbSat
            // 
            this.tckbSat.Location = new System.Drawing.Point(96, 137);
            this.tckbSat.Name = "tckbSat";
            this.tckbSat.Size = new System.Drawing.Size(225, 45);
            this.tckbSat.TabIndex = 14;
            // 
            // tckbConst
            // 
            this.tckbConst.Location = new System.Drawing.Point(96, 35);
            this.tckbConst.Name = "tckbConst";
            this.tckbConst.Size = new System.Drawing.Size(225, 45);
            this.tckbConst.TabIndex = 13;
            // 
            // Label2
            // 
            this.Label2.AutoSize = true;
            this.Label2.Location = new System.Drawing.Point(30, 86);
            this.Label2.Name = "Label2";
            this.Label2.Size = new System.Drawing.Size(56, 13);
            this.Label2.TabIndex = 12;
            this.Label2.Text = "Brightness";
            // 
            // tckbBright
            // 
            this.tckbBright.Location = new System.Drawing.Point(96, 86);
            this.tckbBright.Name = "tckbBright";
            this.tckbBright.Size = new System.Drawing.Size(225, 45);
            this.tckbBright.TabIndex = 11;
            // 
            // Label1
            // 
            this.Label1.AutoSize = true;
            this.Label1.Location = new System.Drawing.Point(30, 35);
            this.Label1.Name = "Label1";
            this.Label1.Size = new System.Drawing.Size(46, 13);
            this.Label1.TabIndex = 10;
            this.Label1.Text = "Contrast";
            // 
            // FrVideoAdjusts
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(379, 272);
            this.Controls.Add(this.Label4);
            this.Controls.Add(this.tckbHue);
            this.Controls.Add(this.Label3);
            this.Controls.Add(this.tckbSat);
            this.Controls.Add(this.tckbConst);
            this.Controls.Add(this.Label2);
            this.Controls.Add(this.tckbBright);
            this.Controls.Add(this.Label1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Name = "FrVideoAdjusts";
            this.ShowInTaskbar = false;
            this.Text = "Adjusts";
            this.Load += new System.EventHandler(this.FrVideoAdjusts_Load);
            ((System.ComponentModel.ISupportInitialize)(this.tckbHue)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.tckbSat)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.tckbConst)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.tckbBright)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        internal System.Windows.Forms.Label Label4;
        internal System.Windows.Forms.TrackBar tckbHue;
        internal System.Windows.Forms.Label Label3;
        internal System.Windows.Forms.TrackBar tckbSat;
        internal System.Windows.Forms.TrackBar tckbConst;
        internal System.Windows.Forms.Label Label2;
        internal System.Windows.Forms.TrackBar tckbBright;
        internal System.Windows.Forms.Label Label1;
    }
}