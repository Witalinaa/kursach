﻿//------------------------------------------------------------------------------
// <auto-generated>
//     Этот код создан по шаблону.
//
//     Изменения, вносимые в этот файл вручную, могут привести к непредвиденной работе приложения.
//     Изменения, вносимые в этот файл вручную, будут перезаписаны при повторном создании кода.
// </auto-generated>
//------------------------------------------------------------------------------

namespace kurs
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Infrastructure;
    
    public partial class final : DbContext
    {
        private static final _context;

        public final()
            : base("name=final")
        {
        }

        public static final GetContext()
        {
            if (_context == null)
            {
                _context = new final();
            }
            return _context;
        }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            throw new UnintentionalCodeFirstException();
        }
    
        public virtual DbSet<Blydo> Blydo { get; set; }
        public virtual DbSet<Smena> Smena { get; set; }
        public virtual DbSet<Users> Users { get; set; }
        public virtual DbSet<Zakaz> Zakaz { get; set; }
    }
}
