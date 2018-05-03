using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Todo.Domain.Enums;


namespace Todo.Domain.Entities
{
    [Table("TO_DO")]
    public class Do
    {
        public Do()
        {
            FillingTime = DateTime.Now;
            EndingTime = DateTime.Now.AddDays(7);
        }
        public int Id { get; set; }
        [Required(ErrorMessage = "Please enter event")]
        public string Event { get; set; }
        [DataType(DataType.MultilineText)]
        [Required(ErrorMessage = "Please enter description")]
        public string Description { get; set; }
        [Column("Filling_Time")]
        public DateTime FillingTime { get; set; }
        [Column("Ending_Time")]
        public DateTime EndingTime { get; set; }
        [EnumDataType(typeof(Priorities))]
        [Required(ErrorMessage = "Please select priority")]
        public Priorities Priority { get; set; }
        [EnumDataType(typeof(Statuses))]
        [Required(ErrorMessage = "Please select status")]
        public Statuses Status { get; set; }
    }
}
