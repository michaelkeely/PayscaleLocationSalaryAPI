using PayscaleCalc.Models;
using System.Web.Http;


namespace PayscaleCalc.Controllers
{
    public class PayscaleController : ApiController
    {
        /*
        http://services.payscale.com/quote.asmx
        Email: michael.keely@tmp.com
        Password: nfdka8$kdJl
        */


        /// <summary>
        /// Gets the Google formatted JSON for the Ajax call to the salary graph.
        /// </summary>
        /// <param name="city">City</param>
        /// <param name="state">State</param>
        /// <param name="title">Raw job title (will be transformed to Payscale job title internally)</param>
        /// <returns></returns>
        public GooglePayscaleChartData Get(string city, string state, string title)
        {
            var payscaleClient = new PayscaleClient(title, city, state);

            return payscaleClient.GetPayscale().ToGoogleChartData();
        }

    }
}
