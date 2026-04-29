HTTP é a sigla para **HyperText Transfer Protocol** (Protocolo de Transferência de Hipertexto). É um protocolo de comunicação usado para transferir dados entre clientes (como navegadores) e servidores na web. Ele define como as requisições e respostas devem ser feitas, utilizando uma estrutura padronizada de mensagens e verbos (GET, POST, PUT, DELETE, etc.). 

O HTTP opera, por padrão, na porta 80.

---

**HTTPS** é a versão segura do HTTP, cuja sigla significa **HyperText Transfer Protocol Secure**. Ele utiliza criptografia (SSL/TLS) para proteger os dados transmitidos entre o cliente e o servidor, garantindo confidencialidade e integridade das informações. O HTTPS opera geralmente na porta 443.

Principais diferenças:
- **HTTP:** Comunicação sem criptografia. É mais sujeito a ataques do tipo interceptação (man-in-the-middle).
- **HTTPS:** Comunicação criptografada, garantindo segurança na troca de informações (especialmente importante para dados sensíveis como senhas, cartões de crédito, etc).

Resumindo:  
- **HTTP**: protocolo de comunicação básica da web, sem segurança.
- **HTTPS**: versão segura do HTTP, usando criptografia para proteger a comunicação.


### Métodos HTTP

Os métodos (ou verbos) HTTP são essenciais para definir ações que o cliente deseja realizar sobre os recursos no servidor. Abaixo estão os principais métodos:

- **GET**  
  Utilizado para recuperar/consultar informações de um recurso.  
  Exemplo: Buscar a lista de usuários ou o detalhe de um produto.
  
  ```
  GET /api/produtos
  GET /api/produtos/1
  ```
  *Não deve alterar dados no servidor.*

- **POST**  
  Usado para criar um novo recurso.  
  Exemplo: Adicionar um novo usuário ou criar um novo item em uma lista.
  
  ```
  POST /api/produtos
  // Corpo da requisição (body): dados do novo produto
  ```

- **PUT**  
  Serve para atualizar um recurso existente substituindo-o completamente (ou criar caso não exista, dependendo da implementação).  
  Exemplo: Atualizar todas as informações de um produto já cadastrado.
  
  ```
  PUT /api/produtos/1
  // Corpo da requisição (body): dados completos do produto atualizado
  ```

- **DELETE**  
  Utilizado para remover um recurso.  
  Exemplo: Excluir um produto do sistema.
  
  ```
  DELETE /api/produtos/1
  ```

- **PATCH**  
  Serve para atualizar parcialmente um recurso existente.  
  Exemplo: Alterar só o preço de um produto.
  
  ```
  PATCH /api/produtos/1
  // Corpo da requisição (body): campos que deseja modificar (ex: {"preco": 10.0})
  ```

Esses métodos seguem a ideia central de recursos do HTTP: cada recurso é acessado por uma URL e manipulado usando o método apropriado.
Cada um deles deve ser utilizado conforme a ação desejada, seguindo as boas práticas do desenvolvimento de APIs RESTful.



### Todos os Verbos HTTP

Aqui estão os principais verbos (ou métodos) HTTP e seus usos:

- **GET** — Recupera dados de um recurso.
- **POST** — Cria um novo recurso.
- **PUT** — Atualiza completamente um recurso existente ou cria se não existir.
- **PATCH** — Atualiza parcialmente um recurso existente.
- **DELETE** — Remove um recurso.
- **HEAD** — Recupera somente os headers de uma resposta, sem o corpo (body).
- **OPTIONS** — Recupera os métodos HTTP suportados para uma URL ou recurso.
- **TRACE** — Realiza um teste de loopback de uma mensagem (eco do que foi enviado).
- **CONNECT** — Estabelece um túnel para comunicação (usado em proxies, por exemplo).

Outros menos comuns, mas padronizados:
- **LINK** — Estabelece um relacionamento entre recursos.
- **UNLINK** — Remove um relacionamento entre recursos.

---

### Todos os Status Codes HTTP

Os códigos de status HTTP informam o resultado da requisição. Abaixo estão os principais (os 5 grupos), com exemplos comuns:

**1xx — Informacional**
- 100 Continue
- 101 Switching Protocols
- 102 Processing

**2xx — Sucesso**
- 200 OK
- 201 Created
- 202 Accepted
- 203 Non-Authoritative Information
- 204 No Content
- 205 Reset Content
- 206 Partial Content
- 207 Multi-Status
- 208 Already Reported
- 226 IM Used

**3xx — Redirecionamento**
- 300 Multiple Choices
- 301 Moved Permanently
- 302 Found
- 303 See Other
- 304 Not Modified
- 305 Use Proxy
- 307 Temporary Redirect
- 308 Permanent Redirect

**4xx — Erro do Cliente**
- 400 Bad Request
- 401 Unauthorized
- 402 Payment Required
- 403 Forbidden
- 404 Not Found
- 405 Method Not Allowed
- 406 Not Acceptable
- 407 Proxy Authentication Required
- 408 Request Timeout
- 409 Conflict
- 410 Gone
- 411 Length Required
- 412 Precondition Failed
- 413 Payload Too Large
- 414 URI Too Long
- 415 Unsupported Media Type
- 416 Range Not Satisfiable
- 417 Expectation Failed
- 418 I'm a teapot
- 422 Unprocessable Entity
- 423 Locked
- 424 Failed Dependency
- 426 Upgrade Required
- 428 Precondition Required
- 429 Too Many Requests
- 431 Request Header Fields Too Large
- 451 Unavailable For Legal Reasons

**5xx — Erro do Servidor**
- 500 Internal Server Error
- 501 Not Implemented
- 502 Bad Gateway
- 503 Service Unavailable
- 504 Gateway Timeout
- 505 HTTP Version Not Supported
- 506 Variant Also Negotiates
- 507 Insufficient Storage
- 508 Loop Detected
- 510 Not Extended
- 511 Network Authentication Required

> Existem outros códigos menos comuns, mas estes são os principais encontrados no dia a dia do desenvolvimento de APIs Web.