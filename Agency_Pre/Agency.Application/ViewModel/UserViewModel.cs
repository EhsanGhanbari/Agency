using System.Collections.Generic;
using Agency.Application.Annotations;
using Agency.Application.Model;

namespace Agency.Application.ViewModel
{
    public class UserViewModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public string Address { get; set; }
        public bool IsDeleted { get; set; }

        public ResponseMessage ResponseMessage;
        public PagingViewModel PagingViewModel { get; set; }

      
        
    }
}
