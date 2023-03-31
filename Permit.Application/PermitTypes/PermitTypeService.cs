using AutoMapper;
using Permit.Application.Common.Persistence;
using Permit.Application.PermitTypes.Models;
using Permit.Domain.Entities;
using System.Linq.Expressions;

namespace Permit.Application.PermitTypes
{
    public interface IPermitTypeService
    {
        Task<IEnumerable<PermitTypeViewModel>> Get(Expression<Func<PermitType, bool>>? filter = null);
        Task<PermitTypeViewModel> Add(PermitTypeInputViewModel permitType);
        Task<PermitTypeViewModel> Update(int Id, PermitTypeInputViewModel input);
        Task<PermitTypeViewModel> Delete(int Id);
    }
    public class PermitTypeService : IPermitTypeService 
    {
        private readonly IUnitOfWork unitOfWork;
        private readonly IMapper mapper;
        public PermitTypeService(
            IUnitOfWork unitOfWork,
            IMapper mapper)
        {
            this.unitOfWork = unitOfWork;
            this.mapper = mapper;
        }
        public async Task<IEnumerable<PermitTypeViewModel>> Get(Expression<Func<PermitType, bool>>? filter = null)
        {
            var permitTypeRepository = unitOfWork.GetRepositoryFor<PermitType>();
            var result = await permitTypeRepository.Get(filter);
            var permitTypes = result.ToList();
            return this.mapper.Map<IEnumerable<PermitTypeViewModel>>(permitTypes);
        }
        public async Task<PermitTypeViewModel> Add(PermitTypeInputViewModel input)
        {
            var permitTypeRepository = unitOfWork.GetRepositoryFor<PermitType>();
            var result = permitTypeRepository.Add(new PermitType
            {
                Description=input.Description,
                CreatedAt=DateTime.Now, 
                LastUpdatedAt=DateTime.Now
            });
            await unitOfWork.SaveChangesAsync();
            return this.mapper.Map<PermitTypeViewModel>(result);
        }
        public async Task<PermitTypeViewModel> Update(int Id, PermitTypeInputViewModel input)
        {
            var permitTypeRepository = unitOfWork.GetRepositoryFor<PermitType>();
            var result = permitTypeRepository.Update(new PermitType
            {
                Id = Id,
                Description = input.Description,
                LastUpdatedAt = DateTime.Now
            });
            await unitOfWork.SaveChangesAsync();
            return this.mapper.Map<PermitTypeViewModel>(result);
        }
        public async Task<PermitTypeViewModel> Delete(int Id)
        {
            var permitTypeRepository = unitOfWork.GetRepositoryFor<PermitType>();
            var permitTypeFound = (await permitTypeRepository.Get(p=>p.Id == Id)).First();
            ArgumentNullException.ThrowIfNull(permitTypeFound);
            var result = permitTypeRepository.Delete(permitTypeFound);
            await unitOfWork.SaveChangesAsync();
            return this.mapper.Map<PermitTypeViewModel>(result);

        }
    }
}
