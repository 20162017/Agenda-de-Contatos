using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace ManipulandoArquivosTexto
{
    class ManipulaArquivoTexto
    {
        private static string enderecoArquivo = AppDomain.CurrentDomain.BaseDirectory + "Contatos.txt";
        public static List<Contato> LerArquivo() {
            List<Contato> listaContato = new List<Contato>();
            if (File.Exists(@enderecoArquivo)) {
                using (StreamReader sr = File.OpenText(@enderecoArquivo)) {
                    while (sr.Peek() >= 0) {
                        string linha = sr.ReadLine();
                        string[] linhaComSplit = linha.Split(';');

                        if (linhaComSplit.Count() == 3) {
                            Contato contato = new Contato();
                            contato.Nome = linhaComSplit[0];
                            contato.Email = linhaComSplit[1];
                            contato.Telefone = linhaComSplit[2];
                            listaContato.Add(contato);
                        }
                    }
                }
            }


            return listaContato;
        }
        public static void EscreverArquivo(List<Contato> listaContato) {
            if (File.Exists(@enderecoArquivo)) {
                using (StreamWriter sw = new StreamWriter(@enderecoArquivo, false, Encoding.UTF8)) {
                    foreach (Contato contato in listaContato) {
                        string linha = string.Format("{0};{1};{2}", contato.Nome, contato.Email, contato.Telefone);
                        sw.WriteLine(linha);
                    }
                    sw.Flush();
                }
            }else
            {
                throw new Exception("O arquivo não existe");
            }
        }
    }
}
