using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Sistem_Manajemen_Data_Gym
{
    public partial class Form1 : Form
    {
        string connectionString = "Data Source=KHRLFTAMA\\ARIF;Initial Catalog=DB_Gym;Integrated Security=True";
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    conn.Open();
                    // Kalau berhasil, ganti teks di label atau munculkan pesan
                    lblStatusKoneksi.Text = "Connected to DB_Gym";
                    lblStatusKoneksi.ForeColor = Color.Green;
                }
            }
            catch (Exception ex)
            {
                lblStatusKoneksi.Text = "Disconnect";
                lblStatusKoneksi.ForeColor = Color.Red;
                MessageBox.Show("Koneksi Error: " + ex.Message);
            }
        }

        

        private void lblJudul_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    // Query untuk mengambil seluruh data dari tabel member [cite: 586]
                    string query = "SELECT * FROM Member";
                    SqlCommand cmd = new SqlCommand(query, conn);

                    conn.Open(); // Bagian B - Membuka koneksi [cite: 663]

                    // Menggunakan SqlDataReader untuk membaca data [cite: 661, 673]
                    SqlDataReader dr = cmd.ExecuteReader();

                    // Membuat DataTable untuk menampung hasil bacaan
                    DataTable dt = new DataTable();
                    dt.Load(dr);

                    dataGridView2.DataSource = dt;

                    // Tutup reader setelah digunakan
                    dr.Close();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Gagal menampilkan data: " + ex.Message);
            }
        }


        private void Inputstatus_Click(object sender, EventArgs e)
        {

        }

        private void lblTotalRecord_Click(object sender, EventArgs e)
        {

        }

        private void txtcari_TextChanged(object sender, EventArgs e)
        {
            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    // Query mencari nama yang mengandung kata di textbox cari
                    string query = "SELECT * FROM Member WHERE nama LIKE @cari";
                    SqlCommand cmd = new SqlCommand(query, conn);

                    // Menggunakan wildcard % agar pencarian lebih fleksibel
                    cmd.Parameters.AddWithValue("@cari", "%" + txtcari.Text + "%");

                    SqlDataAdapter da = new SqlDataAdapter(cmd);
                    DataTable dt = new DataTable();
                    da.Fill(dt);

                    // Menampilkan hasil pencarian ke DataGridView secara real-time
                    dataGridView1.DataSource = dt;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Terjadi kesalahan saat mencari: " + ex.Message);
            }
        }

        private void txtnama_TextChanged(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtnama.Text))
            {
                txtnama.BackColor = Color.LightPink;
            }
            else
            {
                txtnama.BackColor = Color.White;
            }
        }

        private void txthp_TextChanged(object sender, EventArgs e)
        {
            if (!System.Text.RegularExpressions.Regex.IsMatch(txthp.Text, "^[0-9]*$"))
            {
                MessageBox.Show("Nomor HP hanya boleh berisi angka!", "Peringatan Validasi");
                // Menghapus karakter terakhir yang bukan angka
                txthp.Text = txthp.Text.Remove(txthp.Text.Length - 1);
                txthp.SelectionStart = txthp.Text.Length;
            }

            // Memberikan indikator warna jika kolom kosong (Bagian F)
            if (string.IsNullOrWhiteSpace(txthp.Text))
            {
                txthp.BackColor = Color.LightPink;
            }
            else
            {
                txthp.BackColor = Color.White;
            }

        }

        private void cbstatus_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cbstatus.SelectedItem != null)
            {
                string status = cbstatus.SelectedItem.ToString();

                if (status == "Aktif")
                {
                    // Hijau jika member berstatus aktif
                    cbstatus.BackColor = Color.LightGreen;
                }
                else if (status == "Non-Aktif")
                {
                    // Oranye/Kuning jika member tidak aktif
                    cbstatus.BackColor = Color.Khaki;
                }
                else
                {
                    // Putih untuk kondisi default
                    cbstatus.BackColor = Color.White;
                }
            }
            else
            {
                // Jika tidak ada yang dipilih (kosong), kembalikan ke warna putih
                cbstatus.BackColor = Color.White;
            }
        }

        private void txtsimpan_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtnama.Text) || string.IsNullOrWhiteSpace(txthp.Text) || cbstatus.SelectedIndex == -1)
            {
                 MessageBox.Show("Semua kolom (Nama, No HP, dan Status) wajib diisi!", "Peringatan Validasi"); 
        return;
            }

            try
            {
                // 2. Koneksi ke Database [cite: 1049, 1133]
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    // 3. Query INSERT menggunakan SqlCommand [cite: 1130, 1136]
                    string query = "INSERT INTO Member (nama, no_hp, status_aktif) VALUES (@nama, @hp, @status)";
                    SqlCommand cmd = new SqlCommand(query, conn);

                    // Parameterisasi untuk keamanan data [cite: 998]
                     cmd.Parameters.AddWithValue("@nama", txtnama.Text); 
                     cmd.Parameters.AddWithValue("@hp", txthp.Text); 
                     cmd.Parameters.AddWithValue("@status", cbstatus.Text); 

            conn.Open();

                    // 4. Eksekusi Query (ExecuteNonQuery) 
                    cmd.ExecuteNonQuery();

                    // 5. Pesan Konfirmasi Sukses 
                    MessageBox.Show("Data Transaksi Berhasil Disimpan", "Informasi");

                    // 6. Refresh Tampilan & Statistik
                    TampilkanData(); // Memanggil fungsi Select/DataReader [cite: 1143]
                    UpdateTotalMember(); // Memanggil fungsi ExecuteScalar [cite: 1141]

                    // Bersihkan Form
                    txtnama.Clear();
                    txthp.Clear();
                    cbstatus.SelectedIndex = -1;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Gagal menyimpan data: " + ex.Message);
            }
        }

        private void txtupdate_Click(object sender, EventArgs e)
        {
            if (dataGridView1.CurrentRow != null)
            {
                // 1. Ambil ID_Member sebagai kunci utama (paling akurat)
                // Pastikan di DataGridView kamu ada kolom id_member
                string idMember = dataGridView1.CurrentRow.Cells["id_member"].Value.ToString();

                try
                {
                    using (SqlConnection conn = new SqlConnection(connectionString))
                    {
                        // 2. Query UPDATE menggunakan ID agar tidak salah sasaran
                        string query = "UPDATE Member SET nama = @nama, no_hp = @hp, status_aktif = @status WHERE id_member = @id";
                        SqlCommand cmd = new SqlCommand(query, conn);

                        // Parameter data baru
                        cmd.Parameters.AddWithValue("@nama", txtnama.Text);
                        cmd.Parameters.AddWithValue("@hp", txthp.Text);
                        cmd.Parameters.AddWithValue("@status", cbstatus.Text);
                        cmd.Parameters.AddWithValue("@id", idMember);

                        conn.Open();
                        int rowsAffected = cmd.ExecuteNonQuery();

                        if (rowsAffected > 0)
                        {
                            MessageBox.Show("Data Member Berhasil Diupdate!", "Sukses");

                            // 3. Refresh tabel dan total
                            TampilkanData();
                            UpdateTotalMember();
                        }
                        else
                        {
                            MessageBox.Show("Data tidak ditemukan di database.");
                        }
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error Update: " + ex.Message);
                }
            }
            else
            {
                MessageBox.Show("Pilih baris di tabel dulu, Mas!");
            }
        }

        private void txthapus_Click(object sender, EventArgs e)
        {
            if (dataGridView1.CurrentRow != null)
            {
                // Ambil Nama atau ID dari baris yang dipilih sebagai kunci penghapusan
                string namaMember = dataGridView1.CurrentRow.Cells["Nama"].Value.ToString();

                // Konfirmasi sebelum menghapus
                DialogResult dialogResult = MessageBox.Show("Apakah Anda yakin ingin menghapus member: " + namaMember + "?", "Konfirmasi Hapus", MessageBoxButtons.YesNo);

                if (dialogResult == DialogResult.Yes)
                {
                    try
                    {
                        using (SqlConnection conn = new SqlConnection(connectionString))
                        {
                            // 2. Query SQL untuk menghapus data (Bagian F - Delete)
                            string query = "DELETE FROM Member WHERE Nama = @nama";
                            SqlCommand cmd = new SqlCommand(query, conn);
                            cmd.Parameters.AddWithValue("@nama", namaMember);

                            conn.Open();
                            cmd.ExecuteNonQuery();
                            MessageBox.Show("Data Member Berhasil Dihapus", "Informasi");
                        }

                        // 3. Refresh tampilan tabel dan statistik agar sinkron
                        TampilkanData(); // Memanggil fungsi Select
                        UpdateTotalMember(); // Memanggil fungsi ExecuteScalar
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Gagal menghapus data: " + ex.Message);
                    }
                }
            }
            else
            {
                MessageBox.Show("Silakan pilih baris data di tabel yang ingin dihapus terlebih dahulu.");
            }
        }
        // The errors occur because the methods 'TampilkanData' and 'UpdateTotalMember' are called in your code, but they are not defined anywhere in your Form1 class. 
        // To fix the errors, you need to implement these methods. Here are simple example implementations you can add to your Form1 class:

        private void TampilkanData()
        {
            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    string query = "SELECT * FROM Member";
                    SqlCommand cmd = new SqlCommand(query, conn);
                    SqlDataAdapter da = new SqlDataAdapter(cmd);
                    DataTable dt = new DataTable();
                    da.Fill(dt);
                    dataGridView1.DataSource = dt;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Gagal menampilkan data: " + ex.Message);
            }
        }

        private void UpdateTotalMember()
        {
            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    string query = "SELECT COUNT(*) FROM Member";
                    SqlCommand cmd = new SqlCommand(query, conn);
                    conn.Open();
                    int total = (int)cmd.ExecuteScalar();
                    // Misal ada label bernama lblTotalRecord
                    lblTotalRecord.Text = "Total Member: " + total.ToString();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Gagal menghitung total member: " + ex.Message);
            }
        }

        private void dataGridView2_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            foreach (DataGridViewRow row in dataGridView2.Rows)
            {
                if (row.Cells["status_aktif"].Value != null &&
                    row.Cells["status_aktif"].Value.ToString() == "Non-Aktif")
                {
                    row.DefaultCellStyle.BackColor = Color.MistyRose; // Warna merah muda untuk yang tidak aktif
                }
            }
        }



        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                // Ambil baris yang sedang diklik
                DataGridViewRow row = dataGridView1.Rows[e.RowIndex];

                // Masukkan data dari kolom tabel ke Textbox/Combobox masing-masing
                // Pastikan nama kolom ("nama", "no_hp", "status_aktif") sesuai dengan database kamu
                txtnama.Text = row.Cells["nama"].Value.ToString();
                txthp.Text = row.Cells["no_hp"].Value.ToString();
                cbstatus.Text = row.Cells["status_aktif"].Value.ToString();
            }
        }

        private void RefreshLogDatabase()
        {
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                // Menampilkan 10 data terbaru yang baru masuk (berdasarkan ID terbesar)
                string query = "SELECT TOP 10 id_member, nama, status_aktif FROM Member ORDER BY id_member DESC";
                SqlDataAdapter da = new SqlDataAdapter(query, conn);
                DataTable dt = new DataTable();
                da.Fill(dt);

                dataGridView2.DataSource = dt;
            }
        }

    }
    }
    
    

    



