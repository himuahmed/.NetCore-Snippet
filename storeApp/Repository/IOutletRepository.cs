using System.Collections.Generic;
using System.Threading.Tasks;
using storeApp.Models;

namespace storeApp.Repository
{
    public interface IOutletRepository
    {
        Task<List<OutletModel>> GetAllOutlet();
    }
}