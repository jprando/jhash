using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace JHashWin
{
    static class Program
    {
        [STAThread]
        static void Main(String[] args)
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            FormPrincipal princial = new FormPrincipal();

            if (args.Length >= 1)
            {
                if (args.Length != 3)
                { princial.Show(); }
                Application.DoEvents();
                princial.openFileDialog1.FileName = args[0];
                princial.CalcularHashInit();
                princial.CalcularHashOnLoad(args[0]);
                princial.CalcularHash(args[0]);
                Application.DoEvents();
            }

            if (args.Length != 3)
            {
                if (args.Length >= 2)
                { princial.txtComparar.Text = args[1]; }
            }

            if (args.Length == 3)
            {
                StreamWriter fHash = new StreamWriter(args[2]);
                try
                {
                    switch (args[1])
                    {
                        case "SHA256":
                            fHash.WriteLine(princial.txtSHA256.Text);
                            break;
                    }
                }
                finally
                { fHash.Close(); }
            }
            if (args.Length != 3)
            { Application.Run(princial); }
            else
            { princial.Dispose(); }
        }
    }
}


/// CIA201210251431