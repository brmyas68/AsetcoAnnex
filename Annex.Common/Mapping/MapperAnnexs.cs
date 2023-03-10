

using Annex.ClassDomain.Domains;
using Annex.ClassDTO.DTOs;
using AutoMapper;

namespace Annex.Common.Mapping
{
    public class MapperAnnexs
    {
        public static IMapper MapTo()
        {
            var MappingConfig = new MapperConfiguration(c =>
            {
                c.CreateMap<Annexs, DtoAnnexs>()
                     .ForMember(DtoA => DtoA.Anx_ID, opt => opt.MapFrom(A => A.Annex_ID))
                     .ForMember(DtoA => DtoA.Anx_FilNamePhys, opt => opt.MapFrom(A => A.Annex_FileNamePhysicy))
                     .ForMember(DtoA => DtoA.Anx_FilNameLgic, opt => opt.MapFrom(A => A.Annex_FileNameLogic))
                     .ForMember(DtoA => DtoA.Anx_RefID, opt => opt.MapFrom(A => A.Annex_ReferenceID))
                     .ForMember(DtoA => DtoA.Anx_RefFolderName, opt => opt.MapFrom(A => A.Annex_ReferenceFolderName))
                     .ForMember(DtoA => DtoA.Anx_Path, opt => opt.MapFrom(A => A.Annex_Path))
                     .ForMember(DtoA => DtoA.Anx_Desc, opt => opt.MapFrom(A => A.Annex_Description))
                     .ForMember(DtoA => DtoA.Anx_CreatedDate, opt => opt.MapFrom(A => A.Annex_CreatedDate))
                     .ForMember(DtoA => DtoA.Anx_AnxSetingID, opt => opt.MapFrom(A => A.Annex_AnnexSettingID))
                     .ForMember(DtoA => DtoA.Anx_FileExt, opt => opt.MapFrom(A => A.Annex_FileExtension))
                     .ForMember(DtoA => DtoA.Anx_IsDef, opt => opt.MapFrom(A => A.Annex_IsDefault))
                     .ReverseMap();
            });
            return MappingConfig.CreateMapper();
        }
    }
}
