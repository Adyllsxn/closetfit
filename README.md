# CLOSETFIT
O ClosetFit é uma plataforma moderna e intuitiva para explorar e gerenciar roupas e calçados. Com um design minimalista e funcional, permite que os usuários encontrem e cadastrem peças de vestuário e calçados de forma rápida e organizada.

> **Slogan**: "O teu estilo, organizado num só lugar."
---

## Funcionalidades

---

## Estrutura do Projeto

A estrutura do projeto segue uma organização modular e de fácil manutenção:

```plaintext
📂 ClosetFit/
│
├── 📁 .github/                        # ⚙️ Configuração para GitHub Actions e workflows
│   ├── 📁 workflows/                    # 🤖 Automação (ex: CI/CD, GitHub Pages)
│   
├── 📁 docs/                           # 📖 Documentação adicional do projeto
│   ├── 📁 project/                      # 🏗️ Detalhes sobre a arquitetura do projeto
│   ├── 📁 tech/                         # 📑 Documentação técnica (ex: API, contratos)
│   ├── 📁 visual/                       # 🎨 Recursos visuais da documentação
│   │   ├── 📁 diagrams/                    # 🖼️ Diagramas UML e de arquitetura
│   │   ├── 📁 wireframes/                  # 📝 Protótipos de telas (wireframes)
│   
├── 📂 src/                            # 💻 Código-fonte principal
│   ├── 📁 backend/                      # 🛠️ Código do backend
│   │   ├── 📁 ClosetFit.Presentation/      # 🌍 Camada de apresentação (API)
│   │   ├── 📁 ClosetFit.Application/       # 📜 Regras de negócios e serviços
│   │   ├── 📁 ClosetFit.Domain/            # 📦 Entidades de domínio e validações
│   │   ├── 📁 ClosetFit.Infrastructure/    # 🗄️ Acesso a dados e integração com o banco de dados
│   │   ├── 📁 ClosetFit.IoC/               # 🏗️ Configuração de injeção de dependências
│   ├── 📁 frontend/                    # 🖥️ Código do frontend
│   │   ├── 📁 ClosetFit.Web/             # 🎨 Interface do usuário (Blazor)
│   │
├── 📂 tests/                          # 🖥️ Código de testes
│   ├── 📁 ClosetFit.Test/s             # 🧪 Projetos de testes
│       ├── 📁 IntegrationTest/             # 🔍 Testes de unidade (isolados e rápidos)
│       ├── 📁 Unityest/                    # 🔗 Testes de integração (banco de dados em memória, API)
│
├── 📄 .gitignore                      # 🚫 Arquivo para ignorar arquivos desnecessários no Git
├── 📜 LICENSE                         # 📜 Licença do projeto
├── 📖 README.md                       # 🏠 Documentação principal do projeto
├── 🎯 LeiaJa.sln                      # 🛠️ Solução do projeto (.NET Solution)


## Licença

Este projeto está licenciado sob a Licença MIT - veja o arquivo [LICENSE](./LICENSE) para mais detalhes.
