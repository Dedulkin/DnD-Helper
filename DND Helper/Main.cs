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
    public partial class Main : Form
    {
        public int ID = 0;
        public Main(int ID_log)
        {
            InitializeComponent();
            getInfo(ID_log);
            ID = ID_log;
            
        }
        public void getInfo(int ID)
        {
            string query = "select nick from profile where id_prof=" + ID + ";";
            MySqlConnection conn = DBUtils.GetDBConnection();
            MySqlCommand cmDB = new MySqlCommand(query, conn);
            try
            {
                conn.Open();
                MySqlDataReader rd = cmDB.ExecuteReader();
                if (rd.HasRows)
                    while (rd.Read())
                    {
                        hello_lb.Text = "Добро пожаловать в мою таверну, " + rd.GetString(0) + "!";
                        label1.Text = "Вот список созданных вами героев, "+rd.GetString(0)+ ":";
                    }
                conn.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Возникла непредвиденная ошибка!" + Environment.NewLine + ex.Message);
            }
        }
        

        private void Main_Load(object sender, EventArgs e)
        {
            DGV("select hero.id_char, profile.id_prof, char_list.id_prof, char_list.id_char, name_c as 'Имя персонажа', classes.name_class as 'Класс', date_create as 'Дата создания' from hero join char_list on hero.id_char = char_list.id_char join profile on profile.id_prof = char_list.id_prof join classes on hero.id_class = classes.id_class where char_list.id_prof = "+ID+";", charlist_DGV);
            this.ShowIcon = false;
            hello_lb.Parent = this;
            hello_lb.BackColor = Color.Transparent;
            dialog_lb.Parent = this;
            dialog_lb.BackColor = Color.Transparent;
            label1.BackColor = Color.Transparent;
            panel1.Parent = this;
            panel1.BackColor = Color.Transparent;
            pictureBox1.Parent = this;
            pictureBox1.BackColor = Color.Transparent;
            
            Random random = new Random();
            int i = random.Next(1, 6);
            switch (i)
            {
                case 1:
                    dialog_lb.Text = "Какого героя хотите создать сегодня?";
                   
                    break;
                case 2:
                    dialog_lb.Text = "Пришли проведать свои творения?";
                    
                    break;
                case 3:
                    dialog_lb.Text = "Хотитите анекдот? А я всё равно бы рассказал, так вот:" + Environment.NewLine + "Гном гному: - Вы называете свою цену. Я называю свою цену. Потом мы оба смеемся и приступаем к серьезному разговору.";
                    
                    break;
                case 4:
                    dialog_lb.Text = "Прекрасная погода чтобы создать пару героев не так ли? Ну или злодеев как минимум...";
                   
                    break;
                case 5:
                    dialog_lb.Text = "Представляете, на днях заходил наёмник с двумя мечами, приставал ко всем посетителям с просьбой сыграть в карты, пришлось его выгнать";
                    
                    break;
            }
            

        }

        public void DGV(string query, DataGridView dgv)
        {
            MySqlConnection conn = DBUtils.GetDBConnection();
            MySqlDataAdapter sda = new MySqlDataAdapter(query, conn);
            DataTable dt = new DataTable();
            try
            {
                conn.Open();
                sda.Fill(dt);
                dgv.DataSource = dt;
                dgv.ClearSelection();
                dgv.Columns[0].Visible = false;
                dgv.Columns[1].Visible = false;
                dgv.Columns[2].Visible = false;
                dgv.Columns[3].Visible = false;
                dgv.Columns[4].ReadOnly = true;
                dgv.Columns[5].ReadOnly = true;
                dgv.Columns[6].ReadOnly = true;
                conn.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Произошла непредвиденая ошибка!" + Environment.NewLine + ex.Message);
            }
        }

        private void Main_FormClosing(object sender, FormClosingEventArgs e)
        {
            Application.Exit();
        }

        private void add_btn_Click(object sender, EventArgs e)
        {
            Add add = new Add(ID) { TopLevel = false, TopMost = true };
            panel1.Controls.Clear();
            panel1.Controls.Add(add);
            add.BringToFront();
            add.Show();
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            DGV("select hero.id_char, profile.id_prof, char_list.id_prof, char_list.id_char, name_c as 'Имя персонажа', classes.name_class as 'Класс', date_create as 'Дата создания' from hero join char_list on hero.id_char = char_list.id_char join profile on profile.id_prof = char_list.id_prof join classes on hero.id_class = classes.id_class where char_list.id_prof = " + ID + ";", charlist_DGV);
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
                MessageBox.Show("Произошли технические накладки!" + Environment.NewLine + ex.Message);
            }
        }

        private void del_btn_Click(object sender, EventArgs e)
        {
            try
            {
                panel1.Controls.Clear();
                DialogResult result = MessageBox.Show("Вы уверенны что хотите удалить этого героя? Вернуть его из небытия после удаления не выйдет.", "Удаление персонажа", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
                if (result == DialogResult.Yes)
                {
                    doAction("delete from char_list where id_char = " + charlist_DGV[0, charlist_DGV.CurrentRow.Index].Value.ToString() + ";");
                    doAction("delete from skill_list where id_char = " + charlist_DGV[0, charlist_DGV.CurrentRow.Index].Value.ToString() + ";");


                    label("select id_stat from hero where id_char = " + charlist_DGV[0, charlist_DGV.CurrentRow.Index].Value.ToString() + ";", label2);

                    doAction("delete from hero where id_char = " + charlist_DGV[0, charlist_DGV.CurrentRow.Index].Value.ToString() + ";");
                    doAction("delete from stat where id_stat = " + label2.Text + ";");
                    MessageBox.Show("Герой был удалён. Приятного дня!");

                }
            }
            catch
            {
                MessageBox.Show("Чтобы кого-то удалить, надо кого-то создать.");
            }
            
            
        }
        public void label(string query, Label label)
        {
            MySqlConnection conn = DBUtils.GetDBConnection();
            MySqlCommand cmDB = new MySqlCommand(query, conn);
            try
            {
                conn.Open();
                MySqlDataReader rd = cmDB.ExecuteReader();
                if (rd.HasRows)
                {
                    while (rd.Read())
                    {
                        label.Text = rd.GetString(0);
                    }
                }
                conn.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Произошла непредвиденная ошибка загрузкb!" + Environment.NewLine + ex.Message);
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try 
            {
                int id_c = Int32.Parse(charlist_DGV[0, charlist_DGV.CurrentRow.Index].Value.ToString());
                Info info = new Info(id_c) { TopLevel = false, TopMost = true };
                panel1.Controls.Clear();
                panel1.Controls.Add(info);
                info.BringToFront();
                info.Show();
            }
            catch
            {
                MessageBox.Show("Чтобы что-то узнать о персонаже, стоило бы его для начала создать.");
            }
        }
    }
}
