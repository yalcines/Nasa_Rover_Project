namespace Opportunity
{
    public class Model
    {
        #region Input Girişlerinin Parametre Type Bilgileri
        public ParamType Param { get; set; }
        public enum ParamType
        {
            Limit,
            Position,
            Direction,
            Compas
        } 
        #endregion
    }
}
