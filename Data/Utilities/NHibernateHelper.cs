﻿using System;
using System.IO;
using System.Linq;
using System.Reflection;
using FluentNHibernate.Cfg;
using NHibernate;
using NHibernate.Cfg;
using NHibernate.Tool.hbm2ddl;
using Utilities.ApplicationSettings;

namespace Data.Utilities
{
    public static class NHibernateHelper
    {
        private static readonly Configuration Configuration;
        public static readonly ISessionFactory SessionFactory;

        static NHibernateHelper()
        {
            var applicationSettings = new ApplicationSettings();
            Configuration = new Configuration();

            Configuration.SetProperty(NHibernate.Cfg.Environment.ConnectionString, applicationSettings.ConnectionString);
            Configuration.Configure();

            var currentAssembly = Assembly.GetExecutingAssembly();

            SessionFactory = Fluently.Configure(Configuration)
                .Mappings(m => m.FluentMappings.AddFromAssembly(currentAssembly))
                .BuildSessionFactory();
        }

        public static void CreateDatabaseSchema()
        {
            var schemaExport = new SchemaExport(Configuration);
            schemaExport.Drop(false, true);
            schemaExport.Create(false, true);

            ExecureCustomSql();
        }

        private static void ExecureCustomSql()
        {
            var assembly = Assembly.GetExecutingAssembly();
            var sqlFiles = assembly.GetManifestResourceNames().Where(x => x.Contains("CustomSql"));

            using (var connection = SessionFactory.OpenSession().Connection)
            {
                foreach (var file in sqlFiles.OrderBy(x => x))
                {
                    var stream = assembly.GetManifestResourceStream(file);

                    if (stream == null) continue;
                    
                    var command = connection.CreateCommand();
                    var splitter = new[] {"GO"};

                    var commandTexts = new StreamReader(stream).ReadToEnd()
                        .Split(splitter, StringSplitOptions.RemoveEmptyEntries);

                    foreach (var text in commandTexts)
                    {
                        command.CommandText = text;
                        command.ExecuteNonQuery();
                    }
                }
            }

        }
    }
}
