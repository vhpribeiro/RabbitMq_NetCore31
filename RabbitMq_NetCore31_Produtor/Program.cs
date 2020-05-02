using System;

namespace RabbitMq_NetCore31_Produtor
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("******* Enviando mensagens para o Rabbit **********");

            var clienteRabbitMq = new ClienteRabbitMq();

            for (var quantidadeDeMensagensProduzidas = 0;
                quantidadeDeMensagensProduzidas < 100000;
                quantidadeDeMensagensProduzidas++)
            {
                var mensagem =
                    $"Olá desenvolvedor esta é a mensagem número {quantidadeDeMensagensProduzidas}, enviada à {DateTime.Now}";

                clienteRabbitMq.Publicar(mensagem);

                Console.WriteLine("Enviando mensagem = {0}", mensagem);
            }

            Console.ReadKey();
        }
    }
}
