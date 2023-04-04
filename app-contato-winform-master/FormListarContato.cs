using MySql.Data.MySqlClient;
using MySqlX.XDevAPI;
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
using AppContatoForm.RegrasDeNegocios;

namespace AppContatoForm
{
    public partial class FormListarContato : Form
    {
        List<Contato> contato = new List<Contato>();
        private MySqlConnection conexao;
        private MySqlCommand comando;

        public FormListarContato()
        {
            InitializeComponent();
            Conexao();
            CarregarLista();
        }

        private void CarregarLista()
        {
           MySqlCommand cmd = new MySqlCommand("Select * From contato", conexao);
           MySqlDataAdapter da = new MySqlDataAdapter(cmd);
           DataTable dt = new DataTable();
           da.Fill(dt);


           dgvContato.DataSource = dt;
        }

        private void Conexao()
        {
            string conexaoString = "server=localhost;database=app_contato_bd;user=root;password=root;port=3360";
            conexao = new MySqlConnection(conexaoString);
            comando = conexao.CreateCommand();

            conexao.Open(); 
        }
    }
}
