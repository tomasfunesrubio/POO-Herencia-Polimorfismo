using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Microsoft.VisualBasic;

namespace Ultima_practica_final
{
    public partial class Form1 : Form
    {
        Banco banco1 = new Banco();
        public Form1()
        {
            InitializeComponent();
        }

        public void MensajeEvento(object sender, EventArgs e)
        {
            MessageBox.Show("El interes supera o es igual a 10000 pesos");
        }


        private void button1_Click(object sender, EventArgs e)
        {
            Cliente nuevoCliente = new Cliente();
            nuevoCliente.Legajo = Interaction.InputBox("Ingresar legajo cliente: ");
            nuevoCliente.Nombre = Interaction.InputBox("Ingresar nombre cliente: ");
            nuevoCliente.Apellido = Interaction.InputBox("Ingresar apellido cliente: ");
            nuevoCliente.DNI = Interaction.InputBox("Ingresar DNI: ");

            banco1.AgregarCliente(nuevoCliente);
            dataGridView1.DataSource = null;
            dataGridView1.DataSource = banco1.RetornarListaCliente();

        }

        private void button2_Click(object sender, EventArgs e)
        {
            string ID = Interaction.InputBox("Ingrese el ID: ");
            decimal Importe = decimal.Parse(Interaction.InputBox("Ingrese el importe: "));
            int dias = int.Parse(Interaction.InputBox("Ingrese los dias: "));
            int tasa = int.Parse(Interaction.InputBox("Ingrese la tasa: "));

            Plazo nuevoPlazo;
            Cliente auxCliente = dataGridView1.SelectedRows[0].DataBoundItem as Cliente;

            if(radioButton1.Checked)
            {
                nuevoPlazo = new PlazoFijoComun(ID, Importe, dias, tasa);
            }
            else
            {
                nuevoPlazo = new PlazoFijoEspecial(ID, Importe, dias, tasa);
            }

            auxCliente.AgregarPlazo(nuevoPlazo);
            nuevoPlazo.AsignarCliente(auxCliente);
            banco1.AgregarPlazo(nuevoPlazo);

            dataGridView2.DataSource = null;
            dataGridView2.DataSource = banco1.RetornarListaPlazo();

            dataGridView3.DataSource = null;
            dataGridView3.DataSource = auxCliente.RetornarListaPlazosCliente();


        }

        private void dataGridView1_CellMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            if(dataGridView1.Rows.Count > 0)
            {
                Cliente auxCliente = dataGridView1.SelectedRows[0].DataBoundItem as Cliente;

                dataGridView3.DataSource = null;
                dataGridView3.DataSource = auxCliente.RetornarListaPlazosCliente();
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Plazo auxPlazo = dataGridView3.SelectedRows[0].DataBoundItem as Plazo;

            auxPlazo.EventoPlazoFijoEspecial += MensajeEvento;
            decimal Interes = auxPlazo.Interes();
            auxPlazo.EventoPlazoFijoEspecial -= MensajeEvento;

           
            var consulta = (from p in banco1.RetornarListaPlazo()
                            where p.ID == auxPlazo.ID
                            select new { DNI = p.RetornarClientePlazo().DNI, Importe = p.Importe, Interes = Interes, Importe_Total = p.Importe + Interes }).ToArray();


            dataGridView4.DataSource = null;
            dataGridView4.DataSource = consulta;

        }

        private void button4_Click(object sender, EventArgs e)
        {
            if(dataGridView1.Rows.Count > 0)
            {
                Cliente auxCliente = dataGridView1.SelectedRows[0].DataBoundItem as Cliente;
                banco1.BorrarCLiente(auxCliente);

                dataGridView1.DataSource = null;
                dataGridView1.DataSource = banco1.RetornarListaCliente();

                dataGridView2.DataSource = null;
                dataGridView2.DataSource = banco1.RetornarListaPlazo();

                dataGridView3.DataSource = null; 
            }
        }

        private void button5_Click(object sender, EventArgs e)
        {
            if(dataGridView1.Rows.Count >0)
            {
                Cliente pCliente = dataGridView1.SelectedRows[0].DataBoundItem as Cliente;
                banco1.ModificarCliente(pCliente);

                dataGridView1.DataSource = null;
                dataGridView1.DataSource = banco1.RetornarListaCliente(); 
            }
        }
    }
}
