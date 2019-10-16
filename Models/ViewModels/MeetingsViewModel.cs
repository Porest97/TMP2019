using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using TMP2019.Models.DataModels;
using Activity = TMP2019.Models.DataModels.Activity;

namespace TMP2019.Models.ViewModels
{
    public class MeetingsViewModel
    {
        public List<Activity> Activities { get; internal set; }

        public List<PeopleToActivity> PeopleToActivity { get; internal set; }
    }
}
