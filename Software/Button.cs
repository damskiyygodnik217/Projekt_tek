
using System;
using System.Windows.Forms;

namespace MyDesktopApp
    {
        public partial class MainForm : Form
        {
            public MainForm()
            {
                InitializeComponent();
            }

            // Обработчик события загрузки формы
            private void MainForm_Load(object sender, EventArgs e)
            {
                // Действия при загрузке формы
            }

            // Обработчик события нажатия на кнопку
            private void button_Click(object sender, EventArgs e)
            {
                // Действия при нажатии на кнопку
            }
        }

        static class Program
        {
            [STAThread]
            static void Main()
            {
                Application.EnableVisualStyles();
                Application.SetCompatibleTextRenderingDefault(false);
                Application.Run(new MainForm());
            }
        }
    }


