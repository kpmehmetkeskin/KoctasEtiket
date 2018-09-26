using System;
using System.Collections.Generic;
using System.Text;

using System.Drawing.Printing;
using System.IO;
using System.Runtime.InteropServices;
using System.Security.Cryptography;
using System.Windows.Forms;
using System.Xml;
using System.Net;

namespace Koctas_etiket
{
    class Functions
    {

        public static void BatCreate(out string result)
        {
            result = "";
            try
            {
                string path = @"C:\SapLabel\fiyat_etiket.bat";
                string sourceFileName = @"\\172.16.5.8\magaza_etiket\fiyat_etiket_yeni.bat";
                if (!File.Exists(path))
                {
                    File.Copy(sourceFileName, path);
                }
            }
            catch
            {
                result = "Batch dosyası kopyalanamadı";
            }
        }

        public static void BilgiGetirItem(string tip, string text, string item, out string font, out float size, out float p_x, out string aktif, out float p_y, out string maxkar, out float imageHeigth, out float imageWidth)
        {
            string str;
            float num;
            maxkar = str = "";
            font = aktif = str;
            p_y = num = 0f;
            size = p_x = num;
            imageHeigth = 0;
            imageWidth = 0;
            if (GlobalData.doc != null)
            {
                XmlNode node = GlobalData.doc.SelectSingleNode("koctas/etiket[@tip='" + tip + "']/items/item[@name='" + item + "']/size");
                size = Convert.ToInt32(node.InnerText);
                node = GlobalData.doc.SelectSingleNode("koctas/etiket[@tip='" + tip + "']/items/item[@name='" + item + "']/font");
                font = node.InnerText;
                node = GlobalData.doc.SelectSingleNode("koctas/etiket[@tip='" + tip + "']/items/item[@name='" + item + "']/aktif");
                aktif = node.InnerText;
                try
                {
                    node = GlobalData.doc.SelectSingleNode("koctas/etiket[@tip='" + tip + "']/items/item[@name='" + item + "']/karsayi");
                    maxkar = node.InnerText;
                }
                catch
                {
                    maxkar = "";
                    Console.WriteLine("maxkar");
                }
                node = GlobalData.doc.SelectSingleNode("koctas/etiket[@tip='" + tip + "']/items/item[@name='" + item + "']/XPoint");
                p_x = Convert.ToInt32(node.InnerText);
                node = GlobalData.doc.SelectSingleNode("koctas/etiket[@tip='" + tip + "']/items/item[@name='" + item + "']/YPoint");
                p_y = Convert.ToInt32(node.InnerText);
                node = GlobalData.doc.SelectSingleNode("koctas/etiket[@tip='" + tip + "']/items/item[@name='" + item + "']/imageWidth");
                if (node != null)
                    imageWidth = Convert.ToInt32(node.InnerText);
                node = GlobalData.doc.SelectSingleNode("koctas/etiket[@tip='" + tip + "']/items/item[@name='" + item + "']/imageHeigth");
                if (node != null)
                    imageHeigth = Convert.ToInt32(node.InnerText);
                try
                {
                    if (GlobalData.doc.SelectSingleNode("koctas/etiket[@tip='" + tip + "']/items/item[@name='" + item + "']/durumlar") != null)
                    {
                        int length = text.Length;
                        XmlNode node3 = null;
                        XmlNode node4 = null;
                        XmlNode node5 = null;
                        node3 = GlobalData.doc.SelectSingleNode(string.Concat(new object[] { "koctas/etiket[@tip='", tip, "']/items/item[@name='", item, "']/durumlar/durum[@name='", length, "']/XPoint" }));
                        p_x = Convert.ToInt32(node3.InnerText);
                        node4 = GlobalData.doc.SelectSingleNode(string.Concat(new object[] { "koctas/etiket[@tip='", tip, "']/items/item[@name='", item, "']/durumlar/durum[@name='", length, "']/YPoint" }));
                        p_y = Convert.ToInt32(node4.InnerText);
                        node5 = GlobalData.doc.SelectSingleNode(string.Concat(new object[] { "koctas/etiket[@tip='", tip, "']/items/item[@name='", item, "']/durumlar/durum[@name='", length, "']/size" }));
                        size = Convert.ToInt32(node5.InnerText);
                    }
                }
                catch
                {
                }
            }
        }

        public static void BilgileriGetir(string tip, out string yon, out string Aciklama, out string Boy, out string DikeyEtiketSayisi, out string En, out string OrgX, out string OrgY, out string YatayEtiketSayisi, out string vspace, out string hspace)
        {
            string str;
            yon = str = "";
            hspace = str = str;
            vspace = str = str;
            YatayEtiketSayisi = str = str;
            OrgY = str = str;
            OrgX = str = str;
            En = str = str;
            DikeyEtiketSayisi = str = str;
            Aciklama = Boy = str;
            if (GlobalData.doc != null)
            {
                XmlNodeList childNodes = GlobalData.doc.SelectSingleNode("koctas/etiket[@tip='" + tip + "']").ChildNodes;
                foreach (XmlNode node2 in childNodes)
                {
                    switch (node2.Name)
                    {
                        case "yatay":
                            YatayEtiketSayisi = node2.InnerText;
                            break;

                        case "yon":
                            yon = node2.InnerText;
                            break;

                        case "dikey":
                            DikeyEtiketSayisi = node2.InnerText;
                            break;

                        case "en":
                            En = node2.InnerText;
                            break;

                        case "boy":
                            Boy = node2.InnerText;
                            break;

                        case "orgx":
                            OrgX = node2.InnerText;
                            break;

                        case "orgy":
                            OrgY = node2.InnerText;
                            break;

                        case "vspace":
                            vspace = node2.InnerText;
                            break;

                        case "hspace":
                            hspace = node2.InnerText;
                            break;

                        case "aciklama":
                            Aciklama = node2.InnerText;
                            break;
                    }
                }
            }
        }

        public static void DecryptFile(string inputFile, string outputFile)
        {
            int num;
            string s = "myKey123";
            byte[] bytes = new UnicodeEncoding().GetBytes(s);
            FileStream stream = new FileStream(inputFile, FileMode.Open);
            RijndaelManaged managed = new RijndaelManaged();
            CryptoStream stream2 = new CryptoStream(stream, managed.CreateDecryptor(bytes, bytes), CryptoStreamMode.Read);
            FileStream stream3 = new FileStream(outputFile, FileMode.Create);
            while ((num = stream2.ReadByte()) != -1)
            {
                stream3.WriteByte((byte)num);
            }
            stream3.Close();
            stream2.Close();
            stream.Close();
        }

        public static void EncryptFile(string inputFile, string outputFile)
        {
            try
            {
                int num;
                string s = "myKey123";
                byte[] bytes = new UnicodeEncoding().GetBytes(s);
                string path = outputFile;
                FileStream stream = new FileStream(path, FileMode.Create);
                RijndaelManaged managed = new RijndaelManaged();
                CryptoStream stream2 = new CryptoStream(stream, managed.CreateEncryptor(bytes, bytes), CryptoStreamMode.Write);
                FileStream stream3 = new FileStream(inputFile, FileMode.Open);
                while ((num = stream3.ReadByte()) != -1)
                {
                    stream2.WriteByte((byte)num);
                }
                stream3.Close();
                stream2.Close();
                stream.Close();
            }
            catch
            {
                MessageBox.Show("Encryption failed!", "Error");
            }
        }

        internal static void initialization()
        {
            //Desidn dosyası serverdan alındı. 
            GlobalData.orjXMLPath = Application.StartupPath + @"\koctasDec.dsgn";
            if (File.Exists(GlobalData.orjXMLPath))
            {
                GlobalData.designFilePath = GlobalData.orjXMLPath;
            }
            else if (File.Exists(GlobalData.orjXMLPath1))
            {
                GlobalData.designFilePath = GlobalData.orjXMLPath1;
            }
            else if (File.Exists(GlobalData.orjXMLPath2))
            {
                GlobalData.designFilePath = GlobalData.orjXMLPath2;
            }
            if (GlobalData.designFilePath == "")
            {
                MessageBox.Show("Design dosyası ; " + "\n" + GlobalData.orjXMLPath + "  , \n   " + GlobalData.orjXMLPath1 + "    ,  \n  " + GlobalData.orjXMLPath2 + " \n  adreslerinde herhangi birinde bulunamadı");
                return;
            }

            //Localde kopylanacağı klasor varmı kontrol edilecek yoksa oluşturulacak.
            try
            {
                string myDocuments = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments);
                GlobalData.XMLPath = @"C:\Saplabel\koctasDec2.dsgn";
                GlobalData.XMLPath2 = @"C:\Saplabel\koctasDec.dsgn";
                if (File.Exists(GlobalData.XMLPath))
                {
                    File.Delete(GlobalData.XMLPath);
                }
                if (File.Exists(GlobalData.XMLPath2))
                {
                    File.Delete(GlobalData.XMLPath2);
                }
                if (!Directory.Exists(@"C:\Saplabel\"))
                {

                    Directory.CreateDirectory(@"C:\Saplabel\");
                }
            }
            catch
            {
                try
                {
                    string myDocuments = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments);
                    GlobalData.XMLPath = @"" + myDocuments + "\\Saplabel\\koctasDec2.dsgn";
                    GlobalData.XMLPath2 = @"" + myDocuments + "\\Saplabel\\koctasDec.dsgn";
                    if (File.Exists(GlobalData.XMLPath))
                    {
                        File.Delete(GlobalData.XMLPath);
                    }
                    if (File.Exists(GlobalData.XMLPath2))
                    {
                        File.Delete(GlobalData.XMLPath2);
                    }
                    if (!Directory.Exists(@"" + myDocuments + "\\Saplabel"))
                    {
                        Directory.CreateDirectory(@"" + myDocuments + "\\Saplabel");
                    }
                }
                catch
                {
                    MessageBox.Show("Design dosyası için Saplabel klasörü oluşturulamadı.");
                    return;
                }
            }



            File.Copy(GlobalData.designFilePath, GlobalData.XMLPath2);
            DecryptFile(GlobalData.XMLPath2, GlobalData.XMLPath);
            GlobalData.doc.Load(GlobalData.XMLPath);
        }

        internal static void itaboku()
        {
            string[] strArray = File.ReadAllLines(GlobalData.itabPath, Encoding.GetEncoding("windows-1254"));
            GlobalData.etkList1.Clear();
            GlobalData.etkList2.Clear();
            GlobalData.etkList4.Clear();
            int num = 0;
            foreach (string str in strArray)
            {
                string[] strArray3 = str.Split(new char[] { '\t' });

                if (str != "")
                {
                    Etiket item = new Etiket();
                    item.barkod = strArray3[0];
                    item.tip = strArray3[2];
                    item.count = Convert.ToInt32(strArray3[3]);
                    item.matnr = strArray3[4];
                    item.maktx = strArray3[5];

                    string[] strArray4 = strArray3[6].Split(new char[] { ',' });
                    item.fiyat1 = strArray4[0];
                    item.fiyat2 = strArray4[1];
                    item.ayirac = ",";
                    item.fiyat_birim = "₺";
                    item.olcu_birim = " / " + strArray3[7];

                    item.fiyat1_yeni = strArray4[0];
                    item.fiyat2_yeni = strArray4[1];
                    item.ayirac_yeni = ",";
                    item.fiyat_birim_yeni = "₺";
                    item.olcu_birim_yeni = " / " + strArray3[7];
                    string[] strArray4Eski = strArray3[21].Split(new char[] { ',' });
                    item.fiyat1_eski = strArray4Eski[0];
                    item.fiyat2_eski = strArray4Eski[1];
                    item.ayirac_eski = ",";
                    item.fiyat_birim_eski = "₺";
                    item.olcu_birim_eski = " / " + strArray3[7];
                    item.EskiFiyatBas = strArray3[22];
                    item.EskiFiyatCarpi = strArray3[23];
                    item.reyon = strArray3[13];
                    item.mensei = "Menşei :" + strArray3[20];
                    item.kdv = "FİYATA KDV DAHİLDİR";
                    item.tarih = DateTime.Now.ToShortDateString();
                    item.parokart = "Koçtaşkart ile geçerlidir.";
                    if (strArray3.Length > 24)
                        item.parokart_gecer = strArray3[24];
                    else
                        item.parokart_gecer = "N";
                    item.gecer_tar_ayirac = "-";
                    if (strArray3.Length > 25)
                        item.gecer_tar_basla = strArray3[25];
                    if (strArray3.Length > 26)
                        item.gecer_tar_bitis = strArray3[26];
                    item.gecer_tar_text = "Geçerlilik Tarihi ";
                    for (int i = 0; i < item.count; i++)
                    {
                        int tip;
                        bool result = Int32.TryParse(item.tip, out tip);
                        if (true == result)
                        {
                            {
                                if (tip == 1)
                                {
                                    GlobalData.etkList1.Add(item);
                                }
                                else if (tip == 2)
                                {
                                    GlobalData.etkList2.Add(item);
                                }
                                else if (tip == 4)
                                {
                                    GlobalData.etkList4.Add(item);
                                }
                            }
                        }
                        num++;
                    }
                }
            }
        }

        public static void orientation(string tip, out string orientat)
        {
            orientat = "";
            if (GlobalData.doc != null)
            {
                XmlNode node = GlobalData.doc.SelectSingleNode("koctas/etiket[@tip='" + tip + "']/yon");
                orientat = node.InnerText;
            }
        }

        public static void PrinterGetir(ComboBox cbPrinter)
        {
            cbPrinter.Items.Clear();
            foreach (string str in PrinterSettings.InstalledPrinters)
            {
                cbPrinter.Items.Add(str);
            }
            PrinterSettings settings = new PrinterSettings();
            cbPrinter.SelectedItem = settings.PrinterName;
        }

        public static List<string> splitstring(string sentence, int max)
        {
            string[] strArray = sentence.Split(new char[] { ' ' });
            List<string> list = new List<string>();
            List<int> source = new List<int>();
            int[] numArray = new int[strArray.Length];
            char[] chArray2 = sentence.ToCharArray();
            for (int i = 0; i < chArray2.Length; i++)
            {
                if (chArray2[i] == ' ')
                {
                    source.Add(i);
                }
            }
            source.Add(sentence.Length);
            int startIndex = 0;
            int num3 = 0;
            for (int j = 0; j < source.Count; j++)
            {
                int num5 = Convert.ToInt32(source[j].ToString());  //source.ElementAt<int>(j);
                if ((num5 - startIndex) < (max + 1))
                {
                    num3 = num5;
                }
                else if ((num5 - startIndex) == (max + 1))
                {
                    list.Add(sentence.Substring(startIndex, num5 - startIndex));
                    startIndex = num5;
                    num3 = num5;
                }
                else if ((num5 - startIndex) > (max + 1))
                {
                    if (startIndex == num3)
                    {
                        list.Add(sentence.Substring(startIndex, max));
                        startIndex += max;
                        num3 = startIndex;
                    }
                    else
                    {
                        list.Add(sentence.Substring(startIndex, num3 - startIndex));
                        startIndex = num3;
                    }
                    j--;
                }
            }
            list.Add(sentence.Substring(startIndex));
            return list;
        }
    }
}
