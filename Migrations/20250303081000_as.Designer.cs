﻿// <auto-generated />
using System;
using AspnetCoreMvcStarter.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace AspnetCoreMvcStarter.Migrations
{
    [DbContext(typeof(ApplicationDbContext))]
    [Migration("20250303081000_as")]
    partial class @as
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.0")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("AspnetCoreMvcStarter.Models.BorrowedItem", b =>
                {
                    b.Property<int>("BorrowId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("BorrowId"));

                    b.Property<DateTime>("BorrowDate")
                        .HasColumnType("datetime2");

                    b.Property<int?>("FacilityId")
                        .HasColumnType("int");

                    b.Property<int?>("FacilityItemId")
                        .HasColumnType("int");

                    b.Property<int>("QuantityBorrowed")
                        .HasColumnType("int");

                    b.Property<DateTime?>("ReturnDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("Status")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("UserId")
                        .HasColumnType("int");

                    b.HasKey("BorrowId");

                    b.HasIndex("FacilityId");

                    b.HasIndex("FacilityItemId");

                    b.HasIndex("UserId");

                    b.ToTable("BorrowedItems");
                });

            modelBuilder.Entity("AspnetCoreMvcStarter.Models.Comment", b =>
                {
                    b.Property<int>("CommentId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("CommentId"));

                    b.Property<string>("CommentText")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("CreatedAt")
                        .HasColumnType("datetime2");

                    b.Property<int?>("RequestId")
                        .HasColumnType("int");

                    b.Property<int?>("UserId")
                        .HasColumnType("int");

                    b.HasKey("CommentId");

                    b.HasIndex("RequestId")
                        .IsUnique()
                        .HasFilter("[RequestId] IS NOT NULL");

                    b.HasIndex("UserId");

                    b.ToTable("Comments");
                });

            modelBuilder.Entity("AspnetCoreMvcStarter.Models.Facility", b =>
                {
                    b.Property<int>("FacilityId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("FacilityId"));

                    b.Property<DateTime>("CreatedAt")
                        .HasColumnType("datetime2");

                    b.Property<int>("CreatedBy")
                        .HasColumnType("int");

                    b.Property<DateTime?>("DeletedAt")
                        .HasColumnType("datetime2");

                    b.Property<int?>("DeletedBy")
                        .HasColumnType("int");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("FacilityHeadId")
                        .HasColumnType("int");

                    b.Property<string>("FacilityName")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<DateTime?>("UpdatedAt")
                        .HasColumnType("datetime2");

                    b.Property<int?>("UpdatedBy")
                        .HasColumnType("int");

                    b.HasKey("FacilityId");

                    b.HasIndex("FacilityHeadId");

                    b.ToTable("Facilities");

                    b.HasData(
                        new
                        {
                            FacilityId = 1,
                            CreatedAt = new DateTime(2025, 3, 3, 8, 10, 0, 20, DateTimeKind.Utc).AddTicks(9836),
                            CreatedBy = 0,
                            Description = "Provides books and resources for students.",
                            FacilityName = "Library"
                        },
                        new
                        {
                            FacilityId = 2,
                            CreatedAt = new DateTime(2025, 3, 3, 8, 10, 0, 20, DateTimeKind.Utc).AddTicks(9839),
                            CreatedBy = 0,
                            Description = "Equipped for physics and chemistry experiments.",
                            FacilityName = "Science Lab"
                        },
                        new
                        {
                            FacilityId = 3,
                            CreatedAt = new DateTime(2025, 3, 3, 8, 10, 0, 20, DateTimeKind.Utc).AddTicks(9840),
                            CreatedBy = 0,
                            Description = "Contains computers for student use.",
                            FacilityName = "Computer Lab"
                        },
                        new
                        {
                            FacilityId = 4,
                            CreatedAt = new DateTime(2025, 3, 3, 8, 10, 0, 20, DateTimeKind.Utc).AddTicks(9840),
                            CreatedBy = 0,
                            Description = "Indoor sports and fitness activities.",
                            FacilityName = "Gymnasium"
                        },
                        new
                        {
                            FacilityId = 5,
                            CreatedAt = new DateTime(2025, 3, 3, 8, 10, 0, 20, DateTimeKind.Utc).AddTicks(9842),
                            CreatedBy = 0,
                            Description = "Used for school events and presentations.",
                            FacilityName = "Auditorium"
                        },
                        new
                        {
                            FacilityId = 6,
                            CreatedAt = new DateTime(2025, 3, 3, 8, 10, 0, 20, DateTimeKind.Utc).AddTicks(9844),
                            CreatedBy = 0,
                            Description = "Outdoor sports facility for football training.",
                            FacilityName = "Football Field"
                        },
                        new
                        {
                            FacilityId = 7,
                            CreatedAt = new DateTime(2025, 3, 3, 8, 10, 0, 20, DateTimeKind.Utc).AddTicks(9845),
                            CreatedBy = 0,
                            Description = "Used for basketball games and training.",
                            FacilityName = "Basketball Court"
                        },
                        new
                        {
                            FacilityId = 8,
                            CreatedAt = new DateTime(2025, 3, 3, 8, 10, 0, 20, DateTimeKind.Utc).AddTicks(9846),
                            CreatedBy = 0,
                            Description = "Food and beverages for students and staff.",
                            FacilityName = "Cafeteria"
                        },
                        new
                        {
                            FacilityId = 9,
                            CreatedAt = new DateTime(2025, 3, 3, 8, 10, 0, 20, DateTimeKind.Utc).AddTicks(9847),
                            CreatedBy = 0,
                            Description = "Parking space for staff and students.",
                            FacilityName = "Parking Lot"
                        },
                        new
                        {
                            FacilityId = 10,
                            CreatedAt = new DateTime(2025, 3, 3, 8, 10, 0, 20, DateTimeKind.Utc).AddTicks(9847),
                            CreatedBy = 0,
                            Description = "Monitors campus security operations.",
                            FacilityName = "Security Room"
                        });
                });

            modelBuilder.Entity("AspnetCoreMvcStarter.Models.FacilityItem", b =>
                {
                    b.Property<int>("FacilityItemId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("FacilityItemId"));

                    b.Property<DateTime>("CreatedAt")
                        .HasColumnType("datetime2");

                    b.Property<int>("CreatedBy")
                        .HasColumnType("int");

                    b.Property<DateTime?>("DeletedAt")
                        .HasColumnType("datetime2");

                    b.Property<int?>("DeletedBy")
                        .HasColumnType("int");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("FacilityId")
                        .HasColumnType("int");

                    b.Property<string>("ItemImage")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ItemName")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<int>("Quantity")
                        .HasColumnType("int");

                    b.Property<DateTime?>("UpdatedAt")
                        .HasColumnType("datetime2");

                    b.Property<int?>("UpdatedBy")
                        .HasColumnType("int");

                    b.HasKey("FacilityItemId");

                    b.ToTable("FacilityItems");

                    b.HasData(
                        new
                        {
                            FacilityItemId = 1,
                            CreatedAt = new DateTime(2025, 3, 3, 8, 10, 0, 20, DateTimeKind.Utc).AddTicks(9864),
                            CreatedBy = 0,
                            Description = "Kit for physics experiments.",
                            FacilityId = 2,
                            ItemImage = "physics_kit.png",
                            ItemName = "Physics Kit",
                            Quantity = 5
                        },
                        new
                        {
                            FacilityItemId = 2,
                            CreatedAt = new DateTime(2025, 3, 3, 8, 10, 0, 20, DateTimeKind.Utc).AddTicks(9867),
                            CreatedBy = 0,
                            Description = "Includes beakers and test tubes.",
                            FacilityId = 2,
                            ItemImage = "chemistry_set.png",
                            ItemName = "Chemistry Set",
                            Quantity = 10
                        },
                        new
                        {
                            FacilityItemId = 3,
                            CreatedAt = new DateTime(2025, 3, 3, 8, 10, 0, 20, DateTimeKind.Utc).AddTicks(9869),
                            CreatedBy = 0,
                            Description = "Computers for student use.",
                            FacilityId = 3,
                            ItemImage = "computer.png",
                            ItemName = "Computer",
                            Quantity = 15
                        },
                        new
                        {
                            FacilityItemId = 4,
                            CreatedAt = new DateTime(2025, 3, 3, 8, 10, 0, 20, DateTimeKind.Utc).AddTicks(9870),
                            CreatedBy = 0,
                            Description = "Official size basketballs.",
                            FacilityId = 7,
                            ItemImage = "basketball.png",
                            ItemName = "Basketball",
                            Quantity = 10
                        },
                        new
                        {
                            FacilityItemId = 5,
                            CreatedAt = new DateTime(2025, 3, 3, 8, 10, 0, 20, DateTimeKind.Utc).AddTicks(9892),
                            CreatedBy = 0,
                            Description = "For presentations and seminars.",
                            FacilityId = 5,
                            ItemImage = "projector.png",
                            ItemName = "Projector",
                            Quantity = 3
                        },
                        new
                        {
                            FacilityItemId = 6,
                            CreatedAt = new DateTime(2025, 3, 3, 8, 10, 0, 20, DateTimeKind.Utc).AddTicks(9894),
                            CreatedBy = 0,
                            Description = "For gym workouts.",
                            FacilityId = 4,
                            ItemImage = "treadmill.png",
                            ItemName = "Treadmill",
                            Quantity = 2
                        },
                        new
                        {
                            FacilityItemId = 7,
                            CreatedAt = new DateTime(2025, 3, 3, 8, 10, 0, 20, DateTimeKind.Utc).AddTicks(9895),
                            CreatedBy = 0,
                            Description = "Academic and reference books.",
                            FacilityId = 1,
                            ItemImage = "books.png",
                            ItemName = "Library Books",
                            Quantity = 500
                        },
                        new
                        {
                            FacilityItemId = 8,
                            CreatedAt = new DateTime(2025, 3, 3, 8, 10, 0, 20, DateTimeKind.Utc).AddTicks(9896),
                            CreatedBy = 0,
                            Description = "Monitors school security.",
                            FacilityId = 10,
                            ItemImage = "security_camera.png",
                            ItemName = "Security Camera",
                            Quantity = 8
                        },
                        new
                        {
                            FacilityItemId = 9,
                            CreatedAt = new DateTime(2025, 3, 3, 8, 10, 0, 20, DateTimeKind.Utc).AddTicks(9897),
                            CreatedBy = 0,
                            Description = "Used in science experiments.",
                            FacilityId = 2,
                            ItemImage = "microscope.png",
                            ItemName = "Microscope",
                            Quantity = 6
                        },
                        new
                        {
                            FacilityItemId = 10,
                            CreatedAt = new DateTime(2025, 3, 3, 8, 10, 0, 20, DateTimeKind.Utc).AddTicks(9898),
                            CreatedBy = 0,
                            Description = "Used for training and matches.",
                            FacilityId = 6,
                            ItemImage = "football.png",
                            ItemName = "Football",
                            Quantity = 12
                        });
                });

            modelBuilder.Entity("AspnetCoreMvcStarter.Models.Notification", b =>
                {
                    b.Property<int>("NotificationId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("NotificationId"));

                    b.Property<DateTime>("CreatedAt")
                        .HasColumnType("datetime2");

                    b.Property<string>("Message")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("UserId")
                        .HasColumnType("int");

                    b.HasKey("NotificationId");

                    b.HasIndex("UserId");

                    b.ToTable("Notifications");
                });

            modelBuilder.Entity("AspnetCoreMvcStarter.Models.Request", b =>
                {
                    b.Property<int>("RequestId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("RequestId"));

                    b.Property<DateTime?>("ClosedDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("ClosureReason")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Description")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("FacilityId")
                        .HasColumnType("int");

                    b.Property<int?>("FacilityItemId")
                        .HasColumnType("int");

                    b.Property<int>("QuantityRequested")
                        .HasColumnType("int");

                    b.Property<string>("Remarks")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("RequestDate")
                        .HasColumnType("datetime2");

                    b.Property<int?>("RequestorId")
                        .HasColumnType("int");

                    b.Property<string>("SeverityLevel")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Status")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("RequestId");

                    b.HasIndex("FacilityId");

                    b.HasIndex("FacilityItemId");

                    b.HasIndex("RequestorId");

                    b.ToTable("Requests");

                    b.HasData(
                        new
                        {
                            RequestId = 1,
                            ClosureReason = "",
                            Description = "Request for library books.",
                            FacilityId = 1,
                            FacilityItemId = 7,
                            QuantityRequested = 2,
                            Remarks = "",
                            RequestDate = new DateTime(2025, 3, 3, 8, 10, 0, 20, DateTimeKind.Utc).AddTicks(9916),
                            RequestorId = 7,
                            SeverityLevel = "Medium",
                            Status = "Approved"
                        },
                        new
                        {
                            RequestId = 2,
                            ClosureReason = "",
                            Description = "Physics experiment kit required.",
                            FacilityId = 2,
                            FacilityItemId = 1,
                            QuantityRequested = 1,
                            Remarks = "",
                            RequestDate = new DateTime(2025, 3, 3, 8, 10, 0, 20, DateTimeKind.Utc).AddTicks(9921),
                            RequestorId = 8,
                            SeverityLevel = "High",
                            Status = "Pending"
                        },
                        new
                        {
                            RequestId = 3,
                            ClosureReason = "",
                            Description = "Chemistry lab items.",
                            FacilityId = 2,
                            FacilityItemId = 2,
                            QuantityRequested = 1,
                            Remarks = "",
                            RequestDate = new DateTime(2025, 3, 3, 8, 10, 0, 20, DateTimeKind.Utc).AddTicks(9923),
                            RequestorId = 8,
                            SeverityLevel = "Medium",
                            Status = "Approved"
                        },
                        new
                        {
                            RequestId = 4,
                            ClosureReason = "",
                            Description = "Need footballs for practice.",
                            FacilityId = 6,
                            FacilityItemId = 10,
                            QuantityRequested = 2,
                            Remarks = "",
                            RequestDate = new DateTime(2025, 3, 3, 8, 10, 0, 20, DateTimeKind.Utc).AddTicks(9926),
                            RequestorId = 10,
                            SeverityLevel = "Low",
                            Status = "Pending"
                        },
                        new
                        {
                            RequestId = 5,
                            ClosureReason = "",
                            Description = "Security cameras required.",
                            FacilityId = 10,
                            FacilityItemId = 8,
                            QuantityRequested = 3,
                            Remarks = "",
                            RequestDate = new DateTime(2025, 3, 3, 8, 10, 0, 20, DateTimeKind.Utc).AddTicks(9929),
                            RequestorId = 9,
                            SeverityLevel = "High",
                            Status = "Rejected"
                        });
                });

            modelBuilder.Entity("AspnetCoreMvcStarter.Models.User", b =>
                {
                    b.Property<int>("UserId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("UserId"));

                    b.Property<DateTime>("CreatedAt")
                        .HasColumnType("datetime2");

                    b.Property<DateTime?>("DeletedAt")
                        .HasColumnType("datetime2");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<string>("FullName")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<bool>("IsActive")
                        .HasColumnType("bit");

                    b.Property<string>("PasswordHash")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Phone")
                        .IsRequired()
                        .HasMaxLength(15)
                        .HasColumnType("nvarchar(15)");

                    b.Property<int>("RoleId")
                        .HasColumnType("int");

                    b.Property<DateTime?>("UpdatedAt")
                        .HasColumnType("datetime2");

                    b.Property<string>("Username")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.HasKey("UserId");

                    b.HasIndex("RoleId");

                    b.ToTable("Users");

                    b.HasData(
                        new
                        {
                            UserId = 1,
                            CreatedAt = new DateTime(2025, 3, 3, 8, 10, 0, 20, DateTimeKind.Utc).AddTicks(9799),
                            Email = "admin@school.com",
                            FullName = "Admin User",
                            IsActive = true,
                            PasswordHash = "hashedpassword",
                            Phone = "555-1001",
                            RoleId = 1,
                            Username = "admin"
                        },
                        new
                        {
                            UserId = 2,
                            CreatedAt = new DateTime(2025, 3, 3, 8, 10, 0, 20, DateTimeKind.Utc).AddTicks(9804),
                            Email = "library@school.com",
                            FullName = "Library Manager",
                            IsActive = true,
                            PasswordHash = "hashedpassword",
                            Phone = "555-1002",
                            RoleId = 2,
                            Username = "library"
                        },
                        new
                        {
                            UserId = 3,
                            CreatedAt = new DateTime(2025, 3, 3, 8, 10, 0, 20, DateTimeKind.Utc).AddTicks(9805),
                            Email = "lab@school.com",
                            FullName = "Lab Manager",
                            IsActive = true,
                            PasswordHash = "hashedpassword",
                            Phone = "555-1003",
                            RoleId = 2,
                            Username = "lab"
                        },
                        new
                        {
                            UserId = 4,
                            CreatedAt = new DateTime(2025, 3, 3, 8, 10, 0, 20, DateTimeKind.Utc).AddTicks(9807),
                            Email = "gym@school.com",
                            FullName = "Gym Supervisor",
                            IsActive = true,
                            PasswordHash = "hashedpassword",
                            Phone = "555-1004",
                            RoleId = 2,
                            Username = "gym"
                        },
                        new
                        {
                            UserId = 5,
                            CreatedAt = new DateTime(2025, 3, 3, 8, 10, 0, 20, DateTimeKind.Utc).AddTicks(9808),
                            Email = "sports@school.com",
                            FullName = "Sports Coordinator",
                            IsActive = true,
                            PasswordHash = "hashedpassword",
                            Phone = "555-1005",
                            RoleId = 2,
                            Username = "sports"
                        },
                        new
                        {
                            UserId = 6,
                            CreatedAt = new DateTime(2025, 3, 3, 8, 10, 0, 20, DateTimeKind.Utc).AddTicks(9809),
                            Email = "it@school.com",
                            FullName = "IT Support",
                            IsActive = true,
                            PasswordHash = "hashedpassword",
                            Phone = "555-1006",
                            RoleId = 2,
                            Username = "it"
                        },
                        new
                        {
                            UserId = 7,
                            CreatedAt = new DateTime(2025, 3, 3, 8, 10, 0, 20, DateTimeKind.Utc).AddTicks(9810),
                            Email = "assistant1@school.com",
                            FullName = "Student Assistant",
                            IsActive = true,
                            PasswordHash = "hashedpassword",
                            Phone = "555-1007",
                            RoleId = 3,
                            Username = "assistant1"
                        },
                        new
                        {
                            UserId = 8,
                            CreatedAt = new DateTime(2025, 3, 3, 8, 10, 0, 20, DateTimeKind.Utc).AddTicks(9811),
                            Email = "tech@school.com",
                            FullName = "Lab Technician",
                            IsActive = true,
                            PasswordHash = "hashedpassword",
                            Phone = "555-1008",
                            RoleId = 3,
                            Username = "tech"
                        },
                        new
                        {
                            UserId = 9,
                            CreatedAt = new DateTime(2025, 3, 3, 8, 10, 0, 20, DateTimeKind.Utc).AddTicks(9813),
                            Email = "security@school.com",
                            FullName = "Security Staff",
                            IsActive = true,
                            PasswordHash = "hashedpassword",
                            Phone = "555-1009",
                            RoleId = 3,
                            Username = "security"
                        },
                        new
                        {
                            UserId = 10,
                            CreatedAt = new DateTime(2025, 3, 3, 8, 10, 0, 20, DateTimeKind.Utc).AddTicks(9814),
                            Email = "maintenance@school.com",
                            FullName = "Maintenance Staff",
                            IsActive = true,
                            PasswordHash = "hashedpassword",
                            Phone = "555-1010",
                            RoleId = 3,
                            Username = "maintenance"
                        });
                });

            modelBuilder.Entity("AspnetCoreMvcStarter.Models.UserFacility", b =>
                {
                    b.Property<int?>("UserId")
                        .HasColumnType("int");

                    b.Property<int?>("FacilityId")
                        .HasColumnType("int");

                    b.HasKey("UserId");

                    b.HasIndex("FacilityId");

                    b.ToTable("UserFacilities");
                });

            modelBuilder.Entity("AspnetCoreMvcStarter.Models.UserRole", b =>
                {
                    b.Property<int>("RoleId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("RoleId"));

                    b.Property<string>("RoleName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("RoleId");

                    b.ToTable("UserRoles");

                    b.HasData(
                        new
                        {
                            RoleId = 1,
                            RoleName = "Admin"
                        },
                        new
                        {
                            RoleId = 2,
                            RoleName = "FacilityHead"
                        },
                        new
                        {
                            RoleId = 3,
                            RoleName = "Assignee"
                        });
                });

            modelBuilder.Entity("AspnetCoreMvcStarter.Models.BorrowedItem", b =>
                {
                    b.HasOne("AspnetCoreMvcStarter.Models.Facility", "Facility")
                        .WithMany()
                        .HasForeignKey("FacilityId");

                    b.HasOne("AspnetCoreMvcStarter.Models.FacilityItem", "FacilityItem")
                        .WithMany()
                        .HasForeignKey("FacilityItemId");

                    b.HasOne("AspnetCoreMvcStarter.Models.User", "User")
                        .WithMany()
                        .HasForeignKey("UserId");

                    b.Navigation("Facility");

                    b.Navigation("FacilityItem");

                    b.Navigation("User");
                });

            modelBuilder.Entity("AspnetCoreMvcStarter.Models.Comment", b =>
                {
                    b.HasOne("AspnetCoreMvcStarter.Models.Request", "Request")
                        .WithOne("Comments")
                        .HasForeignKey("AspnetCoreMvcStarter.Models.Comment", "RequestId");

                    b.HasOne("AspnetCoreMvcStarter.Models.User", "User")
                        .WithMany()
                        .HasForeignKey("UserId");

                    b.Navigation("Request");

                    b.Navigation("User");
                });

            modelBuilder.Entity("AspnetCoreMvcStarter.Models.Facility", b =>
                {
                    b.HasOne("AspnetCoreMvcStarter.Models.User", "FacilityHead")
                        .WithMany()
                        .HasForeignKey("FacilityHeadId");

                    b.Navigation("FacilityHead");
                });

            modelBuilder.Entity("AspnetCoreMvcStarter.Models.Notification", b =>
                {
                    b.HasOne("AspnetCoreMvcStarter.Models.User", "User")
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("User");
                });

            modelBuilder.Entity("AspnetCoreMvcStarter.Models.Request", b =>
                {
                    b.HasOne("AspnetCoreMvcStarter.Models.Facility", "Facility")
                        .WithMany()
                        .HasForeignKey("FacilityId");

                    b.HasOne("AspnetCoreMvcStarter.Models.FacilityItem", "FacilityItem")
                        .WithMany()
                        .HasForeignKey("FacilityItemId")
                        .OnDelete(DeleteBehavior.Restrict);

                    b.HasOne("AspnetCoreMvcStarter.Models.User", "Requestor")
                        .WithMany()
                        .HasForeignKey("RequestorId");

                    b.Navigation("Facility");

                    b.Navigation("FacilityItem");

                    b.Navigation("Requestor");
                });

            modelBuilder.Entity("AspnetCoreMvcStarter.Models.User", b =>
                {
                    b.HasOne("AspnetCoreMvcStarter.Models.UserRole", "Role")
                        .WithMany()
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Role");
                });

            modelBuilder.Entity("AspnetCoreMvcStarter.Models.UserFacility", b =>
                {
                    b.HasOne("AspnetCoreMvcStarter.Models.Facility", "Facility")
                        .WithMany()
                        .HasForeignKey("FacilityId");

                    b.HasOne("AspnetCoreMvcStarter.Models.User", "User")
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Facility");

                    b.Navigation("User");
                });

            modelBuilder.Entity("AspnetCoreMvcStarter.Models.Request", b =>
                {
                    b.Navigation("Comments");
                });
#pragma warning restore 612, 618
        }
    }
}
