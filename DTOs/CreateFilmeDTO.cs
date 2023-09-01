using System.ComponentModel.DataAnnotations;

namespace filmesApi.DTO;

public class CreateFilmeDto { 


    [Required(ErrorMessage = "O título do filme é obrigtório")]
    public string Titulo { get; set; }

    [StringLength(50, ErrorMessage = "O tamanho do genênro não pode ser maior do que 50 caractres")]
    [Required(ErrorMessage = "O gênero do filme é obrigtoório")]
    public string Genero { get; set; }

    [Required(ErrorMessage = "A duração do filme é obrigtória")]
    [Range(70, 600, ErrorMessage = "A duração deve ser entre 70 e 600 minutos")]
    public int Duracao { get; set; }

}
