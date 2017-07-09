using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ThreeDPayment.Models
{
    public class CreditCardModel
    {
        public string HolderName { get; set; }
        public string CardNumber { get; set; }
        public string ExpireMonth { get; set; }
        public string ExpireYear { get; set; }
        public string CV2 { get; set; }
    }
}