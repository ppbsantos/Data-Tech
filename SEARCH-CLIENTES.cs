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
    public partial class CLIENTES : UserControl
    {
        String conect = "server=localhost;user id=root;password=euteamo12;persistsecurityinfo=True;database=db";

        public CLIENTES()
        {
            InitializeComponent();
            txt_name.Enabled = false;
        }

        private void btn_search_Click(object sender, EventArgs e)
        {
            
            MySqlConnection CreateConection = new MySqlConnection(conect);

            String sql = @"SELECT * FROM clientes where Nome= @Pesquisar";
            MySqlCommand comando = new MySqlCommand(sql, CreateConection);
            comando.CommandType = CommandType.Text;
            comando.Parameters.Add("@Pesquisar", MySqlDbType.VarChar).Value = txt_pesquisar.Text;

            try
            {
                if(txt_pesquisar.Text == string.Empty)
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

                txt_name.Text = Convert.ToString(dados["Nome"]);
                txt_dress.Text = Convert.ToString(dados["Endereco"]);
                txt_nasc.Text = Convert.ToString(dados["Nascimento"]);
                txt_cep.Text = Convert.ToString(dados["Cep"]);
                txt_tel.Text = Convert.ToString(dados["Telefone"]);
                txt_email.Text = Convert.ToString(dados["Email"]);
                txt_desc.Text = Convert.ToString(dados["Descricao"]);
                txt_id.Text = Convert.ToString(dados["ID"]);

                
            }

            catch(Exception ex)
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
            String sql = @"UPDATE clientes set Nome=@Nome, Endereco=@Endereco, Nascimento=@Nascimento, Cep=@Cep, Telefone=@Telefone, Email=@Email, Descricao=@Descricao where ID=@ID";
            MySqlCommand comando = new MySqlCommand(sql, CreateConection);
            
            // Parametros
            comando.Parameters.Add("@Nome", MySqlDbType.VarChar).Value = txt_name.Text;
            comando.Parameters.Add("@Endereco", MySqlDbType.VarChar).Value = txt_dress.Text;
            comando.Parameters.Add("@Nascimento", MySqlDbType.VarChar).Value = txt_nasc.Text;
            comando.Parameters.Add("@Cep", MySqlDbType.VarChar).Value = txt_cep.Text;
            comando.Parameters.Add("@Telefone", MySqlDbType.VarChar).Value = txt_tel.Text;
            comando.Parameters.Add("@Email", MySqlDbType.VarChar).Value = txt_email.Text;
            comando.Parameters.Add("@Descricao", MySqlDbType.VarChar).Value = txt_desc.Text;
            comando.Parameters.Add("@ID", MySqlDbType.VarChar).Value = txt_id.Text;

            comando.CommandType = CommandType.Text;
            // Abrir conexãio
            CreateConection.Open();
            try
            {
                int i = comando.ExecuteNonQuery();
                if (i > 0)
                    MessageBox.Show("Cadastro atualizado com sucesso!");
            }
            catch (Exception ex)
            {
                MessageBox.Show("Erro: " + ex.ToString());
            }
            finally
            {
                CreateConection.Close();
            }

            
      

            // Limpa as txts dps que finalizar o cadastro
            txt_name.Clear();
            txt_dress.Clear();
            txt_email.Clear();
            txt_tel.Clear();
            txt_cep.Clear();
            txt_nasc.Clear();
            txt_desc.Clear();
            txt_pesquisar.Clear();
            txt_id.Clear();
        }

        private void btn_dell_Click(object sender, EventArgs e)
        {
            MySqlConnection CreateConection = new MySqlConnection(conect);

            String sql = @"DELETE FROM clientes where Nome=@Nome ";
            MySqlCommand comando = new MySqlCommand(sql, CreateConection);
            comando.CommandType = CommandType.Text;
            comando.Parameters.Add("@Nome", MySqlDbType.VarChar).Value = txt_name.Text;

            try
            {
                // Abrir conexãio
                CreateConection.Open();

                // Comandos do Mysql
                MySqlDataReader dados = comando.ExecuteReader();
                if (MessageBox.Show("Deseja deletar o cliente?", "AVISO", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                { 
                MessageBox.Show("Cliente deletado com sucesso.", "AVISO");
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
            txt_name.Clear();
            txt_dress.Clear();
            txt_email.Clear();
            txt_tel.Clear();
            txt_cep.Clear();
            txt_nasc.Clear();
            txt_desc.Clear();
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
