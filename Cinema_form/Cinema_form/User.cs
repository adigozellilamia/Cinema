using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Cinema_form
{
    public partial class User : Form
    {
        List<Orders> order = new List<Orders>();
        
        string Name;
        Login form;
        public User(Login _login,string _Name, List<Orders> _order)
        {
            
            this.Name = _Name;
            this.form = _login;
            InitializeComponent();
           
            if (_order != null)
            {
                order = _order;
            }else
            {
                order.AddRange(new Orders[]{
                new Orders
                {
                    Text="15",
                },

                new Orders
                {
                    Text="16",
                }

            });
            }
        }

        private void User_Load(object sender, EventArgs e)
        {
           
            int top = 50;
            int left = 50;
            int count = 1;
            for (var i = 0; i < 5; i++)
            {
                
                for (var j=0; j < 6; j++)
                {
                    Button button = new Button();
                    button.Top += top;
                    button.Size = new Size(50, 50);
                    button.Left += left;
                    left += 50;
                    Controls.Add(button);
                    button.Text += count;
                    count+=1;
                    foreach (Orders btn in order)
                    {
                        if (btn.Text == button.Text)
                        {
                            button.BackColor = Color.Red;
                            button.ForeColor = Color.White;
                            button.Enabled = false;
                        }
                    }
                    button.Click += Lamie;
                    

                }
                left = 50;
                top += 50;
            }
        }

        private void Lamie(object sender, EventArgs e)
        {
            Button btn = sender as Button;
            MessageBox.Show(Name +" "+ btn.Text + " Ordered");
            btn.BackColor = Color.Red;
            btn.ForeColor = Color.White;
            Orders _btn = new Orders();
            _btn.Text = btn.Text;
            this.order.Add(_btn);
            btn.Enabled = false;
        }
        private void User_FormClosing(object sender, FormClosingEventArgs e)
        {
            Login_page login_Page = new Login_page(form,order );
            login_Page.Show();
            this.Hide();
        }
    }
}
