using System;

namespace Module_2
{
    public class DatingUser
    {
        public int Iq { get; }
        public string Name { get; }

        public DatingUser(int iq, string name)
        {
            Iq = iq;
            Name = name;
        }
        public DatingUser() { }
    }
}
