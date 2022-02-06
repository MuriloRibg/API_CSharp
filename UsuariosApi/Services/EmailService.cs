using System;
using MimeKit;
using UsuariosApi.Models;

namespace UsuariosApi.Services
{
    public class EmailService
    {
        public void EnviarEmail(string[] destinatario, string assunto, int usuarioId, string codigoAtivacao)
        {
            Mensagem mensagem = new Mensagem(destinatario, assunto, usuarioId, codigoAtivacao);

            var mensagemDeEmail = CriarCorpoEmail(mensagem);
        }

        private object CriarCorpoEmail(Mensagem mensagem)
        {
            var mensagemDeEmail = new MimeMessage();
            //MailBoxBddress é para converter, pois n pode ser uma string.
            mensagemDeEmail.From.Add(new MailboxAddress("Remetente"));
            mensagemDeEmail.To.AddRange(mensagem.Destinatario);
            mensagemDeEmail.Subject = mensagem.Assunto;
            mensagemDeEmail.Body = new TextPart(MimeKit.Text.TextFormat.Text) { //é oq o e-mail aceita
                Text = mensagem.Conteudo
            }; 
        }
    }
}
