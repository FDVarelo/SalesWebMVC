using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;

namespace SalesWebMvc.Models
{
    public class Seller
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "{0} required.")] // Name is required
        [StringLength(50, MinimumLength = 3, ErrorMessage = "{0} size should be  between {2} and {1}.")] // Should have at least 3 characters to the maximum of 50 characters
        public string Name { get; set; }

        [DataType(DataType.EmailAddress)] // Has to be an email, example: (name@gmail.com) / Cannot be: (namegmail.com)
        [Required(ErrorMessage = "{0} required.")]
        [EmailAddress(ErrorMessage = "Enter a valid email.")]
        public string Email { get; set; }

        [Display(Name = "Birth Date")] // Change in the Display [BirthDate → Birth Date]
        [DataType(DataType.Date)] // Date type
        [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}")] // How the date is displayed
        [Required(ErrorMessage = "{0} required.")]
        public DateTime BirthDate { get; set; }

        [Display(Name = "Base Salary")] // Change in the Display
        [DisplayFormat(DataFormatString = "{0:F2}")]
        [Required(ErrorMessage = "{0} required.")]
        [Range(100.0, 50000.0, ErrorMessage = "{0} must be from {1} to {2}")] // Minimun and Maximum amount of the BaseSalary
        public double BaseSalary { get; set; }

        public Department Department { get; set; }

        [Display(Name = "Department Id")]
        public int DepartmentId { get; set; }

        public ICollection<SalesRecord> Sales { get; set; } = new List<SalesRecord>();

        public Seller() { }
        public Seller(int id, string name, string email, DateTime birthDate, double baseSalary, Department department)
        {
            Id = id;
            Name = name;
            Email = email;
            BirthDate = birthDate;
            BaseSalary = baseSalary;
            Department = department;
        }

        public void AddSales(SalesRecord sr)
        {
            Sales.Add(sr);
        }

        public void RemoveSales(SalesRecord sr)
        {
            Sales.Remove(sr);
        }

        public double TotalSales(DateTime initial, DateTime final)
        {
            return Sales.Where(sr => sr.Date >= initial && sr.Date <= final).Sum(sr => sr.Amount);
        }
    }
}
