using System;

namespace Project.Domain.Entities
{
    public class Person : Entity<int>
    {
        public virtual String Name { get; set; }
        public virtual String LastName { get; set; }
        public virtual String Birthday { get; set; }
        public virtual String Username { get; set; }
        public virtual String Password { get; set; }
    }
}