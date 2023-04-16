using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MySql.Data.MySqlClient;

namespace DND_Helper
{
    public partial class Reg : Form
    {
        public Reg()
        {
            InitializeComponent();
        }

        private void reg_btn_Click(object sender, EventArgs e)
        {
            if (user_tB.Text == "" || log_tB.Text == "" || pswrd_tB.Text == "")
            {
                MessageBox.Show("Поля не могут быть пустыми. Повторите попытку.");
            }
            else
            {
                try
                {
                    doAction("insert into log (log) values('" + log_tB.Text + "');");
                    doAction("insert into pswrd (pswrd) values('" + pswrd_tB.Text + "');");
                    doAction("insert into profile (nick, id_pswrd, id_log) values( '" + user_tB.Text + "', (select max(id_pswrd) from pswrd), (select max(id_log) from log));");
                    MessageBox.Show("Добавлен новый аккаунт.  Возращайтесь и авторизируйтесь.");
                }
                catch
                {
                    MessageBox.Show("При создании аккаунта возникла ошибка попробуйте ещё раз!");
                }
            }
        }
        public void doAction(string query)
        {
            MySqlConnection conn = DBUtils.GetDBConnection();
            MySqlCommand cmDB = new MySqlCommand(query, conn);
            try
            {
                conn.Open();
                cmDB.ExecuteReader();
                conn.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Произошли технические шоколадки!" + Environment.NewLine + ex.Message);
            }
        }
    }
}
