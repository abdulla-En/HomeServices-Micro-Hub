FROM mcr.microsoft.com/dotnet/sdk:8.0

# path where dotnet ef command store in [add it to PATH to found by the container sys]
ENV PATH="$PATH:/root/.dotnet/tools"

# 2. install the dotnet ef 
RUN dotnet tool install --global dotnet-ef

WORKDIR /app

EXPOSE 5000

# run with hot reload [Dev time not production]
CMD ["dotnet", "watch", "run", "--urls", "http://0.0.0.0:5000"]