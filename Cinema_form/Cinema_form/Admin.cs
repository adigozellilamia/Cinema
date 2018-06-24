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
    public partial class Admin : Form
    {
        List<Orders> order;
        Login form;
        public Admin(Login _login,List<Orders> _order)
        {
            this.order = _order;
            this.form = _login;
            InitializeComponent();
        }

        private void Admin_Load(object sender, EventArgs e)
        {
            int top = 50;
            int left = 50;
            int count = 1;
            for (var i = 0; i < 5; i++)
            {

                for (var j = 0; j < 6; j++)
                {
                    Button button = new Button();
                    button.Top += top;
                    button.Size = new Size(50, 50);
                    button.Left += left;
                    left += 50;
                    Controls.Add(button);
                    button.Text += count;
                    count += 1;
                    foreach (Orders btn in order)
                    {
                        if (btn.Text == button.Text)
                        {
                            button.BackColor = Color.Red;
                            button.ForeColor = Color.White;
                            button.Enabled = false;
                        }
                    }
                    


                }
                left = 50;
                top += 50;
            }
        }

        private void Admin_FormClosing(object sender, FormClosingEventArgs e)
        {
            Login_page login_page = new Login_page(form, order);

            login_page.Show();
            this.Hide();
        }
    }
}
