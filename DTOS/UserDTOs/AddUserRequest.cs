using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTOS.UserDTOs
{
    public class AddUserRequest
    {
        public string Name { get; set; }

        public string Email { get; set; }

        public DateTime BirthDate { get; set; }

        public string Location { get; set; }

        public string PictureProfile { get; set; }
    }
}
