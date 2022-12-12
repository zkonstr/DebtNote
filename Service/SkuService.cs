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
            var skus = _repository.Sku.GetAllSkus(trackChanges);
            var skusDto = _mapper.Map<IEnumerable<SkuDTO>>(skus);
            return skusDto;
        }
        public SkuDTO GetSku(Guid id, bool trackChanges)
        {
            var sku = _repository.Sku.GetSku(id, trackChanges);
            //Check if the user is null
            var skuDto = _mapper.Map<SkuDTO>(sku);
            return skuDto;
        }
    }
}
