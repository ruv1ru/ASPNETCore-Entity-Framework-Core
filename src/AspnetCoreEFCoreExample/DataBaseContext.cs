using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using AspnetCoreEFCoreExample.Models;
using Microsoft.EntityFrameworkCore;

namespace AspnetCoreEFCoreExample
{
    public class DataBaseContext : DbContext
    {
        public DbSet<MyModel> MyModels { get; set; }
        public DbSet<EntityBee> EntityBees { get; set; }
        public DbSet<EntityCee> EntityCees { get; set; }
        public DbSet<EntityDee> EntityDees { get; set; }

        public DataBaseContext(DbContextOptions<DataBaseContext> options)
            : base(options)
        { }


        public List<string> GetEntities(EntityBee bee)
        {
            var types = new List<string>();

            foreach (var entityType in this.Model.GetEntityTypes())
            {
                var clr = entityType.ClrType;

                var tableName = entityType.Relational().TableName;

                BaseEntity instance = (BaseEntity)Activator.CreateInstance(clr);

                var isChildOfBee = instance.IsChildOfBee();

                if(isChildOfBee)
                {
                    var query = $"select top(1) * from EntityBees where Id IN (select EntityBeeId from {tableName} where EntityBeeId = {bee.Id})";
                   
                    var eB = this.EntityBees.FromSql(query).FirstOrDefault();

                    if(eB != null)
                    {
                        types.Add(instance.GetDisplayName());
                    }

                }

                // var rel = entityType.Relational();
                // var eType = rel.GetType();
                // var tableName = entityType.Relational().TableName;
                // foreach (var propertyType in entityType.GetProperties())
                // {
                //     var columnName = propertyType.Relational().ColumnName;
                // }
            }
            return types;
        }
        public bool CheckIfEntityExistsByEntityId<T>(Expression<Func<T,bool>> expr)
        {
            return false;
            //return this.DbSet().Any(u => expr);
        }
    }
}
