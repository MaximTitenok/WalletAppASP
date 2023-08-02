using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WalletAppASP.Controllers;
using WalletAppASP.Models;
using WalletAppASP.Services;
using WalletAppASP.Services.Interfaces;

namespace WalletAppASP.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class DailyPointsController : Controller
    {
        private readonly ILogger<DailyPointsController> _logger;
        private readonly ICalculationPoints _calculationPoints;

        public DailyPointsController(ILogger<DailyPointsController> logger, ICalculationPoints calculationPoints)
        {
            _logger = logger;
            _calculationPoints = calculationPoints;
        }
        [HttpGet]
        public ActionResult<int> GetDailyPoints()
        {
            return _calculationPoints.CalculatePoints(DateTime.Now);
        }
    }
}
