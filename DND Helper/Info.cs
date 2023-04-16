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
    public partial class Info : Form
    {
        public int ID = 0;
        public Info(int ID_c)
        {
            InitializeComponent();
            getInfo(ID_c);
            ID = ID_c;
            id_lb.Text = ID_c.ToString();
        }
        public void getInfo(int ID)
        {
            string query = "select name_c from hero where id_char=" + ID + ";";
            MySqlConnection conn = DBUtils.GetDBConnection();
            MySqlCommand cmDB = new MySqlCommand(query, conn);
            try
            {
                conn.Open();
                MySqlDataReader rd = cmDB.ExecuteReader();
                if (rd.HasRows)
                    while (rd.Read())
                    {
                        name_lb.Text =   rd.GetString(0);
                    }
                conn.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Возникла непредвиденная ошибка!" + Environment.NewLine + ex.Message);
            }
        }
        public void Info_TB(string query, TextBox box)
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
                        box.Text = rd.GetString(0);
                    }
                }
                conn.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Произошли технические накладки!" + Environment.NewLine + ex.Message);
            }
        }

        public void label(string txt,string query, Label label)
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
                        label.Text = txt + rd.GetString(0);
                    }
                }
                conn.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Произошла непредвиденная ошибка загрузкb!" + Environment.NewLine + ex.Message);
            }
        }

        public void getLists(string query, ListBox listBox)
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
                        listBox.Items.Add(rd.GetString(0));
                    }
                }
                conn.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Произошла непредвиденная ошибочка!" + Environment.NewLine + ex.Message);
            }
        }

        private void Info_Load(object sender, EventArgs e)
        {
            groupBox1.Parent = this;
            groupBox1.BackColor = Color.Transparent;
            label("Возраст героя: ","select age from hero where id_char = "+id_lb.Text+";",age_lb);
            label("Рост героя (см): ", "select height from hero where id_char = " + id_lb.Text + ";", height_lb);
            label("Цвет глаз: ", "select eye from hero where id_char = " + id_lb.Text + ";", eye_lb);
            label("Цвет кожи: ", "select skin from hero where id_char = " + id_lb.Text + ";", skin_lb);
            label("Цвет волос: ", "select hair from hero where id_char = " + id_lb.Text + ";", hair_lb);
            label("", "select name_race from race where id_race = (select id_race from hero where id_char =" + id_lb.Text + ");", race_lb);
            label("", "select name_class from classes where id_class = (select id_class from hero where id_char =" + id_lb.Text + ");", class_lb);
            label("", "select name_w from worldview where id_world = (select id_world from hero where id_char =" + id_lb.Text + ");", world_lb);
            label("", "select name_history from history where id_history = (select id_history from hero where id_char =" + id_lb.Text + ");", history_lb);
            Info_TB("select trait from hero where id_char = " + id_lb.Text + ";", trait_Tb);
            Info_TB("select ideal from hero where id_char = " + id_lb.Text + ";", ideal_Tb);
            Info_TB("select devotion from hero where id_char = " + id_lb.Text + ";", devotion_Tb);
            Info_TB("select weakness from hero where id_char = " + id_lb.Text + ";", weakness_Tb);
            Info_TB("select bio from hero where id_char = "+id_lb.Text+";",bio_Tb);
            label("", "select strenght from stat where id_stat=(select id_stat from hero where id_char =" + id_lb.Text + ");", strp_lb);
            label("", "select dextery from stat where id_stat=(select id_stat from hero where id_char =" + id_lb.Text + ");", dexp_lb);
            label("", "select constilution from stat where id_stat=(select id_stat from hero where id_char =" + id_lb.Text + ");", conp_lb);
            label("", "select intelligence from stat where id_stat=(select id_stat from hero where id_char =" + id_lb.Text + ");", intp_lb);
            label("", "select wisdom from stat where id_stat=(select id_stat from hero where id_char =" + id_lb.Text + ");", wisp_lb);
            label("", "select charisma from stat where id_stat=(select id_stat from hero where id_char =" + id_lb.Text + ");", chap_lb);
            label("", "select mod_po from modificator where stat_point=" + strp_lb.Text + ";", strm_lb);
            label("", "select mod_po from modificator where stat_point=" + dexp_lb.Text + ";", dexm_lb);
            label("", "select mod_po from modificator where stat_point=" + conp_lb.Text + ";", conm_lb);
            label("", "select mod_po from modificator where stat_point=" + intp_lb.Text + ";", intm_lb);
            label("", "select mod_po from modificator where stat_point=" + wisp_lb.Text + ";", wism_lb);
            label("", "select mod_po from modificator where stat_point=" + chap_lb.Text + ";", cham_lb);
            label("","select speed from race where name_race = '"+race_lb.Text+"';",speed_lb);
            label("", "select hitpoint from classes where name_class = '" + class_lb.Text + "';", hitpoint_lb);
            Info_TB("select equipment from hero where id_char = " + id_lb.Text + ";", invent_Tb);
            Info_TB("select abilites from hero where id_char = " + id_lb.Text + ";", ability_Tb);
            getLists("select name_skill from skills",skills_Lb);
            getLists("select skills.name_skill from skills join skill_list on skills.id_skill = skill_list.id_skill where skill_list.id_char = " + id_lb.Text + ";", skill_Lb);
        }

        private void race_lb_Click(object sender, EventArgs e)
        {
            Info_TB("select desc_race from race where name_race = '" + race_lb.Text + "';", info_Tb);
        }

        private void class_lb_Click(object sender, EventArgs e)
        {
            Info_TB("select desc_class from classes where name_class = '" + class_lb.Text + "';", info_Tb);
        }

        private void world_lb_Click(object sender, EventArgs e)
        {
            Info_TB("select desc_w from worldview where name_w = '" + world_lb.Text + "';", info_Tb);
        }

        private void history_lb_Click(object sender, EventArgs e)
        {
            Info_TB("select desc_history from history where name_history = '" + history_lb.Text + "';", info_Tb);
        }
    }
}
