using DevTrackR.Entities;

namespace DevTrackR.Persistence.Repository
{
    public interface IPackageRepository
    {
        List<Package> GetAll();
        Package GetByCode(string code);
        void Add(Package package);
        void Update(Package package);   
    }
}
