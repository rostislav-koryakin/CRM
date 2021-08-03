using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using CRM.Web.Models.Entities;
using CRM.Web.Data;
using CRM.Web.Services;
using CRM.Web.Models.ViewModels;

namespace CRM.Web.Controllers
{
    public class ActivitiesController : Controller
    {
        private readonly AppDbContext _context;
        private readonly IActivitiesService _activitiesService;

        public ActivitiesController(AppDbContext context, IActivitiesService activitiesService)
        {
            _context = context;
            _activitiesService = activitiesService;
        }

        // GET: Activities
        public async Task<IActionResult> Index(string sortOrder, string searchString, string currentFilter, int? pageNumber)
        {
            ViewData["CurrentSort"] = sortOrder;
            ViewData["NameSortParm"] = String.IsNullOrEmpty(sortOrder) ? "name_desc" : "";
            ViewData["TypeSortParm"] = sortOrder == "Type" ? "type_desc" : "Type";
            ViewData["StartDateSortParm"] = sortOrder == "StartDate" ? "start_date_desc" : "StartDate";
            ViewData["EndDateSortParm"] = sortOrder == "EndDate" ? "end_date_desc" : "EndDate";
            ViewData["ContactSortParm"] = sortOrder == "Contact" ? "contact_desc" : "Contact";
            ViewData["SalesmanSortParm"] = sortOrder == "Salesman" ? "salesman_desc" : "Salesman";

            if (searchString != null)
            {
                pageNumber = 1;
            }
            else
            {
                searchString = currentFilter;
            }

            ViewData["CurrentFilter"] = searchString;

            var activities = await _activitiesService.GetPaginatedList(sortOrder, searchString, currentFilter, pageNumber);

            return View(activities);
        }

        // GET: Activities/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return View("NotFound");
            }

            var activity = await _activitiesService.GetById(id);

            if (activity == null)
            {
                return View("NotFound");
            }

            return View(activity);
        }

        // GET: Activities/Create
        public IActionResult Create()
        {
            ViewData["ContactId"] = new SelectList(_context.Contacts, "Id", "Email");
            ViewData["SalesmanId"] = new SelectList(_context.Salesmen, "Id", "Email");
            
            return View();
        }

        // POST: Activities/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Name,Description,StartDate,EndDate,Type,ContactId,SalesmanId,Id,CreatedDate,UpdatedDate")] FormActivityViewModel activityViewModel)
        {
            if (!ModelState.IsValid)
            {
                return View();
            }

            Activity activity = new Activity
            {
                Name = activityViewModel.Name,
                Description = activityViewModel.Description,
                Type = (Activity.ActivityType)activityViewModel.Type,
                StartDate = activityViewModel.StartDate,
                EndDate = activityViewModel.EndDate,
                ContactId = activityViewModel.ContactId,
                SalesmanId = activityViewModel.SalesmanId
            };

            var successful = await _activitiesService.Create(activity);

            if (!successful)
            {
                return View("NotFound");
            }

            ViewData["ContactId"] = new SelectList(_context.Contacts, "Id", "Email", activity.ContactId);
            ViewData["SalesmanId"] = new SelectList(_context.Salesmen, "Id", "Email", activity.SalesmanId);

            return RedirectToAction(nameof(Index));
        }

        // GET: Activities/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return View("NotFound");
            }

            var activity = await _activitiesService.GetById(id);

            if (activity == null)
            {
                return View("NotFound");
            }
            
            ViewData["ContactId"] = new SelectList(_context.Contacts, "Id", "Email", activity.ContactId);
            ViewData["SalesmanId"] = new SelectList(_context.Salesmen, "Id", "Email", activity.SalesmanId);

            FormActivityViewModel activityViewModel = new FormActivityViewModel 
            {
                Id = activity.Id,
                Name = activity.Name,
                Description = activity.Description,
                Type = (FormActivityViewModel.ActivityType)activity.Type,
                StartDate = activity.StartDate,
                EndDate = activity.EndDate,
                ContactId = activity.ContactId,
                SalesmanId = activity.SalesmanId,
                CreatedDate = activity.CreatedDate,
                UpdatedDate = activity.UpdatedDate
            };

            return View(activityViewModel);
        }

        // POST: Activities/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Name,Description,StartDate,EndDate,Type,ContactId,SalesmanId,Id,CreatedDate,UpdatedDate")] FormActivityViewModel activityViewModel)
        {
            if (id != activityViewModel.Id)
            {
                return View("NotFound");
            }

            Activity activity = new Activity
            {
                Id = activityViewModel.Id,
                Name = activityViewModel.Name,
                Description = activityViewModel.Description,
                Type = (Activity.ActivityType)activityViewModel.Type,
                StartDate = activityViewModel.StartDate,
                EndDate = activityViewModel.EndDate,
                ContactId = activityViewModel.ContactId,
                SalesmanId = activityViewModel.SalesmanId,
                CreatedDate = activityViewModel.CreatedDate,
                UpdatedDate = activityViewModel.UpdatedDate
            };

            if (ModelState.IsValid)
            {
                try
                {
                    var result = await _activitiesService.Update(activity);

                    if (result == false)
                    {
                        return View("NotFound");
                    }
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!(await _activitiesService.Exists(activity.Id)))
                    {
                        return View("NotFound");
                    }
                }

                return RedirectToAction(nameof(Index));
            }

            ViewData["ContactId"] = new SelectList(_context.Contacts, "Id", "Email", activity.ContactId);
            ViewData["SalesmanId"] = new SelectList(_context.Salesmen, "Id", "Email", activity.SalesmanId);
            
            return View(activityViewModel);
        }

        // GET: Activities/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return View("NotFound");
            }

            var activity = await _activitiesService.GetById(id);

            if (activity == null)
            {
                return View("NotFound");
            }

            return View(activity);
        }

        // POST: Activities/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int? id)
        {
            if (id == null)
            {
                return View("NotFound");
            }

            var result = await _activitiesService.Delete(id);

            if (result == false)
            {
                return View("NotFound");
            }

            return RedirectToAction(nameof(Index));
        }
    }
}