using System.Collections.Generic;

namespace Models
{
    public class Administrator : User
    {
        public string Company { get; private set; }

        public Administrator(string username, string password, string company) : base(username, password, RoleEnum.Administrator)
        {
            Company = company;
        }

        public string GetCompanyInvoices(List<Invoice> invoices)
        {

            string result = "";
            for(int i = 0; i < invoices.Count; i++)
            {
                if(invoices[i].Company == Company)
                {
                    result += $"{i + 1}. Company: {invoices[i].Company}   |   Status: {invoices[i].InvoiceStatus}\n";
                }
            }

            return result;
        }
    }
}
