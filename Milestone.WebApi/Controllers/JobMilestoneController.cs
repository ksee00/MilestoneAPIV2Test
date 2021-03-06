﻿using Milestone.Dapper.Entities;
using Milestone.Dapper.IRepository;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Milestone.WebApi.Controllers
{

    [Route("api/[controller]/[action]")]
    public class JobMilestoneController : Controller
    {
        private readonly IJobMilestoneRespository jobMilestoneRepository;
        //Milestone.Dapper.IRepository.
        public JobMilestoneController(IJobMilestoneRespository _jobMilestoneRepository)
        {
            jobMilestoneRepository = _jobMilestoneRepository;
        }

        /// <summary>
        /// Get all inbound jobs
        /// </summary>
        /// <returns></returns>
        /// 
        [HttpGet]
        public async Task<JsonResult> GetInbundJobs(string id)
        {
            List<JobMilestone> list = await jobMilestoneRepository.GetInbundJobs(id);



            return Json(list);
        }

        /// <summary>
        /// Get Inbound Job Detail
        /// </summary>
        [HttpGet]
        public async Task<JsonResult> GetOutbundJobs(string Id)
        {
            List<JobMilestone> list = await jobMilestoneRepository.GetOutbundJobs(Id);
            return Json(list);
        }


        /// <summary>
        /// Get Pickup Job Detail
        /// </summary>
        [HttpGet]
        public async Task<JsonResult> GetPickupJobs(string Id)
        {
            List<JobMilestone> list = await jobMilestoneRepository.GetPickupJobs(Id);
            return Json(list);
        }

        /// <summary>
        /// Complete inbound job task and record complete date time
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
        [HttpPost]
        public async Task CompleteInboundTask([FromBody]JobMilestone data)
        {
            try
            {
                await jobMilestoneRepository.CompleteInboundTask(data.Id, data.mile_date);
            }
            catch (Exception ex)
            {
                throw new ArgumentException(ex.Message);
            }
        }

        /// <summary>
        /// Complete outbound job task, record cont_no and record complete date time
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
        [HttpPost]
        public async Task CompleteOutboundTask([FromBody]JobMilestone data)
        {
            try
            {
                await jobMilestoneRepository.CompleteOutboundTask(data.Id, data.veh_no, data.cont_no, data.mile_date);
            }
            catch (Exception ex)
            {
                throw new ArgumentException(ex.Message);
            }
        }

    }
}