

using Annex.ClassDomain.Domains;
using Annex.ClassDTO.DTOs.Customs;

namespace Annex.InterfaceService.ExternalInterfaces
{

    public interface IFtpService
    {
        Task<List<Annexs>> UploadListFiles(List<DtoListFiles> Files, string Path, int Reference_ID, int AnnexSetting_ID);
        Task<bool> UploadImage(Stream File, string FileName, string ExtensionName, string UploadPath);
        Task<bool> DeleteImage(string Path);
        Task<bool> CreateDirectory(string Path);
        Task<bool> DeleteDirectory(string Path);
        Task<bool> DeleteDirectoryFiles(string Path);
        Task<bool> Exists(string Path);
        Task<bool> ExistsDirectory(string PathDirectory);
    }
}
