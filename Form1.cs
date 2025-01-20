using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Note_Taking_App
{
    public partial class NoteTaker : Form
    {
        DataTable notes = new DataTable();
        bool editing = false;

        public NoteTaker()
        {
            InitializeComponent();
        }

        private void NoteTaker_Load(object sender, EventArgs e)
        {
            notes.Columns.Add("Title");
            notes.Columns.Add("Notes");

            PreviousNotes.DataSource = notes;
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            titleBox.Text = "";
            noteBox.Text = "";
            ReactionImage.BackgroundImage = null;
        }

        private void DeleteButton_Click(object sender, EventArgs e)
        {
            try
            {
                notes.Rows[PreviousNotes.CurrentCell.RowIndex].Delete();
            }
            catch(Exception ex) { Console.WriteLine("Not a valid note!!"); }

            ReactionImage.BackgroundImage = statusimages.Images[2];
        }

        private void button2_Click(object sender, EventArgs e)
        {
            titleBox.Text = notes.Rows[PreviousNotes.CurrentCell.RowIndex].ItemArray[0].ToString();
            noteBox.Text = notes.Rows[PreviousNotes.CurrentCell.RowIndex].ItemArray[1].ToString();
            editing = true;
            ReactionImage.BackgroundImage = statusimages.Images[0];
        }

        private void PreviousNotes_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void SaveButton_Click(object sender, EventArgs e)
        {
            if(editing)
            {
                notes.Rows[PreviousNotes.CurrentCell.RowIndex]["Title"] = titleBox.Text;
                notes.Rows[PreviousNotes.CurrentCell.RowIndex]["Notes"] = noteBox.Text;
            }
            else
            {
                notes.Rows.Add(titleBox.Text, noteBox.Text);
            }

            titleBox.Text = "";
            noteBox.Text = "";
            editing = false;

            ReactionImage.BackgroundImage = statusimages.Images[1];

        }

        private void PreviousNotes_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            titleBox.Text = notes.Rows[PreviousNotes.CurrentCell.RowIndex].ItemArray[0].ToString();
            noteBox.Text = notes.Rows[PreviousNotes.CurrentCell.RowIndex].ItemArray[1].ToString();
            editing = true;
            ReactionImage.BackgroundImage = statusimages.Images[0];
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}
