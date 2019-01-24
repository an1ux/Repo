using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ProjectControl.ModelsViews
{
    public class UserTable
    {
        public int Id { get; set; }

        public DateTime StartDate { get; set; }

        public DateTime AssignedDate { get; set; }

        public string TimeStart { get { return AssignedDate > StartDate ? "Started" : "Not Yet"; } set { TimeStart = value; } }

        public DateTime EndDate { get; set; }

        public DateTime Credits { get; set; }

        public bool IsActive { get; set; }

        public string IsActiveLabel { get { return IsActive == true ? "Active" : "Inactive"; } set { IsActiveLabel = value; } }
    }
}