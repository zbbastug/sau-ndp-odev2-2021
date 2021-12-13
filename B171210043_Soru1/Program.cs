/****************************************************************************
**					SAKARYA ÜNİVERSİTESİ
**				BİLGİSAYAR VE BİLİŞİM BİLİMLERİ FAKÜLTESİ
**				    BİLGİSAYAR MÜHENDİSLİĞİ BÖLÜMÜ
**				   NESNEYE DAYALI PROGRAMLAMA DERSİ
**					2020-2021 BAHAR DÖNEMİ
**	
**				ÖDEV NUMARASI..........: 1.ÖDEV 1.SORU
**				ÖĞRENCİ ADI............: ZEYNEP BURCU BAŞTUĞ    
**				ÖĞRENCİ NUMARASI.......: B171210043
**              DERSİN ALINDIĞI GRUP...: A
****************************************************************************/

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace B171210043_Soru1
{
    class Program
    {
        
        static void CizimTahtasi(int[,] tahta)
        {
            //8x8lik bir matris formunda tahta cizme islemi, ilk for dongusu satir, ikinci for dongusu sutunu olusturur.
            for (int i = 0; i < 8; i++)
            {
                for (int j = 0; j < 8; j++)
                {
                    Console.Write(tahta[i, j] + " ");
                }
                Console.Write("\n");
            }
        }
        static Boolean KontrolDurumu(int[,] tahta, int satir, int sutun)
        {
            /*1. En soldaki sütundan başlayın.  2.Tüm kraliçeler yerleştirilmişse. true dön.
            3.Geçerli sütundaki tüm satırları deneyin. Denenen her satır için takip edin.*/
            int i, j;
            for (i = 0; i < sutun; i++)
            {
                if (tahta[satir, i] == 1) return false;
            }
            for (i = satir, j = sutun; i >= 0 && j >= 0; i--, j--)
            {
                if (tahta[i, j] == 1) return false;
            }
            for (i = satir, j = sutun; j >= 0 && i < 8; i++, j--)
            {
                if (tahta[i, j] == 1) return false;
            }
            return true;
        }
        /*
              
 a. Kraliçe bu sıraya güvenli bir şekilde yerleştirilebilirse,
 bu [sıra, sütun] 'u çözümün bir parçası olarak işaretleyin ve kraliçeyi buraya yerleştirmenin
 bir çözüme yol açıp açmadığını tekrar tekrar kontrol edin.
 b. Veziri [satır, sütun] 'a yerleştirmek bir çözüme götürürse o zaman doğruya dönün.
 c. Vezir yerleştirmek bir çözüme yol açmazsa, bunu [satır, sütun] (Geri izleme) işaretleyin
 ve diğer satırları denemek için (a) adımına gidin
      */
        static Boolean CozumAsamasi(int[,] tahta, int sutun)
        {
            if (sutun >= 8) return true;
            for (int i = 0; i < 8; i++)
            {
                if (KontrolDurumu(tahta, i, sutun))
                {
                    tahta[i, sutun] = 1;
                    if (CozumAsamasi(tahta, sutun + 1)) return true;  
                    tahta[i, sutun] = 0;
                }
            }
            return false;
        }
        static void Main(string[] args)
        {
           
            int[,] tahta = new int[8, 8];
            if (!CozumAsamasi(tahta, 0))
            {
                Console.WriteLine("Cozum bulunamadi.");
            }
            CizimTahtasi(tahta);
            Console.ReadLine();
        }
    }
}
