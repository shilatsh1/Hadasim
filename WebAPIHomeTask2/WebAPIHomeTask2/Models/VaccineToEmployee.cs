﻿// <auto-generated> This file has been auto generated by EF Core Power Tools. </auto-generated>
#nullable disable
using System;
using System.Collections.Generic;

namespace WebAPIHomeTask2.Models
{
    public partial class VaccineToEmployee
    {
        public DateTime DateOfReceivingVaccine { get; set; }
        public int CoronaVaccineId { get; set; }
        public string EmployeeId { get; set; }

        public virtual CoronaVaccine CoronaVaccine { get; set; }
        public virtual Employee Employee { get; set; }
    }
}