


namespace Annex.ClassDomain.Domains
{
    public class AnnexSetting
    {
        public AnnexSetting()
        {
            this.Annexs = new HashSet<Annexs>();
        }
        public int AnnexSetting_ID { get; set; }
        public int AnnexSetting_TenantID { get; set; }
        public int AnnexSetting_SystemTagID { get; set; }
        public int AnnexSetting_TagsknowledgeID { get; set; }
        public string AnnexSetting_KeyWord { get; set; }
        public string AnnexSetting_ReferenceComment { get; set; }
        public string AnnexSetting_Dec { get; set; }

        public virtual ICollection<Annexs> Annexs { get; set; }

    }
}
