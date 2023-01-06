namespace DataCommon
{
    public enum BildirimTuru
    {
        sms,
        email
    }

    public class Class1
    {

    }

    public interface IBildirilebilir
    {
        public BildirimTuru BildirimTercihi { get; }
    }

    public class Musteri: Kisi, IBildirilebilir
    {
        public List<Adres> Adresler { get; set;}

        public BildirimTuru BildirimTercihi 
        { 
            get { return BildirimTuru.email; } 
        }
    }

    public class Personel: Kisi
    {
        public String SicilNo { get; set; }
        public int Bolum { get; set; }

        public Adres EvAdresi { get; set; }

    }
   

    public class SMS
    {

    }

    public class Email
    {

    }


}