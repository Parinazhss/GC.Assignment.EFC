
using ConsoleApp.Services;
using System;

namespace ConsoleApp;


internal class ConsoleUI
{
    private readonly UserService _userService;
    private readonly LoanService _loanService;
    private readonly BookService _bookService;


    public ConsoleUI(UserService userService, LoanService loanService, BookService bookService)
    {
        _userService = userService;
        _loanService = loanService;
        _bookService = bookService;
    }


    // USERS 
    public void CreateUser_UI()
    {
        Console.Clear();
        Console.WriteLine("----CREATE YOUR PROFILE----");

        Console.Write("First Name: ");
        var firstName = Console.ReadLine()!;

        Console.Write("Last Name: ");
        var lastName = Console.ReadLine()!;

        Console.Write("Email: ");
        var email = Console.ReadLine()!;

        Console.Write("Role: ");
        var roleName = Console.ReadLine()!;

        Console.Write("Address Street: ");
        var streetName = Console.ReadLine()!;

        Console.Write("City: ");
        var city = Console.ReadLine()!;

        Console.Write("Postal Code: ");
        var postalCode = Console.ReadLine()!;




        var result = _userService.CreateUser(firstName, lastName, email, roleName, streetName, city, postalCode);
        if (result != null)
        {
            Console.Clear();
            Console.WriteLine("Profile Was Created");
            Console.ReadKey();

        }

    }
    public void GetUsers_UI()
    {
        Console.Clear();

        var users = _userService.GetAllUsers();
        foreach (var user in users)
        {
            Console.WriteLine($"{user.FirstName}:{user.LastName}:{user.Email}");
        }
        Console.ReadKey();
    }
    public void UpdatedUser_UI()
    {
        Console.Clear();
        Console.Write("Enter User Id : ");

        var id = int.Parse(Console.ReadLine()!);

        var user = _userService.GetUserById(id);
        if (user != null)
        {
            Console.WriteLine($"{user.FirstName} {user.LastName} {user.Address.StreetName} {user.Address.City} {user.Address.PostalCode}");
            Console.WriteLine();

            Console.Write("New User First-Name:  ");

            user.FirstName = Console.ReadLine()!;

            var newUser = _userService.Update(user);
            Console.WriteLine($"{user.FirstName} {user.LastName} {user.Address.StreetName} {user.Address.City} {user.Address.PostalCode}");

        }
        else
        {
            Console.WriteLine("NO USER FOUND");
        }

        Console.ReadKey();
    }
    public void DeleteUser_UI()
    {

        Console.Clear();
        Console.Write("Enter User Id which You Want to Delete : ");

        var id = int.Parse(Console.ReadLine()!);

        var user = _userService.GetUserById(id);
        if (user != null)
        {
            _userService.Delete(user.Id);
            Console.WriteLine("User Was Deleted");

        }
        else
        {
            Console.WriteLine("NO USER FOUND");
        }

        Console.ReadKey();
    }


    // LOANS
    public void CreateLoans_UI()
    {
        Console.Clear();
        Console.WriteLine("----CREATE YOUR LOAN ----");

        Console.Write("Date of Loan (YYYY-MM-DD): ");
        var loanDateInput = Console.ReadLine();

        Console.Write("Date of Return (YYYY-MM-DD): ");
        var returnDateInput = Console.ReadLine();

        // Parse loanDate and returnDate strings into DateTime objects
        if (DateTime.TryParse(loanDateInput, out DateTime loanDate) && DateTime.TryParse(returnDateInput, out DateTime returnDate))
        {
            // Om parsingen lyckas, fortsätt med inmatning av andra uppgifter

            Console.Write("First Name: ");
            var firstName = Console.ReadLine()!;

            Console.Write("Last Name: ");
            var lastName = Console.ReadLine()!;

            Console.Write("Email: ");
            var email = Console.ReadLine()!;

            Console.Write("Role: ");
            var roleName = Console.ReadLine()!;

            Console.Write("Address Street: ");
            var streetName = Console.ReadLine()!;

            Console.Write("City: ");
            var city = Console.ReadLine()!;

            Console.Write("Postal Code: ");
            var postalCode = Console.ReadLine()!;

            Console.Write("Tile of Book: ");
            var title = Console.ReadLine()!;

            Console.Write("Writer of Book: ");
            var writer = Console.ReadLine()!;


            var result = _loanService.CreateLoan(loanDate, returnDate, firstName, lastName, email, roleName, streetName, city, postalCode, title, writer);

            if (result != null)
            {
                Console.Clear();
                Console.WriteLine("Loan Was Created");
                Console.ReadKey();
            }
        }
        else
        {
            // Om parsingen misslyckas, meddela användaren
            Console.WriteLine("Invalid date format. Please enter dates in YYYY-MM-DD format.");
        }
    }

    public void GetLoans_UI()
    {
        Console.Clear();

        var loans = _loanService.GetAllLoans();
        foreach (var loan in loans)
        {
            Console.WriteLine($"{loan.LoanDate}:{loan.ReturnDate}:{loan.BookId}:{loan.UserId}");
        }
        Console.ReadKey();
    }

    public void UpdatedLoans_UI()
    {
        Console.Clear();
        Console.Write("Enter Loan Id : ");

        var id = int.Parse(Console.ReadLine()!);

        var loan = _loanService.GetLoanById(id);
        if (loan != null)
        {
            Console.WriteLine($"{loan.LoanDate} {loan.ReturnDate}  ");
            Console.WriteLine();

            Console.Write("New Return Date (YYYY-MM-DD):  ");
            // Läs in den nya returdatumsträngen från användaren
            var newReturnDateStr = Console.ReadLine()!;

            // Konvertera strängen till en DateTime
            if (DateTime.TryParse(newReturnDateStr, out DateTime newReturnDate))
            {
                // Uppdatera returdatumet för lånet
                loan.ReturnDate = newReturnDate;

                // Uppdatera lånet i databasen
                var updatedLoan = _loanService.Update(loan);

                // Skriv ut informationen om det uppdaterade lånet

                Console.WriteLine($"{updatedLoan.LoanDate} {updatedLoan.ReturnDate}  ");
            }
            else
            {
                Console.WriteLine("Invalid date format. Please enter date in YYYY-MM-DD format.");
            }
        }
        else
        {
            Console.WriteLine("NO LOAN FOUND");
        }

        Console.ReadKey();
    }

    public void DeleteLoan_UI()
    {

        Console.Clear();
        Console.Write("Enter Loan Id which You Want to Delete : ");

        var id = int.Parse(Console.ReadLine()!);

        var loan = _loanService.GetLoanById(id);
        if (loan != null)
        {
            _loanService.Delete(loan.Id);
            Console.WriteLine("User Was Deleted");

        }
        else
        {
            Console.WriteLine("NO USER FOUND");
        }

        Console.ReadKey();
    }
}


