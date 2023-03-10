
namespace Annex.ClassDTO.DTOs
{
    public class DtoAnnexs
    {
        public Int64 Anx_ID { get; set; }
        public string Anx_FilNamePhys { get; set; }
        public string Anx_FilNameLgic { get; set; }  
        public int Anx_RefID { get; set; }
        public string Anx_RefFolderName { get; set; } 
        public string Anx_Path { get; set; } 
        public string Anx_Desc { get; set; }
        public int Anx_AnxSetingID { get; set; }
        public DateTime Anx_CreatedDate { get; set; }
        public bool Anx_IsDef { get; set; }
        public string Anx_FileExt { get; set; }
    }
}
