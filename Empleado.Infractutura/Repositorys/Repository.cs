using Empleado.Domain.Interfaces;
using Empleado.Infractutura.Context;
using Microsoft.EntityFrameworkCore;
using System.Data;

namespace Empleado.Infractutura.Repositorys
{
    public class Repository<T> : IRepository<T> where T : class
    {
        private readonly DataContext _dataContext;
        protected DbSet<T> DbSet { get; set; }

        public Repository(DataContext dataContext)
        {
            _dataContext = dataContext;
            this.DbSet = dataContext.Set<T>();
        }
        public async Task<T> AddAsync(T entity)
        {
            var result = await _dataContext.Set<T>().AddAsync(entity);
            return result.Entity;
        }

        public async Task<bool> DeleteAsync(T entity)
        {
            _dataContext.Set<T>().Remove(entity);
            return true;
        }


        public async Task<List<T>> GetAllAsync()
        {
            return await _dataContext.Set<T>().ToListAsync();
        }

        public async Task<T> GetAsync(int id)
        {
            return await _dataContext.Set<T>().FindAsync(id);
        }

        public async Task<T> UpdateAsync(T entity)
        {
            var result = _dataContext.Set<T>().Update(entity);
            return result.Entity;
        }

        public async Task<List<T>> GetByEdadMayotIgual(int edad)
        {
            var result = await _dataContext.Set<T>()
                        .Where(emp => EF.Property<int>(emp, "Edad") >= edad)  
                        .ToListAsync();  

            return result;
        }

        public async Task<bool> DeleteLogicAsync(int id, bool isActive)
        {
          
            var result = await _dataContext.Set<T>()
                        .Where(emp => EF.Property<int>(emp, "Id") == id) 
                        .ExecuteUpdateAsync(setters => setters.SetProperty(p => EF.Property<bool>(p, "Activo"), isActive));

            return true;
        }

        public async Task<List<T>> GetEmpleadosActive(bool activo)
        {
            var result = await _dataContext.Set<T>()
                       .Where(emp => EF.Property<bool>(emp, "Activo") == activo)
                       .ToListAsync();

            return result;
        }
    }
}
