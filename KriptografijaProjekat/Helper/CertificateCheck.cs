using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace KriptografijaProjekat.Helper
{
    class CertificateCheck
    {
        public static bool isCATrusted(string certificate)
        {
            string rootca = Application.StartupPath + "\\PKI\\certs\\rootca.pem";
            string commandIsTrusted = "/c openssl verify -trusted " + rootca + certificate;
            if (commandIsTrusted.Contains("OK"))
                return true;
            return false;
        }
        public static bool isCertificateValidDate(string certificate)
        {
            string cert = "PKI/certs/cert.txt";
            Functions.executeCommandReturn("/c openssl x509 -in " + certificate + " -noout -dates > " + cert);
            var lines = File.ReadAllLines(cert);
            File.Delete(cert);
            var myLine = lines[1].Replace("  ", " ");
            string month = myLine.Split('=')[1].Split(' ')[0];
            string day = myLine.Split('=')[1].Split(' ')[1];
            string year = myLine.Split('=')[1].Split(' ')[3];
            DateTime date = new DateTime(Int32.Parse(year), (int)(Month.Jun + 1), Int32.Parse(day));
            var today = DateTime.Today;
            if (today > date)
                return false;
            else
                return true;
        }

        public static bool isCertificateValidCrl(string certificate)
        {
            string cert = "PKI/certs/cert.txt";
            Functions.executeCommandReturn("/c openssl x509 -in " + certificate + " -noout -serial > " + cert);
            var lines = File.ReadAllLines(cert);
            File.Delete(cert);
            string serial = lines[0].Split('=')[1];
            var allCertificates = File.ReadAllLines("PKI/index.txt");
            List<string> revokedCertificates = new List<string>();
            foreach(var x in allCertificates)
            {
                if (x.StartsWith("R"))
                    revokedCertificates.Add(x);
            }
            
            foreach(var x in revokedCertificates)
            {
                if (serial.Equals(x.Split('\t')[3]))
                    return false;
            }
            return true;
        }

        enum Month
        {
            Jan, Feb, Mar, Apr, May, Jun, Jul, Aug, Sep, Oct, Nov, Dec
        };
    }
}
