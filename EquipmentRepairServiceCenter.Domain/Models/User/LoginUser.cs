﻿using System.ComponentModel.DataAnnotations;

namespace EquipmentRepairServiceCenter.Domain.Models.User
{
    public class LoginUser
    {
        [Required(ErrorMessage = "Not specified login")]
        public string UserName { get; set; }


        [Required(ErrorMessage = "Not specified password")]
        [DataType(DataType.Password)]
        public string Password { get; set; }
    }
}
