using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TrainFit.Comparers;
using TrainFit.Test.Helpers;

namespace TrainFit.Test.Comparers
{
    internal class PseudoComparer : IEqualityComparer<PseudoClass>
    {
        #region properties
        private string[] ignoredProperties;
        #endregion

        #region ctor
        public PseudoComparer() : this(new string[]{ })
        { }

        public PseudoComparer(string[] ignoredProperties)
        {
            this.ignoredProperties = ignoredProperties;
        }
        #endregion

        #region methods
        public bool Equals(PseudoClass expectedPseudoObj, PseudoClass actualPseudoObj)
        {
            return ComparerHelper.InstancePropertiesAreEqual<PseudoClass>(expectedPseudoObj, actualPseudoObj);
        }

        public int GetHashCode(PseudoClass obj)
        {
            return obj == null ? 0 : obj.GetHashCode();
        }
        #endregion
    }
}
