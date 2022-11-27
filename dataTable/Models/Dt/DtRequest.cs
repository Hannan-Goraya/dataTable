using System.Drawing.Printing;

namespace dataTable.Models.Dt
{
    public class DtRequest
    {
        public int draw { get; set; }
        public string SearchText { get; set; }
        public string SortExpression { get; set; }
        public int StartRowIndex { get; set; }
        public int CategotyId { get; set; }
        public int PageSize {get; set;}
    }
}
