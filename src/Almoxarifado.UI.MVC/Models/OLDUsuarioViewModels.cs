//using System;
//using System.Collections.Generic;
//using System.ComponentModel.DataAnnotations;
//using System.Configuration;
//using System.Data;
//using System.Data.Entity;
//using System.Data.SqlClient;
//using System.Security.Claims;
//using System.Threading.Tasks;
//using Microsoft.AspNet.Identity;
//using Microsoft.AspNet.Identity.EntityFramework;

//namespace Almoxarifado.UI.MVC.Models
//{
//   public class UsuarioModel
//    {
//        public Guid idUsuario { get; set; }

//        public string nomeUsuario { get; set; }
//        public string loginUsuario { get; set; }
//        public string senhaUsuario { get; set; }
//        public bool flAtivo { get; set; }

//        public static UsuarioModel ValidarUsuario(string login, string senha)
//        {
//            UsuarioModel ret = null;

//            using (var conexao = new SqlConnection())
//            {
//                conexao.ConnectionString = "Data Source=(localdb)\\MSSQLLocalDB;Initial Catalog=AlmoxarifadoDb";
//                conexao.Open();
//                using (var comando = new SqlCommand())
//                {
//                    comando.Connection = conexao;
//                    comando.CommandText = string.Format(
//                        "select * from usuarios where loginUsuario='{0}' and senhaUsuario='{1}'", login, senha);
//                    var reader = comando.ExecuteReader();
//                    if (reader.Read())
//                    {
//                        ret = new UsuarioModel
//                        {
//                            Id = (Guid)reader["idUsuario"],
//                            Login = (string)reader["loginUsuario"],
//                            Nome = (string)reader["nomeUsuario"],
//                            Senha = (string)reader["senhaUsuario"]

//                        };
//                    }
//                }
//            }

//            return ret;
//        }

//        public static List<UsuarioModel> RecuperarLista() //Listar Usuarios
//        {
//            var ret = new List<UsuarioModel>();

//            using (var conexao = new SqlConnection())
//            {
//                conexao.ConnectionString = ConfigurationManager.ConnectionStrings["AlmoxarifadoConnectionString"].ConnectionString;
//                conexao.Open();
//                using (var comando = new SqlCommand())
//                {
//                    comando.Connection = conexao;
//                    comando.CommandText = "select * from usuarios order by nomeUsuario";
//                    var reader = comando.ExecuteReader();
//                    while (reader.Read())
//                    {
//                        ret.Add(new UsuarioModel
//                        {
//                            Id = (Guid)reader["idUsuario"],
//                            Login = (string)reader["loginUsuario"],
//                            Nome = (string)reader["nomeUsuario"]
//                        });
//                    }
//                }
//            }

//            return ret;
//        }

//        public static UsuarioModel RecuperarPeloId(Guid id)
//        {
//            UsuarioModel ret = null;

//            using (var conexao = new SqlConnection())
//            {
//                conexao.ConnectionString = ConfigurationManager.ConnectionStrings["AlmoxarifadoConnectionString"].ConnectionString;
//                conexao.Open();
//                using (var comando = new SqlCommand())
//                {
//                    comando.Connection = conexao;
//                    comando.CommandText = "select * from usuarios where (idUsuario = @idUsuario)";

//                    comando.Parameters.Add("@idUsuario", SqlDbType.Int).Value = id;

//                    var reader = comando.ExecuteReader();
//                    if (reader.Read())
//                    {
//                        ret = new UsuarioModel
//                        {
//                            Id = (Guid)reader["idUsuario"],
//                            Login = (string)reader["loginUsuario"],
//                            Nome = (string)reader["nomeUsuario"]
//                        };
//                    }
//                }
//            }

//            return ret;
//        }

//        public static bool ExcluirPeloId(Guid id)
//        {
//            var ret = false;

//            if (RecuperarPeloId(id) != null)
//            {
//                using (var conexao = new SqlConnection())
//                {
//                    conexao.ConnectionString = ConfigurationManager.ConnectionStrings["AlmoxarifadoConnectionString"].ConnectionString;
//                    conexao.Open();
//                    using (var comando = new SqlCommand())
//                    {
//                        comando.Connection = conexao;
//                        comando.CommandText = "delete from usuarios where (idUsuario = @idUsuario)";

//                        comando.Parameters.Add("@idUsuario", SqlDbType.Int).Value = id;

//                        ret = (comando.ExecuteNonQuery() > 0);
//                    }
//                }
//            }

//            return ret;
//        }

//        public int Salvar()
//        {
//            var ret = 0;

//            var model = RecuperarPeloId(this.Id);

//            using (var conexao = new SqlConnection())
//            {
//                conexao.ConnectionString = ConfigurationManager.ConnectionStrings["AlmoxarifadoConnectionString"].ConnectionString;
//                conexao.Open();
//                using (var comando = new SqlCommand())
//                {
//                    comando.Connection = conexao;

//                    if (model == null)
//                    {
//                        comando.CommandText = "insert into usuarios (nomeUsuario, loginUsuario, senhaUsuario) values (@nomeUsuario, @loginUsuario, @senhaUsuario); select convert(int, scope_identity())";

//                        comando.Parameters.Add("@nomeUsuario", SqlDbType.VarChar).Value = this.Nome;
//                        comando.Parameters.Add("@loginUsuario", SqlDbType.VarChar).Value = this.Login;
//                        comando.Parameters.Add("@senhaUsuario", SqlDbType.VarChar).Value = CriptoHelper.HashMD5(this.Senha);

//                        ret = (int)comando.ExecuteScalar();
//                    }
//                    else
//                    {
//                        comando.CommandText =
//                            "update usuarios set nomeUsuario=@nomeUsuario, loginUsuario=@loginUsuario" +
//                            (!string.IsNullOrEmpty(this.Senha) ? ", senhaUsuario=@senhaUsuario" : "") +
//                            " where idUsuario = @idUsuario";

//                        comando.Parameters.Add("@nomeUsuario", SqlDbType.VarChar).Value = this.Nome;
//                        comando.Parameters.Add("@loginUsuario", SqlDbType.VarChar).Value = this.Login;

//                        if (!string.IsNullOrEmpty(this.Senha))
//                        {
//                            comando.Parameters.Add("@senhaUsuario", SqlDbType.VarChar).Value = CriptoHelper.HashMD5(this.Senha);
//                        }

//                        comando.Parameters.Add("@idUsuario", SqlDbType.Int).Value = this.Id;

//                        if (comando.ExecuteNonQuery() > 0)
//                        {
//                            //ret = this.Id;
//                        }
//                    }
//                }
//            }

//            return ret;
//        }
//    }



//}
    

