using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;
using Todo.Domain.Enums;

namespace Todo.Web.Models
{
    public class ActionViewModel
    {
        public Actions Action { get; set; }
        public string GroupLabel { get; set; }
        public List<SelectListItem> ListItems
        {
            get
            {
                switch (Action)
                {
                    case Actions.Status:
                        return GenerateEnumList<Statuses>();
                    case Actions.Priority:
                        return GenerateEnumList<Priorities>();
                    case Actions.Delete:
                        return new List<SelectListItem> {
                            new SelectListItem {
                                Text = "Delete",
                                Value = string.Empty
                            }
                        };
                    default:
                        return null;
                }
            }
        }

        private static List<SelectListItem> GenerateEnumList<T>()
        {
            return Enum.GetValues(typeof(T))
                   .Cast<T>()
                   .Select(v => new SelectListItem { Text = v.ToString(), Value = (Convert.ToInt32(v)).ToString() })
                   .ToList();
        }
    }
}