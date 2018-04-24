using System.Collections.Generic;
using Todo.Domain.Entities;

namespace Todo.Domain.Abstract
{
    public interface IDoRepository
    {
        //IEnumerable<Do> DO { get; }
        IEnumerable<Do> GetDoList(Statuses? status,Priorities? priority, string option, string search, int page, int pageSize);
        int TotalCount(Statuses? status, Priorities? priority, string option, string search);     
        bool RemoveFromList(int id);
        Do GetById(int id);
        bool SaveDo(Do result);
        Do GetByEvent(string even);
        bool MultiDelete(IEnumerable<int> ids);
        bool ChangeStatus(IEnumerable<int> ids, Statuses status);
        bool ChangePriority(IEnumerable<int> ids, Priorities priority);

    }
}
