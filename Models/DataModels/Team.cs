﻿using System.Collections.Generic;

namespace TMP2019.Models.DataModels
{
    public class Team
    {
        public int Id { get; set; }

        public string TeamName { get; set; }


        public ICollection<Person> People { get; set; }
    }
}