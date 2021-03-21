using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Zamki
{
    public partial class winGame : Form
    {
        private bool isOk;
        private GameElements.Stuff.GameProgress GP;
        public winGame(bool isOk, GameElements.Stuff.GameProgress GP)
        {
            InitializeComponent();
        }

        private void btnEvil_Click(object sender, EventArgs e)
        {
            isOk = true;
            DialogResult Del = MessageBox.Show("Предпочитаешь играть по-плохому?\nТЕПЕРЬ ТЫ КОЩЕЙ!", "Финал", MessageBoxButtons.OK);
            if (Del == DialogResult.OK)
            {
                GP.result = "Стал Кощеем";
            }
            this.Close();
        }

        private void btnLaw_Click(object sender, EventArgs e)
        {
            isOk = true;
            DialogResult Del = MessageBox.Show("Благодаря твоей смекалке удалось вернуть украденное золото!", "Финал", MessageBoxButtons.OK);
            if (Del == DialogResult.OK)
            {
                GP.result = "Вернул золото";
            }
            this.Close();
        }
        protected override void WndProc(ref Message m) // Перемещать по экрану окно без Border
        {
            switch (m.Msg)
            {
                case 0x84:
                    base.WndProc(ref m);
                    if ((int)m.Result == 0x1)
                        m.Result = (IntPtr)0x2;
                    return;
            }

            base.WndProc(ref m);
        }
    }
}
