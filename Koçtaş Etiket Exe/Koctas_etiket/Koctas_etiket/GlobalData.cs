using NBarCodes;
using System;
using System.Collections.Generic;
using System.Text;
using System.Xml;

namespace Koctas_etiket
{
    class GlobalData
    {
        public static BarCodeSettings bars = new BarCodeSettings();
        public static int bosEtiket = 0;
        public static int counter = 0;
        public static XmlDocument doc = new XmlDocument();
        public static List<Etiket> dummy = new List<Etiket>();
        public static List<Etiket> etkList = new List<Etiket>();
        public static List<Etiket> etkList1 = new List<Etiket>();
        public static List<Etiket> etkList2 = new List<Etiket>();
        public static List<Etiket> etkList4 = new List<Etiket>();
        public static string etkTip = "";
        public static string itabPath = @"C:\Saplabel\itab.txt";
        public static string designFilePath = "";
        public static string designFileLocal = "";
        public static string orjXMLPath = @"\koctasDec.dsgn";
        public static string orjXMLPath2 = @"\\172.16.5.199\magaza_etiket\koctasDec.dsgn";
        public static string orjXMLPath1 = @"\\10.161.161.81\magaza_etiket\koctasDec.dsgn";
        //public static string orjXMLPath = @"\\172.16.5.199\magaza_etiket\kampanya\koctasDec.dsgn";
        //public static string startPath = "";
        public static string printer = "";
        public static List<string> reyonList = new List<string>();
        public static List<Etiket> temp = new List<Etiket>();
        public static string XMLPath = "";
        public static string XMLPath2 = "";
        public static int YERLI_LOGO_MARGIN = 30;
    }
}
