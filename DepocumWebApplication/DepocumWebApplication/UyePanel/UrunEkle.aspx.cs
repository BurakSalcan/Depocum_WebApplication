using DataAccessLayer;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace DepocumWebApplication.UyePanel
{
    public partial class UrunEkle : System.Web.UI.Page
    {
        DataModel dm = new DataModel();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                DepolariGetir();
            }
            if (!IsPostBack)
            {
                RaflariGetir();
            }
            if (!IsPostBack)
            {
                PaletleriGetir();
            }
        }

        private void DepolariGetir()
        {
            // Bağlantı dizesi
            string connectionString = @"Data Source=.\SQLEXPRESS;Initial Catalog=Depocum_DB;Integrated Security=True";

            // SQL sorgusu
            string query = "SELECT ID, Isim FROM Depo";

            using (SqlConnection con = new SqlConnection(connectionString))
            {
                using (SqlCommand cmd = new SqlCommand(query, con))
                {
                    try
                    {
                        con.Open();

                        // SQL verilerini okuyucu ile çek
                        SqlDataReader dr = cmd.ExecuteReader();

                        // DropDownList'e bağla
                        ddl_depolar.DataSource = dr;
                        ddl_depolar.DataTextField = "Isim"; // Görünen metin
                        ddl_depolar.DataValueField = "ID";  // Arka planda kullanılan değer
                        ddl_depolar.DataBind();
                    }
                    catch (Exception ex)
                    {
                        // Hata yönetimi
                        Response.Write("Hata: " + ex.Message);
                    }
                    finally
                    {
                        con.Close();
                    }
                }
            }
        }

        private void RaflariGetir()
        {
            // Bağlantı dizesi
            string connectionString = @"Data Source=.\SQLEXPRESS;Initial Catalog=Depocum_DB;Integrated Security=True";

            // SQL sorgusu
            string query = "SELECT ID, Isim FROM Raf";

            using (SqlConnection con = new SqlConnection(connectionString))
            {
                using (SqlCommand cmd = new SqlCommand(query, con))
                {
                    try
                    {
                        con.Open();

                        // SQL verilerini okuyucu ile çek
                        SqlDataReader dr = cmd.ExecuteReader();

                        // DropDownList'e bağla
                        ddl_raflar.DataSource = dr;
                        ddl_raflar.DataTextField = "Isim"; // Kullanıcıya görünen metin
                        ddl_raflar.DataValueField = "ID";  // Arka planda kullanılan değer
                        ddl_raflar.DataBind();
                    }
                    catch (Exception ex)
                    {
                        // Hata yönetimi
                        Response.Write("Hata: " + ex.Message);
                    }
                    finally
                    {
                        con.Close();
                    }
                }
            }
        }

        private void PaletleriGetir()
        {
            // Veritabanı bağlantı dizesi
            string connectionString = @"Data Source=.\SQLEXPRESS;Initial Catalog=Depocum_DB;Integrated Security=True";

            // SQL sorgusu
            string query = "SELECT ID, Isim FROM Palet";

            using (SqlConnection con = new SqlConnection(connectionString))
            {
                using (SqlCommand cmd = new SqlCommand(query, con))
                {
                    try
                    {
                        con.Open();

                        // SQL verilerini okuyucu ile çek
                        SqlDataReader dr = cmd.ExecuteReader();

                        // DropDownList'e bağla
                        ddl_paletler.DataSource = dr;
                        ddl_paletler.DataTextField = "Isim"; // Kullanıcıya görünen metin
                        ddl_paletler.DataValueField = "ID";  // Arka planda kullanılan değer
                        ddl_paletler.DataBind();
                    }
                    catch (Exception ex)
                    {
                        // Hata yönetimi
                        Response.Write("Hata: " + ex.Message);
                    }
                    finally
                    {
                        con.Close();
                    }
                }
            }
        }

        protected void lbtn_ekle_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(tb_urun.Text))
            {
                if (tb_urun.Text.Length < 50)
                {
                    Urun u = new Urun();
                    u.Isim = tb_urun.Text;
                    u.Ekleme_Tarihi = DateTime.Now; 
                    u.Depo_ID = 1; 
                    u.Raf_ID = 2; 
                    u.Palet_ID = 3; 
                    u.Uye_ID = 1; 

                    int result = dm.UrunEkle(u);

                    if (result != -1)
                    {
                        lbl_mesaj.Text = "Ürün " + result + " ID ile başarıyla eklenmiştir.";
                        pnl_basarisiz.Visible = false;
                        pnl_basarili.Visible = true;
                    }
                    else
                    {
                        lbl_mesaj.Text = "Ürün eklenirken bir hata oluştu!";
                        pnl_basarisiz.Visible = true;
                        pnl_basarili.Visible = false;
                    }
                }
                else
                {
                    lbl_mesaj.Text = "Ürün adı 50 karakterden büyük olamaz!";
                    pnl_basarisiz.Visible = true;
                    pnl_basarili.Visible = false;
                }
            }
            else
            {
                lbl_mesaj.Text = "Ürün Adı boş bırakılamaz!";
                pnl_basarisiz.Visible = true;
                pnl_basarili.Visible = false;
            }
        }
    }
}