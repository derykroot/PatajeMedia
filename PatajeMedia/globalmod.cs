using Microsoft.VisualBasic;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;

namespace PatajeMedia
{
    public static class globalmod
    {
        public static string FileOpened;
        public static List<string> Dirlist = new List<string>();

        private static string[] extvids = new[] { "mp4", "avi", "mkv", "wmv", "m4v", "mov", "mpeg", "mpg", "3gp", "webm" };
        private static string[] extimgs = new[] { "jpg", "jpeg", "tif", "tiff", "png", "bmp", "gif" };

        public static int ctdimgzoom = 0;

        public static void SetFileOpen(string fl)
        {
            FileOpened = fl;
            var fls = (new System.IO.FileInfo(fl)).Directory.GetFiles();

            Dirlist.Clear();
            if (IsVideo(fl))
            {
                for (var i = 0; i <= fls.Length - 1; i++)
                {
                    if (IsVideo(fls[i].FullName))
                        Dirlist.Add(fls[i].FullName);
                }
            }
            else if (IsImage(fl))
            {
                for (var i = 0; i <= fls.Length - 1; i++)
                {
                    if (IsImage(fls[i].FullName))
                        Dirlist.Add(fls[i].FullName);
                }
            }
        }

        public static string getnextmedia()
        {
            if (Dirlist.Count < 2)
                return null;

            var ord = Dirlist.OrderBy(fl => fl);
            var idx = Enumerable.Range(0, Dirlist.Count).Where(i => ord.ElementAt(i) == FileOpened).First();

            if (idx < Dirlist.Count - 1)
                return ord.ElementAt(idx + 1);
            else
                return null;
        }
        public static string getprevmedia()
        {
            if (Dirlist.Count < 2)
                return null;

            var ord = Dirlist.OrderBy(fl => fl);
            var idx = Enumerable.Range(0, Dirlist.Count).Where(i => ord.ElementAt(i) == FileOpened).First();

            if (idx > 0)
                return ord.ElementAt(idx - 1);
            else
                return null;
        }

        public static bool IsVideo(string filenm)
        {
            var ext = (new System.IO.FileInfo(filenm)).Extension.Replace(".", "").ToLower();

            return extvids.Contains(ext) ? true : false;
        }
        public static bool IsImage(string filenm)
        {
            var ext = (new System.IO.FileInfo(filenm)).Extension.Replace(".", "").ToLower();

            return extimgs.Contains(ext) ? true : false;
        }

        public static Size getreszoomctd(Size sz, int ctd)
        {
            if (ctd > 0)
            {
                sz = new Size((int)(sz.Width * 1.25), (int)(sz.Height * 1.25));
                ctd -= 1;
                return getreszoomctd(sz, ctd);
            }
            else if (ctd < 0)
            {
                sz = new Size((int)(sz.Width * 0.8), (int)(sz.Height * 0.8));
                ctd += 1;
                return getreszoomctd(sz, ctd);
            }
            else
                return sz;
        }
        public static Size getmaxsize(Size sz) // Caso o tamanho da midia seja maior que a resolução ajustar de acordo com o tamanho da midia
        {
            var szres = System.Windows.Forms.Screen.PrimaryScreen.WorkingArea.Size;
            if (sz.Width > szres.Width)
            {
                var difperc = ((sz.Width - szres.Width) / (double)sz.Width);
                sz.Width = sz.Width - (int)(difperc * sz.Width);
                sz.Height = sz.Height - (int)(difperc * sz.Height);
            }
            if (sz.Height > szres.Height)
            {
                var difperc = ((sz.Height - szres.Height) / (double)sz.Height);
                sz.Width = sz.Width - (int)(difperc * sz.Width);
                sz.Height = sz.Height - (int)(difperc * sz.Height);
            }

            return getreszoomctd(sz, ctdimgzoom);
        }

        public static string tmformat(TimeSpan tm)
        {
            return Strings.Format(tm.Hours, "##00") + ":" + Strings.Format(tm.Minutes, "##00") + ":" + Strings.Format(tm.Seconds, "##00");
        }
    }
}
