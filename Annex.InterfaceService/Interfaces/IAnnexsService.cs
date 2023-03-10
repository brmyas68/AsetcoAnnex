

using Annex.ClassDomain.Domains;
using Annex.ClassDTO.DTOs.Customs;
using Annex.InterfaceService.InterfacesBase;

namespace Annex.InterfaceService.Interfaces
{
    public interface IAnnexsService : IBaseService<Annexs>
    {
        Task<List<DtoFiles>> GetAllFiles(int RefID, int AnnexSettingID);
        Task<List<DtoAnnexLogo_>> GetAllLogoAnnex(int LanguageID, int AnnexSettingID);
        Task<List<DtoAnnexLogo_>> GetAllPathFile(int LanguageID, int AnnexSettingID);
    }
}
