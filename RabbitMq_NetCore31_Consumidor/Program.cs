using System;

namespace RabbitMq_NetCore31_Consumidor
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("******* Recebendo mensagens **********");

            var consumidorRabbitMq = new ClienteRabbitMqConsumidor();
            consumidorRabbitMq.Consumir();

            Console.ReadKey();
        }
    }
}
