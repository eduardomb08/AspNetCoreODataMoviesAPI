// Copyright (c) Microsoft Corporation.  All rights reserved.
// Licensed under the MIT License.  See License.txt in the project root for license information.

using AspNetCoreODataMoviesAPI.Models;
using Microsoft.AspNet.OData;
using Microsoft.AspNetCore.Mvc;
using System.Linq;

namespace AspNetCoreODataMoviesAPI.Controllers
{
    public class MoviesController : ODataController
    {
        private readonly MovieContext _context;

        public MoviesController(MovieContext context)
        {
            _context = context;
        }

        [EnableQuery]
        public IActionResult Get()
        {
            return Ok(_context.Movies.Select(m => new MovieDTO() {MovieID = m.ID, MovieTitle = m.Title}));
        }

        [EnableQuery]
        public IActionResult Get(int key)
        {
            Movie m = _context.Movies.FirstOrDefault(c => c.ID == key);

            if (m == null)
            {
                return NotFound();
            }

            return Ok(m);
        }
    }
}
