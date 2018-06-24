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
    public partial class Login_page : Form
    {
        Login login;
        List<Orders> newOrder;
        List<Person> person = new List<Person>();
        public Login_page(Login _login ,List<Orders> order)
        {
            newOrder = order;
            this.login = _login;
            InitializeComponent();
            
            person.AddRange(new Person[]{
                new Person
                {
                    Name="Lamia",
                    Email="lamia.adigozelli@icloud.com",
                    Password="123123",
                    Role=Role.Admin,

                },
                new Person
                {
                    Name="Lamia",
                    Email="lamia.adigozelli@gmail.com",
                    Password="123456",
                    Role=Role.User,

                },
            });
        }

        private void Login_page_Load(object sender, EventArgs e)
        {
            cmb_role.DataSource = Enum.GetNames(typeof(Role));
        }

        private void btn_login_Click(object sender, EventArgs e)
        {
            foreach (Person prs in person)
            {

                if (txt_email.Text == prs.Email)
                {
                    if ((txt_name.Text == prs.Name) && (txt_password.Text == prs.Password))
                    {
                        prs.Role = (Role)Enum.Parse(typeof(Role), cmb_role.SelectedItem.ToString());

                        if (prs.Role == Role.User)
                        {
                            User user = new User(login,prs.Name,newOrder);
                            user.Show();
                            this.Hide();
                        }
                        else if (prs.Role == Role.Admin)
                        {
                            
                            Admin admin = new Admin(login,newOrder);
                            admin.Show();
                            this.Hide();
                        }

                        MessageBox.Show("You are succesfull Logined");
                        break;
                    }
                    else
                    {

                        MessageBox.Show("Email or password invalid");
                        break;
                    }
                }

            }
        }

        private void Login_page_FormClosing(object sender, FormClosingEventArgs e)
        {
            login.Close();
        }
    }
}
