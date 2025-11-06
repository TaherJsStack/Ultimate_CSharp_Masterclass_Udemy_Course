
//IDataDownloader dataDownloader = new SlowDataDownloader();
IDataDownloader dataDownloader = 
    new CashingDataDownloader( 
        new PrintingDataDownloader(
            new SlowDataDownloader()
        )
    );

Console.WriteLine(dataDownloader.DownloadData("id1"));
Console.WriteLine(dataDownloader.DownloadData("id2"));
Console.WriteLine(dataDownloader.DownloadData("id3"));
Console.WriteLine(dataDownloader.DownloadData("id1"));
Console.WriteLine(dataDownloader.DownloadData("id3"));
Console.WriteLine(dataDownloader.DownloadData("id1"));
Console.WriteLine(dataDownloader.DownloadData("id2"));

Console.ReadKey();

public class Cache<TKey, TData>
{
    private readonly Dictionary<TKey, TData> _cachedData = new();

    public TData Get(TKey key, Func<TKey, TData> getForTheFirstTime)
    {
        if (!_cachedData.ContainsKey(key)) 
        { 
           //_cachedData[key] = new SlowDataDownloader().DownloadData(key); 
           _cachedData[key] = getForTheFirstTime(key); 
        }
        return _cachedData[key];
    }
}

public class CashingDataDownloader : IDataDownloader
{
    private readonly IDataDownloader _dataDownloader;
    private readonly Cache<string, string> _cashe = new();

    public CashingDataDownloader(IDataDownloader dataDownloader)
    {
        _dataDownloader = dataDownloader;
    }

    public string DownloadData(string resourceId)
    {
        return _cashe.Get(resourceId, _dataDownloader.DownloadData);
    }
}


public class PrintingDataDownloader : IDataDownloader
{
    private readonly IDataDownloader _dataDownloader;
    
    public PrintingDataDownloader(IDataDownloader dataDownloader)
    {
        _dataDownloader = dataDownloader;
    }

    public string DownloadData(string resourceId)
    {
        var data = _dataDownloader.DownloadData(resourceId);
        Console.WriteLine("Data Is Ready!");
        return data;
    }
}

public interface IDataDownloader
{
    string DownloadData(string resourceId);
}

public class SlowDataDownloader : IDataDownloader
{
    //private readonly Cache<string, string> _cashe = new();

    //public string DownloadData(string resourceId)
    //{
    //    ////let's imagine this method downloads real data,
    //    ////and it does it slowly
    //    //Thread.Sleep(1000);
    //    //return $"Some data for {resourceId}";

    //    return _cashe.Get(resourceId, DownloadDataWithoutCashing);

    //}

    //public string DownloadDataWithoutCashing(string resourceId)
    public string DownloadData(string resourceId)
    {
        //let's imagine this method downloads real data,
        //and it does it slowly
        Thread.Sleep(1000);
        return $"Some data for {resourceId}";
    }
}
