
using Annex.ClassDomain.Domains;
using Annex.ClassDTO.DTOs.Customs;
using Annex.InterfaceService.InterfacesBase;

namespace Annex.InterfaceService.Interfaces
{
    public interface IAnnexSettingService : IBaseService<AnnexSetting>
    {
        Task<DtoAnnexSetting_> GetPath(int TenantID, string keyword);
        Task<List<DtoListAnnexSetting>> GetAll_SP(int TenantID);
    }
}
