using System;
using System.Diagnostics;
using System.Drawing;
using System.Drawing.Printing;
using System.Runtime.InteropServices;
using System.Windows.Forms;

namespace RichTextboxExtendido
{
    public enum Acciones
    {
        Imprimir = 0,
        VistaPrevia = 1,
        CalcularPaginacion = 2
    }

    public static class Extension
    {
        public static void Imprimir(this DocumentoExtendido control)
        {
            AyudanteImpresion helper = new AyudanteImpresion(control, Acciones.Imprimir);
            string hrtf = control.Header.Rtf;
            string brtf = control.Body.Rtf;
            string frtf = control.Footer.Rtf;
            helper.PrintRTF();
            control.Header.Rtf = hrtf;
            control.Body.Rtf = brtf;
            control.Footer.Rtf = frtf;
        }

        public static void Visualizar(this DocumentoExtendido control)
        {
            AyudanteImpresion helper = new AyudanteImpresion(control, Acciones.VistaPrevia);
            string hrtf = control.Header.Rtf;
            string brtf = control.Body.Rtf;
            string frtf = control.Footer.Rtf;
            helper.PrintRTF();
            control.Header.Rtf = hrtf;
            control.Body.Rtf = brtf;
            control.Footer.Rtf = frtf;
        }

        public static int CalcularPaginas(this DocumentoExtendido control)
        {
            AyudanteImpresion helper = new AyudanteImpresion(control, Acciones.CalcularPaginacion);
            helper.PrintRTF();
            return helper.TotalPaginas;
        }
    }

    public class AyudanteImpresion
    {
        #region Variables
        Acciones prevision = Acciones.Imprimir;
        DocumentoExtendido control;
        RichTextBox curPart;
        string footerRTF = string.Empty;
        int mpage = 1;
        int mpages = 0;
        #endregion
        #region Propiedades
        public int TotalPaginas
        {
            get
            { return mpages; }
        }
        #endregion

        /// <summary>
        /// Este procedimiento sirve para mostrar el asistente de impresión y sus opciones
        /// </summary>
        /// <param name="controlToPrint"></param>
        /// <param name="prev"></param>
        public AyudanteImpresion(DocumentoExtendido controlToPrint, Acciones tipoaccion)
        {
            control = controlToPrint;
            footerRTF = control.Footer.Rtf;
            prevision = tipoaccion;
            curPart = control.Body;
            //Con este fragmento se obtiene la cantidad total de paginas que tiene el documento.
            PrintDocument mdoc = new PrintDocument();
            mdoc.DefaultPageSettings.Margins = new Margins(control.Padding.Left, control.Padding.Right, control.Padding.Top, control.Padding.Bottom);
            Rectangle mrec = new Rectangle(0, 0, mdoc.DefaultPageSettings.PaperSize.Width, mdoc.DefaultPageSettings.PaperSize.Height);
            Bitmap bmp = new Bitmap(mdoc.DefaultPageSettings.PaperSize.Width, mdoc.DefaultPageSettings.PaperSize.Height);
            Graphics g = Graphics.FromImage(bmp);

            while (m_nFirstCharOnPage < control.Body.TextLength)
            {
                mpages++;
                m_nFirstCharOnPage = FormatRange(false,
                    new PrintPageEventArgs(g, mrec, mrec, mdoc.DefaultPageSettings)
                    ,
        m_nFirstCharOnPage,
        curPart.TextLength);
            }
            m_nFirstCharOnPage = 0;
        }

        /// <summary>
        /// Este procedimiento sirve para enviar el documento a la imopresora seleccionada
        /// </summary>
        public void PrintRTF()
        {
            PrintRTF(new PrintDocument());
        }

        /// <summary>
        /// Este procedimiento sirve para monitorear que el proceso de impresión se complete
        /// </summary>
        /// <param name="printDocument"></param>
        public void PrintRTF(PrintDocument printDocument)
        {
            try
            {
                printDocument.DefaultPageSettings.Margins = new Margins(control.Padding.Left, control.Padding.Right, control.Padding.Top, control.Padding.Bottom);

                printDocument.BeginPrint += new System.Drawing.Printing.PrintEventHandler(this.printDocument_BeginPrint);
                printDocument.EndPrint += new System.Drawing.Printing.PrintEventHandler(this.printDocument_EndPrint);
                printDocument.PrintPage += new System.Drawing.Printing.PrintPageEventHandler(this.printDocument_PrintPage);
                if (prevision == Acciones.VistaPrevia)
                {
                    PrintPreviewDialog prt = new PrintPreviewDialog();
                    prt.Document = printDocument;
                    prt.ShowDialog();
                }
                else if (prevision == Acciones.Imprimir)
                { printDocument.Print(); }
                else { }

            }
            catch (Exception ex)
            {
                Trace.WriteLine(ex.Message);
            }
        }


        private int m_nFirstCharOnPage;

        private void printDocument_BeginPrint(object sender, System.Drawing.Printing.PrintEventArgs e)
        {
            m_nFirstCharOnPage = 0;
        }

        /// <summary>
        /// Este procedimiento sirve para ordenar la impresión, es decir, encabezado, luego los formatos usados en el 
        /// documento, después el contenido y los pie de página.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void printDocument_PrintPage(object sender, System.Drawing.Printing.PrintPageEventArgs e)
        {

            // Des-comentar para dibujar Margen
            //e.Graphics.DrawRectangle(System.Drawing.Pens.Blue, e.MarginBounds);
            curPart = control.Header;

            FormatRange(false,
                e,
                0,
                curPart.TextLength);

            control.Footer.Rtf = footerRTF.Replace("pgs", mpages.ToString());
            control.Footer.Rtf = control.Footer.Rtf.Replace("pg", mpage.ToString());
            curPart = control.Footer;
            FormatRange(false,
                e,
                0,
                curPart.TextLength);

            mpage += 1;

            curPart = control.Body;
            m_nFirstCharOnPage = FormatRange(false,
                e,
                m_nFirstCharOnPage,
                curPart.TextLength);

            if (m_nFirstCharOnPage < control.Body.TextLength)
                e.HasMorePages = true;
            else
                e.HasMorePages = false;
        }

        /// <summary>
        /// Este evento se da cuando la impresión del documento ha finalizado
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void printDocument_EndPrint(object sender, System.Drawing.Printing.PrintEventArgs e)
        {
            FormatRangeDone();
        }


        [StructLayout(LayoutKind.Sequential)]
        private struct STRUCT_RECT
        {
            public Int32 left;
            public Int32 top;
            public Int32 right;
            public Int32 bottom;
        }
        [StructLayout(LayoutKind.Sequential)]
        private struct STRUCT_CHARRANGE
        {
            public Int32 cpMin;
            public Int32 cpMax;
        }

        [StructLayout(LayoutKind.Sequential)]
        private struct STRUCT_FORMATRANGE
        {
            public IntPtr hdc;
            public IntPtr hdcTarget;
            public STRUCT_RECT rc;
            public STRUCT_RECT rcPage;
            public STRUCT_CHARRANGE chrg;
        }

        [StructLayout(LayoutKind.Sequential)]
        private struct CHARFORMATSTRUCT
        {
            public int cbSize;
            public UInt32 dwMask;
            public UInt32 dwEffects;
            public Int32 yHeight;
            public Int32 yOffset;
            public Int32 crTextColor;
            public byte bCharSet;
            public byte bPitchAndFamily;
            [MarshalAs(UnmanagedType.ByValArray, SizeConst = 32)]
            public char[] szFaceName;
        }

        [DllImport("user32.dll")]
        private static extern Int32 SendMessage(IntPtr hWnd, Int32 msg,
            Int32 wParam, IntPtr lParam);

        // Definición de mensajes de windows
        private const Int32 WM_USER = 0x400;
        private const Int32 EM_FORMATRANGE = WM_USER + 57;
        private const Int32 EM_GETCHARFORMAT = WM_USER + 58;
        private const Int32 EM_SETCHARFORMAT = WM_USER + 68;

        // Definiciones para EM_SETCHARFORMAT/EM_GETCHARFORMAT
        private const Int32 SCF_SELECTION = 0x0001;
        private const Int32 SCF_WORD = 0x0002;
        private const Int32 SCF_ALL = 0x0004;

        // Definiciones para STRUCT_CHARFORMAT member dwMask
        private const UInt32 CFM_BOLD = 0x00000001;
        private const UInt32 CFM_ITALIC = 0x00000002;
        private const UInt32 CFM_UNDERLINE = 0x00000004;
        private const UInt32 CFM_STRIKEOUT = 0x00000008;
        private const UInt32 CFM_PROTECTED = 0x00000010;
        private const UInt32 CFM_LINK = 0x00000020;
        private const UInt32 CFM_SIZE = 0x80000000;
        private const UInt32 CFM_COLOR = 0x40000000;
        private const UInt32 CFM_FACE = 0x20000000;
        private const UInt32 CFM_OFFSET = 0x10000000;
        private const UInt32 CFM_CHARSET = 0x08000000;

        // Definiciones para STRUCT_CHARFORMAT member dwEffects
        private const UInt32 CFE_BOLD = 0x00000001;
        private const UInt32 CFE_ITALIC = 0x00000002;
        private const UInt32 CFE_UNDERLINE = 0x00000004;
        private const UInt32 CFE_STRIKEOUT = 0x00000008;
        private const UInt32 CFE_PROTECTED = 0x00000010;
        private const UInt32 CFE_LINK = 0x00000020;
        private const UInt32 CFE_AUTOCOLOR = 0x40000000;

        /// <summary>
        /// Calcular o hacer los contenidos de nuestra RichTextBox para la impresión
        /// </summary>
        /// <param name="measureOnly">true, sólo se realiza el cálculo,
        /// Otra manera el texto se hace así</param>
        /// <param name="e">el objeto PrintPageEventArgs de el
        ///evento PrintPage </param>
        /// <param name="charFrom">Índex del primer carácter a imprimir</param>
        /// <param name="charTo">Índex del ultimo carácter a imprimir</param>
        /// <returns>(Índice del último carácter que encajaba en la
        /// pagina) + 1</returns>
        public int FormatRange(bool measureOnly, PrintPageEventArgs e,
            int charFrom, int charTo)
        {
            // Especificar Caracteres de Impresión
            STRUCT_CHARRANGE cr;
            cr.cpMin = charFrom;
            cr.cpMax = charTo;

            // Especificar el área dentro de las márgenes
            STRUCT_RECT rc;

            if (curPart == control.Header | curPart == control.Body)
            { rc.top = HundredthInchToTwips(e.MarginBounds.Top + curPart.Top + 2); }
            else
            { rc.top = HundredthInchToTwips(e.MarginBounds.Bottom - (curPart.Height + 10)); }
            if (curPart == control.Body)
            {
                rc.bottom = HundredthInchToTwips(control.PageSize.Height);
            }
            else
            { rc.bottom = HundredthInchToTwips(curPart.Height + 5); }

            rc.left = HundredthInchToTwips(e.MarginBounds.Left + 2);
            rc.right = HundredthInchToTwips(e.MarginBounds.Right - 3);

            // Especificar el área de la pagina
            STRUCT_RECT rcPage;
            rcPage.top = HundredthInchToTwips(e.PageBounds.Top);
            rcPage.bottom = HundredthInchToTwips(e.PageBounds.Bottom);
            rcPage.left = HundredthInchToTwips(e.PageBounds.Left);
            rcPage.right = HundredthInchToTwips(e.PageBounds.Right);

            //Obtener contexto de dispositivo del dispositivo de salida
            IntPtr hdc = e.Graphics.GetHdc();

            // Llenar FORMATRANGE struct
            STRUCT_FORMATRANGE fr;
            fr.chrg = cr;
            fr.hdc = hdc;
            fr.hdcTarget = hdc;
            fr.rc = rc;
            fr.rcPage = rcPage;

            // Non-Zero wParam es render, Zero es measure
            Int32 wParam = (measureOnly ? 0 : 1);

            // Asignar memoria para FORMATRANGE struct y
            // copiar el contenido de la estructura a la asignacion
            IntPtr lParam = Marshal.AllocCoTaskMem(Marshal.SizeOf(fr));
            Marshal.StructureToPtr(fr, lParam, false);

            // Enviar el actual mensaje Win32 
            int res = SendMessage(curPart.Handle, EM_FORMATRANGE, wParam, lParam);

            //Memoria asignada libre
            Marshal.FreeCoTaskMem(lParam);

            // liberar el dispositivo
            e.Graphics.ReleaseHdc(hdc);

            return res;
        }
        /// <summary>
        /// Conversión entre 1/100 inch (unidad usado por el .NET)
        /// y twips (1/1440 inch, usada por las llamadas Win32 APIs)
        /// </summary>
        /// <param name="n">Valor en 1/100 inch</param>
        /// <returns>Valor en twips</returns>
        private Int32 HundredthInchToTwips(int n)
        {
            return (Int32)(n * 14.4);
        }

        /// <summary>
        /// Datos libres en la caché del control después de la impresión
        /// </summary>
        public void FormatRangeDone()
        {
            IntPtr lParam = new IntPtr(0);
            SendMessage(curPart.Handle, EM_FORMATRANGE, 0, lParam);
        }

        /// <summary>
        /// Establece la fuente sólo para la parte seleccionada de la RichTextBox
        /// sin modificar las otras propiedades como el tamaño o estilo
        /// </summary>
        /// <param name="face">Nombre de la fuente usada</param>
        /// <returns>true, completo, false, fallas</returns>
        public static bool SetSelectionFont(RichTextBox control, string face)
        {
            CHARFORMATSTRUCT cf = new CHARFORMATSTRUCT();
            cf.cbSize = Marshal.SizeOf(cf);
            cf.szFaceName = new char[32];
            cf.dwMask = CFM_FACE;
            face.CopyTo(0, cf.szFaceName, 0, Math.Min(31, face.Length));

            IntPtr lParam = Marshal.AllocCoTaskMem(Marshal.SizeOf(cf));
            Marshal.StructureToPtr(cf, lParam, false);

            int res = SendMessage(control.Handle, EM_SETCHARFORMAT, SCF_SELECTION, lParam);
            return (res == 0);
        }

        /// <summary>
        /// Establece el estilo de fuente  sólo para la parte seleccionada de la RichTextBox
        /// sin modificar las otras propiedades como fuente o estilo
        /// </summary>
        /// <param name="size">Nuevo tamaño de punto a utilizar</param>
        /// <returns>true, completo;  false, fallas</returns>
        public static bool SetSelectionSize(RichTextBox control, int size)
        {
            CHARFORMATSTRUCT cf = new CHARFORMATSTRUCT();
            cf.cbSize = Marshal.SizeOf(cf);
            cf.dwMask = CFM_SIZE;
            // Conversión Inch
            cf.yHeight = size * 20;

            IntPtr lParam = Marshal.AllocCoTaskMem(Marshal.SizeOf(cf));
            Marshal.StructureToPtr(cf, lParam, false);

            int res = SendMessage(control.Handle, EM_SETCHARFORMAT, SCF_SELECTION, lParam);
            return (res == 0);
        }

        /// <summary>
        /// Establece el estilo de fuente negrilla sólo para la parte seleccionada de la RichTextBox
        /// sin modificar las otras propiedades como fuente o estilo
        /// </summary>
        /// <param name="bold">negrilla (true) o normal (false)</param>
        /// <returns>true, completo;  false, fallas</returns>
        public bool SetSelectionBold(bool bold)
        {
            return SetSelectionStyle(CFM_BOLD, bold ? CFE_BOLD : 0);
        }

        /// <summary>
        /// Establece el estilo de fuente cursiva sólo para la parte seleccionada de la RichTextBox
        /// sin modificar las otras propiedades como fuente o estilo
        /// </summary>
        /// <param name="bold">cursiva (true) o normal (false)</param>
        /// <returns>true, completo;  false, fallas</returns>
        public bool SetSelectionItalic(bool italic)
        {
            return SetSelectionStyle(CFM_ITALIC, italic ? CFE_ITALIC : 0);
        }

        /// <summary>
        /// Establece el estilo de fuente subrayado sólo para la parte seleccionada de la RichTextBox
        /// sin modificar las otras propiedades como fuente o estilo
        /// </summary>
        /// <param name="bold">cursiva (true) o normal (false)</param>
        /// <returns>true, completo;  false, fallas</returns>
        public bool SetSelectionUnderlined(bool underlined)
        {
            return SetSelectionStyle(CFM_UNDERLINE, underlined ? CFE_UNDERLINE : 0);
        }

        /// <summary>
        /// Establece el estilo sólo para la parte seleccionada de la RichTextBox
        /// con la posibilidad de enmascarar algunos estilos que no deben ser modificados
        /// </summary>
        /// <param name="mask">modificar los estilos?</param>
        /// <param name="effect">nuevos valores para los estilos</param>
        /// <returns>true, completo;  false, fallas</returns>
        private bool SetSelectionStyle(UInt32 mask, UInt32 effect)
        {
            CHARFORMATSTRUCT cf = new CHARFORMATSTRUCT();
            cf.cbSize = Marshal.SizeOf(cf);
            cf.dwMask = mask;
            cf.dwEffects = effect;

            IntPtr lParam = Marshal.AllocCoTaskMem(Marshal.SizeOf(cf));
            Marshal.StructureToPtr(cf, lParam, false);

            int res = SendMessage(curPart.Handle, EM_SETCHARFORMAT, SCF_SELECTION, lParam);
            return (res == 0);
        }
    }


}
