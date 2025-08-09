namespace ProjetoContrato.Infra.Messages.Service
{
    public class UpdateTeste
    {
        public static async Task ConsumeMessage()
        {
            // Obtém o diretório onde o executável está localizado
            string pastaDoExecutavel = AppDomain.CurrentDomain.BaseDirectory;

            // Define o nome do arquivo
            string nomeDoArquivo = "registro_data_hora.txt";

            // Monta o caminho completo do arquivo
            string caminhoCompleto = Path.Combine(pastaDoExecutavel, nomeDoArquivo);

            // Conteúdo a ser gravado: data e hora atual
            string conteudo = "escreveu...";

            // Grava o conteúdo no arquivo (sobrescreve se já existir)
            // await File.AppendAllTextAsync(caminhoCompleto, conteudo + Environment.NewLine);

            Console.WriteLine($"Arquivo gravado em: {caminhoCompleto}");
        }
    }
}