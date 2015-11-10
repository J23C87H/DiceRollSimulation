using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DiceSimulation1
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            //Clear list for new roll
            listView1.Items.Clear();

            //Setup random
            Random shooter = new Random();

            //Setup counter for For loop
            for (int i = 1; i <= 100; ++i)
            {
                String result;
                int die1, die2, die1Value, die2Value;

                //Roll both dice
                die1 = shooter.Next(6);
                die2 = shooter.Next(6);

                //Increase both dice by 1 to get dice value
                die1Value = die1 + 1;
                die2Value = die2 + 1;

                //Change image for each Die to represent the number rolled
                lbl_die1.ImageIndex = die1;
                lbl_die2.ImageIndex = die2;

                //if statement to determine if both dice were the same number
                if (die1Value == die2Value)
                {
                    result = "On roll number " + i.ToString() + " both dice rolled " + die1Value.ToString() + "'s";
                    string[] row = { i.ToString(), die1Value.ToString(), die2Value.ToString(), result };
                    var listViewItem = new ListViewItem(row);
                    listView1.Items.Add(listViewItem);
                    //force application to update
                    Application.DoEvents();
                }
                else
                {

                    string[] row = { i.ToString(), die1Value.ToString(), die2Value.ToString() };
                    var listViewItem = new ListViewItem(row);
                    listView1.Items.Add(listViewItem);
                    //force application to update
                    Application.DoEvents();
                }

                //Force thread to sleep to create a pause between each for loop
                System.Threading.Thread.Sleep(600);
            }
        }


        private void button2_Click(object sender, EventArgs e)
        {
            //Clear list view without re-rolling
            listView1.Items.Clear();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            //alternate close application
            this.Close();
        }
    }
}
