# IShopping

### Grupo:
Eric Marques `2025185438`\
Martim Duarte Borges `2025187810`\
Dinis Dos Reis Gonçalves `2025135981`
-------------------

Desenvolvimento de Aplicações

## Dados de Acesso por Padrão

Username: admin\
Password: admin\
Observação: Podem ser registados outros utilizadores para login.

## Descrição do Projeto

Este projeto consiste no desenvolvimento de uma aplicação de gestão de compras domésticas chamada **IShopping**.
Tem como objetivo ser um projeto de utilização genérica para qualquer utilizador, dando liberdade para personalizar as categorias de artigos, adicionar produtos, criar listas de compras e exportar os relatórios em formato CSV.

Por padrão, a aplicação já vem com dados pré-preenchidos (Seed), porém estes podem ser alterados à vontade do utilizador.

## Requisitos
- Visual Studio (com carga de trabalho para desktop .NET);
- .NET Framework 4.8;
- Entity Framework 6;
- Clonar o repositório;
- Abrir a Solução: No Visual Studio, vá em **Arquivo > Abrir > Projeto/Solução** e selecione o ficheiro `IShopping.sln`.

## Utilização

1. **Registo / Login**
   - A aplicação permite o registo de novos utilizadores no formulário de Autenticação.
   - Permite o login de utilizadores com as credenciais padrão ou com contas recém-criadas.

2. **Menu Principal**
   - Possui uma grelha central que lista e permite a visualização rápida de compras em aberto.
   - Possui uma barra de navegação no topo com as seguintes opções:
      - **Gestão:** Utilizadores, Tipos de Artigos, Artigos e Orçamentos.
      - **Compras:** Planeamento de Compras (Artigos previstos e não previstos).
      - **Estatísticas / Exportação:** Opção para exportar os históricos de compras diretamente para um relatório.

3. **Gestão de Inventário e Compras**
   - **Artigos e Categorias:** Permite criar, editar e associar artigos a tipos/categorias específicas.
   - **Modo de Compra:** Permite criar uma lista, estipular quantidades e preços unitários, discriminando os artigos planeados daqueles que foram adicionados por impulso em loja.
   - **Exportação de Dados:** Exporta os dados estruturados de compras num ficheiro separado por ponto e vírgula, compatível com Excel.
