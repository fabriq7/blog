using System;

namespace Application.DTO.Request
{
    public class CommentDTO
    {
        public string Text { get; set; }    
        public Guid PostId { get; set; }    
    }
}
