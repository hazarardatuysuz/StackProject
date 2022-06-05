using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO; //txtyi çekmek için

namespace BasicStackProject
{

    class Yigin
    {
        int[] yigin; // yığını tutar
        int ind; // yıgının indeksi kontrol gibi bi şey mesela yıgına bi şey eklediğime indeksi arttırıcak
        // boş bir stack yapılandırdık
        public Yigin(int boyut)// int boyut döndürüyo yıgını oluşturma kodu
        {
            yigin = new int[boyut];// yıgın olusturuyo yıgına her bir eleman eklediğimde indisi 1 arttırır
            ind = 0;//ilk indeksi 0
        }
        //yıgına veri yükleme metodu
        public void Push(int sayi)
        {
            if (ind == yigin.Length) // yıgının boyutu 5 mesela bu ifin içindede 5 olursa dolu mesajı veriyo
            {
                Console.WriteLine("Yığın doldu.");
                return;
            }
            yigin[ind] = sayi;// girdiğimiz sayı yıgının herhangi bir indeksi olabilir bunu her sayı girdiğimizde arttırıyoruz
            ind++;
        }
        //yıgından veri çıkartma metodu
        public int Pop() // burda sayılar eklenmiş oluyor ve yıgının son elemanını çıkarıyor neyi çıkardıgını biliyor pc
        {
            if (ind == 0)//indisimiz kontrolümüzdü ilk önce indis 0 dır yukarda eleman eklemiştik indis 1 oldu eğer sayı eklemezsek veya sayıların hepsini çıkarıtrsak 0 da kalır bu da boş oldugunu gösterir
            {
                Console.WriteLine("Yığın boş"); //indis 0 sa boş
                return 0;
            }
            ind--;///boş değilse azaltıyo
            return yigin[ind];// 5 den 4 e döndürüyo mesela yukarda okuması için
        }
        //yığın dolu ise true döndür
        public bool IsFull()
        {
            return ind == yigin.Length;//yıgının uzunlugu 1 den başlar 
            // yıgının uzunlugu 5 indisimiz de beş yani yıgın dolu o zaman true döndürür
        }
        //yığın boş ise true döndür
        public bool IsEmpty() //is empty kapasite demek
        {
            return ind == 0; // indis  sa boş onu döndürür
        }
        //yığının kapasitesinin döndürür
        public int Kapasite()
        {
            return yigin.Length; // kapasite yıgının o anki uzunluğu
            // mesela normalde yıgının uzunlugu 5 bu yıgından 2 eleman çıkarırsak uzunluk 3 olur  bu fonkisiyon o zaman 3 döndürür
        }
        public int GetNesne()//yıgında kaç kişi kaldıgını döndürür
        {
            return ind; // o an indisin kaçsa indisin sayısını döndürür, yıgındaki nesnelerin sayısını döndürür
        }
        static void Main(string[] args)// txt de yazıları çekmek için parçalamamız lazım parçaladıgımız her şeye değişkenlere atmamız lazım çünkü hepsini alamıyoruz değişkenleri birleşitiriyoruz
        {
            string str;
            Console.WriteLine("Dosya adı giriniz: ");
            str = Console.ReadLine();//metinden txt çekmek için bu kullanıcı tarafından giriliyor buraya metin veya metin 2 falan yaıcaz
            // str=... üstteki satırda string oldugu için
            FileStream fin = new FileStream(str, FileMode.Open);//metin.txtyi girdik mesela bu komut dosyayı açıyor str de metin var metin.txtyi açıyo
            StreamReader fstr_in = new StreamReader(fin);//okumasıyla yani üst satırla bağıntılı bu dosyayı okumak
            int i, a, b;// int i demek metin.txt de mesela partiye kaç kişi katılcak i partide kaç kişi oldugunu söyler
            // yani i demek 
            //4 burdaki dört i demek tam sayı oldugunda parçalamaya gerek yok(burda 4 den sonra virgüllü bi şey yok null orası ondan parçalama)
            //0 1
            //1 2
            //3 2
            //4 2
            string temp;
            string[] tokens;//parçaladıgımda kullanıcaz (1 2) mesela tokensin 0.elemanı 1 1.elemanı 2 

            temp = fstr_in.ReadLine();//bu okuma komutu okudu 4 parçalanmaz bnuu tempe at (fstr_in.... bu ilk satırı okumak demek bunu tempe atıyoruz parçalanmıyo
            i = int.Parse(temp);// okudugumuz hep string bunu inte çeviriyoruz )4 temp tempde string stringi inte çevirmmek için bunu yaptık i ye atadık
            int[,] matris = new int[i, i];//4x4 lük matris oluşturucaz i =4 olursa
            while ((temp = fstr_in.ReadLine()) != null)//burada 
            {
                tokens = temp.Split();//tempi parçalıyo okudugum değerler string okudugum değerleri int yapmak için yani başka türdeki değişkenlere atamak için 
                //splitde 4ü okudu aşağoıya indi 0 1 templer 0 1 i gösteriyo 0 1 i parçalıyo 1 2 oluyo bunu da tokensa atıyo 
                a = int.Parse(tokens[0]);// 0.elemanı 1 yani a 1
                b = int.Parse(tokens[1]);//1.elemanı 2 yani b 2
                matris[a, b] = 1;//tanıdıgını göstermek için 1 koyuyo
            }
            int temp2 = 0;
            for (int j = 0; j < i; j++)//0. elemanı 1 1. elemanı 2 1 ve 2 yi yerine koyuyor j satır k sütun i de 4
            {
                for (int k = 0; k < i; k++)
                {
                    if (matris[k, j] == 1)// k j yi tanıyorsa tempsi 1 arttır
                        temp2++;
                }
            }
            Yigin ygn1 = new Yigin(i);//yıgını oluşturuyoruz
            int sayi, sayi1;
            int s;//s yi for da kullanmak için tanımladık
            //!ygn1.Dolu(): dolu metodunu cagırır ve yıgın dolu degilse false döndürür
            for (s = 0; !ygn1.IsFull(); s++)//yıgın 4 olana kadar döndür demek
            {
                ygn1.Push(s);//partide 4 kişi varsa 0 dan 4 e kadar kişileri ekliyor
            }
            while (ygn1.GetNesne() != 1)//yıgının içinde 1 kişi kalana kadar çıkartıcak
            {
                sayi = ygn1.Pop();//sayi yıgından çıkarttıgım ilk kişi 0 1 2 3 (4 kişilik) 3 ü çıkartıyoruz 3 sayi oluyo
                sayi1 = ygn1.Pop();//yıgından 2. çıkarttıgım kişi 2 de sayı1 olur
                if (matris[sayi, sayi1] == 0)// 3 2 yi tanımıyorsa,2 ünlü olamaz
                {
                    ygn1.Push(sayi);//3 2 yi tanımıyosa 2 ünlü olamaz ama 3 ünlü olabişliro yüzden yıgına tekrar ekliyoruz 3ü
                }
                else
                {
                    ygn1.Push(sayi1);// 3 2 yi tanıyor demektir o zaman 2 ünlü olabileceği içiin yıgına 2 yi eklio
                }
            }
            int unlukontrol = 0;//ünlü değilse 1 ünlü ise 0
            if (ygn1.GetNesne() == 1)//yıgınımın içinde bir eleman varsa
            {
                int unluindis;
                unluindis = ygn1.Pop();//yıgının içindeki en elemanı çıkarıyor
                int e, v;
                for (e = unluindis; e < (unluindis + 1); e++)//kontrolü burada yapıyo unluindis+1 yapmamızın neden bi kez çalışsın
                                                             //e ye neden unlu indis diyoruz mesela yıgında sadece 3 kaldı o zaman for 3 den başlıcak
                {
                    for (v = 0; v < i; v++)// e satır v sutun ünlü 3. satırdaysa 3 0 ,3 1, 3 1,3 3 kontrol etcez
                    {
                        if (matris[e, v] == 1)// e v yi tanıyo
                        {
                            unlukontrol = 1;
                        }

                    }
                }
                if (unlukontrol == 0)//partide unlu kiş var
                {
                    Console.WriteLine("Partide ünlü kişi vardır.Ünlü kişi" + unluindis + "numaralı kişidir.");
                }
                else
                {
                    Console.WriteLine("Partide ünlü kişi yoktur.");
                }
            }
            Console.ReadKey();


        }
    }
}
