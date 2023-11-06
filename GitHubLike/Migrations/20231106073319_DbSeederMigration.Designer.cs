﻿// <auto-generated />
using System;
using GitHubLike.Modules.Common.Entity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace GitHubLike.Migrations
{
    [DbContext(typeof(ApplicationDbContext))]
    [Migration("20231106073319_DbSeederMigration")]
    partial class DbSeederMigration
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.13")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("GitHubLike.Modules.Common.Entity.OwnerType", b =>
                {
                    b.Property<int>("OwnerTypeId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("OwnerTypeId"));

                    b.Property<long?>("ProjectsId")
                        .HasColumnType("bigint");

                    b.Property<bool>("SoftDeleted")
                        .HasColumnType("bit");

                    b.Property<string>("Type")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.HasKey("OwnerTypeId");

                    b.HasIndex("ProjectsId");

                    b.ToTable("OwnerType");
                });

            modelBuilder.Entity("GitHubLike.Modules.OrganizationModule.Entity.OrganizationRoles", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("OrganizationRoleName")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<bool>("SoftDeleted")
                        .HasColumnType("bit");

                    b.HasKey("Id");

                    b.ToTable("OrganizationModule_OrganizationRoles");
                });

            modelBuilder.Entity("GitHubLike.Modules.OrganizationModule.Entity.OrganizationUsers", b =>
                {
                    b.Property<long>("UserId")
                        .HasColumnType("bigint");

                    b.Property<long>("OrganizationId")
                        .HasColumnType("bigint");

                    b.Property<long>("OrgRoleId")
                        .HasColumnType("bigint");

                    b.Property<bool>("AcceptedInvite")
                        .HasColumnType("bit");

                    b.Property<int>("OrganizationRoleId")
                        .HasColumnType("int");

                    b.HasKey("UserId", "OrganizationId", "OrgRoleId");

                    b.HasIndex("OrganizationId");

                    b.HasIndex("OrganizationRoleId");

                    b.ToTable("OrganizationModule_OrganizationUsers");
                });

            modelBuilder.Entity("GitHubLike.Modules.OrganizationModule.Entity.Organizations", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<long>("Id"));

                    b.Property<DateTimeOffset>("CreatedAt")
                        .HasColumnType("datetimeoffset");

                    b.Property<string>("OrganizationName")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<long>("OwnerUserId")
                        .HasColumnType("bigint");

                    b.Property<bool?>("SoftDeleted")
                        .HasColumnType("bit");

                    b.Property<DateTimeOffset?>("UpdatedAt")
                        .HasColumnType("datetimeoffset");

                    b.Property<long?>("UpdatedBy")
                        .HasColumnType("bigint");

                    b.Property<long>("WorkspaceId")
                        .HasColumnType("bigint");

                    b.HasKey("Id");

                    b.HasIndex("OwnerUserId");

                    b.HasIndex("WorkspaceId");

                    b.ToTable("OrganizationModule_Organization");
                });

            modelBuilder.Entity("GitHubLike.Modules.ProjectModule.Entity.ProjectUsers", b =>
                {
                    b.Property<long>("UserId")
                        .HasColumnType("bigint");

                    b.Property<long>("ProjectId")
                        .HasColumnType("bigint");

                    b.Property<long>("RoleId")
                        .HasColumnType("bigint");

                    b.Property<bool>("AcceptedInvite")
                        .HasColumnType("bit");

                    b.Property<long>("ProjectsId")
                        .HasColumnType("bigint");

                    b.Property<long>("RolesId")
                        .HasColumnType("bigint");

                    b.HasKey("UserId", "ProjectId", "RoleId");

                    b.HasIndex("ProjectsId");

                    b.HasIndex("RolesId");

                    b.ToTable("ProjectModule_ProjectUsers");
                });

            modelBuilder.Entity("GitHubLike.Modules.ProjectModule.Entity.Projects", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<long>("Id"));

                    b.Property<DateTimeOffset>("CreatedAt")
                        .HasColumnType("datetimeoffset");

                    b.Property<int>("OwnerId")
                        .HasColumnType("int");

                    b.Property<int>("OwnerTypeId")
                        .HasColumnType("int");

                    b.Property<string>("ProjectName")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<bool?>("SoftDeleted")
                        .HasColumnType("bit");

                    b.Property<DateTimeOffset?>("UpdatedAt")
                        .HasColumnType("datetimeoffset");

                    b.Property<long?>("UpdatedBy")
                        .HasColumnType("bigint");

                    b.Property<long>("WorkspaceId")
                        .HasColumnType("bigint");

                    b.HasKey("Id");

                    b.HasIndex("WorkspaceId");

                    b.ToTable("ProjectModule_Project");
                });

            modelBuilder.Entity("GitHubLike.Modules.RoleModule.Entity.Roles", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<long>("Id"));

                    b.Property<DateTimeOffset>("CreatedAt")
                        .HasColumnType("datetimeoffset");

                    b.Property<long>("CreatedById")
                        .HasColumnType("bigint");

                    b.Property<long>("CreatedByUserId")
                        .HasColumnType("bigint");

                    b.Property<int>("Permissions")
                        .HasColumnType("int");

                    b.Property<string>("RoleName")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<bool?>("SoftDeleted")
                        .HasColumnType("bit");

                    b.Property<DateTimeOffset?>("UpdatedAt")
                        .HasColumnType("datetimeoffset");

                    b.Property<long?>("UpdatedBy")
                        .HasColumnType("bigint");

                    b.HasKey("Id");

                    b.HasIndex("CreatedById");

                    b.ToTable("RoleModule_Roles");
                });

            modelBuilder.Entity("GitHubLike.Modules.UserModule.Entity.User", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<long>("Id"));

                    b.Property<DateTimeOffset>("CreatedAt")
                        .HasColumnType("datetimeoffset");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool?>("SoftDeleted")
                        .HasColumnType("bit");

                    b.Property<DateTimeOffset?>("UpdatedAt")
                        .HasColumnType("datetimeoffset");

                    b.Property<long?>("UpdatedBy")
                        .HasColumnType("bigint");

                    b.Property<string>("UserName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("UserPassword")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<long>("WorkspaceId")
                        .HasColumnType("bigint");

                    b.HasKey("Id");

                    b.HasIndex("WorkspaceId");

                    b.ToTable("UserModule_User");
                });

            modelBuilder.Entity("GitHubLike.Modules.WorkspaceModule.Entity.Workspace", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<long>("Id"));

                    b.Property<DateTimeOffset>("CreatedAt")
                        .HasColumnType("datetimeoffset");

                    b.Property<bool?>("SoftDeleted")
                        .HasColumnType("bit");

                    b.Property<DateTimeOffset?>("UpdatedAt")
                        .HasColumnType("datetimeoffset");

                    b.Property<long?>("UpdatedBy")
                        .HasColumnType("bigint");

                    b.Property<string>("WorkspaceName")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.HasKey("Id");

                    b.ToTable("WorkspaceModule_Workspace");
                });

            modelBuilder.Entity("GitHubLike.Modules.Common.Entity.OwnerType", b =>
                {
                    b.HasOne("GitHubLike.Modules.ProjectModule.Entity.Projects", null)
                        .WithMany("OwnerTypes")
                        .HasForeignKey("ProjectsId");
                });

            modelBuilder.Entity("GitHubLike.Modules.OrganizationModule.Entity.OrganizationUsers", b =>
                {
                    b.HasOne("GitHubLike.Modules.OrganizationModule.Entity.Organizations", "Organization")
                        .WithMany()
                        .HasForeignKey("OrganizationId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("GitHubLike.Modules.OrganizationModule.Entity.OrganizationRoles", "OrganizationRole")
                        .WithMany()
                        .HasForeignKey("OrganizationRoleId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("GitHubLike.Modules.UserModule.Entity.User", "User")
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Organization");

                    b.Navigation("OrganizationRole");

                    b.Navigation("User");
                });

            modelBuilder.Entity("GitHubLike.Modules.OrganizationModule.Entity.Organizations", b =>
                {
                    b.HasOne("GitHubLike.Modules.UserModule.Entity.User", "OwnerUser")
                        .WithMany()
                        .HasForeignKey("OwnerUserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("GitHubLike.Modules.WorkspaceModule.Entity.Workspace", "Workspace")
                        .WithMany()
                        .HasForeignKey("WorkspaceId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("OwnerUser");

                    b.Navigation("Workspace");
                });

            modelBuilder.Entity("GitHubLike.Modules.ProjectModule.Entity.ProjectUsers", b =>
                {
                    b.HasOne("GitHubLike.Modules.ProjectModule.Entity.Projects", "Projects")
                        .WithMany()
                        .HasForeignKey("ProjectsId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("GitHubLike.Modules.RoleModule.Entity.Roles", "Roles")
                        .WithMany()
                        .HasForeignKey("RolesId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("GitHubLike.Modules.UserModule.Entity.User", "Users")
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Projects");

                    b.Navigation("Roles");

                    b.Navigation("Users");
                });

            modelBuilder.Entity("GitHubLike.Modules.ProjectModule.Entity.Projects", b =>
                {
                    b.HasOne("GitHubLike.Modules.WorkspaceModule.Entity.Workspace", "Workspace")
                        .WithMany()
                        .HasForeignKey("WorkspaceId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Workspace");
                });

            modelBuilder.Entity("GitHubLike.Modules.RoleModule.Entity.Roles", b =>
                {
                    b.HasOne("GitHubLike.Modules.UserModule.Entity.User", "CreatedBy")
                        .WithMany()
                        .HasForeignKey("CreatedById")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("CreatedBy");
                });

            modelBuilder.Entity("GitHubLike.Modules.UserModule.Entity.User", b =>
                {
                    b.HasOne("GitHubLike.Modules.WorkspaceModule.Entity.Workspace", "Workspace")
                        .WithMany()
                        .HasForeignKey("WorkspaceId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Workspace");
                });

            modelBuilder.Entity("GitHubLike.Modules.ProjectModule.Entity.Projects", b =>
                {
                    b.Navigation("OwnerTypes");
                });
#pragma warning restore 612, 618
        }
    }
}
