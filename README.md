# ServiFlow: Polyglot Microservices Marketplace

## 📌 Project Overview
ServiFlow is a distributed, on-demand home services marketplace that connects skilled professionals (plumbers, electricians, cleaners, etc.) with customers. The project is designed as a **Polyglot Microservices Architecture**, demonstrating seamless interoperability between .NET and Java ecosystems using **RabbitMQ** for asynchronous messaging.

## 🏗️ System Architecture & Tech Stack

The system is decomposed into three specialized microservices, each leveraging a different technology stack to address specific domain needs:

### 1. User Service (.NET 8)
- **Role:** Handles identity management, authentication, and user profiles (Admins, Providers, Customers).
- **Tech:** ASP.NET Core Web API, Entity Framework Core.
- **Database:** PostgreSQL.

### 2. Wallet Service (Java EE / Jakarta EE)
- **Role:** Manages customer financial accounts, fund deposits, and transaction integrity.
- **Tech:** Enterprise JavaBeans (EJBs) for robust business logic.
- **Database:** PostgreSQL.

### 3. Booking Service (Spring Boot)
- **Role:** Orchestrates service categories, professional offers, and the end-to-end booking lifecycle.
- **Tech:** Spring Boot, Spring Data JPA.
- **Database:** PostgreSQL.

## 🚀 Asynchronous Workflow (RabbitMQ)
We utilize **RabbitMQ** to handle cross-service communication and ensure data consistency without tight coupling:
- **Booking Flow:** When a customer books a service, a message is sent to verify the wallet balance.
- **Transaction Logic:** The Wallet service deducts funds asynchronously; if insufficient, it triggers a rollback in the Booking service.
- **Notifications:** Users receive status updates and confirmations via JSON-based REST API endpoints.

## 🛠️ Infrastructure
The entire environment is containerized for consistent development across the team:
- **Docker Compose:** Orchestrates PostgreSQL instances, RabbitMQ broker, and the microservices.
- **Dev Containers:** Standardized VS Code environments for .NET and Java development.

## 🚦 Getting Started
1. **Clone the Repo:**
   ```bash
   git clone [https://github.com/YourUsername/ServiFlow.git](https://github.com/YourUsername/ServiFlow.git)
2. **Launch Infrastructure:**
   ```bash
   docker-compose up -d
3. **Access Services:**
   Detailed API documentation (Swagger/OpenAPI) is available for each service once running.

## 👥 Team
  - Abdulla hassanien
  - Mostafa mahmoud 
  - Mohab sobhy 
  
