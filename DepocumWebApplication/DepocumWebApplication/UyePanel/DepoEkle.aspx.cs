using DataAccessLayer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace DepocumWebApplication.UyePanel
{
    public partial class DepoEkle : System.Web.UI.Page
    {
        DataModel dm = new DataModel();
        protected void Page_Load(object sender, EventArgs e)
        {
            
        }

        protected void lbtn_ekle_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(tb_isim.Text))
            {
                if (tb_isim.Text.Length < 50)
                {
                    Depo d = new Depo();
                    d.Isim = tb_isim.Text;
                    int result = dm.DepoEkle(d);
                    if (result != -1)
                    {
                        lbl_basariliMesaj.Text = "Depo " + result + " id ile başarıyla eklenmiştir.";
                        pnl_basarisiz.Visible = false;
                        pnl_basarili.Visible = true;
                    }
                    else
                    {
                        lbl_mesaj.Text = "Depo eklenirken bir hata oluştu!";
                        pnl_basarisiz.Visible = true;
                        pnl_basarili.Visible = false;
                    }
                }
                else
                {
                    lbl_mesaj.Text = "Depo adı 50 karakterden büyük olamaz!";
                    pnl_basarisiz.Visible = true;
                    pnl_basarili.Visible = false;
                }
            }
            else
            {
                lbl_mesaj.Text = "Depo Adı boş bırakılamaz!";
                pnl_basarisiz.Visible = true;
                pnl_basarili.Visible = false;
            }

        }
    }
}