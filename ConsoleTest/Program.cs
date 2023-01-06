using DataCommon;
using ConsoleTest.Models;
using Microsoft.EntityFrameworkCore;

namespace ConsoleTest
{
    internal class Program
    {
        static void Main1(string[] args)
        {
            ChinookContext cnt = new ChinookContext();

            //List<Customer> musteriler = cnt.Customers.ToList();
            //List<Customer> musteriler = cnt.Customers.Take(5).ToList();
            //List<Customer> musteriler = cnt.Customers.Skip(5).Take(5).ToList();
            //List<Customer> musteriler = cnt.Customers.Where(x=>x.FirstName=="Helena").ToList(); //'x' her bir satırdaki customerı demek istiyor. x yerine başka bir şey de yazılabilir.
            //List<Customer> musteriler = cnt.Customers.Where(x => x.FirstName.StartsWith("A")).ToList();
            //int musterisayisi = cnt.Customers.Count();
            //Customer customer = musteriler[0];

            /*
            Artist ar = new Artist();
            ar.Name = "Cüneyt Arkın";
            cnt.Artists.Add(ar);
            cnt.SaveChanges();
            */


            /*
            //Artist degisecek = cnt.Artists.First(x => x.Name.ToLower.StartsWith("Cüneyt ".ToLower));
            Artist degisecek = cnt.Artists.First(x => x.Name.StartsWith("Cüneyt"));
            degisecek.Name = "Cüneyt Cürekli";
            cnt.Artists.Update(degisecek);
            cnt.SaveChanges();
            */

            /*
            Artist silinecek = cnt.Artists.First(x => x.Name.StartsWith("Cüneyt"));
            cnt.Artists.Remove(silinecek);
            cnt.SaveChanges();
            */


            //foreach (var item in musteriler)
            //{
            //    Console.WriteLine(item.FirstName);
            //}

            //Kisi k1 = new Personel();
            //k1.Ad = "Ali";
            //k1.Soyad = "Demir";


            //Kisi k2 = new Personel { Ad = "Mert", Soyad = "Der" };
            //Kisi k3 = new Musteri { Ad = "Veli", Soyad = "Kar" };

            //List<Kisi> list = new List<Kisi>();
            //list.Add(k1); list.Add(k2); list.Add(k3);

            //foreach (var item in list) //Herbir eleman için 'item' yazılır. başka bir şey yazsan da olur.
            //{
            //    Console.WriteLine(item.TamAdi);
            //}

        }
        static void Main()
        {
            ChinookContext cnt = new ChinookContext();

            List<Artist> artists = cnt.Artists.Take(10).ToList();
            foreach (var artist in artists)
            {
                Console.WriteLine("Top 10 List");

                String s = String.Format("Id: {0} Name: {1}", artist.ArtistId, artist.Name);
                Console.WriteLine(s);
                
            }
            Console.WriteLine();
            Console.WriteLine("Artistin Id numarasını yazınız:");

            string secim = Console.ReadLine();
            Console.WriteLine(secim + " Seçtiniz.");
            Console.WriteLine();
            Console.WriteLine("Seçilen Artistin Albümü Listeleniyor...");

            int intSecim = int.Parse(secim);

            //List<Album> albums1 = cnt.Albums.Where(x => x.ArtistId == intSecim).ToList();

            var res = cnt.Artists.Include(x => x.Albums).ToList(); //bütün albümü getiriyor.

            Artist art = artists.Single(x => x.ArtistId == intSecim);

            List<Album> albums = art.Albums.ToList();

            //List<Album> albums = artists.Single(x=>x.ArtistId == intSecim).Albums.ToList();


            art.Albums.Add(new Album { Title = "Zero" }); //seçilen sanatçının albümüne direkt ekler. artist ıdye bağlamak gerek kalmadı.
            cnt.SaveChanges();

            /* 
            //burada bir şarkıyı albüme ekliyoruz ve burada artistıd ye bağlı olduğu için onu da eklemek gerekti.
            Album al = new Album();
            al.Title = "The Sing";
            al.ArtistId = intSecim;
            cnt.Albums.Add(al);
            cnt.SaveChanges();
            */




            foreach (var album in albums)
            {
                Console.WriteLine(album.Title);
            }

        }
    }
}