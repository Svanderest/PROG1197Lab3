using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Lab3
{
    public partial class FrmToDo : Form
    {
        Queue Q;

        public FrmToDo()
        {
            InitializeComponent();
            Q = new Queue();
            cmbPrioriy.Items.AddRange(Priorities.PriorityLevels.ToArray());
            UpdateUI();
        }

        private void UpdateUI()
        {
            lblCount.Text = $"Number of things to do: {Q.Count.ToString()}";
            StringBuilder sb = new StringBuilder();
            foreach (string str in Priorities.PriorityLevels)
            {
                sb.Append($"{str} items: {Q.PriorityCount(str)}\n");
            }
            lblPriorities.Text = sb.ToString();
            lblPriority1.Text = $"Prioirity: {Q.First?.PriorityLevel ?? "None"}";
            lblDescription1.Text = $"Description: {Q.First?.Description ?? "None"}";
        }

        private void BtnComplete_Click(object sender, EventArgs e)
        {
            if (Q.Count > 0)
            {
                Q.Dequeue();
                UpdateUI();
            }
            else
                MessageBox.Show("Nothing to do");
        }

        private void BtnAdd_Click(object sender, EventArgs e)
        {
            if (txtDescription.Text.Length > 0 && cmbPrioriy.SelectedIndex != -1)
            {
                ToDo t = new ToDo(txtDescription.Text, cmbPrioriy.Text);
                Q.Enqueue(t);
                txtDescription.Clear();
                cmbPrioriy.SelectedIndex = -1;
                UpdateUI();
            }
            else
                MessageBox.Show("Please enter the description and priority");
        }

        private void BtnClear_Click(object sender, EventArgs e)
        {
            Q.Clear();
            UpdateUI();
        }

        private void BtnAll_Click(object sender, EventArgs e)
        {
            StringBuilder sb = new StringBuilder();
            foreach (ToDo t in Q)
                sb.Append($"{t.Description} {t.PriorityLevel}\n");
            MessageBox.Show(sb.Length > 0 ? sb.ToString() : "Nothing to do");
        }
    }
}
