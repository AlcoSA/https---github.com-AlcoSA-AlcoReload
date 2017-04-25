using System;
using System.Data;

namespace FormatosExportacion.Excel
{
    public class Excel_XML : Base_Exportacion
    {
        public Excel_XML(string ruta, string usuario) : base(ruta, usuario)
        { }
        public void Exportar(DataTable[] tablas)
        {
            try
            {
                System.IO.StreamWriter fs = new System.IO.StreamWriter(ruta, false);
                #region Encabezado
                fs.WriteLine(@"<?xml version=""1.0""?>");
                fs.WriteLine(@"<?mso-application progid=""Excel.Sheet""?>");
                fs.WriteLine(@"<Workbook xmlns=""urn:schemas-microsoft-com:office:spreadsheet""");
                fs.WriteLine(@" xmlns:o=""urn:schemas-microsoft-com:office:office""");
                fs.WriteLine(@" xmlns:x=""urn:schemas-microsoft-com:office:excel""");
                fs.WriteLine(@" xmlns:ss=""urn:schemas-microsoft-com:office:spreadsheet""");
                fs.WriteLine(@" xmlns:html=""http://www.w3.org/TR/REC-html40"">");
                fs.WriteLine(@" <DocumentProperties xmlns=""urn:schemas-microsoft-com:office:office"">");
                fs.WriteLine(@"  <Author>" + usuariocreacion + "</Author>");
                fs.WriteLine(@"  <LastAuthor> " + usuariocreacion + "</LastAuthor>");
                fs.WriteLine(@"  <Created>" + DateTime.Now.ToLongTimeString() + "</Created>");
                fs.WriteLine(@"  <Version>15.00</Version>");
                fs.WriteLine(@" </DocumentProperties>");
                fs.WriteLine(@" <OfficeDocumentSettings xmlns=""urn:schemas-microsoft-com:office:office"">");
                fs.WriteLine(@"  <AllowPNG/>");
                fs.WriteLine(@" </OfficeDocumentSettings>");
                #endregion

                fs.WriteLine(@" <ExcelWorkbook xmlns=""urn:schemas-microsoft-com:office:excel"">");
                fs.WriteLine(@"  <WindowHeight>600</WindowHeight>");
                fs.WriteLine(@"  <WindowWidth>800</WindowWidth>");
                fs.WriteLine(@"  <WindowTopX>0</WindowTopX>");
                fs.WriteLine(@"  <WindowTopY>0</WindowTopY>");
                fs.WriteLine(@"  <ProtectStructure>False</ProtectStructure>");
                fs.WriteLine(@"  <ProtectWindows>False</ProtectWindows>");
                fs.WriteLine(@" </ExcelWorkbook>");
                fs.WriteLine(@" <Styles>");

                #region Estilo de celda predeterminado
                fs.WriteLine(@" <Style ss:ID=""Default"" ss:Name=""Normal"">");
                fs.WriteLine(@"  <Alignment ss:Vertical=""Bottom""/>");
                fs.WriteLine(@"  <Borders/>");
                fs.WriteLine(@"  <Font ss:FontName=""Calibri"" x:Family=""Swiss"" ss:Size=""11"" ss:Color=""#000000""/>");
                fs.WriteLine(@"  <Interior/>");
                fs.WriteLine(@"  <NumberFormat/>");
                fs.WriteLine(@"  <Protection/>");
                fs.WriteLine(@" </Style>");
                #endregion

                #region Estilo s30
                fs.WriteLine(@" <Style ss:ID=""s30"" ss:Name=""Salida"">");
                fs.WriteLine(@"  <Borders>");
                fs.WriteLine(@"   <Border ss:Position=""Bottom"" ss:LineStyle=""Continuous"" ss:Weight=""1"" ss:Color=""#3F3F3F""/>");
                fs.WriteLine(@"   <Border ss:Position=""Left"" ss:LineStyle=""Continuous"" ss:Weight=""1"" ss:Color=""#3F3F3F""/>");
                fs.WriteLine(@"   <Border ss:Position=""Right"" ss:LineStyle=""Continuous"" ss:Weight=""1"" ss:Color=""#3F3F3F""/>");
                fs.WriteLine(@"   <Border ss:Position=""Top"" ss:LineStyle=""Continuous"" ss:Weight=""1"" ss:Color=""#3F3F3F""/>");
                fs.WriteLine(@"  </Borders>");
                fs.WriteLine(@"  <Font ss:FontName=""Calibri"" x:Family=""Swiss"" ss:Size=""11"" ss:Color=""#3F3F3F"" ss:Bold=""0""/>");
                fs.WriteLine(@"  <Interior ss:Color=""#F2F2F2"" ss:Pattern=""Solid""/>");
                fs.WriteLine(@" </Style>");
                #endregion

                #region Estilo s66
                fs.WriteLine(@" <Style ss:ID=""s66"" ss:Parent=""s30"">");
                fs.WriteLine(@"  <Alignment ss:Horizontal=""Center"" ss:Vertical=""Bottom"" ss:WrapText=""1""/>");
                fs.WriteLine(@"  <Borders>");
                fs.WriteLine(@"   <Border ss:Position=""Bottom"" ss:LineStyle=""Continuous"" ss:Weight=""1""/>");
                fs.WriteLine(@"   <Border ss:Position=""Left"" ss:LineStyle=""Continuous"" ss:Weight=""1""/>");
                fs.WriteLine(@"   <Border ss:Position=""Right"" ss:LineStyle=""Continuous"" ss:Weight=""1""/>");
                fs.WriteLine(@"   <Border ss:Position=""Top"" ss:LineStyle=""Continuous"" ss:Weight=""1""/>");
                fs.WriteLine(@"  </Borders>");
                fs.WriteLine(@" </Style>");
                #endregion

                #region Estilo s67
                fs.WriteLine(@" <Style ss:ID=""s67"">");
                fs.WriteLine(@"  <Alignment ss:Horizontal=""Center"" ss:Vertical=""Bottom"" ss:WrapText=""1""/>");
                fs.WriteLine(@"  <Borders>");
                fs.WriteLine(@"   <Border ss:Position=""Bottom"" ss:LineStyle=""Continuous"" ss:Weight=""1""/>");
                fs.WriteLine(@"   <Border ss:Position=""Left"" ss:LineStyle=""Continuous"" ss:Weight=""1""/>");
                fs.WriteLine(@"   <Border ss:Position=""Right"" ss:LineStyle=""Continuous"" ss:Weight=""1""/>");
                fs.WriteLine(@"   <Border ss:Position=""Top"" ss:LineStyle=""Continuous"" ss:Weight=""1""/>");
                fs.WriteLine(@"  </Borders>");
                fs.WriteLine(@" </Style>");
                #endregion

                #region Estilo s68
                fs.WriteLine(@" <Style ss:ID=""s68"">");
                fs.WriteLine(@"  <Alignment ss:Horizontal=""Center"" ss:Vertical=""Bottom"" ss:WrapText=""1""/>");
                fs.WriteLine(@"  <NumberFormat ss:Format=""Standard""/>");
                fs.WriteLine(@"  <Borders>");
                fs.WriteLine(@"   <Border ss:Position=""Bottom"" ss:LineStyle=""Continuous"" ss:Weight=""1""/>");
                fs.WriteLine(@"   <Border ss:Position=""Left"" ss:LineStyle=""Continuous"" ss:Weight=""1""/>");
                fs.WriteLine(@"   <Border ss:Position=""Right"" ss:LineStyle=""Continuous"" ss:Weight=""1""/>");
                fs.WriteLine(@"   <Border ss:Position=""Top"" ss:LineStyle=""Continuous"" ss:Weight=""1""/>");
                fs.WriteLine(@"  </Borders>");
                fs.WriteLine(@" </Style>");
                #endregion

                #region Estilo s69
                fs.WriteLine(@" <Style ss:ID=""s69"">");
                fs.WriteLine(@"  <Alignment ss:Horizontal=""Center"" ss:Vertical=""Bottom"" ss:WrapText=""1""/>");
                fs.WriteLine(@"  <NumberFormat ss:Format=""0""/>");
                fs.WriteLine(@"  <Borders>");
                fs.WriteLine(@"   <Border ss:Position=""Bottom"" ss:LineStyle=""Continuous"" ss:Weight=""1""/>");
                fs.WriteLine(@"   <Border ss:Position=""Left"" ss:LineStyle=""Continuous"" ss:Weight=""1""/>");
                fs.WriteLine(@"   <Border ss:Position=""Right"" ss:LineStyle=""Continuous"" ss:Weight=""1""/>");
                fs.WriteLine(@"   <Border ss:Position=""Top"" ss:LineStyle=""Continuous"" ss:Weight=""1""/>");
                fs.WriteLine(@"  </Borders>");
                fs.WriteLine(@" </Style>");
                #endregion

                #region Estilo s70
                fs.WriteLine(@" <Style ss:ID=""s70"">");
                fs.WriteLine(@"  <Alignment ss:Horizontal=""Center"" ss:Vertical=""Bottom"" ss:WrapText=""1""/>");
                fs.WriteLine(@"  <NumberFormat ss:Format=""Short Date""/>");
                fs.WriteLine(@"  <Borders>");
                fs.WriteLine(@"   <Border ss:Position=""Bottom"" ss:LineStyle=""Continuous"" ss:Weight=""1""/>");
                fs.WriteLine(@"   <Border ss:Position=""Left"" ss:LineStyle=""Continuous"" ss:Weight=""1""/>");
                fs.WriteLine(@"   <Border ss:Position=""Right"" ss:LineStyle=""Continuous"" ss:Weight=""1""/>");
                fs.WriteLine(@"   <Border ss:Position=""Top"" ss:LineStyle=""Continuous"" ss:Weight=""1""/>");
                fs.WriteLine(@"  </Borders>");
                fs.WriteLine(@" </Style>");
                #endregion

                #region Estilo s71
                fs.WriteLine(@" <Style ss:ID=""s71"">");
                fs.WriteLine(@"  <Alignment ss:Horizontal=""Center"" ss:Vertical=""Bottom"" ss:WrapText=""1""/>");
                fs.WriteLine(@"  <NumberFormat ss:Format=""Standard""/>");
                fs.WriteLine(@"  <Borders>");
                fs.WriteLine(@"   <Border ss:Position=""Top"" ss:LineStyle=""Continuous"" ss:Weight=""1""/>");
                fs.WriteLine(@"  </Borders>");
                fs.WriteLine(@" </Style>");
                #endregion

                fs.WriteLine(@" </Styles>");
                for(int i=0;i<tablas.Length;i++)
                {
                    fs.WriteLine(@" <Worksheet ss:Name=""" + "Hoja"  + i.ToString() + @""">");
                    fs.WriteLine(@" <Table ss:ExpandedColumnCount=""" + Convert.ToString(tablas[i].Columns.Count) + @""" ss:ExpandedRowCount="""
                        + Convert.ToString(tablas[i].Rows.Count+1) + @""" x:FullColumns=""1""" +
                        "\n" + @"  x:FullRows=""1"" ss:DefaultColumnWidth=""60"" ss:DefaultRowHeight=""15"">");
                    fs.WriteLine("   <Row>");
                    for (int c=0;c<tablas[i].Columns.Count;c++)
                    {
                        fs.WriteLine(@"    <Cell ss:StyleID=""s66""><Data ss:Type=""String"">" + tablas[i].Columns[c].Caption + "</Data></Cell>");
                    }
                    fs.WriteLine("   </Row>");

                    for(int r=0; r < tablas[i].Rows.Count; r++)
                    {
                        fs.WriteLine("   <Row>");
                        for (int c = 0; c < tablas[i].Columns.Count; c++)
                        {
                            string valor = Convert.ToString(tablas[i].Rows[r].ItemArray[c]);
                            string formato = string.Empty;
                            string estilo = string.Empty;
                            FormatoValor(valor, tablas[i].Columns[c], out formato, out estilo);
                            fs.WriteLine(@"    <Cell ss:StyleID=""" + estilo + @"""><Data ss:Type=""" + formato + @""">" + valor + "</Data></Cell>");
                        }
                        fs.WriteLine("   </Row>");
                    }
                    fs.WriteLine(@"  </Table>");
                    fs.WriteLine(@"  <WorksheetOptions xmlns=""urn:schemas-microsoft-com:office:excel"">");
                    fs.WriteLine(@"   <PageSetup>");
                    fs.WriteLine(@"    <Header x:Margin=""0.3""/>");
                    fs.WriteLine(@"    <Footer x:Margin=""0.3""/>");
                    fs.WriteLine(@"    <PageMargins x:Bottom=""0.75"" x:Left=""0.7"" x:Right=""0.7"" x:Top=""0.75""/>");
                    fs.WriteLine(@"   </PageSetup>");
                    fs.WriteLine(@"   <Unsynced/>");
                    fs.WriteLine(@"   <Print>");
                    fs.WriteLine(@"    <ValidPrinterInfo/>");
                    fs.WriteLine(@"    <HorizontalResolution>1200</HorizontalResolution>");
                    fs.WriteLine(@"    <VerticalResolution>1200</VerticalResolution>");
                    fs.WriteLine(@"   </Print>");
                    fs.WriteLine(@"   <Selected/>");
                    fs.WriteLine(@"   <ProtectObjects>False</ProtectObjects>");
                    fs.WriteLine(@"   <ProtectScenarios>False</ProtectScenarios>");
                    fs.WriteLine(@"  </WorksheetOptions>");
                    fs.WriteLine(@" </Worksheet>");
                }
                fs.WriteLine("</Workbook>");
                fs.Flush();
                fs.Close();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message, ex.InnerException);
            }
        }


        private void FormatoValor(string valor, DataColumn columna, out string valorconformato, out string estilo)
        {
            try
            {
                valorconformato = string.Empty;
                estilo = string.Empty;

                if (columna.DataType == typeof(int) || columna.DataType == typeof(long))
                {
                    valorconformato = "Number";
                    estilo = "s69";
                }
                else if (columna.DataType == typeof(decimal) || columna.DataType == typeof(double) || columna.DataType == typeof(Single))
                {
                    valorconformato = "Number";
                    estilo = "s68";
                }
                else
                {
                    valorconformato = "String";
                    estilo = "s70";
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message, ex.InnerException);
            }
        }  
    }
}
