using Abstract_Factory_Pattern.Business.Models.Commerce;
using Abstract_Factory_Pattern.Business.Models.Commerce.Invoice;
using Abstract_Factory_Pattern.Business.Models.Commerce.Summary;
using Abstract_Factory_Pattern.Business.Models.Shipping;
using Abstract_Factory_Pattern.Business.Models.Shipping.Factories;

namespace Abstract_Factory_Pattern.Business.PurchaseProviderFactories
{
    public class AustraliaPurchaseProviderFactory : IPurchaseProviderFactory
    {
        public ShippingProvider CreateShippingProvider(Order order)
        {
            var shippingProviderFactory = new StandardShippingProviderFactory();

            return shippingProviderFactory.CreateShippingProvider(order.Sender.Country);
        }

        public IInvoice CreateInvoice(Order order)
        {
            return new GSTInvoice();
        }

        public ISummary CreateSummary(Order order)
        {
            return new CsvSummary();
        }
    }
}