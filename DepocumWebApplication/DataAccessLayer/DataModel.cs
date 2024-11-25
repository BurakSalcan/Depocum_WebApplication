using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer
{
    public class DataModel
    {
        SqlConnection con; SqlCommand cmd;

        public DataModel()
        {
            con = new SqlConnection(ConnectionString.ConStr);
            cmd = con.CreateCommand();
        }

        #region Uye Metotları

        public Uye UyeGiris(string mail, string sifre)
        {
            //    try
            //    {
            //        cmd.CommandText = "SELECT U.ID, U.Isim, U.Soyisim, U.Mail, U.Sifre FROM Uye AS U WHERE U.Mail = @mail AND U.Sifre = @sifre";
            //        cmd.Parameters.Clear();
            //        cmd.Parameters.AddWithValue("@mail", mail);
            //        cmd.Parameters.AddWithValue("@sifre", sifre);
            //        con.Open();
            //        SqlDataReader reader = cmd.ExecuteReader();
            //        Uye u = new Uye();
            //        while (reader.Read())
            //        {
            //            u = new Uye();
            //            u.ID = reader.GetInt32(0);
            //            u.Isim = reader.GetString(1);
            //            u.Soyisim = reader.GetString(2);
            //            u.Mail = reader.GetString(3);
            //            u.Sifre = reader.GetString(4);
            //        }
            //        return u;
            //    }
            //    catch
            //    {

            //        return null;
            //    }
            //    finally
            //    {
            //        con.Close();
            //    }
            //}

            try
            {
                cmd.CommandText = "SELECT U.ID, U.Isim, U.Soyisim, U.Mail, U.Sifre, U.AktifMi FROM Uye AS U WHERE U.Mail = @mail AND U.Sifre = @sifre";
                cmd.Parameters.Clear();
                cmd.Parameters.AddWithValue("@mail", mail);
                cmd.Parameters.AddWithValue("@sifre", sifre);

                con.Open();
                SqlDataReader reader = cmd.ExecuteReader();

                Uye u = null; // Başlangıçta null olarak ayarlayın
                while (reader.Read())
                {
                    u = new Uye();
                    u.ID = reader.GetInt32(0);
                    u.Isim = reader.GetString(1);
                    u.Soyisim = reader.GetString(2);
                    u.Mail = reader.GetString(3);
                    u.Sifre = reader.GetString(4);
                    u.AktifMi = reader.GetBoolean(5);
                }
                return u;
            }
            catch (Exception ex)
            {
                // Hata mesajını loglayabilir veya gösterime ekleyebilirsiniz
                Console.WriteLine(ex.Message);
                return null;
            }
            finally
            {
                if (con.State == ConnectionState.Open)
                {
                    con.Close();
                }
            }
        }

        #endregion

        #region Ekleme Metotları

        #region Depo

        public int DepoEkle(Depo de)
        {
            try
            {
                cmd.CommandText = "INSERT INTO Depo(Isim, Durum) VALUES(@isim, @durum) SELECT @@IDENTITY";
                cmd.Parameters.Clear();
                cmd.Parameters.AddWithValue("@isim", de.Isim);
                cmd.Parameters.AddWithValue("@durum", de.Durum);
                con.Open();
                int id = Convert.ToInt32(cmd.ExecuteScalar());
                return id;
            }
            catch
            {
                return -1;
            }
            finally
            {
                con.Close();
            }
        }

        public List<Depo> DepoGetir()
        {
            List<Depo> depo = new List<Depo>();
            try
            {
                cmd.CommandText = "SELECT Durum, ID, Isim FROM Depo";
                cmd.Parameters.Clear();
                con.Open();
                SqlDataReader okuyucu = cmd.ExecuteReader();
                Depo de;
                while (okuyucu.Read())
                {
                    de = new Depo();
                    de.ID = okuyucu.GetInt32(1);
                    de.Isim = okuyucu.GetString(2);
                    de.Durum = okuyucu.GetBoolean(0);
                    de.DurumStr = okuyucu.GetBoolean(0) ? "Aktif" : "Pasif";
                    depo.Add(de);
                }
                return depo;
            }
            catch
            {
                return null;
            }
            finally
            {
                con.Close();
            }
        }

        public List<Depo> DepoGetir(bool durum)
        {
            string d = durum ? "1" : "0";
            List<Depo> kategoriler = new List<Depo>();
            try
            {
                cmd.CommandText = "SELECT Durum, ID, Isim FROM Depo WHERE Durum = " + d;
                cmd.Parameters.Clear();
                con.Open();
                SqlDataReader okuyucu = cmd.ExecuteReader();
                Depo de;
                while (okuyucu.Read())
                {
                    de = new Depo();
                    de.ID = okuyucu.GetInt32(1);
                    de.Isim = okuyucu.GetString(2);
                    de.Durum = okuyucu.GetBoolean(0);
                    de.DurumStr = okuyucu.GetBoolean(0) ? "Aktif" : "Pasif";
                    kategoriler.Add(de);
                }
                return kategoriler;
            }
            catch
            {
                return null;
            }
            finally
            {
                con.Close();
            }
        }

        public void DepoDurumDegistir(int id)
        {
            try
            {
                cmd.CommandText = "SELECT Durum FROM Depo WHERE ID=@id";
                cmd.Parameters.Clear();
                cmd.Parameters.AddWithValue("@id", id);
                con.Open();
                bool durum = Convert.ToBoolean(cmd.ExecuteScalar());
                cmd.CommandText = "UPDATE Depo SET Durum = @d WHERE ID=@id";
                cmd.Parameters.Clear();
                cmd.Parameters.AddWithValue("@id", id);
                cmd.Parameters.AddWithValue("@d", !durum);
                cmd.ExecuteNonQuery();
            }
            finally
            {
                con.Close();
            }
        }

        public void DepoSil(int id)
        {
            try
            {
                cmd.CommandText = "DELETE FROM Depo WHERE ID = @id";
                cmd.Parameters.Clear();
                cmd.Parameters.AddWithValue("@id", id);
                con.Open();
                cmd.ExecuteNonQuery();
            }
            finally
            {
                con.Close();
            }
        }

        public Depo DepoGetir(int id)
        {
            try
            {
                cmd.CommandText = "SELECT ID, Isim, Durum FROM Depo WHERE ID = @id";
                cmd.Parameters.Clear();
                cmd.Parameters.AddWithValue("@id", id);
                con.Open();
                SqlDataReader okuyucu = cmd.ExecuteReader();
                Depo d = new Depo();
                while (okuyucu.Read())
                {
                    d.ID = okuyucu.GetInt32(0);
                    d.Isim = okuyucu.GetString(1);
                    d.Durum = okuyucu.GetBoolean(2);
                }
                return d;
            }
            catch
            {
                return null;
            }
            finally
            {
                con.Close();
            }
        }

        public bool DepoGuncelle(Depo de)
        {
            try
            {
                cmd.CommandText = "UPDATE Depo SET Isim=@isim, Durum=@durum WHERE ID=@id";
                cmd.Parameters.Clear();
                cmd.Parameters.AddWithValue("@id", de.ID);
                cmd.Parameters.AddWithValue("@isim", de.Isim);
                cmd.Parameters.AddWithValue("@durum", de.Durum);
                con.Open();
                cmd.ExecuteNonQuery();
                return true;
            }
            catch
            {
                return false;
            }
            finally
            {
                con.Close();
            }
        }

        #endregion

        #region Palet
        public int PaletEkle(Palet plt)
        {
            try
            {
                cmd.CommandText = "INSERT INTO Palet(Isim) VALUES(@isim) SELECT @@IDENTITY";
                cmd.Parameters.Clear();
                cmd.Parameters.AddWithValue("@isim", plt.Isim);
                con.Open();
                int id = Convert.ToInt32(cmd.ExecuteScalar());
                return id;
            }
            catch
            {
                return -1;
            }
            finally
            {
                con.Close();
            }
        }

        public List<Palet> PaletGetir()
        {
            List<Palet> palet = new List<Palet>();
            try
            {
                cmd.CommandText = "SELECT Durum, ID, Isim FROM Palet";
                cmd.Parameters.Clear();
                con.Open();
                SqlDataReader okuyucu = cmd.ExecuteReader();
                Palet plt;
                while (okuyucu.Read())
                {
                    plt = new Palet();
                    plt.ID = okuyucu.GetInt32(1);
                    plt.Isim = okuyucu.GetString(2);
                    plt.Durum = okuyucu.GetBoolean(0);
                    plt.DurumStr = okuyucu.GetBoolean(0) ? "Aktif" : "Pasif";
                    palet.Add(plt);
                }
                return palet;
            }
            catch
            {
                return null;
            }
            finally
            {
                con.Close();
            }
        }

        public List<Palet> PaletGetir(bool durum)
        {
            string d = durum ? "1" : "0";
            List<Palet> palet = new List<Palet>();
            try
            {
                cmd.CommandText = "SELECT Durum, ID, Isim FROM Palet WHERE Durum = " + d;
                cmd.Parameters.Clear();
                con.Open();
                SqlDataReader okuyucu = cmd.ExecuteReader();
                Palet plt;
                while (okuyucu.Read())
                {
                    plt = new Palet();
                    plt.ID = okuyucu.GetInt32(1);
                    plt.Isim = okuyucu.GetString(2);
                    plt.Durum = okuyucu.GetBoolean(0);
                    plt.DurumStr = okuyucu.GetBoolean(0) ? "Aktif" : "Pasif";
                    palet.Add(plt);
                }
                return palet;
            }
            catch
            {
                return null;
            }
            finally
            {
                con.Close();
            }
        }

        public void PaletDurumDegistir(int id)
        {
            try
            {
                cmd.CommandText = "SELECT Durum FROM Palet WHERE ID=@id";
                cmd.Parameters.Clear();
                cmd.Parameters.AddWithValue("@id", id);
                con.Open();
                bool durum = Convert.ToBoolean(cmd.ExecuteScalar());
                cmd.CommandText = "UPDATE Palet SET Durum = @d WHERE ID=@id";
                cmd.Parameters.Clear();
                cmd.Parameters.AddWithValue("@id", id);
                cmd.Parameters.AddWithValue("@d", !durum);
                cmd.ExecuteNonQuery();
            }
            finally
            {
                con.Close();
            }
        }

        public void PaletSil(int id)
        {
            try
            {
                cmd.CommandText = "DELETE FROM Palet WHERE ID = @id";
                cmd.Parameters.Clear();
                cmd.Parameters.AddWithValue("@id", id);
                con.Open();
                cmd.ExecuteNonQuery();
            }
            finally
            {
                con.Close();
            }
        }

        public Palet PaletGetir(int id)
        {
            try
            {
                cmd.CommandText = "SELECT ID, Isim, Durum FROM Palet WHERE ID = @id";
                cmd.Parameters.Clear();
                cmd.Parameters.AddWithValue("@id", id);
                con.Open();
                SqlDataReader okuyucu = cmd.ExecuteReader();
                Palet p = new Palet();
                while (okuyucu.Read())
                {
                    p.ID = okuyucu.GetInt32(0);
                    p.Isim = okuyucu.GetString(1);
                    p.Durum = okuyucu.GetBoolean(2);
                }
                return p;
            }
            catch
            {
                return null;
            }
            finally
            {
                con.Close();
            }
        }

        public bool PaletGuncelle(Palet plt)
        {
            try
            {
                cmd.CommandText = "UPDATE Palet SET Isim=@isim, Durum=@durum WHERE ID=@id";
                cmd.Parameters.Clear();
                cmd.Parameters.AddWithValue("@id", plt.ID);
                cmd.Parameters.AddWithValue("@isim", plt.Isim);
                cmd.Parameters.AddWithValue("@durum", plt.Durum);
                con.Open();
                cmd.ExecuteNonQuery();
                return true;
            }
            catch
            {
                return false;
            }
            finally
            {
                con.Close();
            }
        }

        #endregion

        #region Raf

        public int RafEkle(Raf rf)
        {
            try
            {
                cmd.CommandText = "INSERT INTO Raf(Isim) VALUES(@isim) SELECT @@IDENTITY";
                cmd.Parameters.Clear();
                cmd.Parameters.AddWithValue("@isim", rf.Isim);
                con.Open();
                int id = Convert.ToInt32(cmd.ExecuteScalar());
                return id;
            }
            catch
            {
                return -1;
            }
            finally
            {
                con.Close();
            }
        }

        public List<Raf> RafGetir()
        {
            List<Raf> raf = new List<Raf>();
            try
            {
                cmd.CommandText = "SELECT Durum, ID, Isim FROM Raf";
                cmd.Parameters.Clear();
                con.Open();
                SqlDataReader okuyucu = cmd.ExecuteReader();
                Raf rf;
                while (okuyucu.Read())
                {
                    rf = new Raf();
                    rf.ID = okuyucu.GetInt32(1);
                    rf.Isim = okuyucu.GetString(2);
                    rf.Durum = okuyucu.GetBoolean(0);
                    rf.DurumStr = okuyucu.GetBoolean(0) ? "Aktif" : "Pasif";
                    raf.Add(rf);
                }
                return raf;
            }
            catch
            {
                return null;
            }
            finally
            {
                con.Close();
            }
        }

        public List<Raf> RafGetir(bool durum)
        {
            string d = durum ? "1" : "0";
            List<Raf> raf = new List<Raf>();
            try
            {
                cmd.CommandText = "SELECT Durum, ID, Isim FROM Raf WHERE Durum = " + d;
                cmd.Parameters.Clear();
                con.Open();
                SqlDataReader okuyucu = cmd.ExecuteReader();
                Raf rf;
                while (okuyucu.Read())
                {
                    rf = new Raf();
                    rf.ID = okuyucu.GetInt32(1);
                    rf.Isim = okuyucu.GetString(2);
                    rf.Durum = okuyucu.GetBoolean(0);
                    rf.DurumStr = okuyucu.GetBoolean(0) ? "Aktif" : "Pasif";
                    raf.Add(rf);
                }
                return raf;
            }
            catch
            {
                return null;
            }
            finally
            {
                con.Close();
            }
        }

        public void RafDurumDegistir(int id)
        {
            try
            {
                cmd.CommandText = "SELECT Durum FROM Raf WHERE ID=@id";
                cmd.Parameters.Clear();
                cmd.Parameters.AddWithValue("@id", id);
                con.Open();
                bool durum = Convert.ToBoolean(cmd.ExecuteScalar());
                cmd.CommandText = "UPDATE Raf SET Durum = @d WHERE ID=@id";
                cmd.Parameters.Clear();
                cmd.Parameters.AddWithValue("@id", id);
                cmd.Parameters.AddWithValue("@d", !durum);
                cmd.ExecuteNonQuery();
            }
            finally
            {
                con.Close();
            }
        }

        public void RafSil(int id)
        {
            try
            {
                cmd.CommandText = "DELETE FROM Raf WHERE ID = @id";
                cmd.Parameters.Clear();
                cmd.Parameters.AddWithValue("@id", id);
                con.Open();
                cmd.ExecuteNonQuery();
            }
            finally
            {
                con.Close();
            }
        }

        public Raf RafGetir(int id)
        {
            try
            {
                cmd.CommandText = "SELECT ID, Isim, Durum FROM Raf WHERE ID = @id";
                cmd.Parameters.Clear();
                cmd.Parameters.AddWithValue("@id", id);
                con.Open();
                SqlDataReader okuyucu = cmd.ExecuteReader();
                Raf r = new Raf();
                while (okuyucu.Read())
                {
                    r.ID = okuyucu.GetInt32(0);
                    r.Isim = okuyucu.GetString(1);
                    r.Durum = okuyucu.GetBoolean(2);
                }
                return r;
            }
            catch
            {
                return null;
            }
            finally
            {
                con.Close();
            }
        }

        public bool RafGuncelle(Raf rf)
        {
            try
            {
                cmd.CommandText = "UPDATE Raf SET Isim=@isim, Durum=@durum WHERE ID=@id";
                cmd.Parameters.Clear();
                cmd.Parameters.AddWithValue("@id", rf.ID);
                cmd.Parameters.AddWithValue("@isim", rf.Isim);
                cmd.Parameters.AddWithValue("@durum", rf.Durum);
                con.Open();
                cmd.ExecuteNonQuery();
                return true;
            }
            catch
            {
                return false;
            }
            finally
            {
                con.Close();
            }
        }

        #endregion

        #region Ürün

        public int UrunEkle(Urun ur)
        {
            try
            {
                cmd.CommandText = "INSERT INTO Urun (Isim, EklemeTarihi, Depo_ID, Raf_ID, Palet_ID, Uye_ID) " +
                                  "VALUES (@isim, @eklemeTarihi, @depo_ID, @raf_ID, @palet_ID, @uye_ID); " +
                                  "SELECT SCOPE_IDENTITY();";

                cmd.Parameters.Clear();
                cmd.Parameters.AddWithValue("@isim", ur.Isim);
                cmd.Parameters.AddWithValue("@eklemeTarihi", ur.Ekleme_Tarihi);
                cmd.Parameters.AddWithValue("@depo_ID", ur.Depo_ID);
                cmd.Parameters.AddWithValue("@raf_ID", ur.Raf_ID);
                cmd.Parameters.AddWithValue("@palet_ID", ur.Palet_ID);
                cmd.Parameters.AddWithValue("@uye_ID", ur.Uye_ID);

                con.Open();

                object result = cmd.ExecuteScalar();

                if (result != null)
                {
                    return Convert.ToInt32(result);
                }
                else
                {
                    return -1;
                }
            }
            catch
            {
                return -1;
            }
            finally
            {
                con.Close();
            }

        }

        #endregion

        #endregion


    }
}
