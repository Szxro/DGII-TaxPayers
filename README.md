# DGII-TaxPayers

## Terminologia

- **DGII-TaxPayers** = DGII-Contribuyentes
- **RncId** = RncCedula
- **TaxReceipt** = Recibo de Impuestos (Comprobantes Fiscales)
- **Taxpayer** = Contribuyente
- **Status** = Estado

## Api (Backend)

### Arquitectura

Se utilizo la Arquitectura Limpia (Clean Architecture) propuesta por Robert C. Martin mas conocido como Tio Bob (Uncle Bob), ya que esta tiene un enfoque que busca separar las responsabilidades del sistema en capas distintas e independientes.

Se dividio en las siguientes capas:

- **Application** (Aplicacion) : en esta capa es donde se desarrolla la aplicación en su forma tangible, dando vida a la lógica previamente definida en la capa de dominio.

- **Domain** (Dominio) : La capa de dominio se encuentra entre la capa de presentación y la capa de datos (Infrastructure).Esta capa consta de entidades (entities), DTOs (Data Transfer Objects) , contratos (contracts), etc..

- **Infrastructure** (Infraestructura) : Implementa una interfaz desde la capa de dominio y proporciona funcionalidad para acceder a sistemas externos. Incluye repositorios que se comunican con la base de datos, Entity Framework DbContext y archivos de migración necesarios para la comunicación con la base de datos.

- **Presentation** (Api) : Esta capa es responsable de manejar las interacciones del usuario y entregar datos a la interfaz de usuario.

### Patrones de diseño

Esta API consta de código integrado para admitir algunos patrones comunes, como puede ser :
- CQRS (Command Query Responsability Segregation),
- Mediatr (Patron Mediador), Options Pattern
- Functional Result Pattern
- Domain Events (Eventos de dominios)
- Repository Pattern (Patron de repositorio)
- Entre otros...

### Librerias de terceros utilizadas (Nuggets)

- **Mediatr**
- **ADO .NET Entity Framework**
- **Fluent Validation**
- **Microsoft.Extensions.Logging.Abstractions**
- **Microsoft.Extensions.Configuration.Binder**

### Caracteristicas (Features)

- **Query Caching**
- **Request Validation**
- **Request Exception Handling**
- **Request Performance**
- **Global Exception Handling**
- **Events Handlers**
- **Dependency Injection**
- **Error Log**
- **Exception Log**
