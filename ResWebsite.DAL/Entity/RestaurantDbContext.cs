namespace ResWebsite.DAL.Entity
{
    using System;
    using System.Data.Entity;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Linq;

    public partial class RestaurantDbContext : DbContext
    {
        public RestaurantDbContext()
            : base("name=RestaurantDbContext")
        {
        }

        public virtual DbSet<Account_Log> Account_Log { get; set; }
        public virtual DbSet<Business> Businesses { get; set; }
        public virtual DbSet<Customer> Customers { get; set; }
        public virtual DbSet<Employee> Employees { get; set; }
        public virtual DbSet<Employee_Activity_Log> Employee_Activity_Log { get; set; }
        public virtual DbSet<ExportImport> ExportImports { get; set; }
        public virtual DbSet<ExportImportDetail> ExportImportDetails { get; set; }
        public virtual DbSet<ExportImportType> ExportImportTypes { get; set; }
        public virtual DbSet<GrantPermission> GrantPermissions { get; set; }
        public virtual DbSet<GrantShift> GrantShifts { get; set; }
        public virtual DbSet<Item> Items { get; set; }
        public virtual DbSet<MealDrink> MealDrinks { get; set; }
        public virtual DbSet<MealDrinkType> MealDrinkTypes { get; set; }
        public virtual DbSet<Menu> Menus { get; set; }
        public virtual DbSet<OrderMealDrinkDetail> OrderMealDrinkDetails { get; set; }
        public virtual DbSet<Order> Orders { get; set; }
        public virtual DbSet<OrderServiceDetail> OrderServiceDetails { get; set; }
        public virtual DbSet<Permission> Permissions { get; set; }
        public virtual DbSet<Place> Places { get; set; }
        public virtual DbSet<PlaceType> PlaceTypes { get; set; }
        public virtual DbSet<ReservationBill> ReservationBills { get; set; }
        public virtual DbSet<ReservationContract> ReservationContracts { get; set; }
        public virtual DbSet<ReservationMealDrinkDetail> ReservationMealDrinkDetails { get; set; }
        public virtual DbSet<ReservationServiceDetail> ReservationServiceDetails { get; set; }
        public virtual DbSet<Salary> Salaries { get; set; }
        public virtual DbSet<SaleContract> SaleContracts { get; set; }
        public virtual DbSet<SaleContractDetail> SaleContractDetails { get; set; }
        public virtual DbSet<Service> Services { get; set; }
        public virtual DbSet<ServiceType> ServiceTypes { get; set; }
        public virtual DbSet<Shift> Shifts { get; set; }
        public virtual DbSet<Supplier> Suppliers { get; set; }
        public virtual DbSet<SupplierType> SupplierTypes { get; set; }
        public virtual DbSet<TimeKeeping> TimeKeepings { get; set; }
        public virtual DbSet<Unit> Units { get; set; }
        public virtual DbSet<WarehouseType> WarehouseTypes { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Account_Log>()
                .Property(e => e.IpAddress)
                .IsUnicode(false);

            modelBuilder.Entity<Business>()
                .Property(e => e.BusinessId)
                .IsUnicode(false);

            modelBuilder.Entity<Business>()
                .HasMany(e => e.Permissions)
                .WithRequired(e => e.Business)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Customer>()
                .Property(e => e.Phone)
                .IsUnicode(false);

            modelBuilder.Entity<Customer>()
                .Property(e => e.Email)
                .IsUnicode(false);

            modelBuilder.Entity<Customer>()
                .HasMany(e => e.ReservationContracts)
                .WithRequired(e => e.Customer)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Employee>()
                .Property(e => e.Phone)
                .IsUnicode(false);

            modelBuilder.Entity<Employee>()
                .Property(e => e.Picture)
                .IsUnicode(false);

            modelBuilder.Entity<Employee>()
                .Property(e => e.Username)
                .IsUnicode(false);

            modelBuilder.Entity<Employee>()
                .Property(e => e.Password)
                .IsUnicode(false);

            modelBuilder.Entity<Employee>()
                .Property(e => e.Email)
                .IsUnicode(false);

            modelBuilder.Entity<Employee>()
                .HasMany(e => e.Account_Log)
                .WithRequired(e => e.Employee)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Employee>()
                .HasMany(e => e.Employee_Activity_Log)
                .WithRequired(e => e.Employee)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Employee>()
                .HasMany(e => e.ExportImports)
                .WithRequired(e => e.Employee)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Employee>()
                .HasMany(e => e.Orders)
                .WithRequired(e => e.Employee)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Employee>()
                .HasMany(e => e.GrantPermissions)
                .WithRequired(e => e.Employee)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Employee>()
                .HasMany(e => e.GrantShifts)
                .WithRequired(e => e.Employee)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Employee>()
                .HasMany(e => e.Salaries)
                .WithRequired(e => e.Employee)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Employee>()
                .HasMany(e => e.TimeKeepings)
                .WithRequired(e => e.Employee)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Employee_Activity_Log>()
                .Property(e => e.IpAddress)
                .IsUnicode(false);

            modelBuilder.Entity<ExportImport>()
                .HasMany(e => e.ExportImportDetails)
                .WithRequired(e => e.ExportImport)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<ExportImportType>()
                .HasMany(e => e.ExportImports)
                .WithRequired(e => e.ExportImportType)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Item>()
                .Property(e => e.Price)
                .HasPrecision(19, 4);

            modelBuilder.Entity<Item>()
                .HasMany(e => e.ExportImportDetails)
                .WithRequired(e => e.Item)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Item>()
                .HasMany(e => e.SaleContractDetails)
                .WithRequired(e => e.Item)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<MealDrink>()
                .Property(e => e.MealDrinkId)
                .IsUnicode(false);

            modelBuilder.Entity<MealDrink>()
                .Property(e => e.Price)
                .HasPrecision(19, 4);

            modelBuilder.Entity<MealDrink>()
                .Property(e => e.Picture)
                .IsUnicode(false);

            modelBuilder.Entity<MealDrink>()
                .HasMany(e => e.OrderMealDrinkDetails)
                .WithRequired(e => e.MealDrink)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<MealDrink>()
                .HasMany(e => e.ReservationMealDrinkDetails)
                .WithRequired(e => e.MealDrink)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Menu>()
                .HasMany(e => e.MealDrinks)
                .WithRequired(e => e.Menu)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<OrderMealDrinkDetail>()
                .Property(e => e.MealDrinkId)
                .IsUnicode(false);

            modelBuilder.Entity<OrderMealDrinkDetail>()
                .Property(e => e.Price)
                .HasPrecision(19, 4);

            modelBuilder.Entity<Order>()
                .Property(e => e.Total)
                .HasPrecision(19, 4);

            modelBuilder.Entity<Order>()
                .HasMany(e => e.OrderMealDrinkDetails)
                .WithRequired(e => e.Order)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Order>()
                .HasMany(e => e.OrderServiceDetails)
                .WithRequired(e => e.Order)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<OrderServiceDetail>()
                .Property(e => e.ServiceId)
                .IsUnicode(false);

            modelBuilder.Entity<OrderServiceDetail>()
                .Property(e => e.Price)
                .HasPrecision(19, 4);

            modelBuilder.Entity<Permission>()
                .Property(e => e.BusinessId)
                .IsUnicode(false);

            modelBuilder.Entity<Permission>()
                .HasMany(e => e.GrantPermissions)
                .WithRequired(e => e.Permission)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Place>()
                .Property(e => e.Picture)
                .IsUnicode(false);

            modelBuilder.Entity<Place>()
                .Property(e => e.Price)
                .HasPrecision(19, 4);

            modelBuilder.Entity<Place>()
                .HasMany(e => e.Orders)
                .WithRequired(e => e.Place)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Place>()
                .HasMany(e => e.ReservationContracts)
                .WithRequired(e => e.Place)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<PlaceType>()
                .HasMany(e => e.Places)
                .WithRequired(e => e.PlaceType)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<ReservationBill>()
                .Property(e => e.PrePay)
                .HasPrecision(19, 4);

            modelBuilder.Entity<ReservationBill>()
                .Property(e => e.TotalPay)
                .HasPrecision(19, 4);

            modelBuilder.Entity<ReservationContract>()
                .HasMany(e => e.ReservationBills)
                .WithRequired(e => e.ReservationContract)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<ReservationContract>()
                .HasMany(e => e.ReservationMealDrinkDetails)
                .WithRequired(e => e.ReservationContract)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<ReservationContract>()
                .HasMany(e => e.ReservationServiceDetails)
                .WithRequired(e => e.ReservationContract)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<ReservationMealDrinkDetail>()
                .Property(e => e.MealDrinkId)
                .IsUnicode(false);

            modelBuilder.Entity<ReservationMealDrinkDetail>()
                .Property(e => e.Price)
                .HasPrecision(19, 4);

            modelBuilder.Entity<ReservationServiceDetail>()
                .Property(e => e.ServiceId)
                .IsUnicode(false);

            modelBuilder.Entity<ReservationServiceDetail>()
                .Property(e => e.Price)
                .HasPrecision(19, 4);

            modelBuilder.Entity<Salary>()
                .Property(e => e.BasicSalary)
                .HasPrecision(19, 4);

            modelBuilder.Entity<Salary>()
                .Property(e => e.Bonus)
                .HasPrecision(19, 4);

            modelBuilder.Entity<Salary>()
                .Property(e => e.Subsidy)
                .HasPrecision(19, 4);

            modelBuilder.Entity<SaleContract>()
                .HasMany(e => e.SaleContractDetails)
                .WithRequired(e => e.SaleContract)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<SaleContractDetail>()
                .Property(e => e.Total)
                .HasPrecision(19, 4);

            modelBuilder.Entity<Service>()
                .Property(e => e.ServiceId)
                .IsUnicode(false);

            modelBuilder.Entity<Service>()
                .Property(e => e.Price)
                .HasPrecision(19, 4);

            modelBuilder.Entity<Service>()
                .HasMany(e => e.OrderServiceDetails)
                .WithRequired(e => e.Service)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Service>()
                .HasMany(e => e.ReservationServiceDetails)
                .WithRequired(e => e.Service)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<ServiceType>()
                .HasMany(e => e.Services)
                .WithRequired(e => e.ServiceType)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Shift>()
                .HasMany(e => e.GrantShifts)
                .WithRequired(e => e.Shift)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Shift>()
                .HasMany(e => e.TimeKeepings)
                .WithRequired(e => e.Shift)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Supplier>()
                .Property(e => e.Phone)
                .IsUnicode(false);

            modelBuilder.Entity<Supplier>()
                .Property(e => e.Email)
                .IsUnicode(false);

            modelBuilder.Entity<Supplier>()
                .HasMany(e => e.SaleContracts)
                .WithRequired(e => e.Supplier)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<SupplierType>()
                .HasMany(e => e.Suppliers)
                .WithRequired(e => e.SupplierType)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<WarehouseType>()
                .HasMany(e => e.Items)
                .WithRequired(e => e.WarehouseType)
                .WillCascadeOnDelete(false);
        }
    }
}
