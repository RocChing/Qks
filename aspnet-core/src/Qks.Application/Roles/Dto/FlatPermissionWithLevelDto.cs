using System;
using System.Collections.Generic;
using System.Text;

namespace Qks.Roles.Dto
{
    public class FlatPermissionWithLevelDto : FlatPermissionDto
    {
        public string ParentName { get; set; }

        //public bool IsGrantedByDefault { get; set; }

        //public int Level { get; set; }

        public List<FlatPermissionWithLevelDto> Children { get; set; }

        public bool Expand { get { return Children != null && Children.Count > 0; } }

        public bool Selected { get; set; }
    }
}
