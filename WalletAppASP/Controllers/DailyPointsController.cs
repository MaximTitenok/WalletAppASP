using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WalletAppASP.Controllers;
using WalletAppASP.Models;

namespace WalletAppASP.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class DailyPointsController : Controller
    {
        private readonly ILogger<DailyPointsController> _logger;

        public DailyPointsController(ILogger<DailyPointsController> logger)
        {
            _logger = logger;
        }
        [HttpGet]
        public ActionResult<int> GetDailyPoints()
        {
            return CalculationPoints.CalculatePoints(DateTime.Now);
        }
    }
}
