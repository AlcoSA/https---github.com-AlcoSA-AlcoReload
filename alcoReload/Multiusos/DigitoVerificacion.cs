using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Multiusos
{
    public class DigitoVerificacion
    {
        public string calculoDigitoVerificacion(Control campoDocumento)
        {
            try
            {
                if (campoDocumento.Text == string.Empty)
                {
                    return string.Empty;
                }
                else if (IsNumeric(campoDocumento.Text))
                {
                    int DigitoVerificacion;
                    int NumCaracteres = (campoDocumento.Text).ToString().Length;
                    int cantidadCeros = 15 - NumCaracteres;
                    string ceros = "";

                    for (int i = 1; i <= cantidadCeros; i++)
                    {
                        ceros += "0";
                    }

                    string Doc = ceros + campoDocumento.Text;
                    int[] array = new int[] { 3, 7, 13, 17, 19, 23, 29, 37, 41, 43, 47, 53, 59, 67, 71 };

                    int acum = 0;
                    int j = 0;
                    for (int i = 14; i >= 0; i += -1)
                    {
                        int DocChar = Convert.ToInt32(Doc[i].ToString());
                        int ArrChar = array[j];
                        acum += ArrChar * DocChar;
                        j += 1;
                    }

                    int formula = acum % 11;

                    if (formula > 1)
                    {
                        DigitoVerificacion = 11 - formula;
                    }
                    else
                    {
                        DigitoVerificacion = formula;
                    }
                    return DigitoVerificacion.ToString();
                }
                else
                {
                    return "N/A";
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message, ex.InnerException);
            }
        }

        public static Boolean IsNumeric(string valor)
        {
            int result;
            return int.TryParse(valor, out result);
        }
    }
}
