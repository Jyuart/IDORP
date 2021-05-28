using System;

namespace IdorpDemo.BL
{
    public class Entity
    {
        public Id<Guid> Id { get; set; }
        public string Name { get; set; }

        public Entity(Id<Guid> id, string name)
        {
            Id = id;
            Name = name;
        }
    }
}
