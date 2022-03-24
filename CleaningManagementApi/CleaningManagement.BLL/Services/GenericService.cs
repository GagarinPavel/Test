using AutoMapper;
using CleaningManagement.BLL.Interfaces.Services;
using CleaningManagement.DAL.Interfaces.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace CleaningManagement.BLL.Services
{
    public class GenericService<TEntity, TMapToEntity> : IGenericService<TEntity>
            where TEntity : class
            where TMapToEntity : class
    {
        private readonly IGenericRepository<TMapToEntity> _repository;
        private readonly IMapper _mapper;

        public GenericService(IGenericRepository<TMapToEntity> repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public async Task<TEntity> Create(TEntity entity, CancellationToken ct)
        {
            return _mapper.Map<TEntity>(await _repository.Create(
                _mapper.Map<TMapToEntity>(entity), ct
            ));
        }

        public Task Delete(Guid id, CancellationToken ct)
        {
            return _repository.Delete(id, ct);
        }

        public async Task<IEnumerable<TEntity>> Get(CancellationToken ct)
        {
            var result = _mapper.Map<IEnumerable<TEntity>>(
               await _repository.Get(ct)
           );

            return result;
        }

        public async Task<TEntity> GetById(Guid id, CancellationToken ct)
        {
            var res = _mapper.Map<TEntity>(await _repository.GetById(id, ct));

            return res;
        }

        public async Task<TEntity> Update(TEntity entity, CancellationToken ct)
        {
            return _mapper.Map<TEntity>(
                await _repository.Update(_mapper.Map<TMapToEntity>(entity), ct)
                );
        }
    }
}
