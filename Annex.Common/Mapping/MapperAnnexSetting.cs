
using Annex.ClassDomain.Domains;
using Annex.ClassDTO.DTOs;
using AutoMapper;

namespace Annex.Common.Mapping
{
    public class MapperAnnexSetting
    {
        public static IMapper MapTo()
        {

            var MappingConfig = new MapperConfiguration(c =>
            {

                c.CreateMap<AnnexSetting, DtoAnnexSetting>()
                     .ForMember(DtoAS => DtoAS.AnxSeting_ID, opt => opt.MapFrom(AS => AS.AnnexSetting_ID))
                     .ForMember(DtoAS => DtoAS.AnxSeting_TenatID, opt => opt.MapFrom(AS => AS.AnnexSetting_TenantID))
                     .ForMember(DtoAS => DtoAS.AnxSeting_SysTagID, opt => opt.MapFrom(AS => AS.AnnexSetting_SystemTagID))
                     .ForMember(DtoAS => DtoAS.AnxSeting_KeyWord, opt => opt.MapFrom(AS => AS.AnnexSetting_KeyWord))
                     .ForMember(DtoAS => DtoAS.AnxSeting_RefComent, opt => opt.MapFrom(AS => AS.AnnexSetting_ReferenceComment))
                     .ForMember(DtoAS => DtoAS.AnxSeting_Desc, opt => opt.MapFrom(AS => AS.AnnexSetting_Dec))
                     .ForMember(DtoAS => DtoAS.AnxSeting_TagID, opt => opt.MapFrom(AS => AS.AnnexSetting_TagsknowledgeID))
                     .ReverseMap();
            });

            return MappingConfig.CreateMapper();
        }
    }
}
