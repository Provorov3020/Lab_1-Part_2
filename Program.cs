using System;
using System.Globalization;
using System.Text;

public interface IDateTime
{
    string GetDateTime();
}

public class EuropeanDateTime: IDateTime
{
    private string _dateTime;
    public EuropeanDateTime(string dateTime)
    {
        _dateTime = dateTime; // Пример: "07/04/2025"
    }
    public string GetDateTime()
    {
        CultureInfo myCIintl = new CultureInfo("es-ES", false);
        return DateTime.Now.ToString(myCIintl);
    }
}

public class AmericanDateTime: IDateTime
{
    private string _dateTime;
    public AmericanDateTime(string dateTime)
    {
        _dateTime = dateTime; // Пример: "04/07/2025"
    }
    public string GetDateTime()
    {
        CultureInfo myCIintl = new CultureInfo("en-US", false);
        return DateTime.Now.ToString(myCIintl);
       
    }
}

public class AsteriskDecorator : IDateTime // декоратор с символом *
{
    private EuropeanDateTime _dateTime;
    public AsteriskDecorator(EuropeanDateTime dateTime) 
    {
       _dateTime = dateTime;
    }
   
    public string GetDateTime()
    {
        StringBuilder sb = new StringBuilder();
        sb.Append("*").Append(_dateTime.GetDateTime()).Append("*");
        return sb.ToString();
    }
}

public class DashDecorator : IDateTime // декоратор с символом -
{
    private AmericanDateTime _dateTime;
    
    public DashDecorator(AmericanDateTime dateTime)
    {
       _dateTime = dateTime;
    }

    public string GetDateTime()
    {
        StringBuilder sb = new StringBuilder();
        sb.Append("-").Append(_dateTime.GetDateTime()).Append("-");
        return sb.ToString();
    }
}
public class Program
{
    public static void Main(string[] args)
    {
        var europeanDateTime = new EuropeanDateTime("07/04/2025");
        var decoratedEuropeanTime = new AsteriskDecorator(europeanDateTime);
        Console.WriteLine("Decorated European DateTime: " + decoratedEuropeanTime.GetDateTime());

        var americanDateTime = new AmericanDateTime("04/07/2025");
        var decoratedAmericanTime = new DashDecorator(americanDateTime);
        Console.WriteLine("Decorated American DateTime: " + decoratedAmericanTime.GetDateTime());
           
     
    }
}

