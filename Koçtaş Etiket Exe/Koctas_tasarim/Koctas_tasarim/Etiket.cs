using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Koctas_tasarim
{
   internal class Etiket
    {

        public string ayirac_eski { get; set; }
        public string ayirac_yeni { get; set; }
        public string ayirac { get; set; }
        public string barkod { get; set; }
        public string fiyat_birim { get; set; }
        public string fiyat_birim_eski { get; set; }
        public string fiyat_birim_yeni { get; set; }
        public string olcu_birim { get; set; }
        public string olcu_birim_eski { get; set; }
        public string olcu_birim_yeni { get; set; }
        public int count { get; set; }
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
        public string urunkodu { get; set; }
        public string parokart { get; set; }
        public string gecer_tar_text { get; set; }
        public string gecer_tar_basla { get; set; }
        public string gecer_tar_bitis { get; set; }

        public string gecer_tar_ayirac { get; set; }

        public Etiket()
        {
            count = 0;
            maktx = "";
            barkod = "";
            matnr = "";
            reyon = "";
            fiyat_birim = "";
            fiyat1 = "";
            fiyat2 = "";
            ayirac = ".";
            tarih = "";
            urunkodu = "";
            mensei = "";
            kdv = "";
            fiyat1_eski = "";
            fiyat2_eski = "";
            ayirac_eski = "";
            fiyat_birim_eski = "";
            fiyat1_yeni = "";
            fiyat2_yeni = "";
            ayirac_yeni = "";
            fiyat_birim_yeni = "";
            parokart = "";
            gecer_tar_text = "";
            gecer_tar_basla = "";
            gecer_tar_bitis = "";
            olcu_birim = "";
            olcu_birim_yeni = "";
            olcu_birim_eski = "";
            gecer_tar_ayirac = "-";
        }

        public Etiket(int count, string maktx, string barkod, string matnr, string reyon, string fiyat_birim, string fiyat1, string fiyat2, string ayirac, string mensei, string string_0, string string_1, string ayiraceski, string string_2, string string_3, string ayiracyeni, string parokart, string gecer_tar_text, string gecer_tar_basla, string gecer_tar_bitis,string olcu_birim,string gecer_tar_ayirac)
        {
            
            this.kdv = this.kdv;
            this.count = count;
            this.maktx = maktx;
            this.barkod = barkod;
            this.matnr = matnr;
            this.reyon = reyon;
            this.mensei = mensei;
            this.fiyat_birim = fiyat_birim;
            this.fiyat1 = fiyat1;
            this.fiyat2 = fiyat2;
            this.ayirac = ayirac;
            this.tarih = this.tarih;
            this.urunkodu = this.urunkodu;
            this.fiyat1_eski = string_0;
            this.fiyat2_eski = string_1;
            this.ayirac_eski = ayiraceski;
            this.fiyat_birim_eski = fiyat_birim;
            this.fiyat1_yeni = string_2;
            this.fiyat2_yeni = string_3;
            this.ayirac_yeni = ayiracyeni;
            this.fiyat_birim_yeni = fiyat_birim;
            this.parokart = parokart;
            this.gecer_tar_text = gecer_tar_text;
            this.gecer_tar_basla = gecer_tar_basla;
            this.gecer_tar_bitis = gecer_tar_bitis;
            this.olcu_birim = olcu_birim;
            this.olcu_birim_yeni = olcu_birim;
            this.olcu_birim_eski = olcu_birim;
            this.gecer_tar_ayirac = gecer_tar_ayirac;
        }
    }
}
