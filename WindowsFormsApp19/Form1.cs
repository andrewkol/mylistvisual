using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApp19
{
    public partial class Form1 : Form
    {
        MyList<int> myFirstList;
        List<MyRectangle> myRect;
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            myFirstList = new MyList<int>();
            myRect = new List<MyRectangle>();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if(int.TryParse(textBox1.Text, out var number))
            {
                myFirstList.Add(number);
                richTextBox1.Text += "Элемент " + number + " добавлен в конец списка.\r\n";
                if (myRect.Count() < 1)
                    myRect.Add(new MyRectangle(10, 10, 50, 30, textBox1.Text));
                else
                    myRect.Add(new MyRectangle(myRect[myRect.Count - 1].StartX + 80, 10, 50, 30, textBox1.Text));
            }
            else
            {
                richTextBox1.Text += "Проверьте введёное значение.\r\n";
            }
            Draw();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (int.TryParse(textBox2.Text, out var number) && int.TryParse(textBox3.Text, out var position))
            {
                if (myFirstList.Add(number, position) == 1)
                {
                    richTextBox1.Text += "Элемент " + number + " добавлен на позицию " + position + "\r\n";
                    for (int i = position; i < myRect.Count(); i++)
                    {
                        myRect[i].ReRect(myRect[i].StartX + 80, 10);
                    }
                    myRect.Insert(position, new MyRectangle(myRect[position].StartX - 80, 10, 50, 30, textBox2.Text));
                    
                }
                else
                    richTextBox1.Text += "Элемент не добавлен. Индекс должен находиться в границах этого списка. \r\n";
            }
            else
            {
                richTextBox1.Text += "Проверьте введёное значение.\r\n";
            }
            Draw();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            if(int.TryParse(textBox4.Text, out var position))
            {
                if(myFirstList.Remove(position) == 1)
                {
                    richTextBox1.Text += "Элемент удалён с позиции " + position + "\r\n";
                    myRect.RemoveAt(position);
                    for(int i = position; i < myRect.Count(); i++)
                    {
                        myRect[i].ReRect(myRect[i].StartX - 80, 10);
                    }
                }
                else
                    richTextBox1.Text += "Элемент не удалён. Индекс должен находиться в границах этого списка.\r\n";
            }
            else
            {
                richTextBox1.Text += "Проверьте введёное значение.\r\n";
            }
            Draw();
        }

        private void label7_Click(object sender, EventArgs e)
        {

        }

        private void button4_Click(object sender, EventArgs e)
        {
            if(myFirstList.Count > 0)
            {
                myFirstList.RemoveLast();
                myRect.RemoveAt(myRect.Count() - 1);
                richTextBox1.Text += "Последний элемент удалён из списка.\r\n";
            }
            else
                richTextBox1.Text += "Список пуст.\r\n";
            Draw();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            if(int.TryParse(textBox5.Text, out var number))
            {
                if(myFirstList.Find(number, 1) != -1)
                {
                    myFirstList.Remove(number, 1);
                    int todel = -1;
                    for (int i = 0; i< myRect.Count(); i++)
                    {
                        if (Convert.ToInt32(myRect[i]._NUM) == number)
                        {
                            todel = i;
                            break;
                        }
                    }
                    if(todel != -1)
                        myRect.RemoveAt(todel);
                    for (int i = todel; i < myRect.Count(); i++)
                    {
                        myRect[i].ReRect(myRect[i].StartX - 80, 10);
                    }
                }
                else
                    richTextBox1.Text += "Такого элемента нет.\r\n";

            }
            else
                richTextBox1.Text += "Проверьте введёное значение.\r\n";
            Draw();
        }

        private void button6_Click(object sender, EventArgs e)
        {
            if (int.TryParse(textBox6.Text, out var number))
            {
                if (myFirstList.Find(number, 1) != -1)
                {
                    myFirstList.RemoveAll(number);
                    int todel = -1;
                    for (int i = 0; i < myRect.Count(); i++)
                    {
                        todel = -1;
                        if (Convert.ToInt32(myRect[i]._NUM) == number)
                        {
                            todel = i;
                            myRect.RemoveAt(todel);
                            i--;
                            for (int j = todel; j < myRect.Count(); j++)
                            {
                                myRect[j].ReRect(myRect[j].StartX - 80, 10);
                            }
                        }
                    }
                }
                else
                    richTextBox1.Text += "Такого элемента нет.\r\n";

            }
            else
                richTextBox1.Text += "Проверьте введёное значение.\r\n";
            Draw();
        }

        private void button7_Click(object sender, EventArgs e)
        {
            if (int.TryParse(textBox7.Text, out var number))
            {
                if(myFirstList.Find(number, 1) != -1)
                    richTextBox1.Text += "Элемент " + number + " позиция - " + myFirstList.Find(number, 1) + "\r\n";
                else
                    richTextBox1.Text += "Элемент не найден.\r\n";

            }
            else
                richTextBox1.Text += "Проверьте введёное значение.\r\n";
        }

        private void button8_Click(object sender, EventArgs e)
        {
            if (int.TryParse(textBox8.Text, out var position))
            {
                if(myFirstList.Find(position) != default)
                {
                    richTextBox1.Text += "На позиции " + position + " находится элемент " + myFirstList.Find(position) + "\r\n";
                }
                else
                    richTextBox1.Text += "Элемент не найден.\r\n";
            }
            else
                richTextBox1.Text += "Проверьте введёное значение.\r\n";
        }

        private void button9_Click(object sender, EventArgs e)
        {
            myFirstList.Clear();
            myRect.Clear();
            Draw();
            richTextBox1.Text += "Список очищен.\r\n";
        }

        private void button10_Click(object sender, EventArgs e)
        {
            richTextBox1.Text += "Количество элементов в списке: " + myFirstList.Count + "\r\n";
        }
        public void Draw()
        {
            Graphics g = panel1.CreateGraphics();
            g.Clear(Color.White);
            foreach(var item in myRect)
            {
                item.Draw(g);
                Console.WriteLine(item._NUM);
            }
            Console.WriteLine("---------");
        }

        private void button11_Click(object sender, EventArgs e)
        {
            richTextBox1.Clear();
            for(int i = 0; i < myFirstList.Count(); i++)
            {
                Console.WriteLine(myFirstList[i]);
            }
        }
    }
}
