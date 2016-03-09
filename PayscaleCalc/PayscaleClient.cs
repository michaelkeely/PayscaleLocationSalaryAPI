using System;
using System.ServiceModel;
using PayscaleCalc.Models;

namespace PayscaleCalc
{
    public class PayscaleClient
    {
        public string JobName { get; set; }
        public string City { get; set; }
        public string State { get; set; }
        public string Country { get; set; }

        private TimeSpan _timeout = new TimeSpan(0, 0, 30);
        private string _suggestedJobName;
        private Payscale.Location _location;

        private string _username = "michael.keely@tmp.com"; //config this and possibly encrypt
        private string _password = "nfdka8$kdJl"; //config this and possibly encrypt

        private string _payscaleURL = "http://services.payscale.com/quote.asmx"; //config this and possibly encrypt

        private EndpointAddress _endpointAddress;
        private HttpBindingBase _binding;

        private Payscale.PayScaleQuoteServiceSoapClient _soapClient;

        public PayscaleClient(string jobName, string city, string state, string country = "United States")
        {
            JobName = jobName;
            City = city;
            State = state;
            Country = country;

            _location = new Payscale.Location() { City = this.City, State = this.State, Country = this.Country };
            
            //set up service
            _endpointAddress = new EndpointAddress(_payscaleURL);

            _binding = new BasicHttpBinding();
            _binding.SendTimeout = _timeout;
            _binding.OpenTimeout = _timeout;

            _soapClient = new Payscale.PayScaleQuoteServiceSoapClient(_binding, _endpointAddress);
        }

        public PayscaleQuoteModel GetPayscale()
        {
            PayscaleQuoteModel returnModel = new PayscaleQuoteModel();

            try
            {
                var req = new Payscale.PayScaleQuoteRequest() { IsTest = true } ;
                req.Credentials = new Payscale.PayscaleCredentials() { UserName = _username, Password = _password };

                _suggestedJobName = GetJobSuggestion(JobName);

                if (String.IsNullOrEmpty(_suggestedJobName))
                {
                    throw new Exception("No jobs found from Job Name supplied.");
                }

                
                req.UserEnteredJobTitle = _suggestedJobName;

                Payscale.Job job = new Payscale.Job() { Title = _suggestedJobName };

                req.Profile = new Payscale.UserProfile() { Location = _location, Job = job };

                var response = _soapClient.PayScaleQuote(req);

                if (response.PayScaleQuotes != null && response.PayScaleQuotes.Length > 0)
                {
                    returnModel.Low = response.PayScaleQuotes[0].Percentile25;
                    returnModel.Typical = response.PayScaleQuotes[0].Median;
                    returnModel.High = response.PayScaleQuotes[0].Percentile75;
                }

            }
            catch (Exception e)
            {
            }


            return returnModel;
        }

        public string GetJobSuggestion(string jobName)
        {
            var suggestJobsReq = new Payscale.SuggestJobsRequest{ IsTest = true };
            suggestJobsReq.Credentials = new Payscale.PayscaleCredentials() { UserName = _username, Password = _password };

            suggestJobsReq.MaxResults = 1;
            suggestJobsReq.MatchType = Payscale.MatchType.Default;
            suggestJobsReq.Job = jobName;

            var response = _soapClient.SuggestJobs(suggestJobsReq);

            string job = response.Jobs[0];

            if (response.Jobs != null && response.Jobs.Length > 0)
            {
                return response.Jobs[0];
            }
            else
            {
                return "";
            }
            
        }
    }
}