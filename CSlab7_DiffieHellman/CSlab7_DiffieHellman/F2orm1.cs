using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using CryptoBase;

namespace CSlab7_DiffieHellman
{
    public partial class F2orm1 : Form
    {
        public F2orm1()
        {
            InitializeComponent();

            DiffieHellmanProtocol d = new DiffieHellmanProtocol();

            var enc = d.Encrypt("Валера world!");

            var text = d.Decrypt(enc);
        }


    }
}
