namespace Repository;

public class InsertResponse
{
    public InsertResponse(string source)
    {
        this.Source = source;
    }

    public string Source { get; }
}