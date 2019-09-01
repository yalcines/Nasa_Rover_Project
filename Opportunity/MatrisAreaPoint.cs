namespace Opportunity
{
    public class MatrisAreaPoint
    {
        #region Plota düzlemi için sağlamam Gereken X ve Y Tiplerinin Tanımları
        public int X;
        public int Y;

        public MatrisAreaPoint(int _X, int _Y) 
        {
            X = _X;
            Y = _Y;
        }
        public MatrisAreaPoint RoverPosition { get; set; } 
        #endregion

    }
}
