using ClosedXML.Excel;

namespace TestTask.DataProvider.ExcelDataProvider;

public class ExcelDataProvider
{
    private readonly IXLWorksheet _worksheet;

    public ExcelDataProvider(string dataPath)
    {
        var xlWorkbook = new XLWorkbook(dataPath);
        _worksheet = xlWorkbook.Worksheet(1);
    }

    public string GetData(string dataPosition)
    {
        return _worksheet.Cell(dataPosition).GetValue<string>();
    }

    public List<int> GetTableSize()
    {
        return new List<int>(){_worksheet.RowCount(), _worksheet.ColumnCount()};
    }
}