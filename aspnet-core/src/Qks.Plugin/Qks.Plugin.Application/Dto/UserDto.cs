using System;
using System.Collections.Generic;
using System.Text;
using Qks.Plugin.Core;
using System.ComponentModel.DataAnnotations;

namespace Qks.Plugin.Application
{
    public class UserDto
    {
        public int Id { get; set; }

        [Required]
        public string Name { get; set; }

        [Range(10, 150)]
        public int Age { get; set; }

        [Required]
        public string Gender { get; set; }
    }
}
