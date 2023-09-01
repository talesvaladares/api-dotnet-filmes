using System.ComponentModel.DataAnnotations;

namespace filmesApi.Models;

public class Filme
{
    [Key]
    [Required]
    public int Id { get; set; }

    [Required(ErrorMessage = "O título do filme é obrigtoório")]
    public string Titulo { get; set; }

    [MaxLength(50, ErrorMessage = "O tamanho do genênro não pode ser maior do que 50 caractres")]
    [Required(ErrorMessage = "O gênero do filme é obrigtoório")]
    public string Genero { get; set; }

    [Required(ErrorMessage = "A duração do filme é obrigtória")]
    [Range(70, 600, ErrorMessage = "A duração deve ser entre 70 e 600 minutos")]
    public int Duracao { get; set; }

}
