using System;
using Microsoft.Data.Entity;
using Microsoft.Data.Entity.Infrastructure;
using Microsoft.Data.Entity.Metadata;
using Microsoft.Data.Entity.Migrations;
using aCMS.Core.Models;

namespace aCMS.Web.Migrations
{
    [DbContext(typeof(CmsContext))]
    partial class CmsContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.0-rc1-16348");

            modelBuilder.Entity("aCMS.Core.Models.Author", b =>
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

                    b.Property<string>("Url")
                        .IsRequired();

                    b.HasKey("Id");
                });

            modelBuilder.Entity("aCMS.Core.Models.Blog", b =>
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

                    b.Property<string>("SubTitle");

                    b.Property<string>("Title")
                        .IsRequired();

                    b.Property<string>("Url")
                        .IsRequired();

                    b.HasKey("Id");
                });

            modelBuilder.Entity("aCMS.Core.Models.Page", b =>
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

                    b.Property<string>("SubTitle");

                    b.Property<string>("Title")
                        .IsRequired();

                    b.Property<string>("Url")
                        .IsRequired();

                    b.HasKey("Id");
                });

            modelBuilder.Entity("aCMS.Core.Models.Post", b =>
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

                    b.Property<string>("SubTitle");

                    b.Property<string>("Title")
                        .IsRequired();

                    b.Property<string>("Url")
                        .IsRequired();

                    b.HasKey("Id");
                });

            modelBuilder.Entity("aCMS.Core.Models.Blog", b =>
                {
                    b.HasOne("aCMS.Core.Models.Author")
                        .WithMany()
                        .HasForeignKey("AuthorId");
                });

            modelBuilder.Entity("aCMS.Core.Models.Page", b =>
                {
                    b.HasOne("aCMS.Core.Models.Author")
                        .WithMany()
                        .HasForeignKey("AuthorId");
                });

            modelBuilder.Entity("aCMS.Core.Models.Post", b =>
                {
                    b.HasOne("aCMS.Core.Models.Author")
                        .WithMany()
                        .HasForeignKey("AuthorId");

                    b.HasOne("aCMS.Core.Models.Blog")
                        .WithMany()
                        .HasForeignKey("BlogId");
                });
        }
    }
}
