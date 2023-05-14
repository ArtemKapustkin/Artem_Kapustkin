using Dropbox.Api;
using Dropbox.Api.Files;
using NUnit.Framework;

namespace WebAPI
{

    public interface IDropboxClientFactory
    {
        DropboxClient CreateDropboxClient(string accessToken);
    }

    public class DropboxClientFactory : IDropboxClientFactory
    {
        public DropboxClient CreateDropboxClient(string accessToken)
        {
            var config = new DropboxClientConfig("wv6b4smzxs8z3f8");
            return new DropboxClient(accessToken, config);
        }
    }

    public interface IDropboxManager
    {
        Task UploadFileToDropbox(string accessToken, string localFilePath, string destinationPath);
        Task<Metadata> GetFileMetadata(string accessToken, string localFilePath);
        Task DeleteFile(string accessToken, string filePath);
        Task<bool> CheckFileExistsInDropbox(string accessToken, string localFilePath);
    }

    public class DropboxManager : IDropboxManager
    {
        private readonly IDropboxClientFactory _dropboxClientFactory;

        public DropboxManager(IDropboxClientFactory dropboxClientFactory)
        {
            _dropboxClientFactory = dropboxClientFactory;
        }

        public async Task UploadFileToDropbox(string accessToken, string localFilePath, string destinationPath)
        {
            try
            {
                using (var fileStream = File.OpenRead(localFilePath))
                {
                    var client = _dropboxClientFactory.CreateDropboxClient(accessToken);
                    var uploadResult = await client.Files.UploadAsync(
                        destinationPath,
                        WriteMode.Overwrite.Instance,
                        body: fileStream);

                    Console.WriteLine("Uploaded file: " + uploadResult.PathDisplay);
                }
            }
            catch (Exception ex)
            {
                // Handle the exception appropriately
                throw new DropboxManagerException("An error occurred while uploading the file.", ex);
            }
        }

        public async Task<Metadata> GetFileMetadata(string accessToken, string localFilePath)
        {
            try
            {
                var client = _dropboxClientFactory.CreateDropboxClient(accessToken);
                // Get file metadata
                var metadata = await client.Files.GetMetadataAsync(localFilePath);

                // Process the metadata
                if (metadata.IsFile)
                {
                    var fileMetadata = (FileMetadata)metadata;
                    return fileMetadata;
                }
                else if (metadata.IsFolder)
                {
                    return metadata;
                }
                else
                {
                    throw new InvalidOperationException("Invalid file.");
                }
            }
            catch (ApiException<GetMetadataError> ex)
            {
                throw new DropboxManagerException($"Error getting metadata: {ex.Message}", ex);
            }
        }
        public async Task DeleteFile(string accessToken, string filePath)
        {
            try
            {
                var client = _dropboxClientFactory.CreateDropboxClient(accessToken);
                var deleteResult = await client.Files.DeleteV2Async(filePath);
                Console.WriteLine($"Deleted file: {deleteResult.Metadata.PathDisplay}");
            }
            catch (ApiException<DeleteError> ex)
            {
                Console.WriteLine($"Error deleting file: {ex.Message}");
            }
        }
        public async Task<bool> CheckFileExistsInDropbox(string accessToken, string localFilePath)
        {
            try
            {
                var client = _dropboxClientFactory.CreateDropboxClient(accessToken);
                // Get file metadata
                var metadata = await client.Files.GetMetadataAsync(localFilePath);

                // Check if the metadata represents a file
                if (metadata.IsFile)
                {
                    return true; // File exists
                }
            }
            catch (ApiException<GetMetadataError>)
            {
                // Ignore the exception and return false
            }

            return false; // File does not exist or encountered an error
        }
    }

    public class DropboxManagerException : Exception
    {
        public DropboxManagerException(string message, Exception innerException)
            : base(message, innerException)
        {
        }
    }
}


namespace WebAPI.Tests
{
    [TestFixture]
    public class Tests
    {
        static string accessToken = "sl.BeYDRWf0xerqaXzFjf-heRstARj_XaF0-lJ1AvzJl3mQ4CTPgXIgaTgDqReCm5WfXmygAMaNvHnJlLjsweyfgr7mjt5mG8kEW0IG5UHW7a0R7XKW0K9Wzjbd1WKVri5zPCtu2x4LQ8k";
        static string localFilePath = "C:\\Users\\akapu\\Desktop\\testapi.txt";
        static string dropboxDestinationPath = "/Documents/file.txt";
        static DropboxClientFactory dropboxClient = new DropboxClientFactory();
        static DropboxManager dropboxManager = new DropboxManager(dropboxClient);
        [Test]
        public async Task UploadFileToDropboxTest()
        {
            // Act
            await dropboxManager.UploadFileToDropbox(accessToken, localFilePath, dropboxDestinationPath);
            // Assert
            var uploadedFileExists = await dropboxManager.CheckFileExistsInDropbox(accessToken, dropboxDestinationPath);
            Assert.IsTrue(uploadedFileExists, "The file was not uploaded successfully to Dropbox");
        }
        [Test]
        public async Task GetFileMetadataFromDropboxTest()
        {
            // Act
            var metadata = await dropboxManager.GetFileMetadata(accessToken, dropboxDestinationPath);
            // Assert
            Console.WriteLine(metadata.Name);
            Assert.AreEqual("file.txt", metadata.Name, "The file name does not match the expected value");
        }

        [Test]
        public async Task DeleteFileFromDropboxTest()
        {
            // Act
            await dropboxManager.DeleteFile(accessToken, dropboxDestinationPath);
            // Assert
            var fileExistsAfterDeletion = await dropboxManager.CheckFileExistsInDropbox(accessToken, dropboxDestinationPath);
            Assert.IsFalse(fileExistsAfterDeletion, "The file was not deleted successfully from Dropbox");

        }
    }
}