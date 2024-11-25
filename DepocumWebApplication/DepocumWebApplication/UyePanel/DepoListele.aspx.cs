using DataAccessLayer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace DepocumWebApplication.UyePanel
{
    public partial class DepoListele : System.Web.UI.Page
    {
        DataModel dm = new DataModel();
        protected void Page_Load(object sender, EventArgs e)
        {
            Doldur();
        }

        protected void lv_depolar_ItemCommand(object sender, ListViewCommandEventArgs e)
        {
            int id = Convert.ToInt32(e.CommandArgument);
            if (e.CommandName == "durum")
            {
                dm.DepoDurumDegistir(id);
            }
            if (e.CommandName == "sil")
            {
                dm.DepoSil(id);
            }
            Doldur();
        }

        void Doldur()
        {
            lv_depolar.DataSource = dm.DepoGetir();
            lv_depolar.DataBind();
        }
    }
}