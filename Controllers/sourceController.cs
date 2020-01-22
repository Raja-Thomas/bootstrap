using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace bootstrap.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class sourceController : ControllerBase
    {
        public IActionResult GetCategories()
        {
            try
            {
                var categories = "1234";
                if (categories == null)
                {
                    return NotFound();
                }

                return Ok(categories);
            }
            catch (Exception)
            {
                return BadRequest();
            }

        }
    }
}