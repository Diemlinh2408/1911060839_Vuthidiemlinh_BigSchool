using System;
using Microsoft.AspNet.Identity;
using _1911060839_Vuthidiemlinh_BigSchool.Models;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using Microsoft.Azure.Documents;
using System.Web.Helpers;
using _1911060839_Vuthidiemlinh_BigSchool.DTOs;

namespace _1911060839_Vuthidiemlinh_BigSchool.Controllers
{
    [Authorize]
    public class AttendancesController : ApiController
    {
        private ApplicationDbContext _dbContext;
        public AttendancesController()
        {
            _dbContext = new ApplicationDbContext();
        }

        [HttpPost]
        public IHttpActionResult Attend(AttendanceDto atttendanceDto)
        {
            var userId =User.Identity.GetUserId();
            if (_dbContext.Attendances.Any(a => a.AttendeeId == userId && a.CourseId == atttendanceDto.CourseId))
                return BadRequest("The Attendance already exists!");
            var attendance = new Attendance
            {
                CourseId = atttendanceDto.CourseId,
                AttendeeId =userId


            };

            _dbContext.Attendances.Add(attendance);
            _dbContext.SaveChanges();

            return Ok();

        }

        
    }
}
