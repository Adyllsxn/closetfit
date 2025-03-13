namespace ClosetFit.Application.DTOs.CategoriaDTO;
public sealed class CategoriaUpdateDTO : DtoBase
{
    [Required(ErrorMessage = "Nome é obrigatório.")]
    [StringLength(50, ErrorMessage = "Nome deve ser menor que 50.")]
    public string Nome { get; set; } = null!;
}
