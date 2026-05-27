using MiniBookstoreCatalogMVC.Models;

namespace MiniBookstoreCatalogMVC.Services
{
    // Interface định nghĩa "hợp đồng" cho BookService
    // Controller chỉ cần biết interface này, không cần biết implement cụ thể
    public interface IBookService
    {
        // Lấy toàn bộ danh sách sách
        List<Book> GetAllBooks();

        // Lấy sách theo Id, trả null nếu không tồn tại
        Book? GetBookById(int id);

        // Đếm tổng số đầu sách
        int GetTotalBooks();

        // Tính tổng số lượng tồn kho
        int GetTotalStock();

        // Lấy danh sách sách hết hàng (StockQuantity == 0)
        List<Book> GetOutOfStockBooks();

        // Lấy danh sách sách sắp hết (0 < StockQuantity < 5)
        List<Book> GetLowStockBooks();
    }
}
