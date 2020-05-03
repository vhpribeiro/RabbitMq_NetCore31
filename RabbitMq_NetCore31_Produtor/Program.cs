using Bogus;
using Bogus.Extensions.Brazil;
using Newtonsoft.Json;
using System;

namespace RabbitMq_NetCore31_Produtor
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("******* Enviando mensagens para o Rabbit **********");

            var produtorRabbitMq = new ClienteRabbitMqProdutor();
            var faker = new Faker<InscricaoDto>("pt_BR");

            for (var quantidadeDeMensagensProduzidas = 0;
                quantidadeDeMensagensProduzidas < 100000;
                quantidadeDeMensagensProduzidas++)
            {
                var inscricao = faker.StrictMode(true)
                    .RuleFor(inscricao => inscricao.Id, new Guid())
                    .RuleFor(inscricao => inscricao.NumeroDoSorteio, quantidadeDeMensagensProduzidas)
                    .RuleFor(inscricao => inscricao.NomeDoTitular, f => f.Person.FullName)
                    .RuleFor(inscricao => inscricao.CpfDoTitular, f => f.Person.Cpf()).Generate();
                var mensagem = JsonConvert.SerializeObject(inscricao);

                produtorRabbitMq.Publicar(mensagem);

                Console.WriteLine("Enviando inscrição de {0} de CPF {1} com o número {2} às {3}.", inscricao.NomeDoTitular,
                    inscricao.CpfDoTitular, inscricao.NumeroDoSorteio,DateTime.Now);
            }

            Console.ReadKey();
        }
    }
}
