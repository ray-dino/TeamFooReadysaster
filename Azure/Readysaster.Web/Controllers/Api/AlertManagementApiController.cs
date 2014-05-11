   //Team Foo Readysaster 2014
 
   //This program is free software; you can redistribute it and/or modify it
   //under the terms of the GNU General Public License as published by the
   //Free Software Foundation; either version 3, or (at your option) any later
   //version.

   //This program is distributed in the hope that it will be useful, but
   //WITHOUT ANY WARRANTY; without even the implied warranty of
   //MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.  See the GNU General
   //Public License for more details.

   //You should have received a copy of the GNU General Public License along
   //with this program; if not, write to the Free Software Foundation, Inc.,
   //59 Temple Place - Suite 330, Boston, MA 02111-1307, USA. 
 

using Readysaster.DAL.EF;
using Readysaster.SharedModels.Alerts;
using Readysaster.SharedModels.Geo;
using System.Linq;
using System;
using System.Collections.Generic;
using System.Web.Http;

namespace Pre.ph.WebApi.Controllers.Api
{
    /// <summary>
    /// Manage Alerts
    /// </summary>
    public class AlertManagementApiController : ApiController
    {
        /// <summary>
        /// Alert subscription / unsubscription
        /// </summary>
        /// <returns></returns>
        private AlertConfigurationUVM getTestUvm()
        {
            return new AlertConfigurationUVM
                {
                    Id = Guid.Empty,
                    AffectedArea = "Point Area",
                    Message = "RUUUUUUUUN Zombies are coming",
                    AlertStatus = AlertStatus.NONE
                };
        }

        /// <summary>
        /// GET: api/AlertSubscriptionApi
        /// </summary>
        /// <param name="skip"></param>
        /// <param name="take"></param>
        /// <returns></returns>
        public IEnumerable<AlertConfigurationUVM> Get(int skip = 0, int take = 25)
        {
            return new[] 
                {
                    this.getTestUvm()
                };
        }

        /// <summary>
        /// GET: api/AlertSubscriptionApi/5
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public AlertConfigurationUVM Get(Guid id)
        {
            return this.getTestUvm();
        }

        /// <summary>
        /// POST: api/AlertSubscriptionApi
        /// </summary>
        /// <param name="model"></param>
        public dynamic Post([FromBody]AlertConfigurationUVM model)
        {
            if (ModelState.IsValid)
            {
                using (var dbC = new DatabaseContext())
                {
                    var allAffected = from af in dbC.AlertSubscriptions
                                      select new
                                      { 
                                           PhoneNumer = af.PhoneNumber,
                                           ClosestSchoolName = (from school in dbC.Schools orderby school.Location.Distance(af.LastKnownLocation) ascending select school).FirstOrDefault()
                                      };

                    return allAffected.ToList();

                }
            }

            return NotFound();
        }

        /// <summary>
        /// PUT: api/AlertSubscriptionApi/5
        /// </summary>
        /// <param name="model"></param>
        public void Put([FromBody]AlertConfigurationUVM model)
        {
        }

        /// <summary>
        /// DELETE: api/AlertSubscriptionApi/5
        /// </summary>
        /// <param name="id"></param>
        public void Delete(Guid id)
        {
        }
    }
}
