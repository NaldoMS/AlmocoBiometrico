using System;
using System.IO;
using System.Drawing;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Windows.Forms;
using System.Data;
using System.IO;
using MySql.Data.MySqlClient;


using NITGEN.SDK.NBioBSP;

namespace IndexSearchDemoCS
{
    /// <summary>
    /// Summary description for Form1.
    /// </summary>
    public class Form1 : System.Windows.Forms.Form
    {
        NBioAPI m_NBioAPI;
        NBioAPI.IndexSearch m_IndexSearch;

        private GroupBox groupBox1;
        private Button btnRegist;
        private ColumnHeader columnUserID;
        private ColumnHeader columnFpID;
        private ColumnHeader columnSampleNo;
        private TextBox textUserID;
        private ListView listSearchDB;
        private ListView listResult;
        private ColumnHeader columnHeader1;
        private ColumnHeader columnHeader2;
        private ColumnHeader columnHeader3;
        private GroupBox groupBox2;
        private Button btnIdentify;
        private Button btnExit;
        private Button btnDBRemove;
        private Button btnSaveFile;
        private Label label1;
        private Button btnLoadFile;
        private Button btnDBClear;
        private ComboBox comboBox1;

        /// <summary>
        /// Required designer variable.
        /// </summary>

        public Form1()
        {
            //
            // Required for Windows Form Designer support
            //
            InitializeComponent();

            //
            // TODO: Add any constructor code after InitializeComponent call
            //

            // Create NBioBSP object
            m_NBioAPI = new NBioAPI();
            m_IndexSearch = new NBioAPI.IndexSearch(m_NBioAPI);
        }

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>


        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.groupBox1 = new GroupBox();
            this.comboBox1 = new ComboBox();
            this.label1 = new Label();
            this.btnRegist = new Button();
            this.textUserID = new TextBox();
            this.listSearchDB = new ListView();
            this.columnUserID = ((ColumnHeader)(new ColumnHeader()));
            this.columnFpID = ((ColumnHeader)(new ColumnHeader()));
            this.columnSampleNo = ((ColumnHeader)(new ColumnHeader()));
            this.listResult = new ListView();
            this.columnHeader1 = ((ColumnHeader)(new ColumnHeader()));
            this.columnHeader2 = ((ColumnHeader)(new ColumnHeader()));
            this.columnHeader3 = ((ColumnHeader)(new ColumnHeader()));
            this.groupBox2 = new GroupBox();
            this.btnIdentify = new Button();
            this.btnExit = new Button();
            this.btnDBRemove = new Button();
            this.btnSaveFile = new Button();
            this.btnLoadFile = new Button();
            this.btnDBClear = new Button();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.comboBox1);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.btnRegist);
            this.groupBox1.Controls.Add(this.textUserID);
            this.groupBox1.Location = new System.Drawing.Point(8, 8);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(296, 85);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Registro";
            // 
            // comboBox1
            // 
            this.comboBox1.FormattingEnabled = true;
            this.comboBox1.Location = new System.Drawing.Point(53, 27);
            this.comboBox1.Name = "comboBox1";
            this.comboBox1.Size = new System.Drawing.Size(228, 21);
            this.comboBox1.TabIndex = 3;
            this.comboBox1.SelectedIndexChanged += new System.EventHandler(this.comboBox1_SelectedIndexChanged_1);
            // 
            // label1
            // 
            this.label1.Location = new System.Drawing.Point(8, 24);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(48, 24);
            this.label1.TabIndex = 2;
            this.label1.Text = "Usuário";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // btnRegist
            // 
            this.btnRegist.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnRegist.Location = new System.Drawing.Point(11, 55);
            this.btnRegist.Name = "btnRegist";
            this.btnRegist.Size = new System.Drawing.Size(101, 24);
            this.btnRegist.TabIndex = 1;
            this.btnRegist.Text = "Cadastrar";
            this.btnRegist.Click += new System.EventHandler(this.btnRegist_Click);
            // 
            // textUserID
            // 
            this.textUserID.Location = new System.Drawing.Point(240, 4);
            this.textUserID.Name = "textUserID";
            this.textUserID.Size = new System.Drawing.Size(50, 20);
            this.textUserID.TabIndex = 0;
            this.textUserID.Visible = false;
            // 
            // listSearchDB
            // 
            this.listSearchDB.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnUserID,
            this.columnFpID,
            this.columnSampleNo});
            this.listSearchDB.FullRowSelect = true;
            this.listSearchDB.GridLines = true;
            this.listSearchDB.Location = new System.Drawing.Point(8, 99);
            this.listSearchDB.Name = "listSearchDB";
            this.listSearchDB.Size = new System.Drawing.Size(296, 213);
            this.listSearchDB.TabIndex = 0;
            this.listSearchDB.UseCompatibleStateImageBehavior = false;
            this.listSearchDB.View = System.Windows.Forms.View.Details;
            // 
            // columnUserID
            // 
            this.columnUserID.Text = "ID Usuário";
            this.columnUserID.Width = 93;
            // 
            // columnFpID
            // 
            this.columnFpID.Text = "ID do dedo";
            this.columnFpID.Width = 101;
            // 
            // columnSampleNo
            // 
            this.columnSampleNo.Text = "Nº do teste";
            this.columnSampleNo.Width = 93;
            // 
            // listResult
            // 
            this.listResult.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader1,
            this.columnHeader2,
            this.columnHeader3});
            this.listResult.FullRowSelect = true;
            this.listResult.GridLines = true;
            this.listResult.Location = new System.Drawing.Point(312, 99);
            this.listResult.Name = "listResult";
            this.listResult.Size = new System.Drawing.Size(296, 213);
            this.listResult.TabIndex = 5;
            this.listResult.UseCompatibleStateImageBehavior = false;
            this.listResult.View = System.Windows.Forms.View.Details;
            // 
            // columnHeader1
            // 
            this.columnHeader1.Text = "ID Usuário";
            this.columnHeader1.Width = 93;
            // 
            // columnHeader2
            // 
            this.columnHeader2.Text = "ID do dedo";
            this.columnHeader2.Width = 101;
            // 
            // columnHeader3
            // 
            this.columnHeader3.Text = "Nº do teste";
            this.columnHeader3.Width = 95;
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.btnIdentify);
            this.groupBox2.Location = new System.Drawing.Point(312, 8);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(296, 85);
            this.groupBox2.TabIndex = 3;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Procurar";
            // 
            // btnIdentify
            // 
            this.btnIdentify.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnIdentify.Location = new System.Drawing.Point(87, 27);
            this.btnIdentify.Name = "btnIdentify";
            this.btnIdentify.Size = new System.Drawing.Size(120, 24);
            this.btnIdentify.TabIndex = 1;
            this.btnIdentify.Text = "Verificar usuário";
            this.btnIdentify.Click += new System.EventHandler(this.btnIdentify_Click);
            // 
            // btnExit
            // 
            this.btnExit.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnExit.Location = new System.Drawing.Point(480, 352);
            this.btnExit.Name = "btnExit";
            this.btnExit.Size = new System.Drawing.Size(128, 24);
            this.btnExit.TabIndex = 6;
            this.btnExit.Text = "Sair";
            this.btnExit.Click += new System.EventHandler(this.btnExit_Click);
            // 
            // btnDBRemove
            // 
            this.btnDBRemove.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnDBRemove.Location = new System.Drawing.Point(8, 320);
            this.btnDBRemove.Name = "btnDBRemove";
            this.btnDBRemove.Size = new System.Drawing.Size(144, 24);
            this.btnDBRemove.TabIndex = 1;
            this.btnDBRemove.Text = "Remover registro";
            this.btnDBRemove.Click += new System.EventHandler(this.btnDBRemove_Click);
            // 
            // btnSaveFile
            // 
            this.btnSaveFile.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSaveFile.Location = new System.Drawing.Point(10, 352);
            this.btnSaveFile.Name = "btnSaveFile";
            this.btnSaveFile.Size = new System.Drawing.Size(144, 24);
            this.btnSaveFile.TabIndex = 2;
            this.btnSaveFile.Text = "Salvar dados";
            this.btnSaveFile.Visible = false;
            this.btnSaveFile.Click += new System.EventHandler(this.btnSaveFile_Click);
            // 
            // btnLoadFile
            // 
            this.btnLoadFile.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnLoadFile.Location = new System.Drawing.Point(160, 352);
            this.btnLoadFile.Name = "btnLoadFile";
            this.btnLoadFile.Size = new System.Drawing.Size(144, 24);
            this.btnLoadFile.TabIndex = 4;
            this.btnLoadFile.Text = "Carregar BD";
            this.btnLoadFile.Visible = false;
            this.btnLoadFile.Click += new System.EventHandler(this.btnLoadFile_Click);
            // 
            // btnDBClear
            // 
            this.btnDBClear.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnDBClear.Location = new System.Drawing.Point(154, 320);
            this.btnDBClear.Name = "btnDBClear";
            this.btnDBClear.Size = new System.Drawing.Size(150, 24);
            this.btnDBClear.TabIndex = 3;
            this.btnDBClear.Text = "Limpar DB";
            this.btnDBClear.Click += new System.EventHandler(this.btnDBClear_Click);
            // 
            // Form1
            // 
            this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
            this.ClientSize = new System.Drawing.Size(616, 381);
            this.Controls.Add(this.btnLoadFile);
            this.Controls.Add(this.btnDBClear);
            this.Controls.Add(this.btnSaveFile);
            this.Controls.Add(this.btnDBRemove);
            this.Controls.Add(this.btnExit);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.listResult);
            this.Controls.Add(this.listSearchDB);
            this.Controls.Add(this.groupBox1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Name = "Form1";
            this.Text = "Sistema de almoço";
            this.Closed += new System.EventHandler(this.Form1_Closed);
            this.Load += new System.EventHandler(this.Form1_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.Run(new Form1());
        }

        public class Usuario
        {
            public string Nome { get; set; }
            public int Id { get; set; }
        }

        private void Form1_Load(object sender, System.EventArgs e)
        {
            string config = "server=localhost; database=lanche;  userid=root; password=vertrigo;";
            MySqlConnection conexao = new MySqlConnection(config);

            CarregaComboBox();

            uint ret = m_IndexSearch.InitEngine();
            if (ret != NBioAPI.Error.NONE)
            {
                DisplayErrorMsg(ret);
            }


            NBioAPI.Type.VERSION version = new NBioAPI.Type.VERSION();
            m_NBioAPI.GetVersion(out version);

            listSearchDB.Items.Clear();
            listResult.Items.Clear();

            btnLoadFile_Click(sender, e);
        }

        private void CarregaComboBox()
        {
            //Seto o display com a propriedade
            //"NOME" da classe Cliente
            comboBox1.DisplayMember = "Nome";
            //DataSource
            comboBox1.DataSource = RetornaLista();
        }

        private List<Usuario> RetornaLista()
        {
            //instância do list
            List<Usuario> lista = new List<Usuario>();
            //instância da conexão
            string config = "server=localhost; database=lanche;  userid=root; password=vertrigo;";
            MySqlConnection conexao = new MySqlConnection(config);
            //query do comando
            string query = "SELECT nome FROM users ORDER BY Nome";
            //instância do comando onde passo
            //a query e a conexão
            MySqlCommand cmd = new MySqlCommand(query, conexao);
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
                    Usuario c = new Usuario();
                    //atribuo os valores do bd
                    c.Nome = leitor["nome"].ToString();
                    //adiciono o objeto a lista
                    lista.Add(c);

                }
            }
            //fecho conexão
            conexao.Close();
            //retorno a lista
            return lista;
        }

        private void Form1_Closed(object sender, System.EventArgs e)
        {
            m_IndexSearch.ClearDB();
        }

        private void DisplayErrorMsg(uint ret)
        {
            MessageBox.Show(NBioAPI.Error.GetErrorDescription(ret) + " [" + ret.ToString() + "]", "Error!",
                MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        private void btnRegist_Click(object sender, System.EventArgs e)
        {
            NBioAPI.Type.HFIR hNewFIR;
            uint nUserID = 0;

            // Get User ID
            try
            {
                int test = Convert.ToInt32(textUserID.Text, 10);
                if (test == 0)
                    throw (new Exception());
            }
            catch
            {
                MessageBox.Show("User ID must be have numeric type and greater than 0.", "Error!", MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
                return;
            }

            nUserID = Convert.ToUInt32(textUserID.Text, 10);

            // Get FIR data
            m_NBioAPI.OpenDevice(NBioAPI.Type.DEVICE_ID.AUTO);
            uint ret = m_NBioAPI.Enroll(out hNewFIR, null);
            if (ret != NBioAPI.Error.NONE)
            {
                DisplayErrorMsg(ret);
                m_NBioAPI.CloseDevice(NBioAPI.Type.DEVICE_ID.AUTO);
                return;
            }

            m_NBioAPI.CloseDevice(NBioAPI.Type.DEVICE_ID.AUTO);

            // Regist FIR to IndexSearch DB
            NBioAPI.IndexSearch.FP_INFO[] fpInfo;
            ret = m_IndexSearch.AddFIR(hNewFIR, nUserID, out fpInfo);
            if (ret != NBioAPI.Error.NONE)
            {
                DisplayErrorMsg(ret);
                return;
            }

            // Add item to list of SearchDB
            foreach (NBioAPI.IndexSearch.FP_INFO sampleInfo in fpInfo)
            {
                ListViewItem listItem = new ListViewItem();
                listItem.Text = sampleInfo.ID.ToString();
                listItem.SubItems.Add(sampleInfo.FingerID.ToString());
                listItem.SubItems.Add(sampleInfo.SampleNumber.ToString());
                listSearchDB.Items.Add(listItem);
            }

            btnSaveFile_Click(sender, e);
        }

        private void btnIdentify_Click(object sender, System.EventArgs e)
        {
            NBioAPI.Type.HFIR hCapturedFIR;

            listResult.Items.Clear();

            // Get FIR data
            m_NBioAPI.OpenDevice(NBioAPI.Type.DEVICE_ID.AUTO);
            uint ret = m_NBioAPI.Capture(out hCapturedFIR);
            if (ret != NBioAPI.Error.NONE)
            {
                DisplayErrorMsg(ret);
                m_NBioAPI.CloseDevice(NBioAPI.Type.DEVICE_ID.AUTO);
                return;
            }

            m_NBioAPI.CloseDevice(NBioAPI.Type.DEVICE_ID.AUTO);


            uint nMax;
            m_IndexSearch.GetDataCount(out nMax);

            NBioAPI.IndexSearch.CALLBACK_INFO_0 cbInfo0 = new NBioAPI.IndexSearch.CALLBACK_INFO_0();

            // Identify FIR to IndexSearch DB
            NBioAPI.IndexSearch.FP_INFO fpInfo;
            ret = m_IndexSearch.IdentifyData(hCapturedFIR, NBioAPI.Type.FIR_SECURITY_LEVEL.NORMAL, out fpInfo, cbInfo0);
            if (ret != NBioAPI.Error.NONE)
            {
                btnIdentify_Click(sender, e);

                //DisplayErrorMsg(ret);
                return;
            }

            // Add item to list of result
            ListViewItem listItem = new ListViewItem();
            listItem.Text = fpInfo.ID.ToString();
            listItem.SubItems.Add(fpInfo.FingerID.ToString());
            listItem.SubItems.Add(fpInfo.SampleNumber.ToString());
            listResult.Items.Add(listItem);
        }

        private void btnExit_Click(object sender, System.EventArgs e)
        {
            Close();
        }

        private void btnDBRemove_Click(object sender, System.EventArgs e)
        {
            uint nUserID;
            byte nFingerID, nSampleNumber;

            if (listSearchDB.Items.Count <= 0)
                return;

            if (listSearchDB.SelectedItems.Count <= 0)
            {
                MessageBox.Show("Selecione um item ...", "Error!", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            uint ret = NBioAPI.Error.NONE;
            bool bIsRemoveAll = true;

            for (int i = listSearchDB.SelectedItems.Count - 1; i >= 0; i--)
            {
                nUserID = Convert.ToUInt32(listSearchDB.SelectedItems[i].Text);
                nFingerID = Convert.ToByte(listSearchDB.SelectedItems[i].SubItems[1].Text);
                nSampleNumber = Convert.ToByte(listSearchDB.SelectedItems[i].SubItems[2].Text);

                ret = m_IndexSearch.RemoveData(nUserID, nFingerID, nSampleNumber);
                if (ret != NBioAPI.Error.NONE)
                {
                    bIsRemoveAll = false;
                    break;
                }
            }

            if (bIsRemoveAll)
            {
                for (int i = listSearchDB.SelectedItems.Count - 1; i >= 0; i--)
                    listSearchDB.SelectedItems[i].Remove();
                MessageBox.Show("Usuário deleteado com sucesso!");
            }
            else
            {
                DisplayErrorMsg(ret);
            }
            btnSaveFile_Click(sender, e);
        }

        private void btnSaveFile_Click(object sender, EventArgs e)
        {
            uint ret = NBioAPI.Error.NONE;

            string szFileName = "";

            DirectoryInfo Dir = new DirectoryInfo(@"C:\Users\MC114\Desktop\iteva.ISDB");

            szFileName = Dir.FullName;

            if (szFileName != "")
            {
                if (File.Exists(@"C:\Users\MC114\Desktop\iteva.ISDB"))
                {
                    try
                    {
                        File.Delete(@"C:\Users\MC114\Desktop\iteva.ISDB");
                        File.Delete(@"C:\Users\MC114\Desktop\iteva.FID");
                    }
                    catch (IOException ex)
                    {
                        MessageBox.Show(ex.Message);
                        return;
                    }
                }
                // Save SearchDB to File
                ret = m_IndexSearch.SaveDBToFile(szFileName);
                if (ret != NBioAPI.Error.NONE)
                {
                    DisplayErrorMsg(ret);
                    return;
                }

                // Save list to file
                szFileName = Path.ChangeExtension(szFileName, "FID");

                FileStream fs = new FileStream(szFileName, FileMode.OpenOrCreate, FileAccess.Write);
                StreamWriter fw = new StreamWriter(fs);

                for (int i = 0; i < listSearchDB.Items.Count; i++)
                {
                    fw.WriteLine(listSearchDB.Items[i].Text + "\t" + listSearchDB.Items[i].SubItems[1].Text + "\t" +
                                 listSearchDB.Items[i].SubItems[2].Text);
                }

                fw.Close();
                fs.Close();
            }
        }

        private void btnDBClear_Click(object sender, System.EventArgs e)
        {
            // Clear ListView of SearchDB
            listSearchDB.Items.Clear();

            // Clear IndexSearchDB
            m_IndexSearch.ClearDB();
            btnSaveFile_Click(sender, e);
        }

        private void btnLoadFile_Click(object sender, System.EventArgs e)
        {
            uint ret = NBioAPI.Error.NONE;

            string szFileName = "";

            //Caminho do arquivo com as digitais
            DirectoryInfo Dir = new DirectoryInfo(@"C:\Users\MC114\Desktop\iteva.ISDB");

            szFileName = Dir.FullName;
            if (szFileName != "")
            {
                // Clear ListView of SearchDB
                listSearchDB.Items.Clear();
                // Clear IndexSearchDB
                m_IndexSearch.ClearDB();

                // Load SearchDB from File
                ret = m_IndexSearch.LoadDBFromFile(szFileName);
                if (ret != NBioAPI.Error.NONE)
                {
                    DisplayErrorMsg(ret);
                    return;
                }

                listSearchDB.Items.Clear();

                // Load list from file
                szFileName = Path.ChangeExtension(szFileName, "FID");

                FileStream fs = new FileStream(szFileName, FileMode.Open, FileAccess.Read);
                StreamReader fr = new StreamReader(fs);

                while (fr.Peek() >= 0)
                {
                    try
                    {
                        string szLine = fr.ReadLine();

                        string[] szSplit = szLine.Split('\t');

                        ListViewItem listItem = new ListViewItem();
                        listItem.Text = szSplit[0];
                        listItem.SubItems.Add(szSplit[1]);
                        listItem.SubItems.Add(szSplit[2]);
                        listSearchDB.Items.Add(listItem);
                    }
                    catch
                    {
                        break;
                    }
                }

                fr.Close();
                fs.Close();

            }
            else
            {
                MessageBox.Show("Erro ao carregar arquivo !", "Error!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void comboBox1_SelectedIndexChanged_1(object sender, EventArgs e)
        {
            //instância da conexão
            string config = "server=localhost; database=lanche;  userid=root; password=vertrigo;";
            MySqlConnection conexao = new MySqlConnection(config);
            //query do comando
            string query = "SELECT id FROM users where nome = '" + comboBox1.Text + "'";
            //instância do comando onde passo
            //a query e a conexão
            MySqlCommand cmd = new MySqlCommand(query, conexao);
            //Abro conexão
            conexao.Open();
            //instância do leitor que recebe
            //o comando
            MySqlDataReader leitor = cmd.ExecuteReader();
            //se há linhas
            leitor.Read();
            //atribuo os valores do bd
            textUserID.Text = "" + leitor["id"];
            //fecho conexão
            conexao.Close();
        }
    }
}
