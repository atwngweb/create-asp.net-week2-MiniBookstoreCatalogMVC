namespace MiniBookstoreCatalogMVC.ViewModels
{
    // ViewModel dùng cho trang danh sách sách
    // Chỉ hiển thị các trường cần thiết, không cần ISBN hay Publisher
    public class BookListItemViewModel
    {
        public int Id { get; set; }
        public string Title { get; set; } = string.Empty;
        public string Author { get; set; } = string.Empty;
        public string Category { get; set; } = string.Empty;
        public decimal Price { get; set; }
        public int StockQuantity { get; set; }

        // Trạng thái tồn kho: được tính từ StockQuantity
        // Đây là nơi đặt logic nghiệp vụ — KHÔNG đặt logic này trong View
        public string StockStatus
        {
            get
            {
                if (StockQuantity == 0) return "Out Of Stock";
                if (StockQuantity < 5)  return "Low Stock";
                return "In Stock";
            }
        }
    }
}
