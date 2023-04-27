using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace TeknikServisPerformansi
{
    class TeknikServis
    {
        public int bakiye;
        public string[] telefonParcalari = new string[5] { "Batarya", "Ekran", "Şarj Soketi", "Anakart", "Hoparlör" };
        public string[] bilgisayarParcalari = new string[8] { "Batarya", "Ekran", "İşlemci", "Anakart", "Ram" , "Sabit Disk" , "Ekran Kartı" , "Güç Kaynağı"};

        public void anaMenu()
        {
            anaMenuGiris:
            Console.Clear();
            Console.WriteLine("--------- Teknik Servise Hoş Geldiniz ---------");
            Console.WriteLine("Cihaz Türünü Seçiniz");
            Console.WriteLine("1 - Telefon \n2 - Bilgisayar");
            ConsoleKeyInfo cihazTamirMenuSecim = Console.ReadKey();

            switch (cihazTamirMenuSecim.Key)
            {
                case ConsoleKey.D1:
                case ConsoleKey.NumPad1:
                    Telefon telefon = new Telefon();
                    telefon.telefonMenu();
                    break;

                
                case ConsoleKey.D2:
                case ConsoleKey.NumPad2:
                    Bilgisayar bilgisayar = new Bilgisayar();
                    bilgisayar.bilgisayarMenu();
                    break;


                default:
                    Console.WriteLine("Lütfen Doğru Şekilde Seçim Yapınız !");
                    goto anaMenuGiris;
            }
            
        }
    }

    class Telefon : TeknikServis
    {
        int[] tamirFiyatlari = new int[5];
        int telefonTamirUcreti;


        public void telefonMenu()
        {
            telefonMenuGiris:
            Console.Clear();
            Console.WriteLine("--------- Telefon Hizmeti ---------");
            Console.WriteLine("Lütfen Hizmet Seçiniz...");
            Console.WriteLine("1 - Telefon Tamiri \n2 - Telefon Satışı\n3 - Bakiye Göster \n4 - Bakiye Yatır \n5 - Bakiye Çek \n6 - Ana Menü");
            ConsoleKeyInfo anaMenuSecim = Console.ReadKey();

            switch (anaMenuSecim.Key)
            {
                case ConsoleKey.D1:
                case ConsoleKey.NumPad1:
                    cihazTamirMenu();
                    break;

                case ConsoleKey.D2:
                case ConsoleKey.NumPad2:
                    cihazSatis();
                    break;

                case ConsoleKey.D3:
                case ConsoleKey.NumPad3:
                    bakiyeGoster();
                    break;

                case ConsoleKey.D4:
                case ConsoleKey.NumPad4:
                    bakiyeYatir();
                    break;

                case ConsoleKey.D5:
                case ConsoleKey.NumPad5:
                    bakiyeCek();
                    break;

                case ConsoleKey.D6:
                case ConsoleKey.NumPad6:
                    anaMenu();
                    break;

                default:
                    Thread.Sleep(750);
                    Console.WriteLine("Lütfen Doğru Şekilde Seçim Yapınız !");
                    goto telefonMenuGiris;
            }
        }


        public void cihazTamirMenu()
        {
        cihazTamirMenu:
            Console.Clear();
            Console.WriteLine("--------- Telefon Tamir Menüsü ---------");
            Console.WriteLine("Yapacağınız İşlemi Seçiniz");
            Console.WriteLine("1 - Arıza Tespit \n2 - Arıza Tamiri\n3 - Telefon Menü \n4 - Ana Menü");
            ConsoleKeyInfo telefonMenuSecim = Console.ReadKey();

            switch (telefonMenuSecim.Key)
            {
                case ConsoleKey.D1:
                case ConsoleKey.NumPad1:
                    arizaTespit();
                    break;

                case ConsoleKey.D2:
                case ConsoleKey.NumPad2:
                    arizaTamir();
                    break;

                case ConsoleKey.D3:
                case ConsoleKey.NumPad3:
                    telefonMenu();
                    break;

                case ConsoleKey.D4:
                case ConsoleKey.NumPad4:
                    anaMenu();
                    break;

                default:
                    Thread.Sleep(750);
                    Console.WriteLine("Lütfen Doğru Şekilde Seçim Yapınız !");
                    goto cihazTamirMenu;
            }
        }


        public void bakiyeGoster()
        {
            Console.Clear();
            Console.WriteLine($"Bakiyeniz : {bakiye} TL");
            Console.WriteLine("Geçmek İçin Herhangi Bir Tuşa Basınız ..."); Console.ReadKey(); telefonMenu();
        }

        public void bakiyeYatir()
        {
            bakiyeYatirGiris:
            Console.Clear();
            int miktar;
            Console.Write("Yatırmak İstediğiniz Miktar ? : ");
            try
            {
                miktar = Convert.ToInt32(Console.ReadLine());
            }
            catch
            {
                Console.WriteLine("Lütfen Doğru Şekilde Giriş Yapınız !");
                Console.WriteLine("Geçmek İçin Herhangi Bir Tuşa Basınız ..."); Console.ReadKey(); goto bakiyeYatirGiris;
            }
            if (miktar > 0)
            {
                bakiye += miktar;
                Console.WriteLine($"\nParanız Yatırıldı \nYeni Bakiyeniz : {bakiye} TL");
                Console.WriteLine("Geçmek İçin Herhangi Bir Tuşa Basınız ..."); Console.ReadKey(); telefonMenu();
            }
            else
            {
                Console.WriteLine("\nLütfen Doğru Şekilde Para Yatırınız !");
                Console.WriteLine("Geçmek İçin Herhangi Bir Tuşa Basınız ..."); Console.ReadKey(); goto bakiyeYatirGiris;
            }
        }

        public void bakiyeCek()
        {
            bakiyeCekGiris:
            Console.Clear();
            int miktar;
            Console.Write("Çekmek İstediğiniz Miktar ? : ");
            try
            {
                miktar = Convert.ToInt32(Console.ReadLine());
            }
            catch
            {
                Console.WriteLine("\nLütfen Doğru Şekilde Giriş Yapınız !");
                Console.WriteLine("Geçmek İçin Herhangi Bir Tuşa Basınız ..."); Console.ReadKey(); goto bakiyeCekGiris;
            }
            if (miktar > 0)
            {
                if (bakiye >= miktar)
                {
                    bakiye -= miktar;
                    Console.WriteLine($"\nParanız Çekildi \nYeni Bakiyeniz : {bakiye} TL");
                    Console.WriteLine("Geçmek İçin Herhangi Bir Tuşa Basınız ..."); Console.ReadKey(); telefonMenu();
                }
                else
                {
                    Console.WriteLine("Malesef Çekmek İstediğniz Miktar Bakiyenizden Büyük !");
                    Console.WriteLine("Geçmek İçin Herhangi Bir Tuşa Basınız ..."); Console.ReadKey(); telefonMenu();
                }
            }
            else
            {
                Console.WriteLine("Lütfen Doğru Şekilde Para Çekiniz !");
                Console.WriteLine("Geçmek İçin Herhangi Bir Tuşa Basınız ..."); Console.ReadKey(); goto bakiyeCekGiris;
            }
        }

        public void arizaTespit()
        {
            Console.Clear();    
            Random rnd = new Random();
            for (int i = 0; i <= 4; i++)
            {
                tamirFiyatlari[i] = rnd.Next(500, 2500);
            }
            int arizaOlasilik = rnd.Next(1,5);
            if(arizaOlasilik <= 3)
            {
                int ariza = rnd.Next(0, 5);
                telefonTamirUcreti = tamirFiyatlari[ariza];
                Console.WriteLine($"Telefonunuzdaki Arıza : {telefonParcalari[ariza]} Bozuk \nTamir Ücreti : {telefonTamirUcreti} TL");
                Console.WriteLine("Geçmek İçin Herhangi Bir Tuşa Basınız ..."); Console.ReadKey(); cihazTamirMenu();
            }
            else
            {
                arizaBulma:
                int ariza = rnd.Next(0, 5); 
                int ariza2 = rnd.Next(0, 5);
                if(ariza == ariza2)
                {
                    goto arizaBulma;
                }
                else
                {
                    telefonTamirUcreti = tamirFiyatlari[ariza] + tamirFiyatlari[ariza2];
                    Console.WriteLine($"Telefonunuzdaki Arızalar : {telefonParcalari[ariza]} Ve {telefonParcalari[ariza2]} Bozuk \nTamir Ücreti : {telefonTamirUcreti} TL");
                    Console.WriteLine("Geçmek İçin Herhangi Bir Tuşa Basınız ..."); Console.ReadKey(); cihazTamirMenu();
                }
            }
        }

        public void arizaTamir()
        {
            Console.Clear();
            if(telefonTamirUcreti == 0)
            {
                Console.WriteLine("Lütfen İlk Önce Cihazınızı Kontrol Ettirin !");
                Console.WriteLine("Geçmek İçin Herhangi Bir Tuşa Basınız ..."); Console.ReadKey(); cihazTamirMenu();
            }

            else
            {
                Console.WriteLine($"Telefonunuzun Tamir Fiyatı : {telefonTamirUcreti} TL \nTelefonunuzu Tamir Ettirmek İstiyormusunuz ? (E , H)");
                ConsoleKeyInfo telefonTamirOnay = Console.ReadKey();
                if (telefonTamirOnay.Key == ConsoleKey.E)
                {
                    if (telefonTamirUcreti <= bakiye)
                    {
                        bakiye -= telefonTamirUcreti;
                        int saniye = 5;
                        while (saniye > 0)
                        {
                            Console.Clear();
                            Console.WriteLine($"Telefonunuz Tamir Ediliyor... Lütfen Bekleyiniz ! | {saniye} sn.");
                            Thread.Sleep(1000);
                            saniye--;
                        }
                        telefonTamirUcreti = 0;
                        Console.WriteLine("Telefonunuz Tamir Edildi");
                        Console.WriteLine("Geçmek İçin Herhangi Bir Tuşa Basınız ..."); Console.ReadKey(); cihazTamirMenu();
                    }
                    else
                    {
                        Console.Clear();
                        Console.WriteLine($"Malesef Bakiyeniz Yetmiyor !\nTelefonunuzu Tamir Ettirmek İçin Bakiye Yatırmalısınız \nTamir Ettirmek İçin Yatırmanız Gereken Miktar : {telefonTamirUcreti - bakiye} TL");
                        Console.WriteLine("Geçmek İçin Herhangi Bir Tuşa Basınız ..."); Console.ReadKey(); cihazTamirMenu();
                    }
                }
                else
                {
                    Console.Clear();
                    Console.WriteLine("Telefon Tamir İşlemi İptal Edildi !");
                    Console.WriteLine("Geçmek İçin Herhangi Bir Tuşa Basınız ..."); Console.ReadKey(); cihazTamirMenu();
                }
            }
        }


        public void cihazSatis()
        {
            int saniye = 5;
            while (saniye > 0)
            {
                Console.Clear();
                Console.WriteLine($"Telefonunuz Kontrol Ediliyor... Lütfen Bekleyiniz ! | {saniye} sn.");
                Thread.Sleep(1000);
                saniye--;
            }
            Console.Clear();

            Random rnd = new Random();
            int satisFiyati = rnd.Next(7500, 15000);

            Console.WriteLine($"Telefonunuza Verilen Miktar {satisFiyati} TL'dir \nTelefonunuzu Satmak İstiyormusunuz ? (E , H)");
            ConsoleKeyInfo telefonSatisOnay = Console.ReadKey();
            if (telefonSatisOnay.Key == ConsoleKey.E)
            {
                Console.Clear();
                Console.WriteLine("Telefonunuz Satıldı !");
                bakiye += satisFiyati;
                Console.WriteLine("Geçmek İçin Herhangi Bir Tuşa Basınız ..."); Console.ReadKey(); telefonMenu();
            }
            else
            {
                Console.WriteLine("Telefon Satış İşlemi İptal Edildi !");
                Console.WriteLine("Geçmek İçin Herhangi Bir Tuşa Basınız ..."); Console.ReadKey(); telefonMenu();
            }
        }
    }

    class Bilgisayar : TeknikServis
    {
        int[] tamirFiyatlari = new int[5];
        int bilgisayarTamirUcreti;


        public void bilgisayarMenu()
        {
        telefonMenuGiris:
            Console.Clear();
            Console.WriteLine("--------- Bilgisayar Hizmeti ---------");
            Console.WriteLine("Lütfen Hizmet Seçiniz...");
            Console.WriteLine("1 - Bilgisayar Tamiri \n2 - Bilgisayar Satışı \n3 - Bakiye Göster \n4 - Bakiye Yatır \n5 - Bakiye Çek \n6 - Ana Menü");
            ConsoleKeyInfo anaMenuSecim = Console.ReadKey();

            switch (anaMenuSecim.Key)
            {
                case ConsoleKey.D1:
                case ConsoleKey.NumPad1:
                    cihazTamirMenu();
                    break;

                case ConsoleKey.D2:
                case ConsoleKey.NumPad2:
                    cihazSatis();
                    break;

                case ConsoleKey.D3:
                case ConsoleKey.NumPad3:
                    bakiyeGoster();
                    break;

                case ConsoleKey.D4:
                case ConsoleKey.NumPad4:
                    bakiyeYatir();
                    break;

                case ConsoleKey.D5:
                case ConsoleKey.NumPad5:
                    bakiyeCek();
                    break;

                case ConsoleKey.D6:
                case ConsoleKey.NumPad6:
                    anaMenu();
                    break;

                default:
                    Thread.Sleep(750);
                    Console.WriteLine("Lütfen Doğru Şekilde Seçim Yapınız !");
                    goto telefonMenuGiris;
            }
        }


        public void cihazTamirMenu()
        {
            cihazTamirMenu:
            Console.Clear();
            Console.WriteLine("--------- Bilgisayar Tamir Menüsü ---------");
            Console.WriteLine("Yapacağınız İşlemi Seçiniz");
            Console.WriteLine("1 - Arıza Tespit \n2 - Arıza Tamiri\n3 - Bilgisayar Menü \n4 - Ana Menü");
            ConsoleKeyInfo telefonMenuSecim = Console.ReadKey();

            switch (telefonMenuSecim.Key)
            {
                case ConsoleKey.D1:
                case ConsoleKey.NumPad1:
                    arizaTespit();
                    break;

                case ConsoleKey.D2:
                case ConsoleKey.NumPad2:
                    arizaTamir();
                    break;

                case ConsoleKey.D3:
                case ConsoleKey.NumPad3:
                    bilgisayarMenu();
                    break;

                case ConsoleKey.D4:
                case ConsoleKey.NumPad4:
                    anaMenu();
                    break;

                default:
                    Thread.Sleep(750);
                    Console.WriteLine("Lütfen Doğru Şekilde Seçim Yapınız !");
                    goto cihazTamirMenu;
            }
        }


        public void bakiyeGoster()
        {
            Console.Clear();
            Console.WriteLine($"Bakiyeniz : {bakiye} TL");
            Console.WriteLine("Geçmek İçin Herhangi Bir Tuşa Basınız ..."); Console.ReadKey(); bilgisayarMenu();
        }

        public void bakiyeYatir()
        {
            bakiyeYatirGiris:
            Console.Clear();
            int miktar;
            Console.Write("Yatırmak İstediğiniz Miktar ? : ");
            try
            {
                miktar = Convert.ToInt32(Console.ReadLine());
            }
            catch
            {
                Console.WriteLine("Lütfen Doğru Şekilde Giriş Yapınız !");
                Console.WriteLine("Geçmek İçin Herhangi Bir Tuşa Basınız ..."); Console.ReadKey(); goto bakiyeYatirGiris;
            }
            if (miktar > 0)
            {
                bakiye += miktar;
                Console.WriteLine($"\nParanız Yatırıldı \nYeni Bakiyeniz : {bakiye} TL");
                Console.WriteLine("Geçmek İçin Herhangi Bir Tuşa Basınız ..."); Console.ReadKey(); bilgisayarMenu();
            }
            else
            {
                Console.WriteLine("\nLütfen Doğru Şekilde Para Yatırınız !");
                Console.WriteLine("Geçmek İçin Herhangi Bir Tuşa Basınız ..."); Console.ReadKey(); goto bakiyeYatirGiris;
            }
        }

        public void bakiyeCek()
        {
            bakiyeCekGiris:
            Console.Clear();
            int miktar;
            Console.Write("Çekmek İstediğiniz Miktar ? : ");
            try
            {
                miktar = Convert.ToInt32(Console.ReadLine());
            }
            catch
            {
                Console.WriteLine("\nLütfen Doğru Şekilde Giriş Yapınız !");
                Console.WriteLine("Geçmek İçin Herhangi Bir Tuşa Basınız ..."); Console.ReadKey(); goto bakiyeCekGiris;
            }
            if (miktar > 0)
            {
                if (bakiye >= miktar)
                {
                    bakiye -= miktar;
                    Console.WriteLine($"\nParanız Çekildi \nYeni Bakiyeniz : {bakiye} TL");
                    Console.WriteLine("Geçmek İçin Herhangi Bir Tuşa Basınız ..."); Console.ReadKey(); bilgisayarMenu();
                }
                else
                {
                    Console.WriteLine("Malesef Çekmek İstediğniz Miktar Bakiyenizden Büyük !");
                    Console.WriteLine("Geçmek İçin Herhangi Bir Tuşa Basınız ..."); Console.ReadKey(); bilgisayarMenu();
                }
            }
            else
            {
                Console.WriteLine("Lütfen Doğru Şekilde Para Çekiniz !");
                Console.WriteLine("Geçmek İçin Herhangi Bir Tuşa Basınız ..."); Console.ReadKey(); goto bakiyeCekGiris;
            }
        }

        public void arizaTespit()
        {
            Console.Clear();
            Random rnd = new Random();
            for (int i = 0; i <= 4; i++)
            {
                tamirFiyatlari[i] = rnd.Next(500, 2500);
            }
            int arizaOlasilik = rnd.Next(1, 5);
            if (arizaOlasilik <= 3)
            {
                int ariza = rnd.Next(0, 5);
                bilgisayarTamirUcreti = tamirFiyatlari[ariza];
                Console.WriteLine($"Bilgisayarınızdaki Arıza : {bilgisayarParcalari[ariza]} Bozuk \nTamir Ücreti : {bilgisayarTamirUcreti} TL");
                Console.WriteLine("Geçmek İçin Herhangi Bir Tuşa Basınız ..."); Console.ReadKey(); cihazTamirMenu();
            }
            else
            {
                arizaBulma:
                int ariza = rnd.Next(0, 5);
                int ariza2 = rnd.Next(0, 5);
                if (ariza == ariza2)
                {
                    goto arizaBulma;
                }
                else
                {
                    bilgisayarTamirUcreti = tamirFiyatlari[ariza] + tamirFiyatlari[ariza2];
                    Console.WriteLine($"Bilgisayarınızdaki Arızalar : {bilgisayarParcalari[ariza]} Ve {bilgisayarParcalari[ariza2]} Bozuk \nTamir Ücreti : {bilgisayarTamirUcreti} TL");
                    Console.WriteLine("Geçmek İçin Herhangi Bir Tuşa Basınız ..."); Console.ReadKey(); cihazTamirMenu();
                }
            }
        }

        public void arizaTamir()
        {
            Console.Clear();
            if (bilgisayarTamirUcreti == 0)
            {
                Console.WriteLine("Lütfen İlk Önce Cihazınızı Kontrol Ettirin !");
                Console.WriteLine("Geçmek İçin Herhangi Bir Tuşa Basınız ..."); Console.ReadKey(); cihazTamirMenu();
            }

            else
            {
                Console.WriteLine($"Bilgisayarınızın Tamir Fiyatı : {bilgisayarTamirUcreti} TL \nBilgisayarınızı Tamir Ettirmek İstiyormusunuz ? (E , H)");
                ConsoleKeyInfo telefonTamirOnay = Console.ReadKey();
                if (telefonTamirOnay.Key == ConsoleKey.E)
                {
                    if (bilgisayarTamirUcreti <= bakiye)
                    {
                        bakiye -= bilgisayarTamirUcreti;
                        int saniye = 5;
                        while (saniye > 0)
                        {
                            Console.Clear();
                            Console.WriteLine($"Bilgisayarınız Tamir Ediliyor... Lütfen Bekleyiniz ! | {saniye} sn.");
                            Thread.Sleep(1000);
                            saniye--;
                        }
                        bilgisayarTamirUcreti = 0;
                        Console.WriteLine("Bilgisayarınız Tamir Edildi");
                        Console.WriteLine("Geçmek İçin Herhangi Bir Tuşa Basınız ..."); Console.ReadKey(); cihazTamirMenu();
                    }
                    else
                    {
                        Console.Clear();
                        Console.WriteLine($"Malesef Bakiyeniz Yetmiyor !\nBilgisayarınızı Tamir Ettirmek İçin Bakiye Yatırmalısınız \nTamir Ettirmek İçin Yatırmanız Gereken Miktar : {bilgisayarTamirUcreti - bakiye} TL");
                        Console.WriteLine("Geçmek İçin Herhangi Bir Tuşa Basınız ..."); Console.ReadKey(); cihazTamirMenu();
                    }
                }
                else
                {
                    Console.Clear();
                    Console.WriteLine("Bilgisayar Tamir İşlemi İptal Edildi !");
                    Console.WriteLine("Geçmek İçin Herhangi Bir Tuşa Basınız ..."); Console.ReadKey(); cihazTamirMenu();
                }
            }
        }


        public void cihazSatis()
        {
            int saniye = 5;
            while (saniye > 0)
            {
                Console.Clear();
                Console.WriteLine($"Bilgisayarınız Kontrol Ediliyor... Lütfen Bekleyiniz ! | {saniye} sn.");
                Thread.Sleep(1000);
                saniye--;
            }
            Console.Clear();

            Random rnd = new Random();
            int satisFiyati = rnd.Next(15000, 25000);

            Console.WriteLine($"Bilgisayarınıza Verilen Miktar {satisFiyati} TL'dir \nBilgisayarınızı Satmak İstiyormusunuz ? (E , H)");
            ConsoleKeyInfo bilgisayarSatisOnay = Console.ReadKey();
            if (bilgisayarSatisOnay.Key == ConsoleKey.E)
            {
                Console.Clear();
                Console.WriteLine("Bilgisayarınız Satıldı !");
                bakiye += satisFiyati;
                Console.WriteLine("Geçmek İçin Herhangi Bir Tuşa Basınız ..."); Console.ReadKey(); bilgisayarMenu();
            }
            else
            {
                Console.WriteLine("Bilgisayarınızın Satış İşlemi İptal Edildi !");
                Console.WriteLine("Geçmek İçin Herhangi Bir Tuşa Basınız ..."); Console.ReadKey(); bilgisayarMenu();
            }
        }
    }

    internal class Program
    {
        static void Main(string[] args)
        {
            TeknikServis servis = new TeknikServis();
            servis.anaMenu();
        }
    }
}
