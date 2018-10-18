using NBarCodes;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Printing;
using System.IO;
using System.Text;
using System.Windows.Forms;
using System.Xml;
using System.Reflection;
namespace Koctas_etiket
{
    public partial class Form1 : Form
    {

        string urlPath = Application.StartupPath;

        public Form1()
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

         

        private void btnPrint1_Click(object sender, EventArgs e)
        {
            GlobalData.reyonList.Clear();
            if (GlobalData.etkList1.Count == 0)
            {
                MessageBox.Show("Yazdırılarak etiket bulunmamaktadır");
            }
            else
            {
                try
                {
                    string printer =cbPrinter.SelectedItem.ToString();
                    int result = 0;
                    try
                    {
                        int.TryParse(tbBos1.Text.Trim(), out result);
                    }
                    catch
                    {
                        MessageBox.Show("Boş etiket sayısı rakam olmak zorundadır");
                        return;
                    }
                    try
                    {
                        GlobalData.reyonList.Clear();
                        int num2 = 0;
                        while (num2 < GlobalData.etkList1.Count)
                        {
                            if (!GlobalData.reyonList.Contains(GlobalData.etkList1[num2].reyon.Substring(0, 3)))
                            {
                                GlobalData.reyonList.Add(GlobalData.etkList1[num2].reyon.Substring(0, 3));
                            }
                            num2++;
                        }
                        for (int i = 0; i < GlobalData.reyonList.Count; i++)
                        {
                            GlobalData.dummy.Clear();
                            for (num2 = 0; num2 < GlobalData.etkList1.Count; num2++)
                            {
                                if (GlobalData.etkList1[num2].reyon.Substring(0, 3) == GlobalData.reyonList[i])
                                {
                                    GlobalData.dummy.Add(GlobalData.etkList1[num2]);
                                }
                            }
                            if (i >= 1)
                            {
                                result = 0;
                            }
                           itabprint("001", GlobalData.dummy, printer, result);
                        }
                    }
                    catch (Exception exception)
                    {
                        MessageBox.Show("Etiket \x00e7ıktısı alırken hata oluştu " + exception.ToString());
                    }
                }
                catch
                {
                    MessageBox.Show("Yazıcı se\x00e7meniz gerekmektedir");
                }
            }
        }

        private void btnPrint2_Click(object sender, EventArgs e)
        {
            GlobalData.reyonList.Clear();
            if (GlobalData.etkList2.Count == 0)
            {
                MessageBox.Show("Yazdırılarak etiket bulunmamaktadır");
            }
            else
            {
                try
                {
                    string printer =cbPrinter.SelectedItem.ToString();
                    int result = 0;
                    try
                    {
                        int.TryParse(tbBos2.Text.Trim(), out result);
                    }
                    catch
                    {
                        MessageBox.Show("Boş etiket sayısı rakam olmak zorundadır");
                        return;
                    }
                    try
                    {
                        GlobalData.reyonList.Clear();
                        int num2 = 0;
                        while (num2 < GlobalData.etkList2.Count)
                        {
                            if (!GlobalData.reyonList.Contains(GlobalData.etkList2[num2].reyon.Substring(0, 3)))
                            {
                                GlobalData.reyonList.Add(GlobalData.etkList2[num2].reyon.Substring(0, 3));
                            }
                            num2++;
                        }
                        for (int i = 0; i < GlobalData.reyonList.Count; i++)
                        {
                            GlobalData.dummy.Clear();
                            for (num2 = 0; num2 < GlobalData.etkList2.Count; num2++)
                            {
                                if (GlobalData.etkList2[num2].reyon.Substring(0, 3) == GlobalData.reyonList[i])
                                {
                                    GlobalData.dummy.Add(GlobalData.etkList2[num2]);
                                }
                            }
                            if (i >= 1)
                            {
                                result = 0;
                            }
                           itabprint("002", GlobalData.dummy, printer, result);
                        }
                    }
                    catch (Exception exception)
                    {
                        MessageBox.Show("Etiket \x00e7ıktısı alırken hata oluştu " + exception.ToString());
                    }
                }
                catch
                {
                    MessageBox.Show("Yazıcı se\x00e7meniz gerekmektedir");
                }
            }
        }

        private void btnPrint4_Click(object sender, EventArgs e)
        {
            GlobalData.reyonList.Clear();
            if (GlobalData.etkList4.Count == 0)
            {
                MessageBox.Show("Yazdırılarak etiket bulunmamaktadır");
            }
            else
            {
                try
                {
                    string printer =cbPrinter.SelectedItem.ToString();
                    int result = 0;
                    try
                    {
                        int.TryParse(this.tbBos4.Text.Trim(), out result);
                    }
                    catch
                    {
                        MessageBox.Show("Boş etiket sayısı rakam olmak zorundadır");
                    }
                    try
                    {
                        GlobalData.reyonList.Clear();
                        int num2 = 0;
                        while (num2 < GlobalData.etkList4.Count)
                        {
                            if (!GlobalData.reyonList.Contains(GlobalData.etkList4[num2].reyon.Substring(0, 3)))
                            {
                                GlobalData.reyonList.Add(GlobalData.etkList4[num2].reyon.Substring(0, 3));
                            }
                            num2++;
                        }
                        for (int i = 0; i < GlobalData.reyonList.Count; i++)
                        {
                            GlobalData.dummy.Clear();
                            for (num2 = 0; num2 < GlobalData.etkList4.Count; num2++)
                            {
                                if (GlobalData.etkList4[num2].reyon.Substring(0, 3) == GlobalData.reyonList[i])
                                {
                                    GlobalData.dummy.Add(GlobalData.etkList4[num2]);
                                }
                            }
                            if (i >= 1)
                            {
                                result = 0;
                            }
                           itabprint("004", GlobalData.dummy, printer, result);
                        }
                    }
                    catch (Exception exception)
                    {
                        MessageBox.Show("Etiket \x00e7ıktısı alırken hata oluştu " + exception.ToString());
                    }
                }
                catch
                {
                    MessageBox.Show("Yazıcı se\x00e7meniz gerekmektedir");
                }
            }
        }

         
 
        private void Form1_Load(object sender, EventArgs e)
        {
           
            string text = "";
            if (text != "")
            {
                MessageBox.Show(text);
            }
            Functions.PrinterGetir(this.cbPrinter);
            try
            {
                Functions.initialization();
            }
            catch (Exception exception)
            {
                  MessageBox.Show("FTP servera bağlanamadı " + exception.ToString());
                //MessageBox.Show(GlobalData.startPath+GlobalData.XMLPath2+"  dosyası okunamadı. Dizayn dosyasını kontrol ediniz.");
                return;
            }
            if (!File.Exists(GlobalData.itabPath))
            {
                MessageBox.Show("Fiyat bulunamadı " + GlobalData.itabPath);
            }
            else
            {
                Functions.itaboku();
                GlobalData.bars.BackColor = Color.White;
                GlobalData.bars.Type = BarCodeType.Ean13;
                GlobalData.bars.Data = "8698541020759";
                tbEtk1.Text = GlobalData.etkList1.Count.ToString();
                tbEtk2.Text = GlobalData.etkList2.Count.ToString();
                tbEtk4.Text = GlobalData.etkList4.Count.ToString();
            }
        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {
        }

 

        private void itabprint(string tip, List<Etiket> list, string printer, int bosCount)
        {
            GlobalData.counter = 0;
            GlobalData.etkTip = tip;
            GlobalData.printer = printer;
            //GlobalData.etkList.Clear();
            GlobalData.etkList = list;
            GlobalData.bosEtiket = bosCount;
            string orientat = "";
            Functions.orientation(tip, out orientat);
            PrintDocument document = new PrintDocument();
            PageSettings settings = new PageSettings();
            if (orientat == "yatay" || tip.Equals("004"))
            {
                settings.Landscape = true;
            }
            else
            {
                settings.Landscape = false;
            }
            document.DefaultPageSettings = settings;
            document.PrinterSettings.PrinterName =cbPrinter.SelectedItem.ToString();
            document.PrintPage += new PrintPageEventHandler(print);
            document.Print();
            document.Dispose();
            GlobalData.counter = 0;
        }

        private void print(object o, PrintPageEventArgs e)
        {
            string str2;
            string str3;
            string str4;
            string str5;
            string str6;
            string str7;
            string str8;
            string str9;
            string str10;
            Pen pen = new Pen(Color.Black);
            SolidBrush brush = new SolidBrush(Color.Black);
            string yon = "";
            string etkTip = GlobalData.etkTip;
            ListBox box = new ListBox();
            if (GlobalData.doc != null)
            {
                XmlNodeList list = GlobalData.doc.SelectNodes("koctas/etiket[@tip='" + etkTip + "']/items/item");
                foreach (XmlNode node in list)
                {
                    box.Items.Add(node.Attributes["name"].Value);
                }
            }
            Functions.BilgileriGetir(etkTip, out yon, out str2, out str3, out str4, out str5, out str6, out str7, out str8, out str9, out str10);
            int num3 = Convert.ToInt32(str5);
            int num4 = Convert.ToInt32(str3);
            int num5 = Convert.ToInt32(str4);
            int num6 = Convert.ToInt32(str8);
            int num7 = Convert.ToInt32(str6);
            int num8 = Convert.ToInt32(str7);
            int num9 = Convert.ToInt32(str9);
            int num10 = Convert.ToInt32(str10);
            for (int i = 0; i < num5; i++)  // num5 kaç etiket satırı
            {
                int num2 = ((i * num4) + (i * num9)) + num8;
                int num2InSafe = num2;
                for (int j = 0; j < num6; j++)  //num6 kaç etiket sütunu
                {
                    if (GlobalData.counter >= GlobalData.etkList.Count)
                    {
                        return;
                    }
                    int num = ((j * num3) + (j * num10)) + num7;
                    if ((GlobalData.bosEtiket <= ((i * num6) + j)) || (GlobalData.counter != 0))
                    {
                        foreach (string str12 in box.Items)
                        {
                            string str13;
                            string str15;
                            float num13;
                            float num14;
                            string maxkar = "";
                            float num15 = 0f;
                            string text = "";
                            float imageHeigth = 0f;
                            float imageWidth;
                             if (GlobalData.etkList[GlobalData.counter].EskiFiyatBas.Trim() == "Y")
                            {
                                switch (str12)
                                {
                                    case "fiyat1_yeni":
                                        text = GlobalData.etkList[GlobalData.counter].fiyat1_yeni;
                                        if (text.Length > 3)
                                        {
                                            text = text.Substring(0, text.Length - 3) + "." + text.Substring(text.Length - 3, 3);
                                        }
                                        break;

                                    case "fiyat2_yeni":
                                        text = GlobalData.etkList[GlobalData.counter].fiyat2_yeni;
                                        break;

                                    case "ayirac_yeni":
                                        text = GlobalData.etkList[GlobalData.counter].ayirac_yeni;
                                        break;

                                    case "tanim":
                                        if (etkTip.Equals("004") && GlobalData.etkList[GlobalData.counter].maktx.Length > 40)
                                            text = GlobalData.etkList[GlobalData.counter].maktx.Substring(0, 40);
                                        else
                                            text = GlobalData.etkList[GlobalData.counter].maktx;
                                        break;

                                    case "fiyat_birim_yeni":
                                        text = GlobalData.etkList[GlobalData.counter].fiyat_birim_yeni;
                                        break;
                                    case "olcu_birim_yeni":
                                        text = GlobalData.etkList[GlobalData.counter].olcu_birim_yeni;
                                        break;
                                    case "kdv":
                                        text = "FİYATA KDV DAHİLDİR";
                                        break;

                                    case "barkod":
                                        text = GlobalData.etkList[GlobalData.counter].barkod;
                                        break;

                                    case "reyon":
                                        text = GlobalData.etkList[GlobalData.counter].reyon;
                                        break;

                                    case "mensei":
                                        text = GlobalData.etkList[GlobalData.counter].mensei;
                                        break;

                                    case "tarih":
                                        text = GlobalData.etkList[GlobalData.counter].tarih;
                                        break;

                                    case "urunkodu":
                                        text = GlobalData.etkList[GlobalData.counter].matnr;
                                        break;

                                    case "fiyat1_eski":
                                        text = GlobalData.etkList[GlobalData.counter].fiyat1_eski;
                                        if (text.Length > 3)
                                        {
                                            text = text.Substring(0, text.Length - 3) + "." + text.Substring(text.Length - 3, 3);
                                        }
                                        break;

                                    case "fiyat2_eski":
                                        text = GlobalData.etkList[GlobalData.counter].fiyat2_eski;
                                        break;

                                    case "ayirac_eski":
                                        text = GlobalData.etkList[GlobalData.counter].ayirac_eski;
                                        break;

                                    case "fiyat_birim_eski":
                                        text = GlobalData.etkList[GlobalData.counter].fiyat_birim_eski;
                                        break;
                                    case "olcu_birim_eski":
                                        text = GlobalData.etkList[GlobalData.counter].olcu_birim_eski;
                                        break;
                                    case "parokart":
                                        if (GlobalData.etkList[GlobalData.counter].parokart_gecer == "X")
                                        {
                                            text = GlobalData.etkList[GlobalData.counter].parokart;
                                        }
                                        else
                                        {
                                            text = "";
                                        }

                                        break;
                                    case "gecer_tar_text":
                                        if (GlobalData.etkList[GlobalData.counter].gecer_tar_basla.Trim() != "" || GlobalData.etkList[GlobalData.counter].gecer_tar_bitis.Trim() != "")
                                        {
                                            text = "Fiyat Değişiklik Tarihi";
                                        }
                                        else
                                        {
                                            text = "";
                                        }
                                        break;
                                    case "gecer_tar_basla":
                                        text = GlobalData.etkList[GlobalData.counter].gecer_tar_basla;
                                        break;
                                    case "gecer_tar_bitis":
                                        text = "";
                                        break;
                                    case "gecer_tar_ayirac":
                                        if (GlobalData.etkList[GlobalData.counter].gecer_tar_basla.Trim() != "" || GlobalData.etkList[GlobalData.counter].gecer_tar_bitis.Trim() != "")
                                        { text = ""; }
                                        else
                                        {
                                            text = "";
                                        }
                                        break;

                                }
                            }
                            else 
                            {
                                switch (str12)
                                {
                                    case "fiyat1":
                                        text = GlobalData.etkList[GlobalData.counter].fiyat1;
                                        if (text.Length > 3)
                                        {
                                            text = text.Substring(0, text.Length - 3) + "." + text.Substring(text.Length - 3, 3);
                                        }
                                        break;

                                    case "fiyat2":
                                        text = GlobalData.etkList[GlobalData.counter].fiyat2;
                                        break;

                                    case "ayirac":
                                        text = GlobalData.etkList[GlobalData.counter].ayirac;
                                        break;

                                    case "tanim":
                                        if (etkTip.Equals("004") && GlobalData.etkList[GlobalData.counter].maktx.Length > 40)
                                            text = GlobalData.etkList[GlobalData.counter].maktx.Substring(0, 40);
                                        else
                                            text = GlobalData.etkList[GlobalData.counter].maktx;
                                        break;

                                    case "fiyat_birim":
                                        text = GlobalData.etkList[GlobalData.counter].fiyat_birim;
                                        break;
                                    case "olcu_birim":
                                        text = GlobalData.etkList[GlobalData.counter].olcu_birim;
                                        break;
                                    case "kdv":
                                        text = "FİYATA KDV DAHİLDİR";
                                        break;

                                    case "barkod":
                                        text = GlobalData.etkList[GlobalData.counter].barkod;
                                        break;

                                    case "reyon":
                                        text = GlobalData.etkList[GlobalData.counter].reyon;
                                        break;

                                    case "mensei":
                                        text = GlobalData.etkList[GlobalData.counter].mensei;
                                        break;

                                    case "tarih":
                                        text = GlobalData.etkList[GlobalData.counter].tarih;
                                        break;

                                    case "urunkodu":
                                        text = GlobalData.etkList[GlobalData.counter].matnr;
                                        break;
                                    case "parokart":
                                        if (GlobalData.etkList[GlobalData.counter].parokart_gecer == "X")
                                        {
                                            text = GlobalData.etkList[GlobalData.counter].parokart;
                                        }
                                        else
                                        {
                                            text = "";
                                        }

                                        break;
                                    case "gecer_tar_text":
                                        if (GlobalData.etkList[GlobalData.counter].gecer_tar_basla.Trim() != "" || GlobalData.etkList[GlobalData.counter].gecer_tar_bitis.Trim() != "")
                                        { text = "Fiyat Değişiklik Tarihi"; }
                                        else
                                        {
                                            text = "";
                                        }
                                        break;
                                    case "gecer_tar_basla":
                                        text = GlobalData.etkList[GlobalData.counter].gecer_tar_basla;
                                        break;
                                    case "gecer_tar_bitis":
                                        text = "";
                                        break;
                                    case "gecer_tar_ayirac":
                                        if (GlobalData.etkList[GlobalData.counter].gecer_tar_basla.Trim() != "" || GlobalData.etkList[GlobalData.counter].gecer_tar_bitis.Trim() != "")
                                        { text = ""; }
                                        else
                                        {
                                            text = "";
                                        }
                                        break;
                                }
                            }
                            Functions.BilgiGetirItem(etkTip, text, str12, out str13, out num13, out num14, out str15, out num15, out maxkar,out imageHeigth,out imageWidth);
                            if (str15 == "1")
                            {
                                if (str12 =="barkod")
                                {
                                    if (text.Length != 13)
                                    {
                                        GlobalData.bars.Type = BarCodeType.Code128;
                                    }
                                    else
                                    {
                                        GlobalData.bars.Type = BarCodeType.Ean13;
                                    }
                                    BarCodeGenerator generator = new BarCodeGenerator(GlobalData.bars);
                                    Image image = null;
                                    if (etkTip == "001")
                                    {
                                        GlobalData.bars.Data = text;
                                        //GlobalData.bars.BarHeight = Convert.ToSingle("0,3");
                                        //GlobalData.bars.ModuleWidth = Convert.ToSingle("0,01");
                                        //GlobalData.bars.Font = new Font("Arial", 8f);
                                        GlobalData.bars.BarHeight = 0.2f;
                                        GlobalData.bars.ModuleWidth = 0.01f;
                                        GlobalData.bars.Font = new Font("Verdana", 7);
                                        GlobalData.bars.Dpi = 100;
                                        generator = new BarCodeGenerator(GlobalData.bars);
                                        image = generator.GenerateImage();
                                        image.RotateFlip(RotateFlipType.Rotate270FlipNone);

                                        // Custom Yerli etiket
                                        if (GlobalData.etkList[GlobalData.counter].mensei.Contains("rkiye")) // Türkiye kontrolü
                                        {
                                            num2 = num2InSafe + GlobalData.YERLI_LOGO_MARGIN;
                                            Bitmap bmp = new Bitmap(Koctas_etiket.Properties.Resources.yerli, new Size(76, 30));
                                            e.Graphics.DrawImage(bmp, new PointF(num + 12, num2 - 30));
                                        }
                                        else
                                        {
                                            num2 = num2InSafe;
                                        }

                                        // Custom Fiyata kdv dahildir.
                                        StringFormat format = new StringFormat();
                                        format.Alignment = StringAlignment.Center;
                                        e.Graphics.TranslateTransform(60 + 5 + num, 80 + 132 + num2);
                                        e.Graphics.RotateTransform(90);
                                        e.Graphics.DrawString("FİYATA KDV DAHİLDİR", new Font("Arial", 5), brush, 0, 0, format);
                                        e.Graphics.ResetTransform();

                                        // Custom Promosyon Geçerlilik Tarihi Ekledik
                                        if (GlobalData.etkList[GlobalData.counter].parokart_gecer.Equals("X"))  // Parokartı var 
                                        {
                                            e.Graphics.DrawString("Promosyon Geçerlilik Tarihi", new Font("Arial", 5), brush, new PointF(5 + num, 100 + num2));
                                            e.Graphics.DrawString(GlobalData.etkList[GlobalData.counter].gecer_tar_basla, new Font("Arial", 5), brush, new PointF(5 + num, 108 + num2));
                                            e.Graphics.DrawString(GlobalData.etkList[GlobalData.counter].gecer_tar_bitis, new Font("Arial", 5), brush, new PointF(53 + num, 108 + num2));
                                            e.Graphics.DrawString(GlobalData.etkList[GlobalData.counter].gecer_tar_ayirac, new Font("Arial", 5), brush, new PointF(45 + num, 108 + num2));
                                        }
                                    }
                                    if (etkTip == "002")
                                    {
                                        //size = new Size(190, 35);
                                        //GlobalData.bars.Font = new Font("Arial", 8f);
                                        GlobalData.bars.Data = text;
                                        //GlobalData.bars.BarHeight = Convert.ToSingle("0,3");
                                        //GlobalData.bars.ModuleWidth = Convert.ToSingle("0,01");
                                        GlobalData.bars.BarHeight = 0.2f;
                                        GlobalData.bars.ModuleWidth = 0.01f;
                                        GlobalData.bars.Font = new Font("Verdana", 7);
                                        GlobalData.bars.Dpi = 100;
                                        generator = new BarCodeGenerator(GlobalData.bars);
                                        image = generator.GenerateImage();

                                        // Custom Yerli etiket
                                        if (GlobalData.etkList[GlobalData.counter].mensei.Contains("rkiye"))
                                        {
                                            Bitmap bmp = new Bitmap(Koctas_etiket.Properties.Resources.yerli, new Size(68, 29));
                                            e.Graphics.DrawImage(bmp, new PointF(num + 195, num2 + 1));
                                        }

                                        // Custom Promosyon Geçerlilik Tarihi Ekledik
                                        if (GlobalData.etkList[GlobalData.counter].parokart_gecer.Equals("X"))  // Parokartı var 
                                        {
                                            e.Graphics.DrawString("Promosyon Geçerlilik Tarihi", new Font("Arial", 7), brush, new PointF(135 + num, 120 + num2));
                                            e.Graphics.DrawString(GlobalData.etkList[GlobalData.counter].gecer_tar_basla, new Font("Arial", 5), brush, new PointF(136 + num, 130 + num2));
                                            e.Graphics.DrawString(GlobalData.etkList[GlobalData.counter].gecer_tar_bitis, new Font("Arial", 5), brush, new PointF(176 + num, 130 + num2));
                                            e.Graphics.DrawString(GlobalData.etkList[GlobalData.counter].gecer_tar_ayirac, new Font("Arial", 5), brush, new PointF(173 + num, 130 + num2));
                                        }

                                    }
                                    if (etkTip == "004")
                                    {
                                        //size = new Size(300, 50);
                                        //GlobalData.bars.Font = new Font("Arial", 11f);
                                        GlobalData.bars.Data = text;
                                        GlobalData.bars.BarHeight = 0.3f;
                                        GlobalData.bars.ModuleWidth = 0.015f;
                                        GlobalData.bars.Font = new Font("Verdana", 8);
                                        GlobalData.bars.Dpi = 300;
                                        image = new BarCodeGenerator(GlobalData.bars).GenerateImage();

                                        // Custom Yerli etiket
                                        if (GlobalData.etkList[GlobalData.counter].mensei.Contains("rkiye"))
                                        {
                                            Bitmap bmp = new Bitmap(Koctas_etiket.Properties.Resources.yerli, new Size(101, 40));
                                            e.Graphics.DrawImage(bmp, new PointF(num + 250, num2 + 5));
                                        }

                                        // Custom Promosyon Geçerlilik Tarihi Ekledik
                                        if (GlobalData.etkList[GlobalData.counter].parokart_gecer.Equals("X"))  // Parokartı var 
                                        {
                                            e.Graphics.DrawString("Promosyon Geçerlilik Tarihi", new Font("Arial", 8), brush, new PointF(200 + num, 212 + num2));
                                            e.Graphics.DrawString(GlobalData.etkList[GlobalData.counter].gecer_tar_basla, new Font("Arial", 6), brush, new PointF(200 + num, 225 + num2));
                                            e.Graphics.DrawString(GlobalData.etkList[GlobalData.counter].gecer_tar_bitis, new Font("Arial", 6), brush, new PointF(250 + num, 225 + num2));
                                            e.Graphics.DrawString(GlobalData.etkList[GlobalData.counter].gecer_tar_ayirac, new Font("Arial", 6), brush, new PointF(246 + num, 225 + num2));
                                        }


                                    }
                                    e.Graphics.DrawImage(image, new PointF(num14 + num, num15 + num2));
                                    continue;
                                }
                                if (maxkar == "")
                                {
                                    e.Graphics.DrawString(text, new Font(str13, num13), brush, new PointF(num14 + num, num15 + num2));
                                    if (((str12 != "fiyat1_eski") || (GlobalData.etkList[GlobalData.counter].EskiFiyatBas != "Y")) || (GlobalData.etkList[GlobalData.counter].EskiFiyatCarpi != "Y"))
                                    {
                                        continue;
                                    }
                                    float length = text.ToString().Length;
                                    if (length == 1)
                                    {
                                        length = 2f;
                                    }
                                    else if (length == 2)
                                    {
                                        length = 3f;
                                    }
                                    else if (length == 3)
                                    {
                                        length = 4f;
                                    }
                                    else if (length == 4)
                                    {
                                        length = 4f;
                                    }
                                    else if (length == 5)
                                    {
                                        length = 6f;
                                    }
                                    float num17 = num + (num13 * length);
                                    int num18 = 0;
                                    int num19 = 0;
                                    int num20 = 0;
                                    int num21 = 0;
                                    int num22 = 0;
                                    int num23 = 0;
                                    int num24 = 0;
                                    int num25 = 0;
                                     this.CarpiKoorGetir(etkTip, text.Length.ToString(), out num18, out num19, out num20, out num21, out num22, out num23, out num24, out num25);
                                    e.Graphics.DrawLine(new Pen(Color.Black, 2f), (float)((num14 + num) + num18), (float)((num15 + num2) + num19), (float)((num14 + num17) + num20), (float)(((num15 + num2) + num13) + num21));
                                    e.Graphics.DrawLine(new Pen(Color.Black, 2f), (float)((num14 + num) + num22), (float)(((num15 + num2) + num13) + num23), (float)((num14 + num17) + num24), (float)((num15 + num2) + num25));
                                    continue;
                                }
                                int max = Convert.ToInt32(maxkar);
                                text.Split(new char[] { ' ' });
                                List<string> list2 = Functions.splitstring(text, max);
                                int num27 = 0;
                                foreach (string str18 in list2)
                                {
                                    int num28 = Convert.ToInt32((double)((num27 * num13) * 1.5));
                                    e.Graphics.DrawString(str18.TrimStart(new char[] { ' ' }), new Font(str13, num13), brush, new PointF(num14 + num, (num15 + num2) + num28));
                                    num27++;
                                }
                            }
                        }
                        GlobalData.counter++;
                    }
                }
            }
            if (GlobalData.counter < GlobalData.etkList.Count)
            {
                e.HasMorePages = true;
            }
            else
            {
                e.HasMorePages = false;
            }
        }
        private void CarpiKoorGetir(string tip, string name, out int _startPoint_X1, out int _startPoint_Y1, out int _stopPoint_X1, out int _stopPoint_Y1, out int _startPoint_X2, out int _startPoint_Y2, out int _stopPoint_X2, out int _stopPoint_Y2)
        { 
            _startPoint_X1 = 0;
            _startPoint_Y1 = 0;
            _stopPoint_X1 = 0;
            _stopPoint_Y1 = 0;
            _startPoint_X2 = 0;
            _startPoint_Y2 = 0;
            _stopPoint_X2 = 0;
            _stopPoint_Y2 = 0;
            if (GlobalData.doc != null)
            {
                foreach (XmlNode node2 in GlobalData.doc.SelectSingleNode("koctas/etiket[@tip='" + tip + "']/items/item[@name='carpi_eski']/durumlar/durum[@name='" + name + "']").ChildNodes)
                { 
                    if(node2 == null)
                    {
                        continue;
                    }
                    switch (node2.Name)
                    {
                        case "startPoint_X1":
                            {
                                XmlNode node3 = node2.ChildNodes[0];
                                _startPoint_X1 = Convert.ToInt32(node3.InnerText);
                                break;
                            }
                        case "startPoint_Y1":
                            {
                                XmlNode node4 = node2.ChildNodes[0];
                                _startPoint_Y1 = Convert.ToInt32(node4.InnerText);
                                break;
                            }
                        case "stopPoint_X1":
                            {
                                XmlNode node5 = node2.ChildNodes[0];
                                _stopPoint_X1 = Convert.ToInt32(node5.InnerText);
                                break;
                            }
                        case "stopPoint_Y1":
                            {
                                XmlNode node6 = node2.ChildNodes[0];
                                _stopPoint_Y1 = Convert.ToInt32(node6.InnerText);
                                break;
                            }
                        case "startPoint_X2":
                            {
                                XmlNode node7 = node2.ChildNodes[0];
                                _startPoint_X2 = Convert.ToInt32(node7.InnerText);
                                break;
                            }
                        case "startPoint_Y2":
                            {
                                XmlNode node8 = node2.ChildNodes[0];
                                _startPoint_Y2 = Convert.ToInt32(node8.InnerText);
                                break;
                            }
                        case "stopPoint_X2":
                            {
                                XmlNode node9 = node2.ChildNodes[0];
                                _stopPoint_X2 = Convert.ToInt32(node9.InnerText);
                                break;
                            }
                        case "stopPoint_Y2":
                            {
                                XmlNode node10 = node2.ChildNodes[0];
                                _stopPoint_Y2 = Convert.ToInt32(node10.InnerText);
                                break;
                            }
                    }
                }
            }
        }

        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            try
            {
                if (File.Exists(GlobalData.XMLPath))
                {
                    File.Delete(GlobalData.XMLPath);
                }
                if (File.Exists(GlobalData.XMLPath2))
                {
                    File.Delete(GlobalData.XMLPath2);
                }
            }
            catch
            {
            }
        }
    }
}
