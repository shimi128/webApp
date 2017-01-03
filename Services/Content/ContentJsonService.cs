using System.Linq;
using Core;
using Core.Models;
using Data;
using Data.Domain;

namespace Services.Content
{
    public class ContentJsonService : IContentJsonService
    {
        private readonly IRepository<JsonContents> _repository;

        public ContentJsonService(IRepository<JsonContents> repository)
        {
            _repository = repository;
        }

        public bool AddContent(JsonContentModel content)
        {
            var entity = _repository.FindBy(x => x.NodeId == content.NodeId).FirstOrDefault();
            if (entity != null)
            {
                entity.Content = content.Props;
                _repository.Update(entity);
            }
            else
            {
                var con = new JsonContents { Content = content.Props, Name = content.Name, NodeId = content.NodeId };
                _repository.Insert(con);
            }
            

            return true;
        }
    }
}