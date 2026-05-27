namespace MiniBookstoreCatalogMVC.ViewModels
{
    // ViewModel dùng cho trang thống kê
    // Tổng hợp số liệu từ BookService để hiển thị dashboard
    public class BookStatsViewModel
    {
        // Tổng số đầu sách trong catalog
        public int TotalBooks { get; set; }

        // Tổng số lượng tồn kho
        public int TotalStock { get; set; }

        // Số đầu sách đã hết hàng
        public int OutOfStockCount { get; set; }

        // Số đầu sách sắp hết
        public int LowStockCount { get; set; }

        // Danh sách tên sách hết hàng (để hiển thị chi tiết)
        public List<string> OutOfStockTitles { get; set; } = new();

        // Danh sách tên sách sắp hết
        public List<string> LowStockTitles { get; set; } = new();
    }
}
