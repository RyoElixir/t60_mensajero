﻿using MensajeroModel.DAL;
using MensajeroModel.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MensajeroApp
{
    class Program
    {
        static IMensajesDAL dal = MensajesDALFactory.CreateDAL();

        static void IngresarMensaje()
        {
            string nombre, detalle;
            do
            {
                Console.WriteLine("Ingrese Nombre");
                nombre = Console.ReadLine().Trim();
            } while (nombre == string.Empty);

            do
            {
                Console.WriteLine("Ingrese Mensaje");
                detalle = Console.ReadLine().Trim();
            } while (detalle == string.Empty);

            Mensaje m = new Mensaje()
            {
                Nombre = nombre,
                Detalle = detalle,
                Tipo = "Aplicacion"

            };
            dal.Save(m);

        }


        static void MostrarTodos()
        {
            List<Mensaje> lista = dal.GetAll();
            lista.ForEach(m =>
            {
                Console.WriteLine("N:{0}| D:{1} | T:{2}", m.Nombre, m.Detalle, m.Tipo);
            });
        }

        static bool Menu()
        {
            bool continuar = true;
            Console.WriteLine("Ingrese Opcion:");
            Console.WriteLine("1. Ingresar Mensaje");
            Console.WriteLine("2. Mostar Mensaje");
            Console.WriteLine("0. Salir");

            switch (Console.ReadLine().Trim())
            {
                case "1": IngresarMensaje();
                    break;
                case "2": MostrarTodos();
                    break;
                case "0": continuar = false;
                    break;
            }
            return continuar;
        }



        static void Main(string[] args)
        {
            while (Menu()) ;
        }
    }
}
