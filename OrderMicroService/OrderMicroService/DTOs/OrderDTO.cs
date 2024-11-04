namespace OrderMicroService.DTOs;

public record OrderDTO(IEnumerable<OrderProductDTO> Products); 