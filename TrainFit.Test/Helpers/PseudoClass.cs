﻿using SQLite;
using System;
using TrainFit.Models;

namespace TrainFit.Test.Helpers
{
    [Table("Exercises")]
    internal class PseudoClass : ModelBase
    {
        #region properties
        public Uri Source1 { get; internal set; }
        public Uri Source2 { get; internal set; }
        public Uri Source3 { get; internal set; }
        #endregion
    }
}
