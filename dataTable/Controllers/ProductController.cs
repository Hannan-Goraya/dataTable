using dataTable.Models;
using dataTable.Models.Dt;
using dataTable.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace dataTable.Controllers
{
    public class ProductController : Controller
    {
        private readonly IWebHostEnvironment _env;
        private readonly IProductServices _pro;

        public ProductController(IProductServices pro, IWebHostEnvironment env)
        {
            _env = env;
            _pro = pro;
        }

        public IActionResult Index()
        {
            ViewBag.CategoryId = new SelectList(_pro.GetCategoryList(), "Id", "CatName");
            return View();
        }


        public JsonResult GetProDT()
        {

            

            var request = new DtRequest();

            request.SortExpression = Request.Form["order[0][dir]"];
            request.StartRowIndex = Convert.ToInt32(Request.Form["start"]);
            request.PageSize = Convert.ToInt32(Request.Form["length"]);
            request.SearchText = Request.Form["search[value]"];
            request.CategotyId = Convert.ToInt32(Request.Form["string1"]);






            var data = _pro.GetAllDt(request).Result;


            return Json(data);







        }



        public IActionResult AddProduct()
        {
            ViewBag.CategoryId2 = new SelectList(_pro.GetCategoryList(), "Id", "CatName");
            return View();
        }


        [HttpPost]
        public async Task<IActionResult> AddProduct(Product product)
        {
            ViewBag.CategoryId2 = new SelectList(_pro.GetCategoryList(), "Id", "CatName");






           
            var date = DateTime.Now;
            long Tick = date.Ticks;
                string imageName = "noimage.png";
                if (product.ImgUpload != null)
                {
                    string uploadsDir = Path.Combine(_env.WebRootPath, "media/product");
                    imageName = Tick.ToString() + "_" + product.ImgUpload.FileName ;
                    string filePath = Path.Combine(uploadsDir, imageName);
                    FileStream fs = new FileStream(filePath, FileMode.Create);
                    await product.ImgUpload.CopyToAsync(fs);
                    fs.Close();
                }

                product.Image = imageName;

                var pro = _pro.AddPro(product);
                
                return RedirectToAction("Index");
               





            


        }



        //[HttpPost]
        //public IActionResult Delete (int id)
        //{

        //    var p = _pro.GetProbyid(id);


        //        string uploadsDir = Path.Combine(_env.WebRootPath, "media/users");

        //        if (!string.Equals(p.Image, "noimage.png"))
        //        {
        //            string oldImagePath = Path.Combine(uploadsDir, p.Image);
        //            if (System.IO.File.Exists(oldImagePath))
        //            {
        //                System.IO.File.Delete(oldImagePath);
        //            }
        //        }

        //        _pro.DeletePro(id);

        //    return RedirectToAction("Index");

            



    }
}
