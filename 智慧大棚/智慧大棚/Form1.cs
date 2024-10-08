﻿using Modbus.Device;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO.Ports;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Forms.DataVisualization.Charting;

namespace 智慧大鹏
{
    public partial class Form1 : Form
    {
        // 基于MOdbus通讯的库
        ModbusMaster master;
        public Form1()
        {
            InitializeComponent();
        }
        private void Form1_Load(object sender, EventArgs e)
        {
            serialPort1.PortName = "COM1";
            serialPort1.DataBits = 8;
            serialPort1.BaudRate = 9600;
            serialPort1.StopBits = StopBits.One;
            serialPort1.Parity = Parity.Even;
            serialPort1.Open();
            master = ModbusSerialMaster.CreateRtu(serialPort1);
            //master.ReadHoldingRegisters(1,0x0000,1);
        }

        // 设置间隔
        private void btn_setinterval_Click(object sender, EventArgs e)
        {
            timer1.Interval =Convert.ToInt32(ipt_interval.Text);
        }

        /// <summary>
        /// 开始停止，控制计时器启停
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btn_StartOrStop_Click(object sender, EventArgs e)
        {
            if (timer1.Enabled)
            {
                timer1.Stop();
            }
            else
            {
                timer1.Start();
            }
        }
        Random random = new Random();

        private void timer1_Tick(object sender, EventArgs e)
        {

            // 获取当前时间
            DateTime now = DateTime.Now;
            string time = now.ToString("HH:mm:ss");


            int num = random.Next(1, 100);

            int num1 = random.Next(1, 100);
            int num2 = random.Next(1, 100);
            int num3 = random.Next(1, 100);
            int num4 = random.Next(1, 100);

            if (cb_wd.Checked)
            {
                //// 获取设备的信息
                //ushort[] values = master.ReadHoldingRegisters(1, 0x0000, 1);
                //double tem = values[0] / 10;
                //// chart1 图表
                //// chart1.Series[0]  显示温度的序列
                //AddChartPoint(chart1.Series[0].Points,time,tem);

                // ======= 用随机数模拟数据 ========

                AddChartPoint(chart1.Series[0].Points,time,num+num1);                

            }

            if (cb_sd.Checked)
            {
                //// 获取设备的信息
                //ushort[] values = master.ReadHoldingRegisters(1, 0x0001, 1);

                //double tem = values[0] / 10;

                //// chart1 图表
                //// chart1.Series[0]  显示湿度的序列
                //AddChartPoint(chart1.Series[0].Points, time, tem);


                // ======= 用随机数模拟数据 ========

                AddChartPoint(chart1.Series[1].Points, time, num + num2);

            }
            if (cb_yq.Checked)
            {
                //// 获取设备的信息
                //ushort[] values = master.ReadHoldingRegisters(1, 0x0002, 1);

                //double tem = values[0] / 10;

                //// chart1 图表
                //// chart1.Series[0]  显示湿度的序列
                //AddChartPoint(chart1.Series[0].Points, time, tem);


                // ======= 用随机数模拟数据 ========

                AddChartPoint(chart1.Series[2].Points, time, num + num3);
            }
            if (cb_fs.Checked)
            {
                //// 获取设备的信息
                //ushort[] values = master.ReadHoldingRegisters(1, 0x0003, 1);

                //double tem = values[0] / 10;

                //// chart1 图表
                //// chart1.Series[0]  显示湿度的序列
                //AddChartPoint(chart1.Series[0].Points, time, tem);



                // ======= 用随机数模拟数据 ========

                AddChartPoint(chart1.Series[3].Points, time, num + num4);

            }
            SQLserver.Update($"insert into Imitate(Wd,Sd,Yq,Fs,Time) values ({num+num1},{num+num2},{num+num3},{num+num4},'{time}')");

            // 存储到数据库  时间  温度  湿度  风速  氧气 

        }

        /// <summary>
        /// 添加点的方法
        /// </summary>
        /// <param name="points">序列集合</param>
        /// <param name="time">时间</param>
        /// <param name="value">值</param>
        private void AddChartPoint(DataPointCollection points,string time,object value)
        {
            points.AddXY(time,value);
            if (points.Count >= 10)
            {
                points.RemoveAt(0);
            }
        }

        private void btn_history_Click(object sender, EventArgs e)
        {
            Form2 form = new Form2();
            form.ShowDialog();
        }
    }
}
