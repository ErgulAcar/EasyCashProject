using BusinessLayer.Abstract;
using DataAccessLayer.Abstract;
using DataAccessLayer.Concrete;
using DtoLayer.DTOs.CustomerAccountProcessDtos;
using EntityLayer.Concrete;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace PresentationLayer.Controllers
{
    public class SendMoneyController : Controller
    {
        private readonly UserManager<AppUser> _userManager;
        private readonly ICustomerAccountService _customerAccountService;

        public SendMoneyController(UserManager<AppUser> userManager, ICustomerAccountService customerAccountService)
        {
            _userManager = userManager;
            _customerAccountService = customerAccountService;
        }

        [HttpGet]
        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Index(SendMoneyForCustomerAccountProcessDto sendMoneyForCustomerAccountProcessDto)
        {
            var user = await _userManager.FindByNameAsync(User.Identity.Name);

            var context = new Context();
            var receiverAccountId = context.customerAccounts
                .Where(c => c.CustomerAccountNumber == sendMoneyForCustomerAccountProcessDto.ReceiverAccountNumber)
                .Select(y=>y.CustomerAccountId).FirstOrDefault();

            sendMoneyForCustomerAccountProcessDto.SenderId = user.Id;
            sendMoneyForCustomerAccountProcessDto.ProcessDate = Convert.ToDateTime(DateTime.Now.ToShortDateString());
            sendMoneyForCustomerAccountProcessDto.ProcessType = "Havale";
            sendMoneyForCustomerAccountProcessDto.ReceiverId = receiverAccountId;

            //_customerAccountService.TInsert();

            return RedirectToAction("Index", "Deneme");
        }
    }
}
