namespace Company.Module.Domain.Core.Entities
{
    public partial class Usuario
    {
        public int IdUsuario { get; set; }
        
        public string UserName { get; set; }
        
        public string Password { get; set; }
        
        public string CreationUser { get; set; }
        
        public System.DateTime CreationDate { get; set; }
        
        public string UpdateUser { get; set; }
        
        public System.DateTime UpdateDate { get; set; }
        
        public bool Active { get; set; }
        
    }
}