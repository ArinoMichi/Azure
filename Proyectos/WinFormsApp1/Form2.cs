using AereopuertosNugetAlexia.Models;
using AereopuertosNugetAlexia.Services;
using NorthwindCustomersAMM.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WinFormsApp1
{
    public partial class Form2 : Form
    {
        public Form2()
        {
            InitializeComponent();
        }

        private async void btnCargarAereopuertos_Click(object sender, EventArgs e)
        {
            ServicesAerolinea service = new ServicesAerolinea();
            AirportsList list = await service.GetAirports();
            foreach (Airport a in list.Airports)
            {
                this.lstAereopuertos.Items.Add(a.Name);
            }
        }
    }
}
