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
        private int contador = 5;

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
            CarregaComboBox();

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
            lblnome.Text = "" + leitor["apelido"];
            pictureBox1.ImageLocation = Dir.ToString();
            conexao.Close();

            timer1.Enabled = true;
            timer1.Interval = 25;

            timer2.Enabled = true;


            contador = 5;

            tempo.Enabled = true;
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            label6.Text = DateTime.Now.ToShortDateString();
        }

        private void timer2_Tick(object sender, EventArgs e)
        {
            contador = contador - 1;

            tempo.Text = "(" + contador + ")";

            if (contador == 0)
            {
                timer1.Enabled = false;
                Close();
            }
        }

        private void label8_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void CarregaComboBox()
        {
            //Seto o display com a propriedade
            //"NOME" da classe Cliente
            comboBox1.DisplayMember = "Nome";
            //DataSource
            comboBox1.DataSource = RetornaLista();
        }

        private List<Form1.Usuario> RetornaLista()
        {
            //instância do list
            List<Form1.Usuario> lista = new List<Form1.Usuario>();
            //instância da conexão
            string config = "server=localhost; database=lanche;  userid=root; password=vertrigo;";
            MySqlConnection conexao = new MySqlConnection(config);
            //query do comando
            string selectDuBom = "SELECT nome " +
                                 "FROM produtos " +
                                 "WHERE sobremesa = " + 1 + " " +
                                 "AND id IN(" +
                                 "(SELECT id_produto " +
                                 "FROM produto_cardapio " +
                                 "WHERE id_cardapio = " +
                                 "(SELECT id " +
                                 "FROM cardapio " +
                                 "WHERE data = '" + DateTime.Now.ToString("yyyy-MM-dd") + "' " +
                                 "AND turno =" + 0 + ")))";
            //instância do comando onde passo
            //a query e a conexão
            MySqlCommand cmd = new MySqlCommand(selectDuBom, conexao);
            //Abro conexão
            conexao.Open();
            //instância do leitor que recebe
            //o comando
            MySqlDataReader leitor = cmd.ExecuteReader();
            //se há linhas
            if (leitor.HasRows)
            {
                //enquanto leitor lê
                while (leitor.Read())
                {
                    //instância de um objeto cliente
                    Form1.Usuario c = new Form1.Usuario();
                    //atribuo os valores do bd
                    c.Nome = leitor["nome"].ToString();
                    //adiciono o objeto a lista
                    lista.Add(c);
                    comboBox1.Text = "Selecione um item";

                }
            }
            else
            {
                comboBox1.Text = "Não há sobremesas";
                comboBox1.Enabled = false;
            }
            //fecho conexão
            conexao.Close();
            //retorno a lista
            return lista;
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}
