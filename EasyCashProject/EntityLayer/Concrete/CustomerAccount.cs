using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityLayer.Concrete
{//hesap
    public class CustomerAccount
    {
        public int CustomerAccountId { get; set; }

        public string? CustomerAccountNumber { get; set; }

        public string? CustomerAccountCurrency { get; set;}

        public decimal? CustomerAccountBalance { get; set; }
            
        public string? BankBranch { get; set; }

        public int? AppUserId { get; set; }

        public AppUser Appuser { get; set; }
        
        public List<CustomerAccountProcess> CustomerSender { get; set; }

        public List<CustomerAccountProcess> CustomerReceiver { get; set; }


    }
}
