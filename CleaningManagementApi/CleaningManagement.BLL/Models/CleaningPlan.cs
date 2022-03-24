using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CleaningManagement.BLL.Models
{
    public class CleaningPlan
    {
        public Guid Id { get; set; }
        public string Title { get; set; }
        public int CustomerId { get; set; }
        public string Description { get; set; }
        public DateTime CreatedAt { get; set; }
    }
}
