using System;

namespace PayscaleCalc.Models

{
    public class PayscaleQuoteModel
    {
        public double Low { get; set; }
        public double Typical { get; set; }
        public double High { get; set; }


        public GooglePayscaleChartData ToGoogleChartData()
        {
            GooglePayscaleChartData returnData = new GooglePayscaleChartData();
            returnData.cols = new GoogleCol[2];
            returnData.cols[0] = new GoogleCol() { id = "", label = "Range", pattern = "", type = "string" };
            returnData.cols[1] = new GoogleCol() { id = "", label = "Label", pattern = "", type = "number" };

            returnData.rows = new GoogleRow[3];

            returnData.rows[0] = new GoogleRow() { c = new GoogleRowItem[2] };
            returnData.rows[0].c[0] = new GoogleRowItem() { f = null, v = "low" };
            returnData.rows[0].c[1] = new GoogleRowItem() { f = null, v = Math.Truncate(Low).ToString() };

            returnData.rows[1] = new GoogleRow() { c = new GoogleRowItem[2] };
            returnData.rows[1].c[0] = new GoogleRowItem() { f = null, v = "typical" };
            returnData.rows[1].c[1] = new GoogleRowItem() { f = null, v = Math.Truncate(Typical).ToString() };

            returnData.rows[2] = new GoogleRow() { c = new GoogleRowItem[2] };
            returnData.rows[2].c[0] = new GoogleRowItem() { f = null, v = "high" };
            returnData.rows[2].c[1] = new GoogleRowItem() { f = null, v = Math.Truncate(High).ToString() };

            return returnData;
        }

    }
}



