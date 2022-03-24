using SistemaLogin2.Util;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Data;
using System.Linq;
using System.Threading.Tasks;

namespace SistemaLogin2.Models
{
    public class UserModel
    {
  
        public int Id { get; set; }
        [Required(ErrorMessage = "Preencha corretamente o nome")]
        public string Nome { get; set; }
        [Required(ErrorMessage = "Preencha corretamente o email")]
        public string Email { get; set; }
        [Required(ErrorMessage = "Preencha a senha")]
        public string Senha { get; set; }
        [Required(ErrorMessage = "Preencha a data de nascimento")]
        public string Data_Nasc { get; set; }
       

        public bool ValidarLogin()
        {
            string sql = "SELECT ID, NOME, DATA_NASC FROM USUARIO WHERE EMAIL='"+Email+"' AND SENHA='"+Senha+"'"; ;
            DAL obj = new DAL();
            DataTable dt = obj.dql(sql);
            if(dt!= null)
            {
                if (dt.Rows.Count == 1)
                {
                    Id = int.Parse(dt.Rows[0]["ID"].ToString());
                    Nome = dt.Rows[0]["NOME"].ToString();
                    Data_Nasc = dt.Rows[0]["DATA_NASC"].ToString();
                    return true;
                }
            }
            return false;       
        
        }
        public void RegistrarUsuario()
        {
            string dataNascimento = DateTime.Parse(Data_Nasc).ToString("yyyy/MM/dd");
            string sql = string.Format(@"insert into usuario(nome, email, senha, data_nasc) values('{0}','{1}','{2}','{3}');", Nome, Email, Senha, Data_Nasc);
            DAL obj = new DAL();
            obj.dml(sql);


        }

    }
}
