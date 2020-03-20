using System;
using System.Collections.Generic;
using System.CommandLine;
using System.CommandLine.Invocation;
using Amazon.EC2;
using Amazon.EC2.Model;
using Amazon.Util;

namespace EC2AssignIP
{
    class Program
    {
        static void Main(string publicIp = "")
        {
            if(string.IsNullOrEmpty(publicIp)){
                throw new Exception("Must provide a public IP to assign using --public-ip");
            }

            var client = new AmazonEC2Client();
            var instanceId = EC2InstanceMetadata.InstanceId;
            client.AssociateAddressAsync(new AssociateAddressRequest {
                 InstanceId = instanceId,
                 PublicIp = publicIp
            }).Wait();
            Console.WriteLine($"Finished assigning {publicIp} to {instanceId}");
        }
    }
}
