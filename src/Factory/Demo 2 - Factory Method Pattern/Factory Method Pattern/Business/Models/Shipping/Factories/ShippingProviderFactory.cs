namespace Factory_Method_Pattern.Business.Models.Shipping.Factories
{
    public abstract class ShippingProviderFactory
    {
        public abstract ShippingProvider CreateShippingProvider(string country);

        public ShippingProvider GetShippingProvider(string country)
        {
            var provider = CreateShippingProvider(country);

            /*
             * Example of why you should create a separate GetShippingProvider method
             * instead of using just the CreateShippingProvider
             *
             * if(country == "Sweden" &&
             *     provider.InsuranceOptions.ProviderHasInsurance)
             * {
             *     provider.RequireSignature = false;
             * }
             *
             * Basically, change something before it is returned to the caller.
             */

            return provider;
        }
    }
}