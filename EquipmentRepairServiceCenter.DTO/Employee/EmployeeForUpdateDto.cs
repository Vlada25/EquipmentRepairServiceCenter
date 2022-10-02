﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EquipmentRepairServiceCenter.DTO.Employee
{
    public class EmployeeForUpdateDto
    {
        public Guid Id { get; set; }
        public string Surname { get; set; }
        public string Name { get; set; }
        public string MiddleName { get; set; }
        public string Position { get; set; }
        public int WorkExperienceInYears { get; set; }
    }
}
