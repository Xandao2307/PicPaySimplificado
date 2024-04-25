# PicPay Simplificado

Este é um projeto de uma plataforma de pagamentos simplificada, denominada PicPay Simplificado. Nela, os usuários podem depositar dinheiro em suas carteiras e realizar transferências entre si, além de possibilitar o recebimento de pagamentos por parte dos lojistas.

## Requisitos

Aqui estão os principais requisitos e regras de negócio para o funcionamento do PicPay Simplificado:

- Cadastro de usuários com os seguintes dados obrigatórios: Nome Completo, CPF, E-mail e Senha. Os campos CPF/CNPJ e e-mail devem ser únicos no sistema, permitindo apenas um cadastro por CPF ou endereço de e-mail.

- Usuários podem enviar dinheiro, ou seja, realizar transferências, tanto para lojistas quanto entre outros usuários.

- Lojistas podem apenas receber transferências, não podendo enviar dinheiro para outros usuários.

- Antes de efetivar uma transferência, é necessário validar se o usuário remetente possui saldo suficiente em sua carteira.

- Durante o processo de transferência, é necessário consultar um serviço autorizador externo. Um mock deste serviço está disponível para simulação: [Mock Autorizador](https://run.mocky.io/v3/5794d450-d2e2-4412-8131-73d0293ac1cc).

- Todas as operações de transferência devem ser tratadas como transações, revertendo-se em caso de inconsistência, garantindo que o dinheiro retorne para a carteira do usuário remetente.

- Ao receber um pagamento, seja por parte de um usuário ou de um lojista, é necessário enviar uma notificação, podendo ser por e-mail, SMS ou outro meio. Um mock para simular o envio desta notificação está disponível em: [Mock de Envio de Notificação](https://run.mocky.io/v3/54dc2cf1-3add-45b5-b5a9-6bf7e7f1f4a6).

- O serviço desenvolvido deve ser RESTful.

## Tecnologias Utilizadas

Este projeto foi desenvolvido utilizando as seguintes tecnologias:

- **C# .NET**: Linguagem de programação utilizada para o desenvolvimento do backend.
  
- **Entity Framework**: Framework ORM utilizado para mapeamento objeto-relacional.
  
- **SQL Server**: Banco de dados relacional utilizado para armazenamento dos dados.
  
- **RabbitMQ**: Plataforma de mensageria utilizada para comunicação entre os diferentes componentes do sistema.
  
- **Docker**: Plataforma de containers utilizada para encapsular e distribuir a aplicação, incluindo os servidores de mensageria e banco de dados.

## Arquitetura Utilizada

Para o desenvolvimento deste projeto, foi adotada a arquitetura DDD (Domain-Driven Design) com Clean Architecture. Isso significa que a estrutura do projeto foi organizada de forma a refletir a linguagem ubíqua do domínio do negócio, isolando-o das camadas externas e garantindo uma alta coesão e baixo acoplamento entre os componentes.

## Configuração e Execução

Para executar este projeto localmente, siga os passos abaixo:

1. Clone este repositório em sua máquina local.
2. Certifique-se de ter o Docker instalado em seu sistema.
3. No terminal, navegue até o diretório raiz do projeto.
4. Execute o comando `docker-compose up` para iniciar os containers do RabbitMQ e do SQL Server.
5. Abra a solução do projeto em seu ambiente de desenvolvimento (Visual Studio, VS Code, etc.).
6. Execute a aplicação.

Após seguir estes passos, a aplicação estará em execução e pronta para ser testada.

## Conclusão

Este projeto implementa uma versão simplificada do PicPay, permitindo o depósito, transferência e recebimento de pagamentos entre usuários e lojistas. Utilizando tecnologias modernas e boas práticas de desenvolvimento, busca-se garantir a robustez, escalabilidade e manutenibilidade da aplicação.
