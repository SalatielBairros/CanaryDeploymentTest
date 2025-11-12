
namespace Repository;

public interface IInsertRecord
{
    Task<InsertResponse> InsertData(string source);
}