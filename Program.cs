using Newtonsoft.Json;
using Stripe;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StripeTestbench
{
    class Program
    {
        static void Main(string[] args)
        {
            StripeConfiguration.ApiKey = "sk_test_XkvAeMDMkmENwnuctwQxesT3";

            //InvoiceService invoiceService = new InvoiceService();
            //Invoice invoice = invoiceService.Get("in_1ET2FYIH9mcFLxLz31AUOYQF");
            //string invoiceSerialized = JsonConvert.SerializeObject(invoice);

            //ChargeService stripeChargeService = new ChargeService();
            //Charge stripeCharge = stripeChargeService.Get(invoice.ChargeId);
            //string chargeSerialized = JsonConvert.SerializeObject(stripeCharge);

            CustomerService customerService = new CustomerService();
            Customer customer = customerService.Get("cus_GXpkRhKeV60Bzr");

            Subscription subscription = customer.Subscriptions.First();

            string paymentMethodId = subscription.DefaultPaymentMethodId;
            //CustomerUpdateOptions customerUpdateOptions = new CustomerUpdateOptions()
            //{
            //    InvoiceSettings = new CustomerInvoiceSettingsOptions()
            //    {
            //        DefaultPaymentMethod = paymentMethodId
            //    },
            //};
            //customerService.Update(customer.Id, customerUpdateOptions);


            //PaymentMethodAttachOptions paymentMethodAttachOptions = new PaymentMethodAttachOptions()
            //{
            //    Customer = customer.Id
            //};

            //var service = new PaymentMethodService();
            //service.Attach(paymentMethodId, paymentMethodAttachOptions);


            InvoiceService invoiceService = new InvoiceService();

            //InvoiceItemCreateOptions invoiceItemCreateOptions = new InvoiceItemCreateOptions
            //{
            //    Customer = customer.Id,
            //    Amount = 10000,
            //    Currency = "eur",
            //    Description = "Testing invoice payment",
            //};

            //InvoiceItemService invoiceItemService = new InvoiceItemService();
            //invoiceItemService.Create(invoiceItemCreateOptions);

            //InvoiceCreateOptions invoiceCreateOptions = new InvoiceCreateOptions
            //{
            //    Customer = customer.Id,
            //    AutoAdvance = true,
            //};
            //Invoice prorateInvoice = invoiceService.Create(invoiceCreateOptions);
            //invoiceService.FinalizeInvoice("in_1G0l5CIH9mcFLxLzAYcq1h4m");


            Invoice invoice = invoiceService.Get("in_1G0lh0IH9mcFLxLzGQrSg264");

            PaymentIntentConfirmOptions paymentIntentConfirmOptions = new PaymentIntentConfirmOptions()
            {
                PaymentMethod = paymentMethodId,
            };
            PaymentIntentService paymentIntentService = new PaymentIntentService();
            paymentIntentService.Confirm(invoice.PaymentIntentId, paymentIntentConfirmOptions);

            string s = "" + ""; 
        }
    }
}
 