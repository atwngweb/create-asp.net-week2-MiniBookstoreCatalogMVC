using MiniBookstoreCatalogMVC.Models;

namespace MiniBookstoreCatalogMVC.Services
{
    // BookService implement IBookService
    // Dùng dữ liệu in-memory (List<Book>) thay vì database
    public class BookService : IBookService
    {
        // Danh sách sách mẫu - khởi tạo 1 lần, dùng lại cho mọi request
        private readonly List<Book> _books;

        public BookService()
        {
            // Khởi tạo dữ liệu mẫu gồm 10 cuốn sách đa dạng thể loại
            _books = new List<Book>
            {
                new Book {
                    Id = 1,
                    ISBN = "978-0-13-468599-1",
                    Title = "Clean Code: A Handbook of Agile Software",
                    Author = "Robert C. Martin",
                    Category = "Technology",
                    Price = 350000,
                    StockQuantity = 12,
                    PublishedYear = 2008,
                    Publisher = "Prentice Hall",
                    LastUpdated = new DateTime(2024, 1, 15)
                },
                new Book {
                    Id = 2,
                    ISBN = "978-0-201-63361-0",
                    Title = "Design Patterns: GoF",
                    Author = "Gang of Four",
                    Category = "Technology",
                    Price = 420000,
                    StockQuantity = 3,
                    PublishedYear = 1994,
                    Publisher = "Addison-Wesley",
                    LastUpdated = new DateTime(2024, 2, 10)
                },
                new Book {
                    Id = 3,
                    ISBN = "978-0-06-112008-4",
                    Title = "To Kill a Mockingbird",
                    Author = "Harper Lee",
                    Category = "Fiction",
                    Price = 185000,
                    StockQuantity = 0,
                    PublishedYear = 1960,
                    Publisher = "HarperCollins",
                    LastUpdated = new DateTime(2024, 3, 5)
                },
                new Book {
                    Id = 4,
                    ISBN = "978-0-7432-7357-1",
                    Title = "1984",
                    Author = "George Orwell",
                    Category = "Fiction",
                    Price = 160000,
                    StockQuantity = 20,
                    PublishedYear = 1949,
                    Publisher = "Secker & Warburg",
                    LastUpdated = new DateTime(2024, 1, 20)
                },
                new Book {
                    Id = 5,
                    ISBN = "978-0-385-47378-3",
                    Title = "The Alchemist",
                    Author = "Paulo Coelho",
                    Category = "Fiction",
                    Price = 175000,
                    StockQuantity = 2,
                    PublishedYear = 1988,
                    Publisher = "HarperOne",
                    LastUpdated = new DateTime(2024, 4, 1)
                },
                new Book {
                    Id = 6,
                    ISBN = "978-1-491-95038-4",
                    Title = "ASP.NET Core in Action",
                    Author = "Andrew Lock",
                    Category = "Technology",
                    Price = 520000,
                    StockQuantity = 8,
                    PublishedYear = 2021,
                    Publisher = "Manning Publications",
                    LastUpdated = new DateTime(2024, 5, 12)
                },
                new Book {
                    Id = 7,
                    ISBN = "978-0-14-028329-7",
                    Title = "Sapiens: A Brief History of Humankind",
                    Author = "Yuval Noah Harari",
                    Category = "Science",
                    Price = 280000,
                    StockQuantity = 0,
                    PublishedYear = 2011,
                    Publisher = "Harvill Secker",
                    LastUpdated = new DateTime(2024, 2, 28)
                },
                new Book {
                    Id = 8,
                    ISBN = "978-1-250-30185-3",
                    Title = "Atomic Habits",
                    Author = "James Clear",
                    Category = "Self-Help",
                    Price = 220000,
                    StockQuantity = 35,
                    PublishedYear = 2018,
                    Publisher = "Avery",
                    LastUpdated = new DateTime(2024, 6, 3)
                },
                new Book {
                    Id = 9,
                    ISBN = "978-0-307-37840-1",
                    Title = "The Lean Startup",
                    Author = "Eric Ries",
                    Category = "Business",
                    Price = 260000,
                    StockQuantity = 4,
                    PublishedYear = 2011,
                    Publisher = "Crown Business",
                    LastUpdated = new DateTime(2024, 3, 18)
                },
                new Book {
                    Id = 10,
                    ISBN = "978-0-374-27563-1",
                    Title = "Thinking, Fast and Slow",
                    Author = "Daniel Kahneman",
                    Category = "Science",
                    Price = 310000,
                    StockQuantity = 6,
                    PublishedYear = 2011,
                    Publisher = "Farrar, Straus and Giroux",
                    LastUpdated = new DateTime(2024, 4, 22)
                }
            };
        }

        // Trả toàn bộ danh sách sách
        public List<Book> GetAllBooks() => _books;

        // Tìm sách theo Id, trả null nếu không có
        public Book? GetBookById(int id)
            => _books.FirstOrDefault(b => b.Id == id);

        // Tổng số đầu sách trong catalog
        public int GetTotalBooks() => _books.Count;

        // Tổng số lượng tồn kho
        public int GetTotalStock() => _books.Sum(b => b.StockQuantity);

        // Sách hết hàng: StockQuantity == 0
        public List<Book> GetOutOfStockBooks()
            => _books.Where(b => b.StockQuantity == 0).ToList();

        // Sách sắp hết: StockQuantity > 0 VÀ < 5
        public List<Book> GetLowStockBooks()
            => _books.Where(b => b.StockQuantity > 0 && b.StockQuantity < 5).ToList();
    }
}
