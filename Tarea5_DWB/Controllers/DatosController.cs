using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Tarea5_DWB.DataAccess;
using Tarea5_DWB.BackEnd;
// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Tarea5_DWB.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DatosController : ControllerBase
    {
        UsuariosContext dbcontext = new UsuariosContext(); 

        // GET: api/<DatosController>
        [HttpGet]
        public  List<Dato> Get()
        {
            var usuarios = new UsuarioSC().GetUsuario().ToList();
            return usuarios;
        }

        // GET api/<DatosController>/5
        [HttpGet("{id}")]
        public Dato Get(int id)
        {
            return new UsuarioSC().GetUsuarioByID(id);
        }

        // POST api/<DatosController>
        [HttpPost]
        public void Post([FromBody] Dato datos)
        {
            new UsuarioSC().agregarUsuario(datos);
      
        }

        // PUT api/<DatosController>/5
        [HttpPut("{id}")]
        public ActionResult Put(int id, [FromBody] Dato datos)
        {
            if(datos.Id == id)
            {
                dbcontext.Entry(datos).State=EntityState.Modified;
                dbcontext.SaveChanges();
                return Ok();
            }
            else
            {
                return BadRequest();
            }
        }

        // DELETE api/<DatosController>/5
        [HttpDelete("{id}")]
        public ActionResult Delete(int id)
        {
            var datos = dbcontext.Datos.FirstOrDefault(p=>p.Id==id);
 
            if(datos!=null)
            {
                
                dbcontext.Datos.Remove(datos);
                dbcontext.SaveChanges();
                return Ok();
            }
            else
            {
                return BadRequest();
            }
        }
    }
}
