﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Gui
{
    public partial class Manter_alimento_ed : Form
    {
        //DAOAlimento daoalimento;
        public Manter_alimento_ed()
        {
            InitializeComponent();
            //daoalimento = new DAOAlimento();
        }

 

        private void btnconfirmar_Click(object sender, EventArgs e)
        {
            /*Alimento alimento = new Alimento();
            alimento.Nome = tb_nome.Text;
            alimento.ValorCalorico = double.Parse(tb_valorcalorico.Text);
            alimento.Quantidade = double.Parse(tb_quantidade.Text);
            alimento.DataReposicao = tb_dataultimareposicao.Text;
            daoalimento.Adicionar(alimento);
            //((Manter_alimento)Application.OpenForms["manter_alimento"]).lis.Add(usuario);
            //((Manter_login)Application.OpenForms["manter_alimento"]).AtualizarGrid();*/
        }
    }
}