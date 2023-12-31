﻿using Core.Domain;
using Core.Repository;
using Core.Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service
{
    public class WorkingDateAndTimeService : BaseEntityService<WorkingDateAndTime>, IWorkingDateAndTimeService
    {
        public WorkingDateAndTimeService(IRepository<WorkingDateAndTime> repository) : base(repository)
        {
        }
    }
}
