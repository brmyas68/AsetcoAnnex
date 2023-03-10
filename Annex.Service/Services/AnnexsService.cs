

using System.Linq.Expressions;
using Microsoft.EntityFrameworkCore;
using Annex.ClassDomain.Domains;
using Annex.ClassDTO.DTOs.Customs;
using Annex.DataLayer.Contex;
using Annex.InterfaceService.Interfaces;
using Annex.Service.ServiceBase;
using Microsoft.Data.SqlClient;
using Annex.Common.Consts.StoredProcedures;

namespace Annex.Service.Services
{
    public class AnnexsService : BaseService<Annexs>, IAnnexsService
    {
        private readonly ContextAnnex _ContextAnnex;
        public AnnexsService(ContextAnnex ContextAnnex) : base(ContextAnnex)
        {
            _ContextAnnex = ContextAnnex;
        }
        public async Task<List<DtoFiles>> GetAllFiles(int RefID, int AnnexSettingID)
        {
            var _Annexes = await _ContextAnnex.Annexs.Where(A => A.Annex_ReferenceID == RefID && A.Annex_AnnexSettingID == AnnexSettingID).ToListAsync().ConfigureAwait(false);
            return _Annexes.Select(A => new DtoFiles
            {
                Annex_Id = A.Annex_ID,
                PathFile = A.Annex_Path + "/" + A.Annex_FileNamePhysicy + "" + A.Annex_FileExtension,
            }).ToList();
        }

        public async Task<List<DtoAnnexLogo_>> GetAllLogoAnnex(int LanguageID, int AnnexSettingID)
        {
            var _Cmd = _ContextAnnex.Database.GetDbConnection().CreateCommand();
            bool IsOpen = _Cmd.Connection.State == System.Data.ConnectionState.Open;
            if (!IsOpen) await _Cmd.Connection.OpenAsync().ConfigureAwait(false);
            _Cmd.CommandText = EnumSP.SPAnnex.Annex_GetAllLogoAnnex.ToString();
            _Cmd.CommandType = System.Data.CommandType.StoredProcedure;
            _Cmd.Parameters.Add(new SqlParameter("AnnexSettingID", AnnexSettingID));
            _Cmd.Parameters.Add(new SqlParameter("LanguageID", LanguageID));
            var _ListAnnexes = new List<DtoAnnexLogo_>();
            using (var _Reader = await _Cmd.ExecuteReaderAsync().ConfigureAwait(false))
            {
                if (_Reader.HasRows)
                {
                    try
                    {
                        while (await _Reader.ReadAsync().ConfigureAwait(false))
                        {
                            _ListAnnexes.Add(new DtoAnnexLogo_()
                            {
                                Annex_ID = Convert.ToInt32(_Reader["Annex_ID"]),
                                TagName = _Reader["TagName"].ToString(),
                                Path = _Reader["_PathName"].ToString(),
                                Trans_TagName = _Reader["Trans_TagName"].ToString(),
                            });
                        }
                    }

                    finally
                    {
                        await _Reader.CloseAsync().ConfigureAwait(false);
                        if (IsOpen)
                            await _Cmd.Connection.CloseAsync().ConfigureAwait(false);
                    }
                }
            }
            return _ListAnnexes;
        }

        public async Task<List<DtoAnnexLogo_>> GetAllPathFile(int LanguageID, int AnnexSettingID)
        {
            var _Cmd = _ContextAnnex.Database.GetDbConnection().CreateCommand();
            bool IsOpen = _Cmd.Connection.State == System.Data.ConnectionState.Open;
            if (!IsOpen) await _Cmd.Connection.OpenAsync().ConfigureAwait(false);
            _Cmd.CommandText = EnumSP.SPAnnex.Annex_GetAllPathFile.ToString();
            _Cmd.CommandType = System.Data.CommandType.StoredProcedure;
            _Cmd.Parameters.Add(new SqlParameter("AnnexSetting_ID", AnnexSettingID));
            _Cmd.Parameters.Add(new SqlParameter("Lang_ID", LanguageID));
            var _ListAnnexes = new List<DtoAnnexLogo_>();
            using (var _Reader = await _Cmd.ExecuteReaderAsync().ConfigureAwait(false))
            {
                if (_Reader.HasRows)
                {
                    try
                    {
                        while (await _Reader.ReadAsync().ConfigureAwait(false))
                        {
                            _ListAnnexes.Add(new DtoAnnexLogo_()
                            {
                                Annex_ID = Convert.ToInt32(_Reader["AnexID"]),
                                TagName = _Reader["TagName"].ToString(),
                                Path = _Reader["Path"].ToString(),
                                Trans_TagName = _Reader["TransTag"].ToString(),
                            });
                        }
                    }

                    finally
                    {
                        await _Reader.CloseAsync().ConfigureAwait(false);
                        if (IsOpen)
                            await _Cmd.Connection.CloseAsync().ConfigureAwait(false);
                    }
                }
            }
            return _ListAnnexes;
        }
    }
}
