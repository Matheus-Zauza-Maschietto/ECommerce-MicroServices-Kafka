using System.Text.RegularExpressions;
using StockMicroService.DTOs;
using StockMicroService.Models;
using StockMicroService.Repository.Interfaces;
using StockMicroService.Services.Interfaces;

namespace StockMicroService.Services;

public class StockService : IStockService
{
    private readonly IStockRepository _stockRepository;

    public StockService(IStockRepository stockRepository)
    {
        _stockRepository = stockRepository;
    }

    public async Task<IEnumerable<Stock>> GetStockByProductIdAsync(int productId)
    {
        IEnumerable<Stock> products = await _stockRepository.GetStockByProductIdAsync(productId);
        return products;
    }
    
    public async Task<Stock> GetStockByIdAsync(int id)
    {
        Stock? stock = await _stockRepository.GetStockByIdAsync(id);
        if(stock is null)
            throw new ApplicationException($"Stock with id: {id} not found");
        return stock;
    }
        
    public async Task<Stock> CreateStockAsync(StockDTO stockDto)
    {
        Stock stock = new Stock(stockDto);
        if (!ValidateHexCode(stock.Color))
            throw new ApplicationException("Invalid color");
        
        Stock createdStock = await _stockRepository.CreateStockAsync(stock);
        bool changesAsync = await _stockRepository.SaveChangesAsync();
        if(!changesAsync)
            throw new ApplicationException("Failed to add stock");
        return createdStock;
    }
    
    public async Task<Stock> DeleteStockByIdAsync(int id)
    {
        Stock? stock = await GetStockByIdAsync(id);
        Stock deletedStock = await _stockRepository.DeleteStockAsync(stock);
        bool changesAsync = await _stockRepository.SaveChangesAsync();
        if(!changesAsync)
            throw new ApplicationException("Failed to delete stock");
        return deletedStock;
    }
    
    public async Task<Stock> UpdateStockByIdAsync(int id, StockDTO stockDto)
    {
        Stock? stock = await GetStockByIdAsync(id);
        Stock toUpdateStock = stock.Update(stockDto);
        if (!ValidateHexCode(toUpdateStock.Color))
            throw new ApplicationException("Invalid color");
        Stock updatedStock = await _stockRepository.UpdateStockAsync(toUpdateStock);
        bool changesAsync = await _stockRepository.SaveChangesAsync();
        if(!changesAsync)
            throw new ApplicationException("Failed to update stock");
        return updatedStock;
    }

    public async Task<bool> CheckStockById(CheckStockStatusDTO checkStockDto)
    {
        var stocksTuples = checkStockDto.StockChecks.Select(p => (p.StockId, p.Quantity));
        var stocks = await _stockRepository.GetStocksWithoutAvaiability(stocksTuples);

        if(stocks.Any())
            return false;
        else 
            return true;
    }

    private bool ValidateHexCode(string hexCode)
    {
        return Regex.IsMatch(hexCode, @"([\dA-Fa-f]{6}|[\dA-Fa-f]{3})");
    }
}