using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Supabase.Core.Extensions;
using Supabase.Postgrest.Attributes;
using Supabase.Postgrest.Models;
using static Supabase.Postgrest.Constants;

namespace WinFormsApp1
{
    public partial class TodoList : UserControl
    {
        Supabase.Client supa = DataBase.GetInstance().supa;
        List<TodoItem> entries = new List<TodoItem>();
        List<TodoItem> checkedRows = new List<TodoItem>();
        [Table("todo")]
        public class TodoItem : BaseModel
        {
            [PrimaryKey("id")]
            [Column("id")]
            public string id { get; set; }

            [Column("todo")]
            public string todo { get; set; }
            [Column("completed")]
            public bool completed { get; set; }
            [Column("user_id")]
            public string user_id { get; set; }
        }
        [Table("todo")]
        public class TodoInsert : BaseModel
        {
            [Column("todo")]
            public string todo { get; set; }
            [Column("completed")]
            public bool completed { get; set; }
            [Column("user_id")]
            public string user_id { get; set; }
        }

        public TodoList()
        {
            InitializeComponent();
            writeTodo();

        }


        async private void writeTodo()
        {
            var result = await supa.From<TodoItem>().Select("todo,completed,user_id,id").Filter("user_id", Operator.Equals, Form1._id).Get();
            entries = result.Models ?? new List<TodoItem>();
            foreach (var item in entries)
            {
                string status = item.completed ? "완료" : "미완료";
                bool check = false;
                int rowIndex = dataGridView1.Rows.Add(check, item.todo, status, item.id);
                var row = dataGridView1.Rows[rowIndex];
                if (item.completed)
                {
                    row.Cells[2].Style.Font = new Font(dataGridView1.Font, FontStyle.Strikeout); // 취소선
                    row.Cells[2].Style.ForeColor = Color.Green;
                }
                else
                    row.Cells[2].Style.ForeColor = Color.Red;

            }
        }

        async private void button1_Click(object sender, EventArgs e)
        {
            if (Form1._id == null)
            {
                MessageBox.Show("로그인 후 사용가능합니다.");
                return;
            }
            else if (textBox1.Text.Length == 0)
            {
                MessageBox.Show("내용을 입력하고 추가해주세요.");
                return;
            }
            var data = new TodoInsert
            {
                completed = false,
                todo = textBox1.Text,
                user_id = Form1._id
            };
            var result = await supa.From<TodoInsert>().Insert(data);
            dataGridView1.Rows.Clear();
            writeTodo();
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            //if (e.ColumnIndex == 0 && e.RowIndex >= 0)
            //{
            //    dataGridView1.CommitEdit(DataGridViewDataErrorContexts.Commit);

            //}
        }

        //체크 이벤트를 위해 만듬
        private void dataGridView1_CellContentClick_1(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0 && e.ColumnIndex == 0)
            {
                if (e.RowIndex < entries.Count)
                {

                    var row = dataGridView1.Rows[e.RowIndex];
                    bool isChecked = Convert.ToBoolean(row.Cells[0].Value);
                    row.Cells[0].Value = !isChecked;
                    if (!isChecked)
                    {

                        bool complete = row.Cells[2].Value == "완료" ? true : false;
                        var data = new TodoItem
                        {
                            completed = complete,
                            todo = (string)row.Cells[1].Value,
                            user_id = Form1._id,
                            id = (string)row.Cells[3].Value
                        };
                        checkedRows.Add(data);
                    }
                    else
                    {
                        checkedRows.RemoveAt(checkedRows.FindIndex(x => x.todo == (string)row.Cells[1].Value));
                    }

                }
            }
        }

        //완료 기능
        async private void button2_Click(object sender, EventArgs e)
        {
            if (Form1._id == null)
            {
                MessageBox.Show("로그인 이후 이용해주세요");
                return;
            }
            else if (checkedRows.Count == 0)
            {
                MessageBox.Show("선택 후 처리 가능합니다.");
                return;
            }
            foreach (var item in checkedRows)
            {
                
            await supa.From<TodoItem>().Where(x=>x.id==item.id).Set(x=>x.completed,!item.completed).Update();
                
            }
            dataGridView1.Rows.Clear();
            writeTodo();
        }

        //삭제
        async private void button3_Click(object sender, EventArgs e)
        {
            if (Form1._id == null)
            {
                MessageBox.Show("로그인 이후 이용해주세요");
                return;
            }
            else if (checkedRows.Count == 0)
            {
                MessageBox.Show("선택 후 처리 가능합니다.");
                return;
            }

            foreach (var item in checkedRows)
            {
                
                await supa.From<TodoItem>().Where(x=>x.id==item.id).Delete();
            }
                dataGridView1.Rows.Clear();
                writeTodo();
        }



    }
}
