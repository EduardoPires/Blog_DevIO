﻿namespace Blog_DevIO.Domain.Entities
{
    public class EntityBase
    {
        public EntityBase(Guid id)
        {
            Id = id;
        }

        public EntityBase()
        {
            Id = Guid.NewGuid();
        }

        public Guid Id { get; private set; }
        public DateTime Creation { get; private set; }
    }
}
