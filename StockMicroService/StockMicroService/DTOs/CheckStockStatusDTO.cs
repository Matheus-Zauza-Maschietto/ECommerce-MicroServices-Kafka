namespace StockMicroService.DTOs;

public record CheckStockStatusDTO(IEnumerable<StockCheckDTO> StockChecks);