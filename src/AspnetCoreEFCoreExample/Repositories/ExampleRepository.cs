using System;
using System.Collections.Generic;
using System.Linq;
using AspnetCoreEFCoreExample.Models;
using Microsoft.EntityFrameworkCore;

namespace AspnetCoreEFCoreExample.Repositories
{
    public class ExampleRepository : IExampleRepository
    {
        private readonly DataBaseContext _ctx;

        public ExampleRepository(DataBaseContext ctx)
        {
            _ctx = ctx;
        }

        public IEnumerable<MyModel> GetAll()
        {
            return _ctx.MyModels;
        }

         public IEnumerable<String> GetAssociatedEntities(EntityBee bee)
        {
            return _ctx.GetEntities(bee);
        }

        public MyModel GetSingle(int id)
        {
            return _ctx.MyModels.FirstOrDefault(x => x.Id == id);
        }

        public MyModel Add(MyModel toAdd)
        {
            _ctx.MyModels.Add(toAdd);
            return toAdd;
        }

        public MyModel Update(MyModel toUpdate)
        {
            _ctx.MyModels.Update(toUpdate);
            return toUpdate;
        }

        public void Delete(MyModel toDelete)
        {
            _ctx.MyModels.Remove(toDelete);
        }

        public int Save()
        {
            return _ctx.SaveChanges();
        }

        public int[] GetBFks()
        {
            var entB = _ctx.EntityBees.Find(1);

            var bId = entB.Id;

            var childList = new List<Type>();


            var cType = typeof(EntityCee);
            var dType = typeof(EntityDee);

            childList.Add(cType);
            childList.Add(dType);

            var childList2 = _ctx.Model.GetEntityTypes();

            foreach(var c in childList2)
            {
                //var instance = (BaseEntity)Activator.CreateInstance(c.FindProperty);
                //instance.HasParentRecords(bId);
            }



return new int[0]{};



        }

        

        public EntityBee GetEntityBee(int bId)
        {
            return _ctx.EntityBees.FirstOrDefault(x => x.Id == bId);
        }
    }
}
