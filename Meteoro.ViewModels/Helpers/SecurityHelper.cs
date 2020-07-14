using System;
using System.Security;

namespace Meteoro.ViewModels.Helpers
{
    public static class SecurityHelper
    {
        //Convertir texto plano a SecureString
        public static SecureString ToSecureString(this String plainStr)
        {
            var secStr = new SecureString();
            secStr.Clear();
            foreach (char c in plainStr.ToCharArray())
            {
                secStr.AppendChar(c);

            }
            return secStr;
        }      

        //Convertir SecureString a TextoPlano
        public static String ToPlainString(this SecureString secureStr)
        {
            String plainStr = new System.Net.NetworkCredential(string.Empty, secureStr).Password;
            return plainStr;
        }


        public static SecureString Delete(this String plainStr)
        {
            var secStr = new SecureString();
            secStr.Clear();
            return secStr;
        }

    }
}
