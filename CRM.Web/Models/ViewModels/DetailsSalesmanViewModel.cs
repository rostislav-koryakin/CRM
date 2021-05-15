using CRM.Web.Models.Entities;
using System.Collections.Generic;

namespace CRM.Web.Models.ViewModels
{
    public class DetailsSalesmanViewModel
    {
        public Salesman Salesman { get; set; }

        public IEnumerable<Activity> Activities { get; set; }

        public IEnumerable<Deal> Deals { get; set; }
    }
}
