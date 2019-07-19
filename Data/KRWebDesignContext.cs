using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using KRWebDesign.Models;

namespace KRWebDesign.Models
{
    public class KRWebDesignContext : DbContext
    {
        public KRWebDesignContext()
        {
        }

        public KRWebDesignContext (DbContextOptions<KRWebDesignContext> options)
            : base(options)
        {
        }


        public DbSet<KRWebDesign.Models.FavoriteWebSites> FavoriteWebSites { get; set; }
        public DbSet<KRWebDesign.Models.Beef> Beef { get; set; }
        public DbSet<KRWebDesign.Models.Cart> Carts { get; set; }
        public DbSet<KRWebDesign.Models.Products> Products { get; set; }
        public DbSet<KRWebDesign.Models.Order> Order { get; set; }
        public DbSet<KRWebDesign.Models.OrderDetail> OrderDetails { get; set; }
        public DbSet<KRWebDesign.Models.PlayerData> PlayerData { get; set; }
        public DbSet<KRWebDesign.Models.PongHighScore> HighScorePong { get; set; }
    }
}
