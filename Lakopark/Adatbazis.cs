using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MySql.Data.MySqlClient;

namespace Lakopark
{
    internal class Adatbazis
    {
        MySqlConnection conn;
        MySqlCommand cmd;

        public Adatbazis()
        {
            MySqlConnectionStringBuilder sb = new MySqlConnectionStringBuilder();
            sb.Server = "localhost";
            sb.UserID = "root";
            sb.Password = "";
            sb.Database = "lakopark";
            conn = new MySqlConnection(sb.ToString());
            try
            {
                KapcsolatNyit();
                cmd = conn.CreateCommand();
                KapcsolatZar();
            }
            catch (MySqlException ex)
            {
                string uzenet = ex.Message + Environment.NewLine + Environment.NewLine + "A program leáll!";
                MessageBox.Show(uzenet, "Hiba!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }

        private void KapcsolatZar()
        {
            if (conn.State != System.Data.ConnectionState.Closed) conn.Close();
        }

        void KapcsolatNyit()
        {
            if (conn.State != System.Data.ConnectionState.Open) conn.Open();
        }
        public List<Lakopark> lakoparkokBetoltese()
        {
            List<Lakopark> lakoparkok = new List<Lakopark>();
            KapcsolatNyit();
            cmd.CommandText = "SELECT * FROM epuletek NATURAL JOIN lakopark ORDER BY lakopark.lakoparkId, epuletek.utcaSzam;";
            int oldid = -1;
            int lakoparkIndex = -1;  
                      

            using (MySqlDataReader reader = cmd.ExecuteReader())
            {
                while (reader.Read())
                {
                    if (reader.GetInt32("lakoparkId") != oldid)
                    {
                        lakoparkIndex++;
                        lakoparkok.Add(new Lakopark(reader.GetInt32("lakoparkId"), reader.GetString("lakoparkNev"), reader.GetInt32("utcakSzama"), reader.GetInt32("telkekSzama")));
                        oldid = reader.GetInt32("lakoparkId");
                    }
                    lakoparkok[lakoparkIndex].HazFeltoltese(reader.GetInt32("utcaSzam"), reader.GetInt32("hazSzam"), reader.GetInt32("emelet"));

                    
                }
            }

                      KapcsolatZar();
            return lakoparkok;
        }

        internal void emeletMentes(Lakopark lakopark)
        {
            try
            {
                KapcsolatNyit();
                for (int i = 0; i < lakopark.UtcakSzama; i++)
                {
                    for (int j = 0; j < lakopark.TelkekSzama; j++)
                    {
                        if (vanEpuletAdat(lakopark.LakoparkId,i+1,j+1))
                        {
                            cmd.CommandText = "UPDATE epuletek SET emelet=@emelet WHERE lakoparkId=@lakoparkId AND utcaSzam=@utcaSzam AND hazSzam=@hazSzam;";
                            cmd.Parameters.Clear();
                            cmd.Parameters.AddWithValue("@emelet", lakopark.Hazak[i, j]);
                            cmd.Parameters.AddWithValue("@lakoparkId", lakopark.LakoparkId);
                            cmd.Parameters.AddWithValue("@utcaSzam", i + 1);
                            cmd.Parameters.AddWithValue("@hazSzam", j + 1);
                            cmd.ExecuteNonQuery();
                        }
                        else
                        {
                            cmd.CommandText = "INSERT INTO epuletek (lakoparkId, utcaSzam, hazSzam, emelet) VALUES (@lakoparkId, @utcaSzam, @hazSzam, @emelet);";
                            cmd.Parameters.Clear();
                            cmd.Parameters.AddWithValue("@lakoparkId", lakopark.LakoparkId);
                            cmd.Parameters.AddWithValue("@utcaSzam", i + 1);
                            cmd.Parameters.AddWithValue("@hazSzam", j + 1);
                            cmd.Parameters.AddWithValue("@emelet", lakopark.Hazak[i, j]);
                            cmd.ExecuteNonQuery();
                        }
                    }
                }

            }
            catch (MySqlException ex)
            {
                MessageBox.Show(ex.Message, "Hiba!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                KapcsolatZar();
            }
        }

        private bool vanEpuletAdat(int lakoparkId, int utca, int hazszam)
        {
            cmd.CommandText = "SELECT COUNT(*) FROM epuletek WHERE lakoparkId=@lakoparkId AND utcaSzam=@utcaSzam AND hazSzam=@hazSzam;";
            cmd.Parameters.Clear();
            cmd.Parameters.AddWithValue("@lakoparkId", lakoparkId);
            cmd.Parameters.AddWithValue("@utcaSzam", utca);
            cmd.Parameters.AddWithValue("@hazSzam", hazszam);
            int db = Convert.ToInt32(cmd.ExecuteScalar());
            if (db > 0) return true; else return false;
        }
    }
}
