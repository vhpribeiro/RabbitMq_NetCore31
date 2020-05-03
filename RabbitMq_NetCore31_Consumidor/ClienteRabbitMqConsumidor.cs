using System;
using System.Text;
using Newtonsoft.Json;
using RabbitMQ.Client;
using RabbitMQ.Client.Events;

namespace RabbitMq_NetCore31_Consumidor
{
    public class ClienteRabbitMqConsumidor
    {
        private const string UrlRabbitMq = "amqp://guest:guest@localhost:5672";
        private const string NomeDaFila = "RabbitMq-NetCore31-POC";
        private readonly IModel _modelo;

        public ClienteRabbitMqConsumidor()
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
                var mensagemDaFila = Encoding.UTF8.GetString(corpo);

                if (!string.IsNullOrWhiteSpace(mensagemDaFila))
                {
                    var inscricao = JsonConvert.DeserializeObject<InscricaoDto>(mensagemDaFila);
                    _modelo.BasicAck(evento.DeliveryTag, true);
                    Console.WriteLine("Recebeu a inscrição de {0} de CPF {1} com o número {2} às {3}.", inscricao.NomeDoTitular,
                        inscricao.CpfDoTitular, inscricao.NumeroDoSorteio, DateTime.Now);
                }
                
            };

            _modelo.BasicConsume(NomeDaFila, false, consumidor);
        }
    }
}