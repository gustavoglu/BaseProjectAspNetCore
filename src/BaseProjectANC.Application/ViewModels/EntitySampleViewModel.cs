using System;
using System.ComponentModel.DataAnnotations;

namespace BaseProjectANC.Application.ViewModels
{
    public class EntitySampleViewModel
    {
        public Guid Id { get; set; }

        [Required(ErrorMessage = "Obrigatório informar a descrição")]
        public string Descricao { get; set; }
    }
}
