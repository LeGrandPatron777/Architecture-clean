using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SystèmeGestionStationService.SharedKernel.Interfaces;
using SystèmeGestionStationService.SharedKernel;
using Microsoft.EntityFrameworkCore;
using SystèmeGestionStationService.Infrastructure;

namespace SolutionGestionProjets.Infrastructure.Repositories
{
    public class EfRepository<T> : IAsyncRepository<T>, IRepository<T> where T : BaseEntity, IAggregateRoot

    {

        protected readonly SolutionGestionProjetsContext _SolutionGestionProjetsContext;

        public EfRepository(SolutionGestionProjetsContext solutionGestionProjetsContext)
        {
            _SolutionGestionProjetsContext = solutionGestionProjetsContext;
        }

        public async Task<T> GetByIdAsync(int id)
        {
            return await _SolutionGestionProjetsContext.Set<T>().FindAsync(id);
        }

        public async Task<IReadOnlyList<T>> ListAllAsync()
        {
            return await _SolutionGestionProjetsContext.Set<T>().ToListAsync();
        }

        public async Task<T> AddAsync(T entity)
        {
            await _SolutionGestionProjetsContext.Set<T>().AddAsync(entity);
            await _SolutionGestionProjetsContext.SaveChangesAsync();
            return entity;

        }

        public async Task UpdateAsync(T entity)
        {
            _SolutionGestionProjetsContext.Entry(entity).State =
                                                       EntityState.Modified;
            await _SolutionGestionProjetsContext.SaveChangesAsync();
        }

        public async Task DeleteAsync(T entity)
        {
            _SolutionGestionProjetsContext.Set<T>().Remove(entity);
            await _SolutionGestionProjetsContext.SaveChangesAsync();
        }

        private IQueryable<T> ApplySpecification(ISpecification<T> spec)
        {
            return
            SpecificationEvaluator<T>.GetQuery(
              _SolutionGestionProjetsContext.Set<T>().AsQueryable(), spec);
        }

        public async Task<IReadOnlyList<T>> ListAsync(ISpecification<T> spec)
        {
            return await ApplySpecification(spec).ToListAsync();
        }

        public async Task<int> CountAsync(ISpecification<T> spec)
        {
            return await ApplySpecification(spec).CountAsync();
        }

        public T GetById(int id)
        {
            return  _SolutionGestionProjetsContext.Set<T>().Find(id);
        }

        public IReadOnlyList<T> ListAll()
        {
            return _SolutionGestionProjetsContext.Set<T>().ToList();
        }

        public IReadOnlyList<T> List(ISpecification<T> spec)
        {
            throw new NotImplementedException();
        }

        public T Add(T entity)
        {
            _SolutionGestionProjetsContext.Set<T>().AddAsync(entity);
            _SolutionGestionProjetsContext.SaveChanges();
            return entity;
        }

        public int Update(T entity)
        {
            throw new NotImplementedException();
        }

        public int Delete(T entity)
        {
            throw new NotImplementedException();
        }

        public int Count(ISpecification<T> spec)
        {
            throw new NotImplementedException();
        }
    }
}
