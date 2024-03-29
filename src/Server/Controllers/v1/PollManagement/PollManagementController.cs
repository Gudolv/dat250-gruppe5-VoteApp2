﻿using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using VoteApp.Application.Features.PollQuestions.Commands.Add;
using VoteApp.Application.Features.PollQuestions.Queries.GetAll;
using VoteApp.Application.Features.Polls.Commands.Add;
using VoteApp.Application.Features.Polls.Commands.Stop;
using VoteApp.Application.Features.Polls.Queries.GetAllPollsByQuestionId;
using VoteApp.Application.Features.Polls.Queries.GetById;


namespace VoteApp.Server.Controllers.v1.Vote
{
    public class PollManagementController : BaseApiController<PollManagementController>
    {



        [Authorize]
        [HttpGet]
        [Route("poll-questions")]
        public async Task<IActionResult> GetAllPollQuestions()
        {
            var pollQuestions = await _mediator.Send(new GetAllPollQuestionsQuery());
            return Ok(pollQuestions);
        }

        [Authorize]
        [HttpGet]
        [Route("poll-questions/{id}/polls")]
        public async Task<IActionResult> GetPollsFromPollQuesitonId([FromRoute] int id)
        {
            var polls = await _mediator.Send(new GetPollsByQuestionIdQuery() { PollQuestionId = id });
            return Ok(polls);
        }

        [Authorize]
        [HttpPost]
        [Route("poll-questions")]
        public async Task<IActionResult> Post(AddPollQuestionCommand command)
        {
            return Ok(await _mediator.Send(command));
        }

        [Authorize]
        [HttpPost]
        [Route("polls")]
        public async Task<IActionResult> CreatePoll([FromBody]AddPollCommand command)
        {
            return Ok(await _mediator.Send(command));
        }

        [Authorize]
        [HttpGet]
        [Route("polls/{id}")]
        public async Task<IActionResult> GetPollById([FromRoute] int id)
        {
            var query = new GetPollByIdQuery()
            {
                Id = id
            };
            return Ok(await _mediator.Send(query));
        }

        [Authorize]
        [HttpPost]
        [Route("polls/{id}/stop")]
        public async Task<IActionResult> StopPoll([FromRoute] int id)
        {
            var command = new StopPollCommand(id);
            return Ok(await _mediator.Send(command));
        }


    }
}
