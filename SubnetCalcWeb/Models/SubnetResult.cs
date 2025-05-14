namespace SubnetCalcWeb.Models
{
    public class SubnetResult
    {
        public string NetworkAddress   { get; set; } = string.Empty;
        public string BroadcastAddress { get; set; } = string.Empty;
        public string UsableRange      { get; set; } = string.Empty;
        public int    TotalHosts       { get; set; }
    }
}
