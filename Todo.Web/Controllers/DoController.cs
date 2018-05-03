using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Todo.Domain.Enums;
using Todo.Domain.Abstract;
using Todo.Web.Models;
using System.Threading.Tasks;
using Todo.Web.Infrastructure;
using Todo.Domain.Repository;
using Todo.Domain.Entities;

namespace Todo.Web.Controllers
{
    [RoutePrefix("Do")]
    public class DoController : Controller
    {
        private IDoRepository repository;
        public int PageSize = 8;

        public DoController(IDoRepository doRepository)
        {
            this.repository = doRepository;
        }

        public ActionResult Details(int Id)
        {
            var result = repository.GetById(Id);
            return View(result);
        }

        public ActionResult Remove(int Id)
        {
            var result = repository.RemoveFromList(Id);
            if (!result)
                TempData["Error"] = "არ წაიშალა";
            return RedirectToAction("List");
        }

        [HttpPost]
        public ActionResult DeleteMulti(MultiActionsViewModel model)
        {
            bool Result;
            switch (model.Action)
            {
                case Actions.Status:
                    //TODO: Change status
                    Result = repository.ChangeStatus(model.Ids, (Statuses)model.Value);
                    break;
                case Actions.Priority:
                    //TODO Change priority
                    Result = repository.ChangePriority(model.Ids, (Priorities)model.Value);
                    break;
                case Actions.Delete:
                    Result = repository.MultiDelete(model.Ids);
                    break;
                default:
                    Result = false;
                    break;
            }

            if (!Result)
                TempData["Error"] = "You did not select any event";
            return JavaScript("location.reload(true)");
        }

        public ActionResult Edit(int Id)
        {
            var result = repository.GetById(Id);
            return View(result);
        }

        //public ActionResult ActionsList(int Id)

        [HttpPost]
        public ActionResult Edit(Do result)
        {
            if (ModelState.IsValid)
            {
                var isSaved = repository.SaveDo(result);
                if (isSaved)
                {
                    TempData["message"] = $"{result.Event} has been saved";
                    return RedirectToAction("List");
                }
                ModelState.AddModelError("Error", $"{result.Event} has not saved");
            }
            return View(result);
        }

        public ActionResult Empty()
        {
            return View();
        }

        public ActionResult List(Statuses? status, Priorities? priority, string option, string search, int page = 1)
        {
            var doList = repository.GetDoList(status, priority, option, search, page, PageSize);

            DoListViewModel model = new DoListViewModel
            {
                DO = doList,
                PagingInfo = new PagingInfo
                {
                    CurrentPage = page,
                    ItemsPerPage = PageSize,
                    TotalItems = repository.TotalCount(status, priority, option, search)
                },
                CurrentStatus = status,
                CurrentPriority = priority

            };
            return View(model);
        }

        public ViewResult Create()
        {
            return View("Edit", new Do());
        }

        public ViewResult Main()
        {
            return View("List");
        }

        [HttpPost]
        public ActionResult Search(string option, string search)
        {
            DoListViewModel model = new DoListViewModel();
            if (option == "Event")
            {
                return View(model.DO.Where(x => x.Event.Contains(search) || search == null).ToList());
            }
            else
            {
                return View(model.DO.Where(x => x.Description.Contains(search) || search == null).ToList());
            }
            
        }
    }
}



