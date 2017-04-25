using System;

namespace ManejoExcepciones
{
    public static class MensajeExcepcion
    {
        public static void Show(Exception ex, TipoExcepcion tipoexcepcion, string titulo)
        {
            FrmExceptions fe = new FrmExceptions();
            fe.Excepcion = ex;
            fe.TipoExcepcion = tipoexcepcion;
            fe.Text = titulo;
            fe.ShowDialog();
        }

        public static void Show(Exception ex, TipoExcepcion tipoexcepcion)
        {
            FrmExceptions fe = new FrmExceptions();
            fe.Excepcion = ex;
            fe.TipoExcepcion = tipoexcepcion;
            fe.ShowDialog();
        }

        public static void Show(Exception ex)
        {
            FrmExceptions fe = new FrmExceptions();
            fe.Excepcion = ex;
            fe.ShowDialog();
        }

        public static void ActualizarUsuario(string usuario)
        {
            Properties.Settings.Default.Usuario = usuario;
            Properties.Settings.Default.Save();
        }
    }
}
