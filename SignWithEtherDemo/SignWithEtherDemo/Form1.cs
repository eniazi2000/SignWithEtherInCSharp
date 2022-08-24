using Nethereum.Signer;
using Nethereum.Web3;
using Nethereum.Web3.Accounts;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SignWithEtherDemo
{
    public partial class Form1 : Form
    {
        public Account account;
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            EthECKey key = EthECKey.GenerateKey();
            byte[] privateKey = key.GetPrivateKeyAsBytes();
            account = new Account(privateKey);
            PrivateKeyTxt.Text = account.PrivateKey;
            PublickKeyTxt.Text = account.Address;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            var signer = new EthereumMessageSigner();
            //var signature = signer.EncodeUTF8AndSign(MessageTxt.Text, new EthECKey(account.PrivateKey));
            var signature = signer.HashAndSign(MessageTxt.Text, account.PrivateKey);
            SignatureTxt.Text = signature;
        }

        private void button3_Click(object sender, EventArgs e)
        {
            var signer = new EthereumMessageSigner();
            //var res = signer.EncodeUTF8AndEcRecover(MessageTxt.Text, SignatureTxt.Text);
            var res = signer.HashAndEcRecover(MessageTxt.Text, SignatureTxt.Text);
            MessageBox.Show(res);
        }
    }
}
