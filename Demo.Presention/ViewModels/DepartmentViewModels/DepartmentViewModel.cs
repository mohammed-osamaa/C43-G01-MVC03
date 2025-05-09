﻿namespace Demo.Presention.ViewModels.DepartmentViewModels
{
    public class DepartmentViewModel
    {
        public string Name { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;
        public string Code { get; set; } = string.Empty;
        public DateOnly CreatedOn { get; set; }
    }
}
