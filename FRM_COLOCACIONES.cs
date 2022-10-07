using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Excel = Microsoft.Office.Interop.Excel;

namespace _CYD_ASIENTOS_CONTABLES_2019
{
    public partial class FRM_COLOCACION : Form
    {
        public FRM_COLOCACION()
        {
            InitializeComponent();
        }
        Conexion_Mysql cn = new Conexion_Mysql();
        private string sql = "";
        private string fecha = "";
        private string fechafin = "";
 
        private void button1_Click(object sender, EventArgs e)
        {
    
            if (dateTimePicker1.Value.Date < DateTime.Now.Date && dateTimePicker2.Value.Date < DateTime.Now.Date)
            {

                fecha = dateTimePicker1.Value.ToString("yyyy-MM-dd");
                fechafin = dateTimePicker1.Value.ToString("yyyy-MM-dd");

                if (txt_comprobante.Text != "")
                {
                    Colocacion();
                }
                else
                {
                    MessageBox.Show("INGRESE UN COMPROBANTE CORRESPONDIENTE AL SISTEMA CONTABLE");
                }
         
            }
        }

        private void Colocacion()
        {

            // COLOCACIONES  DIARIAS AVANCES
            sql = "CALL contabilidad.COLOCACIONES_DIARIAS_AVANCES_2019( '" + fecha + "','" + fechafin + "') ;";
            DataTable dt = new DataTable();
            dt = cn.ExecuteQuery(sql);
            dg.DataSource = dt;

            int monto = 0; int interes = 0; int comi = 0; int comi_avance = 0; int impuesto = 0;
            for (int i = 0; i <= dg.Rows.Count - 1; i++)
            {
                monto = monto + int.Parse(dg.Rows[i].Cells[1].Value.ToString());
                interes = interes + int.Parse(dg.Rows[i].Cells[2].Value.ToString());
                comi = comi + int.Parse(dg.Rows[i].Cells[3].Value.ToString());
                comi_avance = comi_avance + int.Parse(dg.Rows[i].Cells[4].Value.ToString());
                impuesto = impuesto + int.Parse(dg.Rows[i].Cells[5].Value.ToString());

            }
               lbl_monto.Text = Convert.ToString("$ " + monto);
               lbl_interescorri.Text = Convert.ToString("$ " + interes);
               lbl_comicuota.Text = Convert.ToString("$ " + comi);
               lbl_comiavance.Text = Convert.ToString("$ " + comi_avance);
               lbl_impuesto.Text = Convert.ToString("$ " + impuesto);

            // COLOCACIONES  DIARIAS NO REPACTACIONES
            sql = "CALL contabilidad.COLOCACIONES_DIARIAS_NO_REPACTACIONES2019( '" + fecha + "','" + fechafin + "') ;";
            DataTable dt2 = new DataTable();
            dt2 = cn.ExecuteQuery(sql);
            dg2.DataSource = dt2;
            int montonr = 0; int interesnr = 0; int cominr = 0; int comi_avancenr = 0; int impuestonr = 0;
            for (int i = 0; i <= dg2.Rows.Count - 1; i++)
            {
                montonr = montonr + int.Parse(dg2.Rows[i].Cells[1].Value.ToString());
                interesnr = interesnr + int.Parse(dg2.Rows[i].Cells[2].Value.ToString());
                cominr = cominr + int.Parse(dg2.Rows[i].Cells[3].Value.ToString());
                comi_avancenr = comi_avancenr + int.Parse(dg2.Rows[i].Cells[4].Value.ToString());
                impuestonr = impuestonr + int.Parse(dg2.Rows[i].Cells[5].Value.ToString());

            }
            lbl_montonr.Text = Convert.ToString("$ " + montonr);
            lbl_interesnr.Text = Convert.ToString("$ " + interesnr);
            lbl_cuotanr.Text = Convert.ToString("$ " + cominr);
            lbl_comiavanr.Text = Convert.ToString("$ " + comi_avancenr);
            lbl_inpunr.Text = Convert.ToString("$ " + impuestonr);



            // COLOCACIONES  DIARIAS REPACTACIONES
            sql = "CALL contabilidad.COLOCACIONES_DIARIAS_REPACTACIONES2019( '" + fecha + "','" + fechafin + "') ;";
            DataTable dt3 = new DataTable();
            dt3 = cn.ExecuteQuery(sql);
            dg3.DataSource = dt3;
            int montorp = 0; int interesrp = 0; int comirp = 0; int comi_avancerp = 0; int impuestorp = 0;
            for (int i = 0; i <= dg3.Rows.Count - 1; i++)
            {
                montorp = montorp + int.Parse(dg3.Rows[i].Cells[1].Value.ToString());
                interesrp = interesrp + int.Parse(dg3.Rows[i].Cells[2].Value.ToString());
                comirp = comirp + int.Parse(dg3.Rows[i].Cells[3].Value.ToString());
                comi_avancerp = comi_avancerp + int.Parse(dg3.Rows[i].Cells[4].Value.ToString());
                impuestorp = impuestorp + int.Parse(dg3.Rows[i].Cells[5].Value.ToString());

            }

            lbl_montorep.Text = Convert.ToString("$ " + montorp);
            label16.Text = Convert.ToString("$ " + interesrp);
            lbl_comirep.Text = Convert.ToString("$ " + comirp);
            lbl_comiavanrep.Text = Convert.ToString("$ " + comi_avancerp);
            lbl_inpurep.Text = Convert.ToString("$ " + impuestorp);



            // ANULACIONES DIARIAS
            // COLOCACIONES  DIARIAS REPACTACIONES
            sql = "CALL ANULACIONES_DIARIAS_2019( '" + fecha + "','" + fechafin + "') ;";
            DataTable dt4 = new DataTable();
            dt4 = cn.ExecuteQuery(sql);
            dg4.DataSource = dt4;
            int montoan = 0;
            for (int i = 0; i <= dg4.Rows.Count - 1; i++)
            {
                montoan = montoan + int.Parse(dg4.Rows[i].Cells[3].Value.ToString());
             
            }
            lbl_anulacion.Text = Convert.ToString("$ " + montoan);


            // ARCHIVO PARA SUBIR AL SISTEMA CONTABLE
            sql = "CALL contabilidad.ARCHIVO_COLOCACIONES( '" + fecha + "','" + Convert.ToInt32(txt_comprobante.Text) + "') ;";
            DataTable dt6 = new DataTable();
            dt6 = cn.ExecuteQuery(sql);
            dg6.DataSource = dt6;

            dg6.Columns[0].HeaderText = "Numero Comprobante";
            dg6.Columns[1].HeaderText = "Fecha";
            dg6.Columns[2].HeaderText = "Tipo ";
            dg6.Columns[3].HeaderText = "Rut Ext.";
            dg6.Columns[4].HeaderText = "Cuenta";
            dg6.Columns[5].HeaderText = "Glosa/ Nombre";
            dg6.Columns[6].HeaderText = "Debe";
            dg6.Columns[7].HeaderText = "Haber";
            dg6.Columns[8].HeaderText = "TD";
            dg6.Columns[9].HeaderText = "Número";
            dg6.Columns[10].HeaderText = "Fecha";
            dg6.Columns[11].HeaderText = "Rut";
            dg6.Columns[12].HeaderText = "C.R.";
            dg6.Columns[13].HeaderText = "Cód. Esp.";
            dg6.Columns[14].HeaderText = "Glosa General";

            int debe = 0;
            int haber = 0;
            for (int i = 0; i <= dg6.Rows.Count - 1; i++)
            {
                string strdebe = !string.IsNullOrEmpty(dg6.Rows[i].Cells[6].Value.ToString()) ? dg6.Rows[i].Cells[6].Value.ToString() : "0";
                string strhaber = !string.IsNullOrEmpty(dg6.Rows[i].Cells[7].Value.ToString()) ? dg6.Rows[i].Cells[7].Value.ToString() : "0";
                debe = debe + int.Parse(strdebe);
                haber = haber + int.Parse(strhaber);
            }

            lbl_debe.Text = Convert.ToString("$ " + debe);
            lbl_haber.Text = Convert.ToString("$ " + haber);

        }

        private void lbl_interesrep_Load(object sender, EventArgs e)
        {
            dateTimePicker1.Value = DateTime.Now;
            dateTimePicker2.Value = DateTime.Now;
        }

        private void button9_Click(object sender, EventArgs e)
        {

            if (dg6.RowCount > 0)
            {
                ExportarDataGridViewExcel(dg6);
                MessageBox.Show("Archivo Excel Generado", " Importacion de datos a Excel ");
            }
        }


        private void ExportarDataGridViewExcel(DataGridView grd)
        {
            SaveFileDialog fichero = new SaveFileDialog();
            fichero.Filter = "Excel (*.xls)|*.xls";
            if (fichero.ShowDialog() == DialogResult.OK)
            {
                Microsoft.Office.Interop.Excel.Application aplicacion;
                Microsoft.Office.Interop.Excel.Workbook libros_trabajo;
                Microsoft.Office.Interop.Excel.Worksheet hoja_trabajo;
                aplicacion = new Microsoft.Office.Interop.Excel.Application();
                libros_trabajo = aplicacion.Workbooks.Add();
                hoja_trabajo =
                    (Microsoft.Office.Interop.Excel.Worksheet)libros_trabajo.Worksheets.get_Item(1);
                //Recorremos el DataGridView rellenando la hoja de trabajo
                for (int i = 0; i < grd.Rows.Count; i++)
                {
                    for (int j = 0; j < grd.Columns.Count; j++)
                    {
                        hoja_trabajo.Cells[i + 1, j + 1] = grd.Rows[i].Cells[j].Value.ToString();
                    }
                }
                libros_trabajo.SaveAs(fichero.FileName,
                Microsoft.Office.Interop.Excel.XlFileFormat.xlWorkbookNormal);
                libros_trabajo.Close(true);
                aplicacion.Quit();
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            dg.SelectAll();
            dg.ClipboardCopyMode = DataGridViewClipboardCopyMode.EnableAlwaysIncludeHeaderText;

            DataObject dataObj2 = dg.GetClipboardContent();

            if (dataObj2 != null)
            {

                Clipboard.SetDataObject(dataObj2);

            }

            dg.ClearSelection();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            dg2.SelectAll();
            dg2.ClipboardCopyMode = DataGridViewClipboardCopyMode.EnableAlwaysIncludeHeaderText;

            DataObject dataObj2 = dg2.GetClipboardContent();

            if (dataObj2 != null)
            {

                Clipboard.SetDataObject(dataObj2);

            }

            dg2.ClearSelection();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            dg3.SelectAll();
            dg3.ClipboardCopyMode = DataGridViewClipboardCopyMode.EnableAlwaysIncludeHeaderText;

            DataObject dataObj2 = dg3.GetClipboardContent();

            if (dataObj2 != null)
            {

                Clipboard.SetDataObject(dataObj2);

            }

            dg3.ClearSelection();
        }

        private void button6_Click(object sender, EventArgs e)
        {
            dg4.SelectAll();
            dg4.ClipboardCopyMode = DataGridViewClipboardCopyMode.EnableAlwaysIncludeHeaderText;

            DataObject dataObj2 = dg4.GetClipboardContent();

            if (dataObj2 != null)
            {

                Clipboard.SetDataObject(dataObj2);

            }

            dg4.ClearSelection();

        }

        private void button3_Click(object sender, EventArgs e)
        {
            dg.DataSource = null;
            dg2.DataSource = null;
            dg3.DataSource = null;
            dg4.DataSource = null;
            dg6.DataSource = null;
            lbl_anulacion.Text = "0";
            lbl_comiavance.Text = "0";
            lbl_comiavanr.Text = "0";
            lbl_comiavanrep.Text = "0";
            lbl_comicuota.Text = "0";
            lbl_comirep.Text = "0";
            lbl_cuotanr.Text = "0";
            lbl_debe.Text = "0";
            lbl_haber.Text = "0";
            lbl_impuesto.Text = "0";
            lbl_inpunr.Text = "0";
            lbl_inpurep.Text = "0";
            lbl_monto.Text = "0";
            lbl_montonr.Text = "0";
            lbl_montorep.Text = "0";
            lbl_interescorri.Text = "0";
            lbl_interesnr.Text = "0";


        }
    }
}
