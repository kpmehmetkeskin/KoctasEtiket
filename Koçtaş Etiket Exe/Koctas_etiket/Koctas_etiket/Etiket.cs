using System;
using System.Collections.Generic;
using System.Text;

namespace Koctas_etiket
{
    class Etiket
    {
        public Etiket()
        {
            this.count = 0;
            this.maktx = "";
            this.barkod = "";
            this.matnr = "";
            this.reyon = "";
            this.fiyat_birim = "";
            this.fiyat_birim_eski = "";
            this.fiyat_birim_yeni = "";
            this.fiyat1 = "";
            this.fiyat1_eski = "";
            this.fiyat1_yeni = "";
            this.fiyat2 = "";
            this.fiyat2_yeni = "";
            this.fiyat2_eski = "";
            this.ayirac = ",";
            this.ayirac_yeni = ",";
            this.ayirac_eski = ",";
            this.tarih = "";
            this.tip= "";
            this.mensei = "";
            this.kdv = "";
            this.EskiFiyatBas = "N";
            this.EskiFiyatCarpi = "N";
            this.parokart = "";
            this.parokart_gecer = "";
            this.gecer_tar_text = "";
            this.gecer_tar_basla = "";
            this.gecer_tar_bitis = "";
            this.olcu_birim = "";
            this.olcu_birim_yeni = "";
            this.olcu_birim_eski = "";
            this.gecer_tar_ayirac = "-";
  
        }

        public Etiket(int count, string maktx, string barkod, string matnr, string reyon, string fiyat_birim, string fiyat_birim_eski, string fiyat_birim_yeni, string fiyat1, string fiyat1_eski, string fiyat1_yeni, string fiyat2, string fiyat2_yeni, string fiyat2_eski, string ayirac, string ayirac_eski, string ayirac_yeni, string mensei, string EskiFiyatBas, string EskiFiyatCarpi, string parokart, string parokart_gecer, string gecer_tar_text, string gecer_tar_basla, string gecer_tar_bitis, string olcu_birim, string gecer_tar_ayirac)
        {
            this.kdv = this.kdv;
            this.EskiFiyatBas = EskiFiyatBas;
            this.EskiFiyatCarpi = EskiFiyatCarpi;
            this.count = count;
            this.maktx = maktx;
            this.barkod = barkod;
            this.matnr = matnr;
            this.reyon = reyon;
            this.mensei = mensei;
            this.fiyat_birim = fiyat_birim;
            this.fiyat_birim_eski = fiyat_birim_eski;
            this.fiyat_birim_yeni = fiyat_birim_yeni;
            this.fiyat1 = fiyat1;
            this.fiyat1_eski = fiyat1_eski;
            this.fiyat1_yeni = fiyat1_yeni;
            this.fiyat2 = fiyat2;
            this.fiyat2_eski = fiyat2_eski;
            this.fiyat2_yeni = fiyat2_yeni;
            this.ayirac = ayirac;
            this.ayirac_yeni = ayirac_yeni;
            this.ayirac_eski = ayirac_eski;
            this.tarih = this.tarih;
            this.tip = this.tip;
            this.parokart = parokart;
            this.parokart_gecer = parokart_gecer;
            this.gecer_tar_text = gecer_tar_text;
            this.gecer_tar_basla = gecer_tar_basla;
            this.gecer_tar_bitis = gecer_tar_bitis;
            this.olcu_birim = olcu_birim;
            this.olcu_birim_yeni = olcu_birim;
            this.olcu_birim_eski = olcu_birim;
            this.gecer_tar_ayirac = gecer_tar_ayirac;
        }

        public string ayirac_eski { get; set; }
        public string ayirac_yeni { get; set; }
        public string ayirac { get; set; }

        public string barkod { get; set; }

       
        public int count { get; set; }
        public string EskiFiyatBas { get; set; }
        public string EskiFiyatCarpi { get; set; }
         
        public string fiyat1 { get; set; }
        public string fiyat1_eski { get; set; }
        public string fiyat1_yeni { get; set; }

        public string fiyat2 { get; set; }
        public string fiyat2_yeni { get; set; }
        public string fiyat2_eski { get; set; }

        public string kdv { get; set; }

        public string maktx { get; set; }

        public string matnr { get; set; }

        public string mensei { get; set; }

        public string reyon { get; set; }

        public string tarih { get; set; }

        public string tip { get; set; }
        public string parokart { get; set; }
        public string parokart_gecer { get; set; }
        public string gecer_tar_text { get; set; }
        public string gecer_tar_basla { get; set; }
        public string gecer_tar_bitis { get; set; }

        public string gecer_tar_ayirac { get; set; }
        public string fiyat_birim { get; set; }
        public string fiyat_birim_eski { get; set; }
        public string fiyat_birim_yeni { get; set; }
        public string olcu_birim { get; set; }
        public string olcu_birim_eski { get; set; }
        public string olcu_birim_yeni { get; set; }
    }
}
