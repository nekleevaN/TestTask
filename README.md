## ✨ **Project Overview**

Welcome to the ** Bulletin Board** system! This project demonstrates a full-stack web application with the following technology stack and features:

- **Backend**: ASP.NET Core RESTful API with MS SQL stored procedures for CRUD operations.
- **Frontend**: ASP.NET MVC or Razor Pages for an interactive user interface.
- **Database**: MS SQL for robust data management.
- **Deployment**: Hosted on Azure App Services, accessible via public URLs.

---

## 🌐 **Live Links**

| Service            | URL                                                                                 |
|--------------------|-------------------------------------------------------------------------------------|
| **API Endpoint**   | [Board API](https://boardapi-a4andzb4frdzf3gq.polandcentral-01.azurewebsites.net/) |
| **Blazor App**     | [Bulletin Board App](https://ndmytryshynblazor-ecd3fjchf5f7egas.polandcentral-01.azurewebsites.net/) |

---

## 🛠️ **Tech Stack**

### **Backend**
- **ASP.NET Core**: RESTful API design.
- **CRUD Operations**
- **Database**: MS SQL for data storage and manipulation.

### **Frontend**
- **ASP.NET MVC** or **Razor Pages**: Designed to interact with the backend API.
- **Dynamic Components**: Built to provide a user-friendly interface.

### **Deployment**
- **Azure App Service**: API and frontend applications deployed separately for scalability.
- **Public Accessibility**: Accessible via public URLs for demonstration purposes.

---

## 🚀 **Features**

### **Backend**
- Fully functional RESTful API for managing bulletin board posts.
- Endpoints for:
  - Creating new announcements.
  - Reading announcements.
  - Updating existing announcements.
  - Deleting announcements.

### **Frontend**
- Dynamic interface for interacting with the bulletin board.
- Simplified navigation for CRUD operations.
- Mobile-friendly and responsive design.

### **Database**
- Table for storing announcements with structured schema.
---

## 🛠️ **How to start**

### **Step 1**
- **Open the project**: Open the BoardApp.sln file in Visual Studio.

### **Step 2**
- **Setting up the database**: Open the appsettings.json file in the BoardPLL project and specify the correct SQL Server connection string. For example: 
"ConnectionStrings": { " 
 " "DefaultConnection": "Server=localhost;Database=BoardDb;Trusted_Connection=True;" 
} 

### **Step 3**
- **Apply migrations to the database**: Open the Package Manager Console and run the command:
Update-Database. 

### **Step 4**
- **Launch the project**: Set BoardAppFront and BoardPLL as the starting project. Run the application through Visual Studio (F5 or Ctrl+F5).
