
# Fintcs - Finance Management System

A comprehensive finance management system supporting multiple roles, advanced data handling, dynamic forms, and robust reporting.

## Tech Stack

- **Frontend**: Angular v18 (Standalone APIs, Routing, HTTP Interceptor) + Tailwind CSS
- **Backend**: ASP.NET Core Web API (C#)
- **Database**: SQL Server (Database Name: Fintcs)

## Features

### User Roles
- **Super Admin**: Complete system access, manage societies and users globally
- **Society Admin**: Manage own society, users, and members
- **User**: Read-only access to society details and reports
- **Member**: Profile management, loan history, savings summary

### Core Functionality
- JWT-based authentication with role-based authorization
- Society Management with approval workflows
- User and Member Management with auto-generated IDs
- Loan Processing with validation and calculations
- Monthly Demand Processing with Excel export
- Voucher Creation with balance validation
- Comprehensive Reporting with filtering and export

## Project Structure

```
Fintcs/
├── Backend/
│   └── Fintcs.API/
│       ├── Controllers/
│       ├── Services/
│       ├── Repositories/
│       ├── Models/
│       ├── DTOs/
│       ├── Data/
│       └── Program.cs
└── Frontend/
    └── src/
        └── app/
            ├── core/
            │   ├── services/
            │   ├── guards/
            │   └── interceptors/
            ├── shared/
            │   ├── models/
            │   ├── components/
            │   └── utils/
            └── features/
                ├── auth/
                ├── dashboard/
                ├── societies/
                ├── users/
                ├── members/
                ├── loans/
                ├── demand/
                └── vouchers/
```

## Setup Instructions

### Prerequisites
- .NET 8.0 SDK
- Node.js (v18 or later)
- SQL Server (LocalDB or full instance)
- Angular CLI (`npm install -g @angular/cli`)

### Backend Setup

1. **Navigate to Backend directory**
   ```bash
   cd Backend/Fintcs.API
   ```

2. **Restore packages**
   ```bash
   dotnet restore
   ```

3. **Update database connection string** (if needed)
   - Edit `appsettings.json`
   - Modify the `DefaultConnection` string for your SQL Server instance

4. **Create and seed database**
   ```bash
   dotnet ef database update
   ```

5. **Run the API**
   ```bash
   dotnet run
   ```
   
   The API will be available at: `http://localhost:5000`

### Frontend Setup

1. **Navigate to Frontend directory**
   ```bash
   cd Frontend
   ```

2. **Install dependencies**
   ```bash
   npm install
   ```

3. **Install Tailwind CSS**
   ```bash
   npm install -D tailwindcss postcss autoprefixer @tailwindcss/forms
   ```

4. **Start the development server**
   ```bash
   npm start
   ```
   
   The application will be available at: `http://localhost:4200`

## Default Login Credentials

### Super Admin
- **Username**: `admin`
- **Password**: `admin`

### Sample Society Admin
- **Username**: `societyadmin`
- **Password**: `admin123`

## Database Schema

### Core Tables
- **SuperAdmins**: System administrators
- **Societies**: Cooperative societies with financial settings
- **AppUsers**: Application users with role-based access
- **Members**: Society members with detailed information
- **Loans**: Loan records with calculations and validations
- **Vouchers**: Financial vouchers with line items
- **MonthlyDemandHeader/Row**: Monthly demand processing
- **PendingEdits**: Approval workflow for changes

### Lookup Tables
- **LoanTypes**: General Loan, Emergency Loan, House Loan
- **Banks**: HDFC Bank, SBI, ICICI Bank
- **VoucherTypes**: Payment, Receipt, Journal, Contra, Adjustment, Others

## API Endpoints

### Authentication
- `POST /api/auth/login` - User login
- `POST /api/auth/refresh` - Refresh token

### Societies
- `GET /api/societies` - Get all societies
- `POST /api/societies` - Create society
- `PUT /api/societies/{id}` - Update society
- `DELETE /api/societies/{id}` - Delete society

### Users
- `GET /api/users` - Get users
- `POST /api/users` - Create user
- `PUT /api/users/{id}` - Update user
- `DELETE /api/users/{id}` - Delete user

### Members
- `GET /api/members` - Get members
- `POST /api/members` - Create member (auto-generates Member No)
- `PUT /api/members/{id}` - Update member
- `DELETE /api/members/{id}` - Delete member

### Loans
- `GET /api/loans` - Get loans
- `POST /api/loans` - Create loan (auto-generates Loan No)
- `PUT /api/loans/{id}` - Update loan
- `DELETE /api/loans/{id}` - Delete loan
- `POST /api/loans/{id}/validate` - Validate loan

### Vouchers
- `GET /api/vouchers` - Get vouchers
- `POST /api/vouchers` - Create voucher
- `PUT /api/vouchers/{id}` - Update voucher
- `DELETE /api/vouchers/{id}` - Delete voucher
- `POST /api/vouchers/{id}/reverse` - Reverse voucher

## Key Features Implementation

### Role-Based Access Control
- JWT tokens contain role claims
- Angular guards protect routes based on roles
- API controllers use `[Authorize(Roles="...")]` attributes

### Auto-Generated Numbers
- Member Numbers: MEM_001, MEM_002, etc.
- Loan Numbers: Configurable format with auto-increment
- Voucher Numbers: Type-based auto-generation

### Validation & Business Rules
- Password complexity requirements
- Unique username validation
- Loan amount vs. limits validation
- Voucher debit/credit balance validation

### File Uploads
- Member photos and signatures
- Secure file storage with path tracking
- Image format validation

### Export Functionality
- Excel export for monthly demand
- PDF export for reports
- Print-friendly voucher formats

## Development Notes

### Angular Features Used
- Standalone components (Angular 18)
- Reactive forms with validation
- HTTP interceptors for authentication
- Route guards for authorization
- Tailwind CSS for styling

### Backend Architecture
- Clean architecture with separation of concerns
- Repository pattern for data access
- Service layer for business logic
- AutoMapper for DTO mapping
- Entity Framework Core for ORM

### Security Implementation
- Password hashing with BCrypt
- JWT token authentication
- Role-based authorization
- CORS configuration for Angular app

## Deployment

### Production Deployment
1. Build Angular application: `ng build --prod`
2. Configure IIS or similar web server for Angular files
3. Deploy ASP.NET Core API to server
4. Update connection strings for production database
5. Configure HTTPS and security headers

### Environment Configuration
- Update `environment.prod.ts` with production API URL
- Configure production database connection string
- Set up proper CORS policies for production domains

## Contributing

1. Fork the repository
2. Create a feature branch
3. Commit your changes
4. Push to the branch
5. Create a Pull Request

## License

This project is licensed under the MIT License.

## Support

For support and questions, please contact the development team or create an issue in the repository.
