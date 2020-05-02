# RabbitMq_NetCore31

## Objetivo
Criar um projeto de exemplo para praticar o RabbitMq. Esse projeto teve como base o texto: https://medium.com/@rodolfostopinto97/poc-net-core-rabbitmq-f1fb5d8eb58b

### Funcionamento
Para subir a estrtura do Rabbit, basta dar um `docker-compose up` na raiz do projeto, isso irá subir um container com toda a estrutura do Rabbit e da UI dele.
- Porta `5672` se encontra o Rabbit
- Porta `15672` se encontra a UI, onde para acessá-la basta colocar `guest` no _Login_ e `guest` no _Password_.

Feito isso, basta executar o _Produtor_, onde o mesmo irá produzir 100000 mensagens e depois executar o _Consumidor_ que irá consumir tais mensagens.