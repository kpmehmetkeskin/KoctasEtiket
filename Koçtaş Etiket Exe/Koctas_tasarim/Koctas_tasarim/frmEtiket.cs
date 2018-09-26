using NBarCodes;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Printing;
using System.IO;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Xml;

namespace Koctas_tasarim
{
    public partial class frmEtiket : Form
    {
        List<Etiket> EtiketList;
        public frmEtiket()
        {
            EtiketList = new List<Etiket>();
            InitializeComponent();
        }

        private void btnEkle_Click(object sender, EventArgs e)
        {

            try
            {
                if (lbItems.SelectedItems.Count == 0)
                {
                    MessageBox.Show("Yandaki menuden düzenlenecek alanı seçiniz.");
                    return;
                }
            

                string str = lbItems.SelectedItem.ToString();
                string str2 = cbFont.SelectedItem.ToString();
                string uzunluk = int.Parse(tbUzun.Text.Trim()).ToString(); 
              


                if (str.StartsWith("fiyat"))
                {
                   
                    Functions.DurumEkleAna(GlobalData.secilenEtiket, str, uzunluk);
                }
                else if(str.StartsWith("carpi"))
                {
                    Functions.DurumEkleCarpi(GlobalData.secilenEtiket, uzunluk);
                }
                lbItems_SelectedIndexChanged(sender, e);
                if (printPreviewControl1 != null)
                {
                    printPreviewControl1.Refresh();
                }
                RefreshLayout();
            }
            catch
            {
                MessageBox.Show("L\x00fctfen değerleri rakam olarak girin.");
            }
        }
        private void btnEtiketKaydet_Click(object sender, EventArgs e)
        {
            string hspace = "";
            string aciklama = tbAciklama.Text.Trim();
            try
            {
                string boy = int.Parse(tbBoy.Text.Trim()).ToString();
                string dikeyEtiketSayisi = int.Parse(tbDikeyEtiketSayisi.Text.Trim()).ToString();
                string en = int.Parse(tbEn.Text.Trim()).ToString();
                string orgX = int.Parse(tbOrgX.Text.Trim()).ToString();
                string orgY = int.Parse(tbOrgY.Text.Trim()).ToString();
                string yatayEtiketSayisi = int.Parse(tbYatayEtiketSayisi.Text.Trim()).ToString();
                string vspace = int.Parse(tbvspace.Text.Trim()).ToString();
                hspace = int.Parse(tbhspace.Text.Trim()).ToString();
                aciklama = tbAciklama.Text.Trim();
                Functions.EtiketUpdate(GlobalData.secilenEtiket, aciklama, boy, dikeyEtiketSayisi, en, orgX, orgY, yatayEtiketSayisi, vspace, hspace);
                if (printPreviewControl1 != null)
                {
                    printPreviewControl1.Refresh();
                }
                RefreshLayout();
            }
            catch
            {
                MessageBox.Show("L\x00fctfen değerleri rakam olarak girin.");
            }
        }

        private void btnGeri_Click(object sender, EventArgs e)
        {
            base.Close();
        }

        private void btnKaydet2_Click(object sender, EventArgs e)
        {
            string maxkar = "";
            if (lbItems.SelectedItems.Count == 0)
            {
                MessageBox.Show("L\x00fctfen sol taraftan bir item se\x00e7in");
                lbItems.Focus();
            }
            else
            {
                try
                {
                    string str4;
                    string item = lbItems.SelectedItem.ToString();
                    string font;

                    if (cbFont.SelectedItem != null)
                    {
                        font = cbFont.SelectedItem.ToString();
                    }
                    else
                    {
                        MessageBox.Show("Font seçiniz");
                        cbFont.Focus();
                        return;
                    }

                    if (CheckBoxAktif.Checked)
                    {
                        str4 = "1";
                    }
                    else
                    {
                        str4 = "0";
                    }
                    if (DGKosul.Visible)
                    {
                        Functions.FontDegistir(GlobalData.secilenEtiket, font);
                        Functions.AktifDegistir(GlobalData.secilenEtiket, item, str4);
                        if (this.lbItems.SelectedItem.ToString() == "carpi_eski")
                        {
                            for (int i = 0; i < this.DGKosul.Rows.Count; i++)
                            {
                                string uzunluk = this.DGKosul.Rows[i].Cells[0].Value.ToString();
                                string str9 = this.DGKosul.Rows[i].Cells[1].Value.ToString();
                                string str10 = this.DGKosul.Rows[i].Cells[2].Value.ToString();
                                string str11 = this.DGKosul.Rows[i].Cells[3].Value.ToString();
                                string str12 = this.DGKosul.Rows[i].Cells[4].Value.ToString();
                                string str13 = this.DGKosul.Rows[i].Cells[5].Value.ToString();
                                string str14 = this.DGKosul.Rows[i].Cells[6].Value.ToString();
                                string str15 = this.DGKosul.Rows[i].Cells[7].Value.ToString();
                                string str16 = this.DGKosul.Rows[i].Cells[8].Value.ToString();
                                Functions.CarpiKoorGuncelle(GlobalData.secilenEtiket, uzunluk, item, str9, str10, str11, str12, str13, str14, str15, str16);
                            }
                        }
                        else
                        {
                            for (int i = 0; i < DGKosul.Rows.Count; i++)
                            {
                                string tip = lbItems.SelectedItem.ToString();
                                string uzunluk = DGKosul.Rows[i].Cells[0].Value.ToString();
                                string korX = DGKosul.Rows[i].Cells[1].Value.ToString();
                                string korY = DGKosul.Rows[i].Cells[2].Value.ToString();
                                string boyut = DGKosul.Rows[i].Cells[3].Value.ToString();
                                Functions.DurumEkle(GlobalData.secilenEtiket, uzunluk, boyut, korX, korY,tip);
                            }
                        }
                    }
                    else
                    {
                        if (tbTanimMax.Visible)
                        {
                            maxkar = int.Parse(tbTanimMax.Text.Trim()).ToString();
                        }
                        else
                        {
                            maxkar = "0";
                        }
                        string str9 = int.Parse(tbSize.Text.Trim()).ToString();
                        string str10 = int.Parse(tbX.Text.Trim()).ToString();
                        string str11 = int.Parse(tbY.Text.Trim()).ToString();

                        if (tbImageHeigth.Text == "")
                            tbImageHeigth.Text = "0";
                        if (tbImageWidth.Text == "")
                            tbImageWidth.Text = "0";

                        string str12= int.Parse(tbImageWidth.Text.Trim()).ToString();
                        string str13= int.Parse(tbImageHeigth.Text.Trim()).ToString();
                        Functions.EtiketUpdate2(GlobalData.secilenEtiket, item, str9, font, str10, str11, str4, maxkar, DGKosul,str12,str13);
                    }
                    if (printPreviewControl1 != null)
                    {
                        printPreviewControl1.Refresh();
                    }
                    RefreshLayout();
                }
                catch
                {
                    MessageBox.Show("L\x00fctfen değerleri rakam olarak girin.");
                }
            }
        }

        private void btnPrint_Click(object sender, EventArgs e)
        {
            string str = "";
            try
            {
                str = cbPrinter.SelectedItem.ToString();
            }
            catch
            {
                MessageBox.Show("L\x00fctfen listeden bir yazıcı se\x00e7in");
                return;
            }
            try
            {
                printPreviewControl1.Document.PrinterSettings.PrinterName = str;
                printPreviewControl1.Document.Print();
            }
            catch (Exception)
            {
                MessageBox.Show("L\x00fctfen belgeyi oluşturun.");
            }
        }


        private void btnSil_Click(object sender, EventArgs e)
        {
            if (this.DGKosul.SelectedRows.Count == 1)
            {
                string name = this.DGKosul.SelectedRows[0].Cells[0].Value.ToString();
                string item = this.lbItems.SelectedItem.ToString();
                Functions.nodeSil(GlobalData.secilenEtiket, name, item);
                this.lbItems_SelectedIndexChanged(sender, e);
            }
        }
        private void btnYayinla_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Dikkat! Oluşturduğunuz taslağı yayınlamak istediğinize emin misiniz?", "Confirm delete", MessageBoxButtons.OKCancel) == DialogResult.OK)
            {
                try
                {

                    string outputFile = @"C:\SapLabel\koctasOrjEnc.dsgn";
                    Functions.EncryptFile(GlobalData.XMLPath, outputFile);
                    File.Copy(outputFile, GlobalData.string_0);
                    string path = @"C:\SapLabel\koctasOrj.dsgn";
                    string str4 = @"C:\SapLabel\koctasOrj2.dsgn";
                    if (File.Exists(path))
                    {
                        File.Delete(path);
                    }
                    if (File.Exists(outputFile))
                    {
                        File.Delete(outputFile);
                    }
                    if (File.Exists(str4))
                    {
                        File.Delete(str4);
                    }

                    MessageBox.Show("Taslak yayınlandı");
                    GlobalData.string_0 = "";
                    base.Close();
                }
                catch (Exception exception)
                {
                    MessageBox.Show("Yayınlama esnasında hata " + exception.ToString());
                }
            }
        }


        private void CarpiKoorGetir(string name, out int _startPoint_X1, out int _startPoint_Y1, out int _stopPoint_X1, out int _stopPoint_Y1, out int _startPoint_X2, out int _startPoint_Y2, out int _stopPoint_X2, out int _stopPoint_Y2)
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
                //TODO kontrol edilmeli foreach.
                foreach (XmlNode node2 in GlobalData.doc.SelectSingleNode("koctas/etiket[@isim='" + GlobalData.secilenEtiket + "']/items/item[@name='carpi_eski']/durumlar/durum[@name='" + name + "']").ChildNodes)
                {
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
        private void FillValues()
        {
            string str;
            string str2;
            string str3;
            string str4;
            string str5;
            string str6;
            string str7;
            string str8;
            string str9;
            Functions.ItemlariGetir(this.lbItems, GlobalData.secilenEtiket);
            Functions.FontlariGetir(this.cbFont);
            Functions.PrinterGetir(this.cbPrinter);
            string hspace = "";
            Functions.BilgileriGetir(GlobalData.secilenEtiket, out str, out str2, out str3, out str4, out str5, out str6, out str7, out str8, out str9, out hspace);
            this.lblEtiketAdı.Text = GlobalData.secilenEtiket;
            this.tbAciklama.Text = str2;
            this.tbBoy.Text = str3;
            this.tbDikeyEtiketSayisi.Text = str4;
            this.tbEn.Text = str5;
            this.tbOrgX.Text = str6;
            this.tbOrgY.Text = str7;
            this.tbhspace.Text = hspace;
            this.tbvspace.Text = str9;
            this.tbYatayEtiketSayisi.Text = str8;
            if (str == "yatay")
            {
                this.rbYatay.Checked = true;
                this.rbDikey.Checked = false;
            }
            else
            {
                this.rbYatay.Checked = false;
                this.rbDikey.Checked = true;
            }
        }
        private void frmEtiket_Load(object sender, EventArgs e)
        {
            RefreshForm();
            FillValues();
            GlobalData.bars.BackColor = Color.White;
            GlobalData.bars.Type = BarCodeType.Ean13;
            GlobalData.bars.Data = "8698541020759";
            SetEtiketBilgileri();
            RefreshLayout();
        }
        private void lbItems_SelectedIndexChanged(object sender, EventArgs e)
        {

            if (this.lbItems.SelectedItems.Count != 0)
            {
                string str;
                string str2;
                string str3;
                string str4;
                string str5;
                string imageWidth, imageHeigth;
                string maxkar = "";
                string item = this.lbItems.SelectedItem.ToString();
                Functions.BilgileriGetir2(GlobalData.secilenEtiket, item, out str, out str2, out str4, out str3, out str5, out maxkar, this.DGKosul,out imageWidth,out imageHeigth);
                this.DGKosul.Visible = false;
                this.tbSize.Enabled = true;
                this.tbX.Enabled = true;
                this.tbY.Enabled = true;
                this.tbSize.ReadOnly = false;
                this.tbX.ReadOnly = false;
                this.tbY.ReadOnly = false;
                this.btnKaydet2.Visible = true;
                this.btnEkle.Visible = true;
                this.btnSil.Visible = true;
                this.btnEkle.Visible = false;
                this.label17.Visible = false;
                this.label18.Visible = false;
                this.tbImageHeigth.Visible = false;
                this.tbImageWidth.Visible = false;
                this.btnSil.Visible = false;
                this.tbUzun.Visible = false;
                this.CheckBoxAktif.Checked = false;
                this.label11.Visible = false;
                this.tbTanimMax.Enabled = false;
                this.tbTanimMax.Visible = false;
                this.lblTanimKarSayi.Visible = false;
                this.tbX.Enabled = true;
                this.tbY.Enabled = true;
                this.tbSize.Enabled = true;
                if (maxkar != "")
                {
                    this.tbTanimMax.Enabled = true;
                    this.tbTanimMax.Visible = true;
                    this.lblTanimKarSayi.Visible = true;
                    this.tbTanimMax.Text = maxkar;
                }

                if(imageHeigth!="0" || imageWidth != "0")
                {
                    this.label17.Visible = true;
                    this.label18.Visible = true;
                    this.tbImageHeigth.Visible = true;
                    this.tbImageWidth.Visible = true;
                    this.tbImageHeigth.Text = imageHeigth;
                    this.tbImageWidth.Text = imageWidth;
                }
                if (this.DGKosul.DataSource != null)
                {
                    this.DGKosul.Visible = true;
                    this.tbX.Enabled = false;
                    this.tbY.Enabled = false;
                    this.tbSize.Enabled = false;
                    this.tbX.Text = "";
                    this.tbY.Text = "";
                    this.tbSize.Text = "";
                    this.tbUzun.Text = "";
                    this.btnKaydet2.Visible = true;
                    this.btnEkle.Visible = true;
                    this.btnSil.Visible = true;
                    this.tbUzun.Visible = true;
                    this.label11.Visible = true;
                }
                else
                {
                    this.tbSize.Text = str3;
                    this.tbX.Text = str;
                    this.tbY.Text = str2;
                }
                if (str5 == "1")
                {
                    this.CheckBoxAktif.Checked = true;
                }
                else
                {
                    this.CheckBoxAktif.Checked = false;
                }
                this.cbFont.SelectedItem = str4;
                if (printPreviewControl1 != null)
                {
                    printPreviewControl1.Refresh();
                }
                RefreshLayout();
            }
        }

        private void RefreshForm()
        {
            this.tbAciklama.Text = "";
            this.label11.Visible = false;
            this.tbUzun.Visible = false;
            this.tbBoy.Text = "";
            this.tbDikeyEtiketSayisi.Text = "";
            this.tbEn.Text = "";
            this.tbOrgX.Text = "";
            this.tbOrgY.Text = "";
            this.tbSize.Text = "";
            this.tbTanimMax.Text = "";
            this.tbX.Text = "";
            this.tbY.Text = "";
            this.tbYatayEtiketSayisi.Text = "";
            this.lblEtiketAdı.Text = "";
            this.cbFont.Items.Clear();
            this.lbItems.Items.Clear();
            this.DGKosul.DataSource = null;
            this.rbDikey.Checked = false;
            this.rbYatay.Checked = false;
        }
        private void RefreshLayout()
        {

            try
            {
                PrintDocument document = new PrintDocument();
                PageSettings settings = new PageSettings();
                if (this.rbYatay.Checked)
                {
                    settings.Landscape = true;
                }
                else
                {
                    settings.Landscape = false;
                }
                document.DefaultPageSettings = settings;
                //this.PrintPreviewControl1 = new PrintPreviewControl();
                //this.PrintPreviewControl1.Location = new Point(480, 0x11);
                //this.PrintPreviewControl1.Size = new Size(550, 0x277);
                //this.PrintPreviewControl1.AutoZoom = true;
                //this.PrintPreviewControl1.Name = "PrintPreviewControl1";
                printPreviewControl1.Document = document;
                printPreviewControl1.Zoom = 1;
                //this.PrintPreviewControl1.UseAntiAlias = true;
                //base.Controls.Add(this.PrintPreviewControl1);
                document.PrintPage += new PrintPageEventHandler(this.pqr2);
            }
            catch (Exception)
            {
            }
        }



        private void pqr2(object sender, PrintPageEventArgs e)
        {
            int xSize = 0;
            int ySize = 0;

            bool flag = false;
            if (this.lbItems.SelectedIndex < 0)
            {
                flag = false;
            }
            else if (this.lbItems.SelectedItem.ToString().Length>6)
            {
                if((this.lbItems.SelectedItem.ToString().Substring(this.lbItems.SelectedItem.ToString().Length - 5, 5) == "_eski") || (this.lbItems.SelectedItem.ToString().Substring(this.lbItems.SelectedItem.ToString().Length - 5, 5) == "_yeni"))
                flag = true;
            }
            else
            {
                flag = false;
            }
            if (!flag)
            {
                new Pen(Color.Black);
                SolidBrush brush = new SolidBrush(Color.Black);
                int num3 = Convert.ToInt32(this.tbEn.Text.Trim());
                int num4 = Convert.ToInt32(this.tbBoy.Text.Trim());
                int num5 = Convert.ToInt32(this.tbDikeyEtiketSayisi.Text);
                int num6 = Convert.ToInt32(this.tbYatayEtiketSayisi.Text);
                int num7 = Convert.ToInt32(this.tbOrgX.Text);
                int num8 = Convert.ToInt32(this.tbOrgY.Text);
                int num9 = Convert.ToInt32(this.tbvspace.Text);
                int num10 = Convert.ToInt32(this.tbhspace.Text);
                int index = 0;
                for (int i = 0; i < num5; i++)
                {
                    int num2 = ((i * num4) + (i * num9)) + num8;
                    xSize = num2;
                    for (int j = 0; j < num6; j++)
                    {
                        int num = ((j * num3) + (j * num10)) + num7;
                        ySize = num;

                    
                        if (index > ((num5 * num6) - 1))
                        {
                            return;
                        }
                        foreach (string str in this.lbItems.Items)
                        {
                            string str2;
                            string str4;
                            float num14;
                            float num15;
                            string maxkar = "";
                            string text = "";
                            float num16 = 0f;
                            float imageWidth = 0f;
                            float imageHeigth = 0f;
                            switch (str)
                            {
                                case "fiyat1":
                                    text = Enumerable.ElementAt<Etiket>(this.EtiketList, index).fiyat1;
                                    if (text.Length > 3)
                                    {
                                        text = text.Substring(0, text.Length - 3) + "," + text.Substring(text.Length - 3, 3);
                                    }
                                    break;

                                case "fiyat2":
                                    text = Enumerable.ElementAt<Etiket>(this.EtiketList, index).fiyat2;
                                    break;

                                case "ayirac":
                                    text = Enumerable.ElementAt<Etiket>(this.EtiketList, index).ayirac;
                                    break;

                                case "tanim":
                                    text = Enumerable.ElementAt<Etiket>(this.EtiketList, index).maktx;
                                    break;

                                case "kdv":
                                    text = Enumerable.ElementAt<Etiket>(this.EtiketList, index).kdv;
                                    break;

                                case "fiyat_birim":
                                    text = Enumerable.ElementAt<Etiket>(this.EtiketList, index).fiyat_birim;
                                    break;
                                case "olcu_birim":
                                    text = Enumerable.ElementAt<Etiket>(this.EtiketList, index).olcu_birim;
                                    break;
                                case "barkod":
                                    text = Enumerable.ElementAt<Etiket>(this.EtiketList, index).barkod;
                                    break;

                                case "reyon":
                                    text = Enumerable.ElementAt<Etiket>(this.EtiketList, index).reyon;
                                    break;

                                case "mensei":
                                    text = Enumerable.ElementAt<Etiket>(this.EtiketList, index).mensei;
                                    break;

                                case "tarih":
                                    text = Enumerable.ElementAt<Etiket>(this.EtiketList, index).tarih;
                                    break;

                                case "urunkodu":
                                    text = Enumerable.ElementAt<Etiket>(this.EtiketList, index).urunkodu;
                                    break;
                                case "parokart":
                                    text = Enumerable.ElementAt<Etiket>(this.EtiketList, index).parokart;
                                    break;
                                case "gecer_tar_text":
                                    text = Enumerable.ElementAt<Etiket>(this.EtiketList, index).gecer_tar_text;
                                    break;
                                case "gecer_tar_basla":
                                    text = Enumerable.ElementAt<Etiket>(this.EtiketList, index).gecer_tar_basla;
                                    break;
                                case "gecer_tar_bitis":
                                    text = Enumerable.ElementAt<Etiket>(this.EtiketList, index).gecer_tar_bitis;
                                    break;
                                case "gecer_tar_ayirac":
                                    text = Enumerable.ElementAt<Etiket>(this.EtiketList, index).gecer_tar_ayirac;
                                    break;
                            }
                            Functions.BilgiGetirItem(GlobalData.secilenEtiket, text, str, out str2, out num14, out num15, out str4, out num16, out maxkar,out imageWidth, out imageHeigth);
                            if (str4 == "1")
                            {
                                if (str == "barkod")
                                {
                                    BarCodeGenerator generator = new BarCodeGenerator(GlobalData.bars);
                                    Image image = generator.GenerateImage();
                                    if (GlobalData.secilenEtiket.StartsWith("1"))
                                    {
                                        //GlobalData.bars.BarHeight = imageHeigth / 100;
                                        //GlobalData.bars.ModuleWidth = imageWidth / 1000;
                                        //GlobalData.bars.Font = new Font("Arial", num14);
                                        GlobalData.bars.BarHeight = 0.2f;
                                        GlobalData.bars.ModuleWidth = 0.01f;
                                        GlobalData.bars.Font = new Font("Verdana", 7);
                                        GlobalData.bars.Dpi = 100;
                                     
                                        generator = new BarCodeGenerator(GlobalData.bars);
                                        image = generator.GenerateImage();
                                        image.RotateFlip(RotateFlipType.Rotate270FlipNone);
                                    }
                                    if (GlobalData.secilenEtiket.StartsWith("2"))
                                    {
                                        new Size(190, 0x23);
                                        GlobalData.bars.BarHeight = 0.2f;
                                        GlobalData.bars.ModuleWidth = 0.01f;
                                        GlobalData.bars.Font = new Font("Verdana", 7);
                                        GlobalData.bars.Dpi = 100;
                            
                                        GlobalData.bars.OffsetWidth = 0f;
                                        generator = new BarCodeGenerator(GlobalData.bars);
                                        image = generator.GenerateImage();
                                    }
                                    if (GlobalData.secilenEtiket.StartsWith("4"))
                                    {
                                        new Size(300, 50);
                                        GlobalData.bars.BarHeight = 0.3f;
                                        GlobalData.bars.ModuleWidth = 0.015f;
                                        GlobalData.bars.Font = new Font("Verdana", 8);
                                        GlobalData.bars.Dpi = 300;
                            
                                        //GlobalData.bars.OffsetWidth = 0f;
                                        image = new BarCodeGenerator(GlobalData.bars).GenerateImage();
                                    }
                                    e.Graphics.DrawImage(image, new PointF(num15 + num, num16 + num2));
                                    pictureBox1.Image = image;
                                   
                                }
                                else if (maxkar == "")
                                {
                                    e.Graphics.DrawString(text, new Font(str2, num14), brush, new PointF(num15 + num, num16 + num2));
                                    if(str== "gecer_tar_text")
                                    {
                                        Pen pdeneme = new Pen(Color.Red);
                                        e.Graphics.DrawRectangle(pdeneme, num, num2, num3, num4);
                                    }
                           
                                }
                                else
                                {
                                    if (str == "gecer_tar_text")
                                    {
                                        Pen pdeneme = new Pen(Color.Red);
                                        e.Graphics.DrawRectangle(pdeneme, num, num2, num3, num4);
                                    }
                                    int max = Convert.ToInt32(maxkar);
                                    text.Split(new char[] { ' ' });
                                    List<string> list = Functions.splitstring(text, max);
                                    int num18 = 0;
                                    foreach (string str6 in list)
                                    {
                                        int num19 = Convert.ToInt32((double)((num18 * num14) * 1.5));
                                        e.Graphics.DrawString(str6.TrimStart(new char[] { ' ' }), new Font(str2, num14), brush, new PointF(num15 + num, (num16 + num2) + num19));
                                        num18++;
                                    }
                                }
                            }
                        }
                        index++;
                    }
                }
           
            }
            else
            {
                new Pen(Color.Black);
                SolidBrush brush2 = new SolidBrush(Color.Black);
                int num22 = Convert.ToInt32(this.tbEn.Text.Trim());
                int num23 = Convert.ToInt32(this.tbBoy.Text.Trim());
                int num24 = Convert.ToInt32(this.tbDikeyEtiketSayisi.Text);
                int num25 = Convert.ToInt32(this.tbYatayEtiketSayisi.Text);
                int num26 = Convert.ToInt32(this.tbOrgX.Text);
                int num27 = Convert.ToInt32(this.tbOrgY.Text);
                int num28 = Convert.ToInt32(this.tbvspace.Text);
                int num29 = Convert.ToInt32(this.tbhspace.Text);
                int num30 = 0;
                for (int k = 0; k < num24; k++)
                {
                    int num21 = ((k * num23) + (k * num28)) + num27;
                    for (int m = 0; m < num25; m++)
                    {
                        int num20 = ((m * num22) + (m * num29)) + num26;
                        if (num30 > ((num24 * num25) - 1))
                        {
                            return;
                        }
                        foreach (string str7 in this.lbItems.Items)
                        {
                            string str8;
                            string str10;
                            float num33;
                            float num34;
                            string str11 = "";
                            string maktx = "";
                            float num35 = 0f;
                            float imageWidth = 0f;
                            float imageHeigth  = 0f;
                switch (str7)
                            {
                                case "tanim":
                                    maktx = Enumerable.ElementAt<Etiket>(this.EtiketList, num30).maktx;
                                    break;

                                case "kdv":
                                    maktx = Enumerable.ElementAt<Etiket>(this.EtiketList, num30).kdv;
                                    break;

                                case "barkod":
                                    maktx = Enumerable.ElementAt<Etiket>(this.EtiketList, num30).barkod;
                                    break;

                                case "reyon":
                                    maktx = Enumerable.ElementAt<Etiket>(this.EtiketList, num30).reyon;
                                    break;

                                case "mensei":
                                    maktx = Enumerable.ElementAt<Etiket>(this.EtiketList, num30).mensei;
                                    break;

                                case "tarih":
                                    maktx = Enumerable.ElementAt<Etiket>(this.EtiketList, num30).tarih;
                                    break;

                                case "urunkodu":
                                    maktx = Enumerable.ElementAt<Etiket>(this.EtiketList, num30).urunkodu;
                                    break;

                                case "fiyat1_eski":
                                    maktx = Enumerable.ElementAt<Etiket>(this.EtiketList, num30).fiyat1_eski;
                                    if (maktx.Length > 3)
                                    {
                                        maktx = maktx.Substring(0, maktx.Length - 3) + "," + maktx.Substring(maktx.Length - 3, 3);
                                    }
                                    break;

                                case "fiyat2_eski":
                                    maktx = Enumerable.ElementAt<Etiket>(this.EtiketList, num30).fiyat2_eski;
                                    break;

                                case "ayirac_eski":
                                    maktx = Enumerable.ElementAt<Etiket>(this.EtiketList, num30).ayirac_eski;
                                    break;

                                case "fiyat_birim_eski":
                                    maktx = Enumerable.ElementAt<Etiket>(this.EtiketList, num30).fiyat_birim_eski;
                                    break;
                                case "olcu_birim_eski":
                                    maktx = Enumerable.ElementAt<Etiket>(this.EtiketList, num30).olcu_birim_eski;
                                    break;

                                case "fiyat1_yeni":
                                    maktx = Enumerable.ElementAt<Etiket>(this.EtiketList, num30).fiyat1_yeni;
                                    if (maktx.Length > 3)
                                    {
                                        maktx = maktx.Substring(0, maktx.Length - 3) + "," + maktx.Substring(maktx.Length - 3, 3);
                                    }
                                    break;

                                case "fiyat2_yeni":
                                    maktx = Enumerable.ElementAt<Etiket>(this.EtiketList, num30).fiyat2_yeni;
                                    break;

                                case "ayirac_yeni":
                                    maktx = Enumerable.ElementAt<Etiket>(this.EtiketList, num30).ayirac_yeni;
                                    break;

                                case "fiyat_birim_yeni":
                                    maktx = Enumerable.ElementAt<Etiket>(this.EtiketList, num30).fiyat_birim_yeni;
                                    break;
                                case "olcu_birim_yeni":
                                    maktx = Enumerable.ElementAt<Etiket>(this.EtiketList, num30).olcu_birim_yeni;
                                    break;
                                case "parokart":
                                    maktx = Enumerable.ElementAt<Etiket>(this.EtiketList, num30).parokart;
                                    break;
                                case "gecer_tar_text":
                                    maktx = Enumerable.ElementAt<Etiket>(this.EtiketList, num30).gecer_tar_text;
                                    break;
                                case "gecer_tar_basla":
                                    maktx = Enumerable.ElementAt<Etiket>(this.EtiketList, num30).gecer_tar_basla;
                                    break;
                                case "gecer_tar_bitis":
                                    maktx = Enumerable.ElementAt<Etiket>(this.EtiketList, num30).gecer_tar_bitis;
                                    break;
                                case "gecer_tar_ayirac":
                                    maktx = Enumerable.ElementAt<Etiket>(this.EtiketList, num30).gecer_tar_ayirac;
                                    break;
                            }
                            Functions.BilgiGetirItem(GlobalData.secilenEtiket, maktx, str7, out str8, out num33, out num34, out str10, out num35, out str11, out imageWidth, out imageHeigth);
                            if (str10 == "1")
                            {
                                if (str7 == "barkod")
                                {
                                    BarCodeGenerator generator2 = new BarCodeGenerator(GlobalData.bars);
                                    Image image2 = generator2.GenerateImage();
                                    if (GlobalData.secilenEtiket.StartsWith("1"))
                                    {

                                        GlobalData.bars.BarHeight = 0.2f;
                                        GlobalData.bars.ModuleWidth = 0.01f;
                                        GlobalData.bars.Font = new Font("Verdana", 7);
                                        GlobalData.bars.Dpi = 100;
                                 
                                        //GlobalData.bars.OffsetWidth = 0f;
                                        generator2 = new BarCodeGenerator(GlobalData.bars);
                                        image2 = generator2.GenerateImage();
                                        image2.RotateFlip(RotateFlipType.Rotate270FlipNone);
                                        e.Graphics.DrawImage(image2, new PointF(num34 + num20, num35 + num21));
                                    }
                                    if (GlobalData.secilenEtiket.StartsWith("2"))
                                    {
                                        new Size(190, 0x23);
                                        GlobalData.bars.BarHeight = 0.2f;
                                        GlobalData.bars.ModuleWidth = 0.01f;
                                        GlobalData.bars.Font = new Font("Verdana", 7);
                                        GlobalData.bars.Dpi = 100;
                                        //GlobalData.bars.BarHeight = imageHeigth / 100;
                                        //GlobalData.bars.ModuleWidth = imageWidth / 1000;
                                        //GlobalData.bars.Font = new Font("Arial", num33);
                                        //GlobalData.bars.OffsetWidth = 0f;
                                        //GlobalData.bars.Font = new Font("Arial", 10f);
                                        //GlobalData.bars.BarHeight = Convert.ToSingle("0,3");
                                        //GlobalData.bars.ModuleWidth = Convert.ToSingle("0,015");
                                        generator2 = new BarCodeGenerator(GlobalData.bars);
                                        image2 = generator2.GenerateImage();
                                        e.Graphics.DrawImage(image2, new PointF(num34 + num20, (num35 + num21)));
                                    }
                                    if (GlobalData.secilenEtiket.StartsWith("4"))
                                    {
                                        new Size(300, 50);
                                        GlobalData.bars.BarHeight = 0.3f;
                                        GlobalData.bars.ModuleWidth = 0.015f;
                                        GlobalData.bars.Font = new Font("Verdana", 8);
                                        GlobalData.bars.Dpi = 300;

                                        image2 = new BarCodeGenerator(GlobalData.bars).GenerateImage();
                                        e.Graphics.DrawImage(image2, new PointF(num34 + num20, num35 + num21));
                                    }
                                    continue;
                                }
                                if (str11 == "")
                                {
                                    e.Graphics.DrawString(maktx, new Font(str8, num33), brush2, new PointF(num34 + num20, num35 + num21));
                                    if (str7 != "fiyat1_eski")
                                    {
                                        continue;
                                    }
                                    if (GlobalData.secilenEtiket.StartsWith("2"))
                                    {
                                        float num36 = maktx.ToString().Length;
                                        //switch (num36)
                                        //{
                                        //    case 1f:
                                        //        num36 = 2.5f;
                                        //        break;

                                        //    case 2f:
                                        //        num36 = 3f;
                                        //        break;

                                        //    case 3f:
                                        //        num36 = 4f;
                                        //        break;
                                        //}
                                        if (num36 == 1)
                                        {
                                            num36 = 2f;
                                        }
                                        else if (num36 == 2)
                                        {
                                            num36 = 3f;
                                        }
                                        else if (num36 == 3)
                                        {
                                            num36 = 4f;
                                        }
                                        else if (num36 == 4)
                                        {
                                            num36 = 4f;
                                        }
                                        else if (num36 == 5)
                                        {
                                            num36 = 6f;
                                        }
                                        float num37 = num20 + (num33 * num36);
                                        int num38 = 0;
                                        int num39 = 0;
                                        int num40 = 0;
                                        int num41 = 0;
                                        int num42 = 0;
                                        int num43 = 0;
                                        int num44 = 0;
                                        int num45 = 0;
                                        int num69 = maktx.Length;
                                        this.CarpiKoorGetir(num69.ToString(), out num38, out num39, out num40, out num41, out num42, out num43, out num44, out num45);
                                        e.Graphics.DrawLine(new Pen(Color.Black, 2f), (float)((num34 + num20) + num38), (float)((num35 + num21) + num39), (float)((num34 + num37) + num40), (float)(((num35 + num21) + num33) + num41));
                                        e.Graphics.DrawLine(new Pen(Color.Black, 2f), (float)((num34 + num20) + num42), (float)(((num35 + num21) + num33) + num43), (float)((num34 + num37) + num44), (float)((num35 + num21) + num45));
                                    }
                                    else if (GlobalData.secilenEtiket.StartsWith("1"))
                                    {
                                        float num46 = maktx.ToString().Length;
                                        //switch (num46)
                                        //{
                                        //    case 1f:
                                        //        num46 = 2f;
                                        //        break;

                                        //    case 2f:
                                        //        num46 = 2.8f;
                                        //        break;

                                        //    case 3f:
                                        //        num46 = 3.5f;
                                        //        break;

                                        //    case 5f:
                                        //        num46 = 6f;
                                        //        break;
                                        //}
                                        if (num46 == 1)
                                        {
                                            num46 = 2f;
                                        }
                                        else if (num46 == 2)
                                        {
                                            num46 = 2.8f;
                                        }
                                        else if (num46 == 3)
                                        {
                                            num46 = 3.5f;
                                        }
                                        else if (num46 == 5)
                                        {
                                            num46 = 6f;
                                        }
                                        float num47 = num20 + (num33 * num46);
                                        int num48 = 0;
                                        int num49 = 0;
                                        int num50 = 0;
                                        int num51 = 0;
                                        int num52 = 0;
                                        int num53 = 0;
                                        int num54 = 0;
                                        int num55 = 0;
                                        this.CarpiKoorGetir(maktx.Length.ToString(), out num48, out num49, out num50, out num51, out num52, out num53, out num54, out num55);
                                        e.Graphics.DrawLine(new Pen(Color.Black, 2f), (float)((num34 + num20) + num48), (float)((num35 + num21) + num49), (float)((num34 + num47) + num50), (float)(((num35 + num21) + num33) + num51));
                                        e.Graphics.DrawLine(new Pen(Color.Black, 2f), (float)((num34 + num20) + num52), (float)(((num35 + num21) + num33) + num53), (float)((num34 + num47) + num54), (float)((num35 + num21) + num55));
                                    }
                                    if (!GlobalData.secilenEtiket.StartsWith("4"))
                                    {
                                        continue;
                                    }
                                    float length = maktx.ToString().Length;
                                    //switch (length)
                                    //{
                                    //    case 1f:
                                    //        length = 2.5f;
                                    //        break;

                                    //    case 2f:
                                    //        length = 3f;
                                    //        break;

                                    //    case 3f:
                                    //        length = 4f;
                                    //        break;
                                    //}
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
                                    else if (length == 5)
                                    {
                                        length = 6f;
                                    }
                                    float num57 = num20 + (num33 * length);
                                    int num58 = 0;
                                    int num59 = 0;
                                    int num60 = 0;
                                    int num61 = 0;
                                    int num62 = 0;
                                    int num63 = 0;
                                    int num64 = 0;
                                    int num65 = 0;
                                    this.CarpiKoorGetir(maktx.Length.ToString(), out num58, out num59, out num60, out num61, out num62, out num63, out num64, out num65);
                                    e.Graphics.DrawLine(new Pen(Color.Black, 2f), (float)((num34 + num20) + num58), (float)((num35 + num21) + num59), (float)((num34 + num57) + num60), (float)(((num35 + num21) + num33) + num61));
                                    e.Graphics.DrawLine(new Pen(Color.Black, 2f), (float)((num34 + num20) + num62), (float)(((num35 + num21) + num33) + num63), (float)((num34 + num57) + num64), (float)((num35 + num21) + num65));
                                    continue;
                                }
                                int num66 = Convert.ToInt32(str11);
                                maktx.Split(new char[] { ' ' });
                                List<string> list2 = Functions.splitstring(maktx, num66);
                                int num67 = 0;
                                foreach (string str15 in list2)
                                {
                                    int num68 = Convert.ToInt32((double)((num67 * num33) * 1.5));
                                    e.Graphics.DrawString(str15.TrimStart(new char[] { ' ' }), new Font(str8, num33), brush2, new PointF(num34 + num20, (num35 + num21) + num68));
                                    num67++;
                                }
                                if (str7 == "gecer_tar_text")
                                {
                                    Pen pdeneme = new Pen(Color.Red);
                                    e.Graphics.DrawRectangle(pdeneme, num20, num21, num22, num23);
                                }
                            }
                        }
                        num30++;
                    }
                }
            } 
        }
        private void SetEtiketBilgileri()
        {

            GlobalData.doc.Load(GlobalData.XMLPath);
            this.EtiketList.Clear();
            for (int i = 0; i < 50; i++)
            {
                Etiket item = new Etiket();

                item.ayirac = ",";
                item.maktx = "1610310 PLATA ALTTAN KLOZET BYZ ALTTAN KLOZET ";
                item.barkod = "8694675032736";
                item.matnr = "1000061118";
                item.reyon = "03";
                item.fiyat_birim = "₺";
                item.fiyat1 = ((((i + 8) * (i + 8)) * i) + (i + 5)).ToString();
                item.fiyat2 = "45";
                item.tarih = "17.04.2017";
                item.urunkodu = "1000061118";
                item.kdv = "FİYATA KDV DAHİLDİR";
                item.fiyat1_yeni = item.fiyat1;
                item.fiyat2_yeni = item.fiyat2;
                item.ayirac_yeni = item.ayirac;
                item.fiyat_birim_yeni = "₺";
                item.fiyat1_eski = ((((i + 7) * (i + 8)) * i) + (i + 5)).ToString();
                item.fiyat2_eski = "75";
                item.ayirac_eski = ",";
                item.fiyat_birim_eski = "₺";
                item.parokart = "Koçtaşkart ile geçerlidir.";
                item.gecer_tar_text = "Geçerlilik Tarihi";
                item.gecer_tar_basla = "18.03.2017";
                item.gecer_tar_bitis = "19.06.2017";
                item.gecer_tar_ayirac = "-";
                item.olcu_birim = "/ADET";
                item.olcu_birim_yeni = "/ADET";
                item.olcu_birim_eski = "/ADET";
                item.mensei = "Menşei :";
                if ((i % 2) == 0)
                {
                    item.mensei += "İthal";
                }
                this.EtiketList.Add(item);
            }
        }
        
        private void trackBar1_ValueChanged(object sender, EventArgs e)
        {
            float deger = 5- (float)(trackBar1.Value);
            deger = deger / 5;
            if (deger > 0.90f)
                return;
            printPreviewControl1.Zoom = 1.0 - deger;
        }
    }
}
