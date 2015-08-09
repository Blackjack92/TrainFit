using System.Collections.Generic;
using TrainFit.Models;

namespace TrainFit.Comparers
{
    public class ExerciseComparer : IEqualityComparer<Exercise>
    {
        #region properties
        private string[] ignoredProperties;
        #endregion

        #region ctor
        public ExerciseComparer() : this(new string[]{ "IsUpdated", "IsStored" })
        { }

        public ExerciseComparer(string[] ignoredProperties)
        {
            this.ignoredProperties = ignoredProperties;
        }
        #endregion

        #region methods
        public bool Equals(Exercise expectedExercise, Exercise actualExercise)
        {
            return ComparerHelper.InstancePropertiesAreEqual<Exercise>(expectedExercise, actualExercise);
        }

        public int GetHashCode(Exercise obj)
        {
            return obj == null ? 0 : obj.GetHashCode();
        }
        #endregion
    }
}
