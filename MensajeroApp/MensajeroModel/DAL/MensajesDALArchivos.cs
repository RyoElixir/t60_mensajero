using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MensajeroModel.DTO;

namespace MensajeroModel.DAL
{
    public class MensajesDALArchivos : IMensajesDAL
        
    {
        private string archivo = Directory.GetCurrentDirectory()
        + Path.DirectorySeparatorChar + "mensaje.txt";

        private MensajesDALArchivos()
        {

        }

        private static IMensajesDAL instancia;

        public static IMensajesDAL GetInstance()
        {
            if (instancia == null)
                instancia = new MensajesDALArchivos();
            return instancia;
        }

        public List<Mensaje> GetAll()
        {
            List<Mensaje> mensaje = new List<Mensaje>();
            try
            {
                using(StreamReader reader = new StreamReader(archivo))
                {
                    string texto = null;
                    do
                    {
                        texto = reader.ReadLine();
                        if(texto != null)
                        {
                            //Procesamiento linea
                            string[] textoArray = texto.Trim().Split(';');
                            Mensaje m = new Mensaje()
                            {
                                Nombre = textoArray[0],
                                Detalle = textoArray[1],
                                Tipo = textoArray[2]
                            };


                            mensaje.Add(m);
                        }
                    } while (texto != null);
                }
            }catch(IOException ex)
            {
                mensaje = null;
            }
            return mensaje;
        }

        public void Save(Mensaje m)
        {
            try
            {
                using (StreamWriter writer = new StreamWriter(archivo, true))
                {
                    writer.WriteLine(m);
                    writer.Flush();
                }
            }catch(IOException ex)
            {

            }
        }
    }
}
