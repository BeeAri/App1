namespace DataCommon
{
    public abstract class Kisi
    {

        //public Kisi() { } //ad ve soyadı boş bırakmanı sağlar.

        //public Kisi(string ad, string soyad) //ad ve soyadı zorunlu kılmanı sağlar.
        //{
        //    Ad = ad;
        //    Soyad = soyad;
        //}   

        public String Ad { get; set; } // public String Ad { get => ad; set => ad = value.Trim().ToUpper(); } valueye değişkenlik yapılabiliyor böyle.

        string soyad; 
        public String Soyad
        {
            get { return soyad; }
            set { soyad = value.Trim().ToUpper(); }
        }

        /* string soyad1;
        public String Soyad1
        {
            get { return soyad1; }
            set { soyad1 = value; }
        } */

        public String TamAdi 
        { 
            get { return String.Format("{1}, {0}", Ad, Soyad); } 
        }
        //public String TamAdi { get { return String.Format("{0} {1}", Ad, Soyad); } }
    }

}