

namespace Annex.ClassDomain.Domains
{
    public class Annexs
    {
        public Int64 Annex_ID { get; set; }

        public string Annex_FileNamePhysicy { get; set; }
        public string Annex_FileNameLogic { get; set; }
        public int Annex_ReferenceID { get; set; }
        public string Annex_ReferenceFolderName { get; set; }
        public string Annex_Path { get; set; }
        public string Annex_Description { get; set; }
        public int Annex_AnnexSettingID { get; set; }
        public DateTime Annex_CreatedDate { get; set; }
        public bool Annex_IsDefault { get; set; }
        public string Annex_FileExtension { get; set; }

        public virtual AnnexSetting AnnexSetting { get; set; }
    }
}

