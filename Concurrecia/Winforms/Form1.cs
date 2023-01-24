using Shared;

namespace Winforms;

public partial class Form1 : Form
{
    public Form1()
    {
        InitializeComponent();
        listBox1.Dock = DockStyle.Fill;
        imgBox.Dock = DockStyle.Fill;
        listBox1.Hide();
    }

    private void button1_Click(object sender, EventArgs e)
    { 
        listBox1.Hide();
        Thread.Sleep(GetWaitTime());
        listBox1.Show(); 
        AddItemsInListBox();
    }
    
    private async void button2_Click(object sender, EventArgs e)
    {
        button1.Enabled = false;
        listBox1.Hide();
        imgBox.Show();
        await Task.Delay(GetWaitTime());
        imgBox.Hide();
        listBox1.Show();
        AddItemsInListBox();
        button1.Enabled = true;
    }

    private TimeSpan GetWaitTime()
    {
        return TimeSpan.FromSeconds(Convert.ToInt32(numericUpDown1.Value));
    }

    private void AddItemsInListBox()
    {
        var products = ProductsRepository.GetProducts(50);
        products.ForEach(_ => listBox1.Items.Add(_.Name));
    }

    private void opcion1ToolStripMenuItem_Click(object sender, EventArgs e)
    {
        MessageBox.Show("Opcion 1");
    }

    private void opcion2ToolStripMenuItem_Click(object sender, EventArgs e)
    {
        MessageBox.Show("Opcion 2");
    }
}
