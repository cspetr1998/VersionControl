using _8gyakorlat.Abstractions;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace _8gyakorlat.Entities
{
    public partial class BallFactory : IToyFactory

    {
        public Toy CreateNew()
        {
            return new Ball();
        }
    }
}
