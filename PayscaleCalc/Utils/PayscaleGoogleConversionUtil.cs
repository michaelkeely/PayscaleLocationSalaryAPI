using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using PayscaleCalc.Models;

namespace PayscaleCalc.Utils
{
    public static class PayscaleGoogleConversionUtil
    {
        //public static GooglePayscaleChartData GetGoogleChartDataFromPayscaleQuoteModel(PayscaleQuoteModel payscaleQuoteModel)
        //{
        //    GooglePayscaleChartData returnData = new GooglePayscaleChartData();
        //    returnData.cols = new GoogleCol[2];
        //    returnData.cols[0] = new GoogleCol() { id = "", label = "", pattern = "", type = "" };
        //    returnData.cols[1] = new GoogleCol() { id = "", label = "", pattern = "", type = "" };

        //    returnData.rows = new GoogleRow[3];

        //    returnData.rows[0] = new GoogleRow() { c = new GoogleRowItem[2] };
        //    returnData.rows[0].c[0] = new GoogleRowItem() { f = null, v = "low" };
        //    returnData.rows[0].c[1] = new GoogleRowItem() { f = "", v = String.Format(payscaleQuoteModel.low, ) };

        //    returnData.rows[1] = new GoogleRow() { c = new GoogleRowItem[2] };
        //    returnData.rows[1].c[0] = new GoogleRowItem() { f = null, v = "typical" };
        //    returnData.rows[1].c[1] = new GoogleRowItem() { f = "", v = payscaleQuoteModel.Typical.ToString() };

        //    returnData.rows[2] = new GoogleRow() { c = new GoogleRowItem[2] };
        //    returnData.rows[2].c[0] = new GoogleRowItem() { f = null, v = "high" };
        //    returnData.rows[2].c[1] = new GoogleRowItem() { f = "", v = payscaleQuoteModel.High.ToString() };

        //    return returnData;
        //}
    }
}

/*
{
    "cols": [
        {"id":"","label":"Range","pattern":"","type":"string"},
        {"id":"","label":"Salary","pattern":"","type":"number"}
        ],
    "rows": [
        {"c":[{"v":"low","f":null},{"v":@Model.low,"f":null}]},
        {"c":[{"v":"typical","f":null},{"v":@Model.typical,"f":null}]},
        {"c":[{"v":"high","f":null},{"v":@Model.high,"f":null}]}
        ]
}
*/
