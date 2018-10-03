using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace cadastrousuario
{
    public partial class painelUSUARIO : Form
    {
        public painelUSUARIO()
        {
            InitializeComponent();

            // Visto pelo Ultimo
            lb_data.Text = DateTime.Now.ToString();
        }

        private void sAIRToolStripMenuItem_Click(object sender, EventArgs e)
        {
            // Botão Sair
            this.Close();
        }

        private void deslogarToolStripMenuItem_Click(object sender, EventArgs e)
        {
            // String de mensagem
            string mensagem = "Você deseja deslogar?";

            // Código do msgbox deslogar
            if (MessageBox.Show(mensagem, "Aviso",
                MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                // Pagina de Login
                this.Hide();
                login login = new login();
                login.Show();
            }
        }

        private void adicionarClienteToolStripMenuItem_Click(object sender, EventArgs e)
        {
            // Adicionar cliente
            this.Show();
            addclient addclient = new addclient();
            addclient.Show();
        }

        private void listaDeClientesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            // Lista de Usuarios
            this.Show();
            listerClient listerClient = new listerClient();
            listerClient.Show();
        }
    }
}
