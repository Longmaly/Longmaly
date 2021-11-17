using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Unity;

namespace DemoApi.Dal
{
   public abstract class AContainer : UnityContainer
    {
        protected AContainer() => RegisterServices();
        protected abstract void RegisterServices();
    }
}
