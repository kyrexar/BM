using System;
using System.Windows.Forms;

namespace BM
{
    public partial class frmMenu : Form
    {
        public int alto, ancho, bombasCantidadInicial;

        public bool nueva = false;

        private void frmMenu_Load(object sender, EventArgs e)
        {
            //txtAlto.Text = "10";
            //txtAncho.Text = "10";
            //txtMinas.Text = "10";
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void txt_KeyPress(object sender, KeyPressEventArgs e)
        {
            // Pulsar enter tambien crea
            if (e.KeyChar == (char)13) // 13=Enter
            {
                Crear();
            }
        }

        public frmMenu()
        {
            InitializeComponent();
        }


        private void btnCrear_Click(object sender, EventArgs e)
        {
            Crear();
        }

        private void Crear()
        {
            alto = (int)numAlto.Value;
            ancho = (int)numAncho.Value;
            bombasCantidadInicial = (int)numMinas.Value;
            Close();

            //if (int.TryParse(numAlto.Text, out int alto))
            //{
            //    this.alto = alto;
            //    if (alto >= 10 && alto <=20)
            //    {
            //        if (int.TryParse(numAncho.Text, out int ancho))
            //        {
            //            this.ancho = ancho;
            //            if (ancho >= 10 && ancho <= 20)
            //            {
            //                if (int.TryParse(numMinas.Text, out int minas))
            //                {
            //                    this.bombasCantidadInicial = minas;
            //                    if (minas >= 10 && minas <= 99)
            //                    {
            //                        nueva = true;
            //                        this.Close();
            //                    }
            //                    else
            //                    {
            //                        MessageBox.Show("Tiene que haber minimo 20 minas y maximo 99 ");
            //                    }
            //                }
            //                else
            //                {
            //                    MessageBox.Show("Minas no es un numero");
            //                }
            //            }
            //            else
            //            {
            //                MessageBox.Show("El ancho tiene que ser minimo 10 y maximo 20");
            //            }
            //        }
            //        else
            //        {
            //            MessageBox.Show("Ancho no es un numero");
            //        }
            //    }
            //    else
            //    {
            //        MessageBox.Show("El alto tiene que ser minimo 10 y maximo 20");
            //    }
            //}
            //else
            //{
            //    MessageBox.Show("Alto no es un numero");
            //}
        }
    }
}
