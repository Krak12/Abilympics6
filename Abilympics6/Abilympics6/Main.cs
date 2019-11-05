using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Abilympics6
{
    public partial class Main : Form
    {
        public Main()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            // настройка ввода логина и пароля
            var userTA = new dbDataSetTableAdapters.WorkersTableAdapter();
            var users = userTA.GetDataByLoginAndPass(textBox1.Text, textBox2.Text);

            if (users.Count == 0)
            {
                MessageBox.Show("Неверный логин или пароль! Повторите попытку ввода.", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            // переходы по формам, зависящие от TypeAcc
            Data.UserAutorized = userTA.GetDataByLogin(textBox1.Text).First();

            if (Data.UserAutorized.TypeAcc == 1)
            {
                Form cm = new CreatorMenu();
                Hide();
                DialogResult res = cm.ShowDialog();
                if (res != DialogResult.Cancel)
                {
                    Show();
                }
                else Close();
            }
            else if (Data.UserAutorized.TypeAcc == 2)
            {
                Form sm = new SpecialistMenu();
                Hide();
                DialogResult res = sm.ShowDialog();
                if (res != DialogResult.Cancel)
                {
                    Show();
                }
                else Close();
            }
            else if (Data.UserAutorized.TypeAcc == 3)
            {
                Form tm = new TechnicianMenu();
                Hide();
                DialogResult res = tm.ShowDialog();
                if (res != DialogResult.Cancel)
                {
                    Show();
                }
                else Close();
            }
        }

        // настройка функции "Показать пароль"
        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            textBox2.UseSystemPasswordChar = !checkBox1.Checked;
        }

        private void Main_Load(object sender, EventArgs e)
        {
            textBox2.UseSystemPasswordChar = true;
        }
    }
}
