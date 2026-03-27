using System;
using System.Collections.Generic;
using System.Linq;
using AulaPOO.Models;

namespace AulaPOO.Services
{
    // Exercício 5: Classe com métodos estatísticos do acervo e empréstimos
    public class BibliotecaRelatorio
    {
        private readonly List<Livro> _livros;
        private readonly List<Usuario> _usuarios;
        private readonly List<Emprestimo> _emprestimos;

        public BibliotecaRelatorio(List<Livro> livros, List<Usuario> usuarios, List<Emprestimo> emprestimos)
        {
            _livros = livros;
            _usuarios = usuarios;
            _emprestimos = emprestimos;
        }

        // --- Estatísticas do Acervo ---

        public int TotalLivros() => _livros.Count;

        public int TotalLivrosDisponiveis() => _livros.Count(l => l.Disponivel);

        public int TotalLivrosEmprestados() => _livros.Count(l => !l.Disponivel);

        public double PercentualDisponibilidade() =>
            _livros.Count == 0 ? 0 : (double)TotalLivrosDisponiveis() / _livros.Count * 100;

        public double MediaPaginasPorLivro() =>
            _livros.Count == 0 ? 0 : _livros.Average(l => l.Paginas);

        public Livro? LivroMaisAntigo() =>
            _livros.OrderBy(l => l.AnoPublicacao).FirstOrDefault();

        public Livro? LivroMaisRecente() =>
            _livros.OrderByDescending(l => l.AnoPublicacao).FirstOrDefault();

        public string AutorMaisPresente()
        {
            if (!_livros.Any()) return "Nenhum livro cadastrado";
            return _livros
                .GroupBy(l => l.Autor)
                .OrderByDescending(g => g.Count())
                .First().Key;
        }

        // --- Estatísticas de Usuários ---

        public int TotalUsuarios() => _usuarios.Count;

        public int TotalUsuariosPremium() => _usuarios.OfType<UsuarioPremium>().Count();

        public Usuario? UsuarioComMaisLivros() =>
            _usuarios.OrderByDescending(u => u.QuantidadeLivrosEmprestados).FirstOrDefault();

        // --- Estatísticas de Empréstimos ---

        public int TotalEmprestimos() => _emprestimos.Count;

        public int EmprestimosAtivos() => _emprestimos.Count(e => !e.Devolvido);

        public int EmprestimosEncerrados() => _emprestimos.Count(e => e.Devolvido);

        public int EmprestimosEmAtraso() => _emprestimos.Count(e => !e.Devolvido && e.DiasAtraso() > 0);

        public decimal TotalMultasGeradas() => _emprestimos.Sum(e => e.CalcularMulta());

        public decimal MultasEmAberto() =>
            _emprestimos.Where(e => !e.Devolvido).Sum(e => e.CalcularMulta());

        public double MediaDiasEmprestimo()
        {
            var encerrados = _emprestimos.Where(e => e.Devolvido).ToList();
            if (!encerrados.Any()) return 0;
            return encerrados.Average(e =>
                (e.DataDevolucao!.Value - e.DataEmprestimo).TotalDays);
        }

        // --- Relatório Completo ---

        public void ExibirRelatorioCompleto()
        {
            Console.WriteLine("\n╔══════════════════════════════════════╗");
            Console.WriteLine("║      RELATÓRIO DA BIBLIOTECA         ║");
            Console.WriteLine($"║   Gerado em: {DateTime.Now:dd/MM/yyyy HH:mm}         ║");
            Console.WriteLine("╚══════════════════════════════════════╝");

            Console.WriteLine("\n📚 ACERVO");
            Console.WriteLine($"  Total de livros:        {TotalLivros()}");
            Console.WriteLine($"  Disponíveis:            {TotalLivrosDisponiveis()} ({PercentualDisponibilidade():F1}%)");
            Console.WriteLine($"  Emprestados:            {TotalLivrosEmprestados()}");
            Console.WriteLine($"  Média de páginas:       {MediaPaginasPorLivro():F0} pág.");
            Console.WriteLine($"  Autor mais presente:    {AutorMaisPresente()}");

            if (LivroMaisAntigo() != null)
                Console.WriteLine($"  Livro mais antigo:      {LivroMaisAntigo()!.Titulo} ({LivroMaisAntigo()!.AnoPublicacao})");
            if (LivroMaisRecente() != null)
                Console.WriteLine($"  Livro mais recente:     {LivroMaisRecente()!.Titulo} ({LivroMaisRecente()!.AnoPublicacao})");

            Console.WriteLine("\n👤 USUÁRIOS");
            Console.WriteLine($"  Total de usuários:      {TotalUsuarios()}");
            Console.WriteLine($"  Usuários premium:       {TotalUsuariosPremium()}");

            var top = UsuarioComMaisLivros();
            if (top != null && top.QuantidadeLivrosEmprestados > 0)
                Console.WriteLine($"  Mais ativo:             {top.Nome} ({top.QuantidadeLivrosEmprestados} livro(s))");

            Console.WriteLine("\n📋 EMPRÉSTIMOS");
            Console.WriteLine($"  Total registrados:      {TotalEmprestimos()}");
            Console.WriteLine($"  Ativos:                 {EmprestimosAtivos()}");
            Console.WriteLine($"  Encerrados:             {EmprestimosEncerrados()}");
            Console.WriteLine($"  Em atraso:              {EmprestimosEmAtraso()}");
            Console.WriteLine($"  Média dias empréstimo:  {MediaDiasEmprestimo():F1} dias");

            Console.WriteLine("\n💰 MULTAS");
            Console.WriteLine($"  Total gerado:           R$ {TotalMultasGeradas():F2}");
            Console.WriteLine($"  Em aberto:              R$ {MultasEmAberto():F2}");

            Console.WriteLine("\n══════════════════════════════════════");
        }
    }
}
