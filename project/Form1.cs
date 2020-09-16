using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Threading;
using System.Data.SqlClient;

namespace WindowsFormsApp2
{
    public partial class Form1 : Form
    {
        int c = 1, w = 0, p = 0,w1=0,w2=0,l1=0,l2=0,g=0,an,bn,cn;
        SqlConnection Con = new SqlConnection();
        SqlCommand Cmd = new SqlCommand();

        public Form1()
        {
            InitializeComponent();
            panel1.Visible = false;
            button6.Visible = false;
            label2.Visible = false;
            label3.Visible = false;
            textBox2.Visible = false;
            label4.Visible = false;
            panel2.Visible = false;
            button7.Text = "";
            button8.Text = "";
            button9.Text = "";
            button10.Text = "";
            button11.Text = "";
            button12.Text = "";
            button13.Text = "";
            button14.Text = "";
            button15.Text = "";
            textBox1.Text = "";
            textBox2.Text = "";
            panel3.Visible = false;

        }

        private void button1_Click(object sender, EventArgs e)
        {
            panel1.Visible = true;
            button6.Visible = false;
            label2.Visible = false;
            textBox2.Visible = false;
            label3.Visible = true;
            label1.Visible = false;
            label4.Visible = true;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            panel1.Visible = true;
            button6.Visible = true;
            label2.Visible = false;
            label3.Visible = false;
            textBox2.Visible = false;
            label1.Visible = true;
            label4.Visible = false;
            textBox2.Text = "COMPUTER";
            p = 1;
            button7.Text = "";
            button8.Text = "";
            button9.Text = "";
            button10.Text = "";
            button11.Text = "";
            button12.Text = "";
            button13.Text = "";
            button14.Text = "";
            button15.Text = "";
            textBox1.Text = "";
           

        }

        private void button3_Click(object sender, EventArgs e)
        {
            panel1.Visible = true;
            button6.Visible = true;
            label2.Visible = true;
            label3.Visible = false;
            textBox2.Visible = true;
            label1.Visible = true;
            label4.Visible = false;
            p = 0;
            button7.Text = "";
            button8.Text = "";
            button9.Text = "";
            button10.Text = "";
            button11.Text = "";
            button12.Text = "";
            button13.Text = "";
            button14.Text = "";
            button15.Text = "";
            textBox1.Text = "";
            textBox2.Text = "";
            label2.Text = "PLAYER 2";

        }

        private void label10_Click(object sender, EventArgs e)
        {
            Con.Open();
            String st = "select * from gamer where ID='" + textBox3.Text + "'";
            Cmd = new SqlCommand(st, Con);
            SqlDataReader dr = Cmd.ExecuteReader();
            if (dr.Read())
            {
                an = int.Parse(dr["WIN"].ToString());
                bn = int.Parse(dr["LOSE"].ToString());
                cn = int.Parse(dr["NOGP"].ToString());

            }
            label11.Text="WINS="+ an;
            label12.Text = "LOSE=" + bn;
            label13.Text = "GAMES PLAYED=" + cn;
            Con.Close();

        }

        private void button18_Click(object sender, EventArgs e)
        {
            panel1.Visible = false;
            panel2.Visible = false;
            panel3.Visible = false;
        }

        private void label13_Click(object sender, EventArgs e)
        {

        }

        private void button4_Click(object sender, EventArgs e)
        {
            panel1.Visible = true;
            panel2.Visible = true;
            panel3.Visible = true;
        }

        private void label3_Click(object sender, EventArgs e)
        {
            
            Con.Open();
            String st = "insert into gamer values('"+textBox1.Text+"',0,0,0)";
            Cmd = new SqlCommand(st, Con);
            Cmd.ExecuteNonQuery();
            MessageBox.Show("REGISTRATION SUCCESSFUL");
            Con.Close();
        }

        private void button16_Click(object sender, EventArgs e)
        {
            button7.Text = "";
            button8.Text = "";
            button9.Text = "";
            button10.Text = "";
            button11.Text = "";
            button12.Text = "";
            button13.Text = "";
            button14.Text = "";
            button15.Text = "";
            c = 1;
            w = 0;
            label6.Text = "YOUR TURN";
            label7.Text = "";
            panel3.Visible = false;

        }

        private void button17_Click(object sender, EventArgs e)
        {
            panel2.Visible = false;
            panel1.Visible = false;
            panel3.Visible = false;
            if (p == 0)
            {
                Con.Open();
                String st = "select * from gamer where ID='" + textBox1.Text + "'";
                Cmd = new SqlCommand(st, Con);
                SqlDataReader dr = Cmd.ExecuteReader();
                if (dr.Read())
                {
                    an = int.Parse(dr["WIN"].ToString());
                    bn = int.Parse(dr["LOSE"].ToString());
                    cn = int.Parse(dr["NOGP"].ToString());

                }
                an += w1;
                bn += l1;
                cn += g;
                Con.Close();
                Con.Open();
                String st1 = "update gamer set WIN='" + an.ToString() + "' ,LOSE=" + bn.ToString() + ",NOGP='" + cn.ToString() + "' where ID='" + textBox1.Text + "'";

                Cmd = new SqlCommand(st1, Con);
                Cmd.ExecuteNonQuery();
                label2.Text = an.ToString();
                label2.Visible = true;
                MessageBox.Show("successful");
                Con.Close();


                Con.Open();
                st = "select * from gamer where ID='" + textBox2.Text + "'";
                Cmd = new SqlCommand(st, Con);
                SqlDataReader dr1 = Cmd.ExecuteReader();
                if (dr1.Read())
                {
                    an = int.Parse(dr1["WIN"].ToString());
                    bn = int.Parse(dr1["LOSE"].ToString());
                    cn = int.Parse(dr1["NOGP"].ToString());

                }
                an += w2;
                bn += l2;
                cn += g;
                Con.Close();
                Con.Open();
                st1 = "update gamer set WIN='" + an.ToString() + "' ,LOSE=" + bn.ToString() + ",NOGP='" + cn.ToString() + "' where ID='" + textBox2.Text + "'";

                Cmd = new SqlCommand(st1, Con);
                Cmd.ExecuteNonQuery();
                label2.Text = an.ToString();
                label2.Visible = true;
                MessageBox.Show("successful");
                Con.Close();
            }
        }

        private void button6_Click(object sender, EventArgs e)
        {
            if (p == 0)
            {
                Con.Open();
                String st1 = "SELECT * FROM gamer WHERE ID='" + textBox1.Text + "'";
                String st2 = "SELECT * FROM gamer WHERE ID='" + textBox2.Text + "'";
                SqlDataAdapter sda1 = new SqlDataAdapter(st1, Con);
                SqlDataAdapter sda2 = new SqlDataAdapter(st2, Con);
                DataTable dt1 = new DataTable();
                DataTable dt2 = new DataTable();
                sda1.Fill(dt1);
                sda2.Fill(dt2);
                if (dt1.Rows.Count == 1 && dt2.Rows.Count == 1)
                {
                    panel2.Visible = true;
                    button7.Text = "";
                    button8.Text = "";
                    button9.Text = "";
                    button10.Text = "";
                    button11.Text = "";
                    button12.Text = "";
                    button13.Text = "";
                    button14.Text = "";
                    button15.Text = "";
                    c = 1;
                    w = 0;
                    w1 = 0;
                    w2 = 0;
                    l1 = 0;
                    l2 = 0;
                    g = 0;
                    label6.Text = "YOUR TURN";
                    label7.Text = "";
                    label5.Text = textBox1.Text;
                    label8.Text = textBox2.Text;
                    textBox2.Visible = false;
                    Con.Close();
                }
                else
                {
                    MessageBox.Show("INVALIED PLAYER NAME. PLEASE RE-ENTER");
                    Con.Close();
                }
            }
            else 
            {
                panel2.Visible = true;
                button7.Text = "";
                button8.Text = "";
                button9.Text = "";
                button10.Text = "";
                button11.Text = "";
                button12.Text = "";
                button13.Text = "";
                button14.Text = "";
                button15.Text = "";
                c = 1;
                w = 0;
                w1 = 0;
                w2 = 0;
                l1 = 0;
                l2 = 0;
                g = 0;
                label6.Text = "YOUR TURN";
                label7.Text = "";
                label5.Text = textBox1.Text;
                label8.Text = textBox2.Text;
                textBox2.Visible = false;
            }
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            Con.ConnectionString = @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\Rahul R Singh\source\repos\WindowsFormsApp2\WindowsFormsApp2\Database1.mdf;Integrated Security=True";
        }

        private void label6_Click(object sender, EventArgs e)
        {

        }

        private void panel2_Paint(object sender, PaintEventArgs e)
        {

        }

        private void button5_Click(object sender, EventArgs e)
        {
            panel1.Visible = false;
            button6.Visible = false;
            label2.Visible = false;
            label3.Visible = false;
            textBox2.Visible = false;
        }

        private void play_click(object sender, EventArgs e)
        {

            Button button = (Button)sender;
            if (p == 0)
            {

                if (button.Text == "")
                {
                    if (c % 2 != 0)
                    {
                        button.Text = "X";
                        label7.Text = "YOUR TURN";
                        label6.Text = "";
                        if ((button7.Text == button8.Text) && (button8.Text == button9.Text) && button7.Text == "X")
                        {
                            label7.Text = "LOSE";
                            label6.Text = "WIN";
                            w = 1;
                            w1 =w1+ 1;
                            l2 += 1;
                            g += 1;
                      


                        }
                        if ((button7.Text == button10.Text) && (button10.Text == button13.Text) && button7.Text == "X")
                        {
                            label7.Text = "LOSE";
                            label6.Text = "WIN";
                            w = 1;
                            w1 = w1 + 1;
                            l2 += 1;
                            g += 1;

                        }
                        if ((button7.Text == button11.Text) && (button15.Text == button11.Text) && button7.Text == "X")
                        {
                            label7.Text = "LOSE";
                            label6.Text = "WIN";
                            w = 1;
                            w1 = w1 + 1;
                            l2 += 1;
                            g += 1;


                        }
                        if ((button8.Text == button11.Text) && (button11.Text == button14.Text) && button3.Text == "X")
                        {
                            label7.Text = "LOSE";
                            label6.Text = "WIN";
                            w = 1;
                            w1 = w1 + 1;
                            l2 += 1;
                            g += 1;
                        }
                        if ((button10.Text == button11.Text) && (button11.Text == button12.Text) && button10.Text == "X")
                        {
                            label7.Text = "LOSE";
                            label6.Text = "WIN";
                            w = 1;
                            w1 = w1 + 1;
                            l2 += 1;
                            g += 1;
                        }
                        if ((button9.Text == button12.Text) && (button12.Text == button15.Text) && button9.Text == "X")
                        {
                            label7.Text = "LOSE";
                            label6.Text = "WIN";
                            w = 1;
                            w1 = w1 + 1;
                            l2 += 1;
                            g += 1;
                        }
                        if ((button9.Text == button11.Text) && (button11.Text == button13.Text) && button9.Text == "X")
                        {
                            label7.Text = "LOSE";
                            label6.Text = "WIN";
                            w = 1;
                            w1 = w1 + 1;
                            l2 += 1;
                            g += 1;
                        }
                        if ((button13.Text == button14.Text) && (button14.Text == button15.Text) && button13.Text == "X")
                        {
                            label7.Text = "LOSE";
                            label6.Text = "WIN";
                            w = 1;
                            w1 = w1 + 1;
                            l2 += 1;
                            g += 1;
                        }

                    }
                    else
                    {
                        button.Text = "O";
                        label6.Text = "YOUR TURN";
                        label7.Text = "";
                        if ((button7.Text == button8.Text) && (button8.Text == button9.Text) && button7.Text == "O")
                        {
                            label6.Text = "LOSE";
                            label7.Text = "WIN";
                            w = 1;
                            w2 = w2 + 1;
                            l1 += 1;
                            g += 1;
                        }
                        if ((button7.Text == button10.Text) && (button10.Text == button13.Text) && button7.Text == "O")
                        {
                            label6.Text = "LOSE";
                            label7.Text = "WIN";
                            w = 1;
                            w2 = w2 + 1;
                            l1 += 1;
                            g += 1;
                        }
                        if ((button7.Text == button11.Text) && (button15.Text == button11.Text) && button7.Text == "O")
                        {
                            label6.Text = "LOSE";
                            label7.Text = "WIN";
                            w = 1;
                            w2 = w2 + 1;
                            l1 += 1;
                            g += 1;

                        }
                        if ((button8.Text == button11.Text) && (button11.Text == button14.Text) && button8.Text == "O")
                        {
                            label6.Text = "LOSE";
                            label7.Text = "WIN";
                            w = 1;
                            w2 = w2 + 1;
                            l1 += 1;
                            g += 1;
                        }
                        if ((button10.Text == button11.Text) && (button11.Text == button12.Text) && button10.Text == "O")
                        {
                            label6.Text = "LOSE";
                            label7.Text = "WIN";
                            w = 1;
                            w2 = w2 + 1;
                            l1 += 1;
                            g += 1;
                        }
                        if ((button9.Text == button12.Text) && (button12.Text == button15.Text) && button9.Text == "O")
                        {
                            label6.Text = "LOSE";
                            label7.Text = "WIN";
                            w = 1;
                            w2 = w2 + 1;
                            l1 += 1;
                            g += 1;
                        }
                        if ((button9.Text == button11.Text) && (button11.Text == button13.Text) && button9.Text == "O")
                        {
                            label6.Text = "LOSE";
                            label7.Text = "WIN";
                            w = 1;
                            w2 = w2 + 1;
                            l1 += 1;
                            g += 1;
                        }
                        
                        if ((button13.Text == button14.Text) && (button14.Text == button15.Text) && button13.Text == "O")
                        {
                            label6.Text = "LOSE";
                            label7.Text = "WIN";
                            w = 1;
                            w2 = w2 + 1;
                            l1 += 1;
                            g += 1;
                        }

                    }

                    if (c >= 9 && w != 1)
                    {
                        label6.Text = "DRAW";
                        label7.Text = "DRAW";
                        g += 1;
                    }
                    c += 1;
                }
            }
            else if (p == 1)
            {

                if (button.Text == "")
                {
                    if (c % 2 != 0)
                    {
                        button.Text = "X";
                        label7.Text = "YOUR TURN";
                        label6.Text = "";
                        if ((button7.Text == button8.Text) && (button8.Text == button9.Text) && button7.Text == "X")
                        {
                            label7.Text = "LOSE";
                            label6.Text = "WIN";
                            w = 1;
                            w1 = w1 + 1;
                            

                        }
                        if ((button7.Text == button10.Text) && (button10.Text == button13.Text) && button7.Text == "X")
                        {
                            label7.Text = "LOSE";
                            label6.Text = "WIN";
                            w = 1;
                            w1 = w1 + 1;
                         
                        }
                        if ((button7.Text == button11.Text) && (button15.Text == button11.Text) && button7.Text == "X")
                        {
                            label7.Text = "LOSE";
                            label6.Text = "WIN";
                            w = 1;
                            w1 = w1 + 1;
                          
                        }
                        if ((button8.Text == button11.Text) && (button11.Text == button14.Text) && button3.Text == "X")
                        {
                            label7.Text = "LOSE";
                            label6.Text = "WIN";
                            w = 1;
                            w1 = w1 + 1;
                           
                        }
                        if ((button10.Text == button11.Text) && (button11.Text == button12.Text) && button10.Text == "X")
                        {
                            label7.Text = "LOSE";
                            label6.Text = "WIN";
                            w = 1;
                            w1 = w1 + 1;
                           
                        }
                        if ((button9.Text == button12.Text) && (button12.Text == button15.Text) && button9.Text == "X")
                        {
                            label7.Text = "LOSE";
                            label6.Text = "WIN";
                            w = 1;
                            w1 = w1 + 1;
                           
                        }
                        if ((button9.Text == button11.Text) && (button11.Text == button13.Text) && button9.Text == "X")
                        {
                            label7.Text = "LOSE";
                            label6.Text = "WIN";
                            w = 1;
                            w1 = w1 + 1;
                         
                        }
                        if ((button13.Text == button14.Text) && (button14.Text == button15.Text) && button13.Text == "X")
                        {
                            label7.Text = "LOSE";
                            label6.Text = "WIN";
                            w = 1;
                            w1 = w1 + 1;
                          
                        }

                    }
                }

                if (c >= 9 && w != 1)
                {
                    label6.Text = "DRAW";
                    label7.Text = "DRAW";
                  
                }
                c += 1;
                if (c % 2 == 0)
                {
                    if (c == 2)
                    {
                        if (button11.Text == "")
                        {
                            button11.Text = "O";
                            label6.Text = "YOUR TURN";
                            label7.Text = "";

                        }
                        else if (button7.Text == "")
                        {
                            button7.Text = "O";
                            label6.Text = "YOUR TURN";
                            label7.Text = "";

                        }
                        else if (button13.Text == "")
                        {
                            button13.Text = "O";
                            label6.Text = "YOUR TURN";
                            label7.Text = "";

                        }
                        else if (button9.Text == "")
                        {
                            button9.Text = "O";
                            label6.Text = "YOUR TURN";
                            label7.Text = "";

                        }
                        else if (button15.Text == "")
                        {
                            button15.Text = "O";
                            label6.Text = "YOUR TURN";
                            label7.Text = "";

                        }
                        c += 1;
                    }
                    else if (c == 4)
                    {
                        if (button7.Text == "X" && button8.Text == "X" && button9.Text == "")
                        {
                            button9.Text = "O";
                            label6.Text = "YOUR TURN";
                            label7.Text = "";
                        }
                        else if (button7.Text == "X" && button9.Text == "X" && button8.Text == "")
                        {
                            button8.Text = "O";
                            label6.Text = "YOUR TURN";
                            label7.Text = "";
                        }
                        else if (button8.Text == "X" && button9.Text == "X" && button7.Text == "")
                        {
                            button7.Text = "O";
                            label6.Text = "YOUR TURN";
                            label7.Text = "";
                        }
                        else if (button10.Text == "X" && button11.Text == "X" && button12.Text == "")
                        {
                            button12.Text = "O";
                            label6.Text = "YOUR TURN";
                            label7.Text = "";
                        }
                        else if (button10.Text == "X" && button12.Text == "X" && button13.Text == "")
                        {
                            button11.Text = "O";
                            label6.Text = "YOUR TURN";
                            label7.Text = "";
                        }
                        else if (button12.Text == "X" && button11.Text == "X" && button10.Text == "")
                        {
                            button10.Text = "O";
                            label6.Text = "YOUR TURN";
                            label7.Text = "";
                        }
                        else if (button13.Text == "X" && button14.Text == "X" && button15.Text == "")
                        {
                            button15.Text = "O";
                            label6.Text = "YOUR TURN";
                            label7.Text = "";
                        }
                        else if (button13.Text == "X" && button15.Text == "X" && button14.Text == "")
                        {
                            button14.Text = "O";
                            label6.Text = "YOUR TURN";
                            label7.Text = "";
                        }
                        else if (button14.Text == "X" && button15.Text == "X" && button13.Text == "")
                        {
                            button13.Text = "O";
                            label6.Text = "YOUR TURN";
                            label7.Text = "";
                        }
                        else if (button7.Text == "X" && button10.Text == "X" && button13.Text == "")
                        {
                            button13.Text = "O";
                            label6.Text = "YOUR TURN";
                            label7.Text = "";
                        }
                        else if (button7.Text == "X" && button13.Text == "X" && button10.Text == "")
                        {
                            button10.Text = "O";
                            label6.Text = "YOUR TURN";
                            label7.Text = "";
                        }
                        else if (button10.Text == "X" && button13.Text == "X" && button7.Text == "")
                        {
                            button7.Text = "O";
                            label6.Text = "YOUR TURN";
                            label7.Text = "";
                        }
                        else if (button8.Text == "X" && button11.Text == "X" && button14.Text == "")
                        {
                            button14.Text = "O";
                            label6.Text = "YOUR TURN";
                            label7.Text = "";
                        }
                        else if (button8.Text == "X" && button14.Text == "X" && button11.Text == "")
                        {
                            button11.Text = "O";
                            label6.Text = "YOUR TURN";
                            label7.Text = "";
                        }
                        else if (button11.Text == "X" && button14.Text == "X" && button8.Text == "")
                        {
                            button8.Text = "O";
                            label6.Text = "YOUR TURN";
                            label7.Text = "";
                        }
                        else if (button9.Text == "X" && button12.Text == "X" && button15.Text == "")
                        {
                            button15.Text = "O";
                            label6.Text = "YOUR TURN";
                            label7.Text = "";
                        }
                        else if (button9.Text == "X" && button15.Text == "X" && button12.Text == "")
                        {
                            button12.Text = "O";
                            label6.Text = "YOUR TURN";
                            label7.Text = "";
                        }
                        else if (button12.Text == "X" && button15.Text == "X" && button9.Text == "")
                        {
                            button9.Text = "O";
                            label6.Text = "YOUR TURN";
                            label7.Text = "";
                        }
                        else if (button7.Text == "X" && button11.Text == "X" && button15.Text == "")
                        {
                            button15.Text = "O";
                            label6.Text = "YOUR TURN";
                            label7.Text = "";
                        }
                        else if (button7.Text == "X" && button15.Text == "X" && button11.Text == "")
                        {
                            button11.Text = "O";
                            label6.Text = "YOUR TURN";
                            label7.Text = "";
                        }
                        else if (button15.Text == "X" && button11.Text == "X" && button7.Text == "")
                        {
                            button7.Text = "O";
                            label6.Text = "YOUR TURN";
                            label7.Text = "";
                        }
                        else if (button9.Text == "X" && button11.Text == "X" && button13.Text == "")
                        {
                            button13.Text = "O";
                            label6.Text = "YOUR TURN";
                            label7.Text = "";
                        }
                        else if (button9.Text == "X" && button13.Text == "X" && button11.Text == "")
                        {
                            button11.Text = "O";
                            label6.Text = "YOUR TURN";
                            label7.Text = "";
                        }
                        else if (button13.Text == "X" && button11.Text == "X" && button9.Text == "")
                        {
                            button9.Text = "O";
                            label6.Text = "YOUR TURN";
                            label7.Text = "";
                        }
                        else
                        {
                            if (button11.Text == "O")
                            {
                                if (button8.Text == "")
                                {
                                    button8.Text = "O";
                                    label6.Text = "YOUR TURN";
                                    label7.Text = "";

                                }
                                else if (button13.Text == "")
                                {
                                    button13.Text = "O";
                                    label6.Text = "YOUR TURN";
                                    label7.Text = "";

                                }
                                else if (button10.Text == "")
                                {
                                    button10.Text = "O";
                                    label6.Text = "YOUR TURN";
                                    label7.Text = "";

                                }
                                else if (button12.Text == "")
                                {
                                    button12.Text = "O";
                                    label6.Text = "YOUR TURN";
                                    label7.Text = "";

                                }

                            }
                            else if (button7.Text == "")
                            {
                                button7.Text = "O";
                                label6.Text = "YOUR TURN";
                                label7.Text = "";

                            }
                            else if (button13.Text == "")
                            {
                                button13.Text = "O";
                                label6.Text = "YOUR TURN";
                                label7.Text = "";

                            }
                            else if (button9.Text == "")
                            {
                                button9.Text = "O";
                                label6.Text = "YOUR TURN";
                                label7.Text = "";

                            }
                            else if (button15.Text == "")
                            {
                                button15.Text = "O";
                                label6.Text = "YOUR TURN";
                                label7.Text = "";

                            }
                        }
                        c += 1;
                    }
                    else
                    {
                        if (button7.Text == "O" && button8.Text == "O" && button9.Text == "")
                        {
                            button9.Text = "O";
                            label6.Text = "YOUR TURN";
                            label7.Text = "";
                        }
                        else if (button7.Text == "O" && button9.Text == "O" && button8.Text == "")
                        {
                            button8.Text = "O";
                            label6.Text = "YOUR TURN";
                            label7.Text = "";
                        }
                        else if (button8.Text == "O" && button9.Text == "O" && button7.Text == "")
                        {
                            button7.Text = "O";
                            label6.Text = "YOUR TURN";
                            label7.Text = "";
                        }
                        else if (button10.Text == "O" && button11.Text == "O" && button12.Text == "")
                        {
                            button12.Text = "O";
                            label6.Text = "YOUR TURN";
                            label7.Text = "";
                        }
                        else if (button10.Text == "O" && button12.Text == "O" && button13.Text == "")
                        {
                            button11.Text = "O";
                            label6.Text = "YOUR TURN";
                            label7.Text = "";
                        }
                        else if (button12.Text == "O" && button11.Text == "O" && button10.Text == "")
                        {
                            button10.Text = "O";
                            label6.Text = "YOUR TURN";
                            label7.Text = "";
                        }
                        else if (button13.Text == "O" && button14.Text == "O" && button15.Text == "")
                        {
                            button15.Text = "O";
                            label6.Text = "YOUR TURN";
                            label7.Text = "";
                        }
                        else if (button13.Text == "O" && button15.Text == "O" && button14.Text == "")
                        {
                            button14.Text = "O";
                            label6.Text = "YOUR TURN";
                            label7.Text = "";
                        }
                        else if (button14.Text == "O" && button15.Text == "O" && button13.Text == "")
                        {
                            button13.Text = "O";
                            label6.Text = "YOUR TURN";
                            label7.Text = "";
                        }
                        else if (button7.Text == "O" && button10.Text == "O" && button13.Text == "")
                        {
                            button13.Text = "O";
                            label6.Text = "YOUR TURN";
                            label7.Text = "";
                        }
                        else if (button7.Text == "O" && button13.Text == "O" && button10.Text == "")
                        {
                            button10.Text = "O";
                            label6.Text = "YOUR TURN";
                            label7.Text = "";
                        }
                        else if (button10.Text == "O" && button13.Text == "O" && button7.Text == "")
                        {
                            button7.Text = "O";
                            label6.Text = "YOUR TURN";
                            label7.Text = "";
                        }
                        else if (button8.Text == "O" && button11.Text == "O" && button14.Text == "")
                        {
                            button14.Text = "O";
                            label6.Text = "YOUR TURN";
                            label7.Text = "";
                        }
                        else if (button8.Text == "O" && button14.Text == "O" && button11.Text == "")
                        {
                            button11.Text = "O";
                            label6.Text = "YOUR TURN";
                            label7.Text = "";
                        }
                        else if (button11.Text == "O" && button14.Text == "O" && button8.Text == "")
                        {
                            button8.Text = "O";
                            label6.Text = "YOUR TURN";
                            label7.Text = "";
                        }
                        else if (button9.Text == "O" && button12.Text == "O" && button15.Text == "")
                        {
                            button15.Text = "O";
                            label6.Text = "YOUR TURN";
                            label7.Text = "";
                        }
                        else if (button9.Text == "O" && button15.Text == "O" && button12.Text == "")
                        {
                            button12.Text = "O";
                            label6.Text = "YOUR TURN";
                            label7.Text = "";
                        }
                        else if (button12.Text == "O" && button15.Text == "O" && button9.Text == "")
                        {
                            button9.Text = "O";
                            label6.Text = "YOUR TURN";
                            label7.Text = "";
                        }
                        else if (button7.Text == "O" && button11.Text == "O" && button15.Text == "")
                        {
                            button15.Text = "O";
                            label6.Text = "YOUR TURN";
                            label7.Text = "";
                        }
                        else if (button7.Text == "O" && button15.Text == "O" && button11.Text == "")
                        {
                            button11.Text = "O";
                            label6.Text = "YOUR TURN";
                            label7.Text = "";
                        }
                        else if (button15.Text == "O" && button11.Text == "O" && button7.Text == "")
                        {
                            button7.Text = "O";
                            label6.Text = "YOUR TURN";
                            label7.Text = "";
                        }
                        else if (button9.Text == "O" && button11.Text == "O" && button13.Text == "")
                        {
                            button13.Text = "O";
                            label6.Text = "YOUR TURN";
                            label7.Text = "";
                        }
                        else if (button9.Text == "O" && button13.Text == "O" && button11.Text == "")
                        {
                            button11.Text = "O";
                            label6.Text = "YOUR TURN";
                            label7.Text = "";
                        }
                        else if (button13.Text == "O" && button11.Text == "O" && button9.Text == "")
                        {
                            button9.Text = "O";
                            label6.Text = "YOUR TURN";
                            label7.Text = "";
                        }
                        else if (button7.Text == "X" && button8.Text == "X" && button9.Text == "")
                        {
                            button9.Text = "O";
                            label6.Text = "YOUR TURN";
                            label7.Text = "";
                        }
                        else if (button7.Text == "X" && button9.Text == "X" && button8.Text == "")
                        {
                            button8.Text = "O";
                            label6.Text = "YOUR TURN";
                            label7.Text = "";
                        }
                        else if (button8.Text == "X" && button9.Text == "X" && button7.Text == "")
                        {
                            button7.Text = "O";
                            label6.Text = "YOUR TURN";
                            label7.Text = "";
                        }
                        else if (button10.Text == "X" && button11.Text == "X" && button12.Text == "")
                        {
                            button12.Text = "O";
                            label6.Text = "YOUR TURN";
                            label7.Text = "";
                        }
                        else if (button10.Text == "X" && button12.Text == "X" && button13.Text == "")
                        {
                            button11.Text = "O";
                            label6.Text = "YOUR TURN";
                            label7.Text = "";
                        }
                        else if (button12.Text == "X" && button11.Text == "X" && button10.Text == "")
                        {
                            button10.Text = "O";
                            label6.Text = "YOUR TURN";
                            label7.Text = "";
                        }
                        else if (button13.Text == "X" && button14.Text == "X" && button15.Text == "")
                        {
                            button15.Text = "O";
                            label6.Text = "YOUR TURN";
                            label7.Text = "";
                        }
                        else if (button13.Text == "X" && button15.Text == "X" && button14.Text == "")
                        {
                            button14.Text = "O";
                            label6.Text = "YOUR TURN";
                            label7.Text = "";
                        }
                        else if (button14.Text == "X" && button15.Text == "X" && button13.Text == "")
                        {
                            button13.Text = "O";
                            label6.Text = "YOUR TURN";
                            label7.Text = "";
                        }
                        else if (button7.Text == "X" && button10.Text == "X" && button13.Text == "")
                        {
                            button13.Text = "O";
                            label6.Text = "YOUR TURN";
                            label7.Text = "";
                        }
                        else if (button7.Text == "X" && button13.Text == "X" && button10.Text == "")
                        {
                            button10.Text = "O";
                            label6.Text = "YOUR TURN";
                            label7.Text = "";
                        }
                        else if (button10.Text == "X" && button13.Text == "X" && button7.Text == "")
                        {
                            button7.Text = "O";
                            label6.Text = "YOUR TURN";
                            label7.Text = "";
                        }
                        else if (button8.Text == "X" && button11.Text == "X" && button14.Text == "")
                        {
                            button14.Text = "O";
                            label6.Text = "YOUR TURN";
                            label7.Text = "";
                        }
                        else if (button8.Text == "X" && button14.Text == "X" && button11.Text == "")
                        {
                            button11.Text = "O";
                            label6.Text = "YOUR TURN";
                            label7.Text = "";
                        }
                        else if (button11.Text == "X" && button14.Text == "X" && button8.Text == "")
                        {
                            button8.Text = "O";
                            label6.Text = "YOUR TURN";
                            label7.Text = "";
                        }
                        else if (button9.Text == "X" && button12.Text == "X" && button15.Text == "")
                        {
                            button15.Text = "O";
                            label6.Text = "YOUR TURN";
                            label7.Text = "";
                        }
                        else if (button9.Text == "X" && button15.Text == "X" && button12.Text == "")
                        {
                            button12.Text = "O";
                            label6.Text = "YOUR TURN";
                            label7.Text = "";
                        }
                        else if (button12.Text == "X" && button15.Text == "X" && button9.Text == "")
                        {
                            button9.Text = "O";
                            label6.Text = "YOUR TURN";
                            label7.Text = "";
                        }
                        else if (button7.Text == "X" && button11.Text == "X" && button15.Text == "")
                        {
                            button15.Text = "O";
                            label6.Text = "YOUR TURN";
                            label7.Text = "";
                        }
                        else if (button7.Text == "X" && button15.Text == "X" && button11.Text == "")
                        {
                            button11.Text = "O";
                            label6.Text = "YOUR TURN";
                            label7.Text = "";
                        }
                        else if (button15.Text == "X" && button11.Text == "X" && button7.Text == "")
                        {
                            button7.Text = "O";
                            label6.Text = "YOUR TURN";
                            label7.Text = "";
                        }
                        else if (button9.Text == "X" && button11.Text == "X" && button13.Text == "")
                        {
                            button13.Text = "O";
                            label6.Text = "YOUR TURN";
                            label7.Text = "";
                        }
                        else if (button9.Text == "X" && button13.Text == "X" && button11.Text == "")
                        {
                            button11.Text = "O";
                            label6.Text = "YOUR TURN";
                            label7.Text = "";
                        }
                        else if (button13.Text == "X" && button11.Text == "X" && button9.Text == "")
                        {
                            button9.Text = "O";
                            label6.Text = "YOUR TURN";
                            label7.Text = "";
                        }
                        else
                        {
                            if (button11.Text == "O")
                            {
                                if (button8.Text == "")
                                {
                                    button8.Text = "O";
                                    label6.Text = "YOUR TURN";
                                    label7.Text = "";

                                }
                                else if (button13.Text == "")
                                {
                                    button13.Text = "O";
                                    label6.Text = "YOUR TURN";
                                    label7.Text = "";

                                }
                                else if (button10.Text == "")
                                {
                                    button10.Text = "O";
                                    label6.Text = "YOUR TURN";
                                    label7.Text = "";

                                }
                                else if (button12.Text == "")
                                {
                                    button12.Text = "O";
                                    label6.Text = "YOUR TURN";
                                    label7.Text = "";

                                }

                            }
                            else if (button7.Text == "")
                            {
                                button7.Text = "O";
                                label6.Text = "YOUR TURN";
                                label7.Text = "";

                            }
                            else if (button13.Text == "")
                            {
                                button13.Text = "O";
                                label6.Text = "YOUR TURN";
                                label7.Text = "";

                            }
                            else if (button9.Text == "")
                            {
                                button9.Text = "O";
                                label6.Text = "YOUR TURN";
                                label7.Text = "";

                            }
                            else if (button15.Text == "")
                            {
                                button15.Text = "O";
                                label6.Text = "YOUR TURN";
                                label7.Text = "";

                            }
                        }
                        c += 1;
                    }

                    if ((button7.Text == button8.Text) && (button8.Text == button9.Text) && button7.Text == "O")
                    {
                        label6.Text = "LOSE";
                        label7.Text = "WIN";
                        w = 1;
                        w2 = w2 + 1;
                       

                    }
                    if ((button7.Text == button10.Text) && (button10.Text == button13.Text) && button7.Text == "O")
                    {
                        label6.Text = "LOSE";
                        label7.Text = "WIN";
                        w = 1;
                        w2 = w2 + 1;
                       
                    }
                    if ((button7.Text == button11.Text) && (button15.Text == button11.Text) && button7.Text == "O")
                    {
                        label6.Text = "LOSE";
                        label7.Text = "WIN";
                        w = 1;
                        w2 = w2 + 1;
                        
                    }
                    if ((button8.Text == button11.Text) && (button11.Text == button14.Text) && button8.Text == "O")
                    {
                        label6.Text = "LOSE";
                        label7.Text = "WIN";
                        w = 1;
                        w2 = w2 + 1;
                     
                    }
                    if ((button10.Text == button11.Text) && (button11.Text == button12.Text) && button10.Text == "O")
                    {
                        label6.Text = "LOSE";
                        label7.Text = "WIN";
                        w = 1;
                        w2 = w2 + 1;
                     
                    }
                    if ((button9.Text == button12.Text) && (button12.Text == button15.Text) && button9.Text == "O")
                    {
                        label6.Text = "LOSE";
                        label7.Text = "WIN";
                        w = 1;
                        w2 = w2 + 1;
                   
                    }
                    if ((button9.Text == button11.Text) && (button11.Text == button13.Text) && button9.Text == "O")
                    {
                        label6.Text = "LOSE";
                        label7.Text = "WIN";
                        w = 1;
                        w2 = w2 + 1;
                       
                    }
                    if ((button13.Text == button14.Text) && (button14.Text == button15.Text) && button13.Text == "O")
                    {
                        label6.Text = "LOSE";
                        label7.Text = "WIN";
                        w = 1;
                        w2 = w2 + 1;
                        
                        
                    }
                    if (c >= 9 && w != 1)
                    {
                        label6.Text = "DRAW";
                        label7.Text = "DRAW";
                        
                    }

                }
            }

        }
    }
}
