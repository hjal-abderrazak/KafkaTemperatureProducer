using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KafkaTemperatureProducer
{
    internal class MachineDetails
    {
        public Guid Id { get; set; }
        public Guid MachineId { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string Temperature { get; set; }
        public string NiveauCo2 { get; set; }
        public DateTime TemperatureDate { get; set; }
        public MachineDetails() { }

    }
}
