namespace dataTable.Models.Dt
{
    public class DtProduct
    {

      
      

        public string Image { get; set; }

        public string Name { get; set; }

        public float Price { get; set; }

        public string CatName { get; set; }
    }



    public class TotalP
    {

        public int TotalCount { get; set; }
    }


    public class ResultP
    {
        public List<DtProduct> Rec { get; set; }

        public int TotalRec { get; set; }


    }

}

