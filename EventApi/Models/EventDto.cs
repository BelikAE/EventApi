using System.ComponentModel.DataAnnotations;

namespace EventApi.Models
{
    public class EventDto
    {
        [Required(AllowEmptyStrings = false, ErrorMessage = "Наименование мероприятия обязателно для заполнения")]
        public string Title { get; set; }
        public string? Description { get; set; }

        [Required(ErrorMessage = "Дата окончания мероприятия обязательна для заполнения")]
        [Range(typeof(DateTime), "2020-01-01", "2030-12-31", ErrorMessage = "Некорректная дата")]
        public DateTime StartAt { get; set; }

        [Required(ErrorMessage = "Дата окончания мероприятия обязательна для заполнения")]
        [Range(typeof(DateTime), "2020-01-01", "2030-12-31", ErrorMessage = "Некорректная дата")]
        public DateTime EndAt { get; set; }
    }
}
