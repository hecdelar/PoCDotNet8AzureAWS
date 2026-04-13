
# PoCDotNet8Azure.AdminRequest

Microservicio desarrollado en **.NET 8** que expone una **Web API** para gestionar solicitudes administrativas (*Admin Requests*), persistiendo información en **Amazon DynamoDB** y publicando eventos en **Amazon SQS FIFO**.

El proyecto está diseñado siguiendo principios de **Clean Architecture**, **Arquitectura Hexagonal** y **CQRS**, priorizando la mantenibilidad, escalabilidad y claridad del código.

---
## 📌 Tecnologías utilizadas

- .NET 8
- ASP.NET Core Web API
- MediatR (CQRS)
- FluentValidation
- Amazon SQS (FIFO)
- Amazon DynamoDB
- Docker & Docker Compose

---


## 🧱 Arquitectura

La solución aplica **Clean Architecture**, separando responsabilidades por capas:

```text
┌───────────────────────────┐
│       WebAPI              │  ← Entrada HTTP / Configuración / DI
├───────────────────────────┤
│       Application         │  ← Commands, Handlers, Validators
├───────────────────────────┤
│       Domain              │  ← Entidades y reglas de negocio
├───────────────────────────┤
│       Infrastructure      │  ← AWS (SQS, DynamoDB)
└───────────────────────────┘
```

---

## 📦 Librerías NuGet utilizadas

```bash

dotnet add package MediatR
dotnet add package FluentValidation
dotnet add package FluentValidation.DependencyInjectionExtensions
dotnet add package AWSSDK.SQS
dotnet add package AWSSDK.DynamoDBv2

```
- **MediatR**  
  Implementación de CQRS  

- **FluentValidation**  
  Validación de Commands  

- **AWSSDK.SQS**  
  Publicación de mensajes  

- **AWSSDK.DynamoDBv2**  
  Persistencia en DynamoDB  

## 🔐Configuración de AWS
El SDK de AWS para .NET utiliza automáticamente las variables de entorno:

```bash
AWS_ACCESS_KEY_ID
AWS_SECRET_ACCESS_KEY
AWS_REGION
```
