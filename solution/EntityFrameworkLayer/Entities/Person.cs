using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace EntityFrameworkLayer.Entities
{
    [Table("Person")]
    public class Person
    {
        [Key]
        [Description("Identifiant technique")]
        public int PersonId { get; set; }

        [Description("Prénom")]
        [MaxLength(55)]
        public string FirstName { get; set; }

        [Description("Nom")]
        public string LastName { get; set; }

        [Description("Email")]
        [EmailAddress, Required]
        public string Email { get; set; }
    }
}
