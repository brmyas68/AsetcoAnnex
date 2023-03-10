

using Annex.ClassDTO.DTOs;
using Annex.InterfaceService.ExternalInterfaces;
using Annex.InterfaceService.Interfaces;

namespace Annex.InterfaceService.InterfacesBase
{
    public interface IUnitOfWorkAnnexService : IDisposable
    {

        IAnnexsService _IAnnexsService { get; }
        IAnnexSettingService _IAnnexSettingService { get; }
        IFtpService _IFtpService { get; }

        int SaveChange_DataBase();
        Task<int> SaveChange_DataBase_Async();

    }
}
