using DataAccessLayer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace DepocumWebApplication.UyePanel
{
    public partial class RafListele : System.Web.UI.Page
    {
        DataModel dm = new DataModel();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                Doldur();
            }

        }

        protected void lv_raflar_ItemCommand(object sender, ListViewCommandEventArgs e)
        {
            int id = Convert.ToInt32(e.CommandArgument);
            if (e.CommandName == "durum")
            {
                dm.RafDurumDegistir(id);
            }
            if (e.CommandName == "sil")
            {
                dm.RafSil(id);
            }
            Doldur();

        }

        void Doldur()
        {
            List<Raf> raflar = dm.RafGetir();
            if (raflar != null && raflar.Count > 0)
            {
                lv_raflar.DataSource = raflar;
                lv_raflar.DataBind();
            }
            else
            {
                System.Diagnostics.Debug.WriteLine("Raf listesi boş veya null.");
            }
        }

        //void Doldur()
        //{
        //    lv_raflar.DataSource = dm.RafGetir();
        //    lv_raflar.DataBind();
        //}
    }
}