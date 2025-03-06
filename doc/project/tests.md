┣ 📂 tests                        # Pasta principal de testes
 ┃ ┣ 📂 ClosetFit.Tests             # Projeto de testes
 ┃ ┃ ┣ 📂 UnitTests                 # 📌 Testes de unidade (isolados e rápidos)
 ┃ ┃ ┃ ┣ 📂 Application             # Testes para serviços e casos de uso
 ┃ ┃ ┃ ┣ 📂 Domain                  # Testes para entidades e regras de negócio
 ┃ ┃ ┃ ┣ 📂 Infrastructure          # Testes para repositórios usando mocks
 ┃ ┃ ┣ 📂 IntegrationTests          # 🔄 Testes de integração (testam integração entre componentes)
 ┃ ┃ ┃ ┣ 📂 Infrastructure          # Testes com banco de dados real (SQLite em memória)
 ┃ ┃ ┃ ┣ 📂 API                     # Testes de endpoints da API usando WebApplicationFactory
 ┃ ┃ ┃ ┣ 📂 Services                # Testes de serviços que interagem com o banco de dados