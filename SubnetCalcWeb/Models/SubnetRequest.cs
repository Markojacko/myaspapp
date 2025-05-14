using System.ComponentModel.DataAnnotations;

namespace SubnetCalcWeb.Models
{
    public class SubnetRequest
    {
        [Required]
        [RegularExpression(@"\b(?:\d{1,3}\.){3}\d{1,3}\b",
            ErrorMessage = "Enter a valid IPv4 address.")]
        public string IpAddress { get; set; } = string.Empty;

        [Required]
        [Range(0, 32)]
        public int PrefixLength { get; set; }
    }
}
