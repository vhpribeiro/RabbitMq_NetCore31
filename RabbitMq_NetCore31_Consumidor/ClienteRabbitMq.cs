using System;
using System.Text;
using RabbitMQ.Client;
using RabbitMQ.Client.Events;

namespace RabbitMq_NetCore31_Consumidor
{
    public class ClienteRabbitMq
    {
        private const string UrlRabbitMq = "amqp://guest:guest@localhost:5672";
        private const string NomeDaFila = "RabbitMq-NetCore31-POC";
        private readonly IModel _modelo;

        public ClienteRabbitMq()
        {
            var conexao = CriarConexao();
            _modelo = conexao.CreateModel();
        }

        private static IConnection CriarConexao()
        {
            var conexaoFabrica = new ConnectionFactory
            {
                Uri = new Uri(UrlRabbitMq)
            };

            return conexaoFabrica.CreateConnection();
        }

        private static void ConfigurarFila(string nome, IModel modelo)
        {
            modelo.QueueDeclare(nome, false, false, false, null);
        }

        public void Consumir()
        {
            ConfigurarFila(NomeDaFila, _modelo);

            var consumidor = new EventingBasicConsumer(_modelo);
            consumidor.Received += (emissor, evento) =>
            {
                var corpo = evento.Body.ToArray();
                var mensagem = Encoding.UTF8.GetString(corpo);

                if (!string.IsNullOrWhiteSpace(mensagem))
                {
                    _modelo.BasicAck(@evento.DeliveryTag, true);
                }

                Console.WriteLine("Recebeu a mensagem = {0}", mensagem);
            };

            _modelo.BasicConsume(NomeDaFila, false, consumidor);
        }
    }
}