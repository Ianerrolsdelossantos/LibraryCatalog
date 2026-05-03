using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using LibraryCatalog;



namespace LibraryCatalog
{
    public partial class Form1 : Form
    {

        List<Book> books = new List<Book>();



        public Form1()
        {
            InitializeComponent();
            books.Add(new Book("001", "Naruto", "Masashi Kishimoto", 1999));
            books.Add(new Book("002", "One Piece", "Eiichiro Oda", 1997));
            books.Add(new Book("003", "Bleach", "Tite Kubo", 2001));

            dataGridView1.Rows.Add("001", "Naruto", "Masashi Kishimoto", 1999, "Available");
            dataGridView1.Rows.Add("002", "One Piece", "Eiichiro Oda", 1997, "Available");
            dataGridView1.Rows.Add("003", "Bleach", "Tite Kubo", 2001, "Available");

        }


        private void button1_Click(object sender, EventArgs e)
        {
            int year;

            if (!int.TryParse(txtYear.Text, out year))
                return;

            Book b = new Book(
                txtISBN.Text,
                txtTitle.Text,
                txtAuthor.Text,
                year
            );

            books.Add(b);

            dataGridView1.Rows.Add(
                b.ISBN,
                b.Title,
                b.Author,
                b.YearPublished,
                "Available"
            );
        }




        private void Barrowbtn_Click(object sender, EventArgs e)
        {
            if (dataGridView1.CurrentRow == null)
                return;

            int index = dataGridView1.CurrentRow.Index;

            if (index < 0 || index >= books.Count)
                return;

            string result = books[index].Borrowly();

            if (result == "Already Borrowed")
            {
                MessageBox.Show(result);
                return;
            }

          
            dataGridView1.Rows[index].DefaultCellStyle.BackColor = Color.LightGray;
        }


        private void button2_Click(object sender, EventArgs e)
        {
            txtISBN.Clear();
            txtTitle.Clear();
            txtAuthor.Clear();
            txtYear.Clear();

            txtISBN.Focus();
        }
        

        private void Returnbtn_Click(object sender, EventArgs e)
        {
            if (dataGridView1.CurrentRow == null)
                return;

            int index = dataGridView1.CurrentRow.Index;

           
            if (index < 0 || index >= books.Count)
                return;

            string result = books[index].Returnly();

            if (result == "Not Borrowed")
            {
                MessageBox.Show(result);
                return;
            }

            
            dataGridView1.Rows[index].DefaultCellStyle.BackColor = Color.White;

          
            MessageBox.Show("Book returned successfully!");
        }


        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }
    }
}





