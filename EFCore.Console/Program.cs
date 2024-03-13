// See https://aka.ms/new-console-template for more information
using EFCore.Domain;
using EFCore.Infrastructure.Repository;
using Microsoft.EntityFrameworkCore;

Console.WriteLine("Hello, World!");

/*
using (ApplicationDbContext context = new())
{
  // Create the database if it does not exist
  context.Database.EnsureCreated();

  // Migrate the database
  if (context.Database.GetPendingMigrations().Any())
  {
    context.Database.Migrate();
  }
}
*/

/*
AddBook();
GetAllBooks();
GetBookById(1);
UpdateBook(1);
DeleteBook(1);

async void DeleteBook(int i)
{
  await using var context = new ApplicationDbContext();
  var book = await context.Books.FindAsync(i);
  context.Books.Remove(book);
  await context.SaveChangesAsync();
}

async void UpdateBook(int i)
{
  try
  {
    await using var context = new ApplicationDbContext();
    var book = await context.Books.FindAsync(i);
    
    // books = context.Books.Where(u => u.Publisher_Id == 1);
    //foreach (var book in books)
    //{ 
    //  book.Price = 12.99m;
    //}
    
    book.Isbn = "978-0451524936";
    await context.SaveChangesAsync();
  }
  catch (Exception ex)
  {
    Console.WriteLine(ex.Message);
  }
}

async void GetBookById(int i)
{
  try
  {
    await using var context = new ApplicationDbContext();
    var book = await context.Books.FirstOrDefaultAsync(p => p.Id == i);
    
    // var book_find = context.Books.Find(i);
    // var book_single = context.Books.Single(u => u.Isbn == "978-0451524935");
    // var books_contain = context.Books.Where(u => u.Isbn.Contains("12"));
    // var booksLikeContain = context.Books.Where(u => EF.Functions.Like(u.Isbn,"12%"));
    // var booksLikeContainMax = context.Books.Where(u => EF.Functions.Like(u.Isbn, "12%")).Max(p => p.Price);
  }
  catch (Exception ex)
  {
    Console.WriteLine(ex.Message);
  }
}

async void AddBook()
{
  BookEntity book = new()
  {
    Title = "1984",
    Author = "George Orwell",
    Isbn = "978-0451524935",
    Price = 9.99m,
    Publisher_Id = 4
  };
  await using var context = new ApplicationDbContext();
  var books = await context.AddAsync(book);
  await context.SaveChangesAsync();
}

async void GetAllBooks()
{
  await using var context = new ApplicationDbContext();
  var books = await context.Books.ToListAsync();
  // var booksSorted = context.Books.OrderBy(u => u.Title).ThenByDescending(u => u.Isbn);
  // var booksPaginating = context.Books.Skip(0).Take(2);
  foreach (var book in books)
  {
    Console.WriteLine(book.Title+ " - " + book.Isbn);
  }
}
*/
