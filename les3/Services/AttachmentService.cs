using les3.Models;
using les3.Repositories;
using System.Data;

namespace les3.Services
{
    public class AttachmentService:IAttachmentService
    {
        private readonly IAttachmentRepository _attachmentRepository;

        public AttachmentService(IAttachmentRepository attachmentRepository)
        {
            _attachmentRepository = attachmentRepository;
        }
       

        public DataTable CreateAttachment(string FileName, string FilePath, string Size, string Description)
        {
            return _attachmentRepository.CreateAttachment(FileName, FilePath, Size, Description);
        }

        public bool Create(AttachmentWithTask model)
        {
            return _attachmentRepository.ProcessTransaction(model.attachment, model.task);
        }
    }
}
