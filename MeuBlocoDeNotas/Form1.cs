using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
using MySql.Data.MySqlClient;

//Novo Comentário definido
namespace MeuBlocoDeNotas {
    public partial class formulario : Form {
        public formulario() { //Construtor Padrão
            InitializeComponent();
        }
       
        //Método: clicar no botão salvar do bloco de notas
        //Definir parâmetros e abrir caixa de diálogo
        public void salvarToolStripMenuItem_Click(object sender, EventArgs e) {
            Form formulario = new formulario();
            saveFileDialog1.FileName = formulario.Text;
            saveFileDialog1.Filter =
            "Text files (*.txt)|*.txt|All files (*.*)|*.*";
            saveFileDialog1.ShowDialog(); //Mostra janela para salvar
        }

        //Método: clicar em salvar na caixa de diálogo
        //Salvar texto digitado no arquivo
        public void saveFileDialog1_FileOk(object sender, CancelEventArgs e) {
            
            string Caminho = saveFileDialog1.FileName;
           File.WriteAllText(Caminho, txtJanela.Text);
            
        }

        //Clicar no botão sair do bloco de notas
        public void sairToolStripMenuItem_Click(object sender, EventArgs e) {
            this.Close();
        }

        //Clicar no botão para inserir no banco de dados
        private void button1_Click(object sender, EventArgs e) {
            try
            {
                //MySqlConnection objetoconexao = new MySqlConnection("server=localhost;port=3306;User Id=root;database=bd_blocodenotas;password=Banco,1997");
                MySqlConnection objetoconexao = new MySqlConnection("server=db4free.net;port=3306;User Id=milenammc;database=bd_blocodenotas;password=Banco,1997;old guids=true");
                objetoconexao.Open();

                //Comando SQL para inserir dados na tabela
                MySqlCommand comando = new MySqlCommand("insert into tb_dados (cod, texto, nome,cidade) values (null,?,?,?);", objetoconexao);
                //Parâmetros do comando inserir
                comando.Parameters.Add("@texto",MySqlDbType.VarChar,60).Value = txtJanela.Text;
                comando.Parameters.Add("@nome", MySqlDbType.VarChar, 60).Value = txtNome.Text;
                comando.Parameters.Add("@cidade", MySqlDbType.VarChar, 60).Value = cmbCidade.SelectedItem.ToString();
                //Comando para executar a query
                comando.ExecuteNonQuery();

                MessageBox.Show("Dados inseridos com sucesso");
                objetoconexao.Close();
                
            }

            catch(Exception erro)
            {
                MessageBox.Show("Não conectou "+ erro);
            }
        }

        private void label3_Click(object sender, EventArgs e) {

        }

        private void formulario_Load(object sender, EventArgs e) {
            //Inserir dados no combobox de cidade
            cmbCidade.Items.Add("Curitiba");
            cmbCidade.Items.Add("Guaratinguetá");
        }

        private void button1_Click_1(object sender, EventArgs e) {
        
        }
    }
}
