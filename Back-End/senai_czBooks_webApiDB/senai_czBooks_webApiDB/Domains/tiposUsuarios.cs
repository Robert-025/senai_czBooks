using System;
using System.Collections.Generic;

#nullable disable

namespace senai_czBooks_webApiDB.Domains
{
    public partial class tiposUsuarios
    {
        public tiposUsuarios()
        {
            usuarios = new HashSet<usuarios>();
        }

        public int idTipoUsuario { get; set; }
        public string tipo { get; set; }

        public virtual ICollection<usuarios> usuarios { get; set; }
    }
}
