using System.ComponentModel.DataAnnotations;

namespace sendMail.Models
{
    public class MailModel
    {
        public string From { get; set; }

        [Required(ErrorMessage = "Please insert mail to address")]
        public string To { get; set; }
        [Required(ErrorMessage = "Please insert the subject")]
        public string Subject { get; set; }
        public string Body { get; set; }
    }
}