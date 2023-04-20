using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KafkaTemperatureProducer
{
    public class Machine
    {
        public Guid Id { get; set; }
        public String Name { get; set; }
        public string Description { get; set; }
        public string MaxTemperature { get; set; }
        public string MinTemperature { get; set; }
        public Guid ChaineId { get; set; }
        public Machine() { }
    }
}
