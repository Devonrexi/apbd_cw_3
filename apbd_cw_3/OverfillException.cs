namespace apbd_cw_3;

public class OverfillException : Exception
{
    public OverfillException(string message)
    {
        Console.WriteLine(message);
    }
}