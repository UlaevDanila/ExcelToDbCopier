using System.Globalization;
using TestTask.DataProvider.ExcelDataProvider;

namespace TestTask.DataDeserialzator;

public class DataDeserializator
{
    private readonly ExcelDataProvider _dataProvider;
    private List<User.User> _users;

    public DataDeserializator()
    {
        _dataProvider = new ExcelDataProvider("D:\\Programming\\C#\\TestTasks\\TestTask\\TestTask\\DbDump.xlsx");
        _users = new List<User.User>();
        var usersRecord = 0;
        for (int i = 2; i < _dataProvider.GetTableSize()[0]; i++)
        {
            _dataProvider.GetTableSize();
            var CardCode = DeserializeIntValue($"A{i}");
            if(CardCode == 0)
                break;
            var LastName = _dataProvider.GetData($"B{i}");
            var FirstName = _dataProvider.GetData($"C{i}");
            var Surname = _dataProvider.GetData($"D{i}");
            var PhoneMobile = _dataProvider.GetData($"E{i}");
            var Email = _dataProvider.GetData($"F{i}");
            var GenderId = _dataProvider.GetData($"G{i}");
            DateTime Birthday;
            try
            {
                Birthday = DeserializeData($"H{i}");
            }
            catch (FormatException e)
            {
                Console.WriteLine(e);
                continue;
            }
            var City = _dataProvider.GetData($"I{i}");
            var Pincode = DeserializeIntValue($"J{i}");
            var Bonus = DeserializeIntValue($"K{i}");
            var Turnover = DeserializeIntValue($"L{i}");
            _users.Add(new User.User(CardCode, LastName, FirstName, Surname, PhoneMobile, Email,
                                    GenderId, Birthday, City, Pincode, Bonus, Turnover));
        }
        Console.WriteLine(_users.Count);
        Console.WriteLine(_users.Count - _dataProvider.GetTableSize()[0]);
    }

    private int DeserializeIntValue(string dataPosition)
    {
        var value = _dataProvider.GetData(dataPosition);
        if (value == "")
        {
            return new int();
        }
        return Int32.Parse(value);
    }
    
    private DateTime DeserializeData(string dataPosition)
    {
        string date = _dataProvider.GetData(dataPosition);
        var firstPointIndex = date.IndexOf(".");
        var lastPointIndex = date.LastIndexOf(".");
        if (firstPointIndex == 1)
        {
            date = date.Insert(0, "0");
        }

        if (lastPointIndex - firstPointIndex == 2)
        {
            date = date.Insert(3, "0");
        }
        try
        {
            return DateTime.ParseExact(date, "dd.mm.yyyy", 
                CultureInfo.InvariantCulture);
        }
        catch (FormatException e)
        {
            Console.WriteLine(e);
            throw e;
        }
        
    }
    
    public List<User.User> GetAllUsers()
    {
        return _users;
    }
}