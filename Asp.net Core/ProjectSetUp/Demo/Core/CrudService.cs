using System.Collections.Generic;
using System.Threading.Tasks;
using AutoMapper;
using TestWeb.Helper;

namespace TestWeb.Core
{
    //public class CrudService<D, E>: ICrudService<D> where E: BaseEntity
    //{
    //    private readonly ICrudRepository<E> _repository;
    //    private readonly IMapper _mapper;

    //    protected CrudService(ICrudRepository<E> repository, IMapper mapper)
    //    {
    //        _repository = repository;
    //        _mapper = mapper;
    //    }
    //    public Task<MessageHelper> Create(D dto)
    //    {
    //        E entity = _mapper.Map<E>(dto);
    //        _repository.Create(entity);
    //        return Task.FromResult(BuildMessageHelper());
    //    }
    //    public Task<MessageHelper> Update(D dto)
    //    {
    //        E entity = _mapper.Map<E>(dto);
    //        _repository.Update(entity);
    //        return Task.FromResult(BuildMessageHelperForUpdate());
    //    }
    //    public Task<List<D>> GetList()
    //    {
    //        return Task.FromResult(_repository.GetList().ConvertAll(menu => _mapper.Map<D>(menu)));
    //    }

    //    public Task<D> GetById(long Id)
    //    {
    //        return Task.FromResult(_mapper.Map<D>(_repository.GetById(Id)));
    //    }
        
    //    //TODO Move this method to an util
    //    private static MessageHelper BuildMessageHelper()
    //    {
    //        MessageHelper messageHelper = new MessageHelper();
    //        messageHelper.statuscode = 201;
    //        messageHelper.Message = "Created successfully";
    //        return messageHelper;
    //    }
    //    private static MessageHelper BuildMessageHelperForUpdate()
    //    {
    //        MessageHelper messageHelper = new MessageHelper();
    //        messageHelper.statuscode = 200;
    //        messageHelper.Message = "Edited Successfully";
    //        return messageHelper;
    //    }
    //}
}