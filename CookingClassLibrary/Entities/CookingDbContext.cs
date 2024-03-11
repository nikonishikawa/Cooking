using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace CookingClassLibrary.Entities;

public partial class CookingDbContext : DbContext
{
    public CookingDbContext()
    {
    }

    public CookingDbContext(DbContextOptions<CookingDbContext> options)
        : base(options)
    {
    }

    public virtual DbSet<TblAllergen> TblAllergens { get; set; }

    public virtual DbSet<TblCategory> TblCategories { get; set; }

    public virtual DbSet<TblConversion> TblConversions { get; set; }

    public virtual DbSet<TblCredential> TblCredentials { get; set; }

    public virtual DbSet<TblCuisine> TblCuisines { get; set; }

    public virtual DbSet<TblEquipment> TblEquipments { get; set; }

    public virtual DbSet<TblIngredient> TblIngredients { get; set; }

    public virtual DbSet<TblIngredientSubstitution> TblIngredientSubstitutions { get; set; }

    public virtual DbSet<TblNutritional> TblNutritionals { get; set; }

    public virtual DbSet<TblProduce> TblProduces { get; set; }

    public virtual DbSet<TblRating> TblRatings { get; set; }

    public virtual DbSet<TblRecipe> TblRecipes { get; set; }

    public virtual DbSet<TblReview> TblReviews { get; set; }

    public virtual DbSet<TblSeason> TblSeasons { get; set; }

    public virtual DbSet<TblSeasonalAvailability> TblSeasonalAvailabilities { get; set; }

    public virtual DbSet<TblUser> TblUsers { get; set; }

    public virtual DbSet<TblUserRatingAndReview> TblUserRatingAndReviews { get; set; }

    public virtual DbSet<TblUserRatingAndReviewTemp> TblUserRatingAndReviewsTemps { get; set; }



    //    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    //#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see https://go.microsoft.com/fwlink/?LinkId=723263.
    //        => optionsBuilder.UseSqlServer("Data Source=nishikawa\\SQLEXPRESS;Initial Catalog=CookingDb;Integrated Security=True;TrustServerCertificate=True");

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        if (!optionsBuilder.IsConfigured)
        {
            optionsBuilder.UseSqlServer("Name=Conn");
        }
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<TblAllergen>(entity =>
        {
            entity.HasKey(e => e.AllergenId);

            entity.ToTable("TblAllergen");

            entity.Property(e => e.AllergenId).HasColumnName("AllergenID");
            entity.Property(e => e.AllergenType).HasMaxLength(50);
            entity.Property(e => e.IngredientId).HasColumnName("IngredientID");

            entity.HasOne(d => d.Ingredient).WithMany(p => p.TblAllergens)
                .HasForeignKey(d => d.IngredientId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_TblAllergen_TblIngredients");
        });

        modelBuilder.Entity<TblCategory>(entity =>
        {
            entity.HasKey(e => e.CategoryId);

            entity.ToTable("TblCategory");

            entity.Property(e => e.CategoryId).HasColumnName("CategoryID");
            entity.Property(e => e.Category).HasMaxLength(50);
        });

        modelBuilder.Entity<TblConversion>(entity =>
        {
            entity.HasKey(e => e.ConversionId);

            entity.ToTable("TblConversion");

            entity.Property(e => e.ConversionId).HasColumnName("ConversionID");
            entity.Property(e => e.ConversionFactor).HasColumnType("decimal(18, 2)");
            entity.Property(e => e.FromUnit).HasColumnType("decimal(18, 2)");
            entity.Property(e => e.ToUnit).HasColumnType("decimal(18, 2)");
        });

        modelBuilder.Entity<TblCredential>(entity =>
        {
            entity.HasKey(e => e.CredentialsId);

            entity.Property(e => e.CredentialsId).HasColumnName("CredentialsID");
            entity.Property(e => e.Password).HasMaxLength(50);
            entity.Property(e => e.Username).HasMaxLength(50);
        });

        modelBuilder.Entity<TblCuisine>(entity =>
        {
            entity.HasKey(e => e.CuisineId);

            entity.ToTable("TblCuisine");

            entity.Property(e => e.CuisineId).HasColumnName("CuisineID");
            entity.Property(e => e.Cuisine).HasMaxLength(50);
        });

        modelBuilder.Entity<TblEquipment>(entity =>
        {
            entity.HasKey(e => e.EquipmentId);

            entity.ToTable("TblEquipment");

            entity.Property(e => e.EquipmentId).HasColumnName("EquipmentID");
            entity.Property(e => e.Equipment).HasMaxLength(50);
            entity.Property(e => e.Usage).HasColumnType("text");
        });

        modelBuilder.Entity<TblIngredient>(entity =>
        {
            entity.HasKey(e => e.IngredientId);

            entity.Property(e => e.IngredientId).HasColumnName("IngredientID");
            entity.Property(e => e.CategoryId).HasColumnName("CategoryID");
            entity.Property(e => e.CommonUses).HasColumnType("text");
            entity.Property(e => e.Ingredient).HasMaxLength(50);

            entity.HasOne(d => d.Category).WithMany(p => p.TblIngredients)
                .HasForeignKey(d => d.CategoryId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_TblIngredients_TblCategory");
        });

        modelBuilder.Entity<TblIngredientSubstitution>(entity =>
        {
            entity.HasKey(e => e.IngredientSubstitutionId);

            entity.ToTable("TblIngredientSubstitution");

            entity.Property(e => e.IngredientSubstitutionId).HasColumnName("IngredientSubstitutionID");
            entity.Property(e => e.Ingredient).HasColumnType("text");
            entity.Property(e => e.SubstituteIngredientId).HasColumnName("SubstituteIngredientID");

            entity.HasOne(d => d.SubstituteIngredient).WithMany(p => p.TblIngredientSubstitutions)
                .HasForeignKey(d => d.SubstituteIngredientId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_TblIngredientSubstitution_TblIngredients");
        });

        modelBuilder.Entity<TblNutritional>(entity =>
        {
            entity.HasKey(e => e.NutritionalId);

            entity.ToTable("TblNutritional");

            entity.Property(e => e.NutritionalId).HasColumnName("NutritionalID");
            entity.Property(e => e.Calories).HasColumnType("decimal(18, 2)");
            entity.Property(e => e.Carbohydrates).HasColumnType("decimal(18, 2)");
            entity.Property(e => e.Fats).HasColumnType("decimal(18, 2)");
            entity.Property(e => e.IngredientId).HasColumnName("IngredientID");
            entity.Property(e => e.Protein).HasColumnType("decimal(18, 2)");

            entity.HasOne(d => d.Ingredient).WithMany(p => p.TblNutritionals)
                .HasForeignKey(d => d.IngredientId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_TblNutritional_TblIngredients");
        });

        modelBuilder.Entity<TblProduce>(entity =>
        {
            entity.HasKey(e => e.ProduceId);

            entity.ToTable("TblProduce");

            entity.Property(e => e.ProduceId).HasColumnName("ProduceID");
            entity.Property(e => e.Produce).HasMaxLength(50);
        });

        modelBuilder.Entity<TblRating>(entity =>
        {
            entity.HasKey(e => e.RatingId);

            entity.ToTable("TblRating");

            entity.Property(e => e.RatingId).HasColumnName("RatingID");
            entity.Property(e => e.Rating).HasColumnType("decimal(18, 5)");
        });

        modelBuilder.Entity<TblRecipe>(entity =>
        {
            entity.HasKey(e => e.RecipeId);

            entity.ToTable("TblRecipe");

            entity.Property(e => e.RecipeId).HasColumnName("RecipeID");
            entity.Property(e => e.CookingTime).HasColumnType("decimal(18, 2)");
            entity.Property(e => e.IngredientId).HasColumnName("IngredientID");
            entity.Property(e => e.Instructions).HasColumnType("text");
            entity.Property(e => e.Quantity)
                .HasMaxLength(10)
                .IsFixedLength();
            entity.Property(e => e.Recipe).HasMaxLength(50);

            entity.HasOne(d => d.Ingredient).WithMany(p => p.TblRecipes)
                .HasForeignKey(d => d.IngredientId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_TblRecipe_TblIngredients");
        });

        modelBuilder.Entity<TblReview>(entity =>
        {
            entity.HasKey(e => e.ReviewsId);

            entity.Property(e => e.ReviewsId).HasColumnName("ReviewsID");
            entity.Property(e => e.Review).HasColumnType("text");
        });

        modelBuilder.Entity<TblSeason>(entity =>
        {
            entity.HasKey(e => e.SeasonId);

            entity.ToTable("TblSeason");

            entity.Property(e => e.SeasonId).HasColumnName("SeasonID");
            entity.Property(e => e.Season).HasMaxLength(50);
        });

        modelBuilder.Entity<TblSeasonalAvailability>(entity =>
        {
            entity.HasKey(e => e.SeasonalAvailabilityId);

            entity.ToTable("TblSeasonalAvailability");

            entity.Property(e => e.SeasonalAvailabilityId).HasColumnName("SeasonalAvailabilityID");
            entity.Property(e => e.ProduceId).HasColumnName("ProduceID");
            entity.Property(e => e.SeasonId).HasColumnName("SeasonID");

            entity.HasOne(d => d.Produce).WithMany(p => p.TblSeasonalAvailabilities)
                .HasForeignKey(d => d.ProduceId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_TblSeasonalAvailability_TblProduce");

            entity.HasOne(d => d.Season).WithMany(p => p.TblSeasonalAvailabilities)
                .HasForeignKey(d => d.SeasonId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_TblSeasonalAvailability_TblSeason");
        });

        modelBuilder.Entity<TblUser>(entity =>
        {
            entity.HasKey(e => e.UserId);

            entity.ToTable("TblUser");

            entity.Property(e => e.UserId).HasColumnName("UserID");
            entity.Property(e => e.CredentialsId).HasColumnName("CredentialsID");
            entity.Property(e => e.Username).HasMaxLength(50);

            entity.HasOne(d => d.Credentials).WithMany(p => p.TblUsers)
                .HasForeignKey(d => d.CredentialsId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_TblUser_TblCredentials");
        });

        modelBuilder.Entity<TblUserRatingAndReview>(entity =>
        {
            entity.HasKey(e => e.UserRatingAndReviewId);

            entity.Property(e => e.UserRatingAndReviewId).HasColumnName("UserRatingAndReviewID");
            entity.Property(e => e.RatingId).HasColumnName("RatingID");
            entity.Property(e => e.RecipeId).HasColumnName("RecipeID");
            entity.Property(e => e.ReviewsId).HasColumnName("ReviewsID");
            entity.Property(e => e.UserId).HasColumnName("UserID");

            entity.HasOne(d => d.Rating).WithMany(p => p.TblUserRatingAndReviews)
                .HasForeignKey(d => d.RatingId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_TblUserRatingAndReviews_TblRating");

            entity.HasOne(d => d.Recipe).WithMany(p => p.TblUserRatingAndReviews)
                .HasForeignKey(d => d.RecipeId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_TblUserRatingAndReviews_TblRecipe");

            entity.HasOne(d => d.Reviews).WithMany(p => p.TblUserRatingAndReviews)
                .HasForeignKey(d => d.ReviewsId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_TblUserRatingAndReviews_TblReviews");

            entity.HasOne(d => d.User).WithMany(p => p.TblUserRatingAndReviews)
                .HasForeignKey(d => d.UserId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_TblUserRatingAndReviews_TblUser");
        });

        modelBuilder.Entity<TblUserRatingAndReviewTemp>(entity =>
        {
            entity.HasKey(e => e.UserRatingAndReviewTempId);

            entity.ToTable("TblUserRatingAndReviewsTemp");

            entity.Property(e => e.UserRatingAndReviewTempId).HasColumnName("UserRatingAndReviewTempID");
            entity.Property(e => e.Rating).HasColumnType("decimal(18, 2)");
            entity.Property(e => e.RatingId).HasColumnName("RatingID");
            entity.Property(e => e.RecipeId).HasColumnName("RecipeID");
            entity.Property(e => e.ReviewsId).HasColumnName("ReviewsID");
            entity.Property(e => e.UserId).HasColumnName("UserID");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
