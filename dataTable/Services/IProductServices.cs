using dataTable.Dtos;
using dataTable.Models;
using dataTable.Models.Dt;

namespace dataTable.Services
{
    public interface IProductServices
    {
        Task<DataTableRespose<DtProduct>> GetAllDt(DtRequest req);
        List<Category> GetCategoryList();
        List<Product> GetProbyid(int id);
        int AddPro(Product product);

       
        int DeletePro(int id);
    }
}
