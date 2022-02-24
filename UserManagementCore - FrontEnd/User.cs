using System.ComponentModel.DataAnnotations;

namespace UserManagementCore___BackEnd
{
    public class User
    {
        [Key]
        public string Name { get; set; }
        public string Email { get; set; }
        public string Address { get; set; }
    }
}
