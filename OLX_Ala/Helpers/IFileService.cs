namespace OLX_Ala.Helpers
{
    public interface IFileService
    {
        Task<string> SaveAnnouncementImage(IFormFile file);
        Task<string> DeleteAnnouncementImage(string path);
    }
}
