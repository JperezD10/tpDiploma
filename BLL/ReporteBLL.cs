using iTextSharp.text;
using iTextSharp.text.pdf;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BLL
{
    public class ReporteBLL
    {
        IdiomaBLL servicioIdioma;
        public ReporteBLL()
        {
            servicioIdioma = new IdiomaBLL();
        }
        public void reportePDF(List<DataGridView> listaTablas, SaveFileDialog saveFileDialog, string idioma)
        {
            using (FileStream stream = new FileStream(saveFileDialog.FileName, FileMode.Create))
            {
                Document pdfDoc = new Document(PageSize.A4, 10f, 20f, 20f, 10f);
                PdfWriter.GetInstance(pdfDoc, stream);
                pdfDoc.Open();

                List<PdfPTable> listaPDFTables = new List<PdfPTable>();
                try
                {
                    foreach (DataGridView dataGridView in listaTablas)
                    {
                        int contador = 0;
                        foreach (DataGridViewColumn columna in dataGridView.Columns)
                        {
                            if (columna.Visible)
                            {
                                contador++;
                            }
                        }
                        PdfPTable pdfTable = new PdfPTable(contador);
                        pdfTable.DefaultCell.Padding = 3;
                        pdfTable.WidthPercentage = 100;
                        pdfTable.HorizontalAlignment = Element.ALIGN_LEFT;

                        foreach (DataGridViewColumn column in dataGridView.Columns)
                        {
                            if (!column.Visible) continue;
                            PdfPCell cell = new PdfPCell(new Phrase(column.HeaderText));
                            cell.BackgroundColor = BaseColor.GRAY;
                            pdfTable.AddCell(cell);
                        }

                        foreach (DataGridViewRow row in dataGridView.Rows)
                        {

                            foreach (DataGridViewCell cell in row.Cells)
                            {
                                if (!dataGridView.Columns[cell.ColumnIndex].Visible) continue;
                                pdfTable.AddCell(cell.Value.ToString());
                            }
                        }
                        pdfDoc.Add(pdfTable);
                        pdfDoc.Add(new Paragraph("\n"));
                    }
                    pdfDoc.Close();
                    stream.Close();

                    MessageBox.Show(servicioIdioma.buscarTexto("msbExportacionExito", idioma), "Info");
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error :" + ex.Message);
                }
            }
        }
    }
}
