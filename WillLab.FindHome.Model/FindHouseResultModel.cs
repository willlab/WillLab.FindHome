namespace WillLab.FindHome.Model
{
    /// <summary>
    /// House search result status info
    /// </summary>
    public class FindHouseResultModel
    {
        public string StatusCode { get; set; }
        public string StatusMessage { get; set; }
        public HouseModel HouseInfo { get; set; }
    }
}
