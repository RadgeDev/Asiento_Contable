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
    public partial class lFRM_RECAUDACION : Form
    {
        public lFRM_RECAUDACION()
        {
            InitializeComponent();
        }
        Conexion_Mysql cn = new Conexion_Mysql();
        private string sql = "";
        private string fecha = "";
        private string fechafin = "";
        private string fecharecudacion = "";

        private void button1_Click(object sender, EventArgs e)
        {
            if (dateTimePicker1.Value.Date < DateTime.Now.Date && dateTimePicker2.Value.Date < DateTime.Now.Date)
            {

                fecha = dateTimePicker1.Value.ToString("yyyy-MM-dd");
                fechafin = dateTimePicker1.Value.ToString("yyyy-MM-dd");
                Recaudacion();
            }
        }

        private void Recaudacion()
        {
            sql = "CALL CONTADOR_RECAUDACION_CONSULTAS( '" + fecha + "','" + fechafin + "') ;";
            DataTable dtn = new DataTable();
            dtn = cn.ExecuteQuery(sql);
            lbl_transac.Text = dtn.Rows[0][0].ToString();



            sql = "CALL RECAUDACION_CONSULTAS( '" + fecha + "','" + fechafin + "') ;";
            DataTable dt = new DataTable();
            dt = cn.ExecuteQuery(sql);
            dg.DataSource = dt;


            sql = "CALL INFORME_CONTABILIDAD_RECAUDACION( '" + fecha + "','" + fechafin + "') ;";
            DataTable dt2 = new DataTable();
            dt2 = cn.ExecuteQuery(sql);
            dg2.DataSource = dt2;

            sql = "CALL contabilidad.RECAUDACIONES_DIARIAS_VENCIDA2019( '" + fecha + "','" + fechafin + "') ;";
            DataTable dt3 = new DataTable();
            dt3 = cn.ExecuteQuery(sql);
            dg3.DataSource = dt3;

            lbl_desglose.Text =Convert.ToString(dg.RowCount);





            int ABONO = 0;int ABOCAPI = 0; int ABONO_COMISION_AVANCE = 0; int ABONO_CORRIENTE = 0; int ABONO_IMPUESTO = 0;
            int ABONO_ENVIO = 0; int ABONO_SEGURO_DESGRAVAMEN = 0; int ABONO_INTERES_PROYECTADO = 0; int ABONO_INTERES_PERIODO = 0;
            int ABONO_SALDO_ANTERIOR = 0; int ABONO_AVM = 0; int ABONO_GASTO_COBRANZA = 0; int ABONO_PAGO_POR_APLICAR = 0;


            for (int i = 0; i <= dg.Rows.Count - 1; i++)
            {
                ABONO = ABONO + int.Parse(dg.Rows[i].Cells[3].Value.ToString());
                ABOCAPI = ABOCAPI + int.Parse(dg.Rows[i].Cells[4].Value.ToString());
                ABONO_COMISION_AVANCE = ABONO_COMISION_AVANCE + int.Parse(dg.Rows[i].Cells[5].Value.ToString());
                ABONO_CORRIENTE = ABONO_CORRIENTE + int.Parse(dg.Rows[i].Cells[6].Value.ToString());
                ABONO_IMPUESTO = ABONO_IMPUESTO + int.Parse(dg.Rows[i].Cells[7].Value.ToString());
                ABONO_ENVIO = ABONO_ENVIO + int.Parse(dg.Rows[i].Cells[8].Value.ToString());
                ABONO_SEGURO_DESGRAVAMEN = ABONO_SEGURO_DESGRAVAMEN + int.Parse(dg.Rows[i].Cells[9].Value.ToString());
                ABONO_INTERES_PROYECTADO = ABONO_INTERES_PROYECTADO + int.Parse(dg.Rows[i].Cells[10].Value.ToString());
                ABONO_INTERES_PERIODO = ABONO_INTERES_PERIODO + int.Parse(dg.Rows[i].Cells[11].Value.ToString());
                ABONO_SALDO_ANTERIOR = ABONO_SALDO_ANTERIOR + int.Parse(dg.Rows[i].Cells[12].Value.ToString());
                ABONO_AVM = ABONO_AVM + int.Parse(dg.Rows[i].Cells[13].Value.ToString());
                ABONO_GASTO_COBRANZA = ABONO_GASTO_COBRANZA + int.Parse(dg.Rows[i].Cells[14].Value.ToString());
                ABONO_PAGO_POR_APLICAR = ABONO_PAGO_POR_APLICAR + int.Parse(dg.Rows[i].Cells[15].Value.ToString());
               
            }
            int total_recaudacion_normal = ( ABOCAPI + ABONO_COMISION_AVANCE + ABONO_CORRIENTE + ABONO_IMPUESTO + ABONO_ENVIO + ABONO_SEGURO_DESGRAVAMEN
                + ABONO_INTERES_PROYECTADO + ABONO_INTERES_PERIODO + ABONO_SALDO_ANTERIOR + ABONO_AVM + ABONO_GASTO_COBRANZA + ABONO_PAGO_POR_APLICAR);
            //string[] row1 = new string[] { "ABONO ", Convert.ToString(ABONO) };
            string[] row2 = new string[] { "ABONO CAPITAL", Convert.ToString(ABOCAPI) };
            string[] row3 = new string[] { "ABONO_COMISION_AVANCE", Convert.ToString(ABONO_COMISION_AVANCE) };
            string[] row4 = new string[] { "ABONO_CORRIENTE", Convert.ToString(ABONO_CORRIENTE) };
            string[] row5= new string[] { "ABONO_IMPUESTO", Convert.ToString(ABONO_IMPUESTO) };
            string[] row6 = new string[] { "ABONO_ENVIO", Convert.ToString(ABONO_ENVIO) };
            string[] row7 = new string[] { "ABONO_SEGURO_DESGRAVAMEN", Convert.ToString(ABONO_SEGURO_DESGRAVAMEN) };
            string[] row8 = new string[] { "ABONO_INTERES_PROYECTADO", Convert.ToString(ABONO_INTERES_PROYECTADO) };
            string[] row9 = new string[] { "ABONO_INTERES_PERIODO", Convert.ToString(ABONO_INTERES_PERIODO) };
            string[] row10 = new string[] { "ABONO_SALDO_ANTERIOR", Convert.ToString(ABONO_SALDO_ANTERIOR) };
            string[] row11 = new string[] { "ABONO_AVM", Convert.ToString(ABONO_AVM) };
            string[] row12 = new string[] { "ABONO_GASTO_COBRANZA", Convert.ToString(ABONO_GASTO_COBRANZA) };
            string[] row13 = new string[] { "ABONO_PAGO_POR_APLICAR", Convert.ToString(ABONO_PAGO_POR_APLICAR) };

            
            Addrows(row2);
            Addrows(row3);
            Addrows(row4);
            Addrows(row5);
            Addrows(row6);
            Addrows(row7);
            Addrows(row8);
            Addrows(row9);
            Addrows(row10);
            Addrows(row11);
            Addrows(row12);
            Addrows(row13);


            int total_centropago = 0;
            for (int i = 0; i <= dg2.Rows.Count - 1; i++)
            {
                total_centropago = total_centropago + int.Parse(dg2.Rows[i].Cells[1].Value.ToString());

            }

            lbl_centropago.Text = Convert.ToString("$ " + total_centropago);
            lbl_recaudacionnormal.Text = Convert.ToString("$ " + total_recaudacion_normal);
            lbl_tot_normal.Text = Convert.ToString("$ " + total_recaudacion_normal);




            lbl_sumabonos.Text = Convert.ToString("$ " + ABONO);
            int CAPITAL_DEUDA = 0; int INTERES = 0; int GASTO_COBRANZA_VENC = 0;
            for (int i = 0; i <= dg3.Rows.Count - 1; i++)
            {
                CAPITAL_DEUDA = CAPITAL_DEUDA + int.Parse(dg3.Rows[i].Cells[1].Value.ToString());
                INTERES = INTERES + int.Parse(dg3.Rows[i].Cells[2].Value.ToString());
                GASTO_COBRANZA_VENC = GASTO_COBRANZA_VENC + int.Parse(dg3.Rows[i].Cells[3].Value.ToString());


            }
            int totalrecaudacion_vencida = (CAPITAL_DEUDA + INTERES + GASTO_COBRANZA_VENC );
            string[] ven = new string[] { "CAPITAL_DEUDA ", Convert.ToString(CAPITAL_DEUDA) };
            string[] ven1 = new string[] { "INTERES", Convert.ToString(INTERES) };
            string[] ven2 = new string[] { "GASTO_COBRANZA", Convert.ToString(GASTO_COBRANZA_VENC) };
            AddrowsVen(ven);
            AddrowsVen(ven1);
            AddrowsVen(ven2);
            lbl_capital.Text = Convert.ToString("$ " + CAPITAL_DEUDA);
            lbl_interes.Text = Convert.ToString("$ " + INTERES);
            lbl_gastcobrnzavenc.Text = Convert.ToString("$ " + GASTO_COBRANZA_VENC);
            lbl_recaudacionvencida.Text= Convert.ToString("$ " +totalrecaudacion_vencida);
            lbl_finvencida.Text = Convert.ToString("$ " + totalrecaudacion_vencida);
            lbl_tot_vencida.Text = Convert.ToString("$ " + (totalrecaudacion_vencida));
            int sumarcarteras = 0;
            sumarcarteras = (totalrecaudacion_vencida + total_recaudacion_normal);
            lbl_normvenc.Text = Convert.ToString("$ " + (sumarcarteras));

            sql = "CALL SUMAR_RECAUDACION_CONTABILIDAD( '" + fecha + "','" + fecha + "') ;";
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

        private void Addrows(string[] filas)
        {
            dg4.Rows.Add(filas);
        }

        private void AddrowsVen(string[] filas)
        {
            dg5.Rows.Add(filas);
        }

        private void button2_Click(object sender, EventArgs e)
        {
            dg.SelectAll();
            dg.ClipboardCopyMode = DataGridViewClipboardCopyMode.EnableAlwaysIncludeHeaderText;

            DataObject dataObj = dg.GetClipboardContent();

            if (dataObj != null )
            {

                Clipboard.SetDataObject(dataObj);

            }

            dg.ClearSelection();

        }

        private void button4_Click(object sender, EventArgs e)
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

        private void button5_Click(object sender, EventArgs e)
        {
            dg3.SelectAll();
            dg3.ClipboardCopyMode = DataGridViewClipboardCopyMode.EnableAlwaysIncludeHeaderText;

            DataObject dataObj3 = dg3.GetClipboardContent();

            if (dataObj3 != null)
            {

                Clipboard.SetDataObject(dataObj3);

            }

            dg3.ClearSelection();
        }

        private void button6_Click(object sender, EventArgs e)
        {
            dg4.SelectAll();
            dg4.ClipboardCopyMode = DataGridViewClipboardCopyMode.EnableAlwaysIncludeHeaderText;

            DataObject dataObj4 = dg4.GetClipboardContent();

            if (dataObj4 != null)
            {

                Clipboard.SetDataObject(dataObj4);

            }

            dg4.ClearSelection();
        }

        private void button7_Click(object sender, EventArgs e)
        {
            dg5.SelectAll();
            dg5.ClipboardCopyMode = DataGridViewClipboardCopyMode.EnableAlwaysIncludeHeaderText;

            DataObject dataObj5 = dg5.GetClipboardContent();

            if (dataObj5 != null)
            {

                Clipboard.SetDataObject(dataObj5);

            }

            dg5.ClearSelection();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            dg.DataSource = null;
            dg2.DataSource = null;
            dg3.DataSource = null;
            dg4.Rows.Clear();
            dg5.Rows.Clear();
            dg6.DataSource = null;
            lbl_capital.Text = "0";
            lbl_centropago.Text = "0";
            lbl_desglose.Text = "0";
            lbl_finvencida.Text = "0";
            lbl_gastcobrnzavenc.Text = "0";
            lbl_interes.Text = "0";
            lbl_normvenc.Text = "0";
            lbl_recaudacionnormal.Text = "0";
            lbl_recaudacionvencida.Text = "0";
            lbl_tot_normal.Text = "0";
            lbl_tot_vencida.Text = "0";
            lbl_transac.Text = "0";
            lbl_sumabonos.Text = "0";
            lbl_debe.Text = "0";
            lbl_haber.Text = "0";


        }

        private void lbl_recaudacion_total_Load(object sender, EventArgs e)
        {
            dateTimePicker1.Value = DateTime.Now;
            dateTimePicker2.Value = DateTime.Now;
        }

  

        private void button9_Click(object sender, EventArgs e)
        {
            if ( dg6.RowCount > 0) {
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
                for (int i = 0; i < grd.Rows.Count ; i++)
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

        private void tabControl1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void dateTimePicker2_ValueChanged(object sender, EventArgs e)
        {

        }

        private void dateTimePicker1_ValueChanged(object sender, EventArgs e)
        {

        }
    }
}

