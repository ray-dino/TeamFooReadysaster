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

using Readysaster.SharedModels.Assets;
using Readysaster.SharedModels.Geo;
using System;
using System.Collections.Generic;
using System.Web.Http;

namespace Pre.ph.WebApi.Controllers.Api
{
    /// <summary>
    /// Add / edit assets
    /// </summary>
    public class AssetApiController : ApiController
    {
        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        private AssetUVM getTestUvm()
        {
            return new AssetUVM
                {
                    Id = Guid.Empty,
                    Description = "Description text",
                    LastKnownLocation = new LocationUVM
                    {
                        Latitude = 0.1,
                        Longitude = 0.2,
                    },
                    Name = "Name"
                };
        }

        /// <summary>
        /// GET: api/AssetApi
        /// </summary>
        /// <param name="skip"></param>
        /// <param name="take"></param>
        /// <returns></returns>
        public IEnumerable<AssetUVM> Get(int skip = 0, int take = 25)
        {
            return new[] 
                {
                    this.getTestUvm()
                };
        }

        /// <summary>
        /// GET: api/AssetApi/5
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public AssetUVM Get(Guid id)
        {
            return this.getTestUvm();
        }

        /// <summary>
        /// POST: api/AssetApi
        /// </summary>
        /// <param name="model"></param>
        public void Post([FromBody]AssetUVM model)
        {
        }

        /// <summary>
        /// PUT: api/AssetApi/5
        /// </summary>
        /// <param name="model"></param>
        public void Put([FromBody]AssetUVM model)
        {
        }

        /// <summary>
        /// DELETE: api/AssetApi/5
        /// </summary>
        /// <param name="id"></param>
        public void Delete(Guid id)
        {
        }
    }
}
