using iTextSharp.text;
using iTextSharp.text.pdf;
using Mantenimiento.WebApp.ServiceMantenimiento;
using System;
using System.Collections.Generic;
using System.IO;

namespace Mantenimiento.WebApp.Reports
{
    public class PreventivosPendientesReport
    {
        #region Declaraciones
        int _totalColumn = 10;
        Document _document;
        Font _fontstyle;
        PdfPTable _pdfTable = new PdfPTable(10);
        PdfPCell _pdfPCell;
        MemoryStream _memorystream = new MemoryStream();

        List<TareasPendientesList> tareasPendientesList = new List<TareasPendientesList>();
        List<BaseEntity> empresasList = new List<BaseEntity>();
        #endregion

        public byte[] PrepareReport(List<TareasPendientesList> tareasPendientes, List<BaseEntity> listEmpresas)
        {
            tareasPendientesList = tareasPendientes;
            empresasList = listEmpresas;

            _document = new Document(PageSize.A4, 0f, 0f, 0f, 0f);
            _document.SetPageSize(PageSize.A4);
            _document.SetMargins(20f, 20f, 20f, 20f);
            _pdfTable.WidthPercentage = 100;
            _pdfTable.HorizontalAlignment = Element.ALIGN_LEFT;
            _fontstyle = FontFactory.GetFont("Tahoma", 8f, 1);

            PdfWriter.GetInstance(_document, _memorystream);
            _document.Open();
            _pdfTable.SetWidths(new float[] { 30f, 80f, 20f, 20f, 15f, 15f, 15f, 15f, 15f, 15f });


            this.ReportHeader();
            this.ReportBody();
            

            _pdfTable.HeaderRows = 3;
            
            _document.Add(_pdfTable);
            
            _document.Close();

            return _memorystream.ToArray();
        }

        private void ReportHeader()
        {
            _fontstyle = FontFactory.GetFont("Tahoma", 15f, 1);
            _pdfPCell = new PdfPCell(new Phrase(empresasList[0].Descripcion, _fontstyle));
            _pdfPCell.Colspan = 5;
            _pdfPCell.HorizontalAlignment = Element.ALIGN_LEFT;
            _pdfPCell.Border = 0;
            _pdfPCell.BackgroundColor = BaseColor.WHITE;
            _pdfPCell.ExtraParagraphSpace = 0;
            _pdfTable.AddCell(_pdfPCell);

            _fontstyle = FontFactory.GetFont("Tahoma", 9f, 1);
            _pdfPCell = new PdfPCell(new Phrase(string.Concat("Fecha Impresión : ", DateTime.Now.ToString("dd/MM/yyyy")), _fontstyle));
            _pdfPCell.Colspan = 5;
            _pdfPCell.HorizontalAlignment = Element.ALIGN_RIGHT;
            _pdfPCell.Border = 0;
            _pdfPCell.BackgroundColor = BaseColor.WHITE;
            _pdfPCell.ExtraParagraphSpace = 0;
            _pdfTable.AddCell(_pdfPCell);
            _pdfTable.CompleteRow();


            

            _fontstyle = FontFactory.GetFont("Tahoma", 15f, 1);
            Chunk chunk1 = new Chunk("REALIZAR MANTENIMIENTO PREVENTIVO");
            chunk1.SetUnderline(1.5f, -2);
            _pdfPCell = new PdfPCell(new Phrase(chunk1));
            _pdfPCell.Colspan = _totalColumn;
            _pdfPCell.HorizontalAlignment = Element.ALIGN_CENTER;
            _pdfPCell.Border = 0;
            _pdfPCell.BackgroundColor = BaseColor.WHITE;
            _pdfPCell.ExtraParagraphSpace = 0;
            _pdfTable.AddCell(_pdfPCell);
            _pdfTable.CompleteRow();

            _fontstyle = FontFactory.GetFont("Tahoma", 11f, 1);
            _pdfPCell = new PdfPCell(new Phrase(string.Concat("BUS : ", tareasPendientesList[0].UnidadId), _fontstyle));
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
            _pdfPCell = new PdfPCell(new Phrase("Mantenimiento", _fontstyle));
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

            _pdfPCell = new PdfPCell(new Phrase("Tarea", _fontstyle));
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

            _pdfPCell = new PdfPCell(new Phrase("Kmt Aviso", _fontstyle));
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

            _pdfPCell = new PdfPCell(new Phrase("Fecha C", _fontstyle));
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

            _pdfPCell = new PdfPCell(new Phrase("Informe", _fontstyle));
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

            _pdfPCell = new PdfPCell(new Phrase("Kmt Act.", _fontstyle));
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

            _pdfPCell = new PdfPCell(new Phrase("Horas", _fontstyle));
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

            _pdfPCell = new PdfPCell(new Phrase("Horas Recorrido", _fontstyle));
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

            _pdfPCell = new PdfPCell(new Phrase("Dias", _fontstyle));
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

            _pdfPCell = new PdfPCell(new Phrase("Dias Recorrido", _fontstyle));
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

            _fontstyle = FontFactory.GetFont("Tahoma", 11f, 1);
            //_pdfPCell = new PdfPCell(new Phrase("COMPONENTES", _fontstyle));
            Chunk chunk2 = new Chunk("COMPONENTES");
            chunk2.SetUnderline(1.5f, -2);
            _pdfPCell = new PdfPCell(new Phrase(chunk2));
            _pdfPCell.Colspan = _totalColumn;
            _pdfPCell.HorizontalAlignment = Element.ALIGN_LEFT;
            _pdfPCell.Border = 0;
            _pdfPCell.BackgroundColor = BaseColor.WHITE;
            _pdfPCell.ExtraParagraphSpace = 0;
            _pdfTable.AddCell(_pdfPCell);
            _pdfTable.CompleteRow();


            _fontstyle = FontFactory.GetFont("Tahoma", 6f,0);
            foreach (TareasPendientesList tareaPendiente in tareasPendientesList)
            {
                _pdfPCell = new PdfPCell(new Phrase(tareaPendiente.Descripcion, _fontstyle));
                _pdfPCell.HorizontalAlignment = Element.ALIGN_LEFT;
                _pdfPCell.VerticalAlignment = Element.ALIGN_MIDDLE;
                _pdfPCell.BackgroundColor = BaseColor.WHITE;
                _pdfPCell.Border = 0;
                _pdfTable.AddCell(_pdfPCell);

                _pdfPCell = new PdfPCell(new Phrase(string.Concat(tareaPendiente.IdTarea.ToString(), " - ", tareaPendiente.DescripcionTarea), _fontstyle));
                _pdfPCell.HorizontalAlignment = Element.ALIGN_LEFT;
                _pdfPCell.VerticalAlignment = Element.ALIGN_MIDDLE;
                _pdfPCell.BackgroundColor = BaseColor.WHITE;
                _pdfPCell.Border = 0;
                _pdfTable.AddCell(_pdfPCell);

                _pdfPCell = new PdfPCell(new Phrase(string.Format("{0:0,0.00}", tareaPendiente.KmtAviso), _fontstyle));
                _pdfPCell.HorizontalAlignment = Element.ALIGN_RIGHT;
                _pdfPCell.VerticalAlignment = Element.ALIGN_MIDDLE;
                _pdfPCell.BackgroundColor = BaseColor.WHITE;
                _pdfPCell.Border = 0;
                _pdfTable.AddCell(_pdfPCell);

                _pdfPCell = new PdfPCell(new Phrase(tareaPendiente.fechainforme.ToString("yyyy-MM-dd"), _fontstyle));
                _pdfPCell.HorizontalAlignment = Element.ALIGN_CENTER;
                _pdfPCell.VerticalAlignment = Element.ALIGN_MIDDLE;
                _pdfPCell.BackgroundColor = BaseColor.WHITE;
                _pdfPCell.Border = 0;
                _pdfTable.AddCell(_pdfPCell);


                _pdfPCell = new PdfPCell(new Phrase(tareaPendiente.NroInforme.ToString(), _fontstyle));
                _pdfPCell.HorizontalAlignment = Element.ALIGN_CENTER;
                _pdfPCell.VerticalAlignment = Element.ALIGN_MIDDLE;
                _pdfPCell.BackgroundColor = BaseColor.WHITE;
                _pdfPCell.Border = 0;
                _pdfTable.AddCell(_pdfPCell);

                _pdfPCell = new PdfPCell(new Phrase(string.Format("{0:0,0.00}", tareaPendiente.KmtActual), _fontstyle));
                _pdfPCell.HorizontalAlignment = Element.ALIGN_CENTER;
                _pdfPCell.VerticalAlignment = Element.ALIGN_MIDDLE;
                _pdfPCell.BackgroundColor = BaseColor.WHITE;
                _pdfPCell.Border = 0;
                _pdfTable.AddCell(_pdfPCell);


                _pdfPCell = new PdfPCell(new Phrase(tareaPendiente.Horas.ToString(), _fontstyle));
                _pdfPCell.HorizontalAlignment = Element.ALIGN_CENTER;
                _pdfPCell.VerticalAlignment = Element.ALIGN_MIDDLE;
                _pdfPCell.BackgroundColor = BaseColor.WHITE;
                _pdfPCell.Border = 0;
                _pdfTable.AddCell(_pdfPCell);

                _pdfPCell = new PdfPCell(new Phrase(tareaPendiente.HorasRecorrido.ToString(), _fontstyle));
                _pdfPCell.HorizontalAlignment = Element.ALIGN_CENTER;
                _pdfPCell.VerticalAlignment = Element.ALIGN_MIDDLE;
                _pdfPCell.BackgroundColor = BaseColor.WHITE;
                _pdfPCell.Border = 0;
                _pdfTable.AddCell(_pdfPCell);


                _pdfPCell = new PdfPCell(new Phrase(tareaPendiente.Dias.ToString(), _fontstyle));
                _pdfPCell.HorizontalAlignment = Element.ALIGN_CENTER;
                _pdfPCell.VerticalAlignment = Element.ALIGN_MIDDLE;
                _pdfPCell.BackgroundColor = BaseColor.WHITE;
                _pdfPCell.Border = 0;
                _pdfTable.AddCell(_pdfPCell);

                _pdfPCell = new PdfPCell(new Phrase(tareaPendiente.DiasRecorrido.ToString(), _fontstyle));
                _pdfPCell.HorizontalAlignment = Element.ALIGN_CENTER;
                _pdfPCell.VerticalAlignment = Element.ALIGN_MIDDLE;
                _pdfPCell.BackgroundColor = BaseColor.WHITE;
                _pdfPCell.Border = 0;
                _pdfTable.AddCell(_pdfPCell);

                _pdfTable.CompleteRow();
            }


        }

  
    }
}