using SQLite;

namespace TrainFit.Models
{
    [Table("Users")]
    public class User : ModelBase
    {
        #region fields
        private string name;
        #endregion

        #region properties
        public string Name 
        {
            get
            {
                return name;
            } 
            set 
            {
                SetProperty(ref name, value);
            } 
        }
        #endregion
    }
}
