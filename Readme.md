# webapiAI

**Web API to consume IA resources through API for free using Grok and Cerebras.**:contentReference[oaicite:1]{index=1}

[![License: Apache-2.0](https://img.shields.io/badge/License-Apache%202.0-blue.svg)](LICENSE)

A lightweight **ASP.NET Core Web API** project that enables you to interact with AI endpoints (such as Grok and Cerebras models) via simple HTTP calls. Ideal for building AI-powered tooling, experimentation, or backend integrations that require access to free/experimental AI resources.

---

## 🧱 Project Overview

The repo provides a modular API structure using:

- **Common** — Shared helpers, utilities, and configuration logic.
- **Dtos** — Request/response models for API payloads.
- **Endpoints** — API endpoints organized by feature or model.
- **Program.cs** — Entry point and service registration.
- **Properties** — Application properties and launch settings.
- **Configuration Files**
  - `appsettings.json`
  - `appsettings.Development.json`

---

## 🚀 Features

✔ Simple RESTful endpoints for AI model integration  
✔ Structured request/response models (DTOs)  
✔ Pluggable architecture — easy to extend with additional models  
✔ Uses .NET Core web API best practices  
✔ Apache-2.0 licensed for reuse and modification

---

## 📦 Prerequisites

Before you begin, make sure you have installed:

- [.NET 7+ or .NET 8+ SDK](https://dotnet.microsoft.com/download)  
- A code editor like **Visual Studio**, **VS Code**, or **JetBrains Rider**

---

## 🛠 Installation & Setup

1. **Clone the repository**

   ```bash
   git clone https://github.com/osvafernandez/webapiAI.git
   cd webapiAI
