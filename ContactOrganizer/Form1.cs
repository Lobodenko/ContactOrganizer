using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics.Contracts;
using System.Drawing;
using System.Linq;
using System.Runtime.Remoting.Contexts;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ContactOrganizer
{
    public partial class Form1 : Form
    {
        private List<Contact> contacts;
        public Form1()
        {
            InitializeComponent();
            contacts = new List<Contact>();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string name = nameTextBox.Text;
            string phone = phoneTextBox.Text;
            string email = emailTextBox.Text;

            if (!string.IsNullOrEmpty(name) && !string.IsNullOrEmpty(phone))
            {
                contacts.Add(new Contact { Name = name, Phone = phone, Email = email });
                RefreshContactList();
                ClearInputFields();
            }
            else
            {
                MessageBox.Show("Please enter name and phone number.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (contactsListBox.SelectedIndex != -1)
            {
                Contact selectedContact = contacts[contactsListBox.SelectedIndex];
                selectedContact.Name = nameTextBox.Text;
                selectedContact.Phone = phoneTextBox.Text;
                selectedContact.Email = emailTextBox.Text;

                RefreshContactList();
                ClearInputFields();
            }
            else
            {
                MessageBox.Show("Please select a contact to edit.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (contactsListBox.SelectedIndex != -1)
            {
                contacts.RemoveAt(contactsListBox.SelectedIndex);
                RefreshContactList();
                ClearInputFields();
            }
            else
            {
                MessageBox.Show("Please select a contact to delete.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void RefreshContactList()
        {
            contactsListBox.Items.Clear();
            foreach (Contact contact in contacts)
            {
                contactsListBox.Items.Add(contact.Name);
            }
        }

        private void ClearInputFields()
        {
            nameTextBox.Clear();
            phoneTextBox.Clear();
            emailTextBox.Clear();
        }
    }
    public class Contact
    {
        public string Name { get; set; }
        public string Phone { get; set; }
        public string Email { get; set; }
    }
}
