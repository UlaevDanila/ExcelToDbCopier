using System.ComponentModel.DataAnnotations;

namespace TestTask.User;

public class User(int CardCode, string LastName,string FirstName, 
                    string Surname,string PhoneMobile,string Email,
                    string GenderId, DateTime Birthday, string City,
                    int Pincode, int Bonus,int Turnover)
{
    [Key]
    public int PK_Id { get; set; }
    public int CardCode { get; set; } = CardCode;
    public string LastName { get; set; }  = LastName;
    public string FirstName { get; set; } = FirstName;
    public string? Surname { get; set; } = Surname;
    public string? PhoneMobile { get; set; } = PhoneMobile;
    public string? Email { get; set; } = Email;
    public string? GenderId { get; set; } = GenderId;
    public DateTime Birthday { get; set; } = Birthday;
    public string? City { get; set; } = City;
    public int Pincode { get; set; } = Pincode;
    public int Bonus { get; set; } = Bonus;
    public int Turnover { get; set; } = Turnover;
}