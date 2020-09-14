# RabbitMq_NetCore31

## Objetivo
Criar um projeto de exemplo para praticar o RabbitMq. Esse projeto teve como base o texto: https://medium.com/@rodolfostopinto97/poc-net-core-rabbitmq-f1fb5d8eb58b
E após desenvolver essa POC, também resolvi escrever um artigo onde relato como foi o desenvolvimento do projeto: https://medium.com/@vitorpereiraribeiro_40127/rabbitmq-com-net-core-3-1-um-pequeno-teste-cddf5b3b8f37

## Contexto da solução
Vamos supor que estamos desenvolvendo um sistema que faz sorteio de casas habitacionais, e o nosso produtor deve enviar as inscrições das pessoas que querem participar desse sorteio para o nosso consumidor que irá fazer todo o processo de sorteio.

### Funcionamento
Para subir a estrtura do Rabbit, basta dar um `docker-compose up` na raiz do projeto, isso irá subir um container com toda a estrutura do Rabbit e da UI dele.
- Porta `5672` se encontra o Rabbit
- Porta `15672` se encontra a UI, onde para acessá-la basta colocar `guest` no _Login_ e `guest` no _Password_.

Feito isso, basta executar o _Produtor_, onde o mesmo irá produzir 100000 mensagens e depois executar o _Consumidor_ que irá consumir tais mensagens.
