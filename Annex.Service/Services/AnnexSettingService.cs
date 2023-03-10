

using Annex.ClassDomain.Domains;
using Annex.ClassDTO.DTOs.Customs;
using Annex.Common.Consts.StoredProcedures;
using Annex.DataLayer.Contex;
using Annex.InterfaceService.Interfaces;
using Annex.Service.ServiceBase;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using System.Data;
using System.Reflection.PortableExecutable;
using static Annex.Common.Consts.StoredProcedures.EnumSP;

namespace Annex.Service.Services
{
    public class AnnexSettingService : BaseService<AnnexSetting>, IAnnexSettingService
    {
        private readonly ContextAnnex _ContextAnnex;
        public AnnexSettingService(ContextAnnex ContextAnnex) : base(ContextAnnex)
        {
            _ContextAnnex = ContextAnnex;
        }

        public async Task<List<DtoListAnnexSetting>> GetAll_SP(int TenantID)
        {
            var _Cmd = _ContextAnnex.Database.GetDbConnection().CreateCommand();
            bool IsOpen = _Cmd.Connection.State == System.Data.ConnectionState.Open;
            if (!IsOpen)
                await _Cmd.Connection.OpenAsync().ConfigureAwait(false);
            _Cmd.CommandText = SPAnnex.Annex_GetAllAnnexSetting.ToString();
            _Cmd.CommandType = System.Data.CommandType.StoredProcedure;
            SqlParameter Parameter_AnnexSetting = new SqlParameter();
            Parameter_AnnexSetting.ParameterName = "TenantID";
            Parameter_AnnexSetting.SqlDbType = SqlDbType.Int;
            Parameter_AnnexSetting.Value = TenantID;
            _Cmd.Parameters.Add(Parameter_AnnexSetting);
            var _ListAnnexSetting = new List<DtoListAnnexSetting>();
            using (var _Reader = await _Cmd.ExecuteReaderAsync().ConfigureAwait(false))
            {
                try
                {
                    while (await _Reader.ReadAsync().ConfigureAwait(false))
                    {
                        _ListAnnexSetting.Add(
                            new DtoListAnnexSetting
                            {
                                AnxSeting_ID = Convert.ToInt32(_Reader["AnxSeting_ID"]),
                                AnxSeting_KeyWord = Convert.ToString(_Reader["AnxSeting_KeyWord"]),
                                AnxSeting_RefComent = Convert.ToString(_Reader["AnxSeting_RefComent"]),
                                AnxSeting_SysTagID = Convert.ToInt32(_Reader["AnxSeting_SysTagID"]),
                                AnxSeting_SystemTagName = Convert.ToString(_Reader["AnxSeting_SystemTagName"]),
                                AnxSeting_TagID = Convert.ToInt32(_Reader["AnxSeting_TagID"]),
                                AnxSeting_TagName = Convert.ToString(_Reader["AnxSeting_TagName"]),
                                AnxSeting_TenatID = Convert.ToInt32(_Reader["AnxSeting_TenatID"]),
                                AnxSeting_Desc = Convert.ToString(_Reader["AnxSeting_Desc"]),
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
            return _ListAnnexSetting;
        }

        public async Task<DtoAnnexSetting_> GetPath(int TenantID, string keyword)
        {
            var DtoAnnexSetting_ = new DtoAnnexSetting_();
            var _value = "";
            var _Cmd = _ContextAnnex.Database.GetDbConnection().CreateCommand();
            bool IsOpen = _Cmd.Connection.State == System.Data.ConnectionState.Open;
            if (!IsOpen) await _Cmd.Connection.OpenAsync().ConfigureAwait(false);
            _Cmd.CommandText = SPAnnex.Annex_GetPathFile.ToString();
            _Cmd.CommandType = System.Data.CommandType.StoredProcedure;
            _Cmd.Parameters.Add(new SqlParameter("Tenant_ID", TenantID));
            _Cmd.Parameters.Add(new SqlParameter("KeyWord", keyword));
            using (var _Reader = await _Cmd.ExecuteReaderAsync().ConfigureAwait(false))
            {
                if (_Reader.HasRows)
                {
                    try
                    {
                        while (await _Reader.ReadAsync().ConfigureAwait(false))
                        {
                            _value = _Reader["Path"].ToString();
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
            if (_value != "")
            {
                var _val = _value.Split("::");
                DtoAnnexSetting_.AnnexSetting_Path = _val[0];
                DtoAnnexSetting_.AnnexSetting_ID = Convert.ToInt32(_val[1]);
            }
            return DtoAnnexSetting_;
        }
    }
}
