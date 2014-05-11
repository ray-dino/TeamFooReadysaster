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
using Readysaster.SharedModels.Buildings;
using Readysaster.SharedModels.Geo;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Data.Entity;
using System.Threading.Tasks;
using System.Web.Http;
using System.Data.Entity.Spatial;

namespace Pre.ph.WebApi.Controllers.Api
{
    /// <summary>
    /// Add / edit schools
    /// </summary>
    public class SchoolApiController : ApiController
    {
        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        private SchoolUVM getTestUvm()
        {
            return new SchoolUVM 
                {
                    Id = Guid.Empty,
                    Name = "School 1",
                    Location = new LocationUVM
                    {
                        Latitude = 0.1,
                        Longitude = 0.2,
                    },
                };
        }

        /// <summary>
        /// GET: api/SchoolApi
        /// </summary>
        /// <param name="skip"></param>
        /// <param name="take"></param>
        /// <returns></returns>
        public async Task<IEnumerable<SchoolUVM>> Get(int skip = 0, int take = 25)
        {
            using (var dbC = new DatabaseContext())
            {
                var allSchoolsQ = from school in dbC.Schools
                                 select new SchoolUVM
                                     {
                                         Id = school.Id,
                                         Location = school.Location == null ? null : new LocationUVM 
                                            { 
                                                Latitude = school.Location.Latitude, 
                                                Longitude = school.Location.Longitude 
                                            },
                                         Name = school.Name
                                     };

                allSchoolsQ = allSchoolsQ.OrderBy(r => r.Name);
                allSchoolsQ = allSchoolsQ.Skip(skip);
                allSchoolsQ = allSchoolsQ.Take(take);


                return await allSchoolsQ.ToListAsync();
            }
        }

        /// <summary>
        /// GET: api/SchoolApi/Closest
        /// </summary>
        /// <param name="latitude"></param>
        /// <param name="longitude"></param>
        /// <returns></returns>
        public ICollection<SchoolUVM> GetClosest(double latitude, double longitude)
        {
            using (var dbC = new DatabaseContext())
            {
                var pos = DbGeography.FromText(string.Format("POINT({0} {1})", longitude, latitude));
                var school = from s in dbC.Schools 
                             orderby s.Location.Distance(pos) ascending
                             select new SchoolUVM
                             {
                                 Id = s.Id,
                                 Location = s.Location == null ? null : new LocationUVM
                                 {
                                     Latitude = s.Location.Latitude,
                                     Longitude = s.Location.Longitude
                                 },
                                 Name = s.Name
                             };
                return school.Take(5).ToList();

            }
        }

        /// <summary>
        /// GET: api/SchoolApi/5
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public SchoolUVM Get(Guid id)
        {
            return this.getTestUvm();
        }

        /// <summary>
        /// POST: api/SchoolApi
        /// </summary>
        /// <param name="model"></param>
        public void Post([FromBody]SchoolUVM model)
        {
        }

        /// <summary>
        /// PUT: api/SchoolApi/5
        /// </summary>
        /// <param name="model"></param>
        public void Put([FromBody]SchoolUVM model)
        {
        }

        /// <summary>
        /// DELETE: api/SchoolApi/5
        /// </summary>
        /// <param name="id"></param>
        public void Delete(Guid id)
        {
        }
    }
}
