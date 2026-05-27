namespace MiniBookstoreCatalogMVC.ViewModels
{
    // ViewModel dùng cho trang chi tiết sách
    // Hiển thị đầy đủ thông tin hơn so với List
    public class BookDetailViewModel
    {
        public int Id { get; set; }
        public string ISBN { get; set; } = string.Empty;
        public string Title { get; set; } = string.Empty;
        public string Author { get; set; } = string.Empty;
        public string Category { get; set; } = string.Empty;
        public decimal Price { get; set; }
        public int StockQuantity { get; set; }
        public int PublishedYear { get; set; }
        public string Publisher { get; set; } = string.Empty;
        public DateTime LastUpdated { get; set; }

        // Trạng thái tồn kho - logic tương tự BookListItemViewModel
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
