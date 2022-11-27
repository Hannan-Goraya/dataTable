namespace dataTable.Models.Dt
{
    public  class  DTEmployee
    {

        public int EmployeeId  { get; set; }

        public string EmployeeFirstName { get; set; }

        public string EmployeeLastName { get; set; }

        public decimal Salary { get; set; }

     

        public string Designation { get; set; }
       

    }

    public class Total { 

        public int TotalCount { get; set; } 
    }


    public class Result
    {
        public List<DTEmployee> Rec { get; set; }

        public int TotalRec { get; set; }


    }

}
