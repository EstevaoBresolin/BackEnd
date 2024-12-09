using BackEnd.Classes;
using Microsoft.EntityFrameworkCore;

namespace BackEnd.Services
{
    public class BaseService<T> where T : class
    {
        protected readonly AppDbContext _context;

        public BaseService(AppDbContext context)
        {
            _context = context;
        }

        // Obter todos os registros
        public async Task<List<T>> Get()
        {
            return await _context.Set<T>().ToListAsync();
        }

        // Método genérico para obter uma entidade por ID
        public async Task<T> ObterPorId(int id)
        {
            return await _context.Set<T>().FindAsync(id);
        }

        // Salvar um novo registro ou atualizar se já existir
        public async Task<T> Salvar(T entity)
        {
            var idProperty = entity.GetType().GetProperty("Id");  // Procura a propriedade "Id"
            if (idProperty != null)
            {
                var idValue = idProperty.GetValue(entity);

                if (idValue != null && (int)idValue != 0)
                {
                    // Se o ID for diferente de 0, atualiza a entidade
                    _context.Set<T>().Update(entity);
                }
                else
                {
                    // Se o ID for 0 (ou null), adiciona como novo registro
                    _context.Set<T>().Add(entity);
                }
            }

            await _context.SaveChangesAsync();
            return entity;
        }

        // Editar um registro (atualizar)
        public async Task Editar(T entity)
        {
            _context.Set<T>().Update(entity);
            await _context.SaveChangesAsync();
        }

        // Método genérico para excluir uma entidade
        public async Task Excluir(int id)
        {
            var entity = await _context.Set<T>().FindAsync(id);
            if (entity != null)
            {
                _context.Set<T>().Remove(entity);
                await _context.SaveChangesAsync();
            }
        }

        // Outros métodos genéricos podem ser adicionados aqui, como Adicionar, Atualizar, etc.
    }


}
