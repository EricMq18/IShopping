#  IShopping

O **IShopping** é uma aplicação desktop para a gestão de compras domésticas. O projeto foi desenhado para ser intuitivo e altamente personalizável, permitindo aos utilizadores gerir categorias de artigos, planear listas de compras, controlar gastos por impulso e exportar relatórios detalhados.

---

##  Grupo de Desenvolvimento

* **Eric Marques** - `2025185438`
* **Martim Duarte Borges** - `2025187810`
* **Dinis Dos Reis Gonçalves** - `2025135981`

*Disciplina: Desenvolvimento de Aplicações*

---

##  Tecnologias Utilizadas

* **IDE:** Visual Studio (com a carga de trabalho de desenvolvimento para desktop .NET)
* **Framework:** .NET Framework 4.8
* **ORM:** Entity Framework 6
* **Base de Dados / Armazenamento:** Dados pré-preenchidos (*Seed*) incluídos por padrão para testes rápidos.

---

##  Dados de Acesso (Padrão)

Para o primeiro acesso ao sistema, utilize as seguintes credenciais:

| Campo | Credencial |
| :--- | :--- |
| **Username** | `admin` |
| **Password** | `admin` |

>  **Nota:** Novos utilizadores podem ser registados livremente através do formulário de autenticação da aplicação.

---

##  Requisitos e Como Executar

### Pré-requisitos
Certifique-se de que tem instalado na sua máquina:
* IDE Visual Studio com suporte para **desenvolvimento para desktop .NET**.

### Passos para Execução
1. **Clonar o repositório:**
   Faça o clone do repositório utilizando o Git para a sua máquina local através do URL do projeto.

2. **Abrir o projeto:**
   * No Visual Studio, vá a **Arquivo > Abrir > Projeto/Solução** (ou *File > Open > Project/Solution*).
   * Selecione o ficheiro `IShopping.sln`.

3. **Restaurar Pacotes NuGet:**
   * O Visual Studio deverá restaurar automaticamente o *Entity Framework 6*. Caso contrário, clique com o botão direito na Solução e selecione **Restore NuGet Packages**.

4. **Executar:**
   * Pressione `F5` ou clique no botão **Iniciar/Start** no Visual Studio.

---

##  Funcionalidades Principais

### 1. Autenticação e Segurança
* **Registo de Utilizadores:** Criação de novas contas diretamente no formulário de login.
* **Controlo de Acesso:** Login seguro associado ao perfil do utilizador.

### 2. Painel Principal (Dashboard)
* **Visualização Rápida:** Grelha central que lista de imediato as compras em aberto.
* **Navegação Estruturada:** Menu superior dividido estrategicamente em:
  * **Gestão:** Administração de Utilizadores, Tipos de Artigos, Artigos e Orçamentos.
  * **Compras:** Planeamento e gestão de carrinhos (separando artigos previstos de não previstos).
  * **Estatísticas:** Acesso a históricos e relatórios.

### 3. Gestão de Inventário e Carrinho
* **Artigos e Categorias:** Criação, edição e associação de produtos a categorias específicas.
* **Modo de Compra Inteligente:** Permite estipular quantidades e preços unitários, discriminando de forma clara os artigos planeados daqueles que foram adicionados por "impulso" na loja.

### 4. Exportação de Dados
* **Relatórios em CSV:** Exportação do histórico de compras num ficheiro estruturado (separado por ponto e vírgula `;`), totalmente compatível com o Microsoft Excel ou outras ferramentas de análise.
