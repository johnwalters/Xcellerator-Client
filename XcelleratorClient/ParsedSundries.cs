using System;
using Newtonsoft.Json;

namespace XcelleratorClient
{
    public class ParsedSundries
    {
        [JsonProperty("sundries")]
        public Sundries Data { get; set; }
    }

    public class SundryAmount : CurrencyAmount
    {
        public String name { get; set; }
    }

    public class Sundries
    {
        [JsonProperty("0")]
        public SundryAmount Sundry0 { get; set; }

        [JsonProperty("1")]
        public SundryAmount Sundry1 { get; set; }

        [JsonProperty("2")]
        public SundryAmount Sundry2 { get; set; }

        [JsonProperty("3")]
        public SundryAmount Sundry3 { get; set; }

        [JsonProperty("4")]
        public SundryAmount Sundry4 { get; set; }

        [JsonProperty("5")]
        public SundryAmount Sundry5 { get; set; }

        [JsonProperty("6")]
        public SundryAmount Sundry6 { get; set; }

        [JsonProperty("7")]
        public SundryAmount Sundry7 { get; set; }

        [JsonProperty("8")]
        public SundryAmount Sundry8 { get; set; }

        [JsonProperty("9")]
        public SundryAmount Sundry9 { get; set; }

        [JsonProperty("10")]
        public SundryAmount Sundry10 { get; set; }

        [JsonProperty("11")]
        public SundryAmount Sundry11 { get; set; }

        [JsonProperty("12")]
        public SundryAmount Sundry12 { get; set; }

        [JsonProperty("13")]
        public SundryAmount Sundry13 { get; set; }

        [JsonProperty("14")]
        public SundryAmount Sundry14 { get; set; }

        [JsonProperty("15")]
        public SundryAmount Sundry15 { get; set; }

        [JsonProperty("16")]
        public SundryAmount Sundry16 { get; set; }

        [JsonProperty("17")]
        public SundryAmount Sundry17 { get; set; }

        [JsonProperty("18")]
        public SundryAmount Sundry18 { get; set; }

        [JsonProperty("19")]
        public SundryAmount Sundry19 { get; set; }

        [JsonProperty("20")]
        public SundryAmount Sundry20 { get; set; }

        public SundryAmount total { get; set; }
    }
}