using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using MySql.Data.MySqlClient;

namespace IndexSearchDemoCS
{
    public partial class Form2 : Form
    {
        public Form2(string digital)
        {
            InitializeComponent();
            label1.Text = digital;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        
        private void Form2_Load(object sender, EventArgs e)
        {
            string config = "server=localhost; database=lanche;  userid=root; password=vertrigo;";
            MySqlConnection conexao = new MySqlConnection(config);
            string query = "SELECT foto , apelido FROM users where id =" + label1.Text;
            //instância do comando onde passo
            //a query e a conexão
            MySqlCommand cmd = new MySqlCommand(query, conexao);
            //Abro conexão
            conexao.Open();
            //instância do leitor que recebe
            //o comando
            MySqlDataReader leitor = cmd.ExecuteReader();
            leitor.Read();
            ////fecho conexão
            DirectoryInfo Dir = new DirectoryInfo(@"C:\dev\Visual Studio\AlmocoBiometrico\resources\" + leitor["foto"]);
            label2.Text = ""+leitor["apelido"];
            pictureBox1.ImageLocation = Dir.ToString();
            conexao.Close();
        }
    }
}
