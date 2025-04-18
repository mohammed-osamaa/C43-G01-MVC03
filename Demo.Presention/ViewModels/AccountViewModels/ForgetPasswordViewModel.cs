﻿using System.ComponentModel.DataAnnotations;

namespace Demo.Presention.ViewModels.AccountViewModels
{
    public class ForgetPasswordViewModel
    {
        [DataType(DataType.EmailAddress)]
        public string Email { get; set; } = null!;
    }
}
