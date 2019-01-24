using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using ProjectControl;
using ProjectControl.ModelsViews;

namespace ProjectControl.Controllers
{
    public class UserProjectsController : Controller
    {
        private ProjectsContext db = new ProjectsContext();

        // GET: UserProjects
        // Get all the information about the Users
        public ActionResult Index()
        {
            var listUsersDB = db.EndUsers.ToList();
            var listUsers = listUsersDB.Select(p => new EndUser { Id = p.Id, FirstName = p.FirstName, LastName = p.LastName }).ToList();
            var modelView = new ModelView
            {
                ListUsers = listUsers.Select(p => new SelectListItem { Value = p.Id.ToString(), Text = p.FirstName +" "+ p.LastName })
            };
            modelView.UserProjectResult = new List<UserTable>();
            return View(modelView);
        }

        
        //Returns the data to fill the table
        [AcceptVerbs(HttpVerbs.Get)]
        public PartialViewResult GetUserProject(int id)
        {            
            var userProjects = db.UserProjects.Where(m=>m.UserId == id).Include(y => y.Project).ToList();
            var listUserTable = userProjects.Select(p => new UserTable { Id = p.Project.Id, StartDate = p.Project.StartDate, EndDate = p.Project.EndDate, Credits = p.Project.Credits, AssignedDate = p.AssignedDate, IsActive = p.IsActive});            
            var modelView = new ModelView{UserProjectResult = listUserTable.ToList()};
            return PartialView("PartialTable", modelView);
        }        
    }
}
