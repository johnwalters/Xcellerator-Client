using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Newtonsoft.Json;

namespace XcelleratorClient
{
    public class CalculationResponse
    {
        [JsonProperty("azn")]
        public AmazonFees AmazonFees { get; set; }

        public Dimensions Dimensions { get; set; }
        public ShipmentAmountSet Duties { get; set; }
        public CurrencyAmount Duty { get; set; }

        [JsonProperty("factory_to_hub")]
        public CostOptions FactoryToHub { get; set; }
        public CurrencyAmount FOB { get; set; }
        public CurrencyAmount RVF { get; set; }
        public string Fulfilment { get; set; }

        [JsonProperty("hub_to_fc")]
        public CurrencyAmount HubToFacility { get; set; }
        public string Id { get; set; }

        [JsonProperty("landed_cost")]
        public ShipmentAmountSet LandedCost { get; set; }

        [JsonProperty("output_currency")]
        public string OutputCurrency { get; set; }

        [JsonProperty("output_measurement")]
        public string OutputMeasurement { get; set; }
        public ShipmentAmountSet POI { get; set; }
        public ShipmentAmountSet POR { get; set; }
        public Product Product { get; set; }
        public ShipmentAmountSet Profit { get; set; }

        [JsonProperty("sales_country")]
        public Country SalesCountry { get; set; }

        [JsonProperty("suggested_sales_price")]
        public ShipmentAmountSetWithBest SuggestedSalesPrice { get; set; }
        public Weight Weight { get; set; }

        [JsonProperty("sales_tax")]
        public SalesTax SalesTax { get; set; }
        public string Error { get; set; }
        public string Solution { get; set; }

        [JsonProperty("remaining_calculations")]
        public int RemainingCalculations { get; set; }

        [JsonIgnore]
        public List<SundryAmount> Sundries { get; set; }

        public SundryAmount SundriesTotal { get; set; }

        public void SetSundries(ParsedSundries sundryData)
        {
            Sundries = new List<SundryAmount>();
            if (sundryData.Data == null) return;
            AddSundryAmountIfNotNull(sundryData.Data.Sundry0);
            AddSundryAmountIfNotNull(sundryData.Data.Sundry1);
            AddSundryAmountIfNotNull(sundryData.Data.Sundry2);
            AddSundryAmountIfNotNull(sundryData.Data.Sundry3);
            AddSundryAmountIfNotNull(sundryData.Data.Sundry4);
            AddSundryAmountIfNotNull(sundryData.Data.Sundry5);
            AddSundryAmountIfNotNull(sundryData.Data.Sundry6);
            AddSundryAmountIfNotNull(sundryData.Data.Sundry7);
            AddSundryAmountIfNotNull(sundryData.Data.Sundry8);
            AddSundryAmountIfNotNull(sundryData.Data.Sundry9);
            AddSundryAmountIfNotNull(sundryData.Data.Sundry10);
            AddSundryAmountIfNotNull(sundryData.Data.Sundry11);
            AddSundryAmountIfNotNull(sundryData.Data.Sundry12);
            AddSundryAmountIfNotNull(sundryData.Data.Sundry13);
            AddSundryAmountIfNotNull(sundryData.Data.Sundry14);
            AddSundryAmountIfNotNull(sundryData.Data.Sundry15);
            AddSundryAmountIfNotNull(sundryData.Data.Sundry16);
            AddSundryAmountIfNotNull(sundryData.Data.Sundry17);
            AddSundryAmountIfNotNull(sundryData.Data.Sundry18);
            AddSundryAmountIfNotNull(sundryData.Data.Sundry19);
            AddSundryAmountIfNotNull(sundryData.Data.Sundry20);

            SundriesTotal = new SundryAmount
            {
                Amount = sundryData.Data.total.Amount,
                Currency = sundryData.Data.total.Currency
            };
        }

        private void AddSundryAmountIfNotNull(XcelleratorClient.SundryAmount sundryAmount)
        {
            if (sundryAmount == null) return;
            var responseSundryAmount = new SundryAmount();
            responseSundryAmount.name = sundryAmount.name;
            responseSundryAmount.Amount = sundryAmount.Amount;
            responseSundryAmount.Currency = sundryAmount.Currency;
            Sundries.Add(responseSundryAmount);
        }

        #region formattedString
        public string ToFormattedString()
        {
            var sb = new StringBuilder();
            sb.Append("Calulations for id:" + this.Id + "\n");
            sb.Append("\n");
            sb.Append("Amazon" + "\n");
            sb.Append("\t " + "Sales Fee " + this.AmazonFees.SalesFee.Currency + " " + this.AmazonFees.SalesFee.Amount);
            sb.Append("\t " + "FBA Fee " + this.AmazonFees.FbaFee.Currency + " " + this.AmazonFees.FbaFee.Amount);
            sb.Append("\t " + "EFN Fee " + this.AmazonFees.EfnFee.Currency + " " + this.AmazonFees.EfnFee.Amount);
            sb.Append("\t " + "Hub to FC " + this.HubToFacility.Currency + " " + this.HubToFacility.Amount);

            sb.Append("\n");
            sb.Append("Dimensions" + "\n");
            sb.Append("\t " + "Length " + this.Dimensions.ProductLength + " " + this.Dimensions.Measurement);
            sb.Append("\t " + "Width " + this.Dimensions.ProductWidth + " " + this.Dimensions.Measurement);
            sb.Append("\t " + "Height " + this.Dimensions.ProductHeight + " " + this.Dimensions.Measurement);
            sb.Append("\t " + "CBM " + this.Dimensions.CBM + "m (cubed)");

            sb.Append("\n");
            sb.Append("Duties" + "\n");
            sb.Append("\t " + "via air " + this.Duties.Air.Currency + " " + this.Duties.Air.Amount);
            sb.Append("\t " + "via sea " + this.Duties.Sea.Currency + " " + this.Duties.Sea.Amount);
            sb.Append("\t " + "via shf " + this.Duties.SuperheroFreight.Currency + " " + this.Duties.SuperheroFreight.Amount);
            sb.Append("\t " + "totals " + this.Duty.Currency + " " + this.Duty.Amount);

            sb.Append("\n");
            sb.Append("\n");
            sb.Append("Factory to Hub Costs (via air)" + "\n");
            //  sb.Append("\t " + "best option " + this.factory_to_hub);//TODO: where is best option facToHubCosts?
            sb.Append("\t " + "option #1 " + this.FactoryToHub.Air.Option0.Name + " " + this.FactoryToHub.Air.Option0.PriceCurrency + " " + this.FactoryToHub.Air.Option0.Price + " " + string.Format("Minimum {0} Unit Order\n", this.FactoryToHub.Air.Option0.RequiredProducts));
            sb.Append("\t " + "option #2 " + this.FactoryToHub.Air.Option1.Name + " " + this.FactoryToHub.Air.Option1.PriceCurrency + " " + this.FactoryToHub.Air.Option1.Price + " " + string.Format("Minimum {0} Unit Order\n", this.FactoryToHub.Air.Option1.RequiredProducts));
            sb.Append("\t " + "option #3 " + this.FactoryToHub.Air.Option2.Name + " " + this.FactoryToHub.Air.Option2.PriceCurrency + " " + this.FactoryToHub.Air.Option2.Price + " " + string.Format("Minimum {0} Unit Order\n", this.FactoryToHub.Air.Option2.RequiredProducts));
            sb.Append("\t " + "option #4 " + this.FactoryToHub.Air.Option3.Name + " " + this.FactoryToHub.Air.Option3.PriceCurrency + " " + this.FactoryToHub.Air.Option3.Price + " " + string.Format("Minimum {0} Unit Order\n", this.FactoryToHub.Air.Option3.RequiredProducts));

            sb.Append("\n");
            sb.Append("Factory to Hub Costs (via sea)" + "\n");
            sb.Append("\t " + "option #1 " + this.FactoryToHub.Sea.Option0.Name + " " + this.FactoryToHub.Sea.Option0.PriceCurrency + " " + this.FactoryToHub.Sea.Option0.Price + " " + string.Format("Minimum {0} Unit Order\n", this.FactoryToHub.Sea.Option0.RequiredProducts));
            sb.Append("\t " + "option #2 " + this.FactoryToHub.Sea.Option1.Name + " " + this.FactoryToHub.Sea.Option1.PriceCurrency + " " + this.FactoryToHub.Sea.Option1.Price + " " + string.Format("Minimum {0} Unit Order\n", this.FactoryToHub.Sea.Option1.RequiredProducts));
            sb.Append("\t " + "option #3 " + this.FactoryToHub.Sea.Option2.Name + " " + this.FactoryToHub.Sea.Option2.PriceCurrency + " " + this.FactoryToHub.Sea.Option2.Price + " " + string.Format("Minimum {0} Unit Order\n", this.FactoryToHub.Sea.Option2.RequiredProducts));
            sb.Append("\t " + "option #4 " + this.FactoryToHub.Sea.Option3.Name + " " + this.FactoryToHub.Sea.Option3.PriceCurrency + " " + this.FactoryToHub.Sea.Option3.Price + " " + string.Format("Minimum {0} Unit Order\n", this.FactoryToHub.Sea.Option3.RequiredProducts));

            sb.Append("\n");
            sb.Append("Factory to Hub Costs (via Superhero Freight)" + "\n");
            sb.Append("\t " + "option #1 " + this.FactoryToHub.SuperheroFrieght.Option0.Name + " " + this.FactoryToHub.SuperheroFrieght.Option0.PriceCurrency + " " + this.FactoryToHub.SuperheroFrieght.Option0.Price + " " + string.Format("Minimum {0} Unit Order\n", this.FactoryToHub.SuperheroFrieght.Option0.RequiredProducts));
            sb.Append("\t " + "option #2 " + this.FactoryToHub.SuperheroFrieght.Option1.Name + " " + this.FactoryToHub.SuperheroFrieght.Option1.PriceCurrency + " " + this.FactoryToHub.SuperheroFrieght.Option1.Price + " " + string.Format("Minimum {0} Unit Order\n", this.FactoryToHub.SuperheroFrieght.Option1.RequiredProducts));
            sb.Append("\t " + "option #3 " + this.FactoryToHub.SuperheroFrieght.Option2.Name + " " + this.FactoryToHub.SuperheroFrieght.Option2.PriceCurrency + " " + this.FactoryToHub.SuperheroFrieght.Option2.Price + " " + string.Format("Minimum {0} Unit Order\n", this.FactoryToHub.SuperheroFrieght.Option2.RequiredProducts));
            sb.Append("\t " + "option #4 " + this.FactoryToHub.SuperheroFrieght.Option3.Name + " " + this.FactoryToHub.SuperheroFrieght.Option3.PriceCurrency + " " + this.FactoryToHub.SuperheroFrieght.Option3.Price + " " + string.Format("Minimum {0} Unit Order\n", this.FactoryToHub.SuperheroFrieght.Option3.RequiredProducts));

            sb.Append("\n");
            sb.Append("Misc. Data" + "\n");
            sb.Append("\t " + "Cost " + this.FOB.Currency + " " + this.FOB.Amount);
            sb.Append("\t " + "Fulfilment " + this.Fulfilment);
            sb.Append("\t " + "Origin " + this.Product.Origin.Name);
            sb.Append("\t " + "Category " + this.Product.Category.Name);

            sb.Append("\n");
            sb.Append("Landed Cost" + "\n");
            sb.Append("\t " + "via air " + this.LandedCost.Air.Currency + " " + this.LandedCost.Air.Amount);
            sb.Append("\t " + "via sea " + this.LandedCost.Sea.Currency + " " + this.LandedCost.Sea.Amount);
            sb.Append("\t " + "via shf " + this.LandedCost.SuperheroFreight.Currency + " " + this.LandedCost.SuperheroFreight.Amount);

            sb.Append("\n");
            sb.Append("POI" + "\n");
            sb.Append("\t " + "via air " + this.POI.Air.Currency + " " + String.Format("Value: {0:P2}.", this.POI.Air.Amount));
            sb.Append("\t " + "via sea " + this.POI.Sea.Currency + " " + String.Format("Value: {0:P2}.", this.POI.Sea.Amount));
            sb.Append("\t " + "via shf " + this.POI.SuperheroFreight.Currency + " " + String.Format("Value: {0:P2}.", this.POI.SuperheroFreight.Amount));


            sb.Append("\n");
            sb.Append("POR" + "\n");
            sb.Append("\t " + "via air " + this.POR.Air.Currency + " " + String.Format("Value: {0:P2}.", this.POR.Air.Amount));
            sb.Append("\t " + "via sea " + this.POR.Sea.Currency + " " + String.Format("Value: {0:P2}.", this.POR.Sea.Amount));
            sb.Append("\t " + "via shf " + this.POR.SuperheroFreight.Currency + " " + String.Format("Value: {0:P2}.", this.POR.SuperheroFreight.Amount));

            sb.Append("\n");
            sb.Append("Product Info" + "\n");
            sb.Append("\t " + "Origin " + this.Product.Origin.Name + "\n");
            sb.Append("\t " + "Category " + this.Product.Category.Name + "\n");
            sb.Append("\t " + "Selling Price " + this.Product.SellingPrice.Currency + " " + this.Product.SellingPrice.Amount + "\n");
            sb.Append("\t " + "Pre-Tax " + this.Product.SellingPrice.Taxless.Currency + " " + this.Product.SellingPrice.Taxless.Amount + "\n");
            sb.Append("\t " + "RVF " + this.RVF.Currency + " " + this.RVF.Amount + "\n");
            sb.Append("\t " + "Sales Country " + this.SalesCountry.Name + "\n");
            sb.Append("\t " + "Sales Tax " + String.Format("Value: {0:P2}.", this.SalesTax.CountryTax.Amount) + "\n");
            sb.Append("\t " + "Sales Tax Charged " + this.SalesTax.Currency + " " + this.SalesTax.Amount + "\n");

            sb.Append("\n");
            sb.Append("Profit" + "\n");
            sb.Append("\t " + "via air " + this.Profit.Air.Currency + " " + this.Profit.Air.Amount);
            sb.Append("\t " + "via air " + this.Profit.Sea.Currency + " " + this.Profit.Sea.Amount);
            sb.Append("\t " + "via air " + this.Profit.SuperheroFreight.Currency + " " + this.Profit.SuperheroFreight.Amount);

            sb.Append("\n");
            sb.Append("Suggested Selling Price" + "\n");
            sb.Append("\t " + "via air " + this.SuggestedSalesPrice.Air.Currency + " " + this.SuggestedSalesPrice.Air.Amount);
            sb.Append("\t " + "via sea " + this.SuggestedSalesPrice.Sea.Currency + " " + this.SuggestedSalesPrice.Sea.Amount);
            sb.Append("\t " + "via shf " + this.SuggestedSalesPrice.SuperheroFreight.Currency + " " + this.SuggestedSalesPrice.SuperheroFreight.Amount);

            sb.Append("\n");
            if (Sundries.Any())
            {
                sb.Append("Sundries" + "\n");
                var sundryIndex = 0;
                foreach (var sundryLine in Sundries)
                {
                    sb.Append(String.Format("\t {0}: \t{1} \t{2} \t{3}\n", sundryIndex, sundryLine.name.PadLeft(20, ' '),
                        sundryLine.Amount.ToString().PadLeft(8, ' '), sundryLine.Currency));
                    sundryIndex++;
                }
                if (SundriesTotal != null)
                {
                    sb.Append(String.Format("\t {0}  \t{1} \t{2} \t{3}\n", " ", "Totals".PadLeft(20, ' '),
                        SundriesTotal.Amount.ToString().PadLeft(8, ' '), SundriesTotal.Currency));

                }
            }



            return sb.ToString();
        }
        #endregion
    }

    public class CurrencyAmount
    {
        public float Amount { get; set; }
        public string Currency { get; set; }
    }

    public class TypeAmount
    {
        public float Amount { get; set; }
        public string Type { get; set; }
    }

    public class Country
    {
        public string ISO { get; set; }
        public string Name { get; set; }
    }

    public class SalesTax : CurrencyAmount
    {
        [JsonProperty("country_tax")]
        public TypeAmount CountryTax { get; set; }
    }



    public class CurrencyAmountWithTaxless : CurrencyAmount
    {
        public CurrencyAmount Taxless { get; set; }
    }

    public class AmazonFees
    {
        [JsonProperty("efn_fee")]
        public CurrencyAmount EfnFee { get; set; }

       [JsonProperty("fba_fee")]
        public CurrencyAmount FbaFee { get; set; }

        [JsonProperty("sales_fee")]
        public CurrencyAmount SalesFee { get; set; }
    }

    public class Dimensions
    {
        public float CBM { get; set; }
        public string Measurement { get; set; }
        public float ProductHeight { get; set; }
        public float ProductLength { get; set; }
        public float ProductWidth { get; set; }
    }

    public class ShipmentAmountSet
    {
        public CurrencyAmount Air { get; set; }
        public CurrencyAmount Sea { get; set; }

        [JsonProperty("shf")]
        public CurrencyAmount SuperheroFreight { get; set; }
    }

    public class ShipmentAmountSetWithBest : ShipmentAmountSet
    {
        public CurrencyAmount Best { get; set; }
    }


    public class ShipmentOption
    {
        public string Name { get; set; }
        public float Price { get; set; }
        public string PriceCurrency { get; set; }
        public int RequiredProducts { get; set; }
    }

    public class ShipmentOptions
    {
        [JsonProperty("0")]
        public ShipmentOption Option0 { get; set; }

        [JsonProperty("1")]
        public ShipmentOption Option1 { get; set; }

        [JsonProperty("2")]
        public ShipmentOption Option2 { get; set; }

        [JsonProperty("3")]
        public ShipmentOption Option3 { get; set; }

        public ShipmentOption Best { get; set; }
    }

    public class CostOptions
    {
        public ShipmentOptions Air { get; set; }
        public ShipmentOptions Sea { get; set; }

        [JsonProperty("shf")]
        public ShipmentOptions SuperheroFrieght { get; set; }
    }

    public class Category
    {
        public int Id { get; set; }
        public string Name { get; set; }
    }

    public class Product
    {
        public Category Category { get; set; }
        public Country Origin { get; set; }

        [JsonProperty("selling_price")]
        public CurrencyAmountWithTaxless SellingPrice { get; set; }
    }

    public class Weight
    {
        public float Amount { get; set; }
        public string Measurement { get; set; }
    }
}