using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DocSystEntities.User
{
    public class User
    {
        private string v1;
        private string v2;
        private string v3;
        private string v4;
        private string v5;
        private bool v6;

        public User() { }

        public User(string v1, string v2, string v3, string v4, string v5, bool v6)
        {
            this.v1 = v1;
            this.v2 = v2;
            this.v3 = v3;
            this.v4 = v4;
            this.v5 = v5;
            this.v6 = v6;
        }
    }
}
