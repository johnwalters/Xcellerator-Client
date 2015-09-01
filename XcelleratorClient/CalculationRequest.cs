using System.Collections.Generic;

namespace XcelleratorClient
{
    public class CalculationRequest
    {
        public string ApiKey { get; set; }
        public string CalcId { get; set; }
        public ProductCategory? ProductCategory { get; set; }
        public int? UserId { get; set; }
        public float? Length { get; set; }
        public float? Height { get; set; }
        public float? Width { get; set; }
        public float? Weight { get; set; }
        public float? SellingPrice { get; set; }
        public float? Fob { get; set; }
        public float? Duty { get; set; }
        public string WeightMeasurement { get; set; }
        public string SellingPriceCurrency { get; set; }
        public string FobCurrency { get; set; }
        public string DimensionMeasurement { get; set; }
        public string SalesCountry { get; set; }
        public string ProductOrigin { get; set; }
        public string Fulfilment { get; set; }
        public string OutputCurrency { get; set; }
        public string OutputMeasurement { get; set; }
        public string Email { get; set; }
        public List<Sundry> Sundries { get; set; }

        public void AddSundry(Sundry sundry)
        {
            if (Sundries == null)
            {
                Sundries = new List<Sundry>();
            }
            Sundries.Add(sundry);
        }
    }

    public class Sundry
    {
        public string Name { get; set; }
        public float Amount { get; set; }
        public string Currency { get; set; }
    }

    public enum ProductCategory
    {

        ElectronicAccessories = 1,
        DiyAndTools = 2,
        MusicAndDj = 3,
        Others = 4,
        CarAndMotorbike = 5,
        ComputerAccessories = 6,
        SportsAndOutdoors = 7,
        HomeAndGarden = 8,
        Pets = 9,
        HealthAndBeauty = 10,
        PatioLawnAndGarden = 11,
        HomeImprovement = 12,
        Baby = 13,
        KitchenAndDining = 14

    }

    public class CountryCode
    {
        public static string UnitedStates { get { return "us"; } }
        public static string UnitedKingdom { get { return "uk"; } }
        public static string Canada { get { return "ca"; } }
        public static string Germany { get { return "de"; } }
        public static string France { get { return "fr"; } }
        public static string Italy { get { return "it"; } }
        public static string Spain { get { return "es"; } }
        public static string China { get { return "cn"; } }
    }

    public class DimensionMeasurement
    {
        public static string CubicMeters { get { return "cm"; } }
        public static string Inches { get { return "inches"; } }
    }

    public class WeightMeasurement
    {
        public static string Grams { get { return "g"; } }
        public static string KiloGrams { get { return "kg"; } }
        public static string Pounds { get { return "lbs"; } }
    }

    public class OutputMeasurement
    {
        public static string Metric { get { return "metric"; } }
        public static string Imperial { get { return "imperial"; } }
    }

    public class Currency
    {
        public static string USDollars { get { return "usd"; } }
        public static string Pounds { get { return "gbp"; } }
        public static string CanadianDollars { get { return "cad"; } }
        public static string Euros { get { return "eur"; } }
    }

    public class Fulfilment
    {
        public static string Efn { get { return "efn"; } }
        public static string Mci { get { return "mci"; } }
    }
}