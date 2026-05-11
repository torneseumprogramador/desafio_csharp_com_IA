Separação de responsabilidades, ou Separation of Concerns (SoC), é um princípio fundamental de arquitetura de software que busca dividir um sistema em partes distintas, onde cada parte tem uma responsabilidade bem definida e limitada. Em projetos C#, isso significa estruturar sua aplicação de forma que cada módulo, classe ou camada realize apenas uma tarefa específica do sistema.

### Por que separar responsabilidades?

- **Manutenção facilitada:** Alterações em uma responsabilidade não afetam outras partes do sistema.
- **Testabilidade:** Partes menores e desacopladas são mais fáceis de testar.
- **Reutilização:** Componentes com responsabilidades bem definidas podem ser reutilizados em outros contextos.
- **Evolução do sistema:** Fica mais simples adicionar ou modificar funcionalidades sem causar efeitos indesejados em outras áreas.

### Como aplicar em projetos C#

Em aplicações C#, a separação de responsabilidades geralmente é feita utilizando camadas, tais como:

- **Controllers:** Responsáveis por receber as requisições HTTP, chamar serviços e retornar respostas.
- **Services:** Camada onde ficam as regras de negócio da aplicação.
- **Repositories:** Responsáveis pelo acesso a dados, sejam em memória, banco de dados relacional, etc.
- **DTOs (Data Transfer Objects):** Objetos usados para transportar dados entre camadas, evitando o acoplamento entre modelos de domínio e a camada de apresentação.
- **Validation:** Camada para validações customizadas, como atributos (`Attribute`) para validação de CPF, e-mails, etc.

Exemplo de separação:

- `Controllers/ClienteController.cs` – Recebe requisições e delega para o serviço
- `Services/Clientes/ClienteService.cs` – Trata as regras de negócio de clientes
- `Repositories/Clientes/ClienteRepository.cs` – Gerencia acesso e persistência de dados de clientes
- `DTOs/ClienteRequestDto.cs` e `DTOs/ClienteResponseDto.cs` – Definem os dados que trafegam na API
- `Validation/ValidCpfAttribute.cs` – Valida CPF ao receber dados

Assim, cada parte da aplicação tem uma única responsabilidade clara, promovendo um código mais limpo, organizado e de fácil manutenção.

