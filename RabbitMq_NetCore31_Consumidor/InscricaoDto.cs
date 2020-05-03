using System;

namespace RabbitMq_NetCore31_Consumidor
{
    public class InscricaoDto
    {
        public Guid Id { get; set; }
        public int NumeroDoSorteio { get; set; }
        public string NomeDoTitular { get; set; }
        public string CpfDoTitular { get; set; }
    }
}