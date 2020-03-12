using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace testy_identity.Models
{
    public class Group
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public bool IsCustom { get; set; }
        public ICollection<UserGroup> UserGroups { get; set; }
    }
}
