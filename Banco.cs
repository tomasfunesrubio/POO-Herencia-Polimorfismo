using Microsoft.VisualBasic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ultima_practica_final
{
    public class Banco
    {
        List<Cliente> ListaClientesGeneral;
        List<Plazo> ListaPlazosGeneral; 

        public Banco()
        {
            ListaClientesGeneral = new List<Cliente>();
            ListaPlazosGeneral = new List<Plazo>();
        }


        public void AgregarCliente(Cliente pCliente)
        {
            ListaClientesGeneral.Add(pCliente);
        }

        public void BorrarCLiente(Cliente pCliente)
        {
            ListaClientesGeneral.Remove(pCliente);
            foreach(var x in pCliente.RetornarListaPlazosCliente())
            {
                ListaPlazosGeneral.Remove(x);
            }

        }

        public void ModificarCliente(Cliente nuevoCliente)
        {
            nuevoCliente.Legajo = Interaction.InputBox("Ingresar legajo cliente: ");
            nuevoCliente.Nombre = Interaction.InputBox("Ingresar nombre cliente: ");
            nuevoCliente.Apellido = Interaction.InputBox("Ingresar apellido cliente: ");
            nuevoCliente.DNI = Interaction.InputBox("Ingresar DNI: ");

            foreach(var x in nuevoCliente.RetornarListaPlazosCliente())
            {
                x.AsignarCliente(nuevoCliente);
            }


        }


        public void AgregarPlazo(Plazo pPlazo)
        {
            ListaPlazosGeneral.Add(pPlazo);
        }

        public List<Cliente> RetornarListaCliente()
        {
            return ListaClientesGeneral;
        }

        public List<Plazo> RetornarListaPlazo()
        {
            return ListaPlazosGeneral;
        }
    }
}
