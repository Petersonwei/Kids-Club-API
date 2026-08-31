# Clean Architecture Template (.NET Aspire)

A pragmatic Clean Architecture starter wired up with **.NET Aspire 13.4** on **.NET 10**.
This is the Aspire flavor of the template — the AppHost orchestrates PostgreSQL and the API,
and the Aspire dashboard gives you logs, traces, and metrics out of the box.

## What's included in the template?

- **Aspire AppHost** orchestrating the API and a PostgreSQL container.
- **Aspire ServiceDefaults** with OpenTelemetry (logs, traces, metrics), health checks,
  service discovery, and HTTP resilience.
- **SharedKernel** project with common Domain-Driven Design abstractions.
- **Domain** layer with sample entities and domain events.
- **Application** layer with abstractions for:
  - CQRS (lightweight, MediatR-free command/query handlers)
  - Example use cases (Todos and Users)
  - Cross-cutting concerns (logging, validation) implemented as decorators
- **Infrastructure** layer with:
  - JWT authentication with **refresh tokens** (with token rotation)
  - Permission-based authorization
  - EF Core + PostgreSQL (snake_case naming, migrations)
  - **HybridCache** for fast, unified caching with cache invalidation
- **Web.Api** layer with:
  - Minimal API endpoints
  - **Rate limiting** (configurable global + authentication policies)
  - Global exception handling and `ProblemDetails`
  - Swagger / OpenAPI with JWT support
- **Testing** projects
  - Architecture testing (`ArchitectureTests`)
  - Unit testing (`Application.UnitTests`)
  - Integration testing with **Testcontainers** (`IntegrationTests`)

## Getting started

```bash
dotnet run --project src/Aspire.AppHost
```

This launches the Aspire dashboard, the PostgreSQL container, and the API. Telemetry
(logs/traces/metrics) flows into the dashboard automatically.

Run the full test suite (the integration tests spin up a throwaway PostgreSQL container,
so Docker must be running):

```bash
dotnet test CleanArchitecture.sln
```

If you're ready to learn more, check out [**Pragmatic Clean Architecture**](https://www.milanjovanovic.tech/pragmatic-clean-architecture?utm_source=ca-template):

- Domain-Driven Design
- Role-based authorization
- Permission-based authorization
- Distributed caching with Redis
- OpenTelemetry
- Outbox pattern
- API Versioning
- Unit testing
- Functional testing
- Integration testing

Stay awesome!
