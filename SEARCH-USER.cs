using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MySql.Data.MySqlClient;

namespace cadastrousuario
{
    public partial class SEARCH_USER : UserControl
    {
        String conect = "server=localhost;user id=root;password=euteamo12;persistsecurityinfo=True;database=db";

        public SEARCH_USER()
        {
            InitializeComponent();
        }

        private void btn_search_Click(object sender, EventArgs e)
        {
            MySqlConnection CreateConection = new MySqlConnection(conect);

            String sql = @"SELECT * FROM usuarios where Usuarios= @Pesquisar";
            MySqlCommand comando = new MySqlCommand(sql, CreateConection);
            comando.CommandType = CommandType.Text;
            comando.Parameters.Add("@Pesquisar", MySqlDbType.VarChar).Value = txt_pesquisar.Text;

            try
            {
                if (txt_pesquisar.Text == string.Empty)
                {
                    MessageBox.Show("Campo pesquisar precisa ser preenchido.", "AVISO");
                }

                // Abrir conexãio
                CreateConection.Open();
                // Comandos do Mysql
                MySqlDataReader dados = comando.ExecuteReader();

                if (dados.HasRows == false)
                {
                    throw new Exception("Este nome não existe!");
                }

                dados.Read();

                txt_user.Text = Convert.ToString(dados["Usuarios"]);
                txt_nome.Text = Convert.ToString(dados["Nome"]);
                txt_pass.Text = Convert.ToString(dados["Senha"]);
                cb_nivel.Text = Convert.ToString(dados["Nivel"]);
                txt_tel.Text = Convert.ToString(dados["Telefone"]);
                txt_email.Text = Convert.ToString(dados["Email"]);
                txt_id.Text = Convert.ToString(dados["ID"]);


            }

            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

            finally
            {
                // Fechar conexão
                CreateConection.Close();
            }

            txt_pesquisar.Clear();
        }

        private void btn_edit_Click(object sender, EventArgs e)
        {
            MySqlConnection CreateConection = new MySqlConnection(conect);

            String sql = @"UPDATE usuarios set Usuarios=@Usuarios, Endereco=@Endereco, Nivel=@Nivel, Telefone=@Telefone, Email=@Email, Senha=@Senha where ID=@ID";
            MySqlCommand comando = new MySqlCommand(sql, CreateConection);
            comando.CommandType = CommandType.Text;
            // Parametros
            comando.Parameters.Add("@Usuarios", MySqlDbType.VarChar).Value = txt_user.Text;
            comando.Parameters.Add("@Endereco", MySqlDbType.VarChar).Value = txt_end.Text;
            comando.Parameters.Add("@Telefone", MySqlDbType.VarChar).Value = txt_tel.Text;
            comando.Parameters.Add("@Nivel", MySqlDbType.VarChar).Value = cb_nivel.Text;
            comando.Parameters.Add("@Email", MySqlDbType.VarChar).Value = txt_email.Text;
            comando.Parameters.Add("@Senha", MySqlDbType.VarChar).Value = txt_pass.Text;
            comando.Parameters.Add("@ID", MySqlDbType.VarChar).Value = txt_id.Text;



            try
            {
                // Abrir conexãio
                CreateConection.Open();

                // Comandos do Mysql
                MySqlDataReader dados = comando.ExecuteReader();
                MessageBox.Show("Cadastro alterado com sucesso.", "AVISO");

            }

            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

            finally
            {
                // Fechar conexão
                CreateConection.Close();
            }

            // Limpa as txts dps que finalizar o cadastro
            txt_user.Clear();
            txt_nome.Clear();
            txt_end.Clear();
            txt_email.Clear();
            txt_tel.Clear();
            txt_pass.Clear();
            txt_pesquisar.Clear();
            txt_id.Clear();
            cb_nivel.ResetText();
        }

        private void btn_dell_Click(object sender, EventArgs e)
        {
            MySqlConnection CreateConection = new MySqlConnection(conect);

            String sql = @"DELETE FROM usuarios where User=@User ";
            MySqlCommand comando = new MySqlCommand(sql, CreateConection);
            comando.CommandType = CommandType.Text;
            comando.Parameters.Add("@User", MySqlDbType.VarChar).Value = txt_user.Text;

            try
            {
                // Abrir conexãio
                CreateConection.Open();

                // Comandos do Mysql
                MySqlDataReader dados = comando.ExecuteReader();
                if (MessageBox.Show("Deseja deletar o usuario?", "AVISO", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    MessageBox.Show("Usuario deletado com sucesso.", "AVISO");
                }
            }

            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

            finally
            {
                // Fechar conexão
                CreateConection.Close();
            }

            // Limpa as txts dps que finalizar o cadastro
            txt_nome.Clear();
            txt_end.Clear();
            txt_email.Clear();
            txt_tel.Clear();
            txt_pass.Clear();
            txt_pesquisar.Clear();
        }

        private void txt_pesquisar_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 13)
            {
                btn_search_Click(sender, e);
            }
        }
    }
}
