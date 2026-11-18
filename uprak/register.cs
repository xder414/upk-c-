using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MySql.Data.MySqlClient;

namespace uprak
{
    public partial class register : Form
    {
        string connect = "server=localhost;port=3306;database=db_apotek_petugas; user=root;password";
        private object koneksi;

        public register()
        {
            InitializeComponent();
        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            string nama = textBox1.Text.Trim();
            string username = textBox2.Text.Trim();
            string password = textBox3.Text.Trim();
            string konfirmasi_password = textBox4.Text.Trim();
            string role = comboBox1.Text;

            if (nama == "" || username == "" || password == "" || konfirmasi_password == "" || role == "")
            {
                MessageBox.Show("semua field wajib di isi!", "warning", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            if (password != konfirmasi_password)
            {
                MessageBox.Show("konfirmasi password tidak sesuai !", "warning", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            try
            {
                using (MySqlConnection conn = koneksi.GetConnection())

                {
                    MySqlCommand cek = new MySqlCommand("Select count (*) FROM tb_apoteker WHERE username=@username", conn);
                    cek.Parameters.AddWithValue("@username", username);
                    if (Convert.ToInt32(cek.ExecuteScalar()) == 0)
                    {
                        MessageBox.Show("username sudah digunakan !", "warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        return;
                    }
                    MySqlCommand simpan = new MySqlCommand("insert into tb_apoteker(username,password,nama_petugas,shift,role,status_aktif) values (@username,@password,@nama,@shift,@role,1)", conn);
                    simpan.Parameters.AddWithValue("@username", username);
                    simpan.Parameters.AddWithValue("@password", password);
                    simpan.Parameters.AddWithValue("@nama", nama);
                    simpan.Parameters.AddWithValue("@password", password);
                    simpan.Parameters.AddWithValue("@konfirmasi_password", konfirmasi_password);
                    simpan.ExecuteNonQuery();

                    MessageBox.Show("register petugas apotek Berhasil !", "sukses", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    this.Close();
                    { 
                }

    

            }


    {
       

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();

        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

    }
}
