
using Annex.ClassDomain.Domains;
using Annex.ClassDTO.DTOs.Customs;
using Annex.DataLayer.Contex;
using Annex.InterfaceService.ExternalInterfaces;
using Annex.Service.Services;
using AutoMapper.Internal;
using Microsoft.Extensions.Configuration;
using System.Collections.Generic;
using System.Net;
using System.Net.Cache;
using System.Text;

namespace Annex.Service.ExternalServices
{
    public class FtpService : IFtpService
    {
        private readonly string _Host;
        private readonly string _Port;
        private readonly string _User;
        private readonly string _Password;

        public FtpService()
        {
            var Configuration = new ConfigurationBuilder()
                             .SetBasePath(Directory.GetCurrentDirectory())
                             .AddJsonFile("appsettings.json")
                             .Build();
            _Host = Configuration["FtpAnnexSettings:Host"];
            _Port = Configuration["FtpAnnexSettings:Port"];
            _User = Configuration["FtpAnnexSettings:User"];
            _Password = Configuration["FtpAnnexSettings:PassWord"];
        }

        public async Task<bool> UploadImage(Stream File, string FileName, string ExtensionName, string UploadPath)
        {
            string _Path = "ftp://" + _Host + ":" + _Port + "//" + UploadPath + "//" + FileName + "" + ExtensionName;
            FtpWebRequest ftp = (FtpWebRequest)FtpWebRequest.Create(_Path);
            ftp.Credentials = new NetworkCredential(_User, _Password);
            ftp.CachePolicy = new HttpRequestCachePolicy(HttpRequestCacheLevel.CacheIfAvailable);
            ftp.Method = WebRequestMethods.Ftp.UploadFile;
            using (Stream FtpStream = await ftp.GetRequestStreamAsync().ConfigureAwait(false))
            {
                await File.CopyToAsync(FtpStream).ConfigureAwait(false);
                try
                {
                    using (FtpWebResponse Response = ((FtpWebResponse)await ftp.GetResponseAsync().ConfigureAwait(false)))
                    {
                        //if (Response.StatusCode != FtpStatusCode.CommandOK) { Response.Close(); return false; }

                        return true;
                    }
                }
                catch (WebException ex)
                {
                    FtpWebResponse response = (FtpWebResponse)ex.Response;
                    response.Close();
                    if (response.StatusCode == FtpStatusCode.ActionNotTakenFileUnavailable)
                        return false;
                }
            }
            return false;
        }

        public async Task<bool> DeleteImage(string Path)
        {
            string _Path = "ftp://" + _Host + ":" + _Port + "//" + Path.Replace("/", "//");
            FtpWebRequest ftp = (FtpWebRequest)FtpWebRequest.Create(_Path);
            ftp.Credentials = new NetworkCredential(_User, _Password);
            ftp.CachePolicy = new HttpRequestCachePolicy(HttpRequestCacheLevel.CacheIfAvailable);
            ftp.Method = WebRequestMethods.Ftp.DeleteFile;
            try
            {
                using (FtpWebResponse ResponseDelete = ((FtpWebResponse)await ftp.GetResponseAsync().ConfigureAwait(false)))
                {
                    return true;
                }
            }
            catch (WebException ex)
            {
                FtpWebResponse response = (FtpWebResponse)ex.Response;
                response.Close();
                if (response.StatusCode == FtpStatusCode.ActionNotTakenFileUnavailable)
                    return false;
            }
            return false;
        }

        public async Task<bool> Exists(string Path)
        {
            string _Path = "ftp://" + _Host + ":" + _Port + "//" + Path.Replace("/", "//");
            FtpWebRequest ftp = (FtpWebRequest)FtpWebRequest.Create(_Path);
            ftp.Credentials = new NetworkCredential(_User, _Password);
            ftp.CachePolicy = new HttpRequestCachePolicy(HttpRequestCacheLevel.CacheIfAvailable);
            ftp.Method = WebRequestMethods.Ftp.GetFileSize;

            try
            {
                FtpWebResponse response = (FtpWebResponse)await ftp.GetResponseAsync().ConfigureAwait(false);
                return true;
            }
            catch (WebException ex)
            {
                FtpWebResponse response = (FtpWebResponse)ex.Response;
                if (response.StatusCode == FtpStatusCode.ActionNotTakenFileUnavailable)
                    return false;
            }
            return false;
        }

        public async Task<bool> ExistsDirectory(string PathDirectory)
        {
            string _Path = PathDirectory + "/";
            FtpWebRequest ftp = (FtpWebRequest)FtpWebRequest.Create(_Path);
            ftp.Credentials = new NetworkCredential(_User, _Password);
            ftp.CachePolicy = new HttpRequestCachePolicy(HttpRequestCacheLevel.CacheIfAvailable);
            ftp.Method = WebRequestMethods.Ftp.ListDirectory;

            try
            {
                using (FtpWebResponse response = (FtpWebResponse)await ftp.GetResponseAsync().ConfigureAwait(false))
                {
                    return true;
                }
            }
            catch (WebException ex)
            {
                FtpWebResponse response = (FtpWebResponse)ex.Response;
                response.Close();
                if (response.StatusCode == FtpStatusCode.ActionNotTakenFileUnavailable)
                    return false;
            }
            return false;
        }

        public async Task<bool> CreateDirectory(string Path)
        {
            if (Path != "")
            {
                var DirectoryNames = Path.Split('/');
                string _Path = "ftp://" + _Host + ":" + _Port;
                foreach (var item in DirectoryNames)
                {
                    _Path += '/' + item;
                    if (!(await ExistsDirectory(_Path)))
                    {
                        WebRequest ftp = FtpWebRequest.Create(_Path);
                        ftp.Credentials = new NetworkCredential(_User, _Password);
                        ftp.CachePolicy = new HttpRequestCachePolicy(HttpRequestCacheLevel.CacheIfAvailable);
                        ftp.Method = WebRequestMethods.Ftp.MakeDirectory;
                        try
                        {
                            FtpWebResponse response = (FtpWebResponse)await ftp.GetResponseAsync().ConfigureAwait(false);
                            // return true;
                        }
                        catch (WebException ex)
                        {
                            FtpWebResponse response = (FtpWebResponse)ex.Response;
                            //if (response.StatusCode == FtpStatusCode.ActionNotTakenFileUnavailable)
                            // return false;
                        }
                    }
                }
                return true;
            }
            return false;
        }

        public async Task<bool> DeleteDirectory(string Path)
        {
            string _Path = "ftp://" + _Host + ":" + _Port + "//" + Path;
            FtpWebRequest ftp = (FtpWebRequest)FtpWebRequest.Create(_Path);
            ftp.Credentials = new NetworkCredential(_User, _Password);
            ftp.CachePolicy = new HttpRequestCachePolicy(HttpRequestCacheLevel.CacheIfAvailable);
            ftp.Method = WebRequestMethods.Ftp.RemoveDirectory;
            ftp.UseBinary = true;
            ftp.UsePassive = true;
            ftp.KeepAlive = true;
            try
            {
                using (FtpWebResponse response = (FtpWebResponse)await ftp.GetResponseAsync().ConfigureAwait(false))
                {
                    return true;
                }
            }
            catch (WebException ex)
            {
                FtpWebResponse response = (FtpWebResponse)ex.Response;
                response.Close();
                if (response.StatusCode == FtpStatusCode.ActionNotTakenFileUnavailable)
                    return false;
            }
            return false;
        }

        public async Task<bool> DeleteDirectoryFiles(string Path)
        {
            string _Path = "ftp://" + _Host + ":" + _Port + "//" + Path;
            FtpWebRequest ftp = (FtpWebRequest)FtpWebRequest.Create(_Path);
            ftp.Credentials = new NetworkCredential(_User, _Password);
            ftp.CachePolicy = new HttpRequestCachePolicy(HttpRequestCacheLevel.CacheIfAvailable);
            ftp.Method = WebRequestMethods.Ftp.ListDirectory;
            try
            {
                using (var response = (FtpWebResponse)await ftp.GetResponseAsync().ConfigureAwait(false))
                {
                    using (var responseStream = response.GetResponseStream())
                    {
                        using (var reader = new StreamReader(responseStream, true))
                        {
                            while (!reader.EndOfStream)
                            {
                                var P = Path.Replace("//", "/");
                                await DeleteImage(P + (await reader.ReadLineAsync().ConfigureAwait(false))); // Delete 
                            }
                        }
                    }
                }
                var PathDirector = Path.Substring(0, Path.Length - 2);
                await DeleteDirectory(PathDirector);
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }


        public async Task<List<Annexs>> UploadListFiles(List<DtoListFiles> Files, string Path, int Reference_ID, int AnnexSetting_ID)
        {
            var ListAnnexs = new List<Annexs>();

            if (Files.Count() > 0)
            {

                foreach (DtoListFiles file in Files)
                {
                    string _Path = "ftp://" + _Host + ":" + _Port + "//" + Path + "//" + file.FileNamePhysic + "" + file.ExtensionName;
                    FtpWebRequest ftp = (FtpWebRequest)FtpWebRequest.Create(_Path);
                    ftp.Credentials = new NetworkCredential(_User, _Password);
                    ftp.CachePolicy = new HttpRequestCachePolicy(HttpRequestCacheLevel.CacheIfAvailable);
                    ftp.Method = WebRequestMethods.Ftp.UploadFile;
                    using (Stream FtpStream = await ftp.GetRequestStreamAsync().ConfigureAwait(false))
                    {
                        await file.FileStream.CopyToAsync(FtpStream).ConfigureAwait(false);
                        using (FtpWebResponse Response = ((FtpWebResponse)await ftp.GetResponseAsync().ConfigureAwait(false)))
                        {
                            //if (Response.StatusCode != FtpStatusCode.CommandOK) { Response.Close(); return false; }
                            Response.Close();
                            file.FileStream.Close();

                            var _Annex = new Annexs()
                            {
                                Annex_Path = Path.Replace("//", "/"),
                                Annex_FileNamePhysicy = file.FileNamePhysic,
                                Annex_FileNameLogic = file.FileNameLogic,
                                Annex_ReferenceID = Reference_ID,
                                Annex_CreatedDate = DateTime.Now,
                                Annex_Description = file.FileDesc,
                                //    Annex_ReferenceFolderName = DtoUser.Usr_FName + " " + DtoUser.Usr_LName,
                                Annex_AnnexSettingID = AnnexSetting_ID,
                                Annex_FileExtension = file.ExtensionName,
                                Annex_IsDefault = file.IsDefault,
                            };

                            ListAnnexs.Add(_Annex);
                        }
                    }
                }
                return ListAnnexs;
            }
            return ListAnnexs;
        }

        public string UploadImageTest(Stream File, string FileName, string ExtensionName, string UploadPath)
        {
            throw new NotImplementedException();
        }
    }
}

