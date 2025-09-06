using System.Security.Cryptography;
using System.Text;

namespace Vitrine.Models {
    public static class Criptografia {

        // Chave secreta de 32 bytes (256 bits) para criptografia AES
        private static readonly string chaveSecreta = "ChaveUltraSecreta123456789012345"; // deve ter 32 caracteres
        // Vetor de inicialização (IV) de 16 bytes
        private static readonly string vetorInicializacao = "1234567890123456"; // deve ter 16 caracteres

        // Método para criptografar uma string e retornar o texto criptografado em Base64
        public static string Criptografar(string texto) {
            // Verifica se o texto é nulo ou vazio
            if (string.IsNullOrEmpty(texto))
                return string.Empty;

            // Converte a chave e o IV em arrays de bytes
            byte[] chave = Encoding.UTF8.GetBytes(chaveSecreta);
            byte[] iv = Encoding.UTF8.GetBytes(vetorInicializacao);

            // Cria um objeto AES
            using (Aes aesAlg = Aes.Create()) {
                aesAlg.Key = chave; // define a chave
                aesAlg.IV = iv;     // define o IV

                // Cria um objeto para criptografar os dados
                ICryptoTransform encryptor = aesAlg.CreateEncryptor(aesAlg.Key, aesAlg.IV);

                // Usa um stream para escrever os dados criptografados
                using (MemoryStream msEncrypt = new MemoryStream()) {
                    // Cria o stream de criptografia
                    using (CryptoStream csEncrypt = new CryptoStream(msEncrypt, encryptor, CryptoStreamMode.Write)) {
                        // Converte o texto em bytes
                        byte[] textoBytes = Encoding.UTF8.GetBytes(texto);
                        // Escreve os dados no stream criptografado
                        csEncrypt.Write(textoBytes, 0, textoBytes.Length);
                        csEncrypt.FlushFinalBlock();

                        // Retorna o conteúdo criptografado em formato Base64
                        return Convert.ToBase64String(msEncrypt.ToArray());
                    }
                }
            }
        }

        // Método para decriptografar uma string criptografada e retornar o texto original
        public static string Decriptografar(string textoCriptografado) {
            // Verifica se o texto é nulo ou vazio
            if (string.IsNullOrEmpty(textoCriptografado))
                return string.Empty;

            // Converte a chave e o IV em arrays de bytes
            byte[] chave = Encoding.UTF8.GetBytes(chaveSecreta);
            byte[] iv = Encoding.UTF8.GetBytes(vetorInicializacao);

            // Converte o texto criptografado de Base64 para array de bytes
            byte[] textoBytes = Convert.FromBase64String(textoCriptografado);

            // Cria um objeto AES
            using (Aes aesAlg = Aes.Create()) {
                aesAlg.Key = chave; // define a chave
                aesAlg.IV = iv;     // define o IV

                // Cria um objeto para descriptografar os dados
                ICryptoTransform decryptor = aesAlg.CreateDecryptor(aesAlg.Key, aesAlg.IV);

                // Usa um stream para ler os dados descriptografados
                using (MemoryStream msDecrypt = new MemoryStream(textoBytes)) {
                    // Cria o stream de descriptografia
                    using (CryptoStream csDecrypt = new CryptoStream(msDecrypt, decryptor, CryptoStreamMode.Read)) {
                        // Lê os dados do stream e retorna como string
                        using (StreamReader srDecrypt = new StreamReader(csDecrypt)) {
                            return srDecrypt.ReadToEnd();
                        }
                    }
                }
            }
        }
    }
}

//string original = "minhaSenha123";
//string criptografado = Criptografia.Criptografar(original);
//string decriptografado = Criptografia.Decriptografar(criptografado);

//Console.WriteLine($"Original: {original}");
//Console.WriteLine($"Criptografado: {criptografado}");
//Console.WriteLine($"Decriptografado: {decriptografado}");
