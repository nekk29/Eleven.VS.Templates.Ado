using System;
using System.Data;
using System.Data.Common;
using Microsoft.Practices.EnterpriseLibrary.Data;
using Company.Module.Data.Core;
using Company.Module.Domain.Core.Entities;

namespace Company.Module.Data.MainModule
{
    public partial class UsuarioDataAccess
    {
        private static DatabaseProviderFactory oDatabaseProviderFactory = new DatabaseProviderFactory();
        private Database oDatabase = oDatabaseProviderFactory.Create(Conexion.cnConexion);
        
        //*********************** FUNCION PARA REGISTRO DE USUARIO ***********************//
        public Usuario Registrar_Usuario(Usuario usuario)
        {
            DbCommand oDbCommand = oDatabase.GetStoredProcCommand(Procedimiento.USP_INS_USUARIO);
            
            oDatabase.AddOutParameter(oDbCommand, "@IdUsuario", DbType.Int32, usuario.IdUsuario);
            oDatabase.AddInParameter(oDbCommand, "@UserName", DbType.String, usuario.UserName);
            oDatabase.AddInParameter(oDbCommand, "@Password", DbType.String, usuario.Password);
            oDatabase.AddInParameter(oDbCommand, "@CreationUser", DbType.String, usuario.CreationUser);
            oDatabase.AddInParameter(oDbCommand, "@CreationDate", DbType.DateTime, usuario.CreationDate);
            oDatabase.AddInParameter(oDbCommand, "@UpdateUser", DbType.String, usuario.UpdateUser);
            oDatabase.AddInParameter(oDbCommand, "@UpdateDate", DbType.DateTime, usuario.UpdateDate);
            oDatabase.AddInParameter(oDbCommand, "@Active", DbType.Boolean, usuario.Active);
            
            oDatabase.ExecuteNonQuery(oDbCommand);
            
            usuario.IdUsuario = DataUtil.DbValueToDefault<int>(oDatabase.GetParameterValue(oDbCommand, "@IdUsuario"));
            
            return usuario;
        }
        
        //******************** FUNCION PARA ACTUALIZACION DE USUARIO *********************//
        public Usuario Actualizar_Usuario(Usuario usuario)
        {
            DbCommand oDbCommand = oDatabase.GetStoredProcCommand(Procedimiento.USP_UPD_USUARIO);
            
            oDatabase.AddInParameter(oDbCommand, "@IdUsuario", DbType.Int32, usuario.IdUsuario);
            oDatabase.AddInParameter(oDbCommand, "@UserName", DbType.String, usuario.UserName);
            oDatabase.AddInParameter(oDbCommand, "@Password", DbType.String, usuario.Password);
            oDatabase.AddInParameter(oDbCommand, "@CreationUser", DbType.String, usuario.CreationUser);
            oDatabase.AddInParameter(oDbCommand, "@CreationDate", DbType.DateTime, usuario.CreationDate);
            oDatabase.AddInParameter(oDbCommand, "@UpdateUser", DbType.String, usuario.UpdateUser);
            oDatabase.AddInParameter(oDbCommand, "@UpdateDate", DbType.DateTime, usuario.UpdateDate);
            oDatabase.AddInParameter(oDbCommand, "@Active", DbType.Boolean, usuario.Active);
            
            oDatabase.ExecuteNonQuery(oDbCommand);
            
            return usuario;
        }
        
        //********************* FUNCION PARA ELIMINACION DE USUARIO **********************//
        public Usuario Eliminar_Usuario(
            System.Int32 IdUsuario
        )
        {
            Usuario usuario = new Usuario();
            
            DbCommand oDbCommand = oDatabase.GetStoredProcCommand(Procedimiento.USP_DEL_USUARIO);
            oDatabase.AddInParameter(oDbCommand, "@IdUsuario", DbType.Int32, IdUsuario);
            oDatabase.ExecuteNonQuery(oDbCommand);
            
            return usuario;
        }
        
        //******************* FUNCION PARA SELECCION POR ID DE USUARIO *******************//
        public Usuario Obtener_Usuario_PorId(
            System.Int32 IdUsuario
        )
        {
            Usuario usuario = new Usuario();
            DbCommand oDbCommand = oDatabase.GetStoredProcCommand(Procedimiento.USP_SEL_USUARIO_POR_ID);
            
            oDatabase.AddInParameter(oDbCommand, "@IdUsuario", DbType.Int32, IdUsuario);
            
            using (IDataReader oIDataReader = oDatabase.ExecuteReader(oDbCommand))
            {
                while (oIDataReader.Read())
                {
                    usuario.IdUsuario = DataUtil.DbValueToDefault<int>(oIDataReader[oIDataReader.GetOrdinal("IdUsuario")]);
                    usuario.UserName = DataUtil.DbValueToDefault<string>(oIDataReader[oIDataReader.GetOrdinal("UserName")]);
                    usuario.Password = DataUtil.DbValueToDefault<string>(oIDataReader[oIDataReader.GetOrdinal("Password")]);
                    usuario.CreationUser = DataUtil.DbValueToDefault<string>(oIDataReader[oIDataReader.GetOrdinal("CreationUser")]);
                    usuario.CreationDate = DataUtil.DbValueToDefault<System.DateTime>(oIDataReader[oIDataReader.GetOrdinal("CreationDate")]);
                    usuario.UpdateUser = DataUtil.DbValueToDefault<string>(oIDataReader[oIDataReader.GetOrdinal("UpdateUser")]);
                    usuario.UpdateDate = DataUtil.DbValueToDefault<System.DateTime>(oIDataReader[oIDataReader.GetOrdinal("UpdateDate")]);
                    usuario.Active = DataUtil.DbValueToDefault<bool>(oIDataReader[oIDataReader.GetOrdinal("Active")]);
                }
            }
            
            return usuario;
        }
        
        //********************** FUNCION PARA SELECCION DE USUARIO ***********************//
        public UsuarioList Listar_Usuario(Usuario usuario)
        {
            UsuarioList listaUsuario = new UsuarioList();
            DbCommand oDbCommand = oDatabase.GetStoredProcCommand(Procedimiento.USP_SEL_USUARIO);
            
            oDatabase.AddInParameter(oDbCommand, "@IdUsuario", DbType.Int32, usuario.IdUsuario);
            oDatabase.AddInParameter(oDbCommand, "@UserName", DbType.String, usuario.UserName);
            oDatabase.AddInParameter(oDbCommand, "@Password", DbType.String, usuario.Password);
            oDatabase.AddInParameter(oDbCommand, "@CreationUser", DbType.String, usuario.CreationUser);
            oDatabase.AddInParameter(oDbCommand, "@CreationDate", DbType.DateTime, usuario.CreationDate);
            oDatabase.AddInParameter(oDbCommand, "@UpdateUser", DbType.String, usuario.UpdateUser);
            oDatabase.AddInParameter(oDbCommand, "@UpdateDate", DbType.DateTime, usuario.UpdateDate);
            oDatabase.AddInParameter(oDbCommand, "@Active", DbType.Boolean, usuario.Active);
            
            using (IDataReader oIDataReader = oDatabase.ExecuteReader(oDbCommand))
            {
                while (oIDataReader.Read())
                {
                    usuario= new Usuario();
                    usuario.IdUsuario = DataUtil.DbValueToDefault<int>(oIDataReader[oIDataReader.GetOrdinal("IdUsuario")]);
                    usuario.UserName = DataUtil.DbValueToDefault<string>(oIDataReader[oIDataReader.GetOrdinal("UserName")]);
                    usuario.Password = DataUtil.DbValueToDefault<string>(oIDataReader[oIDataReader.GetOrdinal("Password")]);
                    usuario.CreationUser = DataUtil.DbValueToDefault<string>(oIDataReader[oIDataReader.GetOrdinal("CreationUser")]);
                    usuario.CreationDate = DataUtil.DbValueToDefault<System.DateTime>(oIDataReader[oIDataReader.GetOrdinal("CreationDate")]);
                    usuario.UpdateUser = DataUtil.DbValueToDefault<string>(oIDataReader[oIDataReader.GetOrdinal("UpdateUser")]);
                    usuario.UpdateDate = DataUtil.DbValueToDefault<System.DateTime>(oIDataReader[oIDataReader.GetOrdinal("UpdateDate")]);
                    usuario.Active = DataUtil.DbValueToDefault<bool>(oIDataReader[oIDataReader.GetOrdinal("Active")]);
                    listaUsuario.Add(usuario);
                }
            }
            
            return listaUsuario;
        }
        
    }
}
