using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MinecraftServerInstancesLauncher.ApplicationBuilder
{
    public interface IApplicationBuilder
    {
        public IApplicationBuilder Build(string[] args);
        public IApplicationBuilder Start();
    }
}
