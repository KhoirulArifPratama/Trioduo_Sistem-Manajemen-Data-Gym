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
        BindingSource bs = new BindingSource();
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

                    lblStatusKoneksi.Text = "Connected to DB_Gym";
                    lblStatusKoneksi.ForeColor = Color.Green;
                }

                dataGridView2.ColumnCount = 2;

                dataGridView2.Columns[0].Name = "Waktu & Tanggal";
                dataGridView2.Columns[1].Name = "Aktivitas";

                dataGridView2.AutoSizeColumnsMode =
                DataGridViewAutoSizeColumnsMode.Fill;

                TampilkanData();
                UpdateTotalMember();

                // BINDING NAVIGATOR
                bindingNavigator1.BindingSource = bs;
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
                // Tampilkan semua data member ke tabel kiri
                TampilkanData();

                // Update total member
                UpdateTotalMember();

                // Kosongkan tabel kanan saat refresh
                dataGridView2.DataSource = null;

                MessageBox.Show("Data berhasil ditampilkan!", "Informasi");
            }
            catch (Exception ex)
            {
                MessageBox.Show("Gagal menampilkan data: " + ex.Message);
            }
        }

        private void TambahAktivitas(string aktivitas)
        {
            dataGridView2.Rows.Insert(
                0,
                DateTime.Now.ToString("dd/MM/yyyy"),
                aktivitas
            );
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
                using (SqlConnection conn =
                    new SqlConnection(connectionString))
                {
                    SqlCommand cmd =
                        new SqlCommand(
                            "sp_SearchMember",
                            conn
                        );

                    cmd.CommandType =
                        CommandType.StoredProcedure;

                    cmd.Parameters.AddWithValue(
                        "@keyword",
                        txtcari.Text
                    );

                    SqlDataAdapter da =
                        new SqlDataAdapter(cmd);

                    DataTable dt =
                        new DataTable();

                    da.Fill(dt);

                    dataGridView1.DataSource = dt;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(
                    "Terjadi kesalahan saat mencari: "
                    + ex.Message
                );
            }
        }

        private void txtnama_TextChanged(object sender, EventArgs e)
        {
            // Validasi hanya huruf dan spasi
            if (!System.Text.RegularExpressions.Regex.IsMatch(txtnama.Text, "^[a-zA-Z ]*$"))
            {
                MessageBox.Show("Nama hanya boleh berisi huruf!", "Validasi Nama");

                // Hapus karakter terakhir
                txtnama.Text = txtnama.Text.Remove(txtnama.Text.Length - 1);

                // Kursor kembali ke belakang
                txtnama.SelectionStart = txtnama.Text.Length;
            }

            // Validasi kosong
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
                MessageBox.Show("Nomor HP hanya boleh berisi angka!", "Validasi");

                txthp.Text = txthp.Text.Remove(txthp.Text.Length - 1);
                txthp.SelectionStart = txthp.Text.Length;
            }

            // Maksimal 13 digit
            if (txthp.Text.Length > 13)
            {
                MessageBox.Show("Nomor HP maksimal 13 digit!", "Validasi");

                txthp.Text = txthp.Text.Substring(0, 13);
                txthp.SelectionStart = txthp.Text.Length;
            }

            // Warna validasi
            if (string.IsNullOrWhiteSpace(txthp.Text))
            {
                txthp.BackColor = Color.LightPink;
            }
            else if (txthp.Text.Length < 10 || txthp.Text.Length > 13)
            {
                txthp.BackColor = Color.LightYellow;
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

            // Validasi nomor HP minimal 10 digit dan maksimal 13 digit
            if (txthp.Text.Length < 10 || txthp.Text.Length > 13)
            {
                MessageBox.Show("Nomor HP harus 10 sampai 13 digit!", "Validasi");

                txthp.Focus();
                return;
            }

            // Validasi nama hanya huruf
            if (!System.Text.RegularExpressions.Regex.IsMatch(txtnama.Text, "^[a-zA-Z ]+$"))
            {
                MessageBox.Show("Nama hanya boleh huruf dan spasi!", "Validasi Nama");

                txtnama.Focus();
                return;
            }

            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    SqlCommand cmd =
                    new SqlCommand("sp_InsertMember", conn);

                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.AddWithValue("@nama", txtnama.Text);
                    cmd.Parameters.AddWithValue("@hp", txthp.Text);
                    cmd.Parameters.AddWithValue("@status", cbstatus.Text);

                    conn.Open();

                    TambahAktivitas("Menambah member: " + txtnama.Text);

                    cmd.ExecuteNonQuery();

                    MessageBox.Show("Data berhasil disimpan!");

                    TampilkanData();
                    UpdateTotalMember();

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
                // Ambil ID dari tabel lalu kurangi 100
                int idMember = Convert.ToInt32(
                    dataGridView1.CurrentRow.Cells["id_member"].Value
                ) - 100;

                // Validasi nomor HP
                if (txthp.Text.Length < 10 || txthp.Text.Length > 13)
                {
                    MessageBox.Show(
                        "Nomor HP harus 10 sampai 13 digit!",
                        "Validasi"
                    );

                    txthp.Focus();
                    return;
                }

                // Validasi nama
                if (!System.Text.RegularExpressions.Regex.IsMatch(
                    txtnama.Text,
                    "^[a-zA-Z ]+$"))
                {
                    MessageBox.Show(
                        "Nama hanya boleh huruf dan spasi!",
                        "Validasi Nama"
                    );

                    txtnama.Focus();
                    return;
                }

                // Validasi status
                if (cbstatus.SelectedIndex == -1)
                {
                    MessageBox.Show(
                        "Pilih status member terlebih dahulu!"
                    );

                    cbstatus.Focus();
                    return;
                }

                try
                {
                    using (SqlConnection conn =
                        new SqlConnection(connectionString))
                    {
                        SqlCommand cmd =
                        new SqlCommand(
                            "sp_UpdateMember",
                            conn
                        );

                        cmd.CommandType =
                            CommandType.StoredProcedure;

                        cmd.Parameters.AddWithValue(
                            "@id",
                            idMember
                        );

                        cmd.Parameters.AddWithValue(
                            "@nama",
                            txtnama.Text
                        );

                        cmd.Parameters.AddWithValue(
                            "@hp",
                            txthp.Text
                        );

                        cmd.Parameters.AddWithValue(
                            "@status",
                            cbstatus.Text
                        );

                        conn.Open();

                        int rowsAffected =
                            cmd.ExecuteNonQuery();

                        TambahAktivitas(
                            "Mengupdate member: "
                            + txtnama.Text
                        );

                        if (rowsAffected > 0)
                        {
                            MessageBox.Show(
                                "Data Member Berhasil Diupdate!",
                                "Sukses"
                            );

                            TampilkanData();

                            UpdateTotalMember();

                            txtnama.Clear();
                            txthp.Clear();

                            cbstatus.SelectedIndex = -1;
                        }
                        else
                        {
                            MessageBox.Show(
                                "Data gagal diupdate!" 
                            );
                        }
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show(
                        "Error Update: " + ex.Message
                    );
                }
            }
            else
            {
                MessageBox.Show(
                    "Pilih data member terlebih dahulu!"
                );
            }
        }

        private void txthapus_Click(object sender, EventArgs e)
        {
            if (dataGridView1.CurrentRow != null)
            {
                // Ambil nama member dari tabel
                string namaMember =
                    dataGridView1.CurrentRow.Cells["nama"]
                    .Value.ToString();

                // Konfirmasi hapus
                DialogResult dialogResult =
                    MessageBox.Show(
                        "Apakah Anda yakin ingin menghapus member: "
                        + namaMember + "?",
                        "Konfirmasi Hapus",
                        MessageBoxButtons.YesNo
                    );

                if (dialogResult == DialogResult.Yes)
                {
                    try
                    {
                        using (SqlConnection conn =
                            new SqlConnection(connectionString))
                        {
                            SqlCommand cmd =
                                new SqlCommand(
                                    "sp_DeleteMember",
                                    conn
                                );

                            cmd.CommandType =
                                CommandType.StoredProcedure;

                            cmd.Parameters.AddWithValue(
                                "@nama",
                                namaMember
                            );

                            conn.Open();

                            cmd.ExecuteNonQuery();

                            MessageBox.Show(
                                "Data Member Berhasil Dihapus",
                                "Informasi"
                            );
                        }

                        TambahAktivitas(
                            "Menghapus member: "
                            + namaMember
                        );

                        TampilkanData();

                        UpdateTotalMember();
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(
                            "Gagal menghapus data: "
                            + ex.Message
                        );
                    }
                }
            }
            else
            {
                MessageBox.Show(
                    "Silakan pilih data terlebih dahulu."
                );
            }
        }

        private void TampilkanData()
        {
            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    string query =
                        "SELECT * FROM vw_Member ORDER BY id_member ASC";

                    SqlDataAdapter da = new SqlDataAdapter(query, conn);

                    DataTable dt = new DataTable();

                    da.Fill(dt);

                    bs.DataSource = dt;
                    dataGridView1.DataSource = bs;
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
        DataGridViewRow row = dataGridView1.Rows[e.RowIndex];

        txtnama.Text = row.Cells["nama"].Value.ToString();
        txthp.Text = row.Cells["no_hp"].Value.ToString();
        cbstatus.Text = row.Cells["status_aktif"].Value.ToString();

        string idMember = row.Cells["id_member"].Value.ToString();
    }
}

        private void RefreshLogDatabase()
        {
            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    // Menampilkan 5 member terbaru
                    string query = @"
            SELECT TOP 5
            (id_member + 100) AS id_member,
            nama,
            no_hp,
            status_aktif
            FROM Member
            ORDER BY id_member DESC";

                    SqlDataAdapter da = new SqlDataAdapter(query, conn);

                    DataTable dt = new DataTable();

                    da.Fill(dt);

                    dataGridView2.DataSource = dt;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Gagal menampilkan member terbaru: " + ex.Message);
            }
        }

     

        private void BtnReset_Click(object sender, EventArgs e)
        {
            // Popup konfirmasi
            DialogResult result = MessageBox.Show(
                "Apakah anda ingin menghapus seluruh data?",
                "Konfirmasi Hapus",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Warning
            );

            // Jika user pilih YES
            if (result == DialogResult.Yes)
            {
                try
                {
                    using (SqlConnection conn = new SqlConnection(connectionString))
                    {
                        string query = "DELETE FROM Member";

                        SqlCommand cmd = new SqlCommand(query, conn);

                        conn.Open();
                        cmd.ExecuteNonQuery();
                    }

                    // Refresh kedua tabel
                    TampilkanData();
                  
                    UpdateTotalMember();

                    MessageBox.Show("Seluruh data berhasil dihapus!", "Informasi");
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Gagal menghapus data: " + ex.Message);
                }
            }
            else
            {
                MessageBox.Show("Penghapusan dibatalkan.", "Informasi");
            }
        }

        private void bindingNavigator1_RefreshItems(object sender, EventArgs e)
        {

        }
    }
}

       





