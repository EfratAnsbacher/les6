using les3.Models;
using System.Data;
using System.Net.Mail;

namespace les3.Repositories
{
    public interface IAttachmentRepository
    {
        DataTable CreateAttachment(string FileName, string FilePath, string Size, string Description);
        public bool ProcessTransaction(Attachments attachment, Tasks task);
    }
}
