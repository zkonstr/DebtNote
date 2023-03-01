using Shared.DataTransferObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service.Contracts
{
    public interface ISkuService
    {
        IEnumerable<SkuDTO> GetAllSkus(bool trackChanges);

        SkuDTO GetSku(Guid Id, bool trackChanges);

        SkuDTO CreateSku(SkuForCreationDTO sku);

        void UpdateSku(Guid skuId,SkuForUpdateDTO sku,bool trackChanges);

        void DeleteSku(Guid skuId, bool trackChanges);
    }
}
