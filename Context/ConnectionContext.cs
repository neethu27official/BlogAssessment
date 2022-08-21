using BlogAssessment.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace BlogAssessment.Context
{
    public class ConnectionContext:DbContext
    {
        #region Initialize DBSet
        public DbSet<ArticleEntity> Articles { get; set; }
        #endregion

        #region Constructor
        public ConnectionContext() : base("DBConnectionContext")
        {
            //create database if not exists
            Database.SetInitializer<ConnectionContext>(new CreateDatabaseIfNotExists<ConnectionContext>());
            //migrate  the new changes to database
            Database.SetInitializer(new MigrateDatabaseToLatestVersion<ConnectionContext, BlogAssessment.Migrations.Configuration>());
        }
        #endregion
    }
}