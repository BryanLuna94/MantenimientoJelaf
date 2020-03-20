using iTextSharp.text;
using iTextSharp.text.pdf;
using Mantenimiento.WebApp.ServiceMantenimiento;
using System;
using System.Collections.Generic;
using System.IO;

namespace Mantenimiento.WebApp.Reports
{
    public class InformeOrdenMantenimientoReport
    {
        #region Declaraciones
        int _totalColumn = 8;
        Document _document;
        Font _fontstyle;

        PdfPTable _pdfTable = new PdfPTable(8);
        PdfPCell _pdfPCell;

        MemoryStream _memorystream = new MemoryStream();

        List<InformeOrdenMantenimientoList> informeOrdenMantenimientoList = new List<InformeOrdenMantenimientoList>();
        List<BaseEntity> empresasList = new List<BaseEntity>();
        List<FallasDEntity> fallasDEntityList = new List<FallasDEntity>();
        List<ODMdList> oDMdList = new List<ODMdList>();
        #endregion

        public byte[] PrepareReport(List<InformeOrdenMantenimientoList> informeOrdenMantList, List<BaseEntity> listEmpresas)
        {
            informeOrdenMantenimientoList = informeOrdenMantList;
            empresasList = listEmpresas;

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


            _pdfTable.HeaderRows = 7;

            _document.Add(_pdfTable);

            _document.Close();

            return _memorystream.ToArray();
        }

        private void ReportHeader()
        {
            _fontstyle = FontFactory.GetFont("Tahoma", 15f, 1);
            _pdfPCell = new PdfPCell(new Phrase(empresasList[0].Descripcion, _fontstyle));
            _pdfPCell.Colspan = 4;
            _pdfPCell.HorizontalAlignment = Element.ALIGN_LEFT;
            _pdfPCell.Border = 0;
            _pdfPCell.BackgroundColor = BaseColor.WHITE;
            _pdfPCell.ExtraParagraphSpace = 0;
            _pdfTable.AddCell(_pdfPCell);

            _fontstyle = FontFactory.GetFont("Tahoma", 9f, 1);
            _pdfPCell = new PdfPCell(new Phrase(string.Concat("Fecha Impresión : ", DateTime.Now.ToString("dd/MM/yyyy")), _fontstyle));
            _pdfPCell.Colspan = 4;
            _pdfPCell.HorizontalAlignment = Element.ALIGN_RIGHT;
            _pdfPCell.Border = 0;
            _pdfPCell.BackgroundColor = BaseColor.WHITE;
            _pdfPCell.ExtraParagraphSpace = 0;
            _pdfTable.AddCell(_pdfPCell);
            _pdfTable.CompleteRow();




            _fontstyle = FontFactory.GetFont("Tahoma", 15f, 1);
            _pdfPCell = new PdfPCell(new Phrase(string.Concat("INFORME N° :  ", informeOrdenMantenimientoList[0].NumeroInforme.ToString()), _fontstyle));
            _pdfPCell.Colspan = _totalColumn;
            _pdfPCell.HorizontalAlignment = Element.ALIGN_CENTER;
            _pdfPCell.Border = 0;
            _pdfPCell.BackgroundColor = BaseColor.WHITE;
            _pdfPCell.ExtraParagraphSpace = 0;
            _pdfTable.AddCell(_pdfPCell);
            _pdfTable.CompleteRow();


            _fontstyle = FontFactory.GetFont("Tahoma", 11f, 1);
            _pdfPCell = new PdfPCell(new Phrase(string.Concat("Fecha : ", informeOrdenMantenimientoList[0].Fecha), _fontstyle));
            _pdfPCell.Colspan = 2;
            _pdfPCell.HorizontalAlignment = Element.ALIGN_LEFT;
            _pdfPCell.Border = 0;
            _pdfPCell.BackgroundColor = BaseColor.WHITE;
            _pdfPCell.ExtraParagraphSpace = 0;
            _pdfTable.AddCell(_pdfPCell);

            _fontstyle = FontFactory.GetFont("Tahoma", 9f, 1);
            _pdfPCell = new PdfPCell(new Phrase(string.Concat("Fecha : ", informeOrdenMantenimientoList[0].Dia), _fontstyle));
            _pdfPCell.Colspan = 2;
            _pdfPCell.HorizontalAlignment = Element.ALIGN_LEFT;
            _pdfPCell.Border = 0;
            _pdfPCell.BackgroundColor = BaseColor.WHITE;
            _pdfPCell.ExtraParagraphSpace = 0;
            _pdfTable.AddCell(_pdfPCell);

            _fontstyle = FontFactory.GetFont("Tahoma", 9f, 1);
            _pdfPCell = new PdfPCell(new Phrase(string.Concat("Fecha Solicitada: ", informeOrdenMantenimientoList[0].FechaRegistro), _fontstyle));
            _pdfPCell.Colspan = 4;
            _pdfPCell.HorizontalAlignment = Element.ALIGN_RIGHT;
            _pdfPCell.Border = 0;
            _pdfPCell.BackgroundColor = BaseColor.WHITE;
            _pdfPCell.ExtraParagraphSpace = 0;
            _pdfTable.AddCell(_pdfPCell);
            _pdfTable.CompleteRow();

            _fontstyle = FontFactory.GetFont("Tahoma", 9f, 1);
            _pdfPCell = new PdfPCell(new Phrase(string.Concat("Bus : ", informeOrdenMantenimientoList[0].BusPlaca), _fontstyle));
            _pdfPCell.Colspan = 2;
            _pdfPCell.HorizontalAlignment = Element.ALIGN_LEFT;
            _pdfPCell.Border = 0;
            _pdfPCell.BackgroundColor = BaseColor.WHITE;
            _pdfPCell.ExtraParagraphSpace = 0;
            _pdfTable.AddCell(_pdfPCell);

            _fontstyle = FontFactory.GetFont("Tahoma", 9f, 1);
            _pdfPCell = new PdfPCell(new Phrase(string.Concat("Solicitante: ", informeOrdenMantenimientoList[0].Ben_Nombre), _fontstyle));
            _pdfPCell.Colspan = 6;
            _pdfPCell.HorizontalAlignment = Element.ALIGN_LEFT;
            _pdfPCell.Border = 0;
            _pdfPCell.BackgroundColor = BaseColor.WHITE;
            _pdfPCell.ExtraParagraphSpace = 0;
            _pdfTable.AddCell(_pdfPCell);
            _pdfTable.CompleteRow();

            _fontstyle = FontFactory.GetFont("Tahoma", 9f, 1);
            _pdfPCell = new PdfPCell(new Phrase(string.Concat("Ruta : ", informeOrdenMantenimientoList[0].Ofi_Nombre), _fontstyle));
            _pdfPCell.Colspan = _totalColumn;
            _pdfPCell.HorizontalAlignment = Element.ALIGN_LEFT;
            _pdfPCell.Border = 0;
            _pdfPCell.BackgroundColor = BaseColor.WHITE;
            _pdfPCell.ExtraParagraphSpace = 0;
            _pdfTable.AddCell(_pdfPCell);
            _pdfTable.CompleteRow();

            _fontstyle = FontFactory.GetFont("Tahoma", 9f, 1);
            _pdfPCell = new PdfPCell(new Phrase(string.Concat("Kilometráje : ", string.Format("{0:0,0.00}", informeOrdenMantenimientoList[0].KmUnidad)), _fontstyle));
            _pdfPCell.Colspan = _totalColumn;
            _pdfPCell.HorizontalAlignment = Element.ALIGN_LEFT;
            _pdfPCell.Border = 0;
            _pdfPCell.BackgroundColor = BaseColor.WHITE;
            _pdfPCell.ExtraParagraphSpace = 0;
            _pdfTable.AddCell(_pdfPCell);
            _pdfTable.CompleteRow();


        }

        private void ReportBody()
        {
            _fontstyle = FontFactory.GetFont("Tahoma", 6f, 1);
            _pdfPCell = new PdfPCell(new Phrase("Sistema", _fontstyle));
            _pdfPCell.Colspan = 2;
            _pdfPCell.HorizontalAlignment = Element.ALIGN_CENTER;
            _pdfPCell.VerticalAlignment = Element.ALIGN_MIDDLE;
            _pdfPCell.BackgroundColor = BaseColor.LIGHT_GRAY;
            _pdfPCell.BackgroundColor = BaseColor.WHITE;
            _pdfPCell.BorderColorLeft = BaseColor.WHITE;
            _pdfPCell.BorderColorRight = BaseColor.WHITE;
            _pdfPCell.BorderColorTop = BaseColor.BLACK;
            _pdfPCell.BorderColorBottom = BaseColor.BLACK;
            _pdfPCell.BorderWidthLeft = 1f;
            _pdfPCell.BorderWidthRight = 1f;
            _pdfPCell.BorderWidthTop = 1f;
            _pdfPCell.BorderWidthBottom = 1f;
            _pdfTable.AddCell(_pdfPCell);

            _fontstyle = FontFactory.GetFont("Tahoma", 6f, 1);
            _pdfPCell = new PdfPCell(new Phrase("Mecanico", _fontstyle));
            _pdfPCell.Colspan = 2;
            _pdfPCell.HorizontalAlignment = Element.ALIGN_CENTER;
            _pdfPCell.VerticalAlignment = Element.ALIGN_MIDDLE;
            _pdfPCell.BackgroundColor = BaseColor.LIGHT_GRAY;
            _pdfPCell.BackgroundColor = BaseColor.WHITE;
            _pdfPCell.BorderColorLeft = BaseColor.WHITE;
            _pdfPCell.BorderColorRight = BaseColor.WHITE;
            _pdfPCell.BorderColorTop = BaseColor.BLACK;
            _pdfPCell.BorderColorBottom = BaseColor.BLACK;
            _pdfPCell.BorderWidthLeft = 1f;
            _pdfPCell.BorderWidthRight = 1f;
            _pdfPCell.BorderWidthTop = 1f;
            _pdfPCell.BorderWidthBottom = 1f;
            _pdfTable.AddCell(_pdfPCell);

            _fontstyle = FontFactory.GetFont("Tahoma", 6f, 1);
            _pdfPCell = new PdfPCell(new Phrase("Observación", _fontstyle));
            _pdfPCell.Colspan = 2;
            _pdfPCell.HorizontalAlignment = Element.ALIGN_CENTER;
            _pdfPCell.VerticalAlignment = Element.ALIGN_MIDDLE;
            _pdfPCell.BackgroundColor = BaseColor.LIGHT_GRAY;
            _pdfPCell.BackgroundColor = BaseColor.WHITE;
            _pdfPCell.BorderColorLeft = BaseColor.WHITE;
            _pdfPCell.BorderColorRight = BaseColor.WHITE;
            _pdfPCell.BorderColorTop = BaseColor.BLACK;
            _pdfPCell.BorderColorBottom = BaseColor.BLACK;
            _pdfPCell.BorderWidthLeft = 1f;
            _pdfPCell.BorderWidthRight = 1f;
            _pdfPCell.BorderWidthTop = 1f;
            _pdfPCell.BorderWidthBottom = 1f;
            _pdfTable.AddCell(_pdfPCell);


            _fontstyle = FontFactory.GetFont("Tahoma", 6f, 1);
            _pdfPCell = new PdfPCell(new Phrase("Realizado", _fontstyle));
            _pdfPCell.Colspan = 2;
            _pdfPCell.HorizontalAlignment = Element.ALIGN_CENTER;
            _pdfPCell.VerticalAlignment = Element.ALIGN_MIDDLE;
            _pdfPCell.BackgroundColor = BaseColor.LIGHT_GRAY;
            _pdfPCell.BackgroundColor = BaseColor.WHITE;
            _pdfPCell.BorderColorLeft = BaseColor.WHITE;
            _pdfPCell.BorderColorRight = BaseColor.WHITE;
            _pdfPCell.BorderColorTop = BaseColor.BLACK;
            _pdfPCell.BorderColorBottom = BaseColor.BLACK;
            _pdfPCell.BorderWidthLeft = 1f;
            _pdfPCell.BorderWidthRight = 1f;
            _pdfPCell.BorderWidthTop = 1f;
            _pdfPCell.BorderWidthBottom = 1f;
            _pdfTable.AddCell(_pdfPCell);
            _pdfTable.CompleteRow();

            _fontstyle = FontFactory.GetFont("Tahoma", 6f, 0);
            foreach (InformeOrdenMantenimientoList informeOrdenMantenimientoList in informeOrdenMantenimientoList)
            {
                _pdfPCell = new PdfPCell(new Phrase(informeOrdenMantenimientoList.Tarea, _fontstyle));
                _pdfPCell.Colspan = 2;
                _pdfPCell.HorizontalAlignment = Element.ALIGN_LEFT;
                _pdfPCell.VerticalAlignment = Element.ALIGN_MIDDLE;
                _pdfPCell.BackgroundColor = BaseColor.WHITE;
                _pdfPCell.Border = 0;
                _pdfTable.AddCell(_pdfPCell);

                _pdfPCell = new PdfPCell(new Phrase(informeOrdenMantenimientoList.Mecanico, _fontstyle));
                _pdfPCell.Colspan = 2;
                _pdfPCell.HorizontalAlignment = Element.ALIGN_LEFT;
                _pdfPCell.VerticalAlignment = Element.ALIGN_MIDDLE;
                _pdfPCell.BackgroundColor = BaseColor.WHITE;
                _pdfPCell.Border = 0;
                _pdfTable.AddCell(_pdfPCell);

                _pdfPCell = new PdfPCell(new Phrase(informeOrdenMantenimientoList.Observacion, _fontstyle));
                _pdfPCell.Colspan = 2;
                _pdfPCell.HorizontalAlignment = Element.ALIGN_LEFT;
                _pdfPCell.VerticalAlignment = Element.ALIGN_MIDDLE;
                _pdfPCell.BackgroundColor = BaseColor.WHITE;
                _pdfPCell.Border = 0;
                _pdfTable.AddCell(_pdfPCell);

                _pdfPCell = new PdfPCell(new Phrase(informeOrdenMantenimientoList.Estado.ToString(), _fontstyle));
                _pdfPCell.Colspan = 2;
                _pdfPCell.HorizontalAlignment = Element.ALIGN_CENTER;
                _pdfPCell.VerticalAlignment = Element.ALIGN_MIDDLE;
                _pdfPCell.BackgroundColor = BaseColor.WHITE;
                _pdfPCell.Border = 0;
                _pdfTable.AddCell(_pdfPCell);

                _pdfTable.CompleteRow();

            }

            // ESPACIADO DOBLE - INICIO
            _fontstyle = FontFactory.GetFont("Tahoma", 20f, 1);
            _pdfPCell = new PdfPCell(new Phrase("   ", _fontstyle));
            _pdfPCell.Colspan = 8;
            _pdfPCell.HorizontalAlignment = Element.ALIGN_RIGHT;
            _pdfPCell.VerticalAlignment = Element.ALIGN_MIDDLE;
            _pdfPCell.BackgroundColor = BaseColor.LIGHT_GRAY;
            _pdfPCell.BackgroundColor = BaseColor.WHITE;
            _pdfPCell.BorderColorLeft = BaseColor.WHITE;
            _pdfPCell.BorderColorRight = BaseColor.WHITE;
            _pdfPCell.BorderColorTop = BaseColor.WHITE;
            _pdfPCell.BorderColorBottom = BaseColor.WHITE;
            _pdfPCell.BorderWidthLeft = 1f;
            _pdfPCell.BorderWidthRight = 1f;
            _pdfPCell.BorderWidthTop = 1f;
            _pdfPCell.BorderWidthBottom = 1f;
            _pdfPCell.PaddingBottom = 5f;
            _pdfTable.AddCell(_pdfPCell);

            _pdfTable.CompleteRow();


            _fontstyle = FontFactory.GetFont("Tahoma", 6f, 1);
            _pdfPCell = new PdfPCell(new Phrase("", _fontstyle));
            _pdfPCell.Colspan = 2;
            _pdfPCell.HorizontalAlignment = Element.ALIGN_RIGHT;
            _pdfPCell.VerticalAlignment = Element.ALIGN_MIDDLE;
            _pdfPCell.BackgroundColor = BaseColor.LIGHT_GRAY;
            _pdfPCell.BackgroundColor = BaseColor.WHITE;
            _pdfPCell.BorderColorLeft = BaseColor.WHITE;
            _pdfPCell.BorderColorRight = BaseColor.WHITE;
            _pdfPCell.BorderColorTop = BaseColor.WHITE;
            _pdfPCell.BorderColorBottom = BaseColor.WHITE;
            _pdfPCell.BorderWidthLeft = 1f;
            _pdfPCell.BorderWidthRight = 1f;
            _pdfPCell.BorderWidthTop = 1f;
            _pdfPCell.BorderWidthBottom = 1f;
            _pdfTable.AddCell(_pdfPCell);

            // ESPACIADO DOBLE - FIN

            _fontstyle = FontFactory.GetFont("Tahoma", 6f, 1);
            _pdfPCell = new PdfPCell(new Phrase("JEFE DE TALLER", _fontstyle));
            _pdfPCell.Colspan = 2;
            _pdfPCell.HorizontalAlignment = Element.ALIGN_CENTER;
            _pdfPCell.VerticalAlignment = Element.ALIGN_MIDDLE;
            _pdfPCell.BackgroundColor = BaseColor.LIGHT_GRAY;
            _pdfPCell.BackgroundColor = BaseColor.WHITE;
            _pdfPCell.BorderColorLeft = BaseColor.WHITE;
            _pdfPCell.BorderColorRight = BaseColor.WHITE;
            _pdfPCell.BorderColorTop = BaseColor.BLACK;
            _pdfPCell.BorderColorBottom = BaseColor.WHITE;
            _pdfPCell.BorderWidthLeft = 1f;
            _pdfPCell.BorderWidthRight = 1f;
            _pdfPCell.BorderWidthTop = 1f;
            _pdfPCell.BorderWidthBottom = 1f;
            _pdfTable.AddCell(_pdfPCell);


            _fontstyle = FontFactory.GetFont("Tahoma", 6f, 1);
            _pdfPCell = new PdfPCell(new Phrase("MECÁNICO", _fontstyle));
            _pdfPCell.Colspan = 2;
            _pdfPCell.HorizontalAlignment = Element.ALIGN_CENTER;
            _pdfPCell.VerticalAlignment = Element.ALIGN_MIDDLE;
            _pdfPCell.BackgroundColor = BaseColor.LIGHT_GRAY;
            _pdfPCell.BackgroundColor = BaseColor.WHITE;
            _pdfPCell.BorderColorLeft = BaseColor.WHITE;
            _pdfPCell.BorderColorRight = BaseColor.WHITE;
            _pdfPCell.BorderColorTop = BaseColor.BLACK;
            _pdfPCell.BorderColorBottom = BaseColor.WHITE;
            _pdfPCell.BorderWidthLeft = 1f;
            _pdfPCell.BorderWidthRight = 1f;
            _pdfPCell.BorderWidthTop = 1f;
            _pdfPCell.BorderWidthBottom = 1f;
            _pdfTable.AddCell(_pdfPCell);

            _fontstyle = FontFactory.GetFont("Tahoma", 6f, 1);
            _pdfPCell = new PdfPCell(new Phrase("", _fontstyle));
            _pdfPCell.Colspan = 2;
            _pdfPCell.HorizontalAlignment = Element.ALIGN_RIGHT;
            _pdfPCell.VerticalAlignment = Element.ALIGN_MIDDLE;
            _pdfPCell.BackgroundColor = BaseColor.LIGHT_GRAY;
            _pdfPCell.BackgroundColor = BaseColor.WHITE;
            _pdfPCell.BorderColorLeft = BaseColor.WHITE;
            _pdfPCell.BorderColorRight = BaseColor.WHITE;
            _pdfPCell.BorderColorTop = BaseColor.WHITE;
            _pdfPCell.BorderColorBottom = BaseColor.WHITE;
            _pdfPCell.BorderWidthLeft = 1f;
            _pdfPCell.BorderWidthRight = 1f;
            _pdfPCell.BorderWidthTop = 1f;
            _pdfPCell.BorderWidthBottom = 1f;
            _pdfTable.AddCell(_pdfPCell);

            _pdfTable.CompleteRow();


        }

        #region Reporte por Informe
        public byte[] PrepareReportInforme(List<InformeOrdenMantenimientoList> informeOrdenMantList, List<BaseEntity> listEmpresas, List<FallasDEntity> FallasDEntityList, List<ODMdList> ODMdList)
        {
            informeOrdenMantenimientoList = informeOrdenMantList;
            empresasList = listEmpresas;
            fallasDEntityList = FallasDEntityList;
            oDMdList = ODMdList;

            _document = new Document(PageSize.A4, 0f, 0f, 0f, 0f);
            _document.SetPageSize(PageSize.A4);
            _document.SetMargins(20f, 20f, 20f, 20f);

            _pdfTable.WidthPercentage = 100;
            _pdfTable.HorizontalAlignment = Element.ALIGN_LEFT;


            _fontstyle = FontFactory.GetFont("Tahoma", 8f, 1);

            PdfWriter.GetInstance(_document, _memorystream);
            _document.Open();
    
            _pdfTable.SetWidths(new float[] { 20f, 20f, 20f, 20f, 20f, 20f, 20f, 20f });


            
            this.ReportHeaderInforme();
            if (fallasDEntityList.Count>0)
                this.ReportBodyInformeFallas();
            this.ReportBodyInforme();
            if (oDMdList.Count >0)
                this.ReportBodyInformeRepuesto();




            _pdfTable.HeaderRows = 7;
      

            _document.Add(_pdfTable);


            _document.Close();

            return _memorystream.ToArray();
        }

        private void ReportHeaderInforme()
        {
            _fontstyle = FontFactory.GetFont("Tahoma", 15f, 1);
            _pdfPCell = new PdfPCell(new Phrase(empresasList[0].Descripcion, _fontstyle));
            _pdfPCell.Colspan = 4;
            _pdfPCell.HorizontalAlignment = Element.ALIGN_LEFT;
            _pdfPCell.Border = 0;
            _pdfPCell.BackgroundColor = BaseColor.WHITE;
            _pdfPCell.ExtraParagraphSpace = 0;
            _pdfTable.AddCell(_pdfPCell);

            _fontstyle = FontFactory.GetFont("Tahoma", 9f, 1);
            _pdfPCell = new PdfPCell(new Phrase(string.Concat("Fecha Impresión : ", DateTime.Now.ToString("dd/MM/yyyy")), _fontstyle));
            _pdfPCell.Colspan = 4;
            _pdfPCell.HorizontalAlignment = Element.ALIGN_RIGHT;
            _pdfPCell.Border = 0;
            _pdfPCell.BackgroundColor = BaseColor.WHITE;
            _pdfPCell.ExtraParagraphSpace = 0;
            _pdfTable.AddCell(_pdfPCell);
            _pdfTable.CompleteRow();


            _fontstyle = FontFactory.GetFont("Tahoma", 15f, 1);
            _pdfPCell = new PdfPCell(new Phrase(string.Concat("INFORME N° :  ",(informeOrdenMantenimientoList.Count>0? informeOrdenMantenimientoList[0].NumeroInforme.ToString():string.Empty)), _fontstyle));
            _pdfPCell.Colspan = _totalColumn;
            _pdfPCell.HorizontalAlignment = Element.ALIGN_CENTER;
            _pdfPCell.Border = 0;
            _pdfPCell.BackgroundColor = BaseColor.WHITE;
            _pdfPCell.ExtraParagraphSpace = 0;
            _pdfTable.AddCell(_pdfPCell);
            _pdfTable.CompleteRow();


            _fontstyle = FontFactory.GetFont("Tahoma", 11f, 1);
            _pdfPCell = new PdfPCell(new Phrase(string.Concat("Fecha : ", (informeOrdenMantenimientoList.Count > 0 ? informeOrdenMantenimientoList[0].Fecha: string.Empty)), _fontstyle));
            _pdfPCell.Colspan = 2;
            _pdfPCell.HorizontalAlignment = Element.ALIGN_LEFT;
            _pdfPCell.Border = 0;
            _pdfPCell.BackgroundColor = BaseColor.WHITE;
            _pdfPCell.ExtraParagraphSpace = 0;
            _pdfTable.AddCell(_pdfPCell);

            _fontstyle = FontFactory.GetFont("Tahoma", 9f, 1);
            _pdfPCell = new PdfPCell(new Phrase(string.Concat("Fecha : ", (informeOrdenMantenimientoList.Count > 0 ? informeOrdenMantenimientoList[0].Dia:string.Empty)), _fontstyle));
            _pdfPCell.Colspan = 2;
            _pdfPCell.HorizontalAlignment = Element.ALIGN_LEFT;
            _pdfPCell.Border = 0;
            _pdfPCell.BackgroundColor = BaseColor.WHITE;
            _pdfPCell.ExtraParagraphSpace = 0;
            _pdfTable.AddCell(_pdfPCell);

            _fontstyle = FontFactory.GetFont("Tahoma", 9f, 1);
            _pdfPCell = new PdfPCell(new Phrase(string.Concat("Fecha Solicitada: ", (informeOrdenMantenimientoList.Count > 0 ? informeOrdenMantenimientoList[0].FechaRegistro:string.Empty)), _fontstyle));
            _pdfPCell.Colspan = 4;
            _pdfPCell.HorizontalAlignment = Element.ALIGN_RIGHT;
            _pdfPCell.Border = 0;
            _pdfPCell.BackgroundColor = BaseColor.WHITE;
            _pdfPCell.ExtraParagraphSpace = 0;
            _pdfTable.AddCell(_pdfPCell);
            _pdfTable.CompleteRow();

            _fontstyle = FontFactory.GetFont("Tahoma", 9f, 1);
            _pdfPCell = new PdfPCell(new Phrase(string.Concat("Bus : ", (informeOrdenMantenimientoList.Count > 0 ? informeOrdenMantenimientoList[0].BusPlaca:string.Empty)), _fontstyle));
            _pdfPCell.Colspan = 2;
            _pdfPCell.HorizontalAlignment = Element.ALIGN_LEFT;
            _pdfPCell.Border = 0;
            _pdfPCell.BackgroundColor = BaseColor.WHITE;
            _pdfPCell.ExtraParagraphSpace = 0;
            _pdfTable.AddCell(_pdfPCell);

            _fontstyle = FontFactory.GetFont("Tahoma", 9f, 1);
            _pdfPCell = new PdfPCell(new Phrase(string.Concat("Solicitante: ", (informeOrdenMantenimientoList.Count > 0 ? informeOrdenMantenimientoList[0].Ben_Nombre:string.Empty)), _fontstyle));
            _pdfPCell.Colspan = 6;
            _pdfPCell.HorizontalAlignment = Element.ALIGN_LEFT;
            _pdfPCell.Border = 0;
            _pdfPCell.BackgroundColor = BaseColor.WHITE;
            _pdfPCell.ExtraParagraphSpace = 0;
            _pdfTable.AddCell(_pdfPCell);
            _pdfTable.CompleteRow();

            _fontstyle = FontFactory.GetFont("Tahoma", 9f, 1);
            _pdfPCell = new PdfPCell(new Phrase(string.Concat("Ruta : ", (informeOrdenMantenimientoList.Count > 0 ? informeOrdenMantenimientoList[0].Ofi_Nombre:string.Empty)), _fontstyle));
            _pdfPCell.Colspan = _totalColumn;
            _pdfPCell.HorizontalAlignment = Element.ALIGN_LEFT;
            _pdfPCell.Border = 0;
            _pdfPCell.BackgroundColor = BaseColor.WHITE;
            _pdfPCell.ExtraParagraphSpace = 0;
            _pdfTable.AddCell(_pdfPCell);
            _pdfTable.CompleteRow();

            _fontstyle = FontFactory.GetFont("Tahoma", 9f, 1);
            _pdfPCell = new PdfPCell(new Phrase(string.Concat("Kilometráje : ", (informeOrdenMantenimientoList.Count > 0 ? string.Format("{0:0,0.00}", informeOrdenMantenimientoList[0].KmUnidad):string.Empty)), _fontstyle));
            _pdfPCell.Colspan = _totalColumn;
            _pdfPCell.HorizontalAlignment = Element.ALIGN_LEFT;
            _pdfPCell.Border = 0;
            _pdfPCell.BackgroundColor = BaseColor.WHITE;
            _pdfPCell.ExtraParagraphSpace = 0;
            _pdfTable.AddCell(_pdfPCell);
            _pdfTable.CompleteRow();

            _fontstyle = FontFactory.GetFont("Tahoma", 10f, 1);
            _pdfPCell = new PdfPCell(new Phrase("   ", _fontstyle));
            _pdfPCell.Colspan = 8;
            _pdfPCell.HorizontalAlignment = Element.ALIGN_RIGHT;
            _pdfPCell.VerticalAlignment = Element.ALIGN_MIDDLE;
            _pdfPCell.BackgroundColor = BaseColor.LIGHT_GRAY;
            _pdfPCell.BackgroundColor = BaseColor.WHITE;
            _pdfPCell.BorderColorLeft = BaseColor.WHITE;
            _pdfPCell.BorderColorRight = BaseColor.WHITE;
            _pdfPCell.BorderColorTop = BaseColor.WHITE;
            _pdfPCell.BorderColorBottom = BaseColor.WHITE;
            _pdfPCell.BorderWidthLeft = 1f;
            _pdfPCell.BorderWidthRight = 1f;
            _pdfPCell.BorderWidthTop = 1f;
            _pdfPCell.BorderWidthBottom = 1f;
            _pdfPCell.PaddingBottom = 2f;
            _pdfTable.AddCell(_pdfPCell);
            _pdfTable.CompleteRow();

        }

        private void ReportBodyInformeFallas()
        {
            _fontstyle = FontFactory.GetFont("Tahoma", 9f, 1);
            _pdfPCell = new PdfPCell(new Phrase("LISTA DE FALLAS", _fontstyle));
            _pdfPCell.Colspan = 8;
            _pdfPCell.HorizontalAlignment = Element.ALIGN_LEFT;
            _pdfPCell.Border = 0;
            _pdfPCell.BackgroundColor = BaseColor.WHITE;
            _pdfPCell.ExtraParagraphSpace = 0;
            _pdfTable.AddCell(_pdfPCell);
            _pdfTable.CompleteRow();

            _fontstyle = FontFactory.GetFont("Tahoma", 6f, 1);
            _pdfPCell = new PdfPCell(new Phrase("Observación", _fontstyle));
            _pdfPCell.Colspan = 4;
            _pdfPCell.HorizontalAlignment = Element.ALIGN_CENTER;
            _pdfPCell.VerticalAlignment = Element.ALIGN_MIDDLE;
            _pdfPCell.BackgroundColor = BaseColor.LIGHT_GRAY;
            _pdfPCell.BackgroundColor = BaseColor.WHITE;
            _pdfPCell.BorderColorLeft = BaseColor.WHITE;
            _pdfPCell.BorderColorRight = BaseColor.WHITE;
            _pdfPCell.BorderColorTop = BaseColor.BLACK;
            _pdfPCell.BorderColorBottom = BaseColor.BLACK;
            _pdfPCell.BorderWidthLeft = 1f;
            _pdfPCell.BorderWidthRight = 1f;
            _pdfPCell.BorderWidthTop = 1f;
            _pdfPCell.BorderWidthBottom = 1f;
            _pdfTable.AddCell(_pdfPCell);

            _fontstyle = FontFactory.GetFont("Tahoma", 6f, 1);
            _pdfPCell = new PdfPCell(new Phrase("Estado", _fontstyle));
            _pdfPCell.Colspan = 4;
            _pdfPCell.HorizontalAlignment = Element.ALIGN_CENTER;
            _pdfPCell.VerticalAlignment = Element.ALIGN_MIDDLE;
            _pdfPCell.BackgroundColor = BaseColor.LIGHT_GRAY;
            _pdfPCell.BackgroundColor = BaseColor.WHITE;
            _pdfPCell.BorderColorLeft = BaseColor.WHITE;
            _pdfPCell.BorderColorRight = BaseColor.WHITE;
            _pdfPCell.BorderColorTop = BaseColor.BLACK;
            _pdfPCell.BorderColorBottom = BaseColor.BLACK;
            _pdfPCell.BorderWidthLeft = 1f;
            _pdfPCell.BorderWidthRight = 1f;
            _pdfPCell.BorderWidthTop = 1f;
            _pdfPCell.BorderWidthBottom = 1f;
            _pdfTable.AddCell(_pdfPCell);
            _pdfTable.CompleteRow();

            _fontstyle = FontFactory.GetFont("Tahoma", 6f, 0);
            foreach (FallasDEntity FallasDEntity in fallasDEntityList)
            {
                _pdfPCell = new PdfPCell(new Phrase(FallasDEntity.Observacion, _fontstyle));
                _pdfPCell.Colspan = 4;
                _pdfPCell.HorizontalAlignment = Element.ALIGN_LEFT;
                _pdfPCell.VerticalAlignment = Element.ALIGN_MIDDLE;
                _pdfPCell.BackgroundColor = BaseColor.WHITE;
                _pdfPCell.Border = 0;
                _pdfTable.AddCell(_pdfPCell);

                _pdfPCell = new PdfPCell(new Phrase(FallasDEntity.Estado.ToString(), _fontstyle));
                _pdfPCell.Colspan = 4;
                _pdfPCell.HorizontalAlignment = Element.ALIGN_CENTER;
                _pdfPCell.VerticalAlignment = Element.ALIGN_MIDDLE;
                _pdfPCell.BackgroundColor = BaseColor.WHITE;
                _pdfPCell.Border = 0;
                _pdfTable.AddCell(_pdfPCell);

                _pdfTable.CompleteRow();

            }

            _fontstyle = FontFactory.GetFont("Tahoma", 20f, 1);
            _pdfPCell = new PdfPCell(new Phrase("   ", _fontstyle));
            _pdfPCell.Colspan = 8;
            _pdfPCell.HorizontalAlignment = Element.ALIGN_RIGHT;
            _pdfPCell.VerticalAlignment = Element.ALIGN_MIDDLE;
            _pdfPCell.BackgroundColor = BaseColor.LIGHT_GRAY;
            _pdfPCell.BackgroundColor = BaseColor.WHITE;
            _pdfPCell.BorderColorLeft = BaseColor.WHITE;
            _pdfPCell.BorderColorRight = BaseColor.WHITE;
            _pdfPCell.BorderColorTop = BaseColor.WHITE;
            _pdfPCell.BorderColorBottom = BaseColor.WHITE;
            _pdfPCell.BorderWidthLeft = 1f;
            _pdfPCell.BorderWidthRight = 1f;
            _pdfPCell.BorderWidthTop = 1f;
            _pdfPCell.BorderWidthBottom = 1f;
            _pdfPCell.PaddingBottom = 5f;
            _pdfTable.AddCell(_pdfPCell);
            _pdfTable.CompleteRow();


        }

        private void ReportBodyInforme()
        {
 
            _fontstyle = FontFactory.GetFont("Tahoma", 6f, 1);
            _pdfPCell = new PdfPCell(new Phrase("Sistema", _fontstyle));
            _pdfPCell.Colspan = 2;
            _pdfPCell.HorizontalAlignment = Element.ALIGN_CENTER;
            _pdfPCell.VerticalAlignment = Element.ALIGN_MIDDLE;
            _pdfPCell.BackgroundColor = BaseColor.LIGHT_GRAY;
            _pdfPCell.BackgroundColor = BaseColor.WHITE;
            _pdfPCell.BorderColorLeft = BaseColor.WHITE;
            _pdfPCell.BorderColorRight = BaseColor.WHITE;
            _pdfPCell.BorderColorTop = BaseColor.BLACK;
            _pdfPCell.BorderColorBottom = BaseColor.BLACK;
            _pdfPCell.BorderWidthLeft = 1f;
            _pdfPCell.BorderWidthRight = 1f;
            _pdfPCell.BorderWidthTop = 1f;
            _pdfPCell.BorderWidthBottom = 1f;
            _pdfTable.AddCell(_pdfPCell);

            _fontstyle = FontFactory.GetFont("Tahoma", 6f, 1);
            _pdfPCell = new PdfPCell(new Phrase("Mecanico", _fontstyle));
            _pdfPCell.Colspan = 1;
            _pdfPCell.HorizontalAlignment = Element.ALIGN_CENTER;
            _pdfPCell.VerticalAlignment = Element.ALIGN_MIDDLE;
            _pdfPCell.BackgroundColor = BaseColor.LIGHT_GRAY;
            _pdfPCell.BackgroundColor = BaseColor.WHITE;
            _pdfPCell.BorderColorLeft = BaseColor.WHITE;
            _pdfPCell.BorderColorRight = BaseColor.WHITE;
            _pdfPCell.BorderColorTop = BaseColor.BLACK;
            _pdfPCell.BorderColorBottom = BaseColor.BLACK;
            _pdfPCell.BorderWidthLeft = 1f;
            _pdfPCell.BorderWidthRight = 1f;
            _pdfPCell.BorderWidthTop = 1f;
            _pdfPCell.BorderWidthBottom = 1f;
            _pdfTable.AddCell(_pdfPCell);

            _fontstyle = FontFactory.GetFont("Tahoma", 6f, 1);
            _pdfPCell = new PdfPCell(new Phrase("Observación", _fontstyle));
            _pdfPCell.Colspan = 2;
            _pdfPCell.HorizontalAlignment = Element.ALIGN_CENTER;
            _pdfPCell.VerticalAlignment = Element.ALIGN_MIDDLE;
            _pdfPCell.BackgroundColor = BaseColor.LIGHT_GRAY;
            _pdfPCell.BackgroundColor = BaseColor.WHITE;
            _pdfPCell.BorderColorLeft = BaseColor.WHITE;
            _pdfPCell.BorderColorRight = BaseColor.WHITE;
            _pdfPCell.BorderColorTop = BaseColor.BLACK;
            _pdfPCell.BorderColorBottom = BaseColor.BLACK;
            _pdfPCell.BorderWidthLeft = 1f;
            _pdfPCell.BorderWidthRight = 1f;
            _pdfPCell.BorderWidthTop = 1f;
            _pdfPCell.BorderWidthBottom = 1f;
            _pdfTable.AddCell(_pdfPCell);


            _fontstyle = FontFactory.GetFont("Tahoma", 6f, 1);
            _pdfPCell = new PdfPCell(new Phrase("Realizado", _fontstyle));
            _pdfPCell.Colspan = 1;
            _pdfPCell.HorizontalAlignment = Element.ALIGN_CENTER;
            _pdfPCell.VerticalAlignment = Element.ALIGN_MIDDLE;
            _pdfPCell.BackgroundColor = BaseColor.LIGHT_GRAY;
            _pdfPCell.BackgroundColor = BaseColor.WHITE;
            _pdfPCell.BorderColorLeft = BaseColor.WHITE;
            _pdfPCell.BorderColorRight = BaseColor.WHITE;
            _pdfPCell.BorderColorTop = BaseColor.BLACK;
            _pdfPCell.BorderColorBottom = BaseColor.BLACK;
            _pdfPCell.BorderWidthLeft = 1f;
            _pdfPCell.BorderWidthRight = 1f;
            _pdfPCell.BorderWidthTop = 1f;
            _pdfPCell.BorderWidthBottom = 1f;
            _pdfTable.AddCell(_pdfPCell);

            _fontstyle = FontFactory.GetFont("Tahoma", 6f, 1);
            _pdfPCell = new PdfPCell(new Phrase("Duración", _fontstyle));
            _pdfPCell.Colspan = 1;
            _pdfPCell.HorizontalAlignment = Element.ALIGN_CENTER;
            _pdfPCell.VerticalAlignment = Element.ALIGN_MIDDLE;
            _pdfPCell.BackgroundColor = BaseColor.LIGHT_GRAY;
            _pdfPCell.BackgroundColor = BaseColor.WHITE;
            _pdfPCell.BorderColorLeft = BaseColor.WHITE;
            _pdfPCell.BorderColorRight = BaseColor.WHITE;
            _pdfPCell.BorderColorTop = BaseColor.BLACK;
            _pdfPCell.BorderColorBottom = BaseColor.BLACK;
            _pdfPCell.BorderWidthLeft = 1f;
            _pdfPCell.BorderWidthRight = 1f;
            _pdfPCell.BorderWidthTop = 1f;
            _pdfPCell.BorderWidthBottom = 1f;
            _pdfTable.AddCell(_pdfPCell);

            _fontstyle = FontFactory.GetFont("Tahoma", 6f, 1);
            _pdfPCell = new PdfPCell(new Phrase("Firma", _fontstyle));
            _pdfPCell.Colspan = 1;
            _pdfPCell.HorizontalAlignment = Element.ALIGN_CENTER;
            _pdfPCell.VerticalAlignment = Element.ALIGN_MIDDLE;
            _pdfPCell.BackgroundColor = BaseColor.LIGHT_GRAY;
            _pdfPCell.BackgroundColor = BaseColor.WHITE;
            _pdfPCell.BorderColorLeft = BaseColor.WHITE;
            _pdfPCell.BorderColorRight = BaseColor.WHITE;
            _pdfPCell.BorderColorTop = BaseColor.BLACK;
            _pdfPCell.BorderColorBottom = BaseColor.BLACK;
            _pdfPCell.BorderWidthLeft = 1f;
            _pdfPCell.BorderWidthRight = 1f;
            _pdfPCell.BorderWidthTop = 1f;
            _pdfPCell.BorderWidthBottom = 1f;
            _pdfTable.AddCell(_pdfPCell);
            _pdfTable.CompleteRow();

            _fontstyle = FontFactory.GetFont("Tahoma", 6f, 0);
            foreach (InformeOrdenMantenimientoList informeOrdenMantenimientoList in informeOrdenMantenimientoList)
            {
                _pdfPCell = new PdfPCell(new Phrase(informeOrdenMantenimientoList.Tarea, _fontstyle));
                _pdfPCell.Colspan = 2;
                _pdfPCell.HorizontalAlignment = Element.ALIGN_LEFT;
                _pdfPCell.VerticalAlignment = Element.ALIGN_MIDDLE;
                _pdfPCell.BackgroundColor = BaseColor.WHITE;
                _pdfPCell.Border = 0;
                _pdfTable.AddCell(_pdfPCell);

                _pdfPCell = new PdfPCell(new Phrase(informeOrdenMantenimientoList.Mecanico, _fontstyle));
                _pdfPCell.Colspan = 1;
                _pdfPCell.HorizontalAlignment = Element.ALIGN_LEFT;
                _pdfPCell.VerticalAlignment = Element.ALIGN_MIDDLE;
                _pdfPCell.BackgroundColor = BaseColor.WHITE;
                _pdfPCell.Border = 0;
                _pdfTable.AddCell(_pdfPCell);

                _pdfPCell = new PdfPCell(new Phrase(informeOrdenMantenimientoList.Observacion, _fontstyle));
                _pdfPCell.Colspan = 2;
                _pdfPCell.HorizontalAlignment = Element.ALIGN_LEFT;
                _pdfPCell.VerticalAlignment = Element.ALIGN_MIDDLE;
                _pdfPCell.BackgroundColor = BaseColor.WHITE;
                _pdfPCell.Border = 0;
                _pdfTable.AddCell(_pdfPCell);

                _pdfPCell = new PdfPCell(new Phrase(informeOrdenMantenimientoList.Estado.ToString(), _fontstyle));
                _pdfPCell.Colspan = 1;
                _pdfPCell.HorizontalAlignment = Element.ALIGN_CENTER;
                _pdfPCell.VerticalAlignment = Element.ALIGN_MIDDLE;
                _pdfPCell.BackgroundColor = BaseColor.WHITE;
                _pdfPCell.Border = 0;
                _pdfTable.AddCell(_pdfPCell);

                _pdfPCell = new PdfPCell(new Phrase("", _fontstyle));
                _pdfPCell.Colspan = 1;
                _pdfPCell.HorizontalAlignment = Element.ALIGN_CENTER;
                _pdfPCell.VerticalAlignment = Element.ALIGN_MIDDLE;
                _pdfPCell.BackgroundColor = BaseColor.WHITE;
                _pdfPCell.Border = 0;
                _pdfTable.AddCell(_pdfPCell);

                _pdfPCell = new PdfPCell(new Phrase("", _fontstyle));
                _pdfPCell.Colspan = 1;
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
                //_pdfPCell.BorderWidthTop = 1f;
                _pdfPCell.BorderWidthBottom = 1f;
                _pdfTable.AddCell(_pdfPCell);

                _pdfTable.CompleteRow();

            }
            // ESPACIADO DOBLE - INICIO
            _fontstyle = FontFactory.GetFont("Tahoma", 20f, 1);
            _pdfPCell = new PdfPCell(new Phrase("   ", _fontstyle));
            _pdfPCell.Colspan = 8;
            _pdfPCell.HorizontalAlignment = Element.ALIGN_RIGHT;
            _pdfPCell.VerticalAlignment = Element.ALIGN_MIDDLE;
            _pdfPCell.BackgroundColor = BaseColor.LIGHT_GRAY;
            _pdfPCell.BackgroundColor = BaseColor.WHITE;
            _pdfPCell.BorderColorLeft = BaseColor.WHITE;
            _pdfPCell.BorderColorRight = BaseColor.WHITE;
            _pdfPCell.BorderColorTop = BaseColor.WHITE;
            _pdfPCell.BorderColorBottom = BaseColor.WHITE;
            _pdfPCell.BorderWidthLeft = 1f;
            _pdfPCell.BorderWidthRight = 1f;
            _pdfPCell.BorderWidthTop = 1f;
            _pdfPCell.BorderWidthBottom = 1f;
            _pdfPCell.PaddingBottom = 5f;
            _pdfTable.AddCell(_pdfPCell);

            _pdfTable.CompleteRow();


        }

        private void ReportBodyInformeRepuesto()
        {
            _fontstyle = FontFactory.GetFont("Tahoma", 9f, 1);
            _pdfPCell = new PdfPCell(new Phrase("LISTA DE REPUESTOS", _fontstyle));
            _pdfPCell.Colspan = 8;
            _pdfPCell.HorizontalAlignment = Element.ALIGN_LEFT;
            _pdfPCell.Border = 0;
            _pdfPCell.BackgroundColor = BaseColor.WHITE;
            _pdfPCell.ExtraParagraphSpace = 0;
            _pdfTable.AddCell(_pdfPCell);
            _pdfTable.CompleteRow();

            _fontstyle = FontFactory.GetFont("Tahoma", 6f, 1);
            _pdfPCell = new PdfPCell(new Phrase("Fecha", _fontstyle));
            _pdfPCell.Colspan = 1;
            _pdfPCell.HorizontalAlignment = Element.ALIGN_CENTER;
            _pdfPCell.VerticalAlignment = Element.ALIGN_MIDDLE;
            _pdfPCell.BackgroundColor = BaseColor.LIGHT_GRAY;
            _pdfPCell.BackgroundColor = BaseColor.WHITE;
            _pdfPCell.BorderColorLeft = BaseColor.WHITE;
            _pdfPCell.BorderColorRight = BaseColor.WHITE;
            _pdfPCell.BorderColorTop = BaseColor.BLACK;
            _pdfPCell.BorderColorBottom = BaseColor.BLACK;
            _pdfPCell.BorderWidthLeft = 1f;
            _pdfPCell.BorderWidthRight = 1f;
            _pdfPCell.BorderWidthTop = 1f;
            _pdfPCell.BorderWidthBottom = 1f;
            _pdfTable.AddCell(_pdfPCell);

            _fontstyle = FontFactory.GetFont("Tahoma", 6f, 1);
            _pdfPCell = new PdfPCell(new Phrase("Código", _fontstyle));
            _pdfPCell.Colspan = 1;
            _pdfPCell.HorizontalAlignment = Element.ALIGN_CENTER;
            _pdfPCell.VerticalAlignment = Element.ALIGN_MIDDLE;
            _pdfPCell.BackgroundColor = BaseColor.LIGHT_GRAY;
            _pdfPCell.BackgroundColor = BaseColor.WHITE;
            _pdfPCell.BorderColorLeft = BaseColor.WHITE;
            _pdfPCell.BorderColorRight = BaseColor.WHITE;
            _pdfPCell.BorderColorTop = BaseColor.BLACK;
            _pdfPCell.BorderColorBottom = BaseColor.BLACK;
            _pdfPCell.BorderWidthLeft = 1f;
            _pdfPCell.BorderWidthRight = 1f;
            _pdfPCell.BorderWidthTop = 1f;
            _pdfPCell.BorderWidthBottom = 1f;
            _pdfTable.AddCell(_pdfPCell);

            _fontstyle = FontFactory.GetFont("Tahoma", 6f, 1);
            _pdfPCell = new PdfPCell(new Phrase("Original", _fontstyle));
            _pdfPCell.Colspan = 2;
            _pdfPCell.HorizontalAlignment = Element.ALIGN_CENTER;
            _pdfPCell.VerticalAlignment = Element.ALIGN_MIDDLE;
            _pdfPCell.BackgroundColor = BaseColor.LIGHT_GRAY;
            _pdfPCell.BackgroundColor = BaseColor.WHITE;
            _pdfPCell.BorderColorLeft = BaseColor.WHITE;
            _pdfPCell.BorderColorRight = BaseColor.WHITE;
            _pdfPCell.BorderColorTop = BaseColor.BLACK;
            _pdfPCell.BorderColorBottom = BaseColor.BLACK;
            _pdfPCell.BorderWidthLeft = 1f;
            _pdfPCell.BorderWidthRight = 1f;
            _pdfPCell.BorderWidthTop = 1f;
            _pdfPCell.BorderWidthBottom = 1f;
            _pdfTable.AddCell(_pdfPCell);

            _fontstyle = FontFactory.GetFont("Tahoma", 6f, 1);
            _pdfPCell = new PdfPCell(new Phrase("Repuesto", _fontstyle));
            _pdfPCell.Colspan = 2;
            _pdfPCell.HorizontalAlignment = Element.ALIGN_CENTER;
            _pdfPCell.VerticalAlignment = Element.ALIGN_MIDDLE;
            _pdfPCell.BackgroundColor = BaseColor.LIGHT_GRAY;
            _pdfPCell.BackgroundColor = BaseColor.WHITE;
            _pdfPCell.BorderColorLeft = BaseColor.WHITE;
            _pdfPCell.BorderColorRight = BaseColor.WHITE;
            _pdfPCell.BorderColorTop = BaseColor.BLACK;
            _pdfPCell.BorderColorBottom = BaseColor.BLACK;
            _pdfPCell.BorderWidthLeft = 1f;
            _pdfPCell.BorderWidthRight = 1f;
            _pdfPCell.BorderWidthTop = 1f;
            _pdfPCell.BorderWidthBottom = 1f;
            _pdfTable.AddCell(_pdfPCell);

            _fontstyle = FontFactory.GetFont("Tahoma", 6f, 1);
            _pdfPCell = new PdfPCell(new Phrase("Cantidad", _fontstyle));
            _pdfPCell.Colspan = 1;
            _pdfPCell.HorizontalAlignment = Element.ALIGN_CENTER;
            _pdfPCell.VerticalAlignment = Element.ALIGN_MIDDLE;
            _pdfPCell.BackgroundColor = BaseColor.LIGHT_GRAY;
            _pdfPCell.BackgroundColor = BaseColor.WHITE;
            _pdfPCell.BorderColorLeft = BaseColor.WHITE;
            _pdfPCell.BorderColorRight = BaseColor.WHITE;
            _pdfPCell.BorderColorTop = BaseColor.BLACK;
            _pdfPCell.BorderColorBottom = BaseColor.BLACK;
            _pdfPCell.BorderWidthLeft = 1f;
            _pdfPCell.BorderWidthRight = 1f;
            _pdfPCell.BorderWidthTop = 1f;
            _pdfPCell.BorderWidthBottom = 1f;
            _pdfTable.AddCell(_pdfPCell);

            _fontstyle = FontFactory.GetFont("Tahoma", 6f, 1);
            _pdfPCell = new PdfPCell(new Phrase("Consumo", _fontstyle));
            _pdfPCell.Colspan = 1;
            _pdfPCell.HorizontalAlignment = Element.ALIGN_CENTER;
            _pdfPCell.VerticalAlignment = Element.ALIGN_MIDDLE;
            _pdfPCell.BackgroundColor = BaseColor.LIGHT_GRAY;
            _pdfPCell.BackgroundColor = BaseColor.WHITE;
            _pdfPCell.BorderColorLeft = BaseColor.WHITE;
            _pdfPCell.BorderColorRight = BaseColor.WHITE;
            _pdfPCell.BorderColorTop = BaseColor.BLACK;
            _pdfPCell.BorderColorBottom = BaseColor.BLACK;
            _pdfPCell.BorderWidthLeft = 1f;
            _pdfPCell.BorderWidthRight = 1f;
            _pdfPCell.BorderWidthTop = 1f;
            _pdfPCell.BorderWidthBottom = 1f;
            _pdfTable.AddCell(_pdfPCell);

            _pdfTable.CompleteRow();





            _fontstyle = FontFactory.GetFont("Tahoma", 6f, 0);
            foreach (ODMdList ODMdList in oDMdList)
            {
                _pdfPCell = new PdfPCell(new Phrase(ODMdList.ODM_FechMovimiento, _fontstyle));
                _pdfPCell.Colspan = 1;
                _pdfPCell.HorizontalAlignment = Element.ALIGN_LEFT;
                _pdfPCell.VerticalAlignment = Element.ALIGN_MIDDLE;
                _pdfPCell.BackgroundColor = BaseColor.WHITE;
                _pdfPCell.Border = 0;
                _pdfTable.AddCell(_pdfPCell);

                _pdfPCell = new PdfPCell(new Phrase(ODMdList.Mer_Codigo, _fontstyle));
                _pdfPCell.Colspan = 1;
                _pdfPCell.HorizontalAlignment = Element.ALIGN_CENTER;
                _pdfPCell.VerticalAlignment = Element.ALIGN_MIDDLE;
                _pdfPCell.BackgroundColor = BaseColor.WHITE;
                _pdfPCell.Border = 0;
                _pdfTable.AddCell(_pdfPCell);

                _pdfPCell = new PdfPCell(new Phrase(ODMdList.Mer_CodOriginal.ToString(), _fontstyle));
                _pdfPCell.Colspan = 2;
                _pdfPCell.HorizontalAlignment = Element.ALIGN_CENTER;
                _pdfPCell.VerticalAlignment = Element.ALIGN_MIDDLE;
                _pdfPCell.BackgroundColor = BaseColor.WHITE;
                _pdfPCell.Border = 0;
                _pdfTable.AddCell(_pdfPCell);

                _pdfPCell = new PdfPCell(new Phrase(ODMdList.Mer_Nombre.ToString(), _fontstyle));
                _pdfPCell.Colspan = 2;
                _pdfPCell.HorizontalAlignment = Element.ALIGN_CENTER;
                _pdfPCell.VerticalAlignment = Element.ALIGN_MIDDLE;
                _pdfPCell.BackgroundColor = BaseColor.WHITE;
                _pdfPCell.Border = 0;
                _pdfTable.AddCell(_pdfPCell);

                _pdfPCell = new PdfPCell(new Phrase(ODMdList.ODMd_Cantidad.ToString(), _fontstyle));
                _pdfPCell.Colspan = 1;
                _pdfPCell.HorizontalAlignment = Element.ALIGN_CENTER;
                _pdfPCell.VerticalAlignment = Element.ALIGN_MIDDLE;
                _pdfPCell.BackgroundColor = BaseColor.WHITE;
                _pdfPCell.Border = 0;
                _pdfTable.AddCell(_pdfPCell);


                _pdfPCell = new PdfPCell(new Phrase(ODMdList.Atendida.ToString(), _fontstyle));
                _pdfPCell.Colspan = 1;
                _pdfPCell.HorizontalAlignment = Element.ALIGN_CENTER;
                _pdfPCell.VerticalAlignment = Element.ALIGN_MIDDLE;
                _pdfPCell.BackgroundColor = BaseColor.WHITE;
                _pdfPCell.Border = 0;
                _pdfTable.AddCell(_pdfPCell);

                _pdfTable.CompleteRow();

            }


            // ESPACIADO DOBLE - INICIO
            _fontstyle = FontFactory.GetFont("Tahoma", 20f, 1);
            _pdfPCell = new PdfPCell(new Phrase("   ", _fontstyle));
            _pdfPCell.Colspan = 8;
            _pdfPCell.HorizontalAlignment = Element.ALIGN_RIGHT;
            _pdfPCell.VerticalAlignment = Element.ALIGN_MIDDLE;
            _pdfPCell.BackgroundColor = BaseColor.LIGHT_GRAY;
            _pdfPCell.BackgroundColor = BaseColor.WHITE;
            _pdfPCell.BorderColorLeft = BaseColor.WHITE;
            _pdfPCell.BorderColorRight = BaseColor.WHITE;
            _pdfPCell.BorderColorTop = BaseColor.WHITE;
            _pdfPCell.BorderColorBottom = BaseColor.WHITE;
            _pdfPCell.BorderWidthLeft = 1f;
            _pdfPCell.BorderWidthRight = 1f;
            _pdfPCell.BorderWidthTop = 1f;
            _pdfPCell.BorderWidthBottom = 1f;
            _pdfPCell.PaddingBottom = 5f;
            _pdfTable.AddCell(_pdfPCell);

            _pdfTable.CompleteRow();


            _fontstyle = FontFactory.GetFont("Tahoma", 6f, 1);
            _pdfPCell = new PdfPCell(new Phrase("", _fontstyle));
            _pdfPCell.Colspan = 2;
            _pdfPCell.HorizontalAlignment = Element.ALIGN_RIGHT;
            _pdfPCell.VerticalAlignment = Element.ALIGN_MIDDLE;
            _pdfPCell.BackgroundColor = BaseColor.LIGHT_GRAY;
            _pdfPCell.BackgroundColor = BaseColor.WHITE;
            _pdfPCell.BorderColorLeft = BaseColor.WHITE;
            _pdfPCell.BorderColorRight = BaseColor.WHITE;
            _pdfPCell.BorderColorTop = BaseColor.WHITE;
            _pdfPCell.BorderColorBottom = BaseColor.WHITE;
            _pdfPCell.BorderWidthLeft = 1f;
            _pdfPCell.BorderWidthRight = 1f;
            _pdfPCell.BorderWidthTop = 1f;
            _pdfPCell.BorderWidthBottom = 1f;
            _pdfTable.AddCell(_pdfPCell);

            // ESPACIADO DOBLE - FIN

            _fontstyle = FontFactory.GetFont("Tahoma", 6f, 1);
            _pdfPCell = new PdfPCell(new Phrase("JEFE DE TALLER", _fontstyle));
            _pdfPCell.Colspan = 4;
            _pdfPCell.HorizontalAlignment = Element.ALIGN_CENTER;
            _pdfPCell.VerticalAlignment = Element.ALIGN_MIDDLE;
            _pdfPCell.BackgroundColor = BaseColor.LIGHT_GRAY;
            _pdfPCell.BackgroundColor = BaseColor.WHITE;
            _pdfPCell.BorderColorLeft = BaseColor.WHITE;
            _pdfPCell.BorderColorRight = BaseColor.WHITE;
            _pdfPCell.BorderColorTop = BaseColor.BLACK;
            _pdfPCell.BorderColorBottom = BaseColor.WHITE;
            _pdfPCell.BorderWidthLeft = 1f;
            _pdfPCell.BorderWidthRight = 1f;
            _pdfPCell.BorderWidthTop = 1f;
            _pdfPCell.BorderWidthBottom = 1f;
            _pdfTable.AddCell(_pdfPCell);


            //_fontstyle = FontFactory.GetFont("Tahoma", 6f, 1);
            //_pdfPCell = new PdfPCell(new Phrase("MECÁNICO", _fontstyle));
            //_pdfPCell.Colspan = 2;
            //_pdfPCell.HorizontalAlignment = Element.ALIGN_CENTER;
            //_pdfPCell.VerticalAlignment = Element.ALIGN_MIDDLE;
            //_pdfPCell.BackgroundColor = BaseColor.LIGHT_GRAY;
            //_pdfPCell.BackgroundColor = BaseColor.WHITE;
            //_pdfPCell.BorderColorLeft = BaseColor.WHITE;
            //_pdfPCell.BorderColorRight = BaseColor.WHITE;
            //_pdfPCell.BorderColorTop = BaseColor.BLACK;
            //_pdfPCell.BorderColorBottom = BaseColor.WHITE;
            //_pdfPCell.BorderWidthLeft = 1f;
            //_pdfPCell.BorderWidthRight = 1f;
            //_pdfPCell.BorderWidthTop = 1f;
            //_pdfPCell.BorderWidthBottom = 1f;
            //_pdfTable.AddCell(_pdfPCell);

            _fontstyle = FontFactory.GetFont("Tahoma", 6f, 1);
            _pdfPCell = new PdfPCell(new Phrase("", _fontstyle));
            _pdfPCell.Colspan = 2;
            _pdfPCell.HorizontalAlignment = Element.ALIGN_RIGHT;
            _pdfPCell.VerticalAlignment = Element.ALIGN_MIDDLE;
            _pdfPCell.BackgroundColor = BaseColor.LIGHT_GRAY;
            _pdfPCell.BackgroundColor = BaseColor.WHITE;
            _pdfPCell.BorderColorLeft = BaseColor.WHITE;
            _pdfPCell.BorderColorRight = BaseColor.WHITE;
            _pdfPCell.BorderColorTop = BaseColor.WHITE;
            _pdfPCell.BorderColorBottom = BaseColor.WHITE;
            _pdfPCell.BorderWidthLeft = 1f;
            _pdfPCell.BorderWidthRight = 1f;
            _pdfPCell.BorderWidthTop = 1f;
            _pdfPCell.BorderWidthBottom = 1f;
            _pdfTable.AddCell(_pdfPCell);

            _pdfTable.CompleteRow();


        }

        #endregion

    }
}