using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AppContatoForm
{
    public partial class ContatoForm : Form
    {
        private MySqlConnection conexao;

        private MySqlCommand comando;

        public ContatoForm()
        {
            InitializeComponent();

            Conexao();
        }

        private void Conexao()
        {
            string conexaoString = "server=localhost;database=app_contato_bd;user=root;password=root;port=3360";
            conexao = new MySqlConnection(conexaoString);
            comando = conexao.CreateCommand();

            conexao.Open();
        }

        private void btnSalvar_Click(object sender, EventArgs e)
        {
            try                             
            {
                var data = dateDataNascimento.Value;

                if (! rdSexo1.Checked && !rdSexo2.Checked)
                {
                    MessageBox.Show("Marque uma opção!");
                }

                else
                {
                    var nome = txtNome.Text;
                    //var data = dateDataNascimento.Text;
                    var sexo = "Feminino";


                    if (rdSexo1.Checked)
                    {
                        sexo = "Masculino";
                    }

                    var email = txtEmail.Text;
                    var telefone = txtTelefone.Text;

                    string query = "INSERT INTO contato (nome_con, data_nascimento_con, sexo_con, email_con, telefone_con) " +
                    "VALUES (@_nome, @_data_nascimento, @_sexo, @_email, @_telefone)";
                    var comando = new MySqlCommand(query, conexao);

                    comando.Parameters.AddWithValue("@_nome", nome);
                    comando.Parameters.AddWithValue("@_data_nascimento", data);
                    comando.Parameters.AddWithValue("@_sexo", sexo);
                    comando.Parameters.AddWithValue("@_email", email);
                    comando.Parameters.AddWithValue("@_telefone", telefone);

                    comando.ExecuteNonQuery();
                    //conexao.Close();

                    txtNome.Clear();
                    dateDataNascimento.Checked = false;
                    txtEmail.Clear();
                    txtTelefone.Clear();
                    rdSexoGroup.Clear();
                    rdSexo1.Checked = false;
                    rdSexo2.Checked = false;
                    txtNome.Focus();

                    var opcao = MessageBox.Show("Informações salvas com sucesso!\nDeseja realizar um novo cadastro?", "Informação",
                        MessageBoxButtons.YesNo, MessageBoxIcon.Question);


                    if (opcao == DialogResult.Yes)
                    {
                        LimparInputs();
                    }

                    else
                    {
                        this.Close();
                    }
                }

            } catch(Exception ex) {
                /*MessageBox.Show($"Ocorreram erros ao tentar salvar os dados! " +
                $"Contate o suporte do sistema. (CAD 25)");*/
                
                MessageBox.Show(ex.Message); // deixar assim até terminar o código
            }
        }

        private void LimparInputs()
        {
            throw new NotImplementedException();
        }
    }
}
