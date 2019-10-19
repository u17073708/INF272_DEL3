using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace INF272_Project.ViewModels
{
    public class UserList
    {
        string Name;
        string Urgency;
        string HelpRequired;
        string Disaster;

        public string Name1
        {
            get
            {
                return Name;
            }

            set
            {
                Name = value;
            }
        }

        public string Urgency1
        {
            get
            {
                return Urgency;
            }

            set
            {
                Urgency = value;
            }
        }

        public string Disaster1
        {
            get
            {
                return Disaster;
            }

            set
            {
                Disaster = value;
            }
        }

        public string HelpRequired1
        {
            get
            {
                return HelpRequired;
            }

            set
            {
                HelpRequired = value;
            }
        }
    }
}