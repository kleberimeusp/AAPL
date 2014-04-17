using APP.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace APP.View
{
    public partial class Usuario : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            //var usuarios = new UsuarioDomain().GetList(new APP.Model.dataShape.Usuario() { iid = 134 });
            var usuarios = new UsuarioDomain().GetList(new APP.Model.dataShape.Usuario());
            dataGrid1.DataSource = usuarios;
            dataGrid1.DataBind();
        }
    }
}