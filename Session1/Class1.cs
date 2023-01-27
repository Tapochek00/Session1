using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Session1
{
    public class Context : Session1Entities
    {
        private static Context context;

        public static Context GetContext()
        {
            if (context == null) context = new Context();
            return context;
        }
    }
}
