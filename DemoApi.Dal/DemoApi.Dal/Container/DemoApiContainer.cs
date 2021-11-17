using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Unity;
using Unity.Lifetime;

namespace DemoApi.Dal
{
    public class DemoApiContainer : AContainer
    {
        public static DemoApiContainer Current { get { return new DemoApiContainer(); } }
        protected override void RegisterServices()
        {
            string pgConnString = DemoApiHelper.GetValueFromEnv("DemoPgConnString");
            if (string.IsNullOrEmpty(pgConnString))
            {
                throw new Exception("DemoPgConnString env variable is not found.");
            }
            DbContextOptionsBuilder<DemoApiDbContext> demoApiOptBuilder = new DbContextOptionsBuilder<DemoApiDbContext>();

            demoApiOptBuilder.UseNpgsql(pgConnString, builder =>
            {
            });
            DemoApiDbContext demoDbContext = new DemoApiDbContext(demoApiOptBuilder.Options);
            this.RegisterInstance(demoDbContext, new SingletonLifetimeManager());
        }
    }
}
