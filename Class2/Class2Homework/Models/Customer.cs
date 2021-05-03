using System;
using System.Collections.Generic;

namespace Models
{
    public class Customer : User
    {
        public double Balance { get; private set; }
        public List<Invoice> Invoices { get; set; }

        public Customer(string username, string password, double balance, List<Invoice> invoices) : base (username, password, RoleEnum.Customer)
        {
            if(balance < 0)
            {
                throw new Exception("Your balance can't have negative value!");
            }
            Balance = balance;
            Invoices = invoices;
        }

        public string DepositMoney(int money)
        {
            if(money < 1)
            {
                return "You can't deposit less than $1.";
            }

            Balance += money;

            return $"You have deposited ${money}. Your current balance is ${Balance}";
        }

        public string PayInvoice(Invoice invoice)
        {
            string result = "You don't have enough money to pay this invoice!";

            if (invoice.IsInvoicePaid())
            {
                result = $"This invoice is already paid.";
            }
            else if(invoice.PayInvoice(Balance))
            {
                Balance -= invoice.Amount;
                result = $"Transaction successfull! ${invoice.Amount} were taken from your balance.";
            }

            return result;
        }

        public string OverviewInvoices()
        {
            string result = "";

            for (int i = 0; i < Invoices.Count; i++)
            {
                result += $"{i + 1}. Company: {Invoices[i].Company}   |   Status: {Invoices[i].InvoiceStatus}   |   DueTo: {Invoices[i].DueDate}   |   Amount: {Invoices[i].Amount}   |   Penalty: {Invoices[i].Penalty()}\n";
            }

            return result;
        }
    }
}
