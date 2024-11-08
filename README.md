# ECommerce-MicroServices-Kafka

## O que é

Tem como objetivo implementar uma arquitetura utilizada em micro serviços com dotnet, utilizando como ferramenta de mensageria o kafka. 

### Componentes Principais 

- Api Gateway (ECommerceApi)
- Api de produtos com banco próprio (ProductMicroService)
- Api de estoques com banco próprio (StockMicroService)
- Api de vendas com banco próprio (OrderMicroService)
- Kafka como aplicação de Mensageria

## System Design
![System Design](./Documentacao/microService%20-%20System%20Design.png)

## Alterações futuras
- Finalização do projeto "EcommerceApi" como um api gateaway para os microserviços.
