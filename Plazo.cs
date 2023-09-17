using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ultima_practica_final
{
    public abstract class Plazo
    {

        public Plazo(string pID, decimal pImporte, int pDias, int pTasa)
        {
            ID = pID;
            Importe = pImporte;
            Dias = pDias;
            Tasa = pTasa;

        }

        public string ID { get; set;  }

        public decimal Importe { get; set;  }

        public int Dias { get; set;  }

        public int Tasa { get; set;  }

        public abstract decimal Interes();

        public virtual event EventHandler EventoPlazoFijoEspecial; 

        Cliente clientePlazo = new Cliente();

        public void AsignarCliente(Cliente pCliente)
        {
            clientePlazo = pCliente;
        }

        public Cliente RetornarClientePlazo()
        {
            return clientePlazo;
        }
    }

    public class PlazoFijoComun : Plazo
    {
        public PlazoFijoComun(string pID, decimal pImporte, int pDias, int pTasa) : base(pID,pImporte,pDias,pTasa)
        {

        }

        public override decimal Interes()
        {
            return (Importe*Dias*Tasa)/36500;
        }



    }


    public class PlazoFijoEspecial : Plazo
    {
        public PlazoFijoEspecial(string pID, decimal pImporte, int pDias, int pTasa) : base(pID, pImporte, pDias, pTasa)
        {

        }

        public override event EventHandler EventoPlazoFijoEspecial;
        public override decimal Interes()
        {
            decimal interes = (Importe * (Tasa + 2)) / 100; if (interes >= 10000) EventoPlazoFijoEspecial?.Invoke(this, null);
            return interes;
        }

    }

}
