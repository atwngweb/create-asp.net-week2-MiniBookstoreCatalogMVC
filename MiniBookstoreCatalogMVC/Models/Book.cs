namespace MiniBookstoreCatalogMVC.Models
{
    // Book model - đại diện cho một cuốn sách trong hệ thống
    public class Book
    {
        // Khóa chính, định danh duy nhất
        public int Id { get; set; }

        // Mã ISBN quốc tế của sách
        public string ISBN { get; set; } = string.Empty;

        // Tên sách
        public string Title { get; set; } = string.Empty;

        // Tên tác giả
        public string Author { get; set; } = string.Empty;

        // Thể loại sách (ví dụ: Fiction, Technology, Science...)
        public string Category { get; set; } = string.Empty;

        // Giá bán (VND)
        public decimal Price { get; set; }

        // Số lượng tồn kho hiện tại
        public int StockQuantity { get; set; }

        // Năm xuất bản
        public int PublishedYear { get; set; }

        // Tên nhà xuất bản
        public string Publisher { get; set; } = string.Empty;

        // Ngày cập nhật thông tin sách gần nhất
        public DateTime LastUpdated { get; set; }
    }
}
