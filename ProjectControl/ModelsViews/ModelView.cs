using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ProjectControl.ModelsViews
{
    //Model that unify data needed to be displayed in the view
    public class ModelView
    {
        public IEnumerable<SelectListItem> ListUsers { get; set; }        
        public List<UserTable> UserProjectResult { get; set; }
    }
}