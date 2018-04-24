using System.Collections.Generic;
using System.Web.Mvc;

namespace Todo.Web.Models
{
    public class EnumsViewModel
    {
        public IEnumerable<SelectListItem> Statuses { get; set; }
        public IEnumerable<SelectListItem> Priorities { get; set; }
        public int Page { get; set; } = 1;
        public string Option { get; set; }
        public string Search { get; set; }
       
    }

}