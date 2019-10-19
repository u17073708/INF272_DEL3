using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace INF272_Project.ViewModels
{
    public class GetHelpVM
    {
        public int UserID { get; set; }
        public Urgency GetHelpUrgency { get; set; }
    }

    public enum Urgency
    {
        High,
        Moderate,
        Low
    }
}