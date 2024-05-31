using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities
{
    public class clsDepartamento
    {
        #region Attributes
        private int id;
        private string nombreDept = "";
        #endregion

        #region Properties
        public int Id { get => id; }
        public string NombreDept { get => nombreDept; }
        #endregion

        #region Constructors
        public clsDepartamento() { }
        public clsDepartamento(int id, string nombreDept)
        {
            this.id = id;
            this.nombreDept = nombreDept;
        }
        public clsDepartamento(clsDepartamento dept)
        {
            id = dept.Id;
            nombreDept = dept.NombreDept;
        }
        #endregion
    }
}
