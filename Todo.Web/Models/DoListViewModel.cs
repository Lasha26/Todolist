using System;
using System.Collections.Generic;
using System.Linq;
using Todo.Domain.Enums;
using Todo.Domain.Entities;

namespace Todo.Web.Models
{
    public class DoListViewModel
    {

        public IEnumerable<Do> DO { get; set; }
        public PagingInfo PagingInfo { get; set; }

        public Statuses? CurrentStatus { get; set; }
        public Priorities? CurrentPriority { get; set; }
        public Do Event { get; }

        public List<ActionViewModel> Actions { get {
                return Enum.GetValues(typeof(Actions))
                              .Cast<Actions>()
                              .Select(v => new ActionViewModel { Action = v, GroupLabel = v.ToString() })
                              .ToList();
            } }
    }
}