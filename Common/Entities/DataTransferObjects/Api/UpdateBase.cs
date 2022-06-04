using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Common.Entities.DataTransferObjects.Api
{
    public class UpdateBase
    {
        [Required(ErrorMessage = "ID không được để trống")]
        public string Id { set; get; } // Id

        public UpdateBase()
        {
            Id = Guid.NewGuid().ToString();
        }
    }
}
