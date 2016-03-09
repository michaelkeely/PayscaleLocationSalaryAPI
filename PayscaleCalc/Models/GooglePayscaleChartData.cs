namespace PayscaleCalc.Models
{
    public class GooglePayscaleChartData
    {
        public GoogleCol[] cols { get; set; }

        public GoogleRow[] rows { get; set; }
    }

    public class GoogleCol
    {
        public string id { get; set; }
        public string label { get; set; }
        public string pattern { get; set; }
        public string type { get; set; }

    }

    public class GoogleRow
    {
        public GoogleRowItem[] c { get; set; }
    }

    public class GoogleRowItem
    {
        public string v { get; set; }

        public string f { get; set; }
    }
}


/* TARGET OUTPUT FORMAT
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

{
    "cols": [
        {"id":"","label":"","pattern":"","type":""},
        {"id":"","label":"","pattern":"","type":""}
        ],
    "rows": [
        {"c":[{"v":"low","f":null},{"v":"53524.009368837","f":""}]},
        {"c":[{"v":"typical","f":null},{"v":"65838.5625877416","f":""}]},{"c":[{"v":"high","f":null},{"v":"82311.5337343583","f":""}]}]}

*/
