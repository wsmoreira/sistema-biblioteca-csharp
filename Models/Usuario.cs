using System;
using System.Collections.Generic;

namespace AulaPOO.Models
{
    public class Usuario
    {
        // Atributos privados
        private string _nome;
        private int _idade;
        private List<Livro> _livrosEmprestados;

        // Propriedades com validação (Encapsulamento)
        public string Nome
        {
            get { return _nome; }
            set
            {
                if (string.IsNullOrWhiteSpace(value))
                    throw new ArgumentException("Nome não pode ser vazio!");
                _nome = value;
            }
        }

        public int Idade
        {
            get { return _idade; }
            set
            {
                if (value < 0 || value > 150)
                    throw new ArgumentException("Idade inválida!");
                _idade = value;
            }
        }

        public string Email { get; set; }
        public string Telefone { get; set; }

        // Propriedade somente leitura
        public int QuantidadeLivrosEmprestados => _livrosEmprestados.Count;

        // Construtor
        public Usuario(string nome, int idade, string email)
        {
            Nome = nome;
            Idade = idade;
            Email = email;
            _livrosEmprestados = new List<Livro>();
        }

        // Métodos públicos
        public virtual void AdicionarLivro(Livro livro)
        {
            if (QuantidadeLivrosEmprestados < 3)
            {
                _livrosEmprestados.Add(livro);
                Console.WriteLine($"Livro '{livro.Titulo}' adicionado ao usuário {Nome}");
            }
            else
            {
                Console.WriteLine($"Usuário {Nome} já atingiu o limite de 3 livros!");
            }
        }

        public void RemoverLivro(Livro livro)
        {
            if (_livrosEmprestados.Remove(livro))
            {
                Console.WriteLine($"Livro '{livro.Titulo}' removido do usuário {Nome}");
            }
        }

        public void ListarLivros()
        {
            Console.WriteLine($"\n--- Livros emprestados por {Nome} ---");
            if (_livrosEmprestados.Count == 0)
            {
                Console.WriteLine("Nenhum livro emprestado.");
                return;
            }
            foreach (var livro in _livrosEmprestados)
            {
                Console.WriteLine($"- {livro.Titulo} por {livro.Autor}");
            }
        }
    }
}
