using System;
using static Opportunity.Model;

namespace Opportunity
{
    public static class Helper
    {

        #region Genel Return Classım
        public class OptinalClass// Genel İşlemler Return için Classım
        {
            public string OptinalClass_msg { get; set; }
            public bool OptinalClass_val { get; set; }
            public bool OptinalClass_optional_Val { get; set; }
            public string OptinalClass_optional_Msg { get; set; }
            public int OptinalClass_ID { get; set; }
            public string OptinalClass_IDs { get; set; }
            public int OptinalClass_optional_ID { get; set; }
            public string OptinalClass_optional_IDs { get; set; }
        }
        #endregion


        #region Rover için Input Girilen Bilgilerin Tipe Göre Kontrolleri
        public static OptinalClass BasicValidControl(string val, ParamType param)
        {
            OptinalClass _OptinalClass = new OptinalClass();

            try
            {
                switch (param)
                {
                    case ParamType.Limit:
                        if (!int.TryParse(val, out int tmp))
                        {
                            _OptinalClass.OptinalClass_msg = "Limit Error";
                            _OptinalClass.OptinalClass_val = false;
                        }
                        else if (Convert.ToInt32(val) <= 0)
                        {
                            _OptinalClass.OptinalClass_msg = "Limit Error";
                            _OptinalClass.OptinalClass_val = false;
                        }
                        else
                        {
                            _OptinalClass.OptinalClass_val = true;
                        }
                        break;
                    case ParamType.Position:
                        if (!int.TryParse(val, out int _tmp))
                        {
                            _OptinalClass.OptinalClass_msg = "Position Error";
                            _OptinalClass.OptinalClass_val = false;
                        }
                        else if (Convert.ToInt32(val) <= 0)
                        {
                            _OptinalClass.OptinalClass_msg = "Position Error";
                            _OptinalClass.OptinalClass_val = false;
                        }
                        else
                        {
                            _OptinalClass.OptinalClass_val = true;
                        }
                        break;
                    case ParamType.Direction:
                        string[] Directions = { "R", "L", "M" };
                        _OptinalClass.OptinalClass_msg = "Direction Error";
                        _OptinalClass.OptinalClass_val = false;
                        foreach (string item in Directions)
                        {

                            if (val.Contains(item))
                            {
                                _OptinalClass.OptinalClass_val = true;
                            }
                        }

                        break;
                    case ParamType.Compas:
                        string[] Compas = { "N", "E", "S", "W" };
                        _OptinalClass.OptinalClass_msg = "Direction Error";
                        _OptinalClass.OptinalClass_val = false;
                        foreach (string item in Compas)
                        {

                            if (val.Contains(item))
                            {
                                _OptinalClass.OptinalClass_val = true;
                            }
                        }

                        break;
                    default:
                        _OptinalClass.OptinalClass_val = true;
                        break;
                }
            }
            catch (System.Exception ex)
            {
                _OptinalClass.OptinalClass_optional_Msg = "Hata!: " + ex.Message;
                _OptinalClass.OptinalClass_val = false;
            }


            return _OptinalClass;
        }
        #endregion
        #region Console Uygulaması Başlangıç Ekranı
        public static string StartText()
        {

            return @"
  _____   ______      ________ _____                        
 |  __ \ / __ \ \    / /  ____|  __ \                       
 | |__) | |  | \ \  / /| |__  | |__) |                      
 |  _  /| |  | |\ \/ / |  __| |  _  /                       
 | | \ \| |__| | \  /  | |____| | \ \                       
 |_|__\_\\____/   \/   |______|_|  \_\          _ _         
  / __ \                       | |             (_) |        
 | |  | |_ __  _ __   ___  _ __| |_ _   _ _ __  _| |_ _   _ 
 | |  | | '_ \| '_ \ / _ \| '__| __| | | | '_ \| | __| | | |
 | |__| | |_) | |_) | (_) | |  | |_| |_| | | | | | |_| |_| |
  \____/| .__/| .__/ \___/|_|   \__|\__,_|_| |_|_|\__|\__, |
        | |   | |                                      __/ |
        |_|   |_|                                     |___/ 
                                                                     
 __ __   ____  _         __  ____  ____        _____  ____  __ __   ____   _____
|  T  T /    T| T       /  ]l    j|    \      / ___/ /    T|  T  | /    T / ___/
|  |  |Y  o  || |      /  /  |  T |  _  Y    (   \_ Y  o  ||  |  |Y  o  |(   \_ 
|  ~  ||     || l___  /  /   |  | |  |  |     \__  T|     ||  |  ||     | \__  T
l___, ||  _  ||     T/   \_  |  | |  |  |     /  \ ||  _  |l  :  !|  _  | /  \ |
|     !|  |  ||     |\     | j  l |  |  |     \    ||  |  | \   / |  |  | \    |
l____/ l__j__jl_____j \____j|____jl__j__j      \___jl__j__j  \_/  l__j__j  \___j
                                                                                

";

        }
        #endregion
    }
}
