using System;
using System.Data.Common;
using Autofac;
using JetBrains.Annotations;
using Microsoft.EntityFrameworkCore;

namespace OpenVASP.PostgreSql
{
    [PublicAPI]
    public static class PostgreSqlBootstrapExtension
    {
        [Obsolete("Use RegisterPostgreSql with dbConnString parameter")]
        public static void RegisterPostgreSql<T>(this ContainerBuilder builder, Func<T> contextCreator) where T: PostgreSqlContext
        {
            using (var context = contextCreator.Invoke())
            {
                context.IsTraceEnabled = true;

                context.Database.Migrate();
            }

            builder.RegisterInstance(new PostgreSqlContextFactory<T>(contextCreator))
                .AsSelf()
                .SingleInstance();
        }

        public static void RegisterPostgreSql<T>(
            this ContainerBuilder builder,
            string dbConnString,
            Func<string, T> connStringCreator,
            Func<DbConnection, T> dbConnectionCreator)
            where T : PostgreSqlContext
        {
            using (var context = connStringCreator(dbConnString))
            {
                context.IsTraceEnabled = true;

                context.Database.Migrate();
            }

            builder.RegisterInstance(
                    new PostgreSqlContextFactory<T>(
                        dbConnString,
                        connStringCreator,
                        dbConnectionCreator))
                .AsSelf()
                .As<IDbContextFactory<T>>()
                .As<ITransactionRunner>()
                .SingleInstance();
        }
    }
}