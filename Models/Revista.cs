using System;
using AulaPOO.Interfaces;

namespace AulaPOO.Models
{
    // Revista implementa a interface IEmprestavel
    public class Revista : IEmprestavel
    {
        public string Titulo { get; set; }
        public int Edicao { get; set; }
        public int Ano { get; set; }
        public bool Disponivel { get; private set; }

        private Usuario? _usuarioAtual;

        public Revista(string titulo, int edicao, int ano)
        {
            Titulo = titulo;
            Edicao = edicao;
            Ano = ano;
            Disponivel = true;
        }

        public void Emprestar(Usuario usuario)
        {
            if (Disponivel)
            {
                Disponivel = false;
                _usuarioAtual = usuario;
                Console.WriteLine($"Revista '{Titulo}' emprestada para {usuario.Nome}");
            }
            else
            {
                Console.WriteLine($"Revista '{Titulo}' não está disponível");
            }
        }

        public void Devolver(Usuario usuario)
        {
            if (!Disponivel && _usuarioAtual == usuario)
            {
                Disponivel = true;
                _usuarioAtual = null;
                Console.WriteLine($"Revista '{Titulo}' devolvida por {usuario.Nome}");
            }
        }

        public bool VerificarDisponibilidade()
        {
            return Disponivel;
        }

        public void ExibirInformacoes()
        {
            Console.WriteLine($"\n--- Revista ---");
            Console.WriteLine($"Título: {Titulo}");
            Console.WriteLine($"Edição: {Edicao}");
            Console.WriteLine($"Ano: {Ano}");
            Console.WriteLine($"Status: {(Disponivel ? "Disponível" : $"Emprestada para {_usuarioAtual?.Nome}")}");
        }
    }
}
