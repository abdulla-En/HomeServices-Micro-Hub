package com.example.dsProject.config;

import jakarta.annotation.sql.DataSourceDefinition;
import jakarta.ejb.Singleton;
import jakarta.ejb.Startup;

@DataSourceDefinition(
    name = "java:app/jdbc/BookingWalletDS",
    className = "org.postgresql.ds.PGSimpleDataSource",
    serverName = "booking_wallet_db",
    portNumber = 5432,
    databaseName = "booking_wallet_db",
    user = "abdulla",
    password = "password123!"
)
@Singleton
@Startup
public class DataSourceConfig {}