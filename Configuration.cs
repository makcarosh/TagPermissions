using JetBrains.Annotations;
using Rocket.API;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TagPerm
{
    public class PluginCfg : IRocketPluginConfiguration
    {
        public List<string> servertag;
        public string group;
        public void LoadDefaults()
        {
            servertag = new List<string>
            {
                "#original",
                "#orig"
            };

            group = "orig";
        }
    }
}
