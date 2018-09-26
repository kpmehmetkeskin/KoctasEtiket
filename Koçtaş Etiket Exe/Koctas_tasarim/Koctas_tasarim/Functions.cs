using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Drawing;
using System.Drawing.Printing;
using System.IO;
using System.Runtime.InteropServices;
using System.Security.Cryptography;
using System.Windows.Forms;
using System.Xml;

namespace Koctas_tasarim
{
    internal class Functions
    {
        public static void AktifDegistir(string tip, string item, string aktif)
        {
            if (GlobalData.doc != null)
            {
                GlobalData.doc.SelectSingleNode("koctas/etiket[@isim='" + tip + "']/items/item[@name='" + item + "']/aktif").InnerText = aktif;
                GlobalData.doc.Save(GlobalData.XMLPath);
            }
        }

        public static void BilgiGetirItem(string tip, string text, string item, out string font, out float size, out float p_x, out string aktif, out float p_y, out string maxkar, out float imageWidth, out float imageHeigth)
        {
            string str;
            float num;
            maxkar = str = "";
            font = aktif = str;
            p_y = num = 0f;
            size = p_x = num;
            imageWidth = 0f;
            imageHeigth = 0f;
            if (GlobalData.doc != null)
            {
                XmlNode node = GlobalData.doc.SelectSingleNode("koctas/etiket[@isim='" + tip + "']/items/item[@name='" + item + "']/size");
                size = Convert.ToInt32(node.InnerText);
                node = GlobalData.doc.SelectSingleNode("koctas/etiket[@isim='" + tip + "']/items/item[@name='" + item + "']/font");
                font = node.InnerText;
                node = GlobalData.doc.SelectSingleNode("koctas/etiket[@isim='" + tip + "']/items/item[@name='" + item + "']/aktif");
                aktif = node.InnerText;
                try
                {
                    node = GlobalData.doc.SelectSingleNode("koctas/etiket[@isim='" + tip + "']/items/item[@name='" + item + "']/karsayi");
                    maxkar = node.InnerText;
                }
                catch
                {
                    maxkar = "";
                    Console.WriteLine("maxkar");
                }
                node = GlobalData.doc.SelectSingleNode("koctas/etiket[@isim='" + tip + "']/items/item[@name='" + item + "']/XPoint");
                p_x = Convert.ToInt32(node.InnerText);
                node = GlobalData.doc.SelectSingleNode("koctas/etiket[@isim='" + tip + "']/items/item[@name='" + item + "']/YPoint");
                p_y = Convert.ToInt32(node.InnerText);
                node = GlobalData.doc.SelectSingleNode("koctas/etiket[@isim='" + tip + "']/items/item[@name='" + item + "']/imageWidth");
                if(node!=null)
                imageWidth = Convert.ToInt32(node.InnerText);
                node = GlobalData.doc.SelectSingleNode("koctas/etiket[@isim='" + tip + "']/items/item[@name='" + item + "']/imageHeigth");
                if (node != null)
                    imageHeigth = Convert.ToInt32(node.InnerText);
                try
                {
                    if (GlobalData.doc.SelectSingleNode("koctas/etiket[@isim='" + tip + "']/items/item[@name='" + item + "']/durumlar") != null)
                    {
                        int length = text.Length;
                        //TODO
                        if ((tip == "001") && (length >= 6))
                        {
                            length = 5;
                        }
                        XmlNode node3 = null;
                        XmlNode node4 = null;
                        XmlNode node5 = null;
                        node3 = GlobalData.doc.SelectSingleNode(string.Concat(new object[] { "koctas/etiket[@isim='", tip, "']/items/item[@name='", item, "']/durumlar/durum[@name='", length, "']/XPoint" }));
                        p_x = Convert.ToInt32(node3.InnerText);
                        node4 = GlobalData.doc.SelectSingleNode(string.Concat(new object[] { "koctas/etiket[@isim='", tip, "']/items/item[@name='", item, "']/durumlar/durum[@name='", length, "']/YPoint" }));
                        p_y = Convert.ToInt32(node4.InnerText);
                        node5 = GlobalData.doc.SelectSingleNode(string.Concat(new object[] { "koctas/etiket[@isim='", tip, "']/items/item[@name='", item, "']/durumlar/durum[@name='", length, "']/size" }));
                        size = Convert.ToInt32(node5.InnerText);
                    }
                }
                catch
                {
                    Console.WriteLine("durumlar");
                }
            }
        }

        public static void BilgileriGetir(string tip, out string Yon, out string Aciklama, out string Boy, out string DikeyEtiketSayisi, out string En, out string OrgX, out string OrgY, out string YatayEtiketSayisi, out string vspace, out string hspace)
        {
            string str;
            Yon = ""; 
            str = "";
            hspace = "";
            vspace = "";
            YatayEtiketSayisi = "";
            OrgY = "";
            OrgX = "";
            En = "";
            DikeyEtiketSayisi = "";
            Aciklama = Boy = str;
            if (GlobalData.doc != null)
            {
                XmlNodeList childNodes = GlobalData.doc.SelectSingleNode("koctas/etiket[@isim='" + tip + "']").ChildNodes;
                foreach (XmlNode node2 in childNodes)
                {
                    switch (node2.Name)
                    {
                        case "yon":
                            Yon = node2.InnerText;
                            break;

                        case "yatay":
                            YatayEtiketSayisi = node2.InnerText;
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

        public static void BilgileriGetir2(string tip, string item, out string x, out string y, out string font, out string Size, out string Aktif, out string maxkar, DataGridView dg, out string imageWidth, out string imageHeigth)
        {
            string str;
            string str2;
            string str3;
            string str4; 
            maxkar = str = "";
            Aktif = str2 = str;
            font = str3 = str2;
            Size = str4 = str3;
            x = y = str4;
            imageHeigth = "0";
            imageWidth = "0";
            dg.DataSource = null;
            if (GlobalData.doc != null)
            {
                foreach (XmlNode node2 in GlobalData.doc.SelectSingleNode("koctas/etiket[@isim='" + tip + "']/items/item[@name='" + item + "']").ChildNodes)
                {
                    switch (node2.Name)
                    {
                        case "karsayi":
                            {
                                maxkar = node2.InnerText;
                                continue;
                            }
                        case "aktif":
                            {
                                Aktif = node2.InnerText;
                                continue;
                            }
                        case "size":
                            {
                                Size = node2.InnerText;
                                continue;
                            }
                        case "font":
                            {
                                font = node2.InnerText;
                                continue;
                            }
                        case "XPoint":
                            {
                                x = node2.InnerText;
                                continue;
                            }
                        case "YPoint":
                            {
                                y = node2.InnerText;
                                continue;
                            }
                        case "imageWidth":
                            {
                                
                                imageWidth = node2.InnerText;
                                continue;
                            }
                        case "imageHeigth":
                            {
                                imageHeigth = node2.InnerText;
                                continue;
                            }
                        case "durumlar":
                            {
                                if (item != "fiyat1")
                                {
                                    break;
                                }
                                DataTable table = new DataTable();
                                DataColumn column = new DataColumn("Uzunluk");
                                DataColumn column2 = new DataColumn("X Koordinatı");
                                DataColumn column3 = new DataColumn("Y Koordinatı");
                                DataColumn column4 = new DataColumn("Font B\x00fcy\x00fckl\x00fcğ\x00fc");
                                table.Columns.Add(column);
                                table.Columns.Add(column2);
                                table.Columns.Add(column3);
                                table.Columns.Add(column4);
                                foreach (XmlNode node3 in node2.ChildNodes)
                                {
                                    object[] values = new object[4];
                                    values[0] = node3.Attributes["name"].InnerText;
                                    XmlNode node4 = node3.ChildNodes[0];
                                    values[1] = node4.InnerText;
                                    XmlNode node5 = node3.ChildNodes[1];
                                    values[2] = node5.InnerText;
                                    XmlNode node6 = node3.ChildNodes[2];
                                    values[3] = node6.InnerText;
                                    table.Rows.Add(values);
                                }
                                dg.DataSource = table;
                                continue;
                            }
                        default:
                            {
                                continue;
                            }
                    }
                    if (item == "fiyat1_eski")
                    {
                        DataTable table2 = new DataTable();
                        DataColumn column5 = new DataColumn("Uzunluk");
                        DataColumn column6 = new DataColumn("X Koordinatı");
                        DataColumn column7 = new DataColumn("Y Koordinatı");
                        DataColumn column8 = new DataColumn("Font B\x00fcy\x00fckl\x00fcğ\x00fc");
                        table2.Columns.Add(column5);
                        table2.Columns.Add(column6);
                        table2.Columns.Add(column7);
                        table2.Columns.Add(column8);
                        foreach (XmlNode node7 in node2.ChildNodes)
                        {
                            object[] objArray2 = new object[4];
                            objArray2[0] = node7.Attributes["name"].InnerText;
                            XmlNode node8 = node7.ChildNodes[0];
                            objArray2[1] = node8.InnerText;
                            XmlNode node9 = node7.ChildNodes[1];
                            objArray2[2] = node9.InnerText;
                            XmlNode node10 = node7.ChildNodes[2];
                            objArray2[3] = node10.InnerText;
                            table2.Rows.Add(objArray2);
                        }
                        dg.DataSource = table2;
                    }
                    else if (item == "fiyat1_yeni")
                    {
                        DataTable table3 = new DataTable();
                        DataColumn column9 = new DataColumn("Uzunluk");
                        DataColumn column10 = new DataColumn("X Koordinatı");
                        DataColumn column11 = new DataColumn("Y Koordinatı");
                        DataColumn column12 = new DataColumn("Font B\x00fcy\x00fckl\x00fcğ\x00fc");
                        table3.Columns.Add(column9);
                        table3.Columns.Add(column10);
                        table3.Columns.Add(column11);
                        table3.Columns.Add(column12);
                        foreach (XmlNode node11 in node2.ChildNodes)
                        {
                            object[] objArray3 = new object[4];
                            objArray3[0] = node11.Attributes["name"].InnerText;
                            XmlNode node12 = node11.ChildNodes[0];
                            objArray3[1] = node12.InnerText;
                            XmlNode node13 = node11.ChildNodes[1];
                            objArray3[2] = node13.InnerText;
                            XmlNode node14 = node11.ChildNodes[2];
                            objArray3[3] = node14.InnerText;
                            table3.Rows.Add(objArray3);
                        }
                        dg.DataSource = table3;
                    }
                    else if (item == "carpi_eski")
                    {
                        DataTable table4 = new DataTable();
                        DataColumn column13 = new DataColumn("Uzunluk");
                        DataColumn column14 = new DataColumn("1	Start X");
                        DataColumn column15 = new DataColumn("1 Start Y");
                        DataColumn column16 = new DataColumn("1	Stop X");
                        DataColumn column17 = new DataColumn("1	Stop Y");
                        DataColumn column18 = new DataColumn("2	Start X");
                        DataColumn column19 = new DataColumn("2 Start Y");
                        DataColumn column20 = new DataColumn("2	Stop X");
                        DataColumn column21 = new DataColumn("2	Stop Y");
                        table4.Columns.Add(column13);
                        table4.Columns.Add(column14);
                        table4.Columns.Add(column15);
                        table4.Columns.Add(column16);
                        table4.Columns.Add(column17);
                        table4.Columns.Add(column18);
                        table4.Columns.Add(column19);
                        table4.Columns.Add(column20);
                        table4.Columns.Add(column21);
                        foreach (XmlNode node15 in node2.ChildNodes)
                        {
                            object[] objArray4 = new object[9];
                            objArray4[0] = node15.Attributes["name"].InnerText;
                            XmlNode node16 = node15.ChildNodes[0];
                            objArray4[1] = node16.InnerText;
                            XmlNode node17 = node15.ChildNodes[1];
                            objArray4[2] = node17.InnerText;
                            XmlNode node18 = node15.ChildNodes[2];
                            objArray4[3] = node18.InnerText;
                            XmlNode node19 = node15.ChildNodes[3];
                            objArray4[4] = node19.InnerText;
                            XmlNode node20 = node15.ChildNodes[4];
                            objArray4[5] = node20.InnerText;
                            XmlNode node21 = node15.ChildNodes[5];
                            objArray4[6] = node21.InnerText;
                            XmlNode node22 = node15.ChildNodes[6];
                            objArray4[7] = node22.InnerText;
                            XmlNode node23 = node15.ChildNodes[7];
                            objArray4[8] = node23.InnerText;
                            table4.Rows.Add(objArray4);
                        }
                        dg.DataSource = table4;
                    }
                }
            }
        }



        public static void CarpiKoorGuncelle(string tip, string uzunluk, string item, string startPoint_X1, string startPoint_Y1, string stopPoint_X1, string stopPoint_Y1, string startPoint_X2, string startPoint_Y2, string stopPoint_X2, string stopPoint_Y2)
        {

            if (GlobalData.doc != null)
            {
                foreach (XmlNode node2 in GlobalData.doc.SelectSingleNode("koctas/etiket[@isim='" + tip + "']/items/item[@name='carpi_eski']/durumlar/durum[@name='" + uzunluk + "']").ChildNodes)
                {
                    if (node2 == null)
                    {
                        continue;
                    }
                    switch (node2.Name)
                    {
                        case "startPoint_X1":
                            node2.InnerText = startPoint_X1;
                            break;

                        case "startPoint_Y1":
                            node2.InnerText = startPoint_Y1;
                            break;

                        case "stopPoint_X1":
                            node2.InnerText = stopPoint_X1;
                            break;

                        case "stopPoint_Y1":
                            node2.InnerText = stopPoint_Y1;
                            break;

                        case "startPoint_X2":
                            node2.InnerText = startPoint_X2;
                            break;

                        case "startPoint_Y2":
                            node2.InnerText = startPoint_Y2;
                            break;

                        case "stopPoint_X2":
                            node2.InnerText = stopPoint_X2;
                            break;

                        case "stopPoint_Y2":
                            node2.InnerText = stopPoint_Y2;
                            break;
                    }
                }
                GlobalData.doc.Save(GlobalData.XMLPath);
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

        public static void DurumEkle(string tip, string uzunluk, string Boyut, string korX, string korY,string tip2)
        {
            if (GlobalData.doc != null)
            {
                XmlNodeList childNodes = GlobalData.doc.SelectSingleNode("koctas/etiket[@isim='" + tip + "']/items/item[@name='"+tip2+"']/durumlar/durum[@name='" + uzunluk + "']").ChildNodes;
                foreach (XmlNode node2 in childNodes)
                {
                    string name = node2.Name;
                    if (name != null)
                    {
                        if (name != "XPoint")
                        {
                            if (name == "YPoint")
                            {
                                goto Label_00D7;
                            }
                            if (name == "size")
                            {
                                goto Label_00E6;
                            }
                        }
                        else
                        {
                            node2.InnerText = korX;
                        }
                    }
                    continue;
                Label_00D7:
                    node2.InnerText = korY;
                    continue;
                Label_00E6:
                    node2.InnerText = Boyut;
                }
                GlobalData.doc.Save(GlobalData.XMLPath);
            }
        }

        public static void DurumEkleAna(string tip, string fiyattip,string uzunluk)
        {
            if (GlobalData.doc != null)
            {
                XmlNode node = GlobalData.doc.SelectSingleNode("koctas/etiket[@isim='" + tip + "']/items/item[@name='"+fiyattip+"']/durumlar");
                XmlElement newChild = GlobalData.doc.CreateElement("durum");
                newChild.SetAttribute("name", uzunluk);
                XmlElement element2 = GlobalData.doc.CreateElement("XPoint");
                XmlElement element3 = GlobalData.doc.CreateElement("YPoint");
                XmlElement element4 = GlobalData.doc.CreateElement("size");
                newChild.AppendChild(element2);
                newChild.AppendChild(element3);
                newChild.AppendChild(element4);
                node.AppendChild(newChild);
                GlobalData.doc.Save(GlobalData.XMLPath);
            }
        }
        public static void DurumEkleCarpi(string tip,  string uzunluk)
        {
            if (GlobalData.doc != null)
            {
                XmlNode node = GlobalData.doc.SelectSingleNode("koctas/etiket[@isim='" + tip + "']/items/item[@name='carpi_eski']/durumlar");
                XmlElement newChild = GlobalData.doc.CreateElement("durum");
                newChild.SetAttribute("name", uzunluk);
                XmlElement element2 = GlobalData.doc.CreateElement("startPoint_X1");
                XmlElement element3 = GlobalData.doc.CreateElement("startPoint_Y1");
                XmlElement element4 = GlobalData.doc.CreateElement("stopPoint_X1");
                XmlElement element5 = GlobalData.doc.CreateElement("stopPoint_Y1");
                XmlElement element6 = GlobalData.doc.CreateElement("startPoint_X2");
                XmlElement element7 = GlobalData.doc.CreateElement("startPoint_Y2");
                XmlElement element8 = GlobalData.doc.CreateElement("stopPoint_X2");
                XmlElement element9 = GlobalData.doc.CreateElement("stopPoint_Y2"); 
                
                newChild.AppendChild(element2);
                newChild.AppendChild(element3);
                newChild.AppendChild(element4);
                newChild.AppendChild(element5);
                newChild.AppendChild(element6);
                newChild.AppendChild(element7);
                newChild.AppendChild(element8);
                newChild.AppendChild(element9); 
                node.AppendChild(newChild);
                GlobalData.doc.Save(GlobalData.XMLPath);
            }
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

        public static string EtiketleriGetir(ListBox lb)
        {
            try
            {
                string xMLPath = GlobalData.XMLPath;
                GlobalData.doc.Load(GlobalData.XMLPath);
                if (GlobalData.doc != null)
                {
                    XmlNodeList list = GlobalData.doc.SelectNodes("koctas/etiket");
                    foreach (XmlNode node in list)
                    {
                        lb.Items.Add(node.Attributes["isim"].Value);
                    }
                }
                else
                {
                    return "E";
                }
            }
            catch
            {
                return "E";
            }
            return "S";
        }

        public static void EtiketUpdate(string tip, string Aciklama, string Boy, string DikeyEtiketSayisi, string En, string OrgX, string OrgY, string YatayEtiketSayisi, string vspace, string hspace)
        {
            if (GlobalData.doc != null)
            {
                XmlNodeList childNodes = GlobalData.doc.SelectSingleNode("koctas/etiket[@isim='" + tip + "']").ChildNodes;
                foreach (XmlNode node2 in childNodes)
                {
                    switch (node2.Name)
                    {
                        case "yatay":
                            node2.InnerText = YatayEtiketSayisi;
                            break;

                        case "dikey":
                            node2.InnerText = DikeyEtiketSayisi;
                            break;

                        case "en":
                            node2.InnerText = En;
                            break;

                        case "boy":
                            node2.InnerText = Boy;
                            break;

                        case "orgx":
                            node2.InnerText = OrgX;
                            break;

                        case "orgy":
                            node2.InnerText = OrgY;
                            break;

                        case "vspace":
                            node2.InnerText = vspace;
                            break;

                        case "hspace":
                            node2.InnerText = hspace;
                            break;

                        case "aciklama":
                            node2.InnerText = Aciklama;
                            break;
                    }
                }
                GlobalData.doc.Save(GlobalData.XMLPath);
            }
        }

        public static void EtiketUpdate2(string tip, string item, string Boyut, string Font, string korX, string korY, string aktif, string maxkar, DataGridView DG, string imageWidth, string imageHeigth)
        {
            if (GlobalData.doc != null)
            {
                XmlNodeList childNodes = GlobalData.doc.SelectSingleNode("koctas/etiket[@isim='" + tip + "']/items/item[@name='" + item + "']").ChildNodes;
                foreach (XmlNode node2 in childNodes)
                {
                    switch (node2.Name)
                    {
                        case "karsayi":
                            node2.InnerText = maxkar;
                            break;

                        case "aktif":
                            node2.InnerText = aktif;
                            break;

                        case "size":
                            node2.InnerText = Boyut;
                            break;

                        case "font":
                            node2.InnerText = Font;
                            break;

                        case "XPoint":
                            node2.InnerText = korX;
                            break;

                        case "YPoint":
                            node2.InnerText = korY;
                            break;
                        case "imageWidth":
                            node2.InnerText = imageWidth;
                            break;
                        case "imageHeigth":
                            node2.InnerText = imageHeigth;
                            break;
                    }
                }
                GlobalData.doc.Save(GlobalData.XMLPath);
            }
        }

        public static void FontDegistir(string tip, string Font)
        {
            if (GlobalData.doc != null)
            {
                GlobalData.doc.SelectSingleNode("koctas/etiket[@isim='" + tip + "']/items/item[@name='fiyat1']/font").InnerText = Font;
                GlobalData.doc.Save(GlobalData.XMLPath);
            }
        }

        public static void FontlariGetir(ComboBox cbFont)
        {
            cbFont.Items.Clear();
            foreach (FontFamily family in FontFamily.Families)
            {
                cbFont.Items.Add(family.Name);
            }
        }

        public static string ItemlariGetir(ListBox lb, string tip)
        {
            if (GlobalData.doc != null)
            {
                XmlNodeList list = GlobalData.doc.SelectNodes("koctas/etiket[@isim='" + tip + "']/items/item");
                foreach (XmlNode node in list)
                {
                    lb.Items.Add(node.Attributes["name"].Value);
                }
            }
            else
            {
                return "E";
            }
            return "S";
        }

 
        public static void nodeSil(string tip, string name, string item)
        { 
            if (GlobalData.doc != null)
            { 
                XmlNode node = GlobalData.doc.SelectSingleNode("koctas/etiket[@isim='" + tip + "']/items/item[@name='" + item + "']/durumlar");
                XmlNode oldChild = GlobalData.doc.SelectSingleNode("koctas/etiket[@isim='" + tip + "']/items/item[@name='" + item + "']/durumlar/durum[@name='" + name + "']");
                node.RemoveChild(oldChild);
                GlobalData.doc.Save(GlobalData.XMLPath);
            }
        }

        public static void PrinterGetir(ComboBox cbPrinter)
        {
            cbPrinter.Items.Clear();
            foreach (string str in PrinterSettings.InstalledPrinters)
            {
                cbPrinter.Items.Add(str);
            }
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
                int num5 = source.ElementAt<int>(j);
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
