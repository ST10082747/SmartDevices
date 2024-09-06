using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmartDevices
{
    public class SmartDevice
    {
        public string Name { get; set; }
        public string Status { get; set; } 

        public SmartDevice(string name, string status)
        {
            Name = name;
            Status = status;
        }

        public override string ToString()
        {
            return $"{Name} - {Status}";
        }
    }

}
