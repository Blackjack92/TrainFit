namespace TrainFit.Models
{
    public interface IStoreable
    {
        #region properties
        bool IsStored { get; set; }

        bool IsUpdated { get; set; }
        #endregion
    }
}
