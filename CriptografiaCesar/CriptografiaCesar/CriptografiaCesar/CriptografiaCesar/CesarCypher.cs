using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace CriptografiaCesar
{
    class CesarCypher
    {
        public string Crypt(string message)
        {
            if (!MensagemValida(message))
            {
                throw new ArgumentOutOfRangeException();
            }

            string menssagemMinuscula = ConverteMinuscula(message);
            string mensagemCriptografada = ConverteCriptografia(menssagemMinuscula, 3, true);
            Console.WriteLine(mensagemCriptografada);
            return mensagemCriptografada;
        }

        public string Decrypt(string cryptedMessage)
        {
            if (!MensagemValida(cryptedMessage))
            {
                throw new ArgumentOutOfRangeException();
            }

            string menssagemMinuscula = ConverteMinuscula(cryptedMessage);
            string mensagemDecriptografada = ConverteCriptografia(menssagemMinuscula, 3, false);
            Console.WriteLine(mensagemDecriptografada);
                 
            return mensagemDecriptografada;
        }


        private bool MensagemValida(string message)
        {
            Regex regex = new Regex(@"^[A-Za-z0-9]*(\s|$)");
            return regex.IsMatch(message);
        }

        private String ConverteMinuscula(string message)
        {
            return message.ToLower();
        }
             

        private String ConverteCriptografia(string mensagem, int chave, bool criptografar)
        {
            Regex regexNum = new Regex(@"^[0-9]*(\s|$)");
            StringBuilder mensagemConvertida = new StringBuilder();
              
            for(int contador=0; contador< mensagem.Length; contador++)
            {
                String caracter = mensagem[contador].ToString();
                if (regexNum.IsMatch(caracter))
                {
                    mensagemConvertida.Append(caracter);
                }
                else
                {
                    if (criptografar == true)
                    {
                        mensagemConvertida.Append(Criptografia(mensagem, chave, contador));
                    }
                    else
                    {
                        mensagemConvertida.Append(Decriptografia(mensagem, chave, contador));
                    }
                } 
            }
            return mensagemConvertida.ToString();

        }

        private string Criptografia(string mensagem, int chave, int contador)
        {
            int novoValor = ((int)mensagem[contador] + 3);
            if (novoValor > 122)
            {
                novoValor = novoValor - 26;
            }

            ASCIIEncoding AsciiCode = new ASCIIEncoding();
            return AsciiCode.GetString(BitConverter.GetBytes(novoValor)).Substring(0, 1);
        
        }

        private string Decriptografia(string mensagem, int chave, int contador)
        {
            int novoValor = ((int)mensagem[contador] - 3);
            if (novoValor < 97)
            {
                novoValor = novoValor + 26;
            }

            ASCIIEncoding AsciiCode = new ASCIIEncoding();
            return AsciiCode.GetString(BitConverter.GetBytes(novoValor)).Substring(0, 1);

        }

    }
}
