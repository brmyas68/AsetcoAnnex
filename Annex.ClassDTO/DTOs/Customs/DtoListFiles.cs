
namespace Annex.ClassDTO.DTOs.Customs
{
    public class DtoListFiles
    {
        public Stream FileStream { get; set; }
        public string FileNamePhysic { get; set; }
        public string FileNameLogic { get; set; }
        public string ExtensionName { get; set; }
        public string FileDesc { get; set; }
        public bool IsDefault { get; set; }
    }
}
