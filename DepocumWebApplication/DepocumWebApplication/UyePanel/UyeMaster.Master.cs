using DataAccessLayer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace DepocumWebApplication.UyePanel
{
    public partial class UyeMaster : System.Web.UI.MasterPage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["GirisYapanUye"] != null)
            {
                Uye u = (Uye)Session["GirisYapanUye"];
                lbl_kullanici.Text = u.Isim + " " + u.Soyisim;
            }
            else
            {
                Response.Redirect("UyeGiris.aspx");
            }
        }

        protected void lbtn_cikis_Click(object sender, EventArgs e)
        {
            Session["GirisYapanUye"] = null;
            Response.Redirect("UyeGiris.aspx");
        }
    }
}