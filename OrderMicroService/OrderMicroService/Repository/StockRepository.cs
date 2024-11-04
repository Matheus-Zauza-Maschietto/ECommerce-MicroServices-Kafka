using OrderMicroService.Repository.Interfaces;

namespace OrderMicroService.Repository;

public class StockRepository : IStockRepository
{
    private readonly HttpClient _stockClient;

    public StockRepository(HttpClient stockClient)
    {
        _stockClient = stockClient;
    }

    public async Task<bool> StockExists(int stockId, int quantity)
    {
        HttpResponseMessage response = await _stockClient.GetAsync($"stock/{stockId}/?quantity={quantity}");  
        string responseString = await response.Content.ReadAsStringAsync();
        return bool.Parse(responseString);
    }

}