using System;

namespace BaseProjectANC.Domain.Core.Models
{
    public abstract class Entity
    {
        public Entity()
        {
            this.Id = Guid.NewGuid();
        }

        public Guid Id { get; set; }

        public string CriadoPor { get; set; } = null;

        public string AtualizadoPor { get; set; } = null;

        public string DeletadoPor { get; set; } = null;

        public DateTime? CriadoEm { get; set; }

        public DateTime? AtualizadoEm { get; set; }

        public DateTime? DeletadoEm { get; set; }

        public bool? Deletado { get; set; } = false;

    }
}
