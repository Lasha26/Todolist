using System.Collections.Generic;
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

       
    }
}