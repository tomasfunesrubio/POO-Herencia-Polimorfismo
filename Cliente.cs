using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ultima_practica_final
{
    public class Cliente
    {
        List<Plazo> ListaPlazosCliente = new List<Plazo>();
        public string Legajo { get; set;  }

        public string Nombre { get; set;  }

        public string Apellido { get; set;  }

        public string DNI { get; set;  }

        public void AgregarPlazo(Plazo pPlazo)
        {
            ListaPlazosCliente.Add(pPlazo);
        }

        public List<Plazo> RetornarListaPlazosCliente()
        {
            return ListaPlazosCliente;
        }

    }
}
