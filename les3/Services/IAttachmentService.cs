using les3.Models;
using System.Data;

namespace les3.Services
{
    public interface IAttachmentService
    {
        DataTable CreateAttachment(string FileName, string FilePath, string Size, string Description);
        bool Create(AttachmentWithTask model);
    }
}
