# 📚 Leitura Livre

O **Leitura Livre** é uma aplicação web desenvolvida como projeto de extensão para promover o compartilhamento de livros entre moradores de Condomínios.
Com ela, os usuários podem cadastrar livros, visualizar obras disponíveis e solicitar empréstimos — tudo de forma simples, digital e colaborativa.

---

## 🚀 Tecnologias Utilizadas

- 🔧 **Backend:** ASP.NET Core (.NET 8)
- 🎨 **Frontend:** Angular 18
- Docker Desktop


## 🛠️ Como rodar o projeto

### 🔙 Backend (.NET)

1. Acesse a pasta `backend`:

- docker compose up --build -d
- o sistema irá carregar o backend e o banco de dados a para acessar o banco de dados usuario: leitura senha: admin


pgAdmin (opcional, para visualizar o banco)
2. Acesse a pasta `frontend`:

- cd frontend
- npm install
- ng serve
