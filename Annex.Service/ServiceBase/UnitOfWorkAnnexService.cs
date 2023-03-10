

using Annex.InterfaceService.InterfacesBase;
using Annex.DataLayer.Contex;
using Annex.InterfaceService.Interfaces;
using Annex.Service.Services;
using Annex.InterfaceService.ExternalInterfaces;
using Annex.Service.ExternalServices;

namespace Annex.Service.ServiceBase
{
    public class UnitOfWorkAnnexService : IUnitOfWorkAnnexService
    {
        private readonly ContextAnnex _ContextAnnex;

        private IAnnexsService _AnnexsService;
        private IAnnexSettingService _AnnexSettingService;
        private IFtpService _FtpService;

        public UnitOfWorkAnnexService(ContextAnnex ContextAnnex)
        {
            _ContextAnnex = ContextAnnex;
        }

        public IAnnexsService _IAnnexsService { get { return _AnnexsService = _AnnexsService ?? new AnnexsService(_ContextAnnex); } }
        public IAnnexSettingService _IAnnexSettingService { get { return _AnnexSettingService = _AnnexSettingService ?? new AnnexSettingService(_ContextAnnex); } }

       // public IFtpService _IFtpService { get { return _FtpService = _FtpService ?? new FtpService(); } }
        public IFtpService _IFtpService { get { return _FtpService = _FtpService ?? new FtpService(); } }


        public int SaveChange_DataBase()
        {
            return _ContextAnnex.SaveChanges();
        }

        public async Task<int> SaveChange_DataBase_Async()
        {
            return await _ContextAnnex.SaveChangesAsync().ConfigureAwait(false);
        }

        private bool disposed = false;


        protected virtual void Dispose(bool disposing)
        {
            if (!disposed)
            {
                if (disposing)
                {
                    _ContextAnnex.Dispose();
                }
            }
            this.disposed = true;
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
    }
}
