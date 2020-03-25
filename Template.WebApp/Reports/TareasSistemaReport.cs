using iTextSharp.text;
using iTextSharp.text.pdf;
using Mantenimiento.Utility;
using Mantenimiento.WebApp.ServiceMantenimiento;
using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Web;
using static Mantenimiento.Utility.Functions;

namespace Mantenimiento.WebApp.Reports
{
    public class TareasSistemaReport
    {
        #region Declaraciones
        int _totalColumn = 8;
        Document _document;
        Font _fontstyle;
        PdfPTable _pdfTable = new PdfPTable(8);
        PdfPCell _pdfPCell;
        MemoryStream _memorystream = new MemoryStream();


        List<AreEntity> ListAreBus = new List<AreEntity>();
        List<TareaSistemaEntity> ListTareaSistemaEntity = new List<TareaSistemaEntity>();
        #endregion

        public byte[] PrepareReport(List<AreEntity> listAreBus, List<TareaSistemaEntity> listTareaSistemaEntity)
        {
            ListAreBus = listAreBus;
            ListTareaSistemaEntity = listTareaSistemaEntity;

            _document = new Document(PageSize.A4, 0f, 0f, 0f, 0f);
            _document.SetPageSize(PageSize.A4);
            _document.SetMargins(20f, 20f, 20f, 20f);
            _pdfTable.WidthPercentage = 100;
            _pdfTable.HorizontalAlignment = Element.ALIGN_LEFT;
            _fontstyle = FontFactory.GetFont("Tahoma", 8f, 1);

            PdfWriter.GetInstance(_document, _memorystream);
            _document.Open();
            _pdfTable.SetWidths(new float[] { 20f, 20f, 20f, 20f, 20f, 20f, 20f, 20f });


            this.ReportHeader();
            this.ReportBody();


            _pdfTable.HeaderRows = 4;

            _document.Add(_pdfTable);

            _document.Close();

            return _memorystream.ToArray();
        }

        private void ReportHeader()
        {
            _fontstyle = FontFactory.GetFont("Tahoma", 9f, 1);
            _pdfPCell = new PdfPCell(new Phrase(""));
            _pdfPCell.Colspan = 1;
            _pdfPCell.HorizontalAlignment = Element.ALIGN_LEFT;
            _pdfPCell.Border = 0;
            _pdfPCell.BackgroundColor = BaseColor.WHITE;
            _pdfPCell.ExtraParagraphSpace = 0;
            _pdfTable.AddCell(_pdfPCell);

            _fontstyle = FontFactory.GetFont("Tahoma", 12f, 1);
            _pdfPCell = new PdfPCell(new Phrase("", _fontstyle));
            _pdfPCell.Colspan = 5;
            _pdfPCell.HorizontalAlignment = Element.ALIGN_LEFT;
            _pdfPCell.Border = 0;
            _pdfPCell.BackgroundColor = BaseColor.WHITE;
            _pdfPCell.ExtraParagraphSpace = 0;
            _pdfTable.AddCell(_pdfPCell);

            _fontstyle = FontFactory.GetFont("Tahoma", 9f, 1);
            _pdfPCell = new PdfPCell(new Phrase("CÓDIGO :", _fontstyle));
            _pdfPCell.Colspan = 1;
            _pdfPCell.HorizontalAlignment = Element.ALIGN_RIGHT;
            _pdfPCell.Border = 0;
            _pdfPCell.BackgroundColor = BaseColor.WHITE;
            _pdfPCell.ExtraParagraphSpace = 0;
            _pdfTable.AddCell(_pdfPCell);

            _fontstyle = FontFactory.GetFont("Tahoma", 9f, 1);
            _pdfPCell = new PdfPCell(new Phrase("", _fontstyle));
            _pdfPCell.Colspan = 1;
            _pdfPCell.HorizontalAlignment = Element.ALIGN_RIGHT;
            _pdfPCell.Border = 0;
            _pdfPCell.BackgroundColor = BaseColor.WHITE;
            _pdfPCell.ExtraParagraphSpace = 0;
            _pdfTable.AddCell(_pdfPCell);

            _pdfTable.CompleteRow();


            _fontstyle = FontFactory.GetFont("Tahoma", 9f, 1);
            _pdfPCell = new PdfPCell(new Phrase(""));
            _pdfPCell.Colspan = 1;
            _pdfPCell.HorizontalAlignment = Element.ALIGN_LEFT;
            _pdfPCell.Border = 0;
            _pdfPCell.BackgroundColor = BaseColor.WHITE;
            _pdfPCell.ExtraParagraphSpace = 0;
            _pdfTable.AddCell(_pdfPCell);

            _fontstyle = FontFactory.GetFont("Tahoma", 12f, 1);
            _pdfPCell = new PdfPCell(new Phrase("RUTINA DE MANTENIMIENTO PREVENTIVO PARA", _fontstyle));
            _pdfPCell.Colspan = 5;
            _pdfPCell.HorizontalAlignment = Element.ALIGN_CENTER;
            _pdfPCell.Border = 0;
            _pdfPCell.BackgroundColor = BaseColor.WHITE;
            _pdfPCell.ExtraParagraphSpace = 0;
            _pdfTable.AddCell(_pdfPCell);

            _fontstyle = FontFactory.GetFont("Tahoma", 9f, 1);
            _pdfPCell = new PdfPCell(new Phrase("VERSION Nº :", _fontstyle));
            _pdfPCell.Colspan = 1;
            _pdfPCell.HorizontalAlignment = Element.ALIGN_RIGHT;
            _pdfPCell.Border = 0;
            _pdfPCell.BackgroundColor = BaseColor.WHITE;
            _pdfPCell.ExtraParagraphSpace = 0;
            _pdfTable.AddCell(_pdfPCell);

            _fontstyle = FontFactory.GetFont("Tahoma", 9f, 1);
            _pdfPCell = new PdfPCell(new Phrase("", _fontstyle));
            _pdfPCell.Colspan = 1;
            _pdfPCell.HorizontalAlignment = Element.ALIGN_RIGHT;
            _pdfPCell.Border = 0;
            _pdfPCell.BackgroundColor = BaseColor.WHITE;
            _pdfPCell.ExtraParagraphSpace = 0;
            _pdfTable.AddCell(_pdfPCell);

            _pdfTable.CompleteRow();

            _fontstyle = FontFactory.GetFont("Tahoma", 9f, 1);
            _pdfPCell = new PdfPCell(new Phrase(""));
            _pdfPCell.Colspan = 1;
            _pdfPCell.HorizontalAlignment = Element.ALIGN_LEFT;
            _pdfPCell.Border = 0;
            _pdfPCell.BackgroundColor = BaseColor.WHITE;
            _pdfPCell.ExtraParagraphSpace = 0;
            _pdfTable.AddCell(_pdfPCell);

            _fontstyle = FontFactory.GetFont("Tahoma", 12f, 1);
            _pdfPCell = new PdfPCell(new Phrase(ListAreBus[0].tbg_Descripcion, _fontstyle));
            _pdfPCell.Colspan = 5;
            _pdfPCell.HorizontalAlignment = Element.ALIGN_CENTER;
            _pdfPCell.Border = 0;
            _pdfPCell.BackgroundColor = BaseColor.WHITE;
            _pdfPCell.ExtraParagraphSpace = 0;
            _pdfTable.AddCell(_pdfPCell);

            _fontstyle = FontFactory.GetFont("Tahoma", 9f, 1);
            _pdfPCell = new PdfPCell(new Phrase("FECHA :", _fontstyle));
            _pdfPCell.Colspan = 1;
            _pdfPCell.HorizontalAlignment = Element.ALIGN_RIGHT;
            _pdfPCell.Border = 0;
            _pdfPCell.BackgroundColor = BaseColor.WHITE;
            _pdfPCell.ExtraParagraphSpace = 0;
            _pdfTable.AddCell(_pdfPCell);

            _fontstyle = FontFactory.GetFont("Tahoma", 9f, 1);
            _pdfPCell = new PdfPCell(new Phrase("", _fontstyle));
            _pdfPCell.Colspan = 1;
            _pdfPCell.HorizontalAlignment = Element.ALIGN_RIGHT;
            _pdfPCell.Border = 0;
            _pdfPCell.BackgroundColor = BaseColor.WHITE;
            _pdfPCell.ExtraParagraphSpace = 0;
            _pdfTable.AddCell(_pdfPCell);

            _pdfTable.CompleteRow();

            _fontstyle = FontFactory.GetFont("Tahoma", 9f, 1);
            _pdfPCell = new PdfPCell(new Phrase(""));
            _pdfPCell.Colspan = 1;
            _pdfPCell.HorizontalAlignment = Element.ALIGN_LEFT;
            _pdfPCell.Border = 0;
            _pdfPCell.BackgroundColor = BaseColor.WHITE;
            _pdfPCell.ExtraParagraphSpace = 0;
            _pdfTable.AddCell(_pdfPCell);

            _fontstyle = FontFactory.GetFont("Tahoma", 12f, 1);
            _pdfPCell = new PdfPCell(new Phrase("", _fontstyle));
            _pdfPCell.Colspan = 5;
            _pdfPCell.HorizontalAlignment = Element.ALIGN_LEFT;
            _pdfPCell.Border = 0;
            _pdfPCell.BackgroundColor = BaseColor.WHITE;
            _pdfPCell.ExtraParagraphSpace = 0;
            _pdfTable.AddCell(_pdfPCell);

            _fontstyle = FontFactory.GetFont("Tahoma", 9f, 1);
            _pdfPCell = new PdfPCell(new Phrase("PAGINAS :", _fontstyle));
            _pdfPCell.Colspan = 1;
            _pdfPCell.HorizontalAlignment = Element.ALIGN_RIGHT;
            _pdfPCell.Border = 0;
            _pdfPCell.BackgroundColor = BaseColor.WHITE;
            _pdfPCell.ExtraParagraphSpace = 0;
            _pdfTable.AddCell(_pdfPCell);

            _fontstyle = FontFactory.GetFont("Tahoma", 9f, 1);
            _pdfPCell = new PdfPCell(new Phrase("", _fontstyle));
            _pdfPCell.Colspan = 1;
            _pdfPCell.HorizontalAlignment = Element.ALIGN_RIGHT;
            _pdfPCell.Border = 0;
            _pdfPCell.BackgroundColor = BaseColor.WHITE;
            _pdfPCell.ExtraParagraphSpace = 0;
            _pdfTable.AddCell(_pdfPCell);

            _pdfTable.CompleteRow();




        }

        private void ReportBody()
        {
            _fontstyle = FontFactory.GetFont("Tahoma", 11f, 1);
            _pdfPCell = new PdfPCell(new Phrase("DATOS DEL VEHICULO", _fontstyle));
            _pdfPCell.Colspan = 8;
            _pdfPCell.HorizontalAlignment = Element.ALIGN_CENTER;
            _pdfPCell.Border = 0;
            _pdfPCell.BackgroundColor = BaseColor.GRAY;
            _pdfPCell.ExtraParagraphSpace = 0;
            _pdfTable.AddCell(_pdfPCell);
            _pdfTable.CompleteRow();

            _fontstyle = FontFactory.GetFont("Tahoma", 9f, 1);
            _pdfPCell = new PdfPCell(new Phrase("PLACA :", _fontstyle));
            _pdfPCell.Colspan = 1;
            _pdfPCell.HorizontalAlignment = Element.ALIGN_RIGHT;
            //_pdfPCell.Border = 1;
            //_pdfPCell.BackgroundColor = BaseColor.WHITE;
            _pdfPCell.ExtraParagraphSpace = 0;
            _pdfTable.AddCell(_pdfPCell);

            _fontstyle = FontFactory.GetFont("Tahoma", 9f, 1);
            _pdfPCell = new PdfPCell(new Phrase((ListAreBus.Count > 0) ? ListAreBus[0].Are_Nombre.ToString() : String.Empty, _fontstyle));
            _pdfPCell.Colspan = 1;
            _pdfPCell.HorizontalAlignment = Element.ALIGN_LEFT;
            //_pdfPCell.Border = 1;
            //_pdfPCell.BackgroundColor = BaseColor.WHITE;
            _pdfPCell.ExtraParagraphSpace = 0;
            _pdfTable.AddCell(_pdfPCell);


            _fontstyle = FontFactory.GetFont("Tahoma", 9f, 1);
            _pdfPCell = new PdfPCell(new Phrase("MARCA :", _fontstyle));
            _pdfPCell.Colspan = 1;
            _pdfPCell.HorizontalAlignment = Element.ALIGN_RIGHT;
            //_pdfPCell.Border = 1;
            //_pdfPCell.BackgroundColor = BaseColor.WHITE;
            _pdfPCell.ExtraParagraphSpace = 0;
            _pdfTable.AddCell(_pdfPCell);

            _fontstyle = FontFactory.GetFont("Tahoma", 9f, 1);
            _pdfPCell = new PdfPCell(new Phrase((ListAreBus.Count > 0) ? ListAreBus[0].Marca.ToString() : String.Empty, _fontstyle));
            _pdfPCell.Colspan = 1;
            _pdfPCell.HorizontalAlignment = Element.ALIGN_LEFT;
            //_pdfPCell.Border = 1;
            //_pdfPCell.BackgroundColor = BaseColor.WHITE;
            _pdfPCell.ExtraParagraphSpace = 0;
            _pdfTable.AddCell(_pdfPCell);


            _fontstyle = FontFactory.GetFont("Tahoma", 9f, 1);
            _pdfPCell = new PdfPCell(new Phrase("MODELO :", _fontstyle));
            _pdfPCell.Colspan = 1;
            _pdfPCell.HorizontalAlignment = Element.ALIGN_RIGHT;
            //_pdfPCell.Border = 1;
            //_pdfPCell.BackgroundColor = BaseColor.WHITE;
            _pdfPCell.ExtraParagraphSpace = 0;
            _pdfTable.AddCell(_pdfPCell);

            _fontstyle = FontFactory.GetFont("Tahoma", 9f, 1);
            _pdfPCell = new PdfPCell(new Phrase((ListAreBus.Count > 0) ? ListAreBus[0].Modelo.ToString() : String.Empty, _fontstyle));
            _pdfPCell.Colspan = 1;
            _pdfPCell.HorizontalAlignment = Element.ALIGN_LEFT;
            //_pdfPCell.Border = 1;
            //_pdfPCell.BackgroundColor = BaseColor.WHITE;
            _pdfPCell.ExtraParagraphSpace = 0;
            _pdfTable.AddCell(_pdfPCell);

            _fontstyle = FontFactory.GetFont("Tahoma", 9f, 1);
            _pdfPCell = new PdfPCell(new Phrase("KILOMETRAJE :", _fontstyle));
            _pdfPCell.Colspan = 1;
            _pdfPCell.HorizontalAlignment = Element.ALIGN_RIGHT;
            //_pdfPCell.Border = 1;
            //_pdfPCell.BackgroundColor = BaseColor.WHITE;
            _pdfPCell.ExtraParagraphSpace = 0;
            _pdfTable.AddCell(_pdfPCell);

            _fontstyle = FontFactory.GetFont("Tahoma", 9f, 1);
            _pdfPCell = new PdfPCell(new Phrase((ListAreBus.Count > 0) ? ListAreBus[0].Kilometraje.ToString() : String.Empty, _fontstyle));
            _pdfPCell.Colspan = 1;
            _pdfPCell.HorizontalAlignment = Element.ALIGN_LEFT;
            //_pdfPCell.Border = 1;
            //_pdfPCell.BackgroundColor = BaseColor.WHITE;
            _pdfPCell.ExtraParagraphSpace = 0;
            _pdfTable.AddCell(_pdfPCell);
            _pdfTable.CompleteRow();

            _fontstyle = FontFactory.GetFont("Tahoma", 9f, 1);
            _pdfPCell = new PdfPCell(new Phrase("OPERADOR :", _fontstyle));
            _pdfPCell.Colspan = 1;
            _pdfPCell.HorizontalAlignment = Element.ALIGN_RIGHT;
            //_pdfPCell.Border = 1;
            //_pdfPCell.BackgroundColor = BaseColor.WHITE;
            _pdfPCell.ExtraParagraphSpace = 0;
            _pdfTable.AddCell(_pdfPCell);

            _fontstyle = FontFactory.GetFont("Tahoma", 9f, 1);
            _pdfPCell = new PdfPCell(new Phrase((ListAreBus.Count > 0) ? ListAreBus[0].tbg_Descripcion.ToString() : String.Empty, _fontstyle));
            _pdfPCell.Colspan = 3;
            _pdfPCell.HorizontalAlignment = Element.ALIGN_LEFT;
            //_pdfPCell.Border = 1;
            //_pdfPCell.BackgroundColor = BaseColor.WHITE;
            _pdfPCell.ExtraParagraphSpace = 0;
            _pdfTable.AddCell(_pdfPCell);


            _fontstyle = FontFactory.GetFont("Tahoma", 9f, 1);
            _pdfPCell = new PdfPCell(new Phrase("FECHA :", _fontstyle));
            _pdfPCell.Colspan = 1;
            _pdfPCell.HorizontalAlignment = Element.ALIGN_RIGHT;
            //_pdfPCell.Border = 1;
            //_pdfPCell.BackgroundColor = BaseColor.WHITE;
            _pdfPCell.ExtraParagraphSpace = 0;
            _pdfTable.AddCell(_pdfPCell);

            _fontstyle = FontFactory.GetFont("Tahoma", 9f, 1);
            _pdfPCell = new PdfPCell(new Phrase((ListAreBus.Count > 0) ? ListAreBus[0].FechaViaje.ToString() : String.Empty, _fontstyle));
            _pdfPCell.Colspan = 1;
            _pdfPCell.HorizontalAlignment = Element.ALIGN_LEFT;
            //_pdfPCell.Border = 1;
            //_pdfPCell.BackgroundColor = BaseColor.WHITE;
            _pdfPCell.ExtraParagraphSpace = 0;
            _pdfTable.AddCell(_pdfPCell);

            _fontstyle = FontFactory.GetFont("Tahoma", 9f, 1);
            _pdfPCell = new PdfPCell(new Phrase("UBICACIÓN :", _fontstyle));
            _pdfPCell.Colspan = 1;
            _pdfPCell.HorizontalAlignment = Element.ALIGN_RIGHT;
            //_pdfPCell.Border = 1;
            //_pdfPCell.BackgroundColor = BaseColor.WHITE;
            _pdfPCell.ExtraParagraphSpace = 0;
            _pdfTable.AddCell(_pdfPCell);

            _fontstyle = FontFactory.GetFont("Tahoma", 9f, 1);
            _pdfPCell = new PdfPCell(new Phrase((ListAreBus.Count > 0) ? ListAreBus[0].Ubicacion.ToString() : String.Empty, _fontstyle));
            _pdfPCell.Colspan = 1;
            _pdfPCell.HorizontalAlignment = Element.ALIGN_LEFT;
            //_pdfPCell.Border = 1;
            //_pdfPCell.BackgroundColor = BaseColor.WHITE;
            _pdfPCell.ExtraParagraphSpace = 0;
            _pdfTable.AddCell(_pdfPCell);
            _pdfTable.CompleteRow();


            _fontstyle = FontFactory.GetFont("Tahoma", 9f, 1);
            _pdfPCell = new PdfPCell(new Phrase("OPERACIÓN :", _fontstyle));
            _pdfPCell.Colspan = 1;
            _pdfPCell.HorizontalAlignment = Element.ALIGN_RIGHT;
            //_pdfPCell.Border = 1;
            //_pdfPCell.BackgroundColor = BaseColor.WHITE;
            _pdfPCell.ExtraParagraphSpace = 0;
            _pdfTable.AddCell(_pdfPCell);

            _fontstyle = FontFactory.GetFont("Tahoma", 9f, 1);
            _pdfPCell = new PdfPCell(new Phrase((ListTareaSistemaEntity.Count > 0) ? ListTareaSistemaEntity[0].Operacion.ToString() : String.Empty, _fontstyle));
            _pdfPCell.Colspan = 3;
            _pdfPCell.HorizontalAlignment = Element.ALIGN_LEFT;
            //_pdfPCell.Border = 1;
            //_pdfPCell.BackgroundColor = BaseColor.WHITE;
            _pdfPCell.ExtraParagraphSpace = 0;
            _pdfTable.AddCell(_pdfPCell);


            _fontstyle = FontFactory.GetFont("Tahoma", 9f, 1);
            _pdfPCell = new PdfPCell(new Phrase("ORD.  TRABAJO :", _fontstyle));
            _pdfPCell.Colspan = 1;
            _pdfPCell.HorizontalAlignment = Element.ALIGN_RIGHT;
            //_pdfPCell.Border = 1;
            //_pdfPCell.BackgroundColor = BaseColor.WHITE;
            _pdfPCell.ExtraParagraphSpace = 0;
            _pdfTable.AddCell(_pdfPCell);

            _fontstyle = FontFactory.GetFont("Tahoma", 9f, 1);
            _pdfPCell = new PdfPCell(new Phrase((ListAreBus.Count > 0) ? ListAreBus[0].OrdenTrabajo.ToString() : String.Empty, _fontstyle));
            _pdfPCell.Colspan = 3;
            _pdfPCell.HorizontalAlignment = Element.ALIGN_LEFT;
            //_pdfPCell.Border = 1;
            //_pdfPCell.BackgroundColor = BaseColor.WHITE;
            _pdfPCell.ExtraParagraphSpace = 0;
            _pdfTable.AddCell(_pdfPCell);
            _pdfTable.CompleteRow();

            _fontstyle = FontFactory.GetFont("Tahoma", 11f, 1);
            _pdfPCell = new PdfPCell(new Phrase("ACTIVIDADES A REALIZAR", _fontstyle));
            _pdfPCell.Colspan = 8;
            _pdfPCell.HorizontalAlignment = Element.ALIGN_CENTER;
            _pdfPCell.Border = 0;
            _pdfPCell.BackgroundColor = BaseColor.GRAY;
            _pdfPCell.ExtraParagraphSpace = 0;
            _pdfTable.AddCell(_pdfPCell);
            _pdfTable.CompleteRow();

            _fontstyle = FontFactory.GetFont("Tahoma", 2F, 1);
            _pdfPCell = new PdfPCell(new Phrase(" ", _fontstyle));
            _pdfPCell.Colspan = 8;
            _pdfPCell.HorizontalAlignment = Element.ALIGN_CENTER;
            _pdfPCell.Border = 0;
            _pdfPCell.BackgroundColor = BaseColor.WHITE;
            _pdfPCell.ExtraParagraphSpace = 0;
            _pdfTable.AddCell(_pdfPCell);
            _pdfTable.CompleteRow();




            // DIVIDIR COLUMNAS
            List<TareaSistemaEntity> List1 = new List<TareaSistemaEntity>();
            List<TareaSistemaEntity> List2 = new List<TareaSistemaEntity>();
            double cantidadPorColumnas = (Convert.ToDouble(ListTareaSistemaEntity.Count) / 2);
            decimal valor = Convert.ToDecimal(cantidadPorColumnas);
            decimal cantidad = Math.Round(valor, MidpointRounding.AwayFromZero);
            List1 = ListTareaSistemaEntity.Take(Convert.ToInt32(cantidad)).ToList();
            List2 = ListTareaSistemaEntity.Skip(Convert.ToInt32(cantidad)).ToList();



            List<ColumnsTable> listct1 = new List<ColumnsTable>();
            ColumnsTable ct1 = new ColumnsTable();
            ColumnsTable ct1s = new ColumnsTable();
            int increment = 0;
            int increments = 0;
            string descSistema = string.Empty;

            foreach (var item in List1)
            {
                if (item.Sistema_Descripcion != descSistema || descSistema == string.Empty)
                {
                    ct1s = new ColumnsTable()
                    {
                        id = ++increment,
                        Sistema_Descripcion = (item.Sistema_Descripcion == descSistema) ? string.Empty : string.Concat(Functions.RetornaNumeroRomano(++increments), " ", item.Sistema_Descripcion)
                    };
                    listct1.Add(ct1s);
                }



                ct1 = new ColumnsTable()
                {
                    id = ++increment,
                    Sistema_Descripcion = string.Empty,
                    IdTarea = item.IdTarea,
                    Tarea_Descripcion = item.Tarea_Descripcion
                };
                listct1.Add(ct1);
                descSistema = item.Sistema_Descripcion;
            }

            List<ColumnsTable> listct2 = new List<ColumnsTable>();
            ColumnsTable ct2 = new ColumnsTable();
            ColumnsTable ct2s = new ColumnsTable();
            int increment2 = 0;

            string descSistema2 = string.Empty;
            foreach (var item in List2)
            {
                if (item.Sistema_Descripcion != descSistema2 || descSistema2 == string.Empty)
                {
                    ct2s = new ColumnsTable()
                    {
                        id = ++increment2,
                        Sistema_Descripcion = (item.Sistema_Descripcion == descSistema2) ? string.Empty : string.Concat(Functions.RetornaNumeroRomano(++increments), " ", item.Sistema_Descripcion)
                    };
                    listct2.Add(ct2s);
                }

                ct2 = new ColumnsTable()
                {
                    id = ++increment2,
                    Sistema_Descripcion = string.Empty, //(item.Sistema_Descripcion == descSistema2) ? string.Empty : item.Sistema_Descripcion,
                    IdTarea = item.IdTarea,
                    Tarea_Descripcion = item.Tarea_Descripcion
                };
                listct2.Add(ct2);
                descSistema2 = item.Sistema_Descripcion;
            }

            List<ColumnsTableUnion> listCTU = new List<ColumnsTableUnion>();
            listCTU = (from l1 in listct1
                       join l2 in listct2 on l1.id equals l2.id into ps
                       from p in ps.DefaultIfEmpty()
                       select new ColumnsTableUnion
                       {
                           id = l1.id,
                           Sistema_Descripcion1 = l1.Sistema_Descripcion,
                           IdTarea1 = l1.IdTarea,
                           Tarea_Descripcion1 = l1.Tarea_Descripcion,
                           Sistema_Descripcion2 = p == null ? string.Empty : p.Sistema_Descripcion,
                           IdTarea2 = p == null ? 0 : p.IdTarea,
                           Tarea_Descripcion2 = p == null ? string.Empty : p.Tarea_Descripcion,

                       }).ToList();



            #region  Columna

            _fontstyle = FontFactory.GetFont("Tahoma", 11f, 1);
            _pdfPCell = new PdfPCell(new Phrase("CODIGO", _fontstyle));
            _pdfPCell.Colspan = 1;
            _pdfPCell.HorizontalAlignment = Element.ALIGN_CENTER;
            _pdfPCell.Border = 0;
            _pdfPCell.BackgroundColor = BaseColor.GRAY;
            _pdfPCell.ExtraParagraphSpace = 0;
            _pdfTable.AddCell(_pdfPCell);

            _fontstyle = FontFactory.GetFont("Tahoma", 11f, 1);
            _pdfPCell = new PdfPCell(new Phrase("DESCRIPCIÓN", _fontstyle));
            _pdfPCell.Colspan = 2;
            _pdfPCell.HorizontalAlignment = Element.ALIGN_CENTER;
            _pdfPCell.Border = 0;
            _pdfPCell.BackgroundColor = BaseColor.GRAY;
            _pdfPCell.ExtraParagraphSpace = 0;
            _pdfTable.AddCell(_pdfPCell);

            _fontstyle = FontFactory.GetFont("Tahoma", 11f, 1);
            _pdfPCell = new PdfPCell(new Phrase("V°B°", _fontstyle));
            _pdfPCell.Colspan = 1;
            _pdfPCell.HorizontalAlignment = Element.ALIGN_CENTER;
            _pdfPCell.Border = 0;
            _pdfPCell.BackgroundColor = BaseColor.GRAY;
            _pdfPCell.ExtraParagraphSpace = 0;
            _pdfTable.AddCell(_pdfPCell);

            _fontstyle = FontFactory.GetFont("Tahoma", 11f, 1);
            _pdfPCell = new PdfPCell(new Phrase("CODIGO", _fontstyle));
            _pdfPCell.Colspan = 1;
            _pdfPCell.HorizontalAlignment = Element.ALIGN_CENTER;
            _pdfPCell.Border = 0;
            _pdfPCell.BackgroundColor = BaseColor.GRAY;
            _pdfPCell.ExtraParagraphSpace = 0;
            _pdfTable.AddCell(_pdfPCell);

            _fontstyle = FontFactory.GetFont("Tahoma", 11f, 1);
            _pdfPCell = new PdfPCell(new Phrase("DESCRIPCIÓN", _fontstyle));
            _pdfPCell.Colspan = 2;
            _pdfPCell.HorizontalAlignment = Element.ALIGN_CENTER;
            _pdfPCell.Border = 0;
            _pdfPCell.BackgroundColor = BaseColor.GRAY;
            _pdfPCell.ExtraParagraphSpace = 0;
            _pdfTable.AddCell(_pdfPCell);

            _fontstyle = FontFactory.GetFont("Tahoma", 11f, 1);
            _pdfPCell = new PdfPCell(new Phrase("V°B°", _fontstyle));
            _pdfPCell.Colspan = 1;
            _pdfPCell.HorizontalAlignment = Element.ALIGN_CENTER;
            _pdfPCell.Border = 0;
            _pdfPCell.BackgroundColor = BaseColor.GRAY;
            _pdfPCell.ExtraParagraphSpace = 0;
            _pdfTable.AddCell(_pdfPCell);
            _pdfTable.CompleteRow();


            _fontstyle = FontFactory.GetFont("Tahoma", 6f, 0);
            foreach (var item in listCTU)
            {
                if (!string.IsNullOrEmpty(item.Sistema_Descripcion1))
                {
                    _pdfPCell = new PdfPCell(new Phrase(string.Concat(" ", item.Sistema_Descripcion1), _fontstyle));
                    _pdfPCell.Colspan = 4;
                    _pdfPCell.HorizontalAlignment = Element.ALIGN_LEFT;
                    _pdfPCell.VerticalAlignment = Element.ALIGN_MIDDLE;
                    _pdfPCell.BackgroundColor = BaseColor.WHITE;
                    _pdfPCell.Border = 0;
                    _pdfTable.AddCell(_pdfPCell);

                    if (!string.IsNullOrEmpty(item.Sistema_Descripcion2))
                    {
                        _pdfPCell = new PdfPCell(new Phrase(string.Concat(" ", item.Sistema_Descripcion2), _fontstyle));
                        _pdfPCell.Colspan = 4;
                        _pdfPCell.HorizontalAlignment = Element.ALIGN_LEFT;
                        _pdfPCell.VerticalAlignment = Element.ALIGN_MIDDLE;
                        _pdfPCell.BackgroundColor = BaseColor.WHITE;
                        _pdfPCell.Border = 0;
                        _pdfTable.AddCell(_pdfPCell);
                        _pdfTable.CompleteRow();

                    }

                    if (item.Tarea_Descripcion2 != null)
                    {
                        _pdfPCell = new PdfPCell(new Phrase(item.IdTarea2.ToString(), _fontstyle));
                        _pdfPCell.Colspan = 1;
                        _pdfPCell.HorizontalAlignment = Element.ALIGN_CENTER;
                        _pdfPCell.VerticalAlignment = Element.ALIGN_MIDDLE;
                        _pdfPCell.BackgroundColor = BaseColor.WHITE;
                        _pdfPCell.Border = 1;
                        _pdfTable.AddCell(_pdfPCell);

                        _pdfPCell = new PdfPCell(new Phrase(item.Tarea_Descripcion2.ToString(), _fontstyle));
                        _pdfPCell.Colspan = 2;
                        _pdfPCell.HorizontalAlignment = Element.ALIGN_LEFT;
                        _pdfPCell.VerticalAlignment = Element.ALIGN_MIDDLE;
                        _pdfPCell.BackgroundColor = BaseColor.WHITE;
                        _pdfPCell.Border = 1;
                        _pdfTable.AddCell(_pdfPCell);

                        _pdfPCell = new PdfPCell(new Phrase("❒", _fontstyle));
                        _pdfPCell.Colspan = 1;
                        _pdfPCell.HorizontalAlignment = Element.ALIGN_CENTER;
                        _pdfPCell.VerticalAlignment = Element.ALIGN_MIDDLE;
                        _pdfPCell.BackgroundColor = BaseColor.WHITE;
                        _pdfPCell.Border = 1;
                        _pdfTable.AddCell(_pdfPCell);
                        _pdfTable.CompleteRow();

                    }
                }

                if (item.Tarea_Descripcion1 != null)
                {
                    _pdfPCell = new PdfPCell(new Phrase(item.IdTarea1.ToString(), _fontstyle));
                    _pdfPCell.Colspan = 1;
                    _pdfPCell.HorizontalAlignment = Element.ALIGN_CENTER;
                    _pdfPCell.VerticalAlignment = Element.ALIGN_MIDDLE;
                    _pdfPCell.BackgroundColor = BaseColor.WHITE;
                    _pdfPCell.Border = 1;
                    _pdfTable.AddCell(_pdfPCell);

                    _pdfPCell = new PdfPCell(new Phrase((item.Tarea_Descripcion1 == null) ? string.Empty : item.Tarea_Descripcion1.ToString(), _fontstyle));
                    _pdfPCell.Colspan = 2;
                    _pdfPCell.HorizontalAlignment = Element.ALIGN_LEFT;
                    _pdfPCell.VerticalAlignment = Element.ALIGN_MIDDLE;
                    _pdfPCell.BackgroundColor = BaseColor.WHITE;
                    _pdfPCell.Border = 1;
                    _pdfTable.AddCell(_pdfPCell);

                    _pdfPCell = new PdfPCell(new Phrase("❒", _fontstyle));
                    _pdfPCell.Colspan = 1;
                    _pdfPCell.HorizontalAlignment = Element.ALIGN_CENTER;
                    _pdfPCell.VerticalAlignment = Element.ALIGN_MIDDLE;
                    _pdfPCell.BackgroundColor = BaseColor.WHITE;
                    _pdfPCell.Border = 1;
                    _pdfTable.AddCell(_pdfPCell);

                    if (!string.IsNullOrEmpty(item.Sistema_Descripcion2))
                    {
                        _pdfPCell = new PdfPCell(new Phrase(string.Concat(" ", item.Sistema_Descripcion2), _fontstyle));
                        _pdfPCell.Colspan = 4;
                        _pdfPCell.HorizontalAlignment = Element.ALIGN_LEFT;
                        _pdfPCell.VerticalAlignment = Element.ALIGN_MIDDLE;
                        _pdfPCell.BackgroundColor = BaseColor.WHITE;
                        _pdfPCell.Border = 0;
                        _pdfTable.AddCell(_pdfPCell);
                        _pdfTable.CompleteRow();

                    }

                    if (item.Tarea_Descripcion2 != null)
                    {
                        _pdfPCell = new PdfPCell(new Phrase(item.IdTarea2.ToString(), _fontstyle));
                        _pdfPCell.Colspan = 1;
                        _pdfPCell.HorizontalAlignment = Element.ALIGN_CENTER;
                        _pdfPCell.VerticalAlignment = Element.ALIGN_MIDDLE;
                        _pdfPCell.BackgroundColor = BaseColor.WHITE;
                        _pdfPCell.Border = 1;
                        _pdfTable.AddCell(_pdfPCell);

                        _pdfPCell = new PdfPCell(new Phrase(item.Tarea_Descripcion2.ToString(), _fontstyle));
                        _pdfPCell.Colspan = 2;
                        _pdfPCell.HorizontalAlignment = Element.ALIGN_LEFT;
                        _pdfPCell.VerticalAlignment = Element.ALIGN_MIDDLE;
                        _pdfPCell.BackgroundColor = BaseColor.WHITE;
                        _pdfPCell.Border = 1;
                        _pdfTable.AddCell(_pdfPCell);

                        _pdfPCell = new PdfPCell(new Phrase("❒", _fontstyle));
                        _pdfPCell.Colspan = 1;
                        _pdfPCell.HorizontalAlignment = Element.ALIGN_CENTER;
                        _pdfPCell.VerticalAlignment = Element.ALIGN_MIDDLE;
                        _pdfPCell.BackgroundColor = BaseColor.WHITE;
                        _pdfPCell.Border = 1;
                        _pdfTable.AddCell(_pdfPCell);
                        _pdfTable.CompleteRow();

                    }
                }

            }


            #region Anterior


            //_fontstyle = FontFactory.GetFont("Tahoma", 6f, 0);
            //List<string> sistemas = ListTareaSistemaEntity.Select(s => s.Sistema_Descripcion).Distinct().ToList();

            //    int i = 0;
            //    string iRomano = string.Empty;
            //    foreach (string itemS in sistemas)
            //    {
            //        i = i + 1;
            //        iRomano = Functions.RetornaNumeroRomano(i);
            //        _pdfPCell = new PdfPCell(new Phrase(string.Concat(iRomano," ",itemS), _fontstyle));
            //        _pdfPCell.Colspan = 4;
            //        _pdfPCell.HorizontalAlignment = Element.ALIGN_LEFT;
            //        _pdfPCell.VerticalAlignment = Element.ALIGN_MIDDLE;
            //        _pdfPCell.BackgroundColor = BaseColor.WHITE;
            //        _pdfPCell.Border = 0;
            //        _pdfTable.AddCell(_pdfPCell);
            //        _pdfTable.CompleteRow();

            //    #region Anterior

            //    List<TareaSistemaEntity> lisTS = ListTareaSistemaEntity.Where(s => s.Sistema_Descripcion == itemS).ToList();

            //    foreach (TareaSistemaEntity tareaSistema in lisTS)
            //    {
            //        _pdfPCell = new PdfPCell(new Phrase(tareaSistema.IdTarea.ToString(), _fontstyle));
            //        _pdfPCell.Colspan = 1;
            //        _pdfPCell.HorizontalAlignment = Element.ALIGN_CENTER;
            //        _pdfPCell.VerticalAlignment = Element.ALIGN_MIDDLE;
            //        _pdfPCell.BackgroundColor = BaseColor.WHITE;
            //        _pdfPCell.Border = 1;
            //        _pdfTable.AddCell(_pdfPCell);

            //        _pdfPCell = new PdfPCell(new Phrase(tareaSistema.Tarea_Descripcion.ToString(), _fontstyle));
            //        _pdfPCell.Colspan = 2;
            //        _pdfPCell.HorizontalAlignment = Element.ALIGN_LEFT;
            //        _pdfPCell.VerticalAlignment = Element.ALIGN_MIDDLE;
            //        _pdfPCell.BackgroundColor = BaseColor.WHITE;
            //        _pdfPCell.Border = 1;
            //        _pdfTable.AddCell(_pdfPCell);

            //        _pdfPCell = new PdfPCell(new Phrase("❒", _fontstyle));
            //        _pdfPCell.Colspan = 1;
            //        _pdfPCell.HorizontalAlignment = Element.ALIGN_CENTER;
            //        _pdfPCell.VerticalAlignment = Element.ALIGN_MIDDLE;
            //        _pdfPCell.BackgroundColor = BaseColor.WHITE;
            //        _pdfPCell.Border = 1;
            //        _pdfTable.AddCell(_pdfPCell);

            //        _pdfTable.CompleteRow();

            //    }

            //    #endregion
            //}
            #endregion
            #endregion



            _fontstyle = FontFactory.GetFont("Tahoma", 2F, 1);
            _pdfPCell = new PdfPCell(new Phrase(" ", _fontstyle));
            _pdfPCell.Colspan = 8;
            _pdfPCell.HorizontalAlignment = Element.ALIGN_CENTER;
            _pdfPCell.Border = 0;
            _pdfPCell.BackgroundColor = BaseColor.WHITE;
            _pdfPCell.ExtraParagraphSpace = 0;
            _pdfTable.AddCell(_pdfPCell);
            _pdfTable.CompleteRow();

            _fontstyle = FontFactory.GetFont("Tahoma", 11f, 1);
            _pdfPCell = new PdfPCell(new Phrase("INSPECCION DE FRENOS Y NEUMATICOS", _fontstyle));
            _pdfPCell.Colspan = 8;
            _pdfPCell.HorizontalAlignment = Element.ALIGN_CENTER;
            _pdfPCell.Border = 0;
            _pdfPCell.BackgroundColor = BaseColor.GRAY;
            _pdfPCell.ExtraParagraphSpace = 0;
            _pdfTable.AddCell(_pdfPCell);
            _pdfTable.CompleteRow();

            // ESPACIO EN BLANCO
            _fontstyle = FontFactory.GetFont("Tahoma", 2F, 1);
            _pdfPCell = new PdfPCell(new Phrase(" ", _fontstyle));
            _pdfPCell.Colspan = 8;
            _pdfPCell.HorizontalAlignment = Element.ALIGN_CENTER;
            _pdfPCell.Border = 0;
            _pdfPCell.BackgroundColor = BaseColor.WHITE;
            _pdfPCell.ExtraParagraphSpace = 0;
            _pdfTable.AddCell(_pdfPCell);
            _pdfTable.CompleteRow();

            _fontstyle = FontFactory.GetFont("Tahoma", 9f, 1);
            _pdfPCell = new PdfPCell(new Phrase("ANOTAR LA ALTURA DE FAJAS DE FRENOS DE CADA TAMBOR (mm)", _fontstyle));
            _pdfPCell.Colspan = 4;
            _pdfPCell.HorizontalAlignment = Element.ALIGN_CENTER;
            //_pdfPCell.Border = 1;
            //_pdfPCell.BackgroundColor = BaseColor.WHITE;
            _pdfPCell.ExtraParagraphSpace = 0;
            _pdfTable.AddCell(_pdfPCell);

            _fontstyle = FontFactory.GetFont("Tahoma", 9f, 1);
            _pdfPCell = new PdfPCell(new Phrase("ANOTAR LA ALTURA DE REMANENTE DE CADA UNO DE LOS NEUMATICOS (mm)", _fontstyle));
            _pdfPCell.Colspan = 4;
            _pdfPCell.HorizontalAlignment = Element.ALIGN_CENTER;
            //_pdfPCell.Border = 1;
            //_pdfPCell.BackgroundColor = BaseColor.WHITE;
            _pdfPCell.ExtraParagraphSpace = 0;
            _pdfTable.AddCell(_pdfPCell);
            _pdfTable.CompleteRow();

            string URL = HttpRuntime.AppDomainAppPath;


            // add a image
            Image jpg = Image.GetInstance(URL + @"Images\" + "image_Frenos_Neumaticos.jpg");
            _pdfPCell = new PdfPCell(jpg, true);
            _pdfPCell.Colspan = 4;
            //_pdfPCell.Border = 1;
            _pdfPCell.HorizontalAlignment = Element.ALIGN_CENTER;
            _pdfPCell.ExtraParagraphSpace = 0;
            _pdfTable.AddCell(_pdfPCell);

            Image jpg2 = Image.GetInstance(URL + @"Images\" + "image_Frenos_Neumaticos.jpg");
            //PdfPCell imageCell = new PdfPCell(jpg);
            _pdfPCell = new PdfPCell(jpg2, true);
            _pdfPCell.Colspan = 4;
            //_pdfPCell.Border = 1;
            _pdfPCell.HorizontalAlignment = Element.ALIGN_CENTER;
            _pdfPCell.ExtraParagraphSpace = 0;
            _pdfTable.AddCell(_pdfPCell);
            _pdfTable.CompleteRow();

            // ESPACIO EN BLANCO
            _fontstyle = FontFactory.GetFont("Tahoma", 2F, 1);
            _pdfPCell = new PdfPCell(new Phrase(" ", _fontstyle));
            _pdfPCell.Colspan = 8;
            _pdfPCell.HorizontalAlignment = Element.ALIGN_CENTER;
            _pdfPCell.Border = 0;
            _pdfPCell.BackgroundColor = BaseColor.WHITE;
            _pdfPCell.ExtraParagraphSpace = 0;
            _pdfTable.AddCell(_pdfPCell);
            _pdfTable.CompleteRow();

            _fontstyle = FontFactory.GetFont("Tahoma", 11f, 1);
            _pdfPCell = new PdfPCell(new Phrase("OBSERVACIONES Y/O TRABAJOS PENDIENTES", _fontstyle));
            _pdfPCell.Colspan = 8;
            _pdfPCell.HorizontalAlignment = Element.ALIGN_CENTER;
            _pdfPCell.Border = 0;
            _pdfPCell.BackgroundColor = BaseColor.GRAY;
            _pdfPCell.ExtraParagraphSpace = 0;
            _pdfTable.AddCell(_pdfPCell);
            _pdfTable.CompleteRow();

            // ESPACIO EN BLANCO
            _fontstyle = FontFactory.GetFont("Tahoma", 2F, 1);
            _pdfPCell = new PdfPCell(new Phrase(" ", _fontstyle));
            _pdfPCell.Colspan = 8;
            _pdfPCell.HorizontalAlignment = Element.ALIGN_CENTER;
            _pdfPCell.Border = 0;
            _pdfPCell.BackgroundColor = BaseColor.WHITE;
            _pdfPCell.ExtraParagraphSpace = 0;
            _pdfTable.AddCell(_pdfPCell);
            _pdfTable.CompleteRow();

            _fontstyle = FontFactory.GetFont("Tahoma", 11f, 1);
            _pdfPCell = new PdfPCell(new Phrase("COD", _fontstyle));
            _pdfPCell.Colspan = 1;
            _pdfPCell.HorizontalAlignment = Element.ALIGN_CENTER;
            _pdfPCell.BackgroundColor = BaseColor.GRAY;
            _pdfPCell.ExtraParagraphSpace = 0;
            _pdfTable.AddCell(_pdfPCell);

            _fontstyle = FontFactory.GetFont("Tahoma", 11f, 1);
            _pdfPCell = new PdfPCell(new Phrase("DESCRIPCIÓN O MOTIVO", _fontstyle));
            _pdfPCell.Colspan = 3;
            _pdfPCell.HorizontalAlignment = Element.ALIGN_CENTER;
            _pdfPCell.BackgroundColor = BaseColor.GRAY;
            _pdfPCell.ExtraParagraphSpace = 0;
            _pdfTable.AddCell(_pdfPCell);

            _fontstyle = FontFactory.GetFont("Tahoma", 11f, 1);
            _pdfPCell = new PdfPCell(new Phrase("COD", _fontstyle));
            _pdfPCell.Colspan = 1;
            _pdfPCell.HorizontalAlignment = Element.ALIGN_CENTER;
            _pdfPCell.BackgroundColor = BaseColor.GRAY;
            _pdfPCell.ExtraParagraphSpace = 0;
            _pdfTable.AddCell(_pdfPCell);

            _fontstyle = FontFactory.GetFont("Tahoma", 11f, 1);
            _pdfPCell = new PdfPCell(new Phrase("DESCRIPCIÓN O MOTIVO", _fontstyle));
            _pdfPCell.Colspan = 3;
            _pdfPCell.HorizontalAlignment = Element.ALIGN_CENTER;
            _pdfPCell.BackgroundColor = BaseColor.GRAY;
            _pdfPCell.ExtraParagraphSpace = 0;
            _pdfTable.AddCell(_pdfPCell);
            _pdfTable.CompleteRow();


            _fontstyle = FontFactory.GetFont("Tahoma", 11f, 1);
            _pdfPCell = new PdfPCell(new Phrase(" ", _fontstyle));
            _pdfPCell.Colspan = 1;
            _pdfPCell.HorizontalAlignment = Element.ALIGN_CENTER;
            _pdfPCell.ExtraParagraphSpace = 0;
            _pdfTable.AddCell(_pdfPCell);

            _fontstyle = FontFactory.GetFont("Tahoma", 11f, 1);
            _pdfPCell = new PdfPCell(new Phrase(" ", _fontstyle));
            _pdfPCell.Colspan = 3;
            _pdfPCell.HorizontalAlignment = Element.ALIGN_CENTER;
            _pdfPCell.ExtraParagraphSpace = 0;
            _pdfTable.AddCell(_pdfPCell);

            _fontstyle = FontFactory.GetFont("Tahoma", 11f, 1);
            _pdfPCell = new PdfPCell(new Phrase(" ", _fontstyle));
            _pdfPCell.Colspan = 1;
            _pdfPCell.HorizontalAlignment = Element.ALIGN_CENTER;
            _pdfPCell.ExtraParagraphSpace = 0;
            _pdfTable.AddCell(_pdfPCell);

            _fontstyle = FontFactory.GetFont("Tahoma", 11f, 1);
            _pdfPCell = new PdfPCell(new Phrase(" ", _fontstyle));
            _pdfPCell.Colspan = 3;
            _pdfPCell.HorizontalAlignment = Element.ALIGN_CENTER;
            _pdfPCell.ExtraParagraphSpace = 0;
            _pdfTable.AddCell(_pdfPCell);
            _pdfTable.CompleteRow();


            _fontstyle = FontFactory.GetFont("Tahoma", 11f, 1);
            _pdfPCell = new PdfPCell(new Phrase(" ", _fontstyle));
            _pdfPCell.Colspan = 1;
            _pdfPCell.HorizontalAlignment = Element.ALIGN_CENTER;
            _pdfPCell.ExtraParagraphSpace = 0;
            _pdfTable.AddCell(_pdfPCell);

            _fontstyle = FontFactory.GetFont("Tahoma", 11f, 1);
            _pdfPCell = new PdfPCell(new Phrase(" ", _fontstyle));
            _pdfPCell.Colspan = 3;
            _pdfPCell.HorizontalAlignment = Element.ALIGN_CENTER;
            _pdfPCell.ExtraParagraphSpace = 0;
            _pdfTable.AddCell(_pdfPCell);

            _fontstyle = FontFactory.GetFont("Tahoma", 11f, 1);
            _pdfPCell = new PdfPCell(new Phrase(" ", _fontstyle));
            _pdfPCell.Colspan = 1;
            _pdfPCell.HorizontalAlignment = Element.ALIGN_CENTER;
            _pdfPCell.ExtraParagraphSpace = 0;
            _pdfTable.AddCell(_pdfPCell);

            _fontstyle = FontFactory.GetFont("Tahoma", 11f, 1);
            _pdfPCell = new PdfPCell(new Phrase(" ", _fontstyle));
            _pdfPCell.Colspan = 3;
            _pdfPCell.HorizontalAlignment = Element.ALIGN_CENTER;
            _pdfPCell.ExtraParagraphSpace = 0;
            _pdfTable.AddCell(_pdfPCell);
            _pdfTable.CompleteRow();


            _fontstyle = FontFactory.GetFont("Tahoma", 11f, 1);
            _pdfPCell = new PdfPCell(new Phrase(" ", _fontstyle));
            _pdfPCell.Colspan = 1;
            _pdfPCell.HorizontalAlignment = Element.ALIGN_CENTER;
            _pdfPCell.ExtraParagraphSpace = 0;
            _pdfTable.AddCell(_pdfPCell);

            _fontstyle = FontFactory.GetFont("Tahoma", 11f, 1);
            _pdfPCell = new PdfPCell(new Phrase(" ", _fontstyle));
            _pdfPCell.Colspan = 3;
            _pdfPCell.HorizontalAlignment = Element.ALIGN_CENTER;
            _pdfPCell.ExtraParagraphSpace = 0;
            _pdfTable.AddCell(_pdfPCell);

            _fontstyle = FontFactory.GetFont("Tahoma", 11f, 1);
            _pdfPCell = new PdfPCell(new Phrase(" ", _fontstyle));
            _pdfPCell.Colspan = 1;
            _pdfPCell.HorizontalAlignment = Element.ALIGN_CENTER;
            _pdfPCell.ExtraParagraphSpace = 0;
            _pdfTable.AddCell(_pdfPCell);

            _fontstyle = FontFactory.GetFont("Tahoma", 11f, 1);
            _pdfPCell = new PdfPCell(new Phrase(" ", _fontstyle));
            _pdfPCell.Colspan = 3;
            _pdfPCell.HorizontalAlignment = Element.ALIGN_CENTER;
            _pdfPCell.ExtraParagraphSpace = 0;
            _pdfTable.AddCell(_pdfPCell);
            _pdfTable.CompleteRow();



            _fontstyle = FontFactory.GetFont("Tahoma", 11f, 1);
            _pdfPCell = new PdfPCell(new Phrase(" ", _fontstyle));
            _pdfPCell.Colspan = 1;
            _pdfPCell.HorizontalAlignment = Element.ALIGN_CENTER;
            _pdfPCell.ExtraParagraphSpace = 0;
            _pdfTable.AddCell(_pdfPCell);

            _fontstyle = FontFactory.GetFont("Tahoma", 11f, 1);
            _pdfPCell = new PdfPCell(new Phrase(" ", _fontstyle));
            _pdfPCell.Colspan = 3;
            _pdfPCell.HorizontalAlignment = Element.ALIGN_CENTER;
            _pdfPCell.ExtraParagraphSpace = 0;
            _pdfTable.AddCell(_pdfPCell);

            _fontstyle = FontFactory.GetFont("Tahoma", 11f, 1);
            _pdfPCell = new PdfPCell(new Phrase(" ", _fontstyle));
            _pdfPCell.Colspan = 1;
            _pdfPCell.HorizontalAlignment = Element.ALIGN_CENTER;
            _pdfPCell.ExtraParagraphSpace = 0;
            _pdfTable.AddCell(_pdfPCell);

            _fontstyle = FontFactory.GetFont("Tahoma", 11f, 1);
            _pdfPCell = new PdfPCell(new Phrase(" ", _fontstyle));
            _pdfPCell.Colspan = 3;
            _pdfPCell.HorizontalAlignment = Element.ALIGN_CENTER;
            _pdfPCell.ExtraParagraphSpace = 0;
            _pdfTable.AddCell(_pdfPCell);
            _pdfTable.CompleteRow();



            _fontstyle = FontFactory.GetFont("Tahoma", 11f, 1);
            _pdfPCell = new PdfPCell(new Phrase(" ", _fontstyle));
            _pdfPCell.Colspan = 1;
            _pdfPCell.HorizontalAlignment = Element.ALIGN_CENTER;
            _pdfPCell.ExtraParagraphSpace = 0;
            _pdfTable.AddCell(_pdfPCell);

            _fontstyle = FontFactory.GetFont("Tahoma", 11f, 1);
            _pdfPCell = new PdfPCell(new Phrase(" ", _fontstyle));
            _pdfPCell.Colspan = 3;
            _pdfPCell.HorizontalAlignment = Element.ALIGN_CENTER;
            _pdfPCell.ExtraParagraphSpace = 0;
            _pdfTable.AddCell(_pdfPCell);

            _fontstyle = FontFactory.GetFont("Tahoma", 11f, 1);
            _pdfPCell = new PdfPCell(new Phrase(" ", _fontstyle));
            _pdfPCell.Colspan = 1;
            _pdfPCell.HorizontalAlignment = Element.ALIGN_CENTER;
            _pdfPCell.ExtraParagraphSpace = 0;
            _pdfTable.AddCell(_pdfPCell);

            _fontstyle = FontFactory.GetFont("Tahoma", 11f, 1);
            _pdfPCell = new PdfPCell(new Phrase(" ", _fontstyle));
            _pdfPCell.Colspan = 3;
            _pdfPCell.HorizontalAlignment = Element.ALIGN_CENTER;
            _pdfPCell.ExtraParagraphSpace = 0;
            _pdfTable.AddCell(_pdfPCell);
            _pdfTable.CompleteRow();

            _fontstyle = FontFactory.GetFont("Tahoma", 2F, 1);
            _pdfPCell = new PdfPCell(new Phrase(" ", _fontstyle));
            _pdfPCell.Colspan = 8;
            _pdfPCell.HorizontalAlignment = Element.ALIGN_CENTER;
            _pdfPCell.Border = 0;
            _pdfPCell.BackgroundColor = BaseColor.WHITE;
            _pdfPCell.ExtraParagraphSpace = 0;
            _pdfTable.AddCell(_pdfPCell);
            _pdfTable.CompleteRow();

            _fontstyle = FontFactory.GetFont("Tahoma", 11f, 1);
            _pdfPCell = new PdfPCell(new Phrase("FIRMA Y CONFORMIDAD DE LA INSPECCION REALIZADA", _fontstyle));
            _pdfPCell.Colspan = 8;
            _pdfPCell.HorizontalAlignment = Element.ALIGN_CENTER;
            _pdfPCell.Border = 0;
            _pdfPCell.BackgroundColor = BaseColor.GRAY;
            _pdfPCell.ExtraParagraphSpace = 0;
            _pdfTable.AddCell(_pdfPCell);
            _pdfTable.CompleteRow();

            _fontstyle = FontFactory.GetFont("Tahoma", 11f, 1);
            _pdfPCell = new PdfPCell(new Phrase(" ", _fontstyle));
            _pdfPCell.Colspan = 8;
            _pdfPCell.HorizontalAlignment = Element.ALIGN_CENTER;
            _pdfPCell.Border = 0;
            _pdfPCell.ExtraParagraphSpace = 0;
            _pdfTable.AddCell(_pdfPCell);

            _fontstyle = FontFactory.GetFont("Tahoma", 11f, 1);
            _pdfPCell = new PdfPCell(new Phrase(" ", _fontstyle));
            _pdfPCell.Colspan = 8;
            _pdfPCell.HorizontalAlignment = Element.ALIGN_CENTER;
            _pdfPCell.Border = 0;
            _pdfPCell.ExtraParagraphSpace = 0;
            _pdfTable.AddCell(_pdfPCell);

            _fontstyle = FontFactory.GetFont("Tahoma", 11f, 1);
            _pdfPCell = new PdfPCell(new Phrase(" ", _fontstyle));
            _pdfPCell.Colspan = 8;
            _pdfPCell.HorizontalAlignment = Element.ALIGN_CENTER;
            _pdfPCell.Border = 0;
            _pdfPCell.ExtraParagraphSpace = 0;
            _pdfTable.AddCell(_pdfPCell);

            _fontstyle = FontFactory.GetFont("Tahoma", 11f, 1);
            _pdfPCell = new PdfPCell(new Phrase(" ", _fontstyle));
            _pdfPCell.Colspan = 8;
            _pdfPCell.HorizontalAlignment = Element.ALIGN_CENTER;

            _pdfPCell.VerticalAlignment = Element.ALIGN_MIDDLE;
            _pdfPCell.BackgroundColor = BaseColor.LIGHT_GRAY;
            _pdfPCell.BackgroundColor = BaseColor.WHITE;
            _pdfPCell.BorderColorLeft = BaseColor.WHITE;
            _pdfPCell.BorderColorRight = BaseColor.WHITE;
            _pdfPCell.BorderColorTop = BaseColor.WHITE;
            _pdfPCell.BorderColorBottom = BaseColor.BLACK;
            _pdfPCell.BorderWidthLeft = 1f;
            _pdfPCell.BorderWidthRight = 1f;
            _pdfPCell.BorderWidthTop = 1f;
            _pdfPCell.BorderWidthBottom = 1f;


            _pdfPCell.ExtraParagraphSpace = 0;
            _pdfTable.AddCell(_pdfPCell);


            _fontstyle = FontFactory.GetFont("Tahoma", 11f, 1);
            _pdfPCell = new PdfPCell(new Phrase("FIRMA DEL OPERADOR", _fontstyle));
            _pdfPCell.Colspan = 4;
            _pdfPCell.HorizontalAlignment = Element.ALIGN_CENTER;
            _pdfPCell.Border = 0;
            _pdfPCell.ExtraParagraphSpace = 0;
            _pdfTable.AddCell(_pdfPCell);

            _fontstyle = FontFactory.GetFont("Tahoma", 11f, 1);
            _pdfPCell = new PdfPCell(new Phrase("SUPERVISOR DE MANTENIMIENTO", _fontstyle));
            _pdfPCell.Colspan = 4;
            _pdfPCell.HorizontalAlignment = Element.ALIGN_CENTER;
            _pdfPCell.Border = 0;
            _pdfPCell.ExtraParagraphSpace = 0;
            _pdfTable.AddCell(_pdfPCell);
            _pdfTable.CompleteRow();

            _fontstyle = FontFactory.GetFont("Tahoma", 8f, 0);
            _pdfPCell = new PdfPCell(new Phrase("Nota: Colocar los símbolos en los recuadros, según corresponda en la verificación.", _fontstyle));
            _pdfPCell.Colspan = 8;
            _pdfPCell.HorizontalAlignment = Element.ALIGN_LEFT;
            _pdfPCell.Border = 0;
            _pdfPCell.ExtraParagraphSpace = 0;
            _pdfTable.AddCell(_pdfPCell);
            _pdfTable.CompleteRow();


            _fontstyle = FontFactory.GetFont("Tahoma", 8f, 0);
            _pdfPCell = new PdfPCell(new Phrase("* - Positivo, conforme, correcto estado, operativo, limpio, utilizable, visible, no roto, se tiene, se puede usar.", _fontstyle));
            _pdfPCell.Colspan = 8;
            _pdfPCell.HorizontalAlignment = Element.ALIGN_LEFT;
            _pdfPCell.Border = 0;
            _pdfPCell.ExtraParagraphSpace = 0;
            _pdfTable.AddCell(_pdfPCell);
            _pdfTable.CompleteRow();


            _fontstyle = FontFactory.GetFont("Tahoma", 8f, 0);
            _pdfPCell = new PdfPCell(new Phrase("X - Negativo, no conforme, mal estado, inoperativo, sucio, inutilizable, no visible, roto, no se tiene, no se puede usar.", _fontstyle));
            _pdfPCell.Colspan = 8;
            _pdfPCell.HorizontalAlignment = Element.ALIGN_LEFT;
            _pdfPCell.Border = 0;
            _pdfPCell.ExtraParagraphSpace = 0;
            _pdfTable.AddCell(_pdfPCell);
            _pdfTable.CompleteRow();

            _fontstyle = FontFactory.GetFont("Tahoma", 8f, 0);
            _pdfPCell = new PdfPCell(new Phrase("NA - No aplica.", _fontstyle));
            _pdfPCell.Colspan = 8;
            _pdfPCell.HorizontalAlignment = Element.ALIGN_LEFT;
            _pdfPCell.Border = 0;
            _pdfPCell.ExtraParagraphSpace = 0;
            _pdfTable.AddCell(_pdfPCell);
            _pdfTable.CompleteRow();

            _fontstyle = FontFactory.GetFont("Tahoma", 9f, 0);
            _pdfPCell = new PdfPCell(new Phrase(" ", _fontstyle));
            _pdfPCell.Colspan = 8;
            _pdfPCell.HorizontalAlignment = Element.ALIGN_RIGHT;
            _pdfPCell.VerticalAlignment = Element.ALIGN_MIDDLE;
            _pdfPCell.BackgroundColor = BaseColor.LIGHT_GRAY;
            _pdfPCell.BackgroundColor = BaseColor.WHITE;
            _pdfPCell.BorderColorLeft = BaseColor.WHITE;
            _pdfPCell.BorderColorRight = BaseColor.WHITE;
            _pdfPCell.BorderColorTop = BaseColor.WHITE;
            _pdfPCell.BorderColorBottom = BaseColor.BLACK;
            _pdfPCell.BorderWidthLeft = 1f;
            _pdfPCell.BorderWidthRight = 1f;
            _pdfPCell.BorderWidthTop = 1f;
            _pdfPCell.BorderWidthBottom = 1f;
            _pdfPCell.ExtraParagraphSpace = 0;
            _pdfTable.AddCell(_pdfPCell);
            _pdfTable.CompleteRow();

            _fontstyle = FontFactory.GetFont("Tahoma", 9f, 1);
            _pdfPCell = new PdfPCell(new Phrase("Jefatura de Mantenimiento", _fontstyle));
            _pdfPCell.Colspan = 8;
            _pdfPCell.HorizontalAlignment = Element.ALIGN_RIGHT;
            _pdfPCell.Border = 0;
            _pdfPCell.ExtraParagraphSpace = 0;
            _pdfTable.AddCell(_pdfPCell);
            _pdfTable.CompleteRow();

        }




    }
}