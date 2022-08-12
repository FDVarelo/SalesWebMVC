using System;
using System.ComponentModel.DataAnnotations;
using SalesWebMvc.Models.Enums;

namespace SalesWebMvc.Models
{
    public class SalesRecord
    {
        public int Id { get; set; }

        [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}")] // Format of the Date
        public DateTime Date { get; set; }

        [DisplayFormat(DataFormatString = "{0:F2}")] // Format of the Amount, example: (10.00)
        public double Amount { get; set; }

        public SaleStatus Status { get; set; }
        public Seller Seller { get; set; }

        public SalesRecord() { }
        public SalesRecord(int id, DateTime date, double amount, SaleStatus status, Seller seller)
        {
            Id = id;
            Date = date;
            Amount = amount;
            Status = status;
            Seller = seller;
        }
    }
}
