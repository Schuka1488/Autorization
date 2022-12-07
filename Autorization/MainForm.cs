using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Microsoft.Office.Interop.Word;
using Excel = Microsoft.Office.Interop.Excel;
using Application = Microsoft.Office.Interop.Word.Application; // передаем application ворду интероп для работы с пакетом 

namespace Autorization
{
    public partial class MainForm : Form
    {
        int dR, dG, dB, sign; // переменные для rgb и индекса таймера
        System.Data.DataTable table; // глобальная переменная для простоты вывода в Microsoft Word
        DBclass db = new DBclass(); // переменная класса для БД, и последующей работе с ними
        private BindingSource bSource = new BindingSource(); // обьявлен для связи с источником соединения
        System.Drawing.Point lastPoint; // специальный класс для задачи координат
        public MainForm()
        {
            InitializeComponent();
        }
        private void MainForm_Load(object sender, EventArgs e)  // краткое описание ролей и их возможностей
        { 
            if (Username.user1.Role == 1) // чтоб обладать полными полномочиями нужно иметь роль 1, это мы передаем в параметры
                изменитьДанныеToolStripMenuItem.Visible = true; // если роль = 1 (например как у администратора) то изменить данные можно
            else
                изменитьДанныеToolStripMenuItem.Visible = false; // иначе, изменить данные нельзя, эти вкладки будут не доступны

            ToolTip toolTip1 = new ToolTip(); // тул тип для подсказок
            toolTip1.AutoPopDelay = 5000; // параметры показа подсказки, в течении какого времени будет видна подсказка
            toolTip1.InitialDelay = 100; // в течении какого кол-ва времени после наведения курсора будет показываться подсказка
            toolTip1.ReshowDelay = 500; // возвращает или задает интервал времени, который должен пройти перед появлением окна очередной всплывающей подсказки при перемещении указателя мыши с одного элемента управления на другой.
            toolTip1.ShowAlways = true; // статус видимости
            toolTip1.SetToolTip(label4, "Закрытие программы");
            ToolTip toolTip2 = new ToolTip(); // тул тип для подсказок
            toolTip2.AutoPopDelay = 5000; // параметры показа подсказки, в течении какого времени будет видна подсказка
            toolTip2.InitialDelay = 100; // в течении какого кол-ва времени после наведения курсора будет показываться подсказка
            toolTip2.ReshowDelay = 500; // возвращает или задает интервал времени, который должен пройти перед появлением окна очередной всплывающей подсказки при перемещении указателя мыши с одного элемента управления на другой.
            toolTip2.ShowAlways = true; // статус видимости
            toolTip2.SetToolTip(label2, "Главное меню создано для просмотра таблиц. \nИзменять данные в таблицах может только сотрудник с ролью admin.\nДля вывода в Microsoft Word необходимо выбрать таблицу в меню сверху (вкладка показать данные)");
        }
        private void panel2_MouseDown(object sender, MouseEventArgs e) //метод который создан для того, чтобы можно было перетаксивать форму, зажимая лкм на панели
        {
            lastPoint = new System.Drawing.Point(e.X, e.Y); // класс поинт создан для определении позиции в пространстве
        }
        private void panel2_MouseMove(object sender, MouseEventArgs e) //метод который создан для того, чтобы можно было перетаксивать форму, зажимая лкм на панели
        {
            if (e.Button == MouseButtons.Left)
            {
                this.Left += e.X - lastPoint.X;
                this.Top += e.Y - lastPoint.Y;
            }
        }
        private void panel1_MouseDown(object sender, MouseEventArgs e) //метод который создан для того, чтобы можно было перетаксивать форму, зажимая лкм на панели
        {
            lastPoint = new System.Drawing.Point(e.X, e.Y); // класс поинт создан для определении позиции в пространстве
        }
        private void panel1_MouseMove(object sender, MouseEventArgs e) //метод который создан для того, чтобы можно было перетаксивать форму, зажимая лкм на панели
        {
            if (e.Button == MouseButtons.Left)
            {
                this.Left += e.X - lastPoint.X;
                this.Top += e.Y - lastPoint.Y;
            }
        }
        private void dataGridView1_MouseDown(object sender, MouseEventArgs e)//метод который создан для того, чтобы можно было перетаксивать форму, зажимая лкм на гриде
        {
            lastPoint = new System.Drawing.Point(e.X, e.Y); // класс поинт создан для определении позиции в пространстве
        }
        private void dataGridView1_MouseMove(object sender, MouseEventArgs e)//метод который создан для того, чтобы можно было перетаксивать форму, зажимая лкм на гриде
        {
            if (e.Button == MouseButtons.Left)
            {
                this.Left += e.X - lastPoint.X;
                this.Top += e.Y - lastPoint.Y;
            }
        }
        private void программуToolStripMenuItem_Click(object sender, EventArgs e) // краткий метод для выхода из программы
        {
            DialogResult res = new DialogResult();
            res = MessageBox.Show("Вы действительно хотите выйти?", "Выход из программы", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (res == DialogResult.Yes)
            { 
                System.Windows.Forms.Application.Exit(); 
            }
            else
            { 
                return; 
            }
            
        }
        private void label4_Click(object sender, EventArgs e) // осуществил выход при помощи тейбла поставив X
        {
            DialogResult res = new DialogResult();
            res = MessageBox.Show("Вы действительно хотите выйти?", "Выход из программы", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (res == DialogResult.Yes)
            {
                System.Windows.Forms.Application.Exit();
            }
            else
            {
                return;
            }
        }
        private void формуToolStripMenuItem_Click(object sender, EventArgs e) // выход из главной формы и возвращение к авторизации, без потери производительности
        {
            this.Hide();
            LoginForm1 auth = new LoginForm1();
            auth.Show();
        }
        private void изменитьДанныеToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Hide();
            ChangeDataForm changedataForm = new ChangeDataForm(); // после авторизации показывается ChangeDataForm
            changedataForm.Show(); // метод для показа ChangeDataForm
        }
        private void WhiteThemeButton_Click(object sender, EventArgs e)
        {
            ThemeMethodClass.LightThemeMethodMainForm(panel1, panel2, dataGridView1, DarkThemeButton, WhiteThemeButton, labelTheme, label1, label2, labelITN, labelNameProject, labelJob, textBoxITN, textBoxNameProject, textBoxJob, richTextBoxTime); //передаем все что хоти изменить
            dR = labelTheme.BackColor.R - labelTheme.ForeColor.R; // используем rgb
            dG = labelTheme.BackColor.G - labelTheme.ForeColor.G;
            dB = labelTheme.BackColor.B - labelTheme.ForeColor.B;
            sign = 2; // знак таймера
            Timer timer = new Timer(); // создаем таймер
            timer.Interval = 10; // интервал с которым будет осуществляться переход 0,1 секунды = значение 10
            timer.Tick += timer2_Tick; // считываем нажатие
            timer.Start(); // таймер срабатывает 
        }
        private void DarkThemeButton_Click(object sender, EventArgs e)
        {
            ThemeMethodClass.DarkThemeMethodMainForm(panel1, panel2, dataGridView1, DarkThemeButton, WhiteThemeButton, labelTheme, label1, label2, labelITN, labelNameProject, labelJob, textBoxITN, textBoxNameProject, textBoxJob, richTextBoxTime); //передаем все что хоти изменить
            dR = labelTheme.BackColor.R - labelTheme.ForeColor.R; // используем rgb
            dG = labelTheme.BackColor.G - labelTheme.ForeColor.G;
            dB = labelTheme.BackColor.B - labelTheme.ForeColor.B;
            sign = 1; // знак таймера
            Timer timer = new Timer(); // создаем таймер
            timer.Interval = 10; // интервал с которым будет осуществляться переход 0,1 секунды = значение 10
            timer.Tick += timer1_Tick; // считываем нажатие
            timer.Start(); // таймер срабатывает 
        }
        private void timer1_Tick(object sender, EventArgs e)
        {
            if (Math.Abs(labelTheme.ForeColor.R - labelTheme.BackColor.R) < Math.Abs(dR / 10))
            {
                sign *= -1;// знак таймера
                labelTheme.Text = "Темная тема вкл."; // указваем какой текст хоти видеть в лейбле
            }
            labelTheme.ForeColor = Color.FromArgb(255, labelTheme.ForeColor.R + sign * dR / 10, labelTheme.ForeColor.G + sign * dG / 10, labelTheme.ForeColor.B + sign * dB / 10);
            if (labelTheme.BackColor.R == labelTheme.ForeColor.R + dR) // параметры для плавного перехода без потери цвета
            {
                ((Timer)sender).Stop(); // таймер останавливается
            }
        }
        private void timer2_Tick(object sender, EventArgs e)
        {
            if (Math.Abs(labelTheme.ForeColor.R - labelTheme.BackColor.R) < Math.Abs(dR / 10))
            {
                sign *= -1; // знак таймера
                labelTheme.Text = "Светлая тема вкл."; // указваем какой текст хоти видеть в лейбле
            }
            labelTheme.ForeColor = Color.FromArgb(255, labelTheme.ForeColor.R + sign * dR / 10, labelTheme.ForeColor.G + sign * dG / 10, labelTheme.ForeColor.B + sign * dB / 10);
            if (labelTheme.BackColor.R == labelTheme.ForeColor.R + dR) // параметры для плавного перехода без потери цвета
            {
                ((Timer)sender).Stop(); // таймер останавливается
            }

        }
        private void timer3_Tick(object sender, EventArgs e)
        {
            string dateandtime = DateTime.Now.ToString();
            richTextBoxTime.Text = dateandtime;
        }

        private void таблицаСотрудниковToolStripMenuItem_Click(object sender, EventArgs e) // метод при нажатии которого осуществяется SQL запрос с получением данных из таблицы БД
        {
            string commandStr = "SELECT EmployeesID AS 'Код сотрудника', employeesBirthday AS 'Дата рождения сотрудника', employeesDateOfEmployed AS 'Дата приема на работу', employeesName AS 'Имя', employeesSurname AS 'Фамилия', employeesPatronymic AS 'Отчество', employeesJobTitle AS 'Профессия' FROM Employees"; // SQL запрос данных из БД
            MySqlCommand cmd = new MySqlCommand(commandStr, db.getConnection()); // осуществяется подключение к БД
            MySqlDataAdapter adapter = new MySqlDataAdapter(); // используется адаптер для получения таблицы 
            table = new System.Data.DataTable(); // создание элемента таблицы
            adapter.SelectCommand = cmd; // адаптер берет соединение
            adapter.Fill(table); // адаптер передает значение для того чтобы показать таблицу
            bSource.DataSource = table;  // принимается таблица для последующего показа таблицы
            dataGridView1.DataSource = bSource; // показывается таблица при выборе вкладки
            dataGridView1.Columns[5].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill; // автосайз для столбца для гридера (растягивает столбец по ширине)
            dataGridView1.Columns[6].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill; // автосайз для столбца для гридера (растягивает столбец по ширине)

            labelJob.Visible = true;
            textBoxJob.Visible = true;

            labelITN.Visible = false;
            textBoxITN.Visible = false;

            labelNameProject.Visible = false;
            textBoxNameProject.Visible = false;
        }
        private void таблицаКлиентовToolStripMenuItem_Click(object sender, EventArgs e) // метод при нажатии которого осуществяется SQL запрос с получением данных из таблицы БД
        {
            string commandStr = "SELECT CustomerID AS 'Код клиента', customerCompanyName AS 'Название компании', customerAddress AS 'Адрес компании', PSRN AS 'ОГРН', ITN AS 'ИНН', TRRC AS 'КПП' FROM Customer"; // SQL запрос данных из БД
            MySqlCommand cmd = new MySqlCommand(commandStr, db.getConnection()); // осуществяется подключение к БД
            MySqlDataAdapter adapter = new MySqlDataAdapter(); // используется адаптер для получения таблицы 
            table = new System.Data.DataTable(); // создание элемента таблицы
            adapter.SelectCommand = cmd; // адаптер берет соединение
            adapter.Fill(table); // адаптер передает значение для того чтобы показать таблицу
            bSource.DataSource = table;  // принимается таблица для последующего показа таблицы
            dataGridView1.DataSource = bSource; // показывается таблица при выборе вкладки
            dataGridView1.Columns[1].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill; // автосайз для столбца для гридера (растягивает столбец по ширине)
            dataGridView1.Columns[2].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill; // автосайз для столбца для гридера (растягивает столбец по ширине)

            labelJob.Visible = false;
            textBoxJob.Visible = false;

            labelITN.Visible = true;
            textBoxITN.Visible = true;

            labelNameProject.Visible = false;
            textBoxNameProject.Visible = false;
        }
        private void таблицаЗаказовToolStripMenuItem_Click(object sender, EventArgs e) // метод при нажатии которого осуществяется SQL запрос с получением данных из таблицы БД
        {
            string commandStr = "SELECT ProjectOrderID AS 'Код заказа', projectName AS 'Название проекта', projectCategory AS 'Категория проекта', 	projectPrice AS 'Цена в рублях', ProjectID AS 'Код проекта', EmployeesID AS 'Код сотрудника', CustomerID AS 'Код клиента' FROM ProjectOrder"; // SQL запрос данных из БД
            MySqlCommand cmd = new MySqlCommand(commandStr, db.getConnection()); // осуществяется подключение к БД
            MySqlDataAdapter adapter = new MySqlDataAdapter(); // используется адаптер для получения таблицы 
            table = new System.Data.DataTable(); // создание элемента таблицы
            adapter.SelectCommand = cmd; // адаптер берет соединение
            adapter.Fill(table); // адаптер передает значение для того чтобы показать таблицу
            bSource.DataSource = table;  // принимается таблица для последующего показа таблицы
            dataGridView1.DataSource = bSource; // показывается таблица при выборе вкладки
            dataGridView1.Columns[1].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill; // автосайз для столбца для гридера (растягивает столбец по ширине)

            labelJob.Visible = false;
            textBoxJob.Visible = false;

            labelITN.Visible = false;
            textBoxITN.Visible = false;

            labelNameProject.Visible = true;
            textBoxNameProject.Visible = true;
        }
        private void таблицаПродажToolStripMenuItem_Click(object sender, EventArgs e) // метод при нажатии которого осуществяется SQL запрос с получением данных из таблицы БД
        {
            string commandStr = "SELECT ProjectID AS 'Код проекта', SaleID AS 'Код продажи', datePurchase AS 'Дата покупки' FROM ProjectSales"; // SQL запрос данных из БД
            MySqlCommand cmd = new MySqlCommand(commandStr, db.getConnection()); // осуществяется подключение к БД
            MySqlDataAdapter adapter = new MySqlDataAdapter(); // используется адаптер для получения таблицы 
            table = new System.Data.DataTable(); // создание элемента таблицы
            adapter.SelectCommand = cmd; // адаптер берет соединение
            adapter.Fill(table); // адаптер передает значение для того чтобы показать таблицу
            bSource.DataSource = table;  // принимается таблица для последующего показа таблицы
            dataGridView1.DataSource = bSource; // показывается таблица при выборе вкладки
            dataGridView1.Columns[0].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill; // автосайз для столбца для гридера (растягивает столбец по ширине)
            dataGridView1.Columns[1].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill; // автосайз для столбца для гридера (растягивает столбец по ширине)
            dataGridView1.Columns[2].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill; // автосайз для столбца для гридера (растягивает столбец по ширине)

            labelJob.Visible = false;
            textBoxJob.Visible = false;

            labelITN.Visible = false;
            textBoxITN.Visible = false;

            labelNameProject.Visible = false;
            textBoxNameProject.Visible = false;
        }
        private void таблицаЦенToolStripMenuItem_Click(object sender, EventArgs e) // метод при нажатии которого осуществяется SQL запрос с получением данных из таблицы БД
        {
            string commandStr = "SELECT SaleID AS 'Код продажи', saleDate AS 'Дата продажи', saleNotes AS 'Кол-во страниц', saleCost AS 'Цена в рублях' FROM Sales"; // SQL запрос данных из БД
            MySqlCommand cmd = new MySqlCommand(commandStr, db.getConnection()); // осуществяется подключение к БД
            MySqlDataAdapter adapter = new MySqlDataAdapter(); // используется адаптер для получения таблицы 
            table = new System.Data.DataTable(); // создание элемента таблицы
            adapter.SelectCommand = cmd; // адаптер берет соединение
            adapter.Fill(table); // адаптер передает значение для того чтобы показать таблицу
            bSource.DataSource = table;  // принимается таблица для последующего показа таблицы
            dataGridView1.DataSource = bSource; // показывается таблица при выборе вкладки
            dataGridView1.Columns[0].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill; // автосайз для столбца для гридера (растягивает столбец по ширине)
            dataGridView1.Columns[1].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill; // автосайз для столбца для гридера (растягивает столбец по ширине)
            dataGridView1.Columns[2].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill; // автосайз для столбца для гридера (растягивает столбец по ширине)
            dataGridView1.Columns[3].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;

            labelJob.Visible = false;
            textBoxJob.Visible = false;

            labelITN.Visible = false;
            textBoxITN.Visible = false;

            labelNameProject.Visible = false;
            textBoxNameProject.Visible = false;
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            table.DefaultView.RowFilter = $"Профессия LIKE '%{textBoxJob.Text}%'";
        }

        private void textBoxITN_TextChanged(object sender, EventArgs e)
        {
            if (textBoxITN.Text.Length < 0) return;
            table.DefaultView.RowFilter = $"Convert(ИНН, System.String) LIKE '%{textBoxITN.Text}%'";
        }

        private void textBoxNameProject_TextChanged(object sender, EventArgs e)
        {
            table.DefaultView.RowFilter = $"`Название проекта` LIKE '%{textBoxNameProject.Text}%'";
        }
        private void печатьToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            Application app = new Application();
            Document doc = app.Documents.Add(Visible: true);
            Range r = doc.Range();
            Table t = doc.Tables.Add(r, dataGridView1.Rows.Count + 1, dataGridView1.Columns.Count);
            int bdRow = 0;
            bool IsColumnReady = false;
            t.Borders.Enable = 1;
            foreach (Row row in t.Rows)
            {
                if (!IsColumnReady && bdRow == 0)
                {
                    int tableCounter = 0;
                    foreach (Cell cell in row.Cells)
                    {
                        cell.Range.Text = table.Columns[tableCounter].ColumnName;
                        tableCounter++;
                    }
                    IsColumnReady = true;
                    continue;
                }
                object[] collection = table.Rows[bdRow].ItemArray;
                int cellCount = 0;
                foreach (Cell cell in row.Cells)
                {
                    cell.Range.Text = collection[cellCount].ToString();
                    cellCount++;
                }
                bdRow++;
            }
            doc.Save();
        }

        private void выводВMicrosoftExcelВыбраннойТаблицыToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Excel.Application exApp = new Excel.Application();
            exApp.Workbooks.Add();
            Excel.Worksheet wsh = (Excel.Worksheet)exApp.ActiveSheet;
            wsh.Cells[1, 1] = dataGridView1.Columns.ToString();
            int i, j;
            for(i=0; i<=dataGridView1.RowCount-1;i++)
            {
                for (j=0;j<=dataGridView1.ColumnCount-1;j++)
                {
                    wsh.Cells[1, j + 1] = dataGridView1.Columns[j].HeaderText.ToString();
                    wsh.Cells[i+2, j+1] = dataGridView1[j, i].Value.ToString();
                }
            }
            exApp.Visible = true;
        }
    }
}
