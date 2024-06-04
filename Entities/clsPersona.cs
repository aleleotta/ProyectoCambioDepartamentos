using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities
{
    public class clsPersona
    {
        #region Attributes
        private int id;
        private string nombre = "";
        private string apellidos = "";
        private int idDept;
        #endregion

        #region Properties
        public int Id { get => id; }
        public string Nombre { get => nombre; }
        public string Apellidos { get => apellidos; }
        public int IdDept
        {
            get => idDept;
            set => idDept = value;
        }
        #endregion

        #region Constructors
        public clsPersona() { }
        public clsPersona(int id, string nombre, string apellidos, int idDept)
        {
            this.id = id;
            this.nombre = nombre;
            this.apellidos = apellidos;
            this.idDept = idDept;
        }
        public clsPersona(clsPersona persona)
        {
            id = persona.Id;
            nombre = persona.Nombre;
            apellidos = persona.apellidos;
            idDept = persona.idDept;
        }
        #endregion
    }
}