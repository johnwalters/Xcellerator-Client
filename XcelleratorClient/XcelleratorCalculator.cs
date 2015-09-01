using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Configuration;
using System.Net;
using System.Text;
using Newtonsoft.Json;


namespace XcelleratorClient
{
    public class XcelleratorCalculator
    {
        private CalculationRequest _input;
        private const string _calculatorUrl = "https://api.xcelleratortools.com/calculator/v1/";
        private string _apiKey;


        public CalculationRequest Request
        {
            get
            {
                if (_input == null)
                {
                    _input = new CalculationRequest();
                }
                return _input;
            }

            set { _input = value; }
        }

        public bool LogResponses { get; set; }

        public XcelleratorCalculator()
        {
            _input = new CalculationRequest();
        }

        private string ApiKey
        {
            get
            {
                if (String.IsNullOrWhiteSpace(_apiKey))
                {
                    _apiKey = ConfigurationManager.AppSettings["ApiKey"];
                }
                return _apiKey;
            }
        }

        private int? UserId
        {
            get
            {
                if (ConfigurationManager.AppSettings["UserId"] != null &&
                    !String.IsNullOrWhiteSpace(ConfigurationManager.AppSettings["UserId"]))
                {
                    return Convert.ToInt32(ConfigurationManager.AppSettings["UserId"]);
                }
                return null;
            }
        }




        public CalculationResponse CreateCalculation()
        {
            Request.ApiKey = String.IsNullOrWhiteSpace(Request.ApiKey) ? ApiKey : Request.ApiKey;
            Request.UserId = Request.UserId.HasValue ? Request.UserId.Value : this.UserId;
            var responsebody = "";


            var formValues = new NameValueCollection();
            formValues.Add("api_key", Request.ApiKey);

            SetFormValueIfNotNull(Request.UserId, "user_id", ref formValues);
            SetFormValueIfNotNull(Request.ProductCategory, "product_category", ref formValues);
            SetFormValueIfNotNull(Request.Length, "length", ref formValues);
            SetFormValueIfNotNull(Request.Width, "width", ref formValues);
            SetFormValueIfNotNull(Request.Height, "height", ref formValues);
            SetFormValueIfNotNull(Request.Weight, "weight", ref formValues);
            SetFormValueIfNotNull(Request.SellingPrice, "selling_price", ref formValues);
            SetFormValueIfNotNull(Request.Fob, "fob", ref formValues);
            SetFormValueIfNotNull(Request.Duty, "duty", ref formValues);
            SetFormValueIfNotNull(Request.WeightMeasurement, "weight_measurement", ref formValues);
            SetFormValueIfNotNull(Request.SellingPriceCurrency, "selling_price_currency", ref formValues);
            SetFormValueIfNotNull(Request.FobCurrency, "fob_currency", ref formValues);
            SetFormValueIfNotNull(Request.DimensionMeasurement, "dimension_measurement", ref formValues);
            SetFormValueIfNotNull(Request.SalesCountry, "sales_country", ref formValues);
            SetFormValueIfNotNull(Request.ProductOrigin, "product_origin", ref formValues);
            SetFormValueIfNotNull(Request.Fulfilment, "fulfilment", ref formValues);
            SetFormValueIfNotNull(Request.OutputCurrency, "output_currency", ref formValues);
            SetFormValueIfNotNull(Request.OutputMeasurement, "output_measurement", ref formValues);
            SetFormValueIfNotNull(Request.CalcId, "calc_id", ref formValues);
            SetFormValueIfNotNull(Request.Email, "email", ref formValues);

            // add sundries
            if (Request.Sundries != null)
            {
                var sundryIndex = 0;
                foreach (var requestSundry in Request.Sundries)
                {
                    SetFormValueIfNotNull(requestSundry.Name, String.Format("sundries[{0}][name]", sundryIndex), ref formValues);
                    SetFormValueIfNotNull(requestSundry.Amount, String.Format("sundries[{0}][amount]", sundryIndex), ref formValues);
                    SetFormValueIfNotNull(requestSundry.Currency, String.Format("sundries[{0}][currency]", sundryIndex), ref formValues);
                    sundryIndex++;
                }
            }
           


            using (var client = new WebClient())
            {
                var responsebytes = client.UploadValues(_calculatorUrl, "POST", formValues);
                responsebody = Encoding.UTF8.GetString(responsebytes);
            }

            if (LogResponses)
            {
                Console.WriteLine(responsebody);
                Console.WriteLine("");
            }

            var typedResponse = JsonConvert.DeserializeObject<CalculationResponse>(responsebody);
            var sundries = JsonConvert.DeserializeObject<ParsedSundries>(responsebody);
            typedResponse.SetSundries(sundries);
            return typedResponse;
        }


        public CalculationResponse GetCalculation(string calculationId)
        {

            var responsebody = "";
            Request.ApiKey = String.IsNullOrWhiteSpace(Request.ApiKey) ? ApiKey : Request.ApiKey;
            Request.UserId = Request.UserId.HasValue ? Request.UserId.Value : this.UserId;


            var formValues = new NameValueCollection();
            formValues.Add("api_key", Request.ApiKey);
            SetFormValueIfNotNull(Request.UserId, "user_id", ref formValues);
            SetFormValueIfNotNull(Request.CalcId, "calc_id", ref formValues);


            using (var client = new WebClient())
            {
                byte[] responsebytes = client.UploadValues(_calculatorUrl, "POST", formValues);
                responsebody = Encoding.UTF8.GetString(responsebytes);
            }
            if (LogResponses)
            {
                Console.WriteLine(responsebody);
                Console.WriteLine("");
            }
            var typedResponse = JsonConvert.DeserializeObject<CalculationResponse>(responsebody);
            var sundries = JsonConvert.DeserializeObject<ParsedSundries>(responsebody);
            typedResponse.SetSundries(sundries);
            return typedResponse;
        }

        private void SetFormValueIfNotNull(object value, string formName, ref NameValueCollection formValues)
        {
            if (!ValueIsNull(value))
            {
                formValues.Add(formName, value.ToString());
            }
        }
        private bool ValueIsNull<T>(T obj)
        {
            return EqualityComparer<T>.Default.Equals(obj, default(T));
        }
       

    }

   

    

}
