using NorthwindCustomersAMM.Models;
using NorthwindCustomersAMM.Services;

namespace WinFormsApp1
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private async void btnCargarCustomers_Click(object sender, EventArgs e)
        {
            ServiceNorthwind service = new ServiceNorthwind();
            CustomersList list = await service.GetCustomerListAsync();
            foreach (Customer c in list.Customers)
            {
                this.lstCustomers.Items.Add(c.Name);
            }
        }
    }
}