using System.Collections.Generic;
using System.Threading.Tasks;
using TestWeb.Helper;

namespace TestWeb.Core
{
    public interface ICrudService<D>
    {
        public Task<MessageHelper> Create(D dto);
        public Task<MessageHelper> Update(D dto);

        public Task<List<D>> GetList();

        public Task<D> GetById(long Id);
    }
}