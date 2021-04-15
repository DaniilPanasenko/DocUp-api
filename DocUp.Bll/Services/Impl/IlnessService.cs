using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using AutoMapper;
using DocUp.Bll.Models;
using DocUp.Dal.Entities;
using DocUp.Dal.Storages;

namespace DocUp.Bll.Services.Impl
{
    public class IlnessService : IIlnessService
    {
        private readonly IIlnessStorage _ilnessStorage;
        private readonly IMapper _mapper;

        public IlnessService(
            IIlnessStorage ilnessStorage,
            IMapper mapper)
        {
            _mapper = mapper;
            _ilnessStorage = ilnessStorage;
        }

        public async Task AddIlnessAsync(IlnessModel ilness)
        {
            var entity = _mapper.Map<IlnessModel, IlnessEntity>(ilness);
            await _ilnessStorage.AddAsync(entity);
        }

        public async Task<List<IlnessModel>> GetIlnessListAsync()
        {
            var entities = await _ilnessStorage.GetIlnessListAsync();
            return _mapper.Map<List<IlnessEntity>, List<IlnessModel>>(entities);
        }
    }
}
