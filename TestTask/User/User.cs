using System.ComponentModel.DataAnnotations;

namespace TestTask.User;

public class User
{
    public User(){}

    public User(int CardCode, string LastName, string FirstName,
        string Surname, string PhoneMobile, string Email,
        string GenderId, DateTime Birthday, string City,
        int Pincode, int Bonus, int Turnover)
    {
        CardCode = CardCode;
        LastName = LastName;
        FirstName = FirstName;
        Surname = Surname;
        PhoneMobile = PhoneMobile;
        Email = Email;
        GenderId = GenderId;
        Birthday = Birthday;
        City = City;
        Pincode = Pincode;
        Bonus = Bonus;
        Turnover = Turnover;
    }
    [Key]
    public int PK_Id { get; set; }
    public int CardCode { get; set; }
    public string LastName { get; set; }
    public string FirstName { get; set; }
    public string? Surname { get; set; }
    public string? PhoneMobile { get; set; }
    public string? Email { get; set; }
    public string? GenderId { get; set; }
    public DateTime Birthday { get; set; }
    public string? City { get; set; }
    public int Pincode { get; set; }
    public int Bonus { get; set; }
    public int Turnover { get; set; }
}