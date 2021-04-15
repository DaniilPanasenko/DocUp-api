using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using DocUp.Bll.Models;

namespace DocUp.Bll.Services
{
    public interface IIlnessService
    {
        Task AddIlnessAsync(IlnessModel ilness);

        Task<List<IlnessModel>> GetIlnessListAsync();
    }
}
