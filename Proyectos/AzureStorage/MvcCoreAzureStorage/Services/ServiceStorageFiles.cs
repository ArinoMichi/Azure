using Azure.Storage.Files.Shares;
using Azure.Storage.Files.Shares.Models;

namespace MvcCoreAzureStorage.Services
{
    public class ServiceStorageFiles
    {
        //TODO SERVICIO DE STORAGE SIEMPRE UTILIZA
        //UN CLIENT PARA ACCEDER A SUS RECURSOS
        //DICHO CLIENT NECESITA DE UNAS KEYS
        private ShareDirectoryClient root;

        //DEBEMOS RECIBIR LAS JETS DESDE APPSETTINGS
        public ServiceStorageFiles(IConfiguration configuration)
        {
            string keys = configuration.GetValue<string>("AzureKeys:StorageAccount");
            //CADA CLIENTE DE STORAGE ACCEDE A UN Share MEDIANTE 
            //LAS CLAVES
            ShareClient client =
                new ShareClient(keys, "ejemplofiles");
            this.root = client.GetRootDirectoryClient();
        }

        //METODO PARA RECUPERAR TODOS LOS FICHEROS DE LA 
        //RAIZ DEL SHARED
        public async Task<List<string>> GetFilesAsync()
        {
            List<string> files = new List<string>();
            await foreach(ShareFileItem item in this.root.GetFilesAndDirectoriesAsync())
            {
                files.Add(item.Name);
            }

            return files;
        }

        public async Task<string> ReadFileAsync(string fileName)
        {
            //NECESITAMOS UN CLIENT DEL RECURSO QUE QUEREMOS
            //RECUPERAR (file)
            ShareFileClient file =
                this.root.GetFileClient(fileName);
            ShareFileDownloadInfo data= await file.DownloadAsync();
            Stream stream = data.Content;
            string contenido = "";
            using(StreamReader reader = new StreamReader(stream))
            {
                contenido = await reader.ReadToEndAsync();
            }
            return contenido;
        }

        public async Task UploadFileAsync(string fileName, Stream stream)
        {
            ShareFileClient file =
                this.root.GetFileClient(fileName);
            await file.CreateAsync(stream.Length);
            await file.UploadAsync(stream);
        }

        public async Task DeleteFileAsync(string fileName)
        {
            ShareFileClient file =
                this.root.GetFileClient(fileName);
            await file.DeleteAsync();
        }
    }
}
