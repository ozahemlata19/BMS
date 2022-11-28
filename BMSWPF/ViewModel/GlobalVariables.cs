using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BMSWPF.ViewModel
{
    class GlobalVariables
    {
        private static string username;

        public static string USERNAME
        {
            get { return username; }
            set { username = value; }
        }
    }
}
