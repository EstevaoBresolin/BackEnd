using BackEnd.Classes;

namespace BackEnd.Services
{
    public class InstituicaoService : BaseService<Instituicao>
    {
        public InstituicaoService(AppDbContext context) : base(context)
        {
        }

        // Você pode adicionar métodos específicos da entidade Instituicao aqui, se necessário
        // Caso não haja métodos específicos, eles podem ser deixados no serviço base
    }
}
