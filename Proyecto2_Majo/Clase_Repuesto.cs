using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Proyecto2_Majo
{
    internal class Repuesto
    {
        private string codigo;

        public string Codigo
        {
            get { return codigo; }
            set
            {
                value.Trim();
                if (value != "")
                {
                    codigo = value;
                }
            }
        }
        private string nombre;

        public string Nombre
        {
            get { return nombre; }
            set 
            {
                if(value !="")
                {
                    nombre = value;
                }
            }
        }
        private string categoria;

        public string Categoria
        {
            get { return categoria; }
            set 
            {
                if(value!="")
                {
                    categoria= value;
                }
            }
        }
        private int stock;

        public int Stock
        {
            get { return stock; }
            set 
            {
                if(value>=0)
                {
                    stock = value;
                }
            }
        }
        private int stockMinimo;

        public int StockMinimo
        {
            get { return stockMinimo; }
            set 
            {
                if(value>0)
                {
                    stockMinimo= value;
                }
            }
        }
        private double costoUnitario;

        public double CostoUnitario
        {
            get { return costoUnitario; }
            set 
            {
                if(value>0)
                {
                    costoUnitario= value;
                }
            }
        }
        private double precioVenta;

        public double PrecioVenta
        {
            get { return precioVenta; }
            set 
            {
                if(value>CostoUnitario)
                {
                    precioVenta= value;
                }
            }
        }
        private int cantidadUsada;

        public int CantidadUsada
        {
            get { return cantidadUsada; }
            set 
            {
                if(value>0)
                {
                    cantidadUsada= value;
                }
            }
        }
        public Repuesto(string codigo, string nombre, string categoria, int stock, int minimo, double costo, double venta, int usados)
        {
            Codigo = codigo;
            Nombre= nombre;
            Categoria= categoria;
            Stock= stock;
            StockMinimo= minimo;
            CostoUnitario= costo;
            PrecioVenta= venta;
            CantidadUsada = usados;
        }
        public void MostrarInformacion()
        {
            Console.WriteLine("---------- INFORMACIÓN DEL REPUESTO ----------");
            Console.WriteLine($"Código: {Codigo}\nNombre: {Nombre}\nCategoría: {Categoria}\nStock actual: {Stock}\nStock mínimo: {StockMinimo}\nCosto unitario: {CostoUnitario}\nPrecio de venta: {PrecioVenta}\nCantidad utilizada: {CantidadUsada}");
        }
        public void ActualizarStock(int ingresos)
        {
            if(ingresos>0)
            {
                Stock += ingresos;
            }
        }
        public void UsarRepuesto(int usados)
        {
            Stock -= usados;
            CantidadUsada += usados;
        }
    }
}
