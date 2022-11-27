using Dapper;
using dataTable.data;
using dataTable.Dtos;
using dataTable.Models;
using dataTable.Models.Dt;
using System.Data;

namespace dataTable.Services
{
    public class ProductServices : IProductServices
    {
        private readonly IbaseRepo _dapper;

        public ProductServices(IbaseRepo dapper)
        {
            _dapper = dapper;
        }

        public async Task<DataTableRespose<DtProduct>> GetAllDt(DtRequest req)
        {
            DynamicParameters parameters = new DynamicParameters();
            parameters.Add("@SearchText", req.SearchText);
            parameters.Add("@SortExpression", req.SortExpression);
            parameters.Add("@StartRowIndex", req.StartRowIndex);
            parameters.Add("@PageSize", req.PageSize);
            parameters.Add("@CategoryId", req.CategotyId);


            var Product = _dapper.ReturnMultipuleDtp("GetAllProductDT", parameters);

            var Response = new DataTableRespose<DtProduct>()
            {
                Draw = req.draw,
                Data = Product.Result.Rec,
                RecordsTotal = Product.Result.TotalRec,
                RecordsFiltered = Product.Result.TotalRec,
                Error = ""




            };
            return Response;





        }



        public int AddPro(Product product)
        {
            DynamicParameters parameters = new DynamicParameters();
            parameters.Add("@Id", -1, dbType: DbType.Int32, direction: ParameterDirection.Output);
            parameters.Add("@Name", product.Name);
            parameters.Add("@Price", product.Price);
            parameters.Add("@Image", product.Image);
            parameters.Add("@CatId", product.catId);


            var res = _dapper.ReturnIntPro("AddProduct", parameters);

            return res;

        }





        public List<Category> GetCategoryList()
        {
            DynamicParameters parameters = new DynamicParameters();

           var catList =  _dapper.ReturnList<Category>("GetAllCat", parameters);
            return catList.ToList();
        } 




        public int DeletePro(int id)
        {
            DynamicParameters parameters =  new DynamicParameters();

            parameters.Add("Id", id);

            return _dapper.ReturnInt("DeleteProduct", parameters);
        }

        public List<Product> GetProbyid(int id)
        {
            DynamicParameters pa = new DynamicParameters();
            pa.Add("Id", id);

           var p =   _dapper.ReturnList<Product>("GetAllbyId", pa);
            return p.ToList();
        }
    }
}
