using System.Diagnostics;
using System.IO;
using CleanSync.Domain.Entities;
using Newtonsoft.Json;

namespace CleanSync.Infrastructure.Services
{
    public class FileReader
    {
        public static DatabaseConfig ReadConfig()
        {
            string path = Process.GetCurrentProcess().MainModule.FileName;
            string trueFolder = Path.GetDirectoryName(path);

            if (string.IsNullOrEmpty(trueFolder))
                throw new InvalidOperationException("Não foi possível determinar a pasta do E-Trade.");

            string filePath = Path.Combine(trueFolder, "ArqID.txt");

            if(!File.Exists(filePath))
                throw new FileNotFoundException($"O arquivo ArqID.txt não foi encontrado no caminho {filePath}");

            string json = File.ReadAllText(filePath);

            return JsonConvert.DeserializeObject<DatabaseConfig>(json)
                ?? throw new InvalidOperationException("Formato inválido no arquivo de configuração do ArqID.");
        }
    }
}
