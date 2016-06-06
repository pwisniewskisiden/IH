using ArxOne.Ftp;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Text.RegularExpressions;

namespace DAL.FTP
{
    public class FTP
    {
        Uri ftpUri;
        NetworkCredential ftpCredentials;
        
        public FTP(string uri, string user, string passwd)
        {
            ftpUri = new System.Uri(uri);
            ftpCredentials = new NetworkCredential(user,passwd);   
        }

        public void Recive(string fromServPath, string toLocalPath, string fileEnding)
        {  
            using (var ftpClient = new FtpClient(ftpUri, ftpCredentials))
            {
                var files = ftpClient.ListEntries(fromServPath);
                foreach (var file in files)
                {
                    if (file.Type != FtpEntryType.File) continue;
                    if (!file.Name.EndsWith(fileEnding)) continue;
                    FtpPath path =new FtpPath(fromServPath+"/"+file.Name);
                    using (var stream = ftpClient.Retr(path, FtpTransferMode.Binary))
                    {
                        using (var fileStream = new FileStream(toLocalPath+"/"+file.Name, FileMode.Create, FileAccess.Write))
                        {
                            stream.CopyTo(fileStream);
                        }

                    }
                    ftpClient.RnfrTo(fromServPath + "/" + file.Name, fromServPath + "/" + file.Name + ".BACKUP." + Guid.NewGuid()+".txt");
                    //ftpClient.Dele(fromServPath + "/" + file.Name);
                }
            }
        }
        public void Send(string inLocal, string outFTP)
        {
            /*
            string[] filePaths = Directory.GetFiles(inLocal);
            using (var ftpClient = new FtpClient(ftpUri, ftpCredentials))
            {

                foreach (var filePath in filePaths)
                {
                    using (var fileStream = new FileStream(filePath, FileMode.Open, FileAccess.Read))
                    {
                        using (var stream = ftpClient.Stor(outFTP + "/" + Path.GetFileName(filePath), FtpTransferMode.Binary))
                        {
                            fileStream.CopyTo(stream);
                        }
                    }

                    var a = filePath;
                    var b = Path.GetDirectoryName(filePath) + "\\DeleteME" + Path.GetFileName(filePath);
                    File.Move(filePath, Path.GetDirectoryName(filePath)+"\\DeleteME"+Path.GetFileName(filePath));
                }
            }
            */
        }

        public void Send(string inLocal, string outFTP, string regex)
        {
            string[] filePaths = Directory.GetFiles(inLocal);
            using (var ftpClient = new FtpClient(ftpUri, ftpCredentials))
            {

                foreach (var filePath in filePaths)
                {
                    if (Path.GetFileName(filePath).StartsWith(regex))
                    {
                        using (var fileStream = new FileStream(filePath, FileMode.Open, FileAccess.Read))
                        {
                            using (var stream = ftpClient.Stor(outFTP + "/" + Path.GetFileName(filePath), FtpTransferMode.Binary))
                            {
                                fileStream.CopyTo(stream);
                            }
                        }
      
                        File.Move(filePath,Path.GetDirectoryName(filePath)+@"/BACKUP_"+Guid.NewGuid()+Path.GetFileName(filePath));
                    }
                }
            }
        }
    }
}
