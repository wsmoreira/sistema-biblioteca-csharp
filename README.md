# Aula POO em C# - Sistema de Biblioteca

Projeto desenvolvido para a aula de **Programação Orientada a Objetos (POO)** em C#.

## 📚 Sobre o Projeto

Sistema de gerenciamento de biblioteca que demonstra os principais conceitos de POO:

| Conceito | Implementação |
|---|---|
| **Classe** | `Livro`, `Usuario`, `Revista`, `DVD` |
| **Encapsulamento** | `Usuario` com propriedades privadas e validação |
| **Herança** | `UsuarioPremium` herda de `Usuario` |
| **Polimorfismo** | `AdicionarLivro` sobrescrito em `UsuarioPremium` |
| **Interface** | `IEmprestavel` implementada por `Revista` e `DVD` |
| **Classe Abstrata** | `ItemBiblioteca` com método abstrato `CalcularMulta` |

## 🗂️ Estrutura do Projeto

```
AulaPOO/
├── Interfaces/
│   └── IEmprestavel.cs        # Interface para itens emprestáveis
├── Models/
│   ├── ItemBiblioteca.cs      # Classe abstrata base
│   ├── Livro.cs               # Modelo de livro
│   ├── Revista.cs             # Implementa IEmprestavel
│   ├── DVD.cs                 # Exercício 1 - Implementa IEmprestavel
│   ├── Usuario.cs             # Usuário com encapsulamento
│   └── UsuarioPremium.cs      # Herança de Usuario
├── Services/
│   └── BibliotecaService.cs   # Serviço com lógica de negócio
├── Program.cs                 # Programa principal
└── AulaPOO.csproj
```

## 🚀 Como Executar

**Pré-requisitos:** .NET SDK 6.0 ou superior instalado.

```bash
# Clone o repositório
git clone https://github.com/SEU_USUARIO/AulaPOO.git
cd AulaPOO

# Execute o projeto
dotnet run
```

## ✅ Exercícios Implementados

- **Exercício 1:** Classe `DVD` implementando `IEmprestavel`
- **Exercício 3:** Método `BuscarPorAutor` em `BibliotecaService`

## 🎓 Conceitos Aprendidos

- **Abstração:** Modelagem de entidades do mundo real (Livro, Usuário)
- **Encapsulamento:** Campos privados com propriedades e validação
- **Herança:** `UsuarioPremium` reutiliza e estende `Usuario`
- **Polimorfismo:** Sobrescrita de métodos para comportamentos diferentes
- **Interfaces:** Contrato `IEmprestavel` para tipos distintos
- **Classes Abstratas:** `ItemBiblioteca` como base para o acervo
