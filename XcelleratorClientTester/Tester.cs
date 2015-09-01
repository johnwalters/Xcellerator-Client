using System;
using NUnit.Framework;
using XcelleratorClient;

namespace XcelleratorClientTester
{
    [TestFixture]
    public class Tester
    {
        [Test]
        public void Calculation()
        {
            var calculator = new XcelleratorCalculator();
            calculator.LogResponses = true;

            calculator.Request.Width = 60;
            calculator.Request.Height = 35;
            calculator.Request.Length = 15;
            calculator.Request.Weight = 366;
            calculator.Request.WeightMeasurement = WeightMeasurement.Grams;
            calculator.Request.Fob = (float) 2.90;
            calculator.Request.FobCurrency = Currency.USDollars;
            calculator.Request.ProductCategory = ProductCategory.HomeAndGarden;
            calculator.Request.SalesCountry = CountryCode.UnitedStates;
            calculator.Request.SellingPrice = (float) 18.95;
            var result = calculator.CreateCalculation();
            Assert.That(String.IsNullOrWhiteSpace(result.Error));
            Console.Out.WriteLine(result.ToFormattedString());
          
        }

        [Test]
        public void ComplexCalculation()
        {
            var calculator = new XcelleratorCalculator();
            calculator.LogResponses = true;

            calculator.Request.Width = 60.2f;
            calculator.Request.Height = 35.5f;
            calculator.Request.Length = 15.25f;
            calculator.Request.Weight = 2.65f;
            calculator.Request.WeightMeasurement = WeightMeasurement.KiloGrams;
            calculator.Request.Fob = 3.55f;
            calculator.Request.FobCurrency = Currency.USDollars;
            calculator.Request.ProductCategory = ProductCategory.HomeAndGarden;
            calculator.Request.SalesCountry = CountryCode.UnitedStates;
            calculator.Request.SellingPrice = 18.95f;
            calculator.Request.SellingPriceCurrency = Currency.USDollars;
            calculator.Request.Duty = .05f;
            calculator.Request.SalesCountry = CountryCode.UnitedStates;
            calculator.Request.ProductOrigin = CountryCode.China;

            calculator.Request.Fulfilment = Fulfilment.Mci;
            calculator.Request.OutputCurrency = Currency.USDollars;
            calculator.Request.OutputMeasurement = OutputMeasurement.Imperial;
            calculator.Request.Email = "xcel@lerator.com";

            calculator.Request.DimensionMeasurement = DimensionMeasurement.CubicMeters;

            var result = calculator.CreateCalculation();
            Assert.That(String.IsNullOrWhiteSpace(result.Error));
            Console.Out.WriteLine(result.ToFormattedString());

        }

        [Test]
        public void CalculationWithSundries()
        {
            var calculator = new XcelleratorCalculator();
            calculator.LogResponses = true;

            calculator.Request.Width = 60;
            calculator.Request.Height = 35;
            calculator.Request.Length = 15;
            calculator.Request.Weight = 366;
            calculator.Request.WeightMeasurement = WeightMeasurement.Grams;
            calculator.Request.Fob = (float)2.90;
            calculator.Request.FobCurrency = Currency.USDollars;
            calculator.Request.ProductCategory = ProductCategory.HomeAndGarden;
            calculator.Request.SalesCountry = CountryCode.UnitedStates;
            calculator.Request.SellingPrice = (float)18.95;

            calculator.Request.AddSundry(new Sundry(){Name = "this", Amount = 12.50f, Currency = Currency.USDollars});
            calculator.Request.AddSundry(new Sundry() { Name = "that", Amount = 350.66f, Currency = Currency.USDollars });
            calculator.Request.AddSundry(new Sundry() { Name = "the other", Amount = 110.30f, Currency = Currency.USDollars });

            var result = calculator.CreateCalculation();
            Assert.That(String.IsNullOrWhiteSpace(result.Error));
            Console.Out.WriteLine(result.ToFormattedString());
            Assert.That(result.Sundries.Count == 3);
        }

        [Test]
        public void CalculationWithSundriesSupports20Items()
        {
            var calculator = new XcelleratorCalculator();
            calculator.LogResponses = true;

            calculator.Request.Width = 60;
            calculator.Request.Height = 35;
            calculator.Request.Length = 15;
            calculator.Request.Weight = 366;
            calculator.Request.WeightMeasurement = WeightMeasurement.Grams;
            calculator.Request.Fob = (float)2.90;
            calculator.Request.FobCurrency = Currency.USDollars;
            calculator.Request.ProductCategory = ProductCategory.HomeAndGarden;
            calculator.Request.SalesCountry = CountryCode.UnitedStates;
            calculator.Request.SellingPrice = (float)18.95;

            calculator.Request.AddSundry(new Sundry() { Name = "this", Amount = 12.50f, Currency = Currency.USDollars });
            calculator.Request.AddSundry(new Sundry() { Name = "that", Amount = 350.66f, Currency = Currency.USDollars });
            calculator.Request.AddSundry(new Sundry() { Name = "the other", Amount = 110.30f, Currency = Currency.USDollars });
            calculator.Request.AddSundry(new Sundry() { Name = "more", Amount = 110.30f, Currency = Currency.USDollars });
            calculator.Request.AddSundry(new Sundry() { Name = "more", Amount = 110.30f, Currency = Currency.USDollars });
            calculator.Request.AddSundry(new Sundry() { Name = "more", Amount = 110.30f, Currency = Currency.USDollars });
            calculator.Request.AddSundry(new Sundry() { Name = "more", Amount = 110.30f, Currency = Currency.USDollars });
            calculator.Request.AddSundry(new Sundry() { Name = "more", Amount = 110.30f, Currency = Currency.USDollars });
            calculator.Request.AddSundry(new Sundry() { Name = "more", Amount = 110.30f, Currency = Currency.USDollars });
            calculator.Request.AddSundry(new Sundry() { Name = "more", Amount = 110.30f, Currency = Currency.USDollars });
            calculator.Request.AddSundry(new Sundry() { Name = "more", Amount = 110.30f, Currency = Currency.USDollars });
            calculator.Request.AddSundry(new Sundry() { Name = "more", Amount = 110.30f, Currency = Currency.USDollars });
            calculator.Request.AddSundry(new Sundry() { Name = "more", Amount = 110.30f, Currency = Currency.USDollars });
            calculator.Request.AddSundry(new Sundry() { Name = "more", Amount = 110.30f, Currency = Currency.USDollars });
            calculator.Request.AddSundry(new Sundry() { Name = "more", Amount = 110.30f, Currency = Currency.USDollars });
            calculator.Request.AddSundry(new Sundry() { Name = "more", Amount = 110.30f, Currency = Currency.USDollars });
            calculator.Request.AddSundry(new Sundry() { Name = "more", Amount = 110.30f, Currency = Currency.USDollars });
            calculator.Request.AddSundry(new Sundry() { Name = "more", Amount = 110.30f, Currency = Currency.USDollars });
            calculator.Request.AddSundry(new Sundry() { Name = "more", Amount = 110.30f, Currency = Currency.USDollars });
            calculator.Request.AddSundry(new Sundry() { Name = "more", Amount = 110.30f, Currency = Currency.USDollars });

            var result = calculator.CreateCalculation();
            Assert.That(String.IsNullOrWhiteSpace(result.Error));
            Console.Out.WriteLine(result.ToFormattedString());
            Assert.That(result.Sundries.Count == 20);
            // current limitation of this client is that is only supports up to 20 sundries in the sundry list.
        }

        [Test]
        public void EmptyCalculation()
        {
            var calculator = new XcelleratorCalculator();
            calculator.LogResponses = true;

            var result = calculator.CreateCalculation();
            Assert.That(String.IsNullOrWhiteSpace(result.Error));
            Console.Out.WriteLine(result.ToFormattedString());

            calculator = new XcelleratorCalculator();
            var expectedId = result.Id;
            result = calculator.GetCalculation(expectedId);
            Assert.That(String.IsNullOrWhiteSpace(result.Error));
        }

        [Test]
        public void CalculationWithBadApiReturnsError()
        {
            var calculator = new XcelleratorCalculator();
            calculator.LogResponses = true;
            calculator.Request.Width = 60;
            calculator.Request.Height = 35;
            calculator.Request.Length = 15;
            calculator.Request.WeightMeasurement = "4";
            calculator.Request.Fob = (float)2.90;
            calculator.Request.ApiKey = "notsogoodapikey";
            var result = calculator.CreateCalculation();
            Assert.That(!String.IsNullOrWhiteSpace(result.Error));

        }

       
    }
}
