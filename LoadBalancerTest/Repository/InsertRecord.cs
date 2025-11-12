using StackExchange.Redis;

namespace Repository;

public class InsertRecord : IInsertRecord
{
    private readonly IDatabase _cache;

    public InsertRecord(string connectionString)
    {
        var muxer = ConnectionMultiplexer.Connect(connectionString);
        _cache = muxer.GetDatabase();
    }

    public async Task<InsertResponse> InsertData(string source)
    {
        var total = int.TryParse(
            await _cache.StringGetAsync(source),
            out int current_count) ? current_count : 0;

        total += 1;

        await _cache.StringSetAsync(source, total);
        return new InsertResponse(source);
    }
}
