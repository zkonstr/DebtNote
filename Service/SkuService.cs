using AutoMapper;
using Contracts;
using Entities.Exceptions;
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

        public SkuDTO CreateSku(SkuForCreationDTO sku)
        {
            var SkuEntity = _mapper.Map<Sku>(sku);
            _repository.Sku.CreateSku(SkuEntity);
            _repository.Save();
            var SkuToReturn = _mapper.Map<SkuDTO>(SkuEntity);
            return SkuToReturn;
        }

        public void DeleteSku(Guid skuId, bool trackChanges)
        {
            var sku = _repository.Sku.GetSku(skuId, trackChanges);
            if (sku is null)
                throw new SkuNotFoundException(skuId);
            _repository.Sku.DeleteSku(sku);
            _repository.Save();
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
            if (sku is null)
                throw new SkuNotFoundException(id);
            var skuDto = _mapper.Map<SkuDTO>(sku);
            return skuDto;
        }
    }
}
