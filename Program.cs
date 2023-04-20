using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System;
using System.Threading.Tasks;
using Confluent.Kafka;
using Newtonsoft.Json;

namespace KafkaTemperatureProducer
{
    class Program
    {
        static async Task Main(string[] args)
        {
            var config = new ProducerConfig { BootstrapServers = "localhost:9092" };
            var builder = new ProducerBuilder<string, string>(config);
            var machineId = Guid.NewGuid();
            using (var producer = builder.Build())
            {
                string topic = "temperature-readings";
                Random random = new Random();

                while(true)
                {
                    // Generate a random temperature reading between 0 and 100 degrees Fahrenheit.
                    int temperature = random.Next(20, 101);
                    int niveauCo2 = random.Next(50,100);
                    //initialisation de machine details
                    var machineDetails = new MachineDetails
                    {
                        Id = Guid.NewGuid(),
                        Description = "machine de la chaine de production 1",
                        MachineId = machineId,
                        Name = "machine 1",
                        Temperature = temperature.ToString(),
                        TemperatureDate = DateTime.UtcNow,
                        NiveauCo2 = niveauCo2.ToString()
                    };
                    var jsonResult = JsonConvert.SerializeObject(machineDetails);

                    // Create a message with the temperature reading as the value.
                    var message = new Message<string, string> { Value = jsonResult };

                    // Send the message to the Kafka topic.
                    var result = await producer.ProduceAsync(topic, message);

                    Console.WriteLine($"Sent temperature reading {temperature} ");

                    // Wait for 5 seconds before sending the next temperature reading.
                    await Task.Delay(5000);
                }

            }

        }
    }

}
