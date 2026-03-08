
![Banner](https://capsule-render.vercel.app/api?type=waving&color=gradient&customColorList=6,11,20&height=200&section=header&text=ASP.NET%20Core%20CQRS%20EShop&fontSize=40&fontColor=fff&animation=fadeIn)
# 🛒 ASP-EShop-CQRS-MediatR

![.NET](https://img.shields.io/badge/.NET-8.0-purple?style=flat-square&logo=dotnet)
![MediatR](https://img.shields.io/badge/MediatR-14.0-blue?style=flat-square)
![CQRS](https://img.shields.io/badge/Pattern-CQRS-cyan?style=flat-square)
![License](https://img.shields.io/badge/License-MIT-yellow?style=flat-square)

ASP.NET Core 8 + CQRS + MediatR ilə qurulmuş E-Ticarət API-si.

---

## 🏗️ Struktur
```
Core/
├── EShop.Application   # Commands, Queries, Handlers
└── EShop.Domain        # Entities

Infrastructure/
├── EShop.Persistence   # EF Core, Repositories
└── EShop.Infrastructure

Presentation/
└── EShop.WebAPI        # Controllers
```

## 🛠️ Texnologiyalar
| | |
|---|---|
| ASP.NET Core 8 | Web API |
| MediatR 14 | CQRS |
| EF Core 8 | ORM |
| FluentValidation | Validation |
| SQL Server | Database |

## 🚀 Qurulum
```bash
git clone https://github.com/Ruaaln/ASP-EShop-CQRS-MediatR.git
# appsettings.json-da connection string-i dəyişin
Update-Database
dotnet run
```

## 👤 [@Ruaaln](https://github.com/Ruaaln) • 📄 MIT License
