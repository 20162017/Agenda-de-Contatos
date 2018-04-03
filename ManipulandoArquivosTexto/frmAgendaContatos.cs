using ManipulandoArquivosTexto.Classes;
using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace ManipulandoArquivosTexto
{
    public partial class frmAgendaContatos : Form
    {

        OperEnum acao;

        public frmAgendaContatos()
        {
            InitializeComponent();
        }

        private void CarregarListaContatos() {
            lstContatos.Items.Clear();
            lstContatos.Items.AddRange(ManipulaArquivoTexto.LerArquivo().ToArray());
            if(lstContatos.Items.Count > 0)
            {
                lstContatos.SelectedIndex = 0;
            }
        }

        private void frmAgendaContatos_Shown(object sender, EventArgs e)
        {
            CarregarListaContatos();
            AlteraEstadoCampos(false);
            AlteraBotoesSalvarCancelar(false);
            AlteraBotoesIncluirAlterarExcluir(true);
        }

        private void AlteraEstadoCampos(bool estado) {
            txbNome.Enabled = estado;
            txbEmail.Enabled = estado;
            txbTelefone.Enabled = estado;
        }
        private void AlteraBotoesIncluirAlterarExcluir(bool estado) {
            btnIncluir.Enabled = estado;
            btnAlterar.Enabled = estado;
            btnExcluir.Enabled = estado;
        }
        private void AlteraBotoesSalvarCancelar(bool estado) {
            btnSalvar.Enabled = estado;
            btnCancelar.Enabled = estado;
        }

        private void btnIncluir_Click(object sender, EventArgs e)
        {
            AlteraEstadoCampos(true);
            AlteraBotoesIncluirAlterarExcluir(false);
            AlteraBotoesSalvarCancelar(true);
            acao = OperEnum.INCLUIR;
            LimpaCampos();
        }

        private void btnAlterar_Click(object sender, EventArgs e)
        {
            AlteraEstadoCampos(true);
            AlteraBotoesIncluirAlterarExcluir(false);
            AlteraBotoesSalvarCancelar(true);
            acao = OperEnum.ALTERAR;
        }

        private void btnExcluir_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Tem certeza que deseja excluir?", "Pergunta", MessageBoxButtons.YesNo) == DialogResult.Yes) {

                int indiceExcluido = lstContatos.SelectedIndex;
                lstContatos.SelectedIndex = 0;
                lstContatos.Items.RemoveAt(indiceExcluido);

                List<Contato> listaContato = new List<Contato>();
                foreach (Contato contatoDaLista in lstContatos.Items)
                {
                    listaContato.Add(contatoDaLista);
                }

                ManipulaArquivoTexto.EscreverArquivo(listaContato);
                CarregarListaContatos();
                LimpaCampos();

            }
        }

        private void lstContatos_SelectedIndexChanged(object sender, EventArgs e)
        {
            Contato contato;

            if (lstContatos.SelectedIndex > 0)
            {
                contato = (Contato)lstContatos.Items[lstContatos.SelectedIndex];

                txbNome.Text = contato.Nome;
                txbEmail.Text = contato.Email;
                txbTelefone.Text = contato.Telefone;

            }

        }

        private void LimpaCampos() {
            txbNome.Text = "";
            txbEmail.Text = "";
            txbTelefone.Text = "";
            txbBairro.Text = "";
            txbEndereco.Text = "";
            txbEstado.Text = "";
        }

        private void btnSalvar_Click(object sender, EventArgs e)
        {
            Contato contato     = new Contato();
            contato.Nome        = txbNome.Text;
            contato.Email       = txbEmail.Text;
            contato.Telefone    = txbTelefone.Text;
            contato.Bairro      = txbBairro.Text;
            contato.Estado      = txbEstado.Text;
            contato.Endereco   = txbEndereco.Text;

            List<Contato> listaContato = new List<Contato>();

            foreach (Contato contatoLista in lstContatos.Items) {
                listaContato.Add(contatoLista);
            }

            if (acao == OperEnum.INCLUIR)
            {
                listaContato.Add(contato);
            }
            else
            {
                int indice = lstContatos.SelectedIndex;
                listaContato.RemoveAt(indice);
                listaContato.Insert(indice, contato);
            }
            
            ManipulaArquivoTexto.EscreverArquivo(listaContato);
            CarregarListaContatos();
            LimpaCampos();
            AlteraBotoesIncluirAlterarExcluir(true);
            AlteraBotoesSalvarCancelar(false);
            AlteraEstadoCampos(false);
        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void txbBairro_TextChanged(object sender, EventArgs e)
        {

        }

        private void txbEndereço_TextChanged(object sender, EventArgs e)
        {

        }

        private void txbEstado_TextChanged(object sender, EventArgs e)
        {

        }

        private void txbEmail_MaskInputRejected(object sender, MaskInputRejectedEventArgs e)
        {

        }
    }
}
