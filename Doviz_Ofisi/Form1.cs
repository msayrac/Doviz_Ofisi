using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml;


namespace Doviz_Ofisi
{
	public partial class Form1 : Form
	{
		public Form1()
		{
			InitializeComponent();
		}

		private void Form1_Load(object sender, EventArgs e)
		{
			string today = "https://www.tcmb.gov.tr/kurlar/today.xml";

			var xmlDosya = new XmlDocument();

			xmlDosya.Load(today);

			string dolaralis = xmlDosya.SelectSingleNode("Tarih_Date/Currency[@Kod='USD']/BanknoteBuying").InnerXml;
			LblDolarAlis.Text = dolaralis;

			string dolarsatis = xmlDosya.SelectSingleNode("Tarih_Date/Currency[@Kod='USD']/BanknoteSelling").InnerXml;
			LblDolarSatis.Text = dolarsatis;

			string euroAlis = xmlDosya.SelectSingleNode("Tarih_Date/Currency[@Kod='EUR']/BanknoteBuying").InnerXml;
			LblEuroAlis.Text = euroAlis;

			string eurosatis = xmlDosya.SelectSingleNode("Tarih_Date/Currency[@Kod='EUR']/BanknoteSelling").InnerXml;
			LblEuroSatis.Text = eurosatis;
		}

		private void BtnDolarAl_Click(object sender, EventArgs e)
		{
			txtkur.Text = LblDolarAlis.Text;
		}

		private void BtnDolarSat_Click(object sender, EventArgs e)
		{
			txtkur.Text = LblDolarSatis.Text;
		}

		private void BtnEuroAl_Click(object sender, EventArgs e)
		{
			txtkur.Text = LblEuroAlis.Text;
		}

		private void BtnEuroSat_Click(object sender, EventArgs e)
		{
			txtkur.Text = LblEuroSatis.Text; 
		}
		private void BtnSatisYap_Click(object sender, EventArgs e)
		{
			double kur, miktar, tutar;

			kur= Convert.ToDouble(txtkur.Text);
			miktar= Convert.ToDouble(txtmiktar.Text);
			tutar = kur * miktar;

			//tutar = double.Parse(txtkur.Text)*double.Parse(txtmiktar.Text);
			txttutar.Text =tutar.ToString();
		}

		private void btnsatisyap2_Click(object sender, EventArgs e)
		{
			double kur = Convert.ToDouble(txtkur.Text);
			double tutar =Convert.ToDouble(txttutar.Text);

			int miktar = Convert.ToInt32(Math.Floor(tutar/kur));

			txtmiktar.Text =miktar.ToString();


			double kalan = tutar % kur;
			txtkalan.Text = kalan.ToString();

		}
	}
}
