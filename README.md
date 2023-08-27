<div align="center">
  <h1>ShopSavvy Microservices Project</h1>
  <p>Building a Scalable and Modern E-Commerce Platform</p>
</div>

## Table of Contents

- [Introduction](#introduction)
- [Services Overview](#services-overview)
- [Getting Started](#getting-started)
- [Conclusion](#conclusion)

## Introduction

Welcome to the ShopSavvy Microservices Project repository. This project is dedicated to creating a robust and scalable e-commerce platform using microservices architecture, all built with .NET Core. Each service is designed to serve a specific purpose, leveraging various technologies to ensure high performance and maintainability.

## Services Overview

1. **Catalog API**

   - Description: Manages the product catalog using MongoDB.
   - Technology Stack: .NET Core, MongoDB
   - Swagger Documentation: [Catalog API Swagger (Not Deployed Yet)](link_to_catalog_swagger)

2. **Basket API**

   - Description: Handles shopping cart functionality with Redis caching.
   - Technology Stack: .NET Core, Redis
   - Swagger Documentation: [Basket API Swagger (Not Deployed Yet)](link_to_basket_swagger)

3. **Discount API**

   - Description: Provides discount services using Dapper micro ORM with PostgreSQL.
   - Technology Stack: .NET Core, Dapper, PostgreSQL
   - Swagger Documentation: [Discount API Swagger (Not Deployed Yet)](link_to_discount_swagger)

4. **Discount gRPC API**

   - Description: Offers gRPC-based discount services.
   - Technology Stack: .NET Core, gRPC
   - Swagger Documentation: [Discount gRPC API Swagger (Not Deployed Yet)](link_to_discount_grpc_swagger)

5. **Order API**

   - Description: Implements clean architecture using SQL Server and EF Core for order management. Integrates RabbitMQ with MassTransit for messaging.
   - Technology Stack: .NET Core, EF Core, SQL Server, RabbitMQ
   - Swagger Documentation: [Order API Swagger (Not Deployed Yet)](link_to_order_swagger)

6. **ShopSavvy Aggregator API**

   - Description: Aggregates data from various microservices to present a unified view.
   - Technology Stack: .NET Core
   - Swagger Documentation: [ShopSavvy Aggregator API Swagger (Not Deployed Yet)](link_to_shopsavvy_swagger)

7. **Ocelot API Gateway**
   - Description: Serves as an API gateway to manage requests and routing.
   - Technology Stack: .NET Core, Ocelot
   - Swagger Documentation: [Ocelot API Gateway Swagger (Not Deployed Yet)](link_to_ocelot_swagger)

## Getting Started

To get started with the ShopSavvy Microservices Project, follow these steps:

1. Clone this repository:
   ```sh
   git clone https://github.com/mahmmoudkinawy/ShopSavvy.git
   cd ShopSavvy
   ```
2. Run the application stack using Docker Compose
   ```sh
   docker compose -f docker-compose.yml -f docker-compose.override.yml up -d
   ```

## Conclusion

The ShopSavvy Microservices Project showcases my expertise in building scalable and modern e-commerce platforms using cutting-edge technologies. Through this project, I have demonstrated proficiency in .NET Core, microservices architecture, Dockerization, and integrating various databases and services. The project emphasizes clean code, maintainability, and efficient communication between microservices. The use of Swagger documentation underscores my commitment to clear and accessible APIs.

With its modular design and adherence to best practices, the ShopSavvy project serves as a testament to my ability to create robust and reliable software solutions. The integration of advanced technologies like Redis, MongoDB, PostgreSQL, and RabbitMQ illustrates my versatility in working with a variety of tools.

This project not only highlights my technical skills but also my dedication to creating high-quality software that meets real-world business needs. I'm excited to bring my experience and expertise to new challenges and opportunities.

Thank you for taking the time to explore the ShopSavvy Microservices Project!
