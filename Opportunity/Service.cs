using System;
using System.Linq;
using static Opportunity.Helper;

namespace Opportunity
{
    public class Service
    {
        public OptinalClass displayToConsole(string RoverMoveToMapPos)
        {
            OptinalClass _OptinalClass = new OptinalClass(); // Genel Return Class

            try
            {
                string[] input = RoverMoveToMapPos.Split(new[] { '@' }); // Gelen Bilgileri Burada Arraya Alıyorum.

                int[] bounds = input[0].Split(new[] { ' ' }).Select(i => int.Parse(i)).ToArray();// Plota X ve Y Limiti
                string CompasDirections = "NESW"; // Pusula Yönleri

                #region  Düzlem için X ve Y Aralık Tanımları
                MatrisAreaPoint[] Positions = new MatrisAreaPoint[4];
                Positions[0] = new MatrisAreaPoint(0, 1);
                Positions[1] = new MatrisAreaPoint(1, 0);
                Positions[2] = new MatrisAreaPoint(0, -1);
                Positions[3] = new MatrisAreaPoint(-1, 0);
                #endregion


                #region Matris Düzlemi olarak düşünürsek , X ve Y için Bir Array Şablonu Oluşturuyorum
                Tuple<int, int>[] ArrayLst = new[] { Tuple.Create(Positions[0].X, Positions[0].Y), Tuple.Create(Positions[1].X, Positions[1].Y), Tuple.Create(Positions[2].X, Positions[2].Y), Tuple.Create(Positions[3].X, Positions[3].Y) };
                #endregion

                for (int i = 1; i < input.Length; i += 2)
                {
                    #region Roverın Başlangışta;Plota düzlemindeki, X ile Y Bilgisi ve Yönü
                    string[] start = input[i].Split(new[] { ' ' });
                    int x = int.Parse(start[0]);// Başlangıç X Bilgisi
                    int y = int.Parse(start[1]);// Başlangıç Y Bilgisi
                    int moveDirection = CompasDirections.IndexOf(start[2]); //Başlangıç Yönü
                    #endregion

                    foreach (char position in input[i + 1])
                    {
                        switch (position)
                        {
                            case 'L': // Yön ve Hareket Bilgisi L için 90 derece sola dön
                                moveDirection = (--moveDirection + ArrayLst.Length) % ArrayLst.Length;
                                break;
                            case 'R': // Yön ve Hareket Bilgisi L için 90 derece sağ dön
                                moveDirection = ++moveDirection % ArrayLst.Length;
                                break;
                            default:  // Yön ve Hareket Bilgisi M ise; Yöne Göre X veya Y de Hareket Et
                                x = Math.Min(bounds[0], Math.Max(0, x + ArrayLst[moveDirection].Item1));
                                y = Math.Min(bounds[1], Math.Max(0, y + ArrayLst[moveDirection].Item2));
                                break;
                        }
                    }
                    _OptinalClass.OptinalClass_msg += (x + " " + y + " " + CompasDirections[moveDirection]);// Roverın Plotadaki Düzlemde Son Konumu
                }
                _OptinalClass.OptinalClass_val = true;
            }
            catch (Exception ex)
            {
                _OptinalClass.OptinalClass_val = false;
                _OptinalClass.OptinalClass_optional_Msg = "Hata!: " + ex.Message;// Hata Mesajı
            }
            return _OptinalClass;
        }
    }
}
