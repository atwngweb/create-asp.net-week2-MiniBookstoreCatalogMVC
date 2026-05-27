using Microsoft.AspNetCore.Mvc;
using MiniBookstoreCatalogMVC.Services;
using MiniBookstoreCatalogMVC.ViewModels;

namespace MiniBookstoreCatalogMVC.Controllers
{
    public class BooksController : Controller
    {
        // Dependency Injection: nhận IBookService qua constructor
        // Controller KHÔNG biết implementation cụ thể, chỉ biết interface
        private readonly IBookService _bookService;

        public BooksController(IBookService bookService)
        {
            _bookService = bookService;
        }

        // GET: /Books
        // Hiển thị danh sách tất cả sách
        public IActionResult Index()
        {
            var books = _bookService.GetAllBooks();

            // Mapping từ Book model sang BookListItemViewModel
            // Không truyền model trực tiếp vào View
            var viewModels = books.Select(b => new BookListItemViewModel
            {
                Id           = b.Id,
                Title        = b.Title,
                Author       = b.Author,
                Category     = b.Category,
                Price        = b.Price,
                StockQuantity = b.StockQuantity
            }).ToList();

            return View(viewModels);
        }

        // GET: /Books/Detail/1
        // Hiển thị chi tiết một cuốn sách theo Id
        public IActionResult Detail(int id)
        {
            var book = _bookService.GetBookById(id);

            // Nếu không tìm thấy sách → trả về 404
            if (book == null)
                return NotFound();

            var viewModel = new BookDetailViewModel
            {
                Id            = book.Id,
                ISBN          = book.ISBN,
                Title         = book.Title,
                Author        = book.Author,
                Category      = book.Category,
                Price         = book.Price,
                StockQuantity = book.StockQuantity,
                PublishedYear  = book.PublishedYear,
                Publisher     = book.Publisher,
                LastUpdated   = book.LastUpdated
            };

            return View(viewModel);
        }

        // GET: /Books/Stats
        // Hiển thị thống kê tổng quan kho sách
        public IActionResult Stats()
        {
            var outOfStock = _bookService.GetOutOfStockBooks();
            var lowStock   = _bookService.GetLowStockBooks();

            var viewModel = new BookStatsViewModel
            {
                TotalBooks      = _bookService.GetTotalBooks(),
                TotalStock      = _bookService.GetTotalStock(),
                OutOfStockCount = outOfStock.Count,
                LowStockCount   = lowStock.Count,
                OutOfStockTitles = outOfStock.Select(b => b.Title).ToList(),
                LowStockTitles   = lowStock.Select(b => b.Title).ToList()
            };

            return View(viewModel);
        }

        // GET: /Books/Welcome
        // Demo dùng Content() trả về text thuần
        public IActionResult Welcome()
        {
            return Content("Chào mừng đến với Mini Bookstore Catalog MVC!");
        }

        // GET: /Books/BookJson
        // Demo dùng Json() trả về dữ liệu JSON cho API
        public IActionResult BookJson()
        {
            var books = _bookService.GetAllBooks()
                .Select(b => new
                {
                    b.Id,
                    b.Title,
                    b.Author,
                    b.Price,
                    b.StockQuantity
                });

            return Json(books);
        }

        // GET: /Books/GoToStats
        // Demo dùng RedirectToAction()
        public IActionResult GoToStats()
        {
            // Redirect sang action Stats trong cùng controller
            return RedirectToAction("Stats");
        }

        // GET: /Books/Force404
        // Demo dùng NotFound() để trả 404 chủ động
        public IActionResult Force404()
        {
            return NotFound("Trang này không tồn tại (demo NotFound).");
        }
    }
}
