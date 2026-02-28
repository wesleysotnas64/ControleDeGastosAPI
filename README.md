# 💰 Controle de Gastos API

Bem-vindo ao **Controle de Gastos API**! Uma solução para gestão financeira pessoal. 🚀

---

### 🛠️ Tecnologias e Versões
* **Framework:** ⚡ .NET 10 (C#)
* **Banco de Dados:** 🐘 PostgreSQL 18 (Hospedado no render - Versão gratuita)
* **Documentação:** 📑 Scalar API Reference
* **Hospedagem:** ☁️ Render (Web Service - Versão gratuita)

---

### ⚙️ Como Rodar Localmente

1.  **Clone o repositório**
2.  **Configuração do Banco de Dados:**
    Na raiz do projeto, crie um arquivo chamado `.env` e adicione sua string de conexão preenchendo as credenciais:
    ```env
    CONNECTION_STRING="Host=seu_host;Port=seu_port;Database=seu_db;Username=seu_user;Password=sua_senha;SSL Mode=Require;Trust Server Certificate=true;"
    ```

3.  **Executar a Aplicação:**
    Certifique-se de ter o SDK do .NET 10 instalado e execute:
    ```bash
    dotnet run
    ```

---

### 🧪 Como Testar

O projeto utiliza o **Scalar** para documentação.

#### 📍 Opção 1: Teste Local
Após rodar o projeto, a documentação estará disponível em:
👉 [https://localhost:7154/scalar](https://localhost:7154/scalar) *(Verifique a porta no seu console)*

#### ☁️ Opção 2: Teste Online (Render)
Acesse a API publicada diretamente no Render, sem necessidade de configuração local:
👉 [https://controledegastosapi.onrender.com/scalar](https://controledegastosapi.onrender.com/scalar)
> ⚠️ **Nota importante:** Como estou utilizando a camada gratuita do Render, o servidor entra em "modo de espera" após algum tempo de inatividade. Por isso, a **primeira chamada** pode demorar entre 50 a 60 segundos para responder (o servidor está "acordando"). Após esse primeiro carregamento, a navegação será fluida! ☕

---

### 📸 Prints da Interface

#### Listagem de Categorias
<img width="1846" height="993" alt="image" src="https://github.com/user-attachments/assets/ed881b88-e4c8-4116-b12e-d0e1e6bd0c23" />
<img width="1840" height="994" alt="image" src="https://github.com/user-attachments/assets/12b1e524-9313-412a-96da-5aa9e61739a2" />
<img width="1847" height="986" alt="image" src="https://github.com/user-attachments/assets/ff223c95-60e3-42c0-94f2-ba8e9a88e139" />

> ⚠️ **Nota importante:** Estes passos anteriores só são necessários quando a API é acessada através do render. Se acessada localmente não precisa. ☕

<img width="1915" height="1031" alt="image" src="https://github.com/user-attachments/assets/f995be2a-5676-4113-8bf1-639c85e772ad" />
<img width="1847" height="995" alt="image" src="https://github.com/user-attachments/assets/56eb36b7-6ceb-4fb6-b631-ca48c3157765" />

---

## 📂 Estrutura do Projeto (Full Stack)

Este projeto faz parte de uma solução completa de gerenciamento financeiro. Para visualizar a interface e como os dados são consumidos, acesse o repositório do cliente:

👉 **Front-end (React + TypeScript):** [github.com/wesleysotnas64/controle-gastos-web](https://github.com/wesleysotnas64/controle-gastos-web)

---

## 🙏 Agradecimento

Obrigado por visitar este repositório!  
Acesse meu portfólio completo para conhecer outros projetos:

🔗 [wesleysantos.portfolio](https://wesley-santos-dev-portfolio.netlify.app/)
