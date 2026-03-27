using System;
using AulaPOO.Interfaces;

namespace AulaPOO.Models
{
    // Exercício 1: DVD implementando IEmprestavel
    public class DVD : IEmprestavel
    {
        public string Titulo { get; set; }
        public string Diretor { get; set; }
        public int Ano { get; set; }
        public int DuracaoMinutos { get; set; }
        public bool Disponivel { get; private set; }

        private Usuario? _usuarioAtual;

        public DVD(string titulo, string diretor, int ano, int duracao)
        {
            Titulo = titulo;
            Diretor = diretor;
            Ano = ano;
            DuracaoMinutos = duracao;
            Disponivel = true;
        }

        public void Emprestar(Usuario usuario)
        {
            if (Disponivel)
            {
                Disponivel = false;
                _usuarioAtual = usuario;
                Console.WriteLine($"DVD '{Titulo}' emprestado para {usuario.Nome}");
            }
            else
            {
                Console.WriteLine($"DVD '{Titulo}' não está disponível");
            }
        }

        public void Devolver(Usuario usuario)
        {
            if (!Disponivel && _usuarioAtual == usuario)
            {
                Disponivel = true;
                _usuarioAtual = null;
                Console.WriteLine($"DVD '{Titulo}' devolvido por {usuario.Nome}");
            }
        }

        public bool VerificarDisponibilidade()
        {
            return Disponivel;
        }

        public void ExibirInformacoes()
        {
            Console.WriteLine($"\n--- DVD ---");
            Console.WriteLine($"Título: {Titulo}");
            Console.WriteLine($"Diretor: {Diretor}");
            Console.WriteLine($"Ano: {Ano}");
            Console.WriteLine($"Duração: {DuracaoMinutos} min");
            Console.WriteLine($"Status: {(Disponivel ? "Disponível" : $"Emprestado para {_usuarioAtual?.Nome}")}");
        }
    }
}
