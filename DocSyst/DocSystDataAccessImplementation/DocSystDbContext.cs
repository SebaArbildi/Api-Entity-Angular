﻿using DocSystEntities.Audit;
using DocSystEntities.DocumentStructure;
using DocSystEntities.StyleStructure;
using DocSystEntities.User;
using System.Data.Entity;

namespace DocSystDataAccessImplementation
{
    public class DocSystDbContext : DbContext
    {
        public DocSystDbContext() : base("name=VehicleManagerDbContext") { }
        public DbSet<Body> Bodys { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<Document> Documents { get; set; }
        public DbSet<Margin> Margins { get; set; }
        public DbSet<Paragraph> Paragraphs { get; set; }
        public DbSet<Text> Texts { get; set; }
        public DbSet<AuditLog> AuditLogs { get; set; }
        public DbSet<Style> Styles { get; set; }
        public DbSet<StyleClass> StyleClasses { get; set; }
        public DbSet<Format> Formats { get; set; }
    }
}