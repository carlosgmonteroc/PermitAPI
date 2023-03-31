using AutoMapper;
using Permit.Application.Common.Persistence;
using Permit.Application.Permits.Models;
using Permit.Application.PermitTypes;
using Permit.Domain.Entities;

namespace Permit.Application.Permits
{
    public interface IPermitService
    {
        Task<IEnumerable<PermitViewModel>> Get();
        Task<PermitViewModel> Add(PermitInputViewModel permitType);
        Task<PermitViewModel> Update(int Id, PermitInputViewModel input);
        Task<PermitViewModel> Delete(int Id);
    }
    public class PermitService : IPermitService 
    {
        private readonly IUnitOfWork unitOfWork;
        private readonly IMapper mapper;
        private readonly IPermitTypeService permitTypeService;
        public PermitService(
            IUnitOfWork unitOfWork,
            IMapper mapper,
            IPermitTypeService permitTypeService)
        {
            this.unitOfWork = unitOfWork;
            this.mapper = mapper;
            this.permitTypeService = permitTypeService;
        }
        public async Task<IEnumerable<PermitViewModel>> Get()
        {
            var permitRepository = unitOfWork.GetRepositoryFor<Domain.Entities.Permit>();
            var result = await permitRepository.Get();
            var permits = result.ToList();
            return this.mapper.Map<IEnumerable<PermitViewModel>>(permits);
        }
        public async Task<PermitViewModel> Add(PermitInputViewModel input)
        {
            var permitRepository = unitOfWork.GetRepositoryFor<Domain.Entities.Permit>();
            var permitType = (await permitTypeService.Get(p => p.Id == input.PermitTypeId)).First();
            ArgumentNullException.ThrowIfNull(permitType);

            var result = permitRepository.Add(new Domain.Entities.Permit
            {
                FirstName = input.FirstName,
                LastName = input.LastName,
                PermitTypeId = input.PermitTypeId,
                //PermitType = mapper.Map<PermitType>(permitType),
                PermitDate = input.PermitDate,
                CreatedAt = DateTime.Now,
                LastUpdatedAt = DateTime.Now
            });
            await unitOfWork.SaveChangesAsync();
            return this.mapper.Map<PermitViewModel>(result);
        }
        public async Task<PermitViewModel> Update(int Id, PermitInputViewModel input)
        {
            var permitRepository = unitOfWork.GetRepositoryFor<Domain.Entities.Permit>();
            var result = permitRepository.Update(new Domain.Entities.Permit
            {
                Id = Id,
                FirstName = input.FirstName,
                LastName = input.LastName,
                PermitTypeId = input.PermitTypeId,
                PermitDate = input.PermitDate,
                LastUpdatedAt = DateTime.Now
            });
            await unitOfWork.SaveChangesAsync();
            return this.mapper.Map<PermitViewModel>(result);
        }
        public async Task<PermitViewModel> Delete(int Id)
        {
            var permitRepository = unitOfWork.GetRepositoryFor<Domain.Entities.Permit>();
            var permitFound = (await permitRepository.Get(p=>p.Id == Id)).First();
            ArgumentNullException.ThrowIfNull(permitFound);
            var result = permitRepository.Delete(permitFound);
            await unitOfWork.SaveChangesAsync();
            return this.mapper.Map<PermitViewModel>(result);

        }
    }
}
