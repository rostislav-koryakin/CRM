using CRM.Core.Entities;
using System.Collections.Generic;

namespace CRM.Web.ViewModels
{
    public class SalesmanViewModel
    {
        public Salesman Salesman { get; set; }

        public IEnumerable<Activity> Activities { get; set; }

        public IEnumerable<Deal> Deals { get; set; }
    }
}
