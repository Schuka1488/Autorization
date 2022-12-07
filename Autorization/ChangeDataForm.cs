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

namespace Autorization
{
    public partial class ChangeDataForm : Form
    {
        int dR, dG, dB, sign; // переменные для rgb и индекса таймера
        DataTable table; // глобальная переменная для простоты вывода в Microsoft Word
        DBclass db = new DBclass(); // переменная класса для БД, и последующей работе с ними
        private BindingSource bSource = new BindingSource(); // обьявлен для связи с источником соединения
        Point lastPoint; // специальный класс для задачи координат
        string id_selected_rows; // переменная для определения целой строки, по нажатию на поле id в dataGrid

        public ChangeDataForm()
        {
            InitializeComponent();
        }
        private void ChangeDataForm_Load(object sender, EventArgs e)
        {
            ToolTip toolTip1 = new ToolTip(); // тул тип для подсказок
            toolTip1.AutoPopDelay = 5000; // параметры показа подсказки, в течении какого времени будет видна подсказка
            toolTip1.InitialDelay = 1000; // в течении какого кол-ва времени после наведения курсора будет показываться подсказка
            toolTip1.ReshowDelay = 500; // возвращает или задает интервал времени, который должен пройти перед появлением окна очередной всплывающей подсказки при перемещении указателя мыши с одного элемента управления на другой.
            toolTip1.ShowAlways = true; // статус видимости
            toolTip1.SetToolTip(label4, "Закрытие программы");
            ToolTip toolTip2 = new ToolTip(); // тул тип для подсказок
            toolTip2.AutoPopDelay = 5000; // параметры показа подсказки, в течении какого времени будет видна подсказка
            toolTip2.InitialDelay = 1000; // в течении какого кол-ва времени после наведения курсора будет показываться подсказка
            toolTip2.ReshowDelay = 500; // возвращает или задает интервал времени, который должен пройти перед появлением окна очередной всплывающей подсказки при перемещении указателя мыши с одного элемента управления на другой.
            toolTip2.ShowAlways = true; // статус видимости
            toolTip2.SetToolTip(label2, "Коды (ID поля) не нужно заполнять, они заполняются автоматически! \n Даты пишутся в формате 2004-12-12\n Первое число - год, Второе - месяц, Третье - день.");
        }

        private void panel5_MouseDown(object sender, MouseEventArgs e)
        {
            lastPoint = new Point(e.X, e.Y); // класс поинт создан для определении позиции в пространстве
        }

        private void panel5_MouseMove(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left) //определяет координату панели по оси X и Y, считывает ее перемещение
            {
                this.Left += e.X - lastPoint.X;
                this.Top += e.Y - lastPoint.Y;
            }
        }

        private void panel4_MouseDown(object sender, MouseEventArgs e)
        {
            lastPoint = new Point(e.X, e.Y); // класс поинт создан для определении позиции в пространстве
        }

        private void panel4_MouseMove(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left) //определяет координату панели по оси X и Y, считывает ее перемещение
            {
                this.Left += e.X - lastPoint.X;
                this.Top += e.Y - lastPoint.Y;
            }
        }
        private void dataGridViewTransformData2_MouseDown(object sender, MouseEventArgs e)
        {
            lastPoint = new Point(e.X, e.Y); // класс поинт создан для определении позиции в пространстве
        }

        private void dataGridViewTransformData2_MouseMove(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left) //определяет координату панели по оси X и Y, считывает ее перемещение
            {
                this.Left += e.X - lastPoint.X;
                this.Top += e.Y - lastPoint.Y;
            }
        }

        private void изПрограммыToolStripMenuItem_Click(object sender, EventArgs e)
        {
            DialogResult res = new DialogResult();
            res = MessageBox.Show("Вы действительно хотите выйти?", "Выход из программы", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (res == DialogResult.Yes)
            {
                Application.Exit();
            }
            else
            {
                return;
            }
        }
        private void label4_Click(object sender, EventArgs e)
        {
            DialogResult res = new DialogResult();
            res = MessageBox.Show("Вы действительно хотите выйти?", "Выход из программы", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (res == DialogResult.Yes)
            {
                Application.Exit();
            }
            else
            {
                return;
            }
        }

        private void изАккаунтаToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Hide(); // сокрытие открытой формы
            LoginForm1 auth = new LoginForm1();
            auth.Show(); // открытие формы аунтефикации 
        }

        private void вГлавноеМенюToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Hide(); // сокрытие открытой формы
            MainForm main = new MainForm();
            main.Show(); // открытие главной формы
        }
        #region [ Кнопки тем ]
        private void WhiteThemeButton_Click(object sender, EventArgs e)
        {
            ThemeMethodClass.LightThemeMethodChangeDataForm(panel4, panel5, dataGridViewTransformData2, DarkThemeButton, WhiteThemeButton, 

                labelTheme, AddLineButton, AddLineButton2, AddLineButton3, AddLineButton4, AddLineButton5, AddLineButton6, label1, 

                label2, Column1Label, Column2Label, Column3Label, Column4Label, Column5Label, Column6Label, Column7Label, textBox1,
                
                textBox2, textBox3, textBox4, textBox5, textBox6, textBox7, ResetButton,  ResetButton2, ResetButton3,  ResetButton4,  ResetButton5, ResetButton6,

                DeleteLineButton, DeleteLineButton2, DeleteLineButton3, DeleteLineButton4, DeleteLineButton5, DeleteLineButton6,

                richTextBoxTime);

            dR = labelTheme.BackColor.R - labelTheme.ForeColor.R;
            dG = labelTheme.BackColor.G - labelTheme.ForeColor.G;
            dB = labelTheme.BackColor.B - labelTheme.ForeColor.B;
            sign = 2;
            Timer timer = new Timer();
            timer.Interval = 10;
            timer.Tick += timer2_Tick;
            timer.Start();
        }

        private void DarkThemeButton_Click(object sender, EventArgs e)
        {
            ThemeMethodClass.DarkThemeMethodChangeDataForm(panel4, panel5, dataGridViewTransformData2, DarkThemeButton, WhiteThemeButton, 

                labelTheme, AddLineButton, AddLineButton2, AddLineButton3, AddLineButton4, AddLineButton5, AddLineButton6, label1, 

                label2, Column1Label, Column2Label, Column3Label, Column4Label, Column5Label, Column6Label, Column7Label, textBox1,
                
                textBox2, textBox3, textBox4, textBox5, textBox6, textBox7, ResetButton, ResetButton2, ResetButton3, ResetButton4, ResetButton5, ResetButton6,

                DeleteLineButton, DeleteLineButton2, DeleteLineButton3, DeleteLineButton4, DeleteLineButton5, DeleteLineButton6,

                richTextBoxTime);

            dR = labelTheme.BackColor.R - labelTheme.ForeColor.R;
            dG = labelTheme.BackColor.G - labelTheme.ForeColor.G;
            dB = labelTheme.BackColor.B - labelTheme.ForeColor.B;
            sign = 1;
            Timer timer = new Timer();
            timer.Interval = 10;
            timer.Tick += timer1_Tick;
            timer.Start();
        }
        private void timer1_Tick(object sender, EventArgs e)
        {
            if (Math.Abs(labelTheme.ForeColor.R - labelTheme.BackColor.R) < Math.Abs(dR / 10))
            {
                sign *= -1;
                labelTheme.Text = "Темная тема вкл.";
            }
            labelTheme.ForeColor = Color.FromArgb(255, labelTheme.ForeColor.R + sign * dR / 10, labelTheme.ForeColor.G + sign * dG / 10, labelTheme.ForeColor.B + sign * dB / 10);
            if (labelTheme.BackColor.R == labelTheme.ForeColor.R + dR)
            {
                ((Timer)sender).Stop();
            }
        }
        private void timer2_Tick(object sender, EventArgs e)
        {
            if (Math.Abs(labelTheme.ForeColor.R - labelTheme.BackColor.R) < Math.Abs(dR / 10))
            {
                sign *= -1;
                labelTheme.Text = "Светлая тема вкл.";
            }
            labelTheme.ForeColor = Color.FromArgb(255, labelTheme.ForeColor.R + sign * dR / 10, labelTheme.ForeColor.G + sign * dG / 10, labelTheme.ForeColor.B + sign * dB / 10);
            if (labelTheme.BackColor.R == labelTheme.ForeColor.R + dR)
            {
                ((Timer)sender).Stop();
            }
        }
        private void timer3_Tick(object sender, EventArgs e)
        {
            string dateandtime = DateTime.Now.ToString();
            richTextBoxTime.Text = dateandtime;
        }
        #endregion
        private void EmployeesTableReset()
        {
            string commandStr = "SELECT EmployeesID AS 'Код сотрудника', employeesBirthday AS 'Дата рождения сотрудника', employeesDateOfEmployed AS 'Дата приема на работу', employeesName AS 'Имя', employeesSurname AS 'Фамилия', employeesPatronymic AS 'Отчество', employeesJobTitle AS 'Профессия' FROM Employees"; // SQL запрос данных из БД
            MySqlCommand cmd = new MySqlCommand(commandStr, db.getConnection()); // осуществяется подключение к БД
            MySqlDataAdapter adapter = new MySqlDataAdapter(); // используется адаптер для получения таблицы 
            table = new DataTable(); // класс для таблиц
            adapter.SelectCommand = cmd; // адаптер берет соединение
            adapter.Fill(table); // адаптер передает значение для того чтобы показать таблицу
            bSource.DataSource = table;  // принимается таблица для последующего показа таблицы
            dataGridViewTransformData2.DataSource = bSource; // показывается таблица при выборе вкладки
            dataGridViewTransformData2.Columns[0].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill; // автосайз для столбца для гридера (растягивает столбец по ширине)
            dataGridViewTransformData2.Columns[1].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill; // автосайз для столбца для гридера (растягивает столбец по ширине)
            dataGridViewTransformData2.Columns[2].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill; // автосайз для столбца для гридера (растягивает столбец по ширине)
            dataGridViewTransformData2.Columns[3].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill; // автосайз для столбца для гридера (растягивает столбец по ширине)
            dataGridViewTransformData2.Columns[4].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill; // автосайз для столбца для гридера (растягивает столбец по ширине)
            dataGridViewTransformData2.Columns[5].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill; // автосайз для столбца для гридера (растягивает столбец по ширине)
            dataGridViewTransformData2.Columns[6].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill; // автосайз для столбца для гридера (растягивает столбец по ширине)

            textBox1.Visible = false; // сокрытие и показ всех необходимых элементов формы
            textBox2.Visible = true;
            textBox3.Visible = true;
            textBox4.Visible = true;
            textBox5.Visible = true;
            textBox6.Visible = true;
            textBox7.Visible = true;

            Column1Label.Visible = false;
            Column2Label.Visible = true;
            Column3Label.Visible = true;
            Column4Label.Visible = true;
            Column5Label.Visible = true;
            Column6Label.Visible = true;
            Column7Label.Visible = true;

            AddLineButton.Visible = true;
            AddLineButton2.Visible = false;
            AddLineButton3.Visible = false;
            AddLineButton4.Visible = false;
            AddLineButton5.Visible = false;
            AddLineButton6.Visible = false;

            ResetButton.Visible = true;
            ResetButton2.Visible = false;
            ResetButton3.Visible = false;
            ResetButton4.Visible = false;
            ResetButton5.Visible = false;
            ResetButton6.Visible = false;

            DeleteLineButton.Visible = true;
            DeleteLineButton2.Visible = false;
            DeleteLineButton3.Visible = false;
            DeleteLineButton4.Visible = false;
            DeleteLineButton5.Visible = false;
            DeleteLineButton6.Visible = false;
        }
        private void вТаблицеСотрудникиToolStripMenuItem_Click(object sender, EventArgs e)
        {
            string commandStr = "SELECT EmployeesID AS 'Код сотрудника', employeesBirthday AS 'Дата рождения сотрудника', employeesDateOfEmployed AS 'Дата приема на работу', employeesName AS 'Имя', employeesSurname AS 'Фамилия', employeesPatronymic AS 'Отчество', employeesJobTitle AS 'Профессия' FROM Employees"; // SQL запрос данных из БД
            MySqlCommand cmd = new MySqlCommand(commandStr, db.getConnection()); // осуществяется подключение к БД
            MySqlDataAdapter adapter = new MySqlDataAdapter(); // используется адаптер для получения таблицы 
            table = new DataTable(); // класс для таблиц
            adapter.SelectCommand = cmd; // адаптер берет соединение
            adapter.Fill(table); // адаптер передает значение для того чтобы показать таблицу
            bSource.DataSource = table;  // принимается таблица для последующего показа таблицы
            dataGridViewTransformData2.DataSource = bSource; // показывается таблица при выборе вкладки
            dataGridViewTransformData2.Columns[0].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill; // автосайз для столбца для гридера (растягивает столбец по ширине)
            dataGridViewTransformData2.Columns[1].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill; // автосайз для столбца для гридера (растягивает столбец по ширине)
            dataGridViewTransformData2.Columns[2].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill; // автосайз для столбца для гридера (растягивает столбец по ширине)
            dataGridViewTransformData2.Columns[3].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill; // автосайз для столбца для гридера (растягивает столбец по ширине)
            dataGridViewTransformData2.Columns[4].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill; // автосайз для столбца для гридера (растягивает столбец по ширине)
            dataGridViewTransformData2.Columns[5].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill; // автосайз для столбца для гридера (растягивает столбец по ширине)
            dataGridViewTransformData2.Columns[6].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill; // автосайз для столбца для гридера (растягивает столбец по ширине)

            textBox1.Visible = false; // сокрытие и показ всех необходимых элементов формы
            textBox2.Visible = true;
            textBox3.Visible = true;
            textBox4.Visible = true;
            textBox5.Visible = true;
            textBox6.Visible = true;
            textBox7.Visible = true;
                Column1Label.Visible = false;
                Column2Label.Visible = true;
                Column3Label.Visible = true;
                Column4Label.Visible = true;
                Column5Label.Visible = true;
                Column6Label.Visible = true;
                Column7Label.Visible = true;
                        AddLineButton.Visible = true;
                        AddLineButton2.Visible = false;
                        AddLineButton3.Visible = false;
                        AddLineButton4.Visible = false;
                        AddLineButton5.Visible = false;
                        AddLineButton6.Visible = false;
                                 ResetButton.Visible = true;
                                 ResetButton2.Visible = false;
                                 ResetButton3.Visible = false;
                                 ResetButton4.Visible = false;
                                 ResetButton5.Visible = false;
                                 ResetButton6.Visible = false;
            DeleteLineButton.Visible = true;
            DeleteLineButton2.Visible = false;
            DeleteLineButton3.Visible = false;
            DeleteLineButton4.Visible = false;
            DeleteLineButton5.Visible = false;
            DeleteLineButton6.Visible = false;
        }
        private void SupplemenEmloyee()
        {
            try
            {
                db.openConnection();
                MySqlCommand cmd = new MySqlCommand($"INSERT INTO Employees(employeesBirthday, employeesDateOfEmployed, employeesName, employeesSurname, employeesPatronymic, employeesJobTitle ) VALUES( \"{textBox2.Text}\", \"{textBox3.Text}\",'{textBox4.Text}','{textBox5.Text}','{textBox6.Text}','{textBox7.Text}')", db.getConnection());
                MessageBox.Show(cmd.ExecuteNonQuery() > 0 ? "Данные добавились!" : "Данные не добавились!");
                db.closeConnection();
            }
            catch
            {
                MessageBox.Show("Данные не добавились!","Ошибка ввода!", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                db.closeConnection();
            }
        }
        private void DeleteTable()
        {
            try
            {
                db.openConnection();
                MySqlCommand cmd = new MySqlCommand($"DELETE FROM Employees WHERE EmployeesID = {id_selected_rows}", db.getConnection());
                MessageBox.Show(cmd.ExecuteNonQuery() > 0 ? "Данные удалены!" : "Данные не удалены!");
                db.closeConnection();
            }
            catch
            {
                MessageBox.Show("Данные не удалены!","Строка не выбрана!", MessageBoxButtons.OKCancel, MessageBoxIcon.Error);
                db.closeConnection();
            }
        }
        private void CustomerTableReset()
        {
            string commandStr = "SELECT CustomerID AS 'Код клиента', customerCompanyName AS 'Название компании', customerAddress AS 'Адрес компании', PSRN AS 'ОГРН', ITN AS 'ИНН', TRRC AS 'КПП' FROM Customer"; // SQL запрос данных из БД
            MySqlCommand cmd = new MySqlCommand(commandStr, db.getConnection()); // осуществяется подключение к БД
            MySqlDataAdapter adapter = new MySqlDataAdapter(); // используется адаптер для получения таблицы 
            table = new DataTable(); // класс для таблиц
            adapter.SelectCommand = cmd; // адаптер берет соединение
            adapter.Fill(table); // адаптер передает значение для того чтобы показать таблицу
            bSource.DataSource = table;  // принимается таблица для последующего показа таблицы
            dataGridViewTransformData2.DataSource = bSource; // показывается таблица при выборе вкладки
            dataGridViewTransformData2.Columns[0].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill; // автосайз для столбца для гридера (растягивает столбец по ширине)
            dataGridViewTransformData2.Columns[1].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill; // автосайз для столбца для гридера (растягивает столбец по ширине)
            dataGridViewTransformData2.Columns[2].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill; // автосайз для столбца для гридера (растягивает столбец по ширине)
            dataGridViewTransformData2.Columns[3].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill; // автосайз для столбца для гридера (растягивает столбец по ширине)
            dataGridViewTransformData2.Columns[4].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill; // автосайз для столбца для гридера (растягивает столбец по ширине)
            dataGridViewTransformData2.Columns[5].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill; // автосайз для столбца для гридера (растягивает столбец по ширине)

            textBox1.Visible = false; // сокрытие и показ всех необходимых элементов формы
            textBox2.Visible = true;
            textBox3.Visible = true;
            textBox4.Visible = true;
            textBox5.Visible = true;
            textBox6.Visible = true;
            textBox7.Visible = false;

            Column1Label.Visible = false;
            Column2Label.Visible = true;
            Column3Label.Visible = true;
            Column4Label.Visible = true;
            Column5Label.Visible = true;
            Column6Label.Visible = true;
            Column7Label.Visible = false;

            AddLineButton.Visible = false;
            AddLineButton2.Visible = true;
            AddLineButton3.Visible = false;
            AddLineButton4.Visible = false;
            AddLineButton5.Visible = false;
            AddLineButton6.Visible = false;

            ResetButton.Visible = false;
            ResetButton2.Visible = true;
            ResetButton3.Visible = false;
            ResetButton4.Visible = false;
            ResetButton5.Visible = false;
            ResetButton6.Visible = false;

            DeleteLineButton.Visible = false;
            DeleteLineButton2.Visible = true;
            DeleteLineButton3.Visible = false;
            DeleteLineButton4.Visible = false;
            DeleteLineButton5.Visible = false;
            DeleteLineButton6.Visible = false;
        }
        private void вТаблицеЗаказчикиToolStripMenuItem_Click(object sender, EventArgs e)
        {
            string commandStr = "SELECT CustomerID AS 'Код клиента', customerCompanyName AS 'Название компании', customerAddress AS 'Адрес компании', PSRN AS 'ОГРН', ITN AS 'ИНН', TRRC AS 'КПП' FROM Customer"; // SQL запрос данных из БД
            MySqlCommand cmd = new MySqlCommand(commandStr, db.getConnection()); // осуществяется подключение к БД
            MySqlDataAdapter adapter = new MySqlDataAdapter(); // используется адаптер для получения таблицы 
            table = new DataTable(); // класс для таблиц
            adapter.SelectCommand = cmd; // адаптер берет соединение
            adapter.Fill(table); // адаптер передает значение для того чтобы показать таблицу
            bSource.DataSource = table;  // принимается таблица для последующего показа таблицы
            dataGridViewTransformData2.DataSource = bSource; // показывается таблица при выборе вкладки
            dataGridViewTransformData2.Columns[0].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill; // автосайз для столбца для гридера (растягивает столбец по ширине)
            dataGridViewTransformData2.Columns[1].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill; // автосайз для столбца для гридера (растягивает столбец по ширине)
            dataGridViewTransformData2.Columns[2].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill; // автосайз для столбца для гридера (растягивает столбец по ширине)
            dataGridViewTransformData2.Columns[3].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill; // автосайз для столбца для гридера (растягивает столбец по ширине)
            dataGridViewTransformData2.Columns[4].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill; // автосайз для столбца для гридера (растягивает столбец по ширине)
            dataGridViewTransformData2.Columns[5].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill; // автосайз для столбца для гридера (растягивает столбец по ширине)

            textBox1.Visible = false; // сокрытие и показ всех необходимых элементов формы
            textBox2.Visible = true;
            textBox3.Visible = true;
            textBox4.Visible = true;
            textBox5.Visible = true;
            textBox6.Visible = true;
            textBox7.Visible = false;
                Column1Label.Visible = false;
                Column2Label.Visible = true;
                Column3Label.Visible = true;
                Column4Label.Visible = true;
                Column5Label.Visible = true;
                Column6Label.Visible = true;
                Column7Label.Visible = false;
                        AddLineButton.Visible = false;
                        AddLineButton2.Visible = true;
                        AddLineButton3.Visible = false;
                        AddLineButton4.Visible = false;
                        AddLineButton5.Visible = false;
                        AddLineButton6.Visible = false;
                                 ResetButton.Visible = false;
                                 ResetButton2.Visible = true;
                                 ResetButton3.Visible = false;
                                 ResetButton4.Visible = false;
                                 ResetButton5.Visible = false;
                                 ResetButton6.Visible = false;
            DeleteLineButton.Visible = false;
            DeleteLineButton2.Visible = true;
            DeleteLineButton3.Visible = false;
            DeleteLineButton4.Visible = false;
            DeleteLineButton5.Visible = false;
            DeleteLineButton6.Visible = false;
        }
        private void SupplemenEmloyee2()
        {
            try
            {
                db.openConnection();
                MySqlCommand cmd = new MySqlCommand($"INSERT INTO Customer(customerCompanyName, customerAddress, PSRN, ITN) VALUES( '{textBox2.Text}', '{textBox3.Text}',{textBox4.Text},{textBox5.Text},{textBox6.Text})", db.getConnection());
                MessageBox.Show(cmd.ExecuteNonQuery() > 0 ? "Данные добавились!" : "Данные не добавились!");
                db.closeConnection();
            }
            catch
            {
                MessageBox.Show("Данные не добавились!", "Ошибка ввода!", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                db.closeConnection();
            }
        }
        private void DeleteTable2()
        {
            try
            {
                db.openConnection();
                MySqlCommand cmd = new MySqlCommand($"DELETE FROM Customer WHERE CustomerID = {id_selected_rows}", db.getConnection());
                MessageBox.Show(cmd.ExecuteNonQuery() > 0 ? "Данные удалены!" : "Данные не удалены!");
                db.closeConnection();
            }
            catch
            {
                MessageBox.Show("Данные не удалены!", "Строка не выбрана!", MessageBoxButtons.OKCancel, MessageBoxIcon.Error);
                db.closeConnection();
            }
        }
        private void ProjectOrderTableReset()
        {
            string commandStr = "SELECT ProjectOrderID AS 'Код заказа', projectName AS 'Название проекта', projectCategory AS 'Категория проекта' , projectPrice AS 'Цена в рублях',  ProjectID AS 'Код проекта', EmployeesID AS 'Код сотрудника', CustomerID AS 'Код клиента' FROM ProjectOrder"; // SQL запрос данных из БД
            MySqlCommand cmd = new MySqlCommand(commandStr, db.getConnection()); // осуществяется подключение к БД
            MySqlDataAdapter adapter = new MySqlDataAdapter(); // используется адаптер для получения таблицы 
            table = new DataTable(); // класс для таблиц
            adapter.SelectCommand = cmd; // адаптер берет соединение
            adapter.Fill(table); // адаптер передает значение для того чтобы показать таблицу
            bSource.DataSource = table;  // принимается таблица для последующего показа таблицы
            dataGridViewTransformData2.DataSource = bSource; // показывается таблица при выборе вкладки
            dataGridViewTransformData2.Columns[0].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill; // автосайз для столбца для гридера (растягивает столбец по ширине)
            dataGridViewTransformData2.Columns[1].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill; // автосайз для столбца для гридера (растягивает столбец по ширине)
            dataGridViewTransformData2.Columns[2].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill; // автосайз для столбца для гридера (растягивает столбец по ширине)
            dataGridViewTransformData2.Columns[3].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill; // автосайз для столбца для гридера (растягивает столбец по ширине)
            dataGridViewTransformData2.Columns[4].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill; // автосайз для столбца для гридера (растягивает столбец по ширине)
            dataGridViewTransformData2.Columns[5].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill; // автосайз для столбца для гридера (растягивает столбец по ширине)
            dataGridViewTransformData2.Columns[6].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill; // автосайз для столбца для гридера (растягивает столбец по ширине)

            textBox1.Visible = false; // сокрытие и показ всех необходимых элементов формы
            textBox2.Visible = true;
            textBox3.Visible = true;
            textBox4.Visible = true;
            textBox5.Visible = true;
            textBox6.Visible = true;
            textBox7.Visible = true;

            Column1Label.Visible = false;
            Column2Label.Visible = true;
            Column3Label.Visible = true;
            Column4Label.Visible = true;
            Column5Label.Visible = true;
            Column6Label.Visible = true;
            Column7Label.Visible = true;

            AddLineButton.Visible = false;
            AddLineButton2.Visible = false;
            AddLineButton3.Visible = true;
            AddLineButton4.Visible = false;
            AddLineButton5.Visible = false;
            AddLineButton6.Visible = false;

            ResetButton.Visible = false;
            ResetButton2.Visible = false;
            ResetButton3.Visible = true;
            ResetButton4.Visible = false;
            ResetButton5.Visible = false;
            ResetButton6.Visible = false;

            DeleteLineButton.Visible = false;
            DeleteLineButton2.Visible = false;
            DeleteLineButton3.Visible = true;
            DeleteLineButton4.Visible = false;
            DeleteLineButton5.Visible = false;
            DeleteLineButton6.Visible = false;
        }
        private void заказыToolStripMenuItem_Click(object sender, EventArgs e)
        {
            string commandStr = "SELECT ProjectOrderID AS 'Код заказа', projectName AS 'Название проекта', projectCategory AS 'Категория проекта' , projectPrice AS 'Цена в рублях',  ProjectID AS 'Код проекта', EmployeesID AS 'Код сотрудника', CustomerID AS 'Код клиента' FROM ProjectOrder"; // SQL запрос данных из БД
            MySqlCommand cmd = new MySqlCommand(commandStr, db.getConnection()); // осуществяется подключение к БД
            MySqlDataAdapter adapter = new MySqlDataAdapter(); // используется адаптер для получения таблицы 
            table = new DataTable(); // класс для таблиц
            adapter.SelectCommand = cmd; // адаптер берет соединение
            adapter.Fill(table); // адаптер передает значение для того чтобы показать таблицу
            bSource.DataSource = table;  // принимается таблица для последующего показа таблицы
            dataGridViewTransformData2.DataSource = bSource; // показывается таблица при выборе вкладки
            dataGridViewTransformData2.Columns[0].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill; // автосайз для столбца для гридера (растягивает столбец по ширине)
            dataGridViewTransformData2.Columns[1].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill; // автосайз для столбца для гридера (растягивает столбец по ширине)
            dataGridViewTransformData2.Columns[2].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill; // автосайз для столбца для гридера (растягивает столбец по ширине)
            dataGridViewTransformData2.Columns[3].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill; // автосайз для столбца для гридера (растягивает столбец по ширине)
            dataGridViewTransformData2.Columns[4].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill; // автосайз для столбца для гридера (растягивает столбец по ширине)
            dataGridViewTransformData2.Columns[5].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill; // автосайз для столбца для гридера (растягивает столбец по ширине)
            dataGridViewTransformData2.Columns[6].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill; // автосайз для столбца для гридера (растягивает столбец по ширине)

            textBox1.Visible = false; // сокрытие и показ всех необходимых элементов формы
            textBox2.Visible = true;
            textBox3.Visible = true;
            textBox4.Visible = true;
            textBox5.Visible = true;
            textBox6.Visible = true;
            textBox7.Visible = true;
                Column1Label.Visible = false;
                Column2Label.Visible = true;
                Column3Label.Visible = true;
                Column4Label.Visible = true;
                Column5Label.Visible = true;
                Column6Label.Visible = true;
                Column7Label.Visible = true;
                        AddLineButton.Visible = false;
                        AddLineButton2.Visible = false;
                        AddLineButton3.Visible = true;
                        AddLineButton4.Visible = false;
                        AddLineButton5.Visible = false;
                        AddLineButton6.Visible = false;
                                 ResetButton.Visible = false;
                                 ResetButton2.Visible = false;
                                 ResetButton3.Visible = true;
                                 ResetButton4.Visible = false;
                                 ResetButton5.Visible = false;
                                 ResetButton6.Visible = false;
            DeleteLineButton.Visible = false;
            DeleteLineButton2.Visible = false;
            DeleteLineButton3.Visible = true;
            DeleteLineButton4.Visible = false;
            DeleteLineButton5.Visible = false;
            DeleteLineButton6.Visible = false;
        }
        private void SupplemenEmloyee3()
        {
            try
            {
                db.openConnection();
                MySqlCommand cmd = new MySqlCommand($"INSERT INTO ProjectOrder(projectName, projectCategory, projectPrice, ProjectID, EmployeesID, CustomerID) VALUES('{textBox2.Text}','{textBox3.Text}',{textBox4.Text}, '{textBox5.Text}', '{textBox6.Text}','{textBox7.Text}')", db.getConnection());
                MessageBox.Show(cmd.ExecuteNonQuery() > 0 ? "Данные добавились!" : "Данные не добавились!");
                db.closeConnection();
            }
            catch
            {
                MessageBox.Show("Данные не добавились!", "Ошибка ввода!", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                db.closeConnection();
            }
        }
        private void DeleteTable3()
        {
            try
            {
                db.openConnection();
                MySqlCommand cmd = new MySqlCommand($"DELETE FROM ProjectOrder WHERE ProjectOrderID = {id_selected_rows}", db.getConnection());
                MessageBox.Show(cmd.ExecuteNonQuery() > 0 ? "Данные удалены!" : "Данные не удалены!");
                db.closeConnection();
            }
            catch
            {
                MessageBox.Show("Данные не удалены!", "Строка не выбрана!", MessageBoxButtons.OKCancel, MessageBoxIcon.Error);
                db.closeConnection();
            }
        }
        private void ProjectIDTableReset()
        {
            string commandStr = "SELECT ProjectID AS 'Код проекта', SaleID AS 'Код продажи', datePurchase AS 'Дата покупки' FROM ProjectSales"; // SQL запрос данных из БД
            MySqlCommand cmd = new MySqlCommand(commandStr, db.getConnection()); // осуществяется подключение к БД
            MySqlDataAdapter adapter = new MySqlDataAdapter(); // используется адаптер для получения таблицы 
            table = new DataTable(); // класс для таблиц
            adapter.SelectCommand = cmd; // адаптер берет соединение
            adapter.Fill(table); // адаптер передает значение для того чтобы показать таблицу
            bSource.DataSource = table;  // принимается таблица для последующего показа таблицы
            dataGridViewTransformData2.DataSource = bSource; // показывается таблица при выборе вкладки
            dataGridViewTransformData2.Columns[0].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill; // автосайз для столбца для гридера (растягивает столбец по ширине)
            dataGridViewTransformData2.Columns[1].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill; // автосайз для столбца для гридера (растягивает столбец по ширине)
            dataGridViewTransformData2.Columns[2].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill; // автосайз для столбца для гридера (растягивает столбец по ширине)

            textBox1.Visible = false; // сокрытие и показ всех необходимых элементов формы
            textBox2.Visible = true;
            textBox3.Visible = true;
            textBox4.Visible = false;
            textBox5.Visible = false;
            textBox6.Visible = false;
            textBox7.Visible = false;

            Column1Label.Visible = false;
            Column2Label.Visible = true;
            Column3Label.Visible = true;
            Column4Label.Visible = false;
            Column5Label.Visible = false;
            Column6Label.Visible = false;
            Column7Label.Visible = false;

            AddLineButton.Visible = false;
            AddLineButton2.Visible = false;
            AddLineButton3.Visible = false;
            AddLineButton4.Visible = true;
            AddLineButton5.Visible = false;
            AddLineButton6.Visible = false;

            ResetButton.Visible = false;
            ResetButton2.Visible = false;
            ResetButton3.Visible = false;
            ResetButton4.Visible = true;
            ResetButton5.Visible = false;
            ResetButton6.Visible = false;

            DeleteLineButton.Visible = false;
            DeleteLineButton2.Visible = false;
            DeleteLineButton3.Visible = false;
            DeleteLineButton4.Visible = true;
            DeleteLineButton5.Visible = false;
            DeleteLineButton6.Visible = false;
        }
        private void продажиToolStripMenuItem_Click(object sender, EventArgs e)
        {
            string commandStr = "SELECT ProjectID AS 'Код проекта', SaleID AS 'Код продажи', datePurchase AS 'Дата покупки' FROM ProjectSales"; // SQL запрос данных из БД
            MySqlCommand cmd = new MySqlCommand(commandStr, db.getConnection()); // осуществяется подключение к БД
            MySqlDataAdapter adapter = new MySqlDataAdapter(); // используется адаптер для получения таблицы 
            table = new DataTable(); // класс для таблиц
            adapter.SelectCommand = cmd; // адаптер берет соединение
            adapter.Fill(table); // адаптер передает значение для того чтобы показать таблицу
            bSource.DataSource = table;  // принимается таблица для последующего показа таблицы
            dataGridViewTransformData2.DataSource = bSource; // показывается таблица при выборе вкладки
            dataGridViewTransformData2.Columns[0].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill; // автосайз для столбца для гридера (растягивает столбец по ширине)
            dataGridViewTransformData2.Columns[1].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill; // автосайз для столбца для гридера (растягивает столбец по ширине)
            dataGridViewTransformData2.Columns[2].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill; // автосайз для столбца для гридера (растягивает столбец по ширине)

            textBox1.Visible = false; // сокрытие и показ всех необходимых элементов формы
            textBox2.Visible = true;
            textBox3.Visible = true;
            textBox4.Visible = false;
            textBox5.Visible = false;
            textBox6.Visible = false;
            textBox7.Visible = false;
                Column1Label.Visible = false;
                Column2Label.Visible = true;
                Column3Label.Visible = true;
                Column4Label.Visible = false;
                Column5Label.Visible = false;
                Column6Label.Visible = false;
                Column7Label.Visible = false;
                        AddLineButton.Visible = false;
                        AddLineButton2.Visible = false;
                        AddLineButton3.Visible = false;
                        AddLineButton4.Visible = true;
                        AddLineButton5.Visible = false;
                        AddLineButton6.Visible = false;
                                 ResetButton.Visible = false;
                                 ResetButton2.Visible = false;
                                 ResetButton3.Visible = false;
                                 ResetButton4.Visible = true;
                                 ResetButton5.Visible = false;
                                 ResetButton6.Visible = false;
            DeleteLineButton.Visible = false;
            DeleteLineButton2.Visible = false;
            DeleteLineButton3.Visible = false;
            DeleteLineButton4.Visible = true;
            DeleteLineButton5.Visible = false;
            DeleteLineButton6.Visible = false;
        }
        private void SupplemenEmloyee4()
        {
            try
            {
                db.openConnection();
                MySqlCommand cmd = new MySqlCommand($"INSERT INTO ProjectSales(SaleID, datePurchase) VALUES('{textBox2.Text}', \"{textBox3.Text}\")", db.getConnection());
                MessageBox.Show(cmd.ExecuteNonQuery() > 0 ? "Данные добавились!" : "Данные не добавились!");
                db.closeConnection();
            }
            catch
            {
                MessageBox.Show("Данные не добавились!", "Ошибка ввода!", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                db.closeConnection();
            }
        }
        private void DeleteTable4()
        {
            try
            {
                db.openConnection();
                MySqlCommand cmd = new MySqlCommand($"DELETE FROM ProjectSales WHERE ProjectID = {id_selected_rows}", db.getConnection());
                MessageBox.Show(cmd.ExecuteNonQuery() > 0 ? "Данные удалены!" : "Данные не удалены!");
                db.closeConnection();
            }
            catch
            {
                MessageBox.Show("Данные не удалены!", "Строка не выбрана!", MessageBoxButtons.OKCancel, MessageBoxIcon.Error);
                db.closeConnection();
            }
        }
        private void SaleIDTableReset()
        {
            string commandStr = "SELECT SaleID AS 'Код продажи', saleDate AS 'Дата продажи', saleNotes AS 'Кол-во страниц', saleCost AS 'Цена в рублях' FROM Sales"; // SQL запрос данных из БД
            MySqlCommand cmd = new MySqlCommand(commandStr, db.getConnection()); // осуществяется подключение к БД
            MySqlDataAdapter adapter = new MySqlDataAdapter(); // используется адаптер для получения таблицы 
            table = new DataTable(); // класс для таблиц
            adapter.SelectCommand = cmd; // адаптер берет соединение
            adapter.Fill(table); // адаптер передает значение для того чтобы показать таблицу
            bSource.DataSource = table;  // принимается таблица для последующего показа таблицы
            dataGridViewTransformData2.DataSource = bSource; // показывается таблица при выборе вкладки
            dataGridViewTransformData2.Columns[0].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill; // автосайз для столбца для гридера (растягивает столбец по ширине)
            dataGridViewTransformData2.Columns[1].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill; // автосайз для столбца для гридера (растягивает столбец по ширине)
            dataGridViewTransformData2.Columns[2].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill; // автосайз для столбца для гридера (растягивает столбец по ширине)
            dataGridViewTransformData2.Columns[3].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill; // автосайз для столбца для гридера (растягивает столбец по ширине)

            textBox1.Visible = false; // сокрытие и показ всех необходимых элементов формы
            textBox2.Visible = true;
            textBox3.Visible = true;
            textBox4.Visible = true;
            textBox5.Visible = false;
            textBox6.Visible = false;
            textBox7.Visible = false;

            Column1Label.Visible = false;
            Column2Label.Visible = true;
            Column3Label.Visible = true;
            Column4Label.Visible = true;
            Column5Label.Visible = false;
            Column6Label.Visible = false;
            Column7Label.Visible = false;

            AddLineButton.Visible = false;
            AddLineButton2.Visible = false;
            AddLineButton3.Visible = false;
            AddLineButton4.Visible = false;
            AddLineButton5.Visible = true;
            AddLineButton6.Visible = false;

            ResetButton.Visible = false;
            ResetButton2.Visible = false;
            ResetButton3.Visible = false;
            ResetButton4.Visible = false;
            ResetButton5.Visible = true;
            ResetButton6.Visible = false;

            DeleteLineButton.Visible = false;
            DeleteLineButton2.Visible = false;
            DeleteLineButton3.Visible = false;
            DeleteLineButton4.Visible = false;
            DeleteLineButton5.Visible = true;
            DeleteLineButton6.Visible = false;
        }
        private void ценаToolStripMenuItem_Click(object sender, EventArgs e)
        {
            string commandStr = "SELECT SaleID AS 'Код продажи', saleDate AS 'Дата продажи', saleNotes AS 'Кол-во страниц', saleCost AS 'Цена в рублях' FROM Sales"; // SQL запрос данных из БД
            MySqlCommand cmd = new MySqlCommand(commandStr, db.getConnection()); // осуществяется подключение к БД
            MySqlDataAdapter adapter = new MySqlDataAdapter(); // используется адаптер для получения таблицы 
            table = new DataTable(); // класс для таблиц
            adapter.SelectCommand = cmd; // адаптер берет соединение
            adapter.Fill(table); // адаптер передает значение для того чтобы показать таблицу
            bSource.DataSource = table;  // принимается таблица для последующего показа таблицы
            dataGridViewTransformData2.DataSource = bSource; // показывается таблица при выборе вкладки
            dataGridViewTransformData2.Columns[0].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill; // автосайз для столбца для гридера (растягивает столбец по ширине)
            dataGridViewTransformData2.Columns[1].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill; // автосайз для столбца для гридера (растягивает столбец по ширине)
            dataGridViewTransformData2.Columns[2].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill; // автосайз для столбца для гридера (растягивает столбец по ширине)
            dataGridViewTransformData2.Columns[3].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill; // автосайз для столбца для гридера (растягивает столбец по ширине)

            textBox1.Visible = false; // сокрытие и показ всех необходимых элементов формы
            textBox2.Visible = true;
            textBox3.Visible = true;
            textBox4.Visible = true;
            textBox5.Visible = false;
            textBox6.Visible = false;
            textBox7.Visible = false;
                Column1Label.Visible = false;
                Column2Label.Visible = true;
                Column3Label.Visible = true;
                Column4Label.Visible = true;
                Column5Label.Visible = false;
                Column6Label.Visible = false;
                Column7Label.Visible = false;
                        AddLineButton.Visible = false;
                        AddLineButton2.Visible = false;
                        AddLineButton3.Visible = false;
                        AddLineButton4.Visible = false;
                        AddLineButton5.Visible = true;
                        AddLineButton6.Visible = false;
                                 ResetButton.Visible = false;
                                 ResetButton2.Visible = false;
                                 ResetButton3.Visible = false;
                                 ResetButton4.Visible = false;
                                 ResetButton5.Visible = true;
                                 ResetButton6.Visible = false;
            DeleteLineButton.Visible = false;
            DeleteLineButton2.Visible = false;
            DeleteLineButton3.Visible = false;
            DeleteLineButton4.Visible = false;
            DeleteLineButton5.Visible = true;
            DeleteLineButton6.Visible = false;
        }
        private void SupplemenEmloyee5()
        {
            try
            {
                db.openConnection();
                MySqlCommand cmd = new MySqlCommand($"INSERT INTO Sales(saleDate, saleNotes) VALUES( \"{textBox2.Text}\", {textBox3.Text}, {textBox4.Text})", db.getConnection());
                MessageBox.Show(cmd.ExecuteNonQuery() > 0 ? "Данные добавились!" : "Данные не добавились!");
                db.closeConnection();
            }
            catch
            {
                MessageBox.Show("Данные не добавились!", "Ошибка ввода!", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                db.closeConnection();
            }
        }
        private void DeleteTable5()
        {
            try
            {
                db.openConnection();
                MySqlCommand cmd = new MySqlCommand($"DELETE FROM Sales WHERE SaleID = {id_selected_rows}", db.getConnection());
                MessageBox.Show(cmd.ExecuteNonQuery() > 0 ? "Данные удалены!" : "Данные не удалены!");
                db.closeConnection();
            }
            catch
            {
                MessageBox.Show("Данные не удалены!", "Строка не выбрана!", MessageBoxButtons.OKCancel, MessageBoxIcon.Error);
                db.closeConnection();
            }
        }
        private void AutorizationIDTableReset()
        {
            string commandStr = "SELECT AuthorizationID AS 'Код авторизации', EmployeesID AS 'Код сотрудника', employeesJobTitle AS 'Профессия', login AS 'Логин', password AS 'Пароль', roleTitle AS 'Название роли', levelRole AS 'Уровень роли' FROM authorization"; // SQL запрос данных из БД
            MySqlCommand cmd = new MySqlCommand(commandStr, db.getConnection()); // осуществяется подключение к БД
            MySqlDataAdapter adapter = new MySqlDataAdapter(); // используется адаптер для получения таблицы 
            table = new DataTable(); // класс для таблиц
            adapter.SelectCommand = cmd; // адаптер берет соединение
            adapter.Fill(table); // адаптер передает значение для того чтобы показать таблицу
            bSource.DataSource = table;  // принимается таблица для последующего показа таблицы
            dataGridViewTransformData2.DataSource = bSource; // показывается таблица при выборе вкладки
            dataGridViewTransformData2.Columns[0].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill; // автосайз для столбца для гридера (растягивает столбец по ширине)
            dataGridViewTransformData2.Columns[1].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill; // автосайз для столбца для гридера (растягивает столбец по ширине)
            dataGridViewTransformData2.Columns[2].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill; // автосайз для столбца для гридера (растягивает столбец по ширине)
            dataGridViewTransformData2.Columns[3].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill; // автосайз для столбца для гридера (растягивает столбец по ширине)
            dataGridViewTransformData2.Columns[4].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill; // автосайз для столбца для гридера (растягивает столбец по ширине)
            dataGridViewTransformData2.Columns[5].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill; // автосайз для столбца для гридера (растягивает столбец по ширине)
            dataGridViewTransformData2.Columns[6].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill; // автосайз для столбца для гридера (растягивает столбец по ширине)

            textBox1.Visible = false; // сокрытие и показ всех необходимых элементов формы
            textBox2.Visible = true;
            textBox3.Visible = true;
            textBox4.Visible = true;
            textBox5.Visible = true;
            textBox6.Visible = true;
            textBox7.Visible = true;

            Column1Label.Visible = false;
            Column2Label.Visible = true;
            Column3Label.Visible = true;
            Column4Label.Visible = true;
            Column5Label.Visible = true;
            Column6Label.Visible = true;
            Column7Label.Visible = true;

            AddLineButton.Visible = false;
            AddLineButton2.Visible = false;
            AddLineButton3.Visible = false;
            AddLineButton4.Visible = false;
            AddLineButton5.Visible = false;
            AddLineButton6.Visible = true;

            ResetButton.Visible = false;
            ResetButton2.Visible = false;
            ResetButton3.Visible = false;
            ResetButton4.Visible = false;
            ResetButton5.Visible = false;
            ResetButton6.Visible = true;

            DeleteLineButton.Visible = false;
            DeleteLineButton2.Visible = false;
            DeleteLineButton3.Visible = false;
            DeleteLineButton4.Visible = false;
            DeleteLineButton5.Visible = false;
            DeleteLineButton6.Visible = true;
        }
        private void вТаблицеАвторизацииToolStripMenuItem_Click(object sender, EventArgs e)
        {
            string commandStr = "SELECT AuthorizationID AS 'Код авторизации', EmployeesID AS 'Код сотрудника', employeesJobTitle AS 'Профессия', login AS 'Логин', password AS 'Пароль', roleTitle AS 'Название роли', levelRole AS 'Уровень роли' FROM authorization"; // SQL запрос данных из БД
            MySqlCommand cmd = new MySqlCommand(commandStr, db.getConnection()); // осуществяется подключение к БД
            MySqlDataAdapter adapter = new MySqlDataAdapter(); // используется адаптер для получения таблицы 
            table = new DataTable(); // класс для таблиц
            adapter.SelectCommand = cmd; // адаптер берет соединение
            adapter.Fill(table); // адаптер передает значение для того чтобы показать таблицу
            bSource.DataSource = table;  // принимается таблица для последующего показа таблицы
            dataGridViewTransformData2.DataSource = bSource; // показывается таблица при выборе вкладки
            dataGridViewTransformData2.Columns[0].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill; // автосайз для столбца для гридера (растягивает столбец по ширине)
            dataGridViewTransformData2.Columns[1].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill; // автосайз для столбца для гридера (растягивает столбец по ширине)
            dataGridViewTransformData2.Columns[2].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill; // автосайз для столбца для гридера (растягивает столбец по ширине)
            dataGridViewTransformData2.Columns[3].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill; // автосайз для столбца для гридера (растягивает столбец по ширине)
            dataGridViewTransformData2.Columns[4].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill; // автосайз для столбца для гридера (растягивает столбец по ширине)
            dataGridViewTransformData2.Columns[5].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill; // автосайз для столбца для гридера (растягивает столбец по ширине)
            dataGridViewTransformData2.Columns[6].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill; // автосайз для столбца для гридера (растягивает столбец по ширине)

            textBox1.Visible = false; // сокрытие и показ всех необходимых элементов формы
            textBox2.Visible = true;
            textBox3.Visible = true;
            textBox4.Visible = true;
            textBox5.Visible = true;
            textBox6.Visible = true;
            textBox7.Visible = true;
                Column1Label.Visible = false;
                Column2Label.Visible = true;
                Column3Label.Visible = true;
                Column4Label.Visible = true;
                Column5Label.Visible = true;
                Column6Label.Visible = true;
                Column7Label.Visible = true;
                        AddLineButton.Visible = false;
                        AddLineButton2.Visible = false;
                        AddLineButton3.Visible = false;
                        AddLineButton4.Visible = false;
                        AddLineButton5.Visible = false;
                        AddLineButton6.Visible = true;
                                 ResetButton.Visible = false;
                                 ResetButton2.Visible = false;
                                 ResetButton3.Visible = false;
                                 ResetButton4.Visible = false;
                                 ResetButton5.Visible = false;
                                 ResetButton6.Visible = true;
            DeleteLineButton.Visible = false;
            DeleteLineButton2.Visible = false;
            DeleteLineButton3.Visible = false;
            DeleteLineButton4.Visible = false;
            DeleteLineButton5.Visible = false;
            DeleteLineButton6.Visible = true;
        }
        private void SupplemenEmloyee6()
        {
            try
            {
                db.openConnection();
                MySqlCommand cmd = new MySqlCommand($"INSERT INTO authorization(EmployeesID, employeesJobTitle, login, password, roleTitle, levelRole ) VALUES( '{textBox2.Text}', '{textBox3.Text}','{textBox4.Text}','{textBox5.Text}','{textBox6.Text}',{textBox7.Text})", db.getConnection());
                MessageBox.Show(cmd.ExecuteNonQuery() > 0 ? "Данные добавились!" : "Данные не добавились!");
                db.closeConnection();
            }
            catch
            {
                MessageBox.Show("Данные не добавились!", "Ошибка ввода!", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                db.closeConnection();
            }
        }
        private void DeleteTable6()
        {
            try
            {
                db.openConnection();
                MySqlCommand cmd = new MySqlCommand($"DELETE FROM authorization WHERE AuthorizationID = {id_selected_rows}", db.getConnection());
                MessageBox.Show(cmd.ExecuteNonQuery() > 0 ? "Данные удалены!" : "Данные не удалены!");
                db.closeConnection();
            }
            catch
            {
                MessageBox.Show("Данные не удалены!", "Строка не выбрана!", MessageBoxButtons.OKCancel, MessageBoxIcon.Error);
                db.closeConnection();
            }
        }
        private void AddLineButton_Click(object sender, EventArgs e)
        {
            SupplemenEmloyee();
        }
        private void AddLineButton2_Click(object sender, EventArgs e)
        {
            SupplemenEmloyee2();
        }
        private void AddLineButton3_Click(object sender, EventArgs e)
        {
            SupplemenEmloyee3();
        }
        private void AddLineButton4_Click(object sender, EventArgs e)
        {
            SupplemenEmloyee4();
        }
        private void AddLineButton5_Click(object sender, EventArgs e)
        {
            SupplemenEmloyee5();
        }
        private void AddLineButton6_Click(object sender, EventArgs e)
        {
            SupplemenEmloyee6();
        }
        private void ResetButton_Click(object sender, EventArgs e)
        {
            EmployeesTableReset();
        }
        private void ResetButton2_Click(object sender, EventArgs e)
        {
            CustomerTableReset();
        }
        private void ResetButton3_Click(object sender, EventArgs e)
        {
            ProjectOrderTableReset();
        }
        private void ResetButton4_Click(object sender, EventArgs e)
        {
            ProjectIDTableReset();
        }
        private void ResetButton5_Click(object sender, EventArgs e)
        {
            SaleIDTableReset();
        }
        private void ResetButton6_Click(object sender, EventArgs e)
        {
            AutorizationIDTableReset();
        }
        private void DeleteLineButton_Click(object sender, EventArgs e)
        {
            DeleteTable();
        }
        private void DeleteLineButton2_Click(object sender, EventArgs e)
        {
            DeleteTable2();
        }
        private void DeleteLineButton3_Click(object sender, EventArgs e)
        {
            DeleteTable3();
        }
        private void DeleteLineButton4_Click(object sender, EventArgs e)
        {
            DeleteTable4();
        }
        private void DeleteLineButton5_Click(object sender, EventArgs e)
        {
            DeleteTable5();
        }
        private void DeleteLineButton6_Click(object sender, EventArgs e)
        {
            DeleteTable6();
        }

        private void dataGridViewTransformData2_CellMouseDown(object sender, DataGridViewCellMouseEventArgs e)
        {
            if (!e.RowIndex.Equals(-1) && !e.ColumnIndex.Equals(-1) && e.Button.Equals(MouseButtons.Right))
            {
                dataGridViewTransformData2.CurrentCell = dataGridViewTransformData2[e.ColumnIndex, e.RowIndex];
                //dataGridView1.CurrentRow.Selected = true;
                dataGridViewTransformData2.CurrentCell.Selected = true;
                //Метод получения ID выделенной строки в глобальную переменную
                GetSelectedIDString();
            }
        }
        private void dataGridViewTransformData2_CellMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            dataGridViewTransformData2.CurrentCell = dataGridViewTransformData2[e.ColumnIndex, e.RowIndex];
            dataGridViewTransformData2.CurrentRow.Selected = true;
            //Метод получения ID выделенной строки в глобальную переменную
            GetSelectedIDString();
        }
        public void GetSelectedIDString()
        {
            //Переменная для индекс выбранной строки в гриде
            string index_selected_rows;
            //Индекс выбранной строки
            index_selected_rows = dataGridViewTransformData2.SelectedCells[0].RowIndex.ToString();
            //ID конкретной записи в Базе данных, на основании индекса строки
            id_selected_rows = dataGridViewTransformData2.Rows[Convert.ToInt32(index_selected_rows)].Cells[0].Value.ToString();
            //Указываем ID выделенной строки в метке
        }
    }
}
