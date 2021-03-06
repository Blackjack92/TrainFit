﻿using SQLite;

namespace TrainFit.Models
{
    [Table("Exercises")]
    public class Exercise : ModelBase
    {
        #region fields
        private string name;
        private Difficulty difficulty;
        private string url;
        private string description;
        private ExerciseType exerciseType;
        #endregion

        #region properties
        public string Name { get { return name; } set { SetProperty(ref name, value); } }
        public Difficulty Difficulty { get { return difficulty; } set { SetProperty(ref difficulty, value); } }
        public string Url { get { return url; } set { SetProperty(ref url, value); } }
        public string Description { get { return description; } set { SetProperty(ref description, value); } }
        public ExerciseType ExerciseType { get { return exerciseType; } set { SetProperty(ref exerciseType, value); } }
        #endregion

        #region ctor
        public Exercise()
        { }
        #endregion
    }
}
