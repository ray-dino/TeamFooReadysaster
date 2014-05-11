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
using Readysaster.DAL.EF.Models.Alerts;
using Readysaster.SharedModels.Alerts;
using Readysaster.SharedModels.Geo;
using System;
using System.Linq;
using System.Collections.Generic;
using System.Data.Entity.Spatial;
using System.Net.Http;
using System.Web.Http;
using System.Globalization;

namespace Pre.ph.WebApi.Controllers.Api
{
    /// <summary>
    /// Subscribe and unsubscribe from Alerts
    /// </summary>
    public class AlertSubscriptionApiController : ApiController
    {
        /// <summary>
        /// Alert subscription / unsubscription
        /// </summary>
        /// <returns></returns>
        private AlertSubscriptionUVM getTestUvm()
        {
            return new AlertSubscriptionUVM
                {
                    Id = Guid.Empty,
                    CurrentLocation = new LocationUVM
                        {
                            Latitude = 0.1,
                            Longitude = 0.2,
                        },
                    AddressString = "Ayala Avenue",
                    ValidUntil = DateTime.UtcNow.AddYears(1)
                };
        }

        /// <summary>
        /// GET: api/AlertSubscriptionApi
        /// </summary>
        /// <param name="skip"></param>
        /// <param name="take"></param>
        /// <returns></returns>
        public IEnumerable<AlertSubscriptionUVM> Get(int skip = 0, int take = 25)
        {
            using (var dbC = new DatabaseContext())
            {
                var allSubs = from als in dbC.AlertSubscriptions
                              select new AlertSubscriptionUVM
                                  {
                                      AddressString = als.AddressString,
                                      CurrentLocation = als.LastKnownLocation != null ? new LocationUVM()
                                            {
                                                Latitude = als.LastKnownLocation.Latitude,
                                                Longitude = als.LastKnownLocation.Longitude
                                            } : null,
                                      Id = als.Id,
                                      PhoneNumber = als.PhoneNumber,
                                      ValidUntil = als.ValidUntil
                                  };
                return allSubs.ToList();
            }
        }

        /// <summary>
        /// GET: api/AlertSubscriptionApi/5
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public AlertSubscriptionUVM Get(Guid id)
        {
            return this.getTestUvm();
        }

        /// <summary>
        /// POST: api/AlertSubscriptionApi
        /// </summary>
        /// <param name="model"></param>
        public IHttpActionResult Post([FromBody]AlertSubscriptionUVM model)
        {
            if (ModelState.IsValid)
            {
                using (var dbC = new DatabaseContext())
                {
                    dbC.AlertSubscriptions.Add(
                        new AlertSubscription
                        {
                            AddressString = model.AddressString,
                            LastKnownLocation = string.Format(CultureInfo.InvariantCulture, "Point({0} {1})", model.CurrentLocation.Longitude, model.CurrentLocation.Latitude),
                            PhoneNumber = model.PhoneNumber,
                            //ValidUntil = model.ValidUntil
                            ValidUntil = DateTime.UtcNow.AddYears(1)
                        }
                        );

                    dbC.SaveChanges();
                }
            }
            return null;
        }
        /// <summary>
        /// PUT: api/AlertSubscriptionApi/5
        /// </summary>
        /// <param name="model"></param>
        public void Put([FromBody]AlertSubscriptionUVM model)
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
