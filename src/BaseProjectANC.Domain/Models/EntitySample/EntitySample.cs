using BaseProjectANC.Domain.Core.Models;
using System;

namespace BaseProjectANC.Domain.Models.EntitySample
{
    public class EntitySample : Entity
    {
        public string Descricao { get; set; }

        public EntitySample(string descricao)
        {
            this.Descricao = descricao;
        }

        protected EntitySample(){}

        public static class EntitySampleFactory
        {
            public static EntitySample EntitySampleFull(Guid id,string descricao)
            {
                return new EntitySample() { Id = id, Descricao = descricao };
            }
        }
    }
}
