using Abstract_Factory_Pattern.Business.Models.Commerce;
using Abstract_Factory_Pattern.Business.Models.Commerce.Invoice;
using Abstract_Factory_Pattern.Business.Models.Commerce.Summary;
using Abstract_Factory_Pattern.Business.Models.Shipping;
using Abstract_Factory_Pattern.Business.Models.Shipping.Factories;

namespace Abstract_Factory_Pattern.Business.PurchaseProviderFactories
{
    public class SwedenPurchaseProviderFactory : IPurchaseProviderFactory
    {
        public ShippingProvider CreateShippingProvider(Order order)
        {
            ShippingProviderFactory shippingProviderFactory;

            if (order.Sender.Country != order.Recipient.Country)
            {
                shippingProviderFactory = new GlobalExpressShippingProviderFactory();
            }
            else
            {
                shippingProviderFactory = new StandardShippingProviderFactory();
            }

            return shippingProviderFactory.GetShippingProvider(order.Sender.Country);
        }

        public IInvoice CreateInvoice(Order order)
        {
            if (order.Recipient.Country != order.Sender.Country)
            {
                return new NoVATInvoice();
            }

            return new VATInvoice();
        }

        public ISummary CreateSummary(Order order)
        {
            return new EmailSummary();
        }
    }
}