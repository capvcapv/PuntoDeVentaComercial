using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

// Ne pas oublier d'ajouter cela dans votre projet
using System.Text.RegularExpressions;
using System.Windows;
using System.Windows.Forms;
using System.ComponentModel;

// Auteur : Fabrice GARCIA ( 20290 BORGO, Haute-Corse. le  14 octobre 2018)
// Vous etes libre d'inclure ce code dans vos programmes.
// Il vous est fournis librement et gratuitement sans aucune responsabilité de ma part.
// Je vous demande seulement de respecter mon droit d'auteur en concervant mon nom
// Vous pouvez aussi m'envoyer un mail de remerciement à fab2bprog@outlook.fr  ca me fera plaisir.

//

namespace TerminalPedidos
{
    public class ChampMonetaire
    {

        public TextBox ScanCible;
        public KeyPressEventArgs eKeyPressEvArg;

        double valMin = 0.0;
        double valMax = 1000000000.0;

        public ChampMonetaire()
        {
            Console.WriteLine("hola perro");
        }

        public double ValMin
        {
            get { return valMin; }
            set { valMin = value; }
        }

        public double ValMax
        {
            get { return valMax; }
            set { valMax = value; }
        }

        public bool Valide_Enter()
        {
            char[] CaractAutorise = new char[] { '0', '1', '2', '3', '4', '5', '6', '7', '8', '9', '.', ',', '-' };

            if (ScanCible.Text.Length == 0)
            {
                return true;
            }

            foreach (char character in (ScanCible.Text.ToArray()))
            {
                if (!CaractAutorise.Contains(character))
                {
                    ScanCible.Text = ScanCible.Text.Replace(character.ToString(), string.Empty);

                }
            }

            Double.TryParse(ScanCible.Text, out Double ResultConv);
            ScanCible.Text = ResultConv.ToString();
            return true;

        }

        public bool Valide_KeyPress()
        {
            Char Separateur = System.Globalization.CultureInfo.CurrentCulture.NumberFormat.NumberDecimalSeparator[0];
            Int32 PosSeparateur = ScanCible.Text.IndexOf(Separateur);
            Int32 PosCurseur = ScanCible.SelectionStart;
            double ResultConv;


            if (char.IsDigit(eKeyPressEvArg.KeyChar))
            {

                Double.TryParse(ScanCible.Text, out ResultConv);
                if (PosCurseur == 0 && ResultConv < 0)
                {
                    ScanCible.SelectionStart = ScanCible.Text.Length;
                    return true;
                }

                return true;

            }

            if (eKeyPressEvArg.KeyChar == (char)8) { return true; }

            if (eKeyPressEvArg.KeyChar == '.' || eKeyPressEvArg.KeyChar == ',')
            {
                eKeyPressEvArg.KeyChar = Separateur;

                if (PosSeparateur == -1 && ScanCible.Text.Length > 0 && PosCurseur > 0) { return true; }
                if (ScanCible.Text.Length == 0 || ScanCible.SelectionLength == ScanCible.Text.Length)
                {
                    ScanCible.Text = "0" + Separateur;
                    ScanCible.SelectionStart = 2;
                    eKeyPressEvArg.Handled = true;
                    return false;
                }

                if (PosSeparateur == -1 && ScanCible.Text.Length > 0 && PosCurseur == 0)
                {
                    ScanCible.Text = "0" + Separateur + ScanCible.Text;
                    ScanCible.SelectionStart = 2;
                    eKeyPressEvArg.Handled = true;
                    return false;
                }

                if (ScanCible.SelectedText.Contains(Separateur))
                {
                    ScanCible.SelectedText = Separateur.ToString();
                    eKeyPressEvArg.Handled = true;
                    return false;
                }



            }

            if (eKeyPressEvArg.KeyChar == '-')
            {
                Double.TryParse(ScanCible.Text, out ResultConv);
                ResultConv = ResultConv * -1;
                if (ResultConv < valMin) { ResultConv = valMin; }
                if (ResultConv > valMax) { ResultConv = valMax; }
                ScanCible.Text = ResultConv.ToString();
                ScanCible.SelectionStart = ScanCible.Text.Length;
                eKeyPressEvArg.Handled = true;
                return true;
            }

            eKeyPressEvArg.Handled = true;
            return false;

        }

        public bool Valide_Leave()
        {

            Char Separateur = System.Globalization.CultureInfo.CurrentCulture.NumberFormat.NumberDecimalSeparator[0];

            if (ScanCible.Text.Length == 0)
            {
                return true;
            }

            if (ScanCible.Text == Separateur.ToString())
            {
                ScanCible.Text = "";
                return true;
            }

            Double.TryParse(ScanCible.Text, out Double ResultConv);
            ResultConv = Math.Round(ResultConv, 2);
            if (ResultConv < valMin) { ResultConv = valMin; }
            if (ResultConv > valMax) { ResultConv = valMax; }
            ScanCible.Text = ResultConv.ToString("C");

            return true;

        }

    }
}

