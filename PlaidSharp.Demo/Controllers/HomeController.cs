using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using PlaidSharp.Demo.Models;
using PlaidSharp.Demo.Plaid;
using PlaidSharp.Exceptions;
using System;
using System.Diagnostics;
using System.Threading.Tasks;

namespace PlaidSharp.Demo.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly IPlaidService _plaidService;

        public HomeController(ILogger<HomeController> logger, IPlaidService plaidService)
        {
            _plaidService = plaidService;
            _logger = logger;
        }

        public IActionResult Index()
        {
            return View(new PlaidIndexViewModel
            {
                PlaidEnv = "sandbox",
                PlaidProducts = "transactions",
                PlaidPublicKey = _plaidService.PlaidClient.PublicKey
            });
        }

        [HttpPost("get_access_token")]
        public async Task<IActionResult> GetAccessToken(string public_token)
        {
            try
            {
                var res = await _plaidService.PlaidClient.ExchangePublicToken(public_token);
                _plaidService.AccessToken = res.AccessToken;
                return Json(new { access_token = res.AccessToken, item_id = res.ItemId });
            }
            catch (PlaidException ex)
            {
                _logger.LogError(ex, $"Error in the PlaidClient: {ex.PlaidError.ErrorCode}");
                return Json(new { error = ex.PlaidError });
            }
        }

        [HttpPost("set_access_token")]
        public async Task<IActionResult> SetAccessToken(string access_token)
        {
            _plaidService.AccessToken = access_token;
            var res = await _plaidService.PlaidClient.GetItem(_plaidService.AccessToken);

            return Json(new { item_id = res.Item.ItemId });
        }

        [HttpGet("transactions")]
        public async Task<IActionResult> Transactions()
        {
            try
            {
                var res = await _plaidService.PlaidClient.GetTransactions(_plaidService.AccessToken, DateTime.Now.AddMonths(-2), DateTime.Now, count: 250, offset: 0);
                return Json(new { Transactions = res });
            }
            catch (PlaidException ex)
            {
                _logger.LogError(ex, $"Error in the PlaidClient: {ex.PlaidError.ErrorCode}");
                return Json(new { error = ex.PlaidError });
            }
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
