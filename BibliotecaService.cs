using System;
using System.Collections.Generic;
using System.Linq;
using AulaPOO.Models;

namespace AulaPOO.Services
{
    public class BibliotecaService
    {
        private List<Livro> _livros;
        private List<Usuario> _usuarios;
        private List<Emprestimo> _emprestimos; // Exercício 2 e 4

        // Expõe as listas para o relatório
        public IReadOnlyList<Livro> Livros => _livros;
        public IReadOnlyList<Usuario> Usuarios => _usuarios;
        public IReadOnlyList<Emprestimo> Emprestimos => _emprestimos;

        public BibliotecaService()
        {
            _livros = new List<Livro>();
            _usuarios = new List<Usuario>();
            _emprestimos = new List<Emprestimo>();
        }

        public void AdicionarLivro(Livro livro)
        {
            _livros.Add(livro);
            Console.WriteLine($"Livro '{livro.Titulo}' adicionado à biblioteca");
        }

        public void AdicionarUsuario(Usuario usuario)
        {
            _usuarios.Add(usuario);
            Console.WriteLine($"Usuário '{usuario.Nome}' registrado na biblioteca");
        }

        // Exercício 2: Empréstimo com prazo de devolução
        public Emprestimo? RealizarEmprestimo(string isbn, string usuarioNome, int diasPrazo = 14)
        {
            var livro = _livros.Find(l => l.ISBN == isbn);
            var usuario = _usuarios.Find(u => u.Nome == usuarioNome);

            if (livro == null) { Console.WriteLine("Livro não encontrado!"); return null; }
            if (usuario == null) { Console.WriteLine("Usuário não encontrado!"); return null; }

            livro.Emprestar();
            if (!livro.Disponivel)
            {
                usuario.AdicionarLivro(livro);
                var emprestimo = new Emprestimo(livro, usuario, diasPrazo);
                _emprestimos.Add(emprestimo);
                Console.WriteLine($"Prazo de devolução: {emprestimo.DataPrevistaDevolucao:dd/MM/yyyy}");
                return emprestimo;
            }
            return null;
        }

        // Exercício 2: Devolução com validação de data
        public void RealizarDevolucao(string isbn, string usuarioNome)
        {
            var emprestimo = _emprestimos
                .FirstOrDefault(e => e.Livro.ISBN == isbn
                                  && e.Usuario.Nome == usuarioNome
                                  && !e.Devolvido);

            if (emprestimo == null)
            {
                Console.WriteLine("Empréstimo ativo não encontrado.");
                return;
            }

            emprestimo.RegistrarDevolucaoHoje();
            emprestimo.Livro.Devolver();
            emprestimo.Usuario.RemoverLivro(emprestimo.Livro);
        }

        // Exercício 3: Busca de livros por autor
        public void BuscarPorAutor(string autor)
        {
            Console.WriteLine($"\n=== LIVROS DE: {autor.ToUpper()} ===");
            var encontrados = _livros.Where(l =>
                l.Autor.Contains(autor, StringComparison.OrdinalIgnoreCase)).ToList();

            if (encontrados.Count == 0)
            {
                Console.WriteLine("Nenhum livro encontrado para este autor.");
                return;
            }

            foreach (var livro in encontrados)
                livro.ExibirInformacoes();
        }

        // Exercício 4: Lista empréstimos em atraso com multa
        public void ListarEmprestimosEmAtraso()
        {
            Console.WriteLine("\n=== EMPRÉSTIMOS EM ATRASO ===");
            var atrasados = _emprestimos
                .Where(e => !e.Devolvido && e.DiasAtraso() > 0)
                .OrderByDescending(e => e.DiasAtraso())
                .ToList();

            if (!atrasados.Any())
            {
                Console.WriteLine("Nenhum empréstimo em atraso.");
                return;
            }

            foreach (var e in atrasados)
            {
                Console.WriteLine($"  [{e.DiasAtraso()} dia(s)] {e.Livro.Titulo} — {e.Usuario.Nome} — Multa: R$ {e.CalcularMulta():F2}");
            }
        }

        public void ListarTodosLivros()
        {
            Console.WriteLine("\n=== ACERVO DA BIBLIOTECA ===");
            foreach (var livro in _livros)
                livro.ExibirInformacoes();
        }

        public void ListarUsuarios()
        {
            Console.WriteLine("\n=== USUÁRIOS CADASTRADOS ===");
            foreach (var usuario in _usuarios)
            {
                Console.WriteLine($"- {usuario.Nome} ({usuario.Email})");
                if (usuario is UsuarioPremium premium)
                    Console.WriteLine($"  [Premium] Desconto: {premium.Desconto:P}");
            }
        }
    }
}
