using System;
using Microsoft.Data.Entity;
using Microsoft.Data.Entity.Infrastructure;
using Microsoft.Data.Entity.Metadata;
using Microsoft.Data.Entity.Migrations;
using aCMS.Models;

namespace aCMS.Migrations
{
    [DbContext(typeof(CmsContext))]
    [Migration("20151113210609_Create Authors table")]
    partial class CreateAuthorstable
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.0-beta8-15964");

            modelBuilder.Entity("aCMS.Models.Author", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Bio")
                        .IsRequired();

                    b.Property<string>("BitbucketUsername");

                    b.Property<string>("CodepenUsername");

                    b.Property<string>("Email");

                    b.Property<bool>("EmailPublicDisplay");

                    b.Property<string>("FacebookUsername");

                    b.Property<string>("GithubUsername");

                    b.Property<string>("ImageUrl")
                        .IsRequired();

                    b.Property<string>("Name")
                        .IsRequired();

                    b.Property<string>("StackoverflowUsername");

                    b.Property<string>("TwitterHandle");

                    b.HasKey("Id");
                });

            modelBuilder.Entity("aCMS.Models.Blog", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<bool>("AuthorDisplay");

                    b.Property<int>("AuthorId");

                    b.Property<string>("Content")
                        .IsRequired();

                    b.Property<DateTimeOffset>("DateTimeCreated");

                    b.Property<bool>("DateTimeDisplay");

                    b.Property<DateTimeOffset>("DateTimeUpdated");

                    b.Property<string>("Title")
                        .IsRequired();

                    b.Property<string>("Url")
                        .IsRequired();

                    b.HasKey("Id");
                });

            modelBuilder.Entity("aCMS.Models.Page", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<bool>("AuthorDisplay");

                    b.Property<int>("AuthorId");

                    b.Property<string>("Content")
                        .IsRequired();

                    b.Property<DateTimeOffset>("DateTimeCreated");

                    b.Property<bool>("DateTimeDisplay");

                    b.Property<DateTimeOffset>("DateTimeUpdated");

                    b.Property<string>("Title")
                        .IsRequired();

                    b.Property<string>("Url")
                        .IsRequired();

                    b.HasKey("Id");
                });

            modelBuilder.Entity("aCMS.Models.Post", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<bool>("AuthorDisplay");

                    b.Property<int>("AuthorId");

                    b.Property<int>("BlogId");

                    b.Property<string>("Content")
                        .IsRequired();

                    b.Property<DateTimeOffset>("DateTimeCreated");

                    b.Property<bool>("DateTimeDisplay");

                    b.Property<DateTimeOffset>("DateTimeUpdated");

                    b.Property<string>("Title")
                        .IsRequired();

                    b.Property<string>("Url")
                        .IsRequired();

                    b.HasKey("Id");
                });

            modelBuilder.Entity("aCMS.Models.Blog", b =>
                {
                    b.HasOne("aCMS.Models.Author")
                        .WithMany()
                        .HasForeignKey("AuthorId");
                });

            modelBuilder.Entity("aCMS.Models.Page", b =>
                {
                    b.HasOne("aCMS.Models.Author")
                        .WithMany()
                        .HasForeignKey("AuthorId");
                });

            modelBuilder.Entity("aCMS.Models.Post", b =>
                {
                    b.HasOne("aCMS.Models.Author")
                        .WithMany()
                        .HasForeignKey("AuthorId");

                    b.HasOne("aCMS.Models.Blog")
                        .WithMany()
                        .HasForeignKey("BlogId");
                });
        }
    }
}
