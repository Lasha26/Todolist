using System.ComponentModel.DataAnnotations;

namespace Todo.Domain.Enums
{
    public enum Statuses
    {
        [Display(Name = "In Progress")]
        InProgress = 1,
        [Display(Name = "Completed")]
        Completed = 2
    }    
}
