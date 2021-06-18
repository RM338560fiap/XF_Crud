using SQLite;
using System;
using System.Collections.Generic;
using System.Text;

namespace XF_Crud
{
    public class Alunos
    {
        [PrimaryKey, AutoIncrement]
        public int MatriculaId { get; set; }
        public string Nome { get; set; }

    }
}
