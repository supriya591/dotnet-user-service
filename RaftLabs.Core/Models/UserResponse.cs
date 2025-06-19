using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RaftLabs.Core.Models
{
    public class UserResponse
    {
        public int Page { get; set; }
        public int Total_Pages { get; set; }
        public List<User> Data { get; set; }
    }
}
