using PCLStorage;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace weekysoft.store.Storage
{
    public class FileStorage
    {
        private string _Folder;
        private IFolder folder;
        public FileStorage(string f)
        {
            _Folder = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.Personal),f);
            folder = new FileSystemFolder(_Folder);
            //folder.CreateFolderAsync(f, CreationCollisionOption.OpenIfExists).Wait();
        }
        //IFileSystem _FileSystem { get { return FileSystem.Current; } }
        public string GetFolderPath()
        {
            return Environment.GetFolderPath(Environment.SpecialFolder.Personal);
            //return folder.Path;
        }

        public async Task<string> CreateFile(string fileName)
        {
            //IFolder folder = new FileSystemFolder(_Folder);
            //IFolder folder = await _FileSystem.LocalStorage.CreateFolderAsync(_Folder, CreationCollisionOption.OpenIfExists);
            //string expectedPath = PortablePath.Combine(folder.Path, fileName);
            IFile file = await folder.CreateFileAsync(fileName, CreationCollisionOption.OpenIfExists);

            //IFile gottenFile = await _FileSystem.GetFileFromPathAsync(expectedPath);
            return file.Path;
        }

        public async Task<string> GetFileContent(string fileName)
        {
            //IFolder folder = new FileSystemFolder(_Folder);
            //IFolder folder = await _FileSystem.LocalStorage.CreateFolderAsync(_Folder, CreationCollisionOption.OpenIfExists);
            //string expectedPath = PortablePath.Combine(folder.Path, fileName);
            IFile file = await folder.CreateFileAsync(fileName, CreationCollisionOption.OpenIfExists);

            //IFile gottenFile = await _FileSystem.GetFileFromPathAsync(expectedPath);
            string gottenContents = await file.ReadAllTextAsync();
            return gottenContents;
        }
        public async Task<bool> SaveFileContent(string fileName, string content)
        {
            //IFolder folder = new FileSystemFolder(_Folder);
            //IFolder folder = await _FileSystem.LocalStorage.CreateFolderAsync(_Folder, CreationCollisionOption.OpenIfExists);
            IFile file = await folder.CreateFileAsync(fileName, CreationCollisionOption.OpenIfExists);
            await file.WriteAllTextAsync(content);
            return true;
        }
    }
}
