using AutoMapper;
using Contracts;
using Entities.Models;
using Service.Contracts;
using Shared.DataTransferObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service
{
    internal sealed class SkuService :ISkuService
    {
        private readonly IRepositoryManager _repository;
        private readonly ILoggerManager _logger;
        private readonly IMapper _mapper;

        public SkuService(IRepositoryManager repository, ILoggerManager logger, IMapper mapper)
        {
            _repository = repository;
            _logger = logger;
            _mapper = mapper;
        }

        public IEnumerable<SkuDTO> GetAllSkus(bool trackChanges)
        {
            try
            {
                var skus =
                _repository.Sku.GetAllSkus(trackChanges);
                var skusDto = _mapper.Map<IEnumerable<SkuDTO>>(skus);
                return skusDto;
            }
            catch (Exception ex)
            {
                _logger.LogError($"Something went wrong in the {nameof(GetAllSkus)} service method {ex}");
                throw;
            }
        }
    }
}
