using JBLV.Log;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Xml;
using System.Xml.Serialization;

namespace Mantenimiento.Utility
{
   public class Functions
    {
        public static string MontoSolesALetras(string numero)
        {
            string Valor = string.Empty;

            // ********Declara variables de tipo cadena************
            string palabras = string.Empty, entero = string.Empty, dec = string.Empty, flag = string.Empty;

            // ********Declara variables de tipo entero***********
            int num, x, y;
            flag = "N";

            // **********Número Negativo***********
            if (numero.Substring(1, 1) == "-") { numero = numero.Substring(2, numero.ToString().Length - 1).ToString(); palabras = "menos "; }

            // **********Si tiene ceros a la izquierda*************
            for (x = 0; x <= numero.ToString().Length - 1; x++) { if (numero.Substring(0, 1) == "0") { numero = numero.Substring(2, numero.ToString().Length - 1).ToString().Trim(); if (numero.ToString().Trim().Length == 0) { palabras = string.Empty; } } else { break; } }

            // *********Dividir parte entera y decimal************
            for (y = 0; y <= numero.Length - 1; y++) { if (numero.Substring(y, 1) == ".") { flag = "S"; } else if (flag == "N") { entero = entero + numero.Substring(y, 1); } else { dec = dec + numero.Substring(y, 1); } }
            if (dec.Length == 1) { dec = dec + "0"; }

            // **********proceso de conversión***********
            flag = "N";

            if (decimal.Parse(numero) <= 999999999)
            {
                for (y = entero.Length; y >= 1; y += -1)
                {
                    num = (entero.Length) - (y - 1);
                    switch (y)
                    {
                        case 3:
                        case 6:
                        case 9:
                            {
                                // **********Asigna las palabras para las centenas***********
                                switch (entero.Substring(num - 1, 1))
                                {
                                    case "1": { if (entero.Substring((num - 1) + 1, 1) == "0" & entero.Substring((num - 1) + 2, 1) == "0") { palabras = palabras + "cien "; } else { palabras = palabras + "ciento "; } break; }
                                    case "2": { palabras = palabras + "doscientos "; break; }
                                    case "3": { palabras = palabras + "trescientos "; break; }
                                    case "4": { palabras = palabras + "cuatrocientos "; break; }
                                    case "5": { palabras = palabras + "quinientos "; break; }
                                    case "6": { palabras = palabras + "seiscientos "; break; }
                                    case "7": { palabras = palabras + "setecientos "; break; }
                                    case "8": { palabras = palabras + "ochocientos "; break; }
                                    case "9": { palabras = palabras + "novecientos "; break; }
                                }
                                break;
                            }
                        case 2:
                        case 5:
                        case 8:
                            {
                                // *********Asigna las palabras para las decenas************
                                switch (entero.Substring(num - 1, 1))
                                {
                                    case "1":
                                        {
                                            if (entero.Substring(num, 1) == "0") { flag = "S"; palabras = palabras + "diez "; }
                                            if (entero.Substring(num, 1) == "1") { flag = "S"; palabras = palabras + "once "; }
                                            if (entero.Substring(num, 1) == "2") { flag = "S"; palabras = palabras + "doce "; }
                                            if (entero.Substring(num, 1) == "3") { flag = "S"; palabras = palabras + "trece "; }
                                            if (entero.Substring(num, 1) == "4") { flag = "S"; palabras = palabras + "catorce "; }
                                            if (entero.Substring(num, 1) == "5") { flag = "S"; palabras = palabras + "quince "; }
                                            if (int.Parse(entero.Substring(num, 1)) > 5) { flag = "N"; palabras = palabras + "dieci"; }
                                            break;
                                        }

                                    case "2": { if (entero.Substring(num, 1) == "0") { palabras = palabras + "veinte "; flag = "S"; } else { palabras = palabras + "veinti"; flag = "N"; } break; }
                                    case "3": { if (entero.Substring((num - 1) + 1, 1) == "0") { palabras = palabras + "treinta "; flag = "S"; } else { palabras = palabras + "treinta y "; flag = "N"; } break; }
                                    case "4": { if (entero.Substring(num, 1) == "0") { palabras = palabras + "cuarenta "; flag = "S"; } else { palabras = palabras + "cuarenta y "; flag = "N"; } break; }
                                    case "5": { if (entero.Substring(num, 1) == "0") { palabras = palabras + "cincuenta "; flag = "S"; } else { palabras = palabras + "cincuenta y "; flag = "N"; } break; }
                                    case "6": { if (entero.Substring(num, 1) == "0") { palabras = palabras + "sesenta "; flag = "S"; } else { palabras = palabras + "sesenta y "; flag = "N"; } break; }
                                    case "7": { if (entero.Substring(num, 1) == "0") { palabras = palabras + "setenta "; flag = "S"; } else { palabras = palabras + "setenta y "; flag = "N"; } break; }
                                    case "8": { if (entero.Substring(num, 1) == "0") { palabras = palabras + "ochenta "; flag = "S"; } else { palabras = palabras + "ochenta y "; flag = "N"; } break; }
                                    case "9": { if (entero.Substring(num, 1) == "0") { palabras = palabras + "noventa "; flag = "S"; } else { palabras = palabras + "noventa y "; flag = "N"; } break; }
                                }
                                break;
                            }
                        case 1:
                        case 4:
                        case 7:
                            {
                                // *********Asigna las palabras para las unidades*********
                                switch (entero.Substring(num - 1, 1))
                                {
                                    case "1": { if (flag == "N") { if (y == 1) { palabras = palabras + "uno "; } else { palabras = palabras + "un "; } } break; }
                                    case "2": { if (flag == "N") { palabras = palabras + "dos "; } break; }
                                    case "3": { if (flag == "N") { palabras = palabras + "tres "; } break; }
                                    case "4": { if (flag == "N") { palabras = palabras + "cuatro "; } break; }
                                    case "5": { if (flag == "N") { palabras = palabras + "cinco "; } break; }
                                    case "6": { if (flag == "N") { palabras = palabras + "seis "; } break; }
                                    case "7": { if (flag == "N") { palabras = palabras + "siete "; } break; }
                                    case "8": { if (flag == "N") { palabras = palabras + "ocho "; } break; }
                                    case "9": { if (flag == "N") { palabras = palabras + "nueve "; } break; }
                                }
                                break;
                            }
                    }

                    // ***********Asigna la palabra mil***************
                    if (y == 4) { if (entero.Substring(6, 1) != "0" | entero.Substring(5, 1) != "0" | entero.Substring(4, 1) != "0" | (entero.Substring(6, 1) == "0" & entero.Substring(5, 1) == "0" & entero.Substring(4, 1) == "0" & entero.Length <= 6)) { palabras = palabras + "mil "; } }

                    // **********Asigna la palabra millón*************
                    if (y == 7) { if (entero.Length == 7 & entero.Substring(0, 1) == "1") palabras = palabras + "millón "; else { palabras = palabras + "millones "; } }
                }

                // **********Une la parte entera y la parte decimal*************
                if (dec != string.Empty && int.Parse(dec) > 0) { Valor = palabras + System.Convert.ToString(System.Convert.ToInt32(dec)) + "/100 soles"; } else { Valor = palabras + "00/100 soles"; }
            }
            else { Valor = string.Empty; }
            return Valor.ToUpper();
        }
        public static string ConvertListToXml<T>(T lista, string nombreXmlRoot)
        {
            string cadenaXml = string.Empty;

            Encoding utf8noBOM = new UTF8Encoding(false);
            XmlWriterSettings settings = new XmlWriterSettings
            {
                Indent = true,
                Encoding = utf8noBOM
            };
            XmlSerializer ser = new XmlSerializer(typeof(T), new XmlRootAttribute(nombreXmlRoot));
            StringBuilder sb = new StringBuilder();
            using (XmlWriter xml = XmlWriter.Create(sb, settings))
            {
                ser.Serialize(xml, lista);
            };
            cadenaXml = sb.ToString();

            return cadenaXml;
        }
        public static string ObtenerColorHexadecimal(string _Color)
        {
            string colorHexadecimal = string.Empty;

            var auxColor = long.Parse(_Color);
            int b = (int)(auxColor / 65536);
            int g = (int)((auxColor - b * 65536) / 256);
            int r = (int)(auxColor - b * 65536 - g * 256);

            Color colorRGB = Color.FromArgb(r, g, b);
            colorHexadecimal = "#" + colorRGB.R.ToString("X2") + colorRGB.G.ToString("X2") + colorRGB.B.ToString("X2");

            return colorHexadecimal;
        }
        public string GenerarXML(string[] array, bool cabecera)
        {
            string retorna;
            MemoryStream memory_stream = new MemoryStream();
            XmlTextWriter xml_text_writer = new XmlTextWriter(memory_stream, System.Text.Encoding.UTF8);

            xml_text_writer.Formatting = Formatting.Indented;
            xml_text_writer.Indentation = 4;
            GeneraCabecera(xml_text_writer, cabecera, 'A');
            xml_text_writer.WriteStartElement("string-array");

            for (int i = 0; i < array.Length; i++)
            {
                if (array[i] == null)
                    xml_text_writer.WriteElementString("null", "");
                else
                    xml_text_writer.WriteElementString("string", array[i]);
            }

            xml_text_writer.WriteEndElement();
            GeneraCabecera(xml_text_writer, cabecera, 'C');
            xml_text_writer.Flush();

            // Declaramos un StreamReader para mostrar el resultado.
            StreamReader stream_reader = new StreamReader(memory_stream);

            memory_stream.Seek(0, SeekOrigin.Begin);
            retorna = stream_reader.ReadToEnd();
            xml_text_writer.Close();
            stream_reader.Close();
            stream_reader.Dispose();

            return retorna;
        }
        private void GeneraCabecera(XmlTextWriter xmlTextWriter, bool genera, char estado)
        {
            if (genera)
            {
                switch (estado)
                {
                    case 'A': xmlTextWriter.WriteStartDocument(); break;
                    case 'C': xmlTextWriter.WriteEndDocument(); break;
                    default: break;
                }
            }
        }
        public static string BytesToString(byte[] byt)
        {
            return Encoding.Default.GetString(byt);
        }
        public static string ObjectToXML(Object obj)
        {
            XmlSerializer xs = new XmlSerializer(obj.GetType());
            string xml = string.Empty;
            using (MemoryStream ms = new MemoryStream())
            {
                xs.Serialize(ms, obj);
                using (StreamReader sr = new StreamReader(ms))
                {
                    ms.Seek(0, SeekOrigin.Begin);
                    xml = sr.ReadToEnd();
                }
            }
            return xml;
        }
        public static string StringToSlug(string str)
        {
            str = str.Normalize(System.Text.NormalizationForm.FormD);
            str = new Regex(@"[^a-zA-Z0-9 ]").Replace(str, "").Trim();
            str = new Regex(@"[\/_| -]+").Replace(str, " ");
            return str;
        }
        public static string RemoveDiacritics(string stIn)
        {
            string stFormD = stIn.Normalize(NormalizationForm.FormD);
            StringBuilder sb = new StringBuilder();
            for (int ich = 0; ich <= stFormD.Length - 1; ich++)
            {
                UnicodeCategory uc = CharUnicodeInfo.GetUnicodeCategory(stFormD[ich]);
                if (uc != UnicodeCategory.NonSpacingMark || stFormD[ich].ToString() == "̃")
                {
                    sb.Append(stFormD[ich]);
                }
            }

            return (sb.ToString().Normalize(NormalizationForm.FormC));
        }
        public static string MessageError(Exception ex)
        {
            Log.RegistrarLog(NivelLog.Error, ex);
            return ex.Message;
        }
        public class Check
        {
            private static DateTime fechaValidar;

            public static short Int16(object entero)
            {
                if (entero == null || entero == DBNull.Value)
                {
                    return 0;
                }
                else
                {
                    return Convert.ToInt16(entero);
                }
            }

            public static short? Int16Null(object entero)
            {
                if (entero == null || entero == DBNull.Value)
                {
                    return null;
                }
                else
                {
                    return Convert.ToInt16(entero);
                }
            }

            public static int Int32(object entero)
            {
                if (entero == null || entero == DBNull.Value)
                {
                    return 0;
                }
                else
                {
                    if (entero.ToString() == "")
                    {
                        return 0;
                    }
                    else
                    {
                        return Convert.ToInt32(entero);
                    }
                }
            }

            public static int? Int32Null(object entero)
            {
                if (entero == null || entero == DBNull.Value)
                {
                    return null;
                }
                else
                {
                    return Convert.ToInt32(entero);
                }
            }

            public static string FechaCorta(object fecha)
            {
                string resultado;

                if (fecha == null || fecha == DBNull.Value)
                {
                    resultado = "";
                }
                else
                {
                    if (!DateTime.TryParse(fecha.ToString(), out fechaValidar))
                    {
                        resultado = "";
                    }
                    else
                    {
                        resultado = Convert.ToDateTime(fecha).ToString("dd/MM/yyyy");
                    }
                }
                return resultado;
            }

            public static string FechaLarga(object fecha, int horasSumar = 0)
            {
                string resultado;

                if (fecha == null || fecha == DBNull.Value)
                {
                    resultado = "";
                }
                else
                {
                    if (!DateTime.TryParse(fecha.ToString(), out fechaValidar))
                    {
                        resultado = "";
                    }
                    else
                    {
                        resultado = Convert.ToDateTime(fecha).AddHours(horasSumar).ToString("dd/MM/yyyy HH:mm:ss");
                    }
                }
                return resultado;
            }

            public static string Cadena(object cadena)
            {
                string resultado;

                resultado = (cadena == null) ? "" : cadena.ToString();

                return resultado;
            }

            public static DateTime? Datetime(object fecha)
            {
                DateTime? resultado;

                if (fecha == null || fecha == DBNull.Value)
                {
                    resultado = null;
                }
                else
                {
                    resultado = Convert.ToDateTime(fecha);
                }

                return resultado;
            }

            public static decimal Decimal(object numero)
            {
                if (numero == null || numero == DBNull.Value)
                {
                    return 0;
                }
                else
                {
                    return Convert.ToDecimal(numero);
                }
            }

            public static bool Bool(object valor)
            {
                if (valor == null || valor == DBNull.Value)
                {
                    return false;
                }
                else
                {
                    if (valor.ToString() == "" || valor.ToString() == "0")
                    {
                        return false;
                    }
                    else
                    {
                        return true;
                    }
                }
            }
        }

        public class GenericoListaDto
        {
            public string Codigo { get; set; }
            public string Descripcion { get; set; }
        }

        public class ColumnsTable
        {
            public int id { get; set; }
            public int IdTarea { get; set; }
            public string Tarea_Descripcion { get; set; }
            public int ID_tb_Sistema_Mant { get; set; }
            public string Sistema_Descripcion { get; set; }
            public int Activo { get; set; }
            public string Operacion { get; set; }
        }

        public class ColumnsTableUnion
        {
            public int id { get; set; }
            public int IdTarea1 { get; set; }
            public string Tarea_Descripcion1 { get; set; }
            public string Sistema_Descripcion1 { get; set; }
            public int IdTarea2 { get; set; }
            public string Tarea_Descripcion2 { get; set; }
            public string Sistema_Descripcion2 { get; set; }
        }

        public static string NombreMes(int numeroMes)
        {
            try
            {
                return ListaMeses().Single(x => x.Codigo == numeroMes.ToString()).Descripcion;
            }
            catch (Exception)
            {
                throw new Exception("Mes no encontrado");
            }
        }

        public static string ValidarDatetime(string datetime)
        {
            return datetime.Replace(".", "");
        }

        public static List<GenericoListaDto> ListaMeses()
        {
            List<GenericoListaDto> listaMeses = new List<GenericoListaDto>
            {
                new GenericoListaDto { Codigo = "1", Descripcion = "ENERO" },
                new GenericoListaDto { Codigo = "2", Descripcion = "FEBRERO" },
                new GenericoListaDto { Codigo = "3", Descripcion = "MARZO" },
                new GenericoListaDto { Codigo = "4", Descripcion = "ABRIL" },
                new GenericoListaDto { Codigo = "5", Descripcion = "MAYO" },
                new GenericoListaDto { Codigo = "6", Descripcion = "JUNIO" },
                new GenericoListaDto { Codigo = "7", Descripcion = "JULIO" },
                new GenericoListaDto { Codigo = "8", Descripcion = "AGOSTO" },
                new GenericoListaDto { Codigo = "9", Descripcion = "SETIEMBRE" },
                new GenericoListaDto { Codigo = "10", Descripcion = "OCTUBRE" },
                new GenericoListaDto { Codigo = "11", Descripcion = "NOVIEMBRE" },
                new GenericoListaDto { Codigo = "12", Descripcion = "DICIEMBRE" }
            };

            return listaMeses;
        }

        public static string RetornaNumeroRomano(int numero)
        {
            string numeroRomano = string.Empty;
            int Miles, Resto, Cen, Dec, Uni, N;

            N = numero;
            Miles = N / 1000;
            Resto = N % 1000;
            Cen = Resto / 100;
            Resto = Resto % 100;
            Dec = Resto / 10;
            Resto = Resto % 10;
            Uni = Resto;

            switch (Miles)
            {
                case 1: numeroRomano = "M"; break;
                case 2: numeroRomano = "MM"; break;
                case 3: numeroRomano = "MMM"; break;
            }
            switch (Cen)
            {
                case 1: numeroRomano = "C"; break;
                case 2: numeroRomano = "CC"; break;
                case 3: numeroRomano = "CCC"; break;
                case 4: numeroRomano = "CD"; break;
                case 5: numeroRomano = "D"; break;
                case 6: numeroRomano = "DC"; break;
                case 7: numeroRomano = "DCC"; break;
                case 8: numeroRomano = "DCCC"; break;
                case 9: numeroRomano = "CM"; break;
            }
            switch (Dec)
            {
                case 1:
                    numeroRomano = "X";
                    break;
                case 2:
                    numeroRomano = "XX";
                    break;
                case 3:
                    numeroRomano = "XXX";
                    break;
                case 4:
                    numeroRomano = "XL";
                    break;
                case 5:
                    numeroRomano = "L";
                    break;
                case 6:
                    numeroRomano = "LX";
                    break;
                case 7:
                    numeroRomano = "LXX";
                    break;
                case 8:
                    numeroRomano = "LXXX";
                    break;
                case 9:
                    numeroRomano = "XC";
                    break;
            }
            switch (Uni)
            {
                case 1: numeroRomano = "I"; break;
                case 2: numeroRomano = "II"; break;
                case 3: numeroRomano = "III"; break;
                case 4: numeroRomano = "IV"; break;
                case 5: numeroRomano = "V"; break;
                case 6: numeroRomano = "VI"; break;
                case 7: numeroRomano = "VII"; break;
                case 8: numeroRomano = "VIII"; break;
                case 9: numeroRomano = "IX"; break;
            }


            return numeroRomano;
        }
    }
}
