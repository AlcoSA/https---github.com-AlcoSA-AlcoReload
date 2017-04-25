using System;
using System.IO;
using System.Security.Cryptography;
using System.Text;
using System.Web;
using ReglasNegocio;
using System.Web.Services;
using System.Web.UI.WebControls;

namespace Web_Alco
{
    public partial class Default : System.Web.UI.Page
    {
        #region Variables
        ClsOrdenDePedido c_op;
        Informes.ordenPedidoCliente rpt;
        int id_orden = 0;
        #endregion
        #region Procedimientos
        private string DesencriptarParametro(string parametro)
        {
            string EncryptionKey = "MAKV2SPBNI99212";
            parametro = parametro.Replace(" ", "+");
            byte[] cipherBytes = Convert.FromBase64String(parametro);
            using (Aes encryptor = Aes.Create())
            {
                Rfc2898DeriveBytes pdb = new Rfc2898DeriveBytes(EncryptionKey, new byte[] { 0x49, 0x76, 0x61, 0x6e, 0x20, 0x4d, 0x65, 0x64, 0x76, 0x65, 0x64, 0x65, 0x76 });
                encryptor.Key = pdb.GetBytes(32);
                encryptor.IV = pdb.GetBytes(16);
                using (MemoryStream ms = new MemoryStream())
                {
                    using (CryptoStream cs = new CryptoStream(ms, encryptor.CreateDecryptor(), CryptoStreamMode.Write))
                    {
                        cs.Write(cipherBytes, 0, cipherBytes.Length);
                        cs.Close();
                    }
                    parametro = Encoding.Unicode.GetString(ms.ToArray());
                }
            }
            return parametro;
        }
        private void cargar_Informe()
        {
            if (id_orden > 0)
            {
                Informes.datosInformesTableAdapters.sp_tp002_selectByIdXMLTableAdapter tp002 = new Informes.datosInformesTableAdapters.sp_tp002_selectByIdXMLTableAdapter();
                Informes.datosInformesTableAdapters.sp_tp003_SelectPadresByIdOpXMLTableAdapter tp003 = new Informes.datosInformesTableAdapters.sp_tp003_SelectPadresByIdOpXMLTableAdapter();
                Informes.datosInformesTableAdapters.sp_tp004_selectHijosByIdOpXMLTableAdapter tp004 = new Informes.datosInformesTableAdapters.sp_tp004_selectHijosByIdOpXMLTableAdapter();
                System.Data.DataSet ds = new System.Data.DataSet();
                System.Data.DataTable tb1 = tp002.GetData(id_orden);
                System.Data.DataTable tb2 = tp003.GetData(id_orden);
                System.Data.DataTable tb3 = tp004.GetData(id_orden);
                ds.Tables.Add(tb1);
                ds.Tables.Add(tb2);
                ds.Tables.Add(tb3);
                rpt = new Informes.ordenPedidoCliente();
                rpt.SetDataSource(ds);
                crvreporte.ReportSource = rpt;
                if (Session["reporte_ordenpedido"] == null)
                {
                    Session.Add("reporte_ordenpedido", rpt);
                }
                else
                {
                    Session["reporte_ordenpedido"] = rpt;
                }

            }
        }
        protected string ObtenerDireccionIP()
        {
            System.Web.HttpContext context = System.Web.HttpContext.Current;
            string ipAddress = context.Request.ServerVariables["HTTP_X_FORWARDED_FOR"];

            if (!string.IsNullOrEmpty(ipAddress))
            {
                string[] addresses = ipAddress.Split(',');
                if (addresses.Length != 0)
                {
                    return addresses[0];
                }
            }

            return context.Request.ServerVariables["REMOTE_ADDR"];
        }
        #endregion        
        protected void Page_Load(object sender, EventArgs e)
        {            
            var obtener_parametro = Request.QueryString["id_ordenPed"];
            lbip.Text = ObtenerDireccionIP();
            c_op = new ClsOrdenDePedido();
            if (obtener_parametro != null)
            {
                id_orden = Convert.ToInt32(DesencriptarParametro(HttpUtility.UrlDecode(obtener_parametro)));
                hfidorden.Value =Convert.ToString(id_orden);

                bool cambio = false;
                if (Session["id_opedido"] == null)
                {
                    Session.Add("id_opedido", id_orden);
                    cambio = true;
                }
                else
                {
                    if (Convert.ToInt32(Session["id_opedido"]) != id_orden)
                    {
                        Session["id_opedido"] = id_orden;
                        cambio = true;
                    }
                }


                if (!((ClsEnums.Estados)c_op.TraerxIdOrden(id_orden).Aprobada_Cliente == ClsEnums.Estados.ACTIVO))
                {
                    btnaprobar.Visible = false;
                    btnrechazar.Visible = false;
                }
                if (!btnaprobar.Visible)
                {
                    exito.Attributes.Remove("hidden");
                    if (error.Attributes["hidden"] == null)
                    {
                        error.Attributes.Add("hidden", "hidden");
                    }
                }
                if (Session["reporte_ordenpedido"] == null || cambio)
                {
                    cargar_Informe();
                }
            }
        }
        protected void Page_Init(object sender, EventArgs e)
        {
            if (Session["reporte_ordenpedido"] != null)
            {
                crvreporte.ReportSource = (Informes.ordenPedidoCliente)Session["report"];
            }
        }
        [WebMethod]
        public static void OperacionPedido(int idordenped, int operacion,
            string correo,
            string cedula,
            string cargo,
            string mensaje,
            string ip)
        {
            ClsOrdenDePedido c_ord = new ClsOrdenDePedido();
            ClsUtilidades_Web_Mail utilm = new ClsUtilidades_Web_Mail();
            ClsHistorialCorreosOrdenPed c_hist = new ClsHistorialCorreosOrdenPed();
            c_ord.ActualizarEstadoAprobacionCliente(idordenped, operacion);
            
            string asunto = string.Empty;
            switch ((ClsEnums.Estados)operacion)
            {
                case ClsEnums.Estados.APROBADO:
                    {
                        asunto = "El cliente ha aprobado la orden de pedido";
                        break;
                    }
                case ClsEnums.Estados.RECHAZADO:
                    {
                        asunto = "El cliente ha rechazado la orden de pedido";
                        break;
                    }
            }
            var hist = c_hist.TraerporIdOrden(idordenped);
            string destino = "alco@alco.com.co";
            if (hist.Count > 0)
            {
                destino = hist[hist.Count - 1].Direccion_Envio;
            }
            utilm.EnviarCorreo("camiloa@alco.com.co", asunto, mensaje, null, true);
            c_hist.Insertar(idordenped, ip, destino, correo, cedula, cargo, asunto, mensaje);            

        }

        protected void btnimprimir_Click(object sender, EventArgs e)
        {
            Informes.ordenPedidoCliente inf = (Informes.ordenPedidoCliente)Session["reporte_ordenpedido"];
            if (inf != null)
            {
                inf.PrintToPrinter(1, false, 0, 0);
            }
        }
        protected void btnexportar_Click(object sender, EventArgs e)
        {
            Informes.ordenPedidoCliente inf = (Informes.ordenPedidoCliente)Session["reporte_ordenpedido"];
            if (inf != null)
            {
                Informes.datosInformesTableAdapters.sp_tp002_selectByIdXMLTableAdapter tp002 = new Informes.datosInformesTableAdapters.sp_tp002_selectByIdXMLTableAdapter();
                System.Data.DataTable tb = tp002.GetData(id_orden);
                string nombre_doc = Convert.ToString(tb.Rows[0]["Id"]) + "_" + Convert.ToString(tb.Rows[0]["Obra"]);
                inf.ExportToHttpResponse(CrystalDecisions.Shared.ExportFormatType.PortableDocFormat,
                    Response, true, nombre_doc);
            }
        }
        protected void btnprimerapagina_Click(object sender, EventArgs e)
        {
            crvreporte.ShowFirstPage();
        }
        protected void btnultimapagina_Click(object sender, EventArgs e)
        {
            crvreporte.ShowLastPage();
        }
        protected void btnsiguiente_Click(object sender, EventArgs e)
        {
            crvreporte.ShowNextPage();
        }
        protected void btnanterior_Click(object sender, EventArgs e)
        {
            crvreporte.ShowPreviousPage();
        }
        protected void ddlzoom_TextChanged(object sender, EventArgs e)
        {
            DropDownList cb = (DropDownList)sender;
            int factor = Convert.ToInt32(Convert.ToString(cb.SelectedItem).Replace("%", ""));
            crvreporte.PageZoomFactor = factor;
            crvreporte.Zoom(factor);
            crvreporte.RefreshReport();
        }
    }
}