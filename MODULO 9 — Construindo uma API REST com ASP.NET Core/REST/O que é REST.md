REST é a sigla para **Representational State Transfer**. É um estilo arquitetural para comunicação entre sistemas distribuídos, especialmente aplicado no desenvolvimento de APIs web.

### Principais Características do REST:
- **Baseado em HTTP:** Utiliza os métodos HTTP (GET, POST, PUT, DELETE, etc.) para realizar operações sobre os recursos.
- **Recursos:** Os dados ou entidades (ex: usuários, produtos) são tratados como recursos, cada um identificado por uma URL única.
- **Representações:** O recurso pode ser representado em diferentes formatos, sendo o JSON o mais comum atualmente.
- **Stateless:** Cada requisição do cliente para o servidor deve conter todas as informações necessárias para processar a solicitação. O servidor não armazena nada sobre o estado do cliente entre as requisições.
- **Cacheable:** Respostas podem ser explicitamente rotuladas como cacheáveis ou não-cacheáveis para melhorar a performance.
- **Interface Uniforme:** A comunicação entre cliente e servidor segue um padrão previsível.

### Exemplo prático de URLs RESTful:
```
GET    /api/livros         // retorna uma lista de livros
GET    /api/livros/1       // retorna o livro de id 1
POST   /api/livros         // cria um novo livro
PUT    /api/livros/1       // atualiza o livro de id 1
PATH   /api/livros/1       // atualiza parte do conteudo do livro de id 1
DELETE /api/livros/1       // remove o livro de id 1
```

### Resumindo:
REST define um conjunto de boas práticas para padronizar a criação de APIs, tornando a comunicação mais simples, escalável e fácil de entender.