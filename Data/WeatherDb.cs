using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CityWeatherApp.Models;
using Microsoft.EntityFrameworkCore;

namespace CityWeatherApp.Data
{
    public class WeatherDb : DbContext
    {
        public WeatherDb(DbContextOptions<WeatherDb> options)
        : base(options)
        {
        }
        public DbSet<CurrentWeather> CurrentWeather { get; set; }
        public DbSet<CityFavorite> CityFavorite { get; set; }


        //protected override void OnModelCreating(ModelBuilder modelBuilder)
        //{
        //   modelBuilder.Entity<SityFavorite>(entity =>
        //    {
        //        //entity.Property(e => e.Id).HasColumnName("ID");

        //        //entity.Property(e => e.ClientVersion)
        //        //    .HasMaxLength(20)
        //        //    .IsUnicode(false);

        //        //entity.Property(e => e.DeviceId)
        //        //    .HasColumnName("DeviceID")
        //        //    .HasMaxLength(50)
        //        //    .IsUnicode(false);

        //        //entity.Property(e => e.EndDate).HasColumnType("datetime");

        //        //entity.Property(e => e.ErrorMsg).HasMaxLength(4000);

        //        //entity.Property(e => e.InputType)
        //        //    .HasMaxLength(50)
        //        //    .IsUnicode(false);

        //        //entity.Property(e => e.Language)
        //        //    .HasMaxLength(10)
        //        //    .IsUnicode(false);

        //        //entity.Property(e => e.MemberId)
        //        //    .HasMaxLength(20)
        //        //    .IsUnicode(false);

        //        //entity.Property(e => e.Message).HasMaxLength(300);

        //        //entity.Property(e => e.MethodInput).HasMaxLength(4000);

        //        //entity.Property(e => e.MethodName)
        //        //    .HasMaxLength(50)
        //        //    .IsUnicode(false);

        //        //entity.Property(e => e.MethodOutput).HasMaxLength(4000);

        //        //entity.Property(e => e.RequestId)
        //        //    .HasColumnName("RequestID")
        //        //    .HasMaxLength(40)
        //        //    .IsUnicode(false);

        //        //entity.Property(e => e.StartDate).HasColumnType("datetime");

        //        //entity.Property(e => e.Token)
        //        //    .HasMaxLength(1000)
        //        //    .IsUnicode(false);

        //        //entity.Property(e => e.Type)
        //        //    .HasMaxLength(10)
        //        //    .IsUnicode(false);

        //        //entity.Property(e => e.Uri)
        //        //    .HasMaxLength(300)
        //        //    .IsUnicode(false);

        //        //entity.Property(e => e.UserAgent)
        //        //    .HasMaxLength(300)
        //        //    .IsUnicode(false);
        //    });

        //    modelBuilder.Entity<CurrentWeather>(entity =>
        //    {

        //        entity.HasKey(e => e.CityKey);
        //        entity.Property(e => e.CityKey).HasMaxLength(50);
        //        entity.Property(e => e.ObservationDateTime).HasMaxLength(7);


        //        entity.Property(e => e.WeatherText).HasMaxLength(200);

        //        //entity.Property(e => e.Title).HasMaxLength(100);

        //        //entity.Property(e => e.Type)
        //        //    .IsRequired()
        //        //    .HasMaxLength(50)
        //        //    .IsUnicode(false);
        //    });
        //}
    }

    }
