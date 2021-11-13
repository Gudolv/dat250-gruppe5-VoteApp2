﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VoteApp.Domain.Entities.Vote;

namespace VoteApp.Application.Models.PollStopNotification
{
    public class PollStopNotificationMessage
    {
        public string QuestionTitle { get; set; }
        public string Question { get; set; }
        public string QuestionId { get; set; }
        public string GreenAnswer { get; set; }
        public string RedAnswer { get; set; }
        public VoteCount VoteCount { get; set; }
        public DateTime StartTime { get; set; }
        public DateTime StopTime { get; set; }

    }
}
