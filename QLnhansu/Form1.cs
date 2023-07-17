using QLnhansu.data;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.Entity.Core.Common.CommandTrees.ExpressionBuilder;
using System.Drawing;
using System.Linq;
using System.Runtime.Remoting.Contexts;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace QLnhansu
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }


        public string find_PB(string mapb)
        {
            string pb="";
            using (var nv = new QLNhansu())
            {
                pb= nv.PHONG_BAN.FirstOrDefault(s => s.MaPB == mapb).TenPB.ToString();
            }
            return pb;
        }
        

        private bool KT_Thongtin()
        {
            return (txt_MANV.Text =="" || txt_TNV.Text == "" ||  DATE_NS.Text =="" || cmb_PB.Text =="")? false : true;
        }
         
        private void DATA_LOAD()
        {
            using (var nv = new QLNhansu())
            {
                var nhanvien_list = nv.Nhan_Vien.Select(s => s).ToList(); // Lấy tất cả phần tử
                dataGridView1.Rows.Clear();
                foreach (var data in nhanvien_list)
                {
                    dataGridView1.Rows.Add(data.MaNV.ToString(), data.TenNV.ToString(), data.Ngaysinh.ToString(), find_PB(data.MaPB));
                }
            }
        }



        private void Form1_Load(object sender, EventArgs e)
        {
            DATA_LOAD();
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (dataGridView1.SelectedRows.Count > 0)
            {
                DataGridViewRow Row = dataGridView1.SelectedRows[0];
                txt_MANV.Text = Row.Cells[0].Value.ToString();
                txt_TNV.Text = Row.Cells[1].Value.ToString();
                DATE_NS.Text = Row.Cells[2].Value.ToString();
                cmb_PB.SelectedIndex = cmb_PB.FindString(Row.Cells[3].Value.ToString());
            }
        }

        public string find_MPB(string pb)
        {
            string mpb = "";
            using (var nv = new QLNhansu())
            {
                mpb = nv.PHONG_BAN.FirstOrDefault(s => s.TenPB == pb).MaPB.ToString();
            }
            return mpb;
        }
        private void btn_Them_Click(object sender, EventArgs e)
        {
            int flag = 0;
            if (KT_Thongtin())
                using (var context = new QLNhansu())
                {
                    var nhanvien_list = context.Nhan_Vien.Select(s => s).ToList(); // Lấy tất cả phần tử
                    foreach (var data in nhanvien_list)
                    {
                        if (data.MaNV.ToString() == txt_MANV.Text)
                        {
                            MessageBox.Show("Mã nhân viên bị trùng");
                            txt_MANV.Text = "";
                            txt_TNV.Text = "";
                            DATE_NS.Text = "";
                            return;
                        }
                    }        
                        
                        
                            var f = new Nhan_Vien() { MaNV = txt_MANV.Text, TenNV = txt_TNV.Text, Ngaysinh = DateTime.Parse(DATE_NS.Text), MaPB = find_MPB(cmb_PB.Text) };
                            context.Nhan_Vien.Add(f);
                            context.SaveChanges();
                            DATA_LOAD();

                            txt_MANV.Text = "";
                            txt_TNV.Text = "";
                            DATE_NS.Text = "";
                        
                    
                }
            else
                MessageBox.Show("Vui lòng nhập đầy đủ thông tin");
           
        }

        private void btn_Sua_Click(object sender, EventArgs e)
        {
            using (var context = new QLNhansu())
            {
                var std = context.Nhan_Vien.First(p => p.MaNV == txt_MANV.Text);
                std.TenNV = txt_TNV.Text;
                std.Ngaysinh = DateTime.Parse(DATE_NS.Text);
                std.MaPB = find_MPB(cmb_PB.Text);
                context.SaveChanges();
                DATA_LOAD();
            }
        }

        private void btn_Xoa_Click(object sender, EventArgs e)
        {
            using(var context = new QLNhansu())
            {
                var std = context.Nhan_Vien.First(p => p.MaNV == txt_MANV.Text);
                context.Nhan_Vien.Remove(std);
                context.SaveChanges();
                DATA_LOAD();
            }
        }

        private void btn_Thoat_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
