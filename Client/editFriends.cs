﻿using System;
using System.Collections.Generic;
// using System.ComponentModel;
// using System.Data;
// using System.Drawing;
// using System.Linq;
// using System.Text;
// using System.Threading.Tasks;
using System.Windows.Forms;

namespace ClientSide
{
    public partial class editFriends : Form
    {
        public editFriends()
        {
            InitializeComponent();
        }

        private Form1 mainForm = null;
        public editFriends(Form callingForm)
        {
            mainForm = callingForm as Form1;
            InitializeComponent();
            refresh_lists();
        }

        public void refresh_lists()
        {
            listBox2.Items.Clear();
            listBox1.Items.Clear();

            List<string> ToBeExclude = new List<string>();
            ToBeExclude.Add(this.mainForm.getTbName());

            //Friends List
            int i = this.mainForm.getCountFRI();
            for (int x = 0; x < i; x++)
            {
                ToBeExclude.Add(this.mainForm.listFriendsX(x));
               listBox2.Items.Add(this.mainForm.listFriendsX(x));
               
            }

            //all users list
            int i1 = this.mainForm.allClientsCount();
            for (int x = 0; x < i1; x++)
            {
                //it should not print if
                //a) that user is friends
                //b) that user is requesting
                //c) yourself
                string temp351 = this.mainForm.listAllClinets(x);
                if (ToBeExclude.Contains(temp351) != true)
                {
                    listBox1.Items.Add(temp351);
                }
            }
        }

        private void addfriend_Click(object sender, EventArgs e)
        {
            // ads a friends from list of requests
            // 1. check if anything in listBox? have been selected
            // 2. encode message
            
            
            if (listBox1.SelectedIndex == -1)
            {
                MessageBox.Show("Please select a user first");
            }
            else
            {
                string c1 = listBox1.SelectedItem.ToString();
                string c2 = this.mainForm.getTbName();
                string temp = "@" + c1 + "@" + c2 + "@";
                // 3. store message in client master(setdirectlyToServer(string a))
                this.mainForm.setdirectlyToServer(temp);
                // 4. trigger send button(this.mainForm.sendButton())
                this.mainForm.sendButton();
                refresh_lists();
            }
        }

        private void removefriend_Click(object sender, EventArgs e)
        {
            //remove this function. We don't have enough time
            // removes a friend from list of friends and ads it to the list of others
            // 1. check if anything in listBox? have been selected
            // 2. encode message
            // 3. store message in client master(setdirectlyToServer(string a))
            // 4. trigger send button(this.mainForm.sendButton())
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnRefresh_Click(object sender, EventArgs e)
        {
            refresh_lists();
        }

       
    }
}
