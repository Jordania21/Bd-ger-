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
    public partial class fRecursos : Form
    {
        logicaNegocioRecursos logicaNR = new logicaNegocioRecursos();

        public fRecursos()
        {
            InitializeComponent();
        }

        private void buttonGuardar_Click(object sender, EventArgs e)
        {
            try
            {
                if (buttonGuardar.Text == "Guardar")
                {
                    Recursos objetoRecurso = new Recursos();
                    objetoRecurso.nombrer = textBoxNombrer.Text;
                    objetoRecurso.codigo = textBoxCodigo.Text;
                    objetoRecurso.descripcion = textBoxDescripcion.Text;

                    if (logicaNR.insertarRecursos(objetoRecurso) > 0)
                    {
                        MessageBox.Show("Agregado con exito");
                        dataGridViewRecursos.DataSource = logicaNR.listarRecursos();
                        textBoxNombrer.Text = "";
                        textBoxCodigo.Text = "";
                        textBoxDescripcion.Text = "";
                        tabRecursos.SelectedTab = tabPage2;
                    }
                    else { MessageBox.Show("Error al agregar Recurso"); }
                }
                if (buttonGuardar.Text == "Actualizar")
                {
                    Recursos objetoRecurso = new Recursos();
                    objetoRecurso.idrecursos = Convert.ToInt32(textBoxId.Text);
                    objetoRecurso.nombrer = textBoxNombrer.Text;
                    objetoRecurso.codigo = textBoxCodigo.Text;
                    objetoRecurso.descripcion = textBoxDescripcion.Text;

                    if (logicaNR.EditarRecursos(objetoRecurso) > 0)
                    {
                        MessageBox.Show("Actualizado con exito");
                        dataGridViewRecursos.DataSource = logicaNR.listarRecursos();
                        textBoxNombrer.Text = "";
                        textBoxCodigo.Text = "";
                        textBoxDescripcion.Text = "";
                        tabRecursos.SelectedTab = tabPage2;
                    }
                    else
                    {
                        MessageBox.Show("Error al actualizar Recurso");
                    }
                    buttonGuardar.Text = "Guardar";
                }
            }
            catch
            {
                MessageBox.Show("ERROR");
            }
        }

        private void fRecursos_Load(object sender, EventArgs e)
        {
            textBoxId.Visible = false;
            labelId.Visible = false;
            dataGridViewRecursos.DataSource = logicaNR.listarRecursos();
        }

        private void buttonEditar_Click(object sender, EventArgs e)
        {
            textBoxId.Visible = true;
            textBoxId.Enabled = false;
            labelId.Visible = true;

            textBoxId.Text = dataGridViewRecursos.CurrentRow.Cells["idrecursos"].Value.ToString();
            textBoxNombrer.Text = dataGridViewRecursos.CurrentRow.Cells["nombrer"].Value.ToString();
            textBoxCodigo.Text = dataGridViewRecursos.CurrentRow.Cells["codigo"].Value.ToString();
            textBoxDescripcion.Text = dataGridViewRecursos.CurrentRow.Cells["descripcion"].Value.ToString();

            tabRecursos.SelectedTab = tabPage1;
            buttonGuardar.Text = "Actualizar";
        }

        private void buttonEliminar_Click(object sender, EventArgs e)
        {
            int codigoR = Convert.ToInt32(dataGridViewRecursos.CurrentRow.Cells["idrecursos"].Value.ToString());
            try
            {
                if (logicaNR.eliminarRecursos(codigoR) > 0)
                {
                    MessageBox.Show("Eliminado con exito");
                    dataGridViewRecursos.DataSource = logicaNR.listarRecursos();

                }

            }
            catch
            {
                MessageBox.Show("ERROR al eliminar recurso");
            }
        }

        private void textBoxBuscar_TextChanged(object sender, EventArgs e)
        {
            List<Recursos> listaRecursos = logicaNR.BuscarRecursos(textBoxBuscar.Text);
            dataGridViewRecursos.DataSource = listaRecursos;
        }

       
    }
    
}
