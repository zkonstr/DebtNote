using Contracts;
using Entities.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository
{
    public class SkuRepository : RepositoryBase<Sku>, ISkuRepository
    {
        public SkuRepository(RepositoryContext repositoryContext)
        : base(repositoryContext)
        {
        }

        public void CreateSku(Sku sku) => Create(sku);

        public void DeleteSku(Sku sku)=> Delete(sku);

        public IEnumerable<Sku> GetAllSkus(bool trackChanges) =>
            FindAll(trackChanges).OrderBy(c => c.Name).ToList();

        public Sku GetSku(Guid Id, bool trackChanges) =>
            FindByCondition(c => c.Id.Equals(Id), trackChanges)
                .SingleOrDefault();
    }
}
