using System;

namespace AulaPOO.Models
{
    // Herança: UsuarioPremium herda de Usuario
    public class UsuarioPremium : Usuario
    {
        // Atributos específicos do Premium
        public DateTime DataExpiracao { get; private set; }
        public decimal Desconto { get; private set; }

        // Construtor - chama o construtor da classe base
        public UsuarioPremium(string nome, int idade, string email, decimal desconto)
            : base(nome, idade, email)
        {
            DataExpiracao = DateTime.Now.AddYears(1);
            Desconto = desconto;
        }

        // Método específico do Premium
        public void RenovarAssinatura()
        {
            DataExpiracao = DateTime.Now.AddYears(1);
            Console.WriteLine($"Assinatura renovada para {Nome} até {DataExpiracao:dd/MM/yyyy}");
        }

        // Polimorfismo: sobrescreve o método da classe base
        public override void AdicionarLivro(Livro livro)
        {
            // Usuários premium podem pegar até 5 livros
            if (QuantidadeLivrosEmprestados < 5)
            {
                base.AdicionarLivro(livro); // Chama o método da classe base
            }
            else
            {
                Console.WriteLine($"Usuário premium {Nome} atingiu o limite de 5 livros!");
            }
        }
    }
}
