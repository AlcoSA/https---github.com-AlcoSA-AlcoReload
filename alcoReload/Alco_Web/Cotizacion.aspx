<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Cotizacion.aspx.cs" Inherits="Alco_Web.Cotizacion" %>

<%@ Register Assembly="CrystalDecisions.Web, Version=13.0.2000.0, Culture=neutral, PublicKeyToken=692fbea5521e1304" Namespace="CrystalDecisions.Web" TagPrefix="CR" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml" lang="es">
<head runat="server">
<%--<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>--%>       
<meta name="viewport" content="width=device-width, initial-scale=1" charset="utf-8"/>
    <title>Aprobación Cotizaciones</title>
    <link href="Content/bootstrap-theme.css" rel="stylesheet" />
    <link href="Content/bootstrap.css" rel="stylesheet" />
    <link href="Content/bootstrap.min.css" rel="stylesheet" />
    <link href="Content/themes/base/jquery-ui.min.css" rel="stylesheet" />
    <script src="Scripts/jquery-3.1.1.js"></script>
    <script src="Scripts/jquery-ui-1.12.1.js"></script>
  <script>
      $(document).ready(function () {
          $("#dialog_comentarios").hide();
          $("#dialog_error").hide();
          $("#error").hide();
          $("#exito").hide();
          $("#error_validacion").hide();
          $("#btnaprobar").click(function () {

              var idorden = $("#<%= hfidcotiza.ClientID %>").val();              
              if (idorden > 0)
              {
                    $("#dialog_comentarios").dialog({
                    resizable: false,
                    height: 450,
                    width: 400,
                    modal: true,
                    buttons: {
                        "Enviar": function () {
                            var nombre = $("#<%= txtnombre.ClientID %>").val(); 
                            var cedula = $("#<%= txtcedula.ClientID %>").val();                            
                            var cargo = $("#<%= txtcargo.ID %>").val();
                            var correo = $("#<%= txtcorreo.ID %>").val();
                            var mensaje = $("#<%= txtobservaciones.ClientID %>").val();

                            if (ValidarDatos(nombre, cedula, correo, cargo) == 1) {
                                $('#lberror').html("");
                                $("#error_validacion").hide();
                                AplicarOperacion(22, nombre, cedula, correo, cargo, mensaje);
                                $(this).dialog("close");
                                location.reload();
                            }                            
                        }
                    }
                });
              }
              else
              {
                  $("#dialog_error").dialog({
                    resizable: false,
                    height: 200,
                    width: 350,
                    modal: true,
                    buttons: {
                        "Cerrar": function () {                                                    
                            $(this).dialog("close");
                        }
                    }
                });
              }
                return false;
          });

          $("#btnrechazar").click(function () {
              var idorden = $("#<%= hfidcotiza.ClientID %>").val();
                if (idorden > 0)
              {
                    $("#dialog_comentarios").dialog({
                    resizable: false,
                    height: 450,
                    width: 400,
                    modal: true,
                    buttons: {
                        "Enviar": function () {
                        var nombre = $("#<%= txtnombre.ClientID %>").val();  
                        var cedula = $("#<%= txtcedula.ClientID %>").val();                            
                        var cargo = $("#<%= txtcargo.ClientID %>").val();
                        var correo= $("#<%= txtcorreo.ClientID %>").val();
                        var mensaje = $("#<%= txtobservaciones.ClientID %>").val();
                        if (ValidarDatos(nombre, cedula, correo, cargo) == 1) {
                            $('#lberror').html("");
                            $("#error_validacion").hide();
                            AplicarOperacion(28, nombre, cedula, correo, cargo, mensaje);
                            $(this).dialog("close");
                            location.reload();
                        }
                        }
                    }
                });
              }
              else
              {
                  $("#dialog_error").dialog({
                    resizable: false,
                    height: 200,
                    width: 350,
                    modal: true,
                    buttons: {
                        "Cerrar": function () {                                                    
                            $(this).dialog("close");
                        }
                    }
                });
              }
              return false;
          });
      });
    
      function ValidarDatos(nombre, cedula, correo, cargo)
      {
          var valor_retorno = 1;          
          var error_validacion = "";

            if (nombre.trim() == "" || cedula.trim() == "" || cargo.trim() == "" || correo.trim() == "") {                                
                error_validacion = "los campos con (*) son obligatorios, verifique la información";                                
                valor_retorno = 0;
            }
            var regex_correo = /^(?:[^<>()[\].,;:\s@"]+(\.[^<>()[\].,;:\s@"]+)*|"[^\n"]+")@(?:[^<>()[\].,;:\s@"]+\.)+[^<>()[\]\.,;:\s@"]{2,63}$/i;
            if (!(regex_correo.test(correo))) {
                $("#<%= lberror.ClientID %>").html('El campo de correo no tiene el formato correcto xxxxx@xxxx.xxx[.xx]');                                
                error_validacion = "El campo de correo no tiene el formato correcto xxxxx@xxxx.xxx[.xx]";                                
                valor_retorno = 0;
            }
          if (valor_retorno==0)
            {
                $('#lberror').html(error_validacion);
                $("#error_validacion").show();
            }

          return valor_retorno;
      }

    function AplicarOperacion(operacion, nombre, cedula, correo, cargo, mensaje) {
        var pageUrl = '<%= ResolveUrl("~/Cotizacion.aspx/OperacionCotiza") %>';
        var idcot = $("#<%= hfidcotiza.ClientID %>").val();
        var ip = $("#<%= lbip.ClientID %>").val();
        var parameter = {
            "idcotizacion": idcot, "operacion": operacion,
            "nombre" :nombre,
            "correo" :correo,
            "cedula" :cedula,
            "cargo" : cargo,
            "mensaje": mensaje, "ip": ip
        };
        $.ajax({
            type: 'POST',
            url: pageUrl,
            data: JSON.stringify(parameter),
            contentType: 'application/json; charset=utf-8',
            dataType: 'json',
            success: function (data) {
                $("#exito").show();
            },
            error: function (data, success, error) {
                $("#error").show();
            }
        });
        }

  </script>

</head>
<body>

    <form id="frmaprueba" runat="server">
    <div class="well text-center">
            <h1>Aprobación Cotizaciones</h1>            
    </div>  
        
      <div class="container">
           <div class="text-center">                
                <p>Direccion: <asp:Label ID="lbip" runat="server" Text="--"></asp:Label></p> 
               <asp:HiddenField ID="hfidcotiza" runat="server" Value="0" />       
            </div>

              <div id="exito" class="alert alert-success alert-dismissable fade in" runat="server" visible="False">
                <a href="#" class="close" data-dismiss="alert" aria-label="close">&times;</a>
                <strong>Éxito</strong> La operación se ha ejecutado exitosamente.
              </div>
              <div id="error" class="alert alert-danger alert-dismissable fade in" runat="server" visible="False">
                <a href="#" class="close" data-dismiss="alert" aria-label="close">&times;</a>
                <strong>Error!</strong> La operación no se ha ejecutado correctamente. Intente Nuevamente.
              </div> 

          	<div class="btn-group-sm">  
                <button runat="server" class="btn btn-primary btn-sm" onserverclick="btnimprimir_Click" >
                    <span aria-hidden="true" class="glyphicon glyphicon-print"></span>Imprimir
                </button>
                 <button runat="server" class="btn btn-primary btn-sm" onserverclick="btnexportar_Click" >
                    <span aria-hidden="true" class="glyphicon glyphicon-export"></span>Exportar
                </button>
                 <button runat="server" class="btn btn-primary btn-sm" onserverclick="btnprimerapagina_Click" >
                    <span aria-hidden="true" class="glyphicon glyphicon-step-backward"></span>
                </button>
                 <button runat="server" class="btn btn-primary btn-sm" onserverclick="btnanterior_Click" >
                    <span aria-hidden="true" class="glyphicon glyphicon-triangle-left"></span>
                </button>
                 <button runat="server" class="btn btn-primary btn-sm" onserverclick="btnsiguiente_Click" >
                    <span aria-hidden="true" class="glyphicon glyphicon-triangle-right"></span>
                </button>
                 <button runat="server" class="btn btn-primary btn-sm" onserverclick="btnultimapagina_Click" >
                    <span aria-hidden="true" class="glyphicon glyphicon-step-forward"></span>
                </button> 
                 <asp:DropDownList ID="ddlzoom" CssClass="btn btn-primary dropdown-toggle" runat="server" AutoPostBack="True" OnTextChanged="ddlzoom_TextChanged">
                        <asp:ListItem>75%</asp:ListItem>
                        <asp:ListItem>100%</asp:ListItem>
                        <asp:ListItem Selected="True">125%</asp:ListItem>
                        <asp:ListItem>150%</asp:ListItem>
                        <asp:ListItem>175%</asp:ListItem>
                        <asp:ListItem>200%</asp:ListItem>
                 </asp:DropDownList>                
                 <button runat="server" class="btn btn-success btn-sm" id="btnaprobar">
                      Aprobar Cotización <span aria-hidden="true" class="glyphicon glyphicon-ok-circle"></span> 
                 </button>
                 <button runat="server" class="btn btn-danger btn-sm" id="btnrechazar">
                     Rechazar Cotización <span aria-hidden="true" class="glyphicon glyphicon-remove-circle"></span> 
                 </button>
            </div>
            <div class="center-block">
                <CR:CrystalReportViewer ID="crvreporte" runat="server" BestFitPage="False" EnableTheming="True" ToolPanelView="None" DisplayStatusbar="False" EnableDatabaseLogonPrompt="False" EnableDrillDown="False" EnableParameterPrompt="False" DisplayToolbar="False" HasToggleGroupTreeButton="False" HasToggleParameterPanelButton="False" PrintMode="ActiveX" Width="100%" PageZoomFactor="125" />
            </div>

            <div class="btn-group-sm">  
                <button runat="server" class="btn btn-primary btn-sm" onserverclick="btnimprimir_Click" >
                    <span aria-hidden="true" class="glyphicon glyphicon-print"></span>Imprimir
                </button>
                 <button runat="server" class="btn btn-primary btn-sm" onserverclick="btnexportar_Click" >
                    <span aria-hidden="true" class="glyphicon glyphicon-export"></span>Exportar
                </button>
                 <button runat="server" class="btn btn-primary btn-sm" onserverclick="btnprimerapagina_Click" >
                    <span aria-hidden="true" class="glyphicon glyphicon-step-backward"></span>
                </button>
                 <button runat="server" class="btn btn-primary btn-sm" onserverclick="btnanterior_Click" >
                    <span aria-hidden="true" class="glyphicon glyphicon-triangle-left"></span>
                </button>
                 <button runat="server" class="btn btn-primary btn-sm" onserverclick="btnsiguiente_Click" >
                    <span aria-hidden="true" class="glyphicon glyphicon-triangle-right"></span>
                </button>
                 <button runat="server" class="btn btn-primary btn-sm" onserverclick="btnultimapagina_Click" >
                    <span aria-hidden="true" class="glyphicon glyphicon-step-forward"></span>
                </button> 
                 <asp:DropDownList ID="ddlbuttonb" CssClass="btn btn-primary dropdown-toggle" runat="server" AutoPostBack="True" OnTextChanged="ddlzoom_TextChanged">
                        <asp:ListItem>75%</asp:ListItem>
                        <asp:ListItem>100%</asp:ListItem>
                        <asp:ListItem Selected="True">125%</asp:ListItem>
                        <asp:ListItem>150%</asp:ListItem>
                        <asp:ListItem>175%</asp:ListItem>
                        <asp:ListItem>200%</asp:ListItem>
                 </asp:DropDownList>
            </div>

            <div class ="text-center">
                <%--<footer>--%>
                <p>&copy;<%: DateTime.Now.Year %> -Alco S.A</p>
                <%--</footer>--%>
            </div>
            <div id="dialog_comentarios" title="Información" visible="False">
                
                <div class="form-group">
                    <label for="txtNombre">Nombre(*)</label>
                    <input runat="server" class="form-control" maxlength="20" id="txtnombre" placeholder="Ingrese su nombre"/>
                </div>
                <div class="form-group">
                  <label for="txtcedula">Cedula(*):</label>
                    <input runat="server" class="form-control" maxlength="20" id="txtcedula" placeholder="Ingrese su cedula"/>
                </div>
                <div class="form-group">
                  <label for="txtcargo">Cargo(*):</label>
                    <input runat="server" class="form-control" maxlength="50" id="txtcargo" placeholder="Cargo en la empresa"/>
                </div>
                <div class="form-group">
                  <label for="txtcorreo">Email(*):</label>
                    <input runat="server" maxlength="50" class="form-control" id="txtcorreo" placeholder="Correo empresarial"/>
                </div>
                <div class="form-group">
                  <label for="txtobservaciones">Observaciones:</label>
                    <asp:TextBox ID="txtobservaciones"
                    runat="server"
                    class="form-control"
                    Font-Size="Medium"
                    Height="70px"
                    TextMode="MultiLine"
                    MaxLength="1000"
                    ToolTip="En este campo describa brevemente las observaciones que tiene acerca del pedido."></asp:TextBox>
                </div>
                <div id="error_validacion" class="alert alert-danger" visible="false">
                    <strong>Error!</strong> <asp:Label ID="lberror" class="ui-state-error-text" runat="server"></asp:Label>
                </div>                
            </div>

            <div id="dialog_error" title="Operacion no permitida" visible="False">
                <p>No hay ninguna cotización disponible</p>
            </div>
        </div>
    </form>
</body>
    
</html>

