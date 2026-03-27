# 📚 Sistema de Gerenciamento de Biblioteca — C#

Aplicação console desenvolvida em **C# com .NET 6** que simula um sistema de gerenciamento de biblioteca, criada para demonstrar na prática os pilares da **Programação Orientada a Objetos (POO)**.

---

## 🧠 Conceitos de POO Demonstrados

| Conceito | Implementação |
|---|---|
| **Encapsulamento** | `Usuario` com campos privados e validação nas propriedades |
| **Herança** | `UsuarioPremium` estende `Usuario` |
| **Polimorfismo** | `AdicionarLivro` sobrescrito em `UsuarioPremium` |
| **Abstração** | Classe abstrata `ItemBiblioteca` |
| **Interface** | `IEmprestavel` implementada por `Revista` e `DVD` |
| **Camada de Serviço** | `BibliotecaService` separa a lógica de negócio dos modelos |

---

## ✨ Funcionalidades

- Cadastro e gerenciamento de livros, revistas e DVDs
- Cadastro de usuários comuns e premium
- Sistema de empréstimos com **validação de data de devolução**
- **Cálculo de multa** por atraso na devolução (R$ 1,50/dia)
- Busca de livros por autor
- Relatório estatístico: taxa de disponibilidade, usuário mais ativo, total de multas e mais

---

## 🗂️ Estrutura do Projeto

```
library-management-csharp/
├── Interfaces/
│   └── IEmprestavel.cs        # Contrato para itens emprestáveis
├── Models/
│   ├── ItemBiblioteca.cs      # Classe abstrata base
│   ├── Livro.cs               # Modelo de livro
│   ├── Revista.cs             # Revista — implementa IEmprestavel
│   ├── DVD.cs                 # DVD — implementa IEmprestavel
│   ├── Emprestimo.cs          # Entidade de empréstimo com prazo e multa
│   ├── Usuario.cs             # Usuário com campos encapsulados
│   └── UsuarioPremium.cs      # Usuário premium — herda de Usuario
├── Services/
│   ├── BibliotecaService.cs   # Lógica principal de negócio
│   └── BibliotecaRelatorio.cs # Relatórios estatísticos
├── Program.cs                 # Ponto de entrada
└── library-management-csharp.csproj
```

---

## 🚀 Como Executar

**Pré-requisito:** [.NET SDK 6.0+](https://dotnet.microsoft.com/download) instalado.

```bash
# Clone o repositório
git clone https://github.com/wsmoreira/library-management-csharp.git
cd library-management-csharp

# Execute a aplicação
dotnet run
```

---

## 📊 Exemplo de Saída

```
--- Cadastrando Livros ---
Livro 'Clean Code' adicionado à biblioteca

--- Exercício 2: Empréstimos com Prazo de Devolução ---
Livro 'Clean Code' emprestado com sucesso!
Prazo de devolução: 10/04/2025

--- Exercício 4: Resumo dos Empréstimos ---
Livro:            Clean Code
Status:           Em aberto (13 dia(s) restante(s))

╔══════════════════════════════════════╗
║      RELATÓRIO DA BIBLIOTECA         ║
╚══════════════════════════════════════╝
  Total de livros:        5
  Disponíveis:            3 (60.0%)
  Autor mais presente:    Robert C. Martin
  Total de multas:        R$ 0,00
```

---

## 🛠️ Tecnologias

- **Linguagem:** C# 10
- **Framework:** .NET 6
- **Paradigma:** Programação Orientada a Objetos
- **IDE:** Visual Studio Code

---

## 👨‍💻 Autor

Desenvolvido por **Wellington Moreira ** — conecte-se no [LinkedIn]www.linkedin.com/in/wellingtonmoreira98 ou veja outros projetos no meu GitHub.
