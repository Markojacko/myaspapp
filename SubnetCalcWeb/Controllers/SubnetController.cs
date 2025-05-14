using Microsoft.AspNetCore.Mvc;               // MVC base types
using SubnetCalcWeb.Models;                   // your SubnetRequest & SubnetResult
using SubnetCalcWeb.Services;                 // your ISubnetCalculator

namespace SubnetCalcWeb.Controllers          // MUST match your project + folder
{
    public class SubnetController : Controller   // Controller comes from AspNetCore.Mvc
    {
        private readonly ISubnetCalculator _calculator;

        public SubnetController(ISubnetCalculator calculator)
        {
            _calculator = calculator;
        }

        [HttpGet]
        public IActionResult Index()
        {
            return View(new SubnetRequest());
        }

        [HttpPost]
        public IActionResult Index(SubnetRequest req)
        {
            if (!ModelState.IsValid)
                return View(req);

            var result = _calculator.Calculate(req.IpAddress, req.PrefixLength);
            return View("Result", result);
        }
    }
}
