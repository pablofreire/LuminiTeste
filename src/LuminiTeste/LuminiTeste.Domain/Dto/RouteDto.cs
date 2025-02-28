using System.ComponentModel.DataAnnotations;

namespace LuminiTeste.Domain.Dto
{
    public record RouteDto
    {
        [Required(ErrorMessage = "A origem é obrigatória.")]
        [StringLength(3, MinimumLength = 3, ErrorMessage = "A origem deve ter exatamente 3 caracteres.")]
        [RegularExpression("^[A-Z]+$", ErrorMessage = "A origem deve ser em letras maiúsculas.")]
        public string Origin { get; init; }

        [Required(ErrorMessage = "O destino é obrigatório.")]
        [StringLength(3, MinimumLength = 3, ErrorMessage = "O destino deve ter exatamente 3 caracteres.")]
        [RegularExpression("^[A-Z]+$", ErrorMessage = "O destino deve ser em letras maiúsculas.")]
        public string Destination { get; init; }

        [Required(ErrorMessage = "O custo é obrigatório.")]
        [Range(1, int.MaxValue, ErrorMessage = "O custo deve ser um número maior que zero.")]
        public int Cost { get; init; }

        public RouteDto(string origin, string destination, int cost)
        {
            Origin = origin;
            Destination = destination;
            Cost = cost;
        }
    }
}
