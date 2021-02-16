using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

//Librerias necesarias para la creacion de los ticket

using System.Drawing;
using System.Drawing.Printing;
using System.Runtime.InteropServices;

namespace CapaPresentacion
{
    class CrearTicket
    {
        //Crear objeto de la clase StringBuilder, este objeto agrega las lineas al ticket
        StringBuilder linea = new StringBuilder();
        //Variable para almacenar el maximo de caracteres que permite la impresora 
        int maxCar = 40, cortar;  //Impresora que imprime a 40 columnas, la variable cortar cortara el texto cuando rebase el limite

        //Mètodo para dibujar las lineas de la guia

        public string lineasGuia()
        {
            string lineasGuia = "";

            for (int i = 0; i < maxCar; i++)
            {
                lineasGuia += "-"; //Se agregan un guion hasta llegar al numero maximo de caracterese

            }

            return linea.AppendLine(lineasGuia).ToString(); //Devolvemos la linea con guiones
        }
        //Método para dibujar una linea con asteriscos
        public string lineasAsterico()
        {
            string lineasAsterisco = "";

            for (int i = 0; i < maxCar; i++)
            {
                lineasAsterisco += "*"; //Se agregan un guion hasta llegar al numero maximo de caracterese

            }
            return linea.AppendLine(lineasAsterisco).ToString(); //Devolvemos la linea con asterisco
        }
        //Método para dibujar linea con signo =
        public string lineasIgual()
        {
            string lineasIgual = "";

            for (int i = 0; i < maxCar; i++)
            {
                lineasIgual += "="; //Se agregan un guion hasta llegar al numero maximo de caracterese

            }
            return linea.AppendLine(lineasIgual).ToString(); //Devolvemos la linea con signo =
        }

        //Creación del encabezado para los artículos

        public void encabezadoVenta()
        {
            linea.AppendLine("ARTICULO        |CANT |PRECIO |DESCUENTO");
        }


        //Creación del encabezado para el cuadre de caja

        public void encabezadoCuadre()
        {
            linea.AppendLine("NO FAC        |EFECTIVO |DEVUELTA |TOTAL");
        }

        //Método para poner el texto a la izquierda

        public void textoIzquierda(string texto)
        {
            //Si la longitud del texto es mayor al número maximo, se ejecuta el procedimiento para cortar la palabra
            if (texto.Length > maxCar)
            {
                int caracterActual = 0; //Indica en que caracter se queda al bajar la linea

                for (int longitudTexto = texto.Length; longitudTexto > maxCar; longitudTexto -= maxCar)
                {
                    //Agregar el primer fragmento del texto
                    linea.AppendLine(texto.Substring(caracterActual, maxCar));
                    caracterActual += maxCar;
                }
                //Agregar el fragmento restante
                linea.AppendLine(texto.Substring(caracterActual, texto.Length - caracterActual));
            }
            else
            {
                //Si no es mayor solo se agrega
                linea.AppendLine(texto);
            }
        }

        //Método para poner el texto a la derecha
        public void textoDerecha(string texto)
        {
            //Si la longitud del texto es mayor al número maximo, se ejecuta el procedimiento para cortar la palabra
            if (texto.Length > maxCar)
            {
                int caracterActual = 0; //Indica en que caracter se queda al bajar la linea

                for (int longitudTexto = texto.Length; longitudTexto > maxCar; longitudTexto -= maxCar)
                {
                    //Agregar el primer fragmento del texto
                    linea.AppendLine(texto.Substring(caracterActual, maxCar));
                    caracterActual += maxCar;
                }
                //Variable para poner espacios restante
                string espacios = "";
                //Obtenemos la longitud del texto restante

                for (int i = 0; i < (maxCar - texto.Substring(caracterActual, texto.Length - caracterActual).Length); i++)
                {
                    espacios += " "; //Agregar espacios para alinear a la derecha

                }
                //Agregar el fragmento restante
                linea.AppendLine(espacios + texto.Substring(caracterActual, texto.Length - caracterActual));
            }
            else
            {
                string espacios = "";
                //Obtenemos la longitud del texto restante

                for (int i = 0; i < (maxCar - texto.Length); i++)
                {
                    espacios += " "; //Agregar espacios para alinear a la derecha

                }


                //Si no es mayor solo se agrega
                linea.AppendLine(espacios + texto);
            }
        }
        //Método para centrar el texto
        public void textoCentro(string texto)
        {
            //Si la longitud del texto es mayor al número maximo, se ejecuta el procedimiento para cortar la palabra
            if (texto.Length > maxCar)
            {
                int caracterActual = 0; //Indica en que caracter se queda al bajar la linea

                for (int longitudTexto = texto.Length; longitudTexto > maxCar; longitudTexto -= maxCar)
                {
                    //Agregar el primer fragmento del texto
                    linea.AppendLine(texto.Substring(caracterActual, maxCar));
                    caracterActual += maxCar;
                }
                //Variable para poner espacios restante
                string espacios = "";
                //Sacamos la cantidad de espacios libres y el resultado se divide entre dos
                int centrar = (maxCar - texto.Substring(caracterActual, texto.Length - caracterActual).Length) / 2;

                //Obtenemos la longitud del texto restante

                for (int i = 0; i < centrar; i++)
                {
                    espacios += " "; //Agregar espacios para centrar

                }
                //Agregar el fragmento restante
                linea.AppendLine(espacios + texto.Substring(caracterActual, texto.Length - caracterActual));
            }
            else
            {
                string espacios = "";
                //Sacamos la cantidad de espacios libres y el resultado se divide entre dos
                int centrar = (maxCar - texto.Length) / 2;

                //Obtenemos la longitud del texto restante

                for (int i = 0; i < centrar; i++)
                {
                    espacios += " "; //Agregar espacios para centrar

                }
                //Agregar el fragmento restante
                linea.AppendLine(espacios + texto);
            }
        }

        //Método para poner texto a los extremos
        public void textoExtremos(string textoIzquierdo, string textoDerecho)
        {
            //Varibales a utilizar
            string textoIzq, textoDer, textoCompleto = "", espacios = "";

            //Si el texto que va a la derecha es mayor a 18 cortamos el texto
            if (textoIzquierdo.Length > 18)
            {
                cortar = textoIzquierdo.Length - 18;
                textoIzq = textoIzquierdo.Remove(18, cortar);
            }
            else
            {
                textoIzq = textoIzquierdo;

                textoCompleto = textoIzq;
            }
            if (textoDerecho.Length > 20) //Si es mayor a 20 se corta
            {
                cortar = textoDerecho.Length - 20;
                textoDer = textoDerecho.Remove(20, cortar);
            }
            else
            {
                textoDer = textoDerecho;
            }

            int nroEspacios = maxCar - (textoIzq.Length + textoDer.Length);

            for (int i = 0; i < nroEspacios; i++)
            {
                espacios += " "; //Agrega los espacios para poner textoDerecho al final
            }
            textoCompleto += espacios + textoDerecho;

            linea.AppendLine(textoCompleto);

        }

        //Método para agregar los totales de la venta
        public void agregarTotales(string texto, decimal total)
        {
            //Variables que usaremos
            string resumen, valor, textoCompleto, espacios = "";

            if (texto.Length > 25)//Si es mayor a 25 lo cortamos
            {
                cortar = texto.Length - 25;
                resumen = texto.Remove(25, cortar);
            }
            else
            {
                resumen = texto;
            }
            textoCompleto = resumen;
            valor = total.ToString("#,#.00"); // Agregar el total previo al formateo

            //Obtenet el numero de espacios restantes para alinearlos a la derecha
            int nroEspacios = maxCar - (resumen.Length + valor.Length);
            //Agregamos los espacios

            for (int i = 0; i < nroEspacios; i++)
            {
                espacios += " ";
            }
            textoCompleto += espacios + valor;
            linea.AppendLine(textoCompleto);

        }

        //Método para agregar los articulos
        public void agregarArticulo(string articulo, int cant, decimal precio, decimal importe)
        {
            //Valida que cantidad, precio e importe estan dentro del rango
            if (cant.ToString().Length <= 5 && precio.ToString().Length <= 7 && importe.ToString().Length <= 8)
            {
                string elemento = "", espacios = "";
                bool bandera = false; //Indicara si es la primera linea que se escribe cuando bajemos a la segunda fila si el nombre del articulo es muy largo
                int nroEspacios = 0;
                //Si el nombre o descripcion del articulo es mayor a 20, bajar a la siguiente linea
                if (articulo.Length > 20)
                {
                    //Colocar la cantidad a la derecha
                    nroEspacios = (5 - cant.ToString().Length);
                    espacios = "";

                    for (int i = 0; i < nroEspacios; i++)
                    {
                        espacios += " "; // Generamos los espacios necesarios para alinear a la derecha
                    }
                    elemento += espacios + cant.ToString(); //Agregamos la cantidad con los espacios
                    //Colocar el precio a la derecha
                    nroEspacios = (7 - precio.ToString().Length);
                    espacios = "";
                    for (int i = 0; i < nroEspacios; i++)
                    {
                        espacios += " "; //Generamos los espacios necesarios para alinear a la izquierda
                    }
                    //El operador += indica que agregar mas cadenas a lo que ya existe

                    elemento += espacios + precio.ToString(); //Agregamos el precio a la variable del elemento
                    //Colocar el importe a la derecha
                    nroEspacios = (8 - importe.ToString().Length);
                    espacios = "";

                    for (int i = 0; i < nroEspacios; i++)
                    {
                        espacios += " ";
                    }
                    elemento += espacios + importe.ToString(); //Agregamos el import alineado a la derecha

                    int caracterActual = 0; //Indicara en que caracter se quedo al bajar a la siguiente linea

                    //Por cada 20 caracteres se agregara una linea siguiente
                    for (int longitudTexto = articulo.Length; longitudTexto > 20; longitudTexto -= 20)
                    {
                        if (bandera == false) //Si es false o la primera linea en recorrer, continuar...
                        {
                            //Agregamos los primeros 20 caracteres del nombre del articulo
                            linea.AppendLine(articulo.Substring(caracterActual, 20) + elemento);
                            bandera = true; //Cambiamos su valor a verdadero
                        }
                        else
                        {
                            linea.AppendLine(articulo.Substring(caracterActual, 20));//Solo agrega el nombre del articulo
                            caracterActual += 20; //Aumenta a 20 el valor de la variable caracterActual
                        }
                        //Agrega el resto del fragmento del nombre del articulo
                        linea.AppendLine(articulo.Substring(caracterActual, articulo.Length - caracterActual));

                    }
                }
                else //Si no es mayor solo agregarlo sin dar saltos de linea
                {
                    for (int i = 0; i < (20 - articulo.Length); i++)
                    {
                        espacios += " "; //Agrega espacios para alinear a la derecha
                    }
                    elemento = articulo + espacios;
                    //Colocar la cantidad a la derecha
                    nroEspacios = (5 - cant.ToString().Length); // +(20-elemento.Length);
                    espacios = "";
                    for (int i = 0; i < nroEspacios; i++)
                    {
                        espacios += " "; //Agrega espacios para completar los 20 caracteres
                    }
                    elemento += espacios + cant.ToString();
                    //Colocar el precio a la derecha
                    nroEspacios = (7 - precio.ToString().Length);
                    espacios = "";
                    for (int i = 0; i < nroEspacios; i++)
                    {
                        espacios += " ";
                    }
                    elemento += espacios + precio.ToString();

                    //Colocar el importe a la derecha
                    nroEspacios = (8 - importe.ToString().Length);
                    espacios = "";
                    for (int i = 0; i < nroEspacios; i++)
                    {
                        espacios += " ";
                    }
                    elemento += espacios + importe.ToString();
                    linea.AppendLine(elemento); //Agregamos todo el elemento : nombre del articulo, cant, precio,importe
                }

            }
            else
            {
                linea.AppendLine("Los valores ingresados para esta fila");
                linea.AppendLine("superan las columnas soportadas por este,");
                throw new Exception("Los valores ingreasados para algunas filas del ticket\nsuperan las columnas soportadas por este.");
            }
        }

        //Método para imprimir las ventas diaras
        //Método para agregar los articulos
        public void agregarVenta(string serie, decimal efectivo, decimal debito, decimal total)
        {
            //Valida que cantidad, precio e importe estan dentro del rango
         
                string elemento = "", espacios = "";
                bool bandera = false; //Indicara si es la primera linea que se escribe cuando bajemos a la segunda fila si el nombre del articulo es muy largo
                int nroEspacios = 0;
                //Si el nombre o descripcion del articulo es mayor a 20, bajar a la siguiente linea
                if (serie.Length > 20)
                {
                    //Colocar la cantidad a la derecha
                    nroEspacios = (5 - efectivo.ToString().Length);
                    espacios = "";

                    for (int i = 0; i < nroEspacios; i++)
                    {
                        espacios += " "; // Generamos los espacios necesarios para alinear a la derecha
                    }
                    elemento += espacios + efectivo.ToString(); //Agregamos la cantidad con los espacios
                    //Colocar el precio a la derecha
                    nroEspacios = (7 - debito.ToString().Length);
                    espacios = "";
                    for (int i = 0; i < nroEspacios; i++)
                    {
                        espacios += " "; //Generamos los espacios necesarios para alinear a la izquierda
                    }
                    //El operador += indica que agregar mas cadenas a lo que ya existe

                    elemento += espacios + debito.ToString(); //Agregamos el precio a la variable del elemento
                    //Colocar el importe a la derecha
                    nroEspacios = (8 - total.ToString().Length);
                    espacios = "";

                    for (int i = 0; i < nroEspacios; i++)
                    {
                        espacios += " ";
                    }
                    elemento += espacios + total.ToString(); //Agregamos el import alineado a la derecha

                    int caracterActual = 0; //Indicara en que caracter se quedo al bajar a la siguiente linea

                    //Por cada 20 caracteres se agregara una linea siguiente
                    for (int longitudTexto = serie.Length; longitudTexto > 20; longitudTexto -= 20)
                    {
                        if (bandera == false) //Si es false o la primera linea en recorrer, continuar...
                        {
                            //Agregamos los primeros 20 caracteres del nombre del articulo
                            linea.AppendLine(serie.Substring(caracterActual, 20) + elemento);
                            bandera = true; //Cambiamos su valor a verdadero
                        }
                        else
                        {
                            linea.AppendLine(serie.Substring(caracterActual, 20));//Solo agrega el nombre del articulo
                            caracterActual += 20; //Aumenta a 20 el valor de la variable caracterActual
                        }
                        //Agrega el resto del fragmento del nombre del articulo
                        linea.AppendLine(serie.Substring(caracterActual, serie.Length - caracterActual));

                    }
                }
                else //Si no es mayor solo agregarlo sin dar saltos de linea
                {
                    for (int i = 0; i < (20 - serie.Length); i++)
                    {
                        espacios += " "; //Agrega espacios para alinear a la derecha
                    }
                    elemento = serie + espacios;
                    //Colocar la cantidad a la derecha
                    nroEspacios = (5 - efectivo.ToString().Length); // +(20-elemento.Length);
                    espacios = "";
                    for (int i = 0; i < nroEspacios; i++)
                    {
                        espacios += " "; //Agrega espacios para completar los 20 caracteres
                    }
                    elemento += espacios + efectivo.ToString();
                    //Colocar el precio a la derecha
                    nroEspacios = (7 - debito.ToString().Length);
                    espacios = "";
                    for (int i = 0; i < nroEspacios; i++)
                    {
                        espacios += " ";
                    }
                    elemento += espacios + debito.ToString();

                    //Colocar el importe a la derecha
                    nroEspacios = (8 - total.ToString().Length);
                    espacios = "";
                    for (int i = 0; i < nroEspacios; i++)
                    {
                        espacios += " ";
                    }
                    elemento += espacios + total.ToString();
                    linea.AppendLine(elemento); //Agregamos todo el elemento : nombre del articulo, cant, precio,importe
                }

        }
        //Métodos para enviar secuencias de escape a la impresora
        //Para cortar el papel

        public void cortaTicket()
        {
            linea.AppendLine("\x1B" + "m"); //Caracteres de corte, estos comando varian segun el tipo de impresora
           // linea.AppendLine("\x1B" + "d" + "x01"); // Avanza 9 renglones, tambien varia
        }

        //Método para abrir el cajón del dinero

        public void abreCajon()
        {
            //Estos caracteres varian depende de la impresora
            linea.AppendLine("\x1B" + "p" + "\x00" + "\x0F" + "\x96"); //Caracteres de apertura cajon  0
            //linea.AppendLine("\x1B" + "p" + "\x01" + "\x0F" + "\x96"); //Caracteres de apertura cajon  1
        }

        //Imprimir el ticket

        public void imprimirTicket(string impresora)
        {
            //Este metodo recibe el nombre de la impresora a la cual se le mandara a imprimir



            RawPrinterHelper.SendStringToPrinter(impresora, linea.ToString()); //Imprime el texto
            linea.Clear(); //Al acabar limpia la linea de todo el texto agregado
        }

    }

    //Clase para mandar a imprimir texto plano a la impresora
    //Clase para mandara a imprimir texto plano a la impresora
    public class RawPrinterHelper
    {
        // Structure and API declarions:
        [StructLayout(LayoutKind.Sequential, CharSet = CharSet.Ansi)]
        public class DOCINFOA
        {
            [MarshalAs(UnmanagedType.LPStr)]
            public string pDocName;
            [MarshalAs(UnmanagedType.LPStr)]
            public string pOutputFile;
            [MarshalAs(UnmanagedType.LPStr)]
            public string pDataType;
        }
        [DllImport("winspool.Drv", EntryPoint = "OpenPrinterA", SetLastError = true, CharSet = CharSet.Ansi, ExactSpelling = true, CallingConvention = CallingConvention.StdCall)]
        public static extern bool OpenPrinter([MarshalAs(UnmanagedType.LPStr)] string szPrinter, out IntPtr hPrinter, IntPtr pd);

        [DllImport("winspool.Drv", EntryPoint = "ClosePrinter", SetLastError = true, ExactSpelling = true, CallingConvention = CallingConvention.StdCall)]
        public static extern bool ClosePrinter(IntPtr hPrinter);

        [DllImport("winspool.Drv", EntryPoint = "StartDocPrinterA", SetLastError = true, CharSet = CharSet.Ansi, ExactSpelling = true, CallingConvention = CallingConvention.StdCall)]
        public static extern bool StartDocPrinter(IntPtr hPrinter, Int32 level, [In, MarshalAs(UnmanagedType.LPStruct)] DOCINFOA di);

        [DllImport("winspool.Drv", EntryPoint = "EndDocPrinter", SetLastError = true, ExactSpelling = true, CallingConvention = CallingConvention.StdCall)]
        public static extern bool EndDocPrinter(IntPtr hPrinter);

        [DllImport("winspool.Drv", EntryPoint = "StartPagePrinter", SetLastError = true, ExactSpelling = true, CallingConvention = CallingConvention.StdCall)]
        public static extern bool StartPagePrinter(IntPtr hPrinter);

        [DllImport("winspool.Drv", EntryPoint = "EndPagePrinter", SetLastError = true, ExactSpelling = true, CallingConvention = CallingConvention.StdCall)]
        public static extern bool EndPagePrinter(IntPtr hPrinter);

        [DllImport("winspool.Drv", EntryPoint = "WritePrinter", SetLastError = true, ExactSpelling = true, CallingConvention = CallingConvention.StdCall)]
        public static extern bool WritePrinter(IntPtr hPrinter, IntPtr pBytes, Int32 dwCount, out Int32 dwWritten);

        // SendBytesToPrinter()
        // When the function is given a printer name and an unmanaged array
        // of bytes, the function sends those bytes to the print queue.
        // Returns true on success, false on failure.
        public static bool SendBytesToPrinter(string szPrinterName, IntPtr pBytes, Int32 dwCount)
        {
            Int32 dwError = 0, dwWritten = 0;
            IntPtr hPrinter = new IntPtr(0);
            DOCINFOA di = new DOCINFOA();
            bool bSuccess = false; // Assume failure unless you specifically succeed.

            di.pDocName = "Ticket de Venta";//Este es el nombre con el que guarda el archivo en caso de no imprimir a la impresora fisica.
            di.pDataType = "RAW";//de tipo texto plano

            // Open the printer.
            if (OpenPrinter(szPrinterName.Normalize(), out hPrinter, IntPtr.Zero))
            {
                // Start a document.
                if (StartDocPrinter(hPrinter, 1, di))
                {
                    // Start a page.
                    if (StartPagePrinter(hPrinter))
                    {
                        // Write your bytes.
                        bSuccess = WritePrinter(hPrinter, pBytes, dwCount, out dwWritten);
                        EndPagePrinter(hPrinter);
                    }
                    EndDocPrinter(hPrinter);
                }
                ClosePrinter(hPrinter);
            }
            // If you did not succeed, GetLastError may give more information
            // about why not.
            if (bSuccess == false)
            {
                dwError = Marshal.GetLastWin32Error();
            }
            return bSuccess;
        }

        public static bool SendStringToPrinter(string szPrinterName, string szString)
        {
            IntPtr pBytes;
            Int32 dwCount;
            // How many characters are in the string?
            dwCount = szString.Length;
            // Assume that the printer is expecting ANSI text, and then convert
            // the string to ANSI text.
            pBytes = Marshal.StringToCoTaskMemAnsi(szString);
            // Send the converted ANSI string to the printer.
            SendBytesToPrinter(szPrinterName, pBytes, dwCount);
            Marshal.FreeCoTaskMem(pBytes);
            return true;
        }
    }

}
