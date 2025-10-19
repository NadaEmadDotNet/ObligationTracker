using ExpensesTracker.Models;
using ExpensesTracker.Models.Services;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace ExpensesTracker.Controllers
{
    public class ObligationController : Controller
    {
        public readonly IObligationService _service;
        private readonly UserManager<ApplicationUser> userManager; //دي بتتيح ليا الخصاؤص اللي تخص اليوزر والمثودز
        private readonly SignInManager<ApplicationUser> signInManager;
        public ObligationController(IObligationService service, SignInManager<ApplicationUser> signInManager, UserManager<ApplicationUser> userManager)
        {
            _service = service;
            this.userManager = userManager;
            this.signInManager = signInManager;

        }
   
        [HttpGet]
        public async Task<IActionResult> ShowAllObligations()
        {
            var user = await userManager.GetUserAsync(User);
            if (user == null)
            {
                return RedirectToAction("Login", "Account"); 
            }

            var ob = _service.GetAll()
                             .Where(o => o.userId == user.Id) 
                             .ToList();
            ViewBag.TotalAmount = ob.Sum(o => o.Amount);
            ViewBag.TotalPaid = ob.Sum(o => o.PaidAmount);
            ViewBag.TotalRemaining = ViewBag.TotalAmount - ViewBag.TotalPaid;

            return View(ob);

        }

        [HttpGet]
        public IActionResult AddObligation()
        {
            return View();
        }
        [HttpPost]

        [HttpPost]
        public async Task<IActionResult> SaveAddObligation(Obligation model)
        {
            model.userId = userManager.GetUserId(User);

            if (ModelState.IsValid)
            {
                _service.Add(model);
                _service.Save(); 
                return RedirectToAction("ShowAllObligations");
            }

            foreach (var state in ModelState)
            {
                foreach (var error in state.Value.Errors)
                {
                    Console.WriteLine($"Field: {state.Key}, Error: {error.ErrorMessage}");
                }
            }

            return View("AddObligation", model);
        }



        [HttpPost]
        public IActionResult DeleteObligation(int id)
        {
            _service.Delete(id);
            _service.Save();
            return RedirectToAction("ShowAllObligations");
        }
        [HttpGet]
        public IActionResult EditObligation(int id)
        {
            var obj = _service.GetAll().FirstOrDefault(o => o.Id == id);
            if (obj == null)
                return NotFound();
            return View(obj);
        }

        [HttpPost]
        public IActionResult SaveEditObligation(Obligation obligation)
        {
            if (ModelState.IsValid)
            { 
            _service.Update(obligation);
                _service.Save();
                return RedirectToAction("ShowAllObligations", "Obligation");
            }
            return View ("EditObligation", obligation); 
        }
    }
}
