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
## Before You Start (Install These Once)

1. **Docker Desktop** → https://docker.com
2. **VS Code** → https://code.visualstudio.com
3. **VS Code Extensions** (install from Extensions tab):
   - `Dev Containers` by Microsoft
   - `Database Client` by Weijan Chen per each dev container environment 
   - `Extension Pack for Java` by Microsoft per each dev container environment
  (includes Language Support for Java by Red Hat)
  → Without this: no auto-complete or error highlighting in Spring and Jakarta EE

---

## Step 1: Clone the Project

Open a terminal and run:

```bash
git clone <repo-url>
cd DSProject
```

---

## Step 2: Start the Infrastructure

This starts the databases and RabbitMQ:

```bash
docker-compose up -d --build
```

Check that everything is running:

```bash
docker ps
```

You should see **4 containers** with status **Up** ✅

---

## Step 3: Connect to Databases (Database Client)

1. Click the **Database Client icon** in the left sidebar (looks like a database)
2. Click the **+** button at the top
3. Choose **PostgreSQL**
4. Fill in the details and click **Connect**
5. Repeat for each database below

---

### User DB
| Field | Value |
|---|---|
| Connection Name | User DB |
| Server | localhost |
| Port | 5432 |
| Database | user_service_db |
| Username | abdulla |
| Password | password123! |

---

### Booking/Wallet DB
| Field | Value |
|---|---|
| Connection Name | Booking Wallet DB |
| Server | localhost |
| Port | 5433 |
| Database | booking_wallet_db |
| Username | abdulla |
| Password | password123! |

---

### Category DB
| Field | Value |
|---|---|
| Connection Name | Category DB |
| Server | localhost |
| Port | 5434 |
| Database | category_db |
| Username | abdulla |
| Password | password123! |

> ⚠️ Make sure `docker compose up` is running before you connect, otherwise the connection will fail.

### ⚠️ Important: Which Host to Use?

The host value depends on **where you installed the Database Client extension**:

| Installed Where | Host to Use | Example |
|---|---|---|
| On your machine (outside container) | `localhost` | normal install |
| Inside a devcontainer | `host.docker.internal` | installed inside container |

**Why?**
- If the extension is **outside** any container → use `localhost` because the ports are exposed to your machine.
- If the extension is **inside a devcontainer** → use `host.docker.internal` because the devcontainer is not on the same Docker network as the databases, so it reaches them through the host machine.

---

## Step 4: Open Each Service

> Open each service in a **separate VS Code window**.
> When VS Code asks "Reopen in Container" → click it and wait for the build.

---

### User Service (ASP.NET)

1. `File` → `Open Folder` → select `User-Service`
2. Click **Reopen in Container**
3. Wait for the container to build
4. In the terminal inside the container:

```bash
dotnet watch run
```

Service runs on → **http://localhost:5000**

---

### Category Service (Spring Boot)

1. `File` → `Open Folder` → select `CategoryService`
2. Click **Reopen in Container**
3. Wait for the container to build
4. In the terminal inside the container:

```bash
mvn spring-boot:run
```

Service runs on → **http://localhost:8082**

---

### Notification Service (Spring Boot)

1. `File` → `Open Folder` → select `NotificationService`
2. Click **Reopen in Container**
3. Wait for the container to build
4. In the terminal inside the container:

```bash
mvn spring-boot:run
```

Service runs on → **http://localhost:8083**

---

### Booking/Wallet Service (Jakarta EE)

> This service uses a WAR file, so it needs 2 steps.

1. `File` → `Open Folder` → select `BookingWalletService`
2. Click **Reopen in Container**
3. Wait for the container to build
4. In the terminal inside the container, build the WAR file:

```bash
mvn clean package
```

5. Open a **new terminal outside the container** (in DSProject folder) and run:

```bash
docker compose up -d --build booking-wallet-service 
```

Service runs on → **http://localhost:8081**

---

## All Services Summary

| Service | Technology | Port |
|---|---|---|
| User Service | ASP.NET Core | 5000 |
| Booking/Wallet Service | Jakarta EE (EJB) | 8081 |
| Category Service | Spring Boot | 8082 |
| Notification Service | Spring Boot | 8083 |
| RabbitMQ Dashboard | - | 15672 |

---

## RabbitMQ Dashboard

Open in browser → **http://localhost:15672**

- Username: `guest`
- Password: `guest`

## 👥 Team
  - Abdulla hassanien
  - Mostafa mahmoud 
  - Mohab sobhy 
  
