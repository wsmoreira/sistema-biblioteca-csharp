using AulaPOO.Models;

namespace AulaPOO.Interfaces
{
    public interface IEmprestavel
    {
        void Emprestar(Usuario usuario);
        void Devolver(Usuario usuario);
        bool VerificarDisponibilidade();
    }
}
