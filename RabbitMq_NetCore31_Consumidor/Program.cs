using System;

namespace RabbitMq_NetCore31_Consumidor
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("******* Recebendo mensagens **********");

            var clienteRabbitMq = new ClienteRabbitMq();
            clienteRabbitMq.Consumir();

            Console.ReadKey();
        }
    }
}
