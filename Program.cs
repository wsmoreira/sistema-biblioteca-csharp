using System;
using System.Collections.Generic;
using AulaPOO.Models;
using AulaPOO.Services;

Console.WriteLine("========================================");
Console.WriteLine("   SISTEMA DE BIBLIOTECA - POO em C#   ");
Console.WriteLine("========================================\n");

var biblioteca = new BibliotecaService();

// ========================
// Cadastrando Livros
// ========================
Console.WriteLine("--- Cadastrando Livros ---");
var livro1 = new Livro("Clean Code", "Robert C. Martin", "978-0132350884", 2008, 431);
var livro2 = new Livro("O Programador Pragmático", "Andrew Hunt", "978-8577807413", 1999, 352);
var livro3 = new Livro("Design Patterns", "Gang of Four", "978-0201633610", 1994, 395);
var livro4 = new Livro("Arquitetura Limpa", "Robert C. Martin", "978-8550804606", 2017, 432);
var livro5 = new Livro("C# em Profundidade", "Jon Skeet", "978-8550804699", 2019, 528);

biblioteca.AdicionarLivro(livro1);
biblioteca.AdicionarLivro(livro2);
biblioteca.AdicionarLivro(livro3);
biblioteca.AdicionarLivro(livro4);
biblioteca.AdicionarLivro(livro5);

// ========================
// Cadastrando Usuários
// ========================
Console.WriteLine("\n--- Cadastrando Usuários ---");
var usuario1 = new Usuario("João Silva", 25, "joao@email.com");
var usuario2 = new Usuario("Maria Santos", 30, "maria@email.com");
var usuarioPremium = new UsuarioPremium("Carlos Premium", 35, "carlos@email.com", 0.15m);

biblioteca.AdicionarUsuario(usuario1);
biblioteca.AdicionarUsuario(usuario2);
biblioteca.AdicionarUsuario(usuarioPremium);

// =========================================================
// Exercício 2: Empréstimos com validação de data de devolução
// =========================================================
Console.WriteLine("\n--- Exercício 2: Empréstimos com Prazo de Devolução ---");
var emp1 = biblioteca.RealizarEmprestimo("978-0132350884", "João Silva", diasPrazo: 14);
var emp2 = biblioteca.RealizarEmprestimo("978-8577807413", "Maria Santos", diasPrazo: 7);
var emp3 = biblioteca.RealizarEmprestimo("978-0201633610", "João Silva", diasPrazo: 14);

// Limite de 3 livros para usuário comum
biblioteca.RealizarEmprestimo("978-8550804606", "João Silva");

// Premium pode pegar até 5 livros
Console.WriteLine("\n--- Herança: Usuário Premium ---");
biblioteca.RealizarEmprestimo("978-8550804606", "Carlos Premium");
usuarioPremium.RenovarAssinatura();

// =========================================================
// Exercício 2: Devoluções com validação de data
// =========================================================
Console.WriteLine("\n--- Exercício 2: Devolução com Validação ---");
biblioteca.RealizarDevolucao("978-8577807413", "Maria Santos");
// Tentativa de devolver novamente (já devolvido)
biblioteca.RealizarDevolucao("978-8577807413", "Maria Santos");

// =========================================================
// Exercício 4: Resumo com multas
// =========================================================
Console.WriteLine("\n--- Exercício 4: Resumo dos Empréstimos ---");
if (emp1 != null) emp1.ExibirResumo();
if (emp3 != null) emp3.ExibirResumo();

Console.WriteLine("\n--- Exercício 4: Empréstimos em Atraso ---");
biblioteca.ListarEmprestimosEmAtraso();

// =========================================================
// Interface IEmprestavel - Revista e DVD (Ex. 1)
// =========================================================
Console.WriteLine("\n--- Interface IEmprestavel: Revista ---");
var revista = new Revista("Revista Programação", 42, 2024);
revista.Emprestar(usuario2);
revista.Devolver(usuario2);
Console.WriteLine($"Revista disponível: {revista.VerificarDisponibilidade()}");

Console.WriteLine("\n--- Exercício 1: DVD ---");
var dvd = new DVD("Matrix", "Wachowski", 1999, 136);
dvd.Emprestar(usuario1);
dvd.ExibirInformacoes();
dvd.Devolver(usuario1);

// =========================================================
// Exercício 3: Busca por autor
// =========================================================
Console.WriteLine("\n--- Exercício 3: Busca por Autor ---");
biblioteca.BuscarPorAutor("Robert C. Martin");

// =========================================================
// Exercício 5: Relatório estatístico
// =========================================================
var relatorio = new BibliotecaRelatorio(
    new List<Livro>(biblioteca.Livros),
    new List<Usuario>(biblioteca.Usuarios),
    new List<Emprestimo>(biblioteca.Emprestimos)
);
relatorio.ExibirRelatorioCompleto();

Console.WriteLine("\n========================================");
Console.WriteLine("  Todos os exercícios implementados!   ");
Console.WriteLine("========================================");
