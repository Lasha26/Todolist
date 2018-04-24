using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Todo.Domain.Abstract;
using Todo.Domain.Entities;
using Todo.Web.Models;

namespace Todo.Web.Controllers
{
    public class NavController : Controller
    {
        private IDoRepository repository;

        public NavController(IDoRepository repo)
        {
            repository = repo;
        }
        public PartialViewResult Menu(Statuses? status, Priorities? priority, string option, string search)
        {
            ViewBag.SelectedStatus = status;
            ViewBag.SelectedPriority = priority;

            var statuses = Enum.GetValues(typeof(Statuses)).Cast<Statuses>().Select(m => new SelectListItem()
            {
                Text = m.ToString(),
                Value = ((int)m).ToString(),
                Selected = m == status
            });
            var priorities = Enum.GetValues(typeof(Priorities)).Cast<Priorities>().Select(m => new SelectListItem()
            {
                Text = m.ToString(),
                Value = ((int)m).ToString(),
                Selected = m == priority
            });
            

            return PartialView(new EnumsViewModel
            {
                Statuses = statuses,
                Priorities = priorities,
                Option = option,
                Search = search
            });
        }
    }
}