﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VoteApp.Application.Models.PollStopNotification;

namespace VoteApp.Application.Interfaces.Services
{
    public interface IPollStopNotificationService
    {
        public void Notify(PollStopNotificationMessage message);
    }
}