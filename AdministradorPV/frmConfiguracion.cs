using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Modelos.Negocio;

namespace AdministradorPV
{
    public partial class frmConfiguracion : Form
    {
        public frmConfiguracion()
        {
            InitializeComponent();
        }

        private void toolStripButton1_Click(object sender, EventArgs e)
        {
            Configuracion config = new Configuracion();
            config.id = 1;
            config.empresa = tEmpresa.Text;
            config.rutaBinarios = tRutaBinarios.Text;
            config.claveSello = tClaveSello.Text;
            config.nombre = tNombreEmpresa.Text;
            config.direccion = tDireccion.Text;
            config.logo= ImageToByteArray(pictureBox1.Image);
            config.imprime_ticket = Convert.ToInt32(ckImprimeTicket.Checked);
            config.ivaincluido = Convert.ToInt32(ckIvaIncluido.Checked);
            config.muestraVentanaDescuentos = Convert.ToInt32(ckMuestraVentanaDescuentos.Checked);

            ConfigurationDBContext.actualizar(config);

            MessageBox.Show("Modificación guardada.");
        }

        private byte[] ImageToByteArray(Image image)
        {
            using (MemoryStream ms = new MemoryStream())
            {
                image.Save(ms, image.RawFormat);
                return ms.ToArray();
            }
        }

        private Image ByteArrayToImage(byte[] byteArray)
        {
            using (MemoryStream ms = new MemoryStream(byteArray))
            {
                Image image = Image.FromStream(ms);
                return image;
            }
        }

        private void frmConfiguracion_Load(object sender, EventArgs e)
        {
            var config= ConfigurationDBContext.obtener();

            tEmpresa.Text = config.empresa;
            tRutaBinarios.Text = config.rutaBinarios;
            tClaveSello.Text = config.claveSello;
            tNombreEmpresa.Text = config.nombre;
            tDireccion.Text = config.direccion;

            if (config.logo != null)
            {
                Image image = ByteArrayToImage(config.logo);
                pictureBox1.Image = image;
            }

            ckImprimeTicket.Checked = Convert.ToBoolean(config.imprime_ticket);
            ckIvaIncluido.Checked= Convert.ToBoolean(config.ivaincluido);
            ckMuestraVentanaDescuentos.Checked = Convert.ToBoolean(config.muestraVentanaDescuentos);
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.Filter = "Archivos de Imagen|*.jpg;*.jpeg;*.png;*.gif;*.bmp;*.ico|Todos los archivos|*.*";

            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                try
                {
                    // Cargar la imagen seleccionada en el PictureBox
                    //PictureBox pictureBox = tuPictureBox; // Reemplaza con el nombre de tu PictureBox
                    pictureBox1.Image = new Bitmap(openFileDialog.FileName);
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error al cargar la imagen: " + ex.Message);
                }
            }
        }
    }
}
