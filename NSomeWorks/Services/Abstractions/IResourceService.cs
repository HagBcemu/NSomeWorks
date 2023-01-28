using System.Threading.Tasks;
using NSomeWorks.Model;

namespace NSomeWorks.Services.Abstractions;
public interface IResourceService
{
    Task<Resource> GetResource(int id);
    Task<CollectionData<Resource>> GetResources();
}
