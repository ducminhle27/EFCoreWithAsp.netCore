using System.ComponentModel.DataAnnotations.Schema;

namespace EFCoreWithAsp.netCore.Models
{
    public class Teacher
    {
        public int TeacherId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public DateTime DateOfBirth { get; set; }
        public string Gender { get; set; }
        public string Email { get; set; }
        public string PhoneNumber { get; set; }
        public string Address { get; set; }
        public bool IsActive { get; set; }
        public int Salary { get; set; }

        //Relationship with Department

        [ForeignKey("Department")]
        public int DepartmentId { get; set; } //Foreign Key
        public Department? Department { get; set; } //Reference navigation property

    }
}