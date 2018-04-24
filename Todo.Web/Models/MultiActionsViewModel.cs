using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Todo.Domain.Entities;

namespace Todo.Web.Models
{
    public class MultiActionsViewModel
    {
        public Actions Action { get; set; }
        public int Value { get; set; }
        public List<int> Ids { get; set; } 
    }
}