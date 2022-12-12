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

        public SkuService(IRepositoryManager repository, ILoggerManager logger)
        {
            _repository = repository;
            _logger = logger;
        }

        public IEnumerable<SkuDTO> GetAllSkus(bool trackChanges)
        {
            try
            {
                var skus =
                _repository.Sku.GetAllSkus(trackChanges);
                var skusDto = skus.Select(c =>
                     new SkuDTO(c.Id,c.Name,c.Cost )).ToList();
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
