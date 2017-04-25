using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using ReglasNegocio;
using System.Web.Services;
using System.Security.Cryptography;
using System.IO;
using System.Text;
using ReglasNegocio.cotizaciones;

namespace Alco_Web
{
    public partial class Cotizacion : System.Web.UI.Page
    {
        #region Variables
        Informes.CotizacionClienteV rpt;
        private int id_cotizacion = 0;
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
            if (id_cotizacion > 0)
            {
                Informes.datosInformesTableAdapters.sp_tc016_selectByIdXMLTableAdapter mCot = new Informes.datosInformesTableAdapters.sp_tc016_selectByIdXMLTableAdapter();
                Informes.datosInformesTableAdapters.sp_tc017_selectByIdCotizaXMLTableAdapter mCotPadres = new Informes.datosInformesTableAdapters.sp_tc017_selectByIdCotizaXMLTableAdapter();
                Informes.datosInformesTableAdapters.sp_tc072_selectbyIdContizaXMLTableAdapter mCondiciones = new Informes.datosInformesTableAdapters.sp_tc072_selectbyIdContizaXMLTableAdapter();
                System.Data.DataTable tbcotiza = mCot.GetData(id_cotizacion);
                System.Data.DataTable tbpadres = mCotPadres.GetData(id_cotizacion);
                System.Data.DataTable tbCondiciones = mCondiciones.GetData(id_cotizacion);         
                System.Data.DataSet ds = new System.Data.DataSet();
                ds.Tables.Add(tbcotiza);
                ds.Tables.Add(tbpadres);
                ds.Tables.Add(tbCondiciones);                
                rpt = new Informes.CotizacionClienteV();
                rpt.SetDataSource(ds);
                crvreporte.ReportSource = rpt;
                if (Session["reporte_cotiza"] == null)
                {
                    Session.Add("reporte_cotiza", rpt);
                }
                else
                {
                    Session["reporte_cotiza"] = rpt;
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
            //ddlzoom.SelectedIndex = ddlzoom.Items.IndexOf(ddlzoom.Items.FindByValue(Convert.ToString(crvreporte.PageZoomFactor) + "%"));
            var obtener_parametro = Request.QueryString["id_cotiza"];
            lbip.Text = ObtenerDireccionIP();            
            if (obtener_parametro != null)
            {

                id_cotizacion = Convert.ToInt32(DesencriptarParametro(HttpUtility.UrlDecode(obtener_parametro)));
                hfidcotiza.Value = Convert.ToString(id_cotizacion);
                bool cambio = false;
                if (Session["id_cotiza"] == null)
                {
                    Session.Add("id_cotiza", id_cotizacion);                    
                    cambio = true;
                }
                else
                {
                    if (Convert.ToInt32(Session["id_cotiza"]) != id_cotizacion)
                    {
                        Session["id_cotiza"] = id_cotizacion;
                        cambio = true;
                    }
                }

                ReglasNegocio.cotizaciones.ClsCostizaciones c_cot = new ReglasNegocio.cotizaciones.ClsCostizaciones();
                ClsEnums.Estados estado = (ClsEnums.Estados)c_cot.TraerxId(id_cotizacion).Estado_Aprobacion;
                if (estado != ClsEnums.Estados.ACTIVO && estado != ClsEnums.Estados.ENVIADO)
                {
                    btnrechazar.Visible = false;
                    btnaprobar.Visible = false;
                }
                else
                {
                    btnrechazar.Visible = true;
                    btnaprobar.Visible = true;
                }
                if (Session["reporte_cotiza"] == null || cambio)
                {
                    cargar_Informe();
                }
            }
        }
        protected void Page_Init(object sender, EventArgs e)
        {
            if (Session["reporte_cotiza"] != null)
            {
                crvreporte.ReportSource = (Informes.CotizacionClienteV)Session["reporte_cotiza"];
            }
        }
        [WebMethod]
        public static void OperacionCotiza(int idcotizacion, int operacion,
            string correo,
            string nombre,
            string cedula,
            string cargo,
            string mensaje,
            string ip)
        {
            ReglasNegocio.cotizaciones.ClsCostizaciones c_cot = new ReglasNegocio.cotizaciones.ClsCostizaciones();
            ClsUtilidades_Web_Mail utilm = new ClsUtilidades_Web_Mail();
            ClsHistorialCorreosCotizacion c_hist = new ClsHistorialCorreosCotizacion();
            c_cot.ActualizarAprobacionCliente(idcotizacion, operacion);
            string asunto = string.Empty;
            switch ((ClsEnums.Estados)operacion)
            {
                case ClsEnums.Estados.APROBADO:
                    {
                        asunto = "Aprobación de cotización";
                        break;
                    }
                case ClsEnums.Estados.RECHAZADO:
                    {
                        asunto = "Rechazo de cotización";
                        break;
                    }
            }
            var hist = c_hist.TraerporIdCotizacion(idcotizacion)
                ;
            ClsCostizaciones mcotiza = new ClsCostizaciones();
            ClsVendedoresSiesa mVendedor = new ClsVendedoresSiesa();
            ClsDirectores mDirector = new ClsDirectores();
            vendedorDetalle vend = mVendedor.TraerVendedoresDetalle(mcotiza.TraerxId(idcotizacion).prefijoVendedor);
            director direct = mDirector.TraerxId(vend.IdDirector);

            //string destinos = direct.Correo + ";" + vend.Mail;
            //string destinos = direct.Correo + ";" + "svallejo@alco.com.co";
            string destinos = "svallejo@alco.com.co" + ";" + "svallejo@alco.com.co";
            string cuerpo = generarCuerpo(asunto, idcotizacion, nombre, cedula, correo, cargo, mensaje);
            

            utilm.EnviarCorreo(destinos, asunto, cuerpo, null, true);
            c_hist.Insertar(idcotizacion, ip, destinos, correo, nombre, cedula, cargo, asunto, mensaje);
        }

        private static string generarCuerpo(string asunto, int idCotiza, string nombre, string cedula,
            string correo, string cargo, string observaciones)
        {
            string cuerpo = string.Empty;
            ClsCostizaciones mCotiza = new ClsCostizaciones();
            cotizacion cot = mCotiza.TraerxId(idCotiza);
            cuerpo += "<html>";
            cuerpo += "<body>";
            if (asunto.Contains("Aprobación")){
                cuerpo += "<p><b>El cliente ha aprobado la cottización</b></p><br>";
            }
            else {
                cuerpo += "<p><b>El cliente ha aprobado la cottización</b></p><br>";
            }
            cuerpo += "<a>"+ DateTime.Now +"</a><br><br>";
            cuerpo += "<a><b>Cotización: </b></a>";
            cuerpo += "<a>" + cot.Id + "-" + cot.nombreCotizacion + "</a><br>";
            cuerpo += "<a><b>Obra: </b></a>";
            cuerpo += "<a>" + cot.nomObra + "</a><br>";
            cuerpo += "<a><b>Cliente: </b></a>";
            cuerpo += "<a>" + cot.cliente + "</a><br><br>";
            cuerpo += "<a>Nombre: " + nombre + "</a><br>";
            cuerpo += "<a>Documento: " + cedula +"</a><br>";
            cuerpo += "<a>Correo: </a>" + correo + "<br>";
            cuerpo += "<a>Cargo: </a>" + cargo + "<br>";
            cuerpo += "<a>Observaciones: </a>" + observaciones + "<br>";
            cuerpo += "</body>";
            cuerpo += "</html>";
            return cuerpo;
        }

        protected void btnimprimir_Click(object sender, EventArgs e)
        {
            Informes.CotizacionClienteV inf = (Informes.CotizacionClienteV)Session["reporte_cotiza"];
            if (inf != null)
            {
                inf.PrintToPrinter(1, false, 0, 0);
            }            
        }
        protected void btnexportar_Click(object sender, EventArgs e)
        {
            Informes.CotizacionClienteV inf = (Informes.CotizacionClienteV)Session["reporte_cotiza"];
            if (inf != null)
            {
                Informes.datosInformesTableAdapters.sp_tc016_selectByIdXMLTableAdapter mCot = new Informes.datosInformesTableAdapters.sp_tc016_selectByIdXMLTableAdapter();
                System.Data.DataTable tbcotiza = mCot.GetData(id_cotizacion);
                string nombre_doc = Convert.ToString(tbcotiza.Rows[0]["id"]) + "_" + Convert.ToString(tbcotiza.Rows[0]["nombreObra"]);
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