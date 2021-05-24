using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Tarea5_DWB.DataAccess;
using Tarea5_DWB.Controllers;
using Tarea5_DWB.Modelos;

namespace Tarea5_DWB.BackEnd
{
    public class UsuarioSC : BaseSC
    {
        public IQueryable <Dato> GetUsuario()
        {
            return dbcontext.Datos.AsQueryable();
        }

        public Dato GetUsuarioByID(int id)
        {
            return GetUsuario().Where(x => x.Id == id).FirstOrDefault();
        }

        public void agregarUsuario(Dato newDato)
        {
            var nuevoDato = new Dato();
            nuevoDato.Id = newDato.Id;
            nuevoDato.Usuario = newDato.Usuario;

            string salt = EncryptSC.crearSalt(5);
            nuevoDato.Contraseña = salt + EncryptSC.GetSHA256(newDato.Contraseña);

            dbcontext.Datos.Add(nuevoDato);
            dbcontext.SaveChanges();
        }
    }   

}
