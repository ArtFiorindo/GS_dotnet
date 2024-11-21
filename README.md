# **SuffraDev**

## 📋 **Descrição**
O **SuffraDev** é um sistema desenvolvido com **ASP.NET Core MVC** para gerenciar e monitorar medições de consumo de energia em diferentes torres. O sistema inclui funcionalidades de CRUD (Create, Read, Update, Delete) e uma visualização de estatísticas com gráficos e cards dinâmicos.

---

**Link GitHub**: [https://github.com/ArtFiorindo/GS_dotnet/tree/main](https://github.com/ArtFiorindo/GS_dotnet/tree/main)

## Equipe

> **Artur Lopes Fiorindo** » 53481  
> 
> **Eduardo Felipe Nunes Função** » 553362  
> 
> **Jhoe Kochi Hashimoto** » 553831  
> 

---

## 🚀 **Funcionalidades**
- **CRUD Completo**:
  - Criar, listar, editar, excluir e visualizar detalhes de medições.
- **Estatísticas Dinâmicas**:
  - Visualize o consumo por torre com gráficos interativos e cards.
  - Percentuais calculados automaticamente com base no consumo total.
- **UI Responsiva**:
  - Interface moderna, com tema escuro e design responsivo.

---

## 🛠️ **Tecnologias Utilizadas**
- **Linguagem**: C#
- **Framework**: ASP.NET Core MVC
- **Banco de Dados**: Oracle (via Entity Framework Core)
- **Frontend**:
  - HTML5, CSS3, Bootstrap
  - Gráficos interativos com **Chart.js**
  - SVG Dinâmicos para exibição de porcentagens nos cards
- **Outras Dependências**:
  - **Entity Framework Core**
  - **Oracle.EntityFrameworkCore**

---

## 🏗️ **Estrutura do Projeto**
A estrutura principal do projeto é a seguinte:

```
MeasurementApp/
├── Controllers/
│   ├── HomeController.cs
│   ├── MeasurementController.cs
├── Models/
│   ├── Measurement.cs
│   ├── ErrorViewModel.cs
├── Services/
│   ├── MeasurementService.cs
├── Repositories/
│   ├── IRepository.cs
│   ├── Repository.cs
├── Views/
│   ├── Measurement/
│   │   ├── Create.cshtml
│   │   ├── Edit.cshtml
│   │   ├── Delete.cshtml
│   │   ├── Details.cshtml
│   │   ├── List.cshtml
│   │   ├── TowerStats.cshtml
│   ├── Shared/
│   │   ├── _Layout.cshtml
├── wwwroot/
│   ├── css/
│   ├── js/
│   ├── lib/
├── Program.cs
├── appsettings.json
```

---

## 🖥️ **Como Rodar o Projeto**

### Pré-requisitos:
- **.NET SDK** 6.0 ou superior
- Banco de Dados **Oracle** configurado
- Ferramentas como **Visual Studio** ou **VS Code** (opcional)

### Passo a Passo:
1. **Clone o repositório**:
   ```bash
   git clone https://github.com/seu-usuario/MeasurementApp.git
   cd MeasurementApp
   ```

2. **Configure a conexão com o banco de dados**:
   - No arquivo `appsettings.json`, ajuste a string de conexão:
     ```json
     "ConnectionStrings": {
       "OracleDbConnection": "DATA SOURCE=<SEU_ORACLE_HOST>;USER ID=<SEU_USER>;PASSWORD=<SUA_SENHA>"
     }
     ```

3. **Restaure as dependências**:
   ```bash
   dotnet restore
   ```

4. **Aplique as migrações no banco de dados**:
   ```bash
   dotnet ef database update
   ```

5. **Inicie o servidor**:
   ```bash
   dotnet run
   ```

6. **Acesse a aplicação**:
   - Abra o navegador e acesse: `http://localhost:5184`

---

## 📄 **Rotas Principais**
- **Home**: `http://localhost:5184`
- **Listar Medições**: `http://localhost:5184/Measurement/List`
- **Criar Medição**: `http://localhost:5184/Measurement/Create`
- **Editar Medição**: `http://localhost:5184/Measurement/Edit/{id}`
- **Excluir Medição**: `http://localhost:5184/Measurement/Delete/{id}`
- **Visualizar Detalhes**: `http://localhost:5184/Measurement/Details/{id}`
- **Estatísticas**: `http://localhost:5184/Measurement/TowerStats`

