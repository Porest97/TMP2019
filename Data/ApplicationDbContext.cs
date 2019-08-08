﻿using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using TMP2019.Models.DataModels;

namespace TMP2019.Data
{
    public class ApplicationDbContext : IdentityDbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }
        public DbSet<TMP2019.Models.DataModels.Person> Person { get; set; }
        public DbSet<TMP2019.Models.DataModels.Club> Club { get; set; }
        public DbSet<TMP2019.Models.DataModels.Company> Company { get; set; }
        public DbSet<TMP2019.Models.DataModels.District> District { get; set; }
        public DbSet<TMP2019.Models.DataModels.PersonType> PersonType { get; set; }
        public DbSet<TMP2019.Models.DataModels.Match> Match { get; set; }
        public DbSet<TMP2019.Models.DataModels.Arena> Arena { get; set; }
        public DbSet<TMP2019.Models.DataModels.MatchCategory> MatchCategory { get; set; }
        public DbSet<TMP2019.Models.DataModels.Receipt> Receipt { get; set; }
        public DbSet<TMP2019.Models.DataModels.Team> Team { get; set; }
        public DbSet<TMP2019.Models.DataModels.Tournament> Tournament { get; set; }
        public DbSet<TMP2019.Models.DataModels.Activity> Activity { get; set; }
        public DbSet<TMP2019.Models.DataModels.ActivityType> ActivityType { get; set; }
        public DbSet<TMP2019.Models.DataModels.Camp> Camp { get; set; }
    }
}