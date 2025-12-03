using Microsoft.AspNetCore.Mvc.Rendering;

namespace BelajarDotNet.Models.Model_Binding
{
    public class ProductListViewModelFq
    {
        public IEnumerable<ProductFq> Products { get; set; }
        public int PageNumber { get; set; }
        public int PageSize { get; set; }
        public int TotalPages { get; set; }
        public string SearchTerm { get; set; }
        public string Category { get; set; }
        public string SortBy { get; set; }
        public bool SortAscending { get; set; }
        public IEnumerable<SelectListItem> Categories { get; set; }
        public IEnumerable<SelectListItem> SortOptions { get; set; }
        public IEnumerable<SelectListItem> PageSizeOptions { get; set; }
    }
}
