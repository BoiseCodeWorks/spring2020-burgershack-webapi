using System;
using System.Collections.Generic;
using System.Linq;
using burgershack.DB;
using burgershack.Models;
using Microsoft.AspNetCore.Mvc;

namespace burgershack.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class SidesController : ControllerBase
    {
        [HttpGet]
        public ActionResult<IEnumerable<Side>> Get()
        {
            try
            {
                return Ok(FakeDB.sides);
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        [HttpGet("sizes/{size}")]
        public ActionResult<IEnumerable<Side>> GetBySize(string size)
        {
            try
            {
                if (Enum.TryParse<Size>(size, out Size filterSize))
                {
                    return Ok(FakeDB.sides.Where(s => s.Size == filterSize));
                }
                throw new Exception("Invalid size");
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        [HttpGet("{id}")]
        public ActionResult<Side> Get(string id)
        {
            try
            {
                Side found = FakeDB.sides.Find(s => s.Id == id);
                if (found == null)
                {
                    throw new Exception("Invalid Id");
                }
                return Ok(found);
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        [HttpPost]
        public ActionResult<Side> Create([FromBody] Side newSide)
        {
            try
            {
                FakeDB.sides.Add(newSide);
                return Created($"api/sides/{newSide.Id}", newSide);
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        [HttpPut("{id}")]
        public ActionResult<Side> Edit(string id, [FromBody] Side updatedSide)
        {
            try
            {
                Side sideToUpdate = FakeDB.sides.Find(s => s.Id == id);
                if (sideToUpdate == null)
                {
                    throw new Exception("Invalid Id");
                }
                sideToUpdate.Name = updatedSide.Name;
                sideToUpdate.Description = updatedSide.Description;
                sideToUpdate.Price = updatedSide.Price;
                sideToUpdate.Size = updatedSide.Size;
                return Ok(sideToUpdate);
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }


        [HttpDelete("{id}")]
        public ActionResult<String> Delete(string id)
        {
            try
            {
                Side sideToDelete = FakeDB.sides.Find(s => s.Id == id);
                if (sideToDelete == null)
                {
                    throw new Exception("Invalid Id");
                }
                FakeDB.sides.Remove(sideToDelete);
                return Ok("Successfully Deleted");
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }
    }
}