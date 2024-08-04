﻿using EducationPortal.Domain.Entities.Common;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EducationPortal.Application.Repositories
{
    public interface IRepository<T> where T :class
    {
       DbSet<T>Table {  get; }
    }
}