using System;
namespace Models
{
    public class Invoice
    {
        public string Company { get; set; } 
        public InvoiceStatusEnum InvoiceStatus { get; private set; } 
        public double Amount { get; private set; }
        public DateTime DueDate { get; private set; }
        public DateTime DateIssued { get; private set; }

        public Invoice(string company, double amount, DateTime dueDate, DateTime dateIssued)
        {
            if(amount < 1)
            {
                throw new Exception("The invoice must be over $1.");
            }
            Company = company;
            Amount = amount;
            DueDate = dueDate;
            DateIssued = dateIssued;
            InvoiceStatus = InvoiceStatusEnum.Unpaid;
        }

        public bool IsInvoicePaid()
        {
            return InvoiceStatus == InvoiceStatusEnum.Paid;
        }

        public bool PayInvoice(double money)
        {
            if(DateTime.Now > DueDate)
            {
                int days = (int)Math.Floor((DateTime.Now - DueDate).TotalDays);
                Amount += (days * 10);
            }

            if (money > Amount)
            {
                InvoiceStatus = InvoiceStatusEnum.Paid;
            }

            return money > Amount;
        }

        public int Penalty ()
        {
            int penalty = 0;

            int days = (int)Math.Floor((DateTime.Now - DueDate).TotalDays);

            if(days < 0)
            {
                return penalty;
            }

            penalty += (days * 10);

            return penalty;
        }
    }
}
