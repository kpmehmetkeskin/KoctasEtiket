using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Reflection;

namespace Koctas_tasarim
{
    public partial class frmEtiketSecimi : Form
    {
        public frmEtiketSecimi()
        {
            AppDomain.CurrentDomain.AssemblyResolve += (sender, args) =>
            {
                string resourceName = new AssemblyName(args.Name).Name + ".dll";
                string resource = Array.Find(this.GetType().Assembly.GetManifestResourceNames(), element => element.EndsWith(resourceName));

                using (var stream = Assembly.GetExecutingAssembly().GetManifestResourceStream(resource))
                {
                    Byte[] assemblyData = new Byte[stream.Length];
                    stream.Read(assemblyData, 0, assemblyData.Length);
                    return Assembly.Load(assemblyData);
                }
            };
            InitializeComponent();
        }

        private void btnCikis_Click(object sender, EventArgs e)
        {
            try
            {
                if (File.Exists(GlobalData.XMLPath))
                {
                    File.Delete(GlobalData.XMLPath);
                }
            }
            catch
            {
            }
            Application.ExitThread();
        }

        private void btnDevam_Click(object sender, EventArgs e)
        {
            if (lbEtiket.SelectedItems.Count == 0)
            {
                MessageBox.Show("Devam etmek i\x00e7in l\x00fctfen etiket tipi se\x00e7iniz");
            }
            else
            {
                GlobalData.secilenEtiket = lbEtiket.SelectedItems[0].ToString();
                frmEtiket etiket = new frmEtiket();
                Hide();
                etiket.ShowDialog();
                Show();
                if (GlobalData.string_0 == "")
                {
                    textBox1.Text = "";
                    lbEtiket.Items.Clear();
                }
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            openFileDialog1.Filter = "Desgin files (*.dsgn)|*.dsgn";
            openFileDialog1.FileName = "";
            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                GlobalData.string_0 = openFileDialog1.FileName;
                string path =Application.StartupPath + @"\koctasTasarim.dsgn";
                string str3 =Application.StartupPath + @"\koctasTasarim2.dsgn";
                if (File.Exists(path))
                {
                    File.Delete(path);
                }
                if (File.Exists(str3))
                {
                    File.Delete(str3);
                }
                //kullanıcı tarafından secilen design dosyası açılır.
                File.Copy(GlobalData.string_0, str3);
                Functions.DecryptFile(str3, path);
                GlobalData.XMLPath = path;
                textBox1.Text = GlobalData.string_0;
                Functions.EtiketleriGetir(lbEtiket);
                groupBox1.Visible = true;
            }
        }
        private void frmEtiketSecimi_Load(object sender, EventArgs e)
        {
            textBox1.Text = "";
            if (GlobalData.string_0 == "")
            {
                groupBox1.Visible = false;
            }
        }

    }
}
