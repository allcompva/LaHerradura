using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PortalServicios.PayPerTicApi2.Notificacion
{
    public class PaymentMethod
    {
        public double amount { get; set; }
        public double final_amount { get; set; }
        public int media_payment_id { get; set; }
        public string media_payment_detail { get; set; }
        public string pan_token { get; set; }
        public string last_four_digits { get; set; }
        public string first_six_digits { get; set; }
        public int installments { get; set; }
        public string authorization_code { get; set; }
        public Gateway gateway { get; set; }
        public int payment_method_id { get; set; }
    }
}