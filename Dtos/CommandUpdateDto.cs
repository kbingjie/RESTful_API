using System.ComponentModel.DataAnnotations;
// identical to create dto
namespace myCommander.Dtos
{
    public class CommandUpdateDto
    {
        // id is not need to be create by user, it is created by db
        // public int Id { get; set; }

        [Required]
        [MaxLength(250)]
        public string HowTo { get; set; }

        [Required]
        public string Line { get; set; }

        [Required]
        public string Platform { get; set; }

    }
}