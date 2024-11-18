﻿using MapaSala.Classes;
using MapaSala.Formularios.cadastrar;
using MapaSala.Formularios.Editar;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MapaSala.Formularios
{
    public partial class frmUsuarios : Form
    {

        public frmUsuarios()
        {
            InitializeComponent();
            Usuarios u = new Usuarios();
            dtgridUsuarios1.DataSource = u.PreencherGrid();

        }

        private void FecharForm(object sender, FormClosedEventArgs e)
        {
            Usuarios u = new Usuarios();
            dtgridUsuarios1.DataSource = u.PreencherGrid();
        }

        private void btnNovo1_Click_1(object sender, EventArgs e)
        {
            frmCadastrarUsuario frm = new frmCadastrarUsuario();
            frm.FormClosed += FecharForm;
            frm.ShowDialog();
        }

        private void txtPesquisar1_TextChanged_1(object sender, EventArgs e)
        {
            Usuarios u = new Usuarios();
            dtgridUsuarios1.DataSource = u.Pesquisar(txtPesquisar1.Text);
        }

        private void dtgridUsuarios1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                int id = Convert.ToInt32(
                    dtgridUsuarios1.Rows[e.RowIndex].Cells[0].Value);

                frmEditarUsuarios editar = new frmEditarUsuarios(id);

                // Inscreve-se no evento
                editar.FormClosed += FecharForm;
                editar.ShowDialog(); // Abre o formulário como um diálogo modal
            }
        }
    }
}