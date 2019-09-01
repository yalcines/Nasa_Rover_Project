using System;
using System.Runtime.InteropServices;
using static Opportunity.Helper;

namespace Opportunity
{
    internal class Program
    {
        #region Console uygulaması Tam Ekran imports
        [DllImport("kernel32.dll", ExactSpelling = true)]
        private static extern IntPtr GetConsoleWindow();
        private static readonly IntPtr ThisConsole = GetConsoleWindow();

        [DllImport("user32.dll", CharSet = CharSet.Auto, SetLastError = true)]
        private static extern bool ShowWindow(IntPtr hWnd, int nCmdShow);
        private const int HIDE = 0;
        private const int MAXIMIZE = 3;
        private const int MINIMIZE = 6;
        private const int RESTORE = 9;
        #endregion
        private static void Main(string[] args)
        {
            #region Console Tam Ekran
            Console.SetWindowSize(Console.LargestWindowWidth, Console.LargestWindowHeight);
            ShowWindow(ThisConsole, MAXIMIZE);
            #endregion


            string Limit = "";
            string Positon = "";
            string MoveToMap = "";
            string tmp = "";
            Console.Write(Helper.StartText());// Başlangıç Yazısı
            OptinalClass _OptinalClass = new OptinalClass();
            Console.Write(@"The possible letters are 'L', 'R' and 'M'. 'L' and 'R' makes the rover spin 90 degrees left or right respectively, without moving from its current spot.'M' means move forward one grid point, and maintain the same heading.Compas NESW");// Rover için gerekli açıklama.

            #region Roverın Bulunduğu Plota için; X ve Y düzleminde Limit Bilgilerinin Girişi
            Console.Write("\n");
            Console.Write("\n");
            Console.Write("\n");
            Console.Write("Rover Area Limits X: ");
            Console.Write("\n");

            do
            {
                tmp = Console.ReadLine().ToUpper();// Plota düzleminde X için Limit 
                _OptinalClass = BasicValidControl(tmp, Model.ParamType.Limit);// Helper dan tipe göre kontrol
                Console.Write(_OptinalClass.OptinalClass_val ? ("Rover Area Limits Y: ") : (_OptinalClass.OptinalClass_msg + "- Again Rover Area Limits X: "));
            } while (!_OptinalClass.OptinalClass_val);// Hata var ise Tekrar Giriş Sağlansın
            Limit += tmp;
            Console.Write("\n");
            #endregion

            #region Rover Başlangıç Konumu için; X ve Y Bilgilerinin Girişi
            do
            {
                tmp = Console.ReadLine().ToUpper().Trim();// Plota düzleminde Y için Limit 
                _OptinalClass = BasicValidControl(tmp, Model.ParamType.Limit);// Helper dan tipe göre kontrol
                Console.Write(_OptinalClass.OptinalClass_val ? ("Rover Positon X: ") : (_OptinalClass.OptinalClass_msg + "- Again Rover Area Limits Y: "));
            } while (!_OptinalClass.OptinalClass_val);// Hata var ise Tekrar Giriş Sağlansın
            Limit += " " + tmp;
            Console.Write("\n");
            do
            {
                tmp = Console.ReadLine().ToUpper().Trim();// Plota düzleminde Roverın X için Konumu
                _OptinalClass = BasicValidControl(tmp, Model.ParamType.Position);// Helper dan tipe göre kontrol
                Console.Write(_OptinalClass.OptinalClass_val ? ("Rover Positon Y: ") : (_OptinalClass.OptinalClass_msg + "- Again Rover Positon X: "));
            } while (!_OptinalClass.OptinalClass_val);// Hata var ise Tekrar Giriş Sağlansın
            Positon += tmp;
            Console.Write("\n");
            #endregion

            #region Rover Başlangıç Konumu için; Pusulaya Göre Yön Bilgisinin Girişi (NESW)
            do
            {
                tmp = Console.ReadLine().ToUpper().Trim();// Plota düzleminde Roverın Y için Konumu
                _OptinalClass = BasicValidControl(tmp, Model.ParamType.Position);// Helper dan tipe göre kontrol
                Console.Write(_OptinalClass.OptinalClass_val ? ("Rover Positon Compas: ") : (_OptinalClass.OptinalClass_msg + "- Again Rover Positon Y: "));
            } while (!_OptinalClass.OptinalClass_val);// Hata var ise Tekrar Giriş Sağlansın
            Positon += " " + tmp;
            Console.Write("\n");
            #endregion

            #region Rover için; Değiştireceği Yön ve Hareket Bilgisinin Girişi (LRM)
            do
            {
                tmp = Console.ReadLine().ToUpper().Trim();// Plota düzleminde Roverın Yönü
                _OptinalClass = BasicValidControl(tmp, Model.ParamType.Compas);// Helper dan tipe göre kontrol
                Console.Write(_OptinalClass.OptinalClass_val ? ("Rover MoveToMap: ") : (_OptinalClass.OptinalClass_msg + "- Again Rover Positon Compas: "));
            } while (!_OptinalClass.OptinalClass_val);// Hata var ise Tekrar Giriş Sağlansın
            Positon += " " + tmp;
            Console.Write("\n");
            #endregion

            #region Rover'ın Plotada; X,Y Düzlemi Üzerindeki Son Pozisyonu(X,Y,Compas Bilgisi)
            do
            {
                tmp = Console.ReadLine().ToUpper().Trim();// Plota düzleminde Hareket edeceği Roverın Yönü ve Hareket Bilgisi
                _OptinalClass = BasicValidControl(tmp, Model.ParamType.Direction);// Helper dan tipe göre kontrol
                Console.Write(_OptinalClass.OptinalClass_val ? ("Rover Last Position: ") : (_OptinalClass.OptinalClass_msg + "- Again Rover MoveToMap: "));
            } while (!_OptinalClass.OptinalClass_val);// Hata var ise Tekrar Giriş Sağlansın
            MoveToMap += tmp;
            #endregion

            Service _Service = new Service();
            _OptinalClass = new OptinalClass();
            _OptinalClass = (_Service.displayToConsole(Limit + "@" + Positon + "@" + MoveToMap)); // Servis'e parametreleri vererek,Rover son konumunu alıyorum.

            if (!_OptinalClass.OptinalClass_val) // Servisten dönen değerde eğer hata var ise;
            {
                Console.Write(_OptinalClass.OptinalClass_optional_Msg);
                Console.ReadLine();
            }
            else // Servisten dönen değerde eğer hata yok ise;
            {
                Console.Write(_OptinalClass.OptinalClass_msg);
                Console.ReadLine();
            }
        }
    }
}
