using System;

namespace AulaPOO.Models
{
    // Exercício 2: Validação de data de devolução nos empréstimos
    // Exercício 4: Sistema de multas para devoluções atrasadas
    public class Emprestimo
    {
        public Livro Livro { get; private set; }
        public Usuario Usuario { get; private set; }
        public DateTime DataEmprestimo { get; private set; }
        public DateTime DataPrevistaDevolucao { get; private set; }
        public DateTime? DataDevolucao { get; private set; }
        public bool Devolvido => DataDevolucao.HasValue;

        // Multa por dia de atraso (R$)
        private const decimal MultaPorDia = 1.50m;

        public Emprestimo(Livro livro, Usuario usuario, int diasParaDevolucao = 14)
        {
            if (diasParaDevolucao <= 0)
                throw new ArgumentException("Prazo de devolução deve ser maior que zero.");

            Livro = livro;
            Usuario = usuario;
            DataEmprestimo = DateTime.Now;
            DataPrevistaDevolucao = DateTime.Now.AddDays(diasParaDevolucao);
            DataDevolucao = null;
        }

        // Exercício 2: Registra a devolução com validação de data
        public void RegistrarDevolucao(DateTime dataDevolucao)
        {
            if (Devolvido)
            {
                Console.WriteLine($"Este empréstimo já foi encerrado em {DataDevolucao:dd/MM/yyyy}.");
                return;
            }

            if (dataDevolucao < DataEmprestimo)
                throw new ArgumentException("Data de devolução não pode ser anterior à data do empréstimo.");

            DataDevolucao = dataDevolucao;
            Console.WriteLine($"Devolução registrada em {dataDevolucao:dd/MM/yyyy}.");

            // Exercício 4: Calcula e exibe multa se houver atraso
            var multa = CalcularMulta();
            if (multa > 0)
                Console.WriteLine($"⚠ Devolução com {DiasAtraso()} dia(s) de atraso. Multa: R$ {multa:F2}");
            else
                Console.WriteLine("✓ Devolução no prazo. Sem multa.");
        }

        // Atalho para devolver hoje
        public void RegistrarDevolucaoHoje() => RegistrarDevolucao(DateTime.Now);

        // Exercício 4: Calcula a multa com base nos dias de atraso
        public decimal CalcularMulta()
        {
            var referencia = Devolvido ? DataDevolucao!.Value : DateTime.Now;
            int atraso = DiasAtraso(referencia);
            return atraso > 0 ? atraso * MultaPorDia : 0;
        }

        public int DiasAtraso(DateTime? referencia = null)
        {
            var data = referencia ?? (Devolvido ? DataDevolucao!.Value : DateTime.Now);
            int atraso = (int)(data - DataPrevistaDevolucao).TotalDays;
            return Math.Max(0, atraso);
        }

        public void ExibirResumo()
        {
            Console.WriteLine($"\n--- Empréstimo ---");
            Console.WriteLine($"Livro:            {Livro.Titulo}");
            Console.WriteLine($"Usuário:          {Usuario.Nome}");
            Console.WriteLine($"Data empréstimo:  {DataEmprestimo:dd/MM/yyyy}");
            Console.WriteLine($"Prazo devolução:  {DataPrevistaDevolucao:dd/MM/yyyy}");

            if (Devolvido)
            {
                Console.WriteLine($"Data devolução:   {DataDevolucao:dd/MM/yyyy}");
                var multa = CalcularMulta();
                Console.WriteLine($"Status:           Devolvido {(multa > 0 ? $"com multa de R$ {multa:F2}" : "sem multa")}");
            }
            else
            {
                var multa = CalcularMulta();
                var diasRestantes = (int)(DataPrevistaDevolucao - DateTime.Now).TotalDays;
                if (multa > 0)
                    Console.WriteLine($"Status:           Em atraso ({DiasAtraso()} dias) - Multa acumulada: R$ {multa:F2}");
                else
                    Console.WriteLine($"Status:           Em aberto ({diasRestantes} dia(s) restante(s))");
            }
        }
    }
}
