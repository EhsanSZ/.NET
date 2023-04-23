using Grpc.Net.Client;
using grpcServer.Protos;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WinFormsClient
{
    public partial class Form1 : Form
    {
        GrpcChannel channel;
        ProductService.ProductServiceClient client;

        public Form1()
        {
            InitializeComponent();

            channel = GrpcChannel.ForAddress("https://localhost:5001/");
            client = new ProductService.ProductServiceClient(channel);
        }

        private void button2_Click(object sender, EventArgs e)
        {
            var response = client.GetAllProduct(new RequestAllProduct
            {
                Page = 1,
                PageSize = 20
            });
            dataGridView1.DataSource = response.Items;
        }

        private void btnAddKala_Click(object sender, EventArgs e)
        {
           var response=  client.AddNewProduct(new RequestAddProductDTO
            {
                Brand = txtBrand.Text,
                Name = txtName.Text,
                Price = int.Parse(txtPrice.Text),
            });
            if (response.IsSuccess)
            {
                MessageBox.Show("محصول جدید با موفقیت به سرور اضافه شد");
            }
        }
    }
}
