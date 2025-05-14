using System;
using System.Linq;
using System.Net;
using SubnetCalcWeb.Models;

namespace SubnetCalcWeb.Services
{
    public class SubnetCalculator : ISubnetCalculator
    {
        public SubnetResult Calculate(string ipAddress, int prefixLength)
        {
            // 1) Parse the input IP
            var ip = IPAddress.Parse(ipAddress);
            var ipBytes = ip.GetAddressBytes();  // e.g. [10,10,10,0]

            // 2) Build the mask bytes in network order
            byte[] maskBytes = Enumerable.Range(0, 4)
                .Select(i =>
                    prefixLength >= (i + 1) * 8
                        ? (byte)255                       // full‐1’s octet
                        : prefixLength <= i * 8
                            ? (byte)0                     // full‐0’s octet
                            : (byte)(~((1 << (8 - (prefixLength % 8))) - 1))
                )
                .ToArray();
            // e.g. for /24 → [255,255,255,0]

            // 3) Compute network address
            byte[] networkBytes = ipBytes
                .Zip(maskBytes, (b, m) => (byte)(b & m))
                .ToArray();
            var networkAddress = new IPAddress(networkBytes);

            // 4) Compute broadcast address
            byte[] broadcastBytes = networkBytes
                .Select((b, i) => (byte)(b | (maskBytes[i] ^ 0xFF)))
                .ToArray();
            var broadcastAddress = new IPAddress(broadcastBytes);

            // 5) Calculate host counts & usable range
            int totalHosts = (int)Math.Pow(2, 32 - prefixLength) - 2;

            var firstHostBytes = (byte[])networkBytes.Clone();
            firstHostBytes[3]++;
            var lastHostBytes = (byte[])broadcastBytes.Clone();
            lastHostBytes[3]--;

            string firstHost = new IPAddress(firstHostBytes).ToString();
            string lastHost  = new IPAddress(lastHostBytes).ToString();

            // 6) Return the result object
            return new SubnetResult
            {
                NetworkAddress   = networkAddress.ToString(),
                BroadcastAddress = broadcastAddress.ToString(),
                UsableRange      = $"{firstHost} – {lastHost}",
                TotalHosts       = totalHosts
            };
        }
    }
}
