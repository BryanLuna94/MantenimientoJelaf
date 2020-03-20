using iTextSharp.text;
using iTextSharp.text.pdf;
using Mantenimiento.WebApp.ServiceMantenimiento;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;

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
            _pdfPCell.BackgroundColor = BaseColor.WHITE;
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
            _pdfPCell = new PdfPCell(new Phrase((ListAreBus.Count>0) ?ListAreBus[0].Are_Nombre.ToString():String.Empty, _fontstyle));
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
            _pdfPCell.BackgroundColor = BaseColor.WHITE;
            _pdfPCell.ExtraParagraphSpace = 0;
            _pdfTable.AddCell(_pdfPCell);
            _pdfTable.CompleteRow();

            _fontstyle = FontFactory.GetFont("Tahoma", 11f, 1);
            _pdfPCell = new PdfPCell(new Phrase("CODIGO", _fontstyle));
            _pdfPCell.Colspan = 2;
            _pdfPCell.HorizontalAlignment = Element.ALIGN_CENTER;
            _pdfPCell.Border = 0;
            _pdfPCell.BackgroundColor = BaseColor.WHITE;
            _pdfPCell.ExtraParagraphSpace = 0;
            _pdfTable.AddCell(_pdfPCell);

            _fontstyle = FontFactory.GetFont("Tahoma", 11f, 1);
            _pdfPCell = new PdfPCell(new Phrase("DESCRIPCIÓN", _fontstyle));
            _pdfPCell.Colspan = 4;
            _pdfPCell.HorizontalAlignment = Element.ALIGN_CENTER;
            _pdfPCell.Border = 0;
            _pdfPCell.BackgroundColor = BaseColor.WHITE;
            _pdfPCell.ExtraParagraphSpace = 0;
            _pdfTable.AddCell(_pdfPCell);

            _fontstyle = FontFactory.GetFont("Tahoma", 11f, 1);
            _pdfPCell = new PdfPCell(new Phrase("✓", _fontstyle));
            _pdfPCell.Colspan = 2;
            _pdfPCell.HorizontalAlignment = Element.ALIGN_CENTER;
            _pdfPCell.Border = 0;
            _pdfPCell.BackgroundColor = BaseColor.WHITE;
            _pdfPCell.ExtraParagraphSpace = 0;
            _pdfTable.AddCell(_pdfPCell);

            _pdfTable.CompleteRow();

            _fontstyle = FontFactory.GetFont("Tahoma", 6f, 0);

            List<string> sistemas = ListTareaSistemaEntity.Select(s => s.Sistema_Descripcion).Distinct().ToList();

            foreach (string itemS in sistemas)
            {
                _pdfPCell = new PdfPCell(new Phrase(itemS, _fontstyle));
                _pdfPCell.Colspan = 8;
                _pdfPCell.HorizontalAlignment = Element.ALIGN_LEFT;
                _pdfPCell.VerticalAlignment = Element.ALIGN_MIDDLE;
                _pdfPCell.BackgroundColor = BaseColor.WHITE;
                _pdfPCell.Border = 0;
                _pdfTable.AddCell(_pdfPCell);
                _pdfTable.CompleteRow();

                List<TareaSistemaEntity> lisTS = ListTareaSistemaEntity.Where(s => s.Sistema_Descripcion == itemS).ToList();
                foreach (TareaSistemaEntity tareaSistema in lisTS)
                {
                    _pdfPCell = new PdfPCell(new Phrase(tareaSistema.IdTarea.ToString(), _fontstyle));
                    _pdfPCell.Colspan = 2;
                    _pdfPCell.HorizontalAlignment = Element.ALIGN_CENTER;
                    _pdfPCell.VerticalAlignment = Element.ALIGN_MIDDLE;
                    _pdfPCell.BackgroundColor = BaseColor.WHITE;
                    _pdfPCell.Border = 1;
                    _pdfTable.AddCell(_pdfPCell);

                    _pdfPCell = new PdfPCell(new Phrase(tareaSistema.Tarea_Descripcion.ToString(), _fontstyle));
                    _pdfPCell.Colspan = 4;
                    _pdfPCell.HorizontalAlignment = Element.ALIGN_LEFT;
                    _pdfPCell.VerticalAlignment = Element.ALIGN_MIDDLE;
                    _pdfPCell.BackgroundColor = BaseColor.WHITE;
                    _pdfPCell.Border = 1;
                    _pdfTable.AddCell(_pdfPCell);

                    _pdfPCell = new PdfPCell(new Phrase("❒", _fontstyle));
                    _pdfPCell.Colspan = 2;
                    _pdfPCell.HorizontalAlignment = Element.ALIGN_CENTER;
                    _pdfPCell.VerticalAlignment = Element.ALIGN_MIDDLE;
                    _pdfPCell.BackgroundColor = BaseColor.WHITE;
                    _pdfPCell.Border = 1;
                    _pdfTable.AddCell(_pdfPCell);

                    _pdfTable.CompleteRow();

                }
            }


            _fontstyle = FontFactory.GetFont("Tahoma", 11f, 1);
            _pdfPCell = new PdfPCell(new Phrase("INSPECCION DE FRENOS Y NEUMATICOS", _fontstyle));
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
            _pdfPCell = new PdfPCell(jpg,true);
            _pdfPCell.Colspan = 4; 
            //_pdfPCell.Border = 1;
            _pdfPCell.HorizontalAlignment = Element.ALIGN_CENTER;
            _pdfPCell.ExtraParagraphSpace = 0;
            _pdfTable.AddCell(_pdfPCell);

            Image jpg2 = Image.GetInstance(URL + @"Images\" + "image_Frenos_Neumaticos.jpg");
            //PdfPCell imageCell = new PdfPCell(jpg);
            _pdfPCell = new PdfPCell(jpg2,true);
            _pdfPCell.Colspan = 4;
            //_pdfPCell.Border = 1;
            _pdfPCell.HorizontalAlignment = Element.ALIGN_CENTER;
            _pdfPCell.ExtraParagraphSpace = 0;
            _pdfTable.AddCell(_pdfPCell);

            _pdfTable.CompleteRow();


            _fontstyle = FontFactory.GetFont("Tahoma", 11f, 1);
            _pdfPCell = new PdfPCell(new Phrase("OBSERVACIONES Y/O TRABAJOS PENDIENTES", _fontstyle));
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
            _pdfPCell.ExtraParagraphSpace = 0;
            _pdfTable.AddCell(_pdfPCell);

            _fontstyle = FontFactory.GetFont("Tahoma", 11f, 1);
            _pdfPCell = new PdfPCell(new Phrase("DESCRIPCIÓN O MOTIVO", _fontstyle));
            _pdfPCell.Colspan = 3;
            _pdfPCell.HorizontalAlignment = Element.ALIGN_CENTER;
            _pdfPCell.ExtraParagraphSpace = 0;
            _pdfTable.AddCell(_pdfPCell);

            _fontstyle = FontFactory.GetFont("Tahoma", 11f, 1);
            _pdfPCell = new PdfPCell(new Phrase("COD", _fontstyle));
            _pdfPCell.Colspan = 1;
            _pdfPCell.HorizontalAlignment = Element.ALIGN_CENTER;
            _pdfPCell.ExtraParagraphSpace = 0;
            _pdfTable.AddCell(_pdfPCell);

            _fontstyle = FontFactory.GetFont("Tahoma", 11f, 1);
            _pdfPCell = new PdfPCell(new Phrase("DESCRIPCIÓN O MOTIVO", _fontstyle));
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
            _pdfPCell = new PdfPCell(new Phrase("FIRMA Y CONFORMIDAD DE LA INSPECCION REALIZADA", _fontstyle));
            _pdfPCell.Colspan = 8;
            _pdfPCell.HorizontalAlignment = Element.ALIGN_CENTER;
            _pdfPCell.Border = 0;
            _pdfPCell.BackgroundColor = BaseColor.WHITE;
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