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
    public partial class PAINEL_ADM : Form
    {
        public PAINEL_ADM(string texto)
        {
            InitializeComponent();
            lb_user.Text = texto;
            SidePanel.Height = btn_home.Height;
            SidePanel.Top = btn_home.Top;
            inicio1.BringToFront();
        }

        private void btn_exit_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void lb_sair_Click(object sender, EventArgs e)
        {
            // String de mensagem
            string mensagem = "Você deseja deslogar?";

            // Código do msgbox deslogar
            if (MessageBox.Show(mensagem, "Aviso",
                MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                // Pagina de Loogin
                this.Hide();
                login login = new login();
                login.Show();
            }
        }

        private void btn_home_Click(object sender, EventArgs e)
        {
            SidePanel.Height = btn_home.Height;
            SidePanel.Top = btn_home.Top;
            inicio1.BringToFront();
        }

        private void btn_add_user_Click(object sender, EventArgs e)
        {
            SidePanel.Height = btn_add_user.Height;
            SidePanel.Top = btn_add_user.Top;
            adD_USER1.BringToFront();
        }

        private void btn_listuser_Click(object sender, EventArgs e)
        {
            SidePanel.Height = btn_listuser.Height;
            SidePanel.Top = btn_listuser.Top;
            lisT_USERS1.BringToFront();
        }

        private void btn_add_clients_Click(object sender, EventArgs e)
        {
            SidePanel.Height = btn_add_clients.Height;
            SidePanel.Top = btn_add_clients.Top;
            clients1.BringToFront();
        }

        private void btn_search_Click(object sender, EventArgs e)
        {
            SidePanel.Height = btn_search_clientes.Height;
            SidePanel.Top = btn_search_clientes.Top;
            clientes1.BringToFront();
        }

        private void btn_list_clientes_Click(object sender, EventArgs e)
        {
            SidePanel.Height = btn_list_clientes.Height;
            SidePanel.Top = btn_list_clientes.Top;
            lisT_CLIENTE1.BringToFront();
        }

        private void btn_search_user_Click(object sender, EventArgs e)
        {
            SidePanel.Height = btn_search_user.Height;
            SidePanel.Top = btn_search_user.Top;
            searcH_USER1.BringToFront();
        }
    }
}
