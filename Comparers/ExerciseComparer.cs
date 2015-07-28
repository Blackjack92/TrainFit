﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TrainFit.Models;

namespace TrainFit.Comparers
{
    public class ExerciseComparer : EqualityComparer<Exercise>
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
        public override bool Equals(Exercise expectedExercise, Exercise actualExercise)
        {
            return ComparerHelper.InstancePropertiesAreEqual<Exercise>(expectedExercise, actualExercise);
        }

        public override int GetHashCode(Exercise obj)
        {
            return obj == null ? 0 : obj.GetHashCode();
        }
        #endregion
    }
}