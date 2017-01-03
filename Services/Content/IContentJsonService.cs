using Core.Models;

namespace Services.Content
{
    public interface IContentJsonService
    {
        bool AddContent(JsonContentModel content);
    }
}