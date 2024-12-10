using BackEnd.Classes;
using BackEnd.Data;

namespace BackEnd.Services
{
    public class VoluntarioService : BaseService<Voluntario>
    {
        public VoluntarioService(AppDbContext context) : base(context)
        {
        }

        // Você pode adicionar métodos específicos da entidade Instituicao aqui, se necessário
        // Caso não haja métodos específicos, eles podem ser deixados no serviço base
    }
}
