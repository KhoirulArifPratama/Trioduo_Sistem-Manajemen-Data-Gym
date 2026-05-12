1. FORM KONEKSI
   <img width="373" height="87" alt="image" src="https://github.com/user-attachments/assets/8117cf47-7784-423d-8e26-5ffdc526bfad" />

Form Koneksi Database pada aplikasi **Sistem Manajemen Data Gym** digunakan untuk memastikan aplikasi berhasil terhubung dengan database SQL Server sebelum proses pengolahan data dilakukan. Form ini berfungsi sebagai penghubung antara aplikasi Windows Forms dengan database DB_Gym menggunakan class `SqlConnection`.

Saat aplikasi dijalankan, sistem akan melakukan pengecekan koneksi database secara otomatis melalui event `Form_Load`. Jika koneksi berhasil, maka sistem akan menampilkan status “Connected to DB_Gym” dengan warna hijau sebagai indikator bahwa database dapat diakses dengan baik. Sebaliknya, apabila koneksi gagal, sistem akan menampilkan status “Disconnect” dengan warna merah disertai pesan error untuk membantu proses identifikasi masalah koneksi.

Koneksi database pada aplikasi menggunakan *connection string* berikut:

```csharp
string connectionString =
"Data Source=KHRLFTAMA\\ARIF;Initial Catalog=DB_Gym;Integrated Security=True";
```

## Fungsi Utama Form Koneksi

* Menghubungkan aplikasi dengan database SQL Server
* Memastikan database dapat diakses sebelum proses CRUD dijalankan
* Menampilkan status koneksi database kepada pengguna
* Menangani error koneksi menggunakan metode `try-catch`

## Implementasi yang Digunakan

Dalam proses koneksi database, aplikasi memanfaatkan beberapa class utama dari `System.Data.SqlClient`, yaitu:

* `SqlConnection`
* `SqlCommand`
* `SqlDataAdapter`

Dengan adanya Form Koneksi Database ini, proses pengelolaan data member gym dapat berjalan secara real-time, terstruktur, dan terintegrasi langsung dengan database SQL Server sehingga meningkatkan efisiensi pengolahan data pada aplikasi.


2. FORM INPUT DATA
   <img width="798" height="472" alt="image" src="https://github.com/user-attachments/assets/c8a409f3-40ae-40f2-b8d1-aaf93bd06ede" />

Form Input Data Member merupakan halaman utama pada aplikasi **Sistem Manajemen Data Gym yang digunakan untuk mengelola data member secara digital. Form ini terhubung langsung dengan database SQL Server sehingga seluruh proses pengolahan data dapat dilakukan secara real-time.

Pada form ini, admin dapat melakukan proses:

* Menambahkan data member
* Mengupdate data member
* Menghapus data member
* Mencari data member
* Melihat daftar member
* Melihat total member

Data yang dikelola meliputi:

* Nama Member
* Nomor HP
* Status Member (Aktif / Non-Aktif)

## Validasi Input

Sistem dilengkapi dengan validasi untuk menjaga kualitas data yang dimasukkan, yaitu:

* Nama hanya boleh berisi huruf dan spasi
* Nomor HP hanya boleh angka
* Nomor HP minimal 10 digit dan maksimal 13 digit
* Status member wajib dipilih

## Implementasi Database

Pada form ini, proses manipulasi data sudah menerapkan:

* Stored Procedure untuk proses Insert, Update, Delete, dan Search
* View SQL Server untuk menampilkan data member
* Binding DataGridView untuk menghubungkan data ke tabel
* Binding Navigator untuk navigasi data

## Keamanan Sistem

Aplikasi juga menerapkan pencegahan SQL Injection menggunakan:

* Parameterized Query
* Stored Procedure
* SqlParameter (`AddWithValue`)

Dengan adanya form ini, proses pengelolaan data member gym menjadi lebih cepat, terstruktur, dan aman.

3. FORM TAMPILAN DATA
   <img width="800" height="479" alt="image" src="https://github.com/user-attachments/assets/e27d1a0e-7caf-4d25-a093-6ba24f9411af" />
   
Form Tampilan Data Member pada aplikasi **Sistem Manajemen Data Gym digunakan untuk menampilkan seluruh data member yang tersimpan di dalam database SQL Server. Form ini memudahkan admin dalam melihat, memilih, dan mengelola data member secara langsung melalui komponen `DataGridView`.

Data yang ditampilkan meliputi:

* ID Member
* Nama Member
* Nomor HP
* Status Member

Proses penampilan data dilakukan dengan mengambil data dari **View SQL Server** bernama `vw_Member`. Penggunaan View bertujuan untuk mempermudah pengelolaan query serta meningkatkan struktur pengambilan data pada aplikasi.

Selain menampilkan data, form ini juga mendukung beberapa fitur tambahan seperti:

* Menampilkan total member
* Memilih data member melalui tabel
* Menampilkan data secara real-time
* Navigasi data menggunakan `BindingNavigator`
* Pencarian data member

## Implementasi Binding DataGridView

Pada form ini, `DataGridView` telah menerapkan konsep Binding menggunakan `BindingSource`. Tujuan penggunaan binding adalah agar data dari database dapat terhubung langsung dengan tabel dan mempermudah proses navigasi data.

Contoh implementasi binding:

```csharp
BindingSource bs = new BindingSource();
bs.DataSource = dt;
dataGridView1.DataSource = bs;
bindingNavigator1.BindingSource = bs;
```

## Fungsi Utama Form Tampilan Data

* Menampilkan seluruh data member
* Menghubungkan data database ke `DataGridView`
* Mempermudah proses pencarian dan pemilihan data
* Menampilkan data secara terstruktur dan rapi
* Mendukung navigasi data menggunakan `BindingNavigator`

Dengan adanya Form Tampilan Data Member ini, proses pengelolaan data pada aplikasi menjadi lebih efektif, interaktif, dan mudah digunakan oleh admin gym.


4. Bukti INSERT, UPDATE, DELETE, dan SEARCH
   * INSERT
     <img width="798" height="485" alt="image" src="https://github.com/user-attachments/assets/ff44aa74-3b8c-452b-9afb-faf3debc8c83" />
     <img width="804" height="478" alt="image" src="https://github.com/user-attachments/assets/907cae27-2650-4f02-b023-09274e528218" />

   * UPDATE
     <img width="800" height="478" alt="image" src="https://github.com/user-attachments/assets/7673f611-e5ac-4116-8c06-3cdeb523cc97" />
     <img width="794" height="480" alt="image" src="https://github.com/user-attachments/assets/5d5c0f9a-ad09-49ed-abcf-3c15c7e1b77d" />
     
   * DELETE
     <img width="793" height="480" alt="image" src="https://github.com/user-attachments/assets/da3b10bf-4147-44b0-813a-7451b039ce84" />
     <img width="800" height="481" alt="image" src="https://github.com/user-attachments/assets/11cdc557-aeff-4eac-97e0-17735c583cd6" />

   * SEARCH
     <img width="797" height="430" alt="image" src="https://github.com/user-attachments/assets/5cdbe3a3-7ff2-431c-a2b5-4f703a413375" />
     <img width="800" height="469" alt="image" src="https://github.com/user-attachments/assets/adc28300-3754-4714-b59e-480aaead2f42" />

Pada aplikasi Sistem Manajemen Data Gym, proses pengolahan data member telah menerapkan konsep CRUD (Create, Read, Update, Delete) yang terhubung langsung dengan database SQL Server. Seluruh proses manipulasi data dilakukan menggunakan Stored Procedure untuk meningkatkan keamanan, kerapihan query, dan efisiensi pengolahan data.

# 1. INSERT Data Member

Fitur Insert digunakan untuk menambahkan data member baru ke dalam database. Data yang dimasukkan meliputi:

* Nama Member
* Nomor HP
* Status Member

Proses penyimpanan data dilakukan menggunakan Stored Procedure `sp_InsertMember`. Sebelum data disimpan, sistem akan melakukan validasi input seperti:

* Nama hanya boleh huruf dan spasi
* Nomor HP hanya boleh angka
* Panjang nomor HP minimal 10 digit dan maksimal 13 digit

Setelah data berhasil disimpan, sistem akan:

* Menampilkan pesan berhasil
* Memperbarui tabel data member
* Memperbarui total member
* Menambahkan aktivitas pada log aktivitas


# 2. UPDATE Data Member

Fitur Update digunakan untuk mengubah data member yang sudah tersimpan di database. Sistem akan mengambil data berdasarkan `id_member` yang dipilih pada `DataGridView`.

Proses update dilakukan menggunakan Stored Procedure `sp_UpdateMember`. Setelah proses berhasil dilakukan, sistem akan:

* Memperbarui tampilan data
* Memperbarui total member
* Menampilkan aktivitas update pada tabel aktivitas

Validasi data juga diterapkan sebelum proses update dilakukan untuk menjaga konsistensi data pada database.


# 3. DELETE Data Member

Fitur Delete digunakan untuk menghapus data member dari database berdasarkan data yang dipilih pada tabel.

Sebelum proses penghapusan dilakukan, sistem akan menampilkan konfirmasi terlebih dahulu untuk mencegah kesalahan penghapusan data.

Proses delete menggunakan Stored Procedure `sp_DeleteMember`. Setelah data berhasil dihapus, sistem akan:

* Memperbarui tabel data member
* Memperbarui total member
* Menambahkan aktivitas penghapusan pada log aktivitas


# 4. SEARCH Data Member

Fitur Search digunakan untuk mencari data member secara cepat berdasarkan nama member yang dimasukkan pada textbox pencarian.

Pencarian dilakukan menggunakan Stored Procedure `sp_SearchMember` dengan parameter pencarian yang dikirim dari aplikasi menggunakan `SqlParameter`.

Hasil pencarian akan langsung ditampilkan secara real-time pada `DataGridView` sehingga mempermudah admin dalam menemukan data member tertentu.


5. SQL INJECTION
   <img width="798" height="475" alt="Screenshot 2026-05-11 194617" src="https://github.com/user-attachments/assets/aa0f64e7-2193-4e7e-a9bb-6ae320a7a7c7" />
   ## Pencegahan SQL Injection

Pada aplikasi Sistem Manajemen Data Gym, sistem keamanan database telah menerapkan metode pencegahan SQL Injection menggunakan **Parameterized Query** dan **Stored Procedure** pada proses pencarian data member (Search Member).

SQL Injection adalah teknik serangan yang dilakukan dengan memasukkan perintah SQL berbahaya melalui form input untuk memanipulasi database secara ilegal. Jika aplikasi tidak memiliki validasi keamanan yang baik, maka data pada database dapat dicuri, diubah, bahkan dihapus.

Untuk mencegah hal tersebut, aplikasi menggunakan parameter SQL melalui `SqlCommand` sehingga input dari pengguna tidak akan dieksekusi sebagai perintah SQL.

### Implementasi Pencegahan SQL Injection

Fitur pencarian member menggunakan Stored Procedure `sp_SearchMember` dan parameter `@keyword`.

```csharp
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
```

### Stored Procedure SQL Server

```sql
CREATE PROCEDURE sp_SearchMember
    @keyword VARCHAR(100)
AS
BEGIN
    SELECT *
    FROM Member
    WHERE nama LIKE '%' + @keyword + '%'
END
```

### Skenario SQL Injection

Pengujian dilakukan dengan memasukkan karakter SQL Injection pada form pencarian, contohnya:

```sql
' OR '1'='1
```

### Hasil Pengujian

Sistem tidak menjalankan input tersebut sebagai perintah SQL, melainkan hanya sebagai teks pencarian biasa. Data pada database tetap aman dan aplikasi tidak mengalami manipulasi query.




     






     

     

   





   
