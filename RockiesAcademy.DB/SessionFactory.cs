﻿using FluentNHibernate.Cfg.Db;
using FluentNHibernate.Cfg;
using NHibernate;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NHibernate.Tool.hbm2ddl;
using NHibernate.Cfg;

namespace RockiesAcademy.DB;

 public class SessionFactory  
 { 
    public SessionFactory() 
    {
        if (_sessionFactory is null)
        {
            _sessionFactory = BuildSessionFactory();
        }
    }

    public bool Commit(ISession session)
    {
        using var transaction =session.BeginTransaction();
        try
        {
            if (transaction.IsActive)
            {
                transaction.Commit();
            }
            return true;
        }
        catch (Exception)
        {
            transaction.Rollback();
            return false;

        }
    }

    public ISession Session => _sessionFactory.OpenSession();

    public ISessionFactory _sessionFactory;
        private Configuration config;

        private ISessionFactory BuildSessionFactory()
        {
            var configuration = Fluently.Configure()
                .Database (MsSqlConfiguration.MsSql2012.ConnectionString(_connectionString))
                .Mappings (m=>m.FluentMappings.AddFromAssemblyOf<SessionFactory>())
                .ExposeConfiguration(BuildSchema);

            var sessionFactory = configuration.BuildSessionFactory();
            return sessionFactory;
        }

        private void BuildSchema(Configuration config)
        {
            new SchemaExport(config).Create(true, true);
        }

    private readonly string _connectionString = @"Data Source=(LocalDB)\MSSQLLocalDB;
    AttachDbFilename=""C:\Users\EZINNE\Desktop\CCSA Final Project\Rockies Academy.mdf"";
    Integrated Security=True;Connect Timeout=30";

}
