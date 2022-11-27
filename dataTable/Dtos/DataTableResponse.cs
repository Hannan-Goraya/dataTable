using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace dataTable.Dtos
{
    public class DataTableRespose<T>
    {
        public int Draw { get; set; }
        public int RecordsTotal { get; set; }
        public int RecordsFiltered { get; set; }
        public List<T> Data { get; set; }
        public string Error { get; set; }
    }





}
