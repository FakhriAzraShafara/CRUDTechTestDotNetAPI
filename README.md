# Dot Net Tech Test

## Prerequisites
- .NET SDK 8.0.8
- Visual Studio or Visual Studio Code
- Git

## Getting Started

### 1. Clone the Repository
```bash
git clone https://github.com/FakhriAzraShafara/CRUDTechTestDotNetAPI.git
cd CRUDTechTestDotNetAPI
```

### 2. Database Configuration
1. Rename `appsettings-example.json` to `appsettings.json`
2. Update connection string with your database details:
```json
"ConnectionStrings": {
    "DefaultConnection": "server=your_url_database;port=your_port_database;user=your_username_database;password=your_password_database;database=your_database_name"
}
```

### 3. Restore Dependencies
```bash
dotnet restore
```

### 4. Build the Project
```bash
dotnet build
```

### 5. Run the Application
```bash
dotnet run
```
