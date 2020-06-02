using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using capaNegocio;
using capaEntidades;

namespace capaspresentacionWF
{
    public partial class fSolicitud : Form
    {
        logicaNegocioSolicitud logicaNS = new logicaNegocioSolicitud();

        public fSolicitud()
        {
            InitializeComponent();
        }

        private void buttonGuardar_Click(object sender, EventArgs e)
        {
            try
            {
                if (buttonGuardar.Text == "Guardar")
                {
                    Solicitud objetoSolicitud = new Solicitud();
                    objetoSolicitud.aula = textBoxaula.Text;
                    objetoSolicitud.nivel = textBoxaula.Text;
                    objetoSolicitud.fechasolicitud = Convert.ToDateTime(textBoxfechaSolicitud.Text);
                    objetoSolicitud.fechauso = Convert.ToDateTime(textBoxfechauso.Text);
                    objetoSolicitud.horainicio = Convert.ToDateTime(textBoxhorainicio.Text);
                    objetoSolicitud.horafinal = Convert.ToDateTime(textBoxhorafinal.Text);
                    objetoSolicitud.carrera = textBoxcarrera.Text;
                    objetoSolicitud.asignatura = textBoxasignatura.Text;
                    objetoSolicitud.idrecursos = Convert.ToInt32(textBoxIdrecursos.Text);
                    objetoSolicitud.idusuario = Convert.ToInt32(textBoxIdusuario.Text);

                    if (logicaNS.insertarSolicitud(objetoSolicitud) > 0)
                    {
                        MessageBox.Show("Agregando con exito");
                        dataGridViewSolicitud.DataSource = logicaNS.listarSolicitud();
                        textBoxaula.Text = "";
                        textBoxnivel.Text = "";
                        textBoxfechaSolicitud.Text = "";
                        textBoxfechauso.Text = "";
                        textBoxhorainicio.Text = "";
                        textBoxhorafinal.Text = "";
                        textBoxcarrera.Text = "";
                        textBoxasignatura.Text = "";
                        textBoxIdrecursos.Text = "";
                        textBoxIdusuario.Text = "";
                        tabSolicitud.SelectedTab = tabPage2;
                    }
                    else { MessageBox.Show("Error al agregar Solicitud"); }
                }
                if (buttonGuardar.Text == "Actualizar")
                {
                    Solicitud objetoSolicitud = new Solicitud();
                    objetoSolicitud.idsolicitud = Convert.ToInt32(textBoxId.Text);
                    objetoSolicitud.aula = textBoxaula.Text;
                    objetoSolicitud.nivel = textBoxaula.Text;
                    objetoSolicitud.fechasolicitud = Convert.ToDateTime(textBoxfechaSolicitud.Text);
                    objetoSolicitud.fechauso = Convert.ToDateTime(textBoxfechauso.Text);
                    objetoSolicitud.horainicio = Convert.ToDateTime(textBoxhorainicio.Text);
                    objetoSolicitud.horafinal = Convert.ToDateTime(textBoxhorafinal.Text);
                    objetoSolicitud.carrera = textBoxcarrera.Text;
                    objetoSolicitud.asignatura = textBoxasignatura.Text;
                    objetoSolicitud.idrecursos = Convert.ToInt32(textBoxIdrecursos.Text);
                    objetoSolicitud.idusuario = Convert.ToInt32(textBoxIdusuario.Text);

                    if (logicaNS.EditarSolicitud(objetoSolicitud) > 0)
                    {
                        MessageBox.Show("Actualizando con exito");
                        dataGridViewSolicitud.DataSource = logicaNS.listarSolicitud();
                        textBoxaula.Text = "";
                        textBoxnivel.Text = "";
                        textBoxfechaSolicitud.Text = "";
                        textBoxfechauso.Text = "";
                        textBoxhorainicio.Text = "";
                        textBoxhorafinal.Text = "";
                        textBoxcarrera.Text = "";
                        textBoxasignatura.Text = "";
                        textBoxIdrecursos.Text = "";
                        textBoxIdusuario.Text = "";
                        tabSolicitud.SelectedTab = tabPage2;
                    }
                    else
                    {
                        MessageBox.Show("Error al actualizar Solicitud");
                    }
                    buttonGuardar.Text = "Guardar";
                }
            }
            catch (Exception)
            {
                MessageBox.Show("ERROR");
            }

        }

        private void fSolicitud_Load(object sender, EventArgs e)
        {
            textBoxId.Visible = false;
            labeld.Visible = false;
            dataGridViewSolicitud.DataSource = logicaNS.listarSolicitud();
        }

        private void buttonEditar_Click(object sender, EventArgs e)
        {
            textBoxId.Visible = true;
            textBoxId.Enabled = false;
            labeld.Visible = true;

            textBoxId.Text = dataGridViewSolicitud.CurrentRow.Cells["idsolicitud"].Value.ToString();
            textBoxaula.Text = dataGridViewSolicitud.CurrentRow.Cells["aula"].Value.ToString();
            textBoxnivel.Text = dataGridViewSolicitud.CurrentRow.Cells["nivel"].Value.ToString();
            textBoxfechaSolicitud.Text = dataGridViewSolicitud.CurrentRow.Cells["fechasolicitud"].Value.ToString();
            textBoxfechauso.Text = dataGridViewSolicitud.CurrentRow.Cells["fechauso"].Value.ToString();
            textBoxhorainicio.Text = dataGridViewSolicitud.CurrentRow.Cells["horainicio"].Value.ToString();
            textBoxhorafinal.Text = dataGridViewSolicitud.CurrentRow.Cells["horafinal"].Value.ToString();
            textBoxcarrera.Text = dataGridViewSolicitud.CurrentRow.Cells["carrera"].Value.ToString();
            textBoxasignatura.Text = dataGridViewSolicitud.CurrentRow.Cells["asignatura"].Value.ToString();
            textBoxIdrecursos.Text = dataGridViewSolicitud.CurrentRow.Cells["idrecursos"].Value.ToString();
            textBoxIdusuario.Text = dataGridViewSolicitud.CurrentRow.Cells[" idusuario"].Value.ToString();

            tabSolicitud.SelectedTab = tabPage1;
            buttonGuardar.Text = "Actualizar";
        }

        private void buttonEliminar_Click(object sender, EventArgs e)
        {
            int codigoS = Convert.ToInt32(dataGridViewSolicitud.CurrentRow.Cells["idsolicitud"].Value.ToString());
            try
            {
                if (logicaNS.eliminarSolicitud(codigoS) > 0)
                {
                    MessageBox.Show("Eliminado con exito");
                    dataGridViewSolicitud.DataSource = logicaNS.listarSolicitud();
                }
            }
            catch (Exception)
            {
                MessageBox.Show("Error al eliminar Solicitud");
            }
        }

        private void textBoxBuscar_TextChanged(object sender, EventArgs e)
        {
            List<Solicitud> listaSolicitud = logicaNS.BuscarSolicitud(textBoxBuscar.Text);
            dataGridViewSolicitud.DataSource = listaSolicitud;
        }
    }
    
}
