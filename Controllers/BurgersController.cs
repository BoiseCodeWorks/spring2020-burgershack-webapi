using System;
using System.Collections.Generic;
using burgershack.DB;
using burgershack.Models;
using Microsoft.AspNetCore.Mvc;


namespace burgershack.Controllers
{

    [ApiController]
    [Route("api/[controller]")] // localhost:5000/api/burgers
    public class BurgersController : ControllerBase
    {

        [HttpGet]
        public ActionResult<IEnumerable<Burger>> Get()
        {
            try
            {
                return Ok(FakeDB.burgers);
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        [HttpGet("{burgerId}")]  // /:id
        public ActionResult<Burger> Get(string burgerId)
        {
            try
            {
                Burger found = FakeDB.burgers.Find(b => b.Id == burgerId);
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


        [HttpPost] // method: POST, route: 'api/burgers' 
        // NOTE [FromBody] is used instead of req.body to create the datatype listed (in this case Burger)
        public ActionResult<Burger> Create([FromBody] Burger newBurger)
        {
            try
            {
                FakeDB.burgers.Add(newBurger);
                // NOTE Created is a 201 and requires you pass the "uri" or where the new object can be found
                return Created($"api/burger/{newBurger.Id}", newBurger);
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }


        // NOTE this route handles all properties to edit, 
        // you could alternately make multiple put routes to edit each property one at a time
        [HttpPut("{id}")]
        public ActionResult<Burger> Edit(string id, [FromBody] Burger updatedBurger)
        {
            try
            {
                Burger burgerToUpdate = FakeDB.burgers.Find(b => b.Id == id);
                if (burgerToUpdate == null)
                {
                    throw new Exception();
                }
                burgerToUpdate.Name = updatedBurger.Name;
                burgerToUpdate.Description = updatedBurger.Description;
                burgerToUpdate.Price = updatedBurger.Price;
                return Ok(burgerToUpdate);
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }


        [HttpDelete("{id}")]
        public ActionResult<string> Delete(string id)
        {
            try
            {
                Burger burgerToRemove = FakeDB.burgers.Find(b => b.Id == id);
                if (burgerToRemove == null)
                {
                    throw new Exception("bad Id");
                }
                FakeDB.burgers.Remove(burgerToRemove);
                return Ok("Successfully Removed");

            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }

    }
}
