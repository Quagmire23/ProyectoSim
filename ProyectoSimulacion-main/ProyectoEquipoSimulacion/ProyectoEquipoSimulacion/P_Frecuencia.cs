using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ProyectoEquipoSimulacion
{
    public partial class P_Distancia : Form
    {
        //declaración de variables
        int NcPS = 0, CaG = 3, GL = 1;
        int contR = 0;
        bool contA = false;
        double[] nps;

        double FE = 0, FE2 = 0, FE3 = 0, FOc1 = 0, FOc2 = 0, FOc3 = 0, pro1 = 0, pro2 = 0, pro3 = 0, teta = 0, totalFO = 0, area2;
        double columnatabla, filatabla, vtablas;

        double cct, rrt, cct2;
        int indexC = 0, indexR = 0;
        bool vtpasar = false;
        double ValorCA = 0, valorT = 0, VaSig = 0, intinf = 0, intsup = 0, alpf2 = 0;
        string txt;

        public static double a;
        public static double c;
        public static double Xo;
        public static double M;
        double n, modulo, m = 0/*, acumulador = 0, promedio, Zo*/;

        double[] random = new double[100000];

        public P_Distancia()
        {
            InitializeComponent();
            
            //dataGridView1.Rows[0].Cells[0].Value = /*0*/33;
            //dataGridView1.Rows[0].Cells[1].Value = /*FOc1*/33;
            //dataGridView1.Rows[0].Cells[2].Value =/* pro1*/33;
            //dataGridView1.Rows[0].Cells[3].Value = /*FE*/33;

            ////dataGridView1.Rows[1].Cells[0].Value = 1;
            ////dataGridView1.Rows[1].Cells[1].Value = FOc2;
            ////dataGridView1.Rows[1].Cells[2].Value = pro2;
            ////dataGridView1.Rows[1].Cells[3].Value = FE2;

            ////dataGridView1.Rows[2].Cells[0].Value = "2 a +";
            ////dataGridView1.Rows[2].Cells[1].Value = FOc3;
            ////dataGridView1.Rows[2].Cells[2].Value = pro3;
            ////dataGridView1.Rows[2].Cells[3].Value = FE3;
        }
        

        

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void volver_Click(object sender, EventArgs e)
        {
            this.Hide();
            Form1 p2 = new Form1();
            p2.Show();
        }

        
        int ad;

        //Form1 p1 = new Form1();
        private void StartPF_Click(object sender, EventArgs e)
        {
            //obtención de los números pseudoaleatorios
            {
                //optención de valores para las variables
                double.TryParse(tbA2.Text, out a);
                double.TryParse(tbC2.Text, out c);
                double.TryParse(tbXo2.Text, out Xo);
                double.TryParse(tbM2.Text, out M);
                double.TryParse(tbn2.Text, out n);
                
                

                //int.TryParse(tbn2.Text, out NcPS);
                NcPS = Convert.ToInt32(n) ;
                //n = nn.Text();
                nps = new double[NcPS];
                //int.TryParse(CanGr.Text, out CaG);
                double.TryParse(Nsig.Text, out VaSig);
                //generar numeros 
                for (int i = 0; i < n; i++)
                {
                    modulo = (a * Xo + c) % M;
                    random[i] = modulo / M;
                    double redoneado = (Math.Round(random[i], 5));
                    ad = dataGridView3.Rows.Add();
                    dataGridView3.Rows[ad].Cells[0].Value = (i + 1).ToString();
                    dataGridView3.Rows[ad].Cells[1].Value = redoneado.ToString();

                    nps[i] = redoneado;
                    m = modulo;
                    Xo = m;
                }
            }

            //validación para comenzar la prueba
            if (nn.Text == "" && Nsig.Text == "")
            {
                MessageBox.Show("Para realizar la prueba son necesarios los valores a analizar y el nivel de significancia.");
            }
            else
            {
  
                //tabla de distribución normal para obtener el limite superor (Za/2)
                {
                    double numa = 0.0;
                    for (int i = 0; i < 30; i++)
                    {
                        dataGridView2.Rows.Add();

                        dataGridView2.Rows[i].Cells[0].Value = numa;
                        numa = numa + 0.1;
                    }

                    //fila .00
                    dataGridView2.Rows[0].Cells[1].Value = 0.0000;
                    dataGridView2.Rows[0].Cells[2].Value = 0.0040;
                    dataGridView2.Rows[0].Cells[3].Value = 0.0080;
                    dataGridView2.Rows[0].Cells[4].Value = 0.0120;
                    dataGridView2.Rows[0].Cells[5].Value = 0.0160;
                    dataGridView2.Rows[0].Cells[6].Value = 0.0199;
                    dataGridView2.Rows[0].Cells[7].Value = 0.0239;
                    dataGridView2.Rows[0].Cells[8].Value = 0.0279;
                    dataGridView2.Rows[0].Cells[9].Value = 0.0319;
                    dataGridView2.Rows[0].Cells[10].Value = 0.0359;

                    //fila .01
                    dataGridView2.Rows[1].Cells[1].Value = 0.0398;
                    dataGridView2.Rows[1].Cells[2].Value = 0.0438;
                    dataGridView2.Rows[1].Cells[3].Value = 0.0478;
                    dataGridView2.Rows[1].Cells[4].Value = 0.0517;
                    dataGridView2.Rows[1].Cells[5].Value = 0.0557;
                    dataGridView2.Rows[1].Cells[6].Value = 0.0596;
                    dataGridView2.Rows[1].Cells[7].Value = 0.0636;
                    dataGridView2.Rows[1].Cells[8].Value = 0.0675;
                    dataGridView2.Rows[1].Cells[9].Value = 0.0714;
                    dataGridView2.Rows[1].Cells[10].Value = 0.0753;

                    //fila .02
                    dataGridView2.Rows[2].Cells[1].Value = 0.0793;
                    dataGridView2.Rows[2].Cells[2].Value = 0.0832;
                    dataGridView2.Rows[2].Cells[3].Value = 0.0871;
                    dataGridView2.Rows[2].Cells[4].Value = 0.0910;
                    dataGridView2.Rows[2].Cells[5].Value = 0.0948;
                    dataGridView2.Rows[2].Cells[6].Value = 0.0987;
                    dataGridView2.Rows[2].Cells[7].Value = 0.1026;
                    dataGridView2.Rows[2].Cells[8].Value = 0.1064;
                    dataGridView2.Rows[2].Cells[9].Value = 0.1103;
                    dataGridView2.Rows[2].Cells[10].Value = 0.1141;

                    //fila .3
                    dataGridView2.Rows[3].Cells[1].Value = 0.1179;
                    dataGridView2.Rows[3].Cells[2].Value = 0.1217;
                    dataGridView2.Rows[3].Cells[3].Value = 0.1255;
                    dataGridView2.Rows[3].Cells[4].Value = 0.1293;
                    dataGridView2.Rows[3].Cells[5].Value = 0.1331;
                    dataGridView2.Rows[3].Cells[6].Value = 0.1368;
                    dataGridView2.Rows[3].Cells[7].Value = 0.1406;
                    dataGridView2.Rows[3].Cells[8].Value = 0.1443;
                    dataGridView2.Rows[3].Cells[9].Value = 0.1480;
                    dataGridView2.Rows[3].Cells[10].Value = 0.1517;

                    //fila .4
                    dataGridView2.Rows[4].Cells[1].Value = 0.1554;
                    dataGridView2.Rows[4].Cells[2].Value = 0.1591;
                    dataGridView2.Rows[4].Cells[3].Value = 0.1628;
                    dataGridView2.Rows[4].Cells[4].Value = 0.1664;
                    dataGridView2.Rows[4].Cells[5].Value = 0.1700;
                    dataGridView2.Rows[4].Cells[6].Value = 0.1736;
                    dataGridView2.Rows[4].Cells[7].Value = 0.1772;
                    dataGridView2.Rows[4].Cells[8].Value = 0.1808;
                    dataGridView2.Rows[4].Cells[9].Value = 0.1844;
                    dataGridView2.Rows[4].Cells[10].Value = 0.1879;

                    //fila .5
                    dataGridView2.Rows[5].Cells[1].Value = 0.1915;
                    dataGridView2.Rows[5].Cells[2].Value = 0.1950;
                    dataGridView2.Rows[5].Cells[3].Value = 0.1985;
                    dataGridView2.Rows[5].Cells[4].Value = 0.2019;
                    dataGridView2.Rows[5].Cells[5].Value = 0.2054;
                    dataGridView2.Rows[5].Cells[6].Value = 0.2088;
                    dataGridView2.Rows[5].Cells[7].Value = 0.2123;
                    dataGridView2.Rows[5].Cells[8].Value = 0.2157;
                    dataGridView2.Rows[5].Cells[9].Value = 0.2190;
                    dataGridView2.Rows[5].Cells[10].Value = 0.2224;

                    //fila .6
                    dataGridView2.Rows[6].Cells[1].Value = 0.2257;
                    dataGridView2.Rows[6].Cells[2].Value = 0.2291;
                    dataGridView2.Rows[6].Cells[3].Value = 0.2324;
                    dataGridView2.Rows[6].Cells[4].Value = 0.2357;
                    dataGridView2.Rows[6].Cells[5].Value = 0.2389;
                    dataGridView2.Rows[6].Cells[6].Value = 0.2422;
                    dataGridView2.Rows[6].Cells[7].Value = 0.2454;
                    dataGridView2.Rows[6].Cells[8].Value = 0.2486;
                    dataGridView2.Rows[6].Cells[9].Value = 0.2517;
                    dataGridView2.Rows[6].Cells[10].Value = 0.2549;

                    //fila .7
                    dataGridView2.Rows[7].Cells[1].Value = 0.2580;
                    dataGridView2.Rows[7].Cells[2].Value = 0.2611;
                    dataGridView2.Rows[7].Cells[3].Value = 0.2642;
                    dataGridView2.Rows[7].Cells[4].Value = 0.2673;
                    dataGridView2.Rows[7].Cells[5].Value = 0.2703;
                    dataGridView2.Rows[7].Cells[6].Value = 0.2734;
                    dataGridView2.Rows[7].Cells[7].Value = 0.2764;
                    dataGridView2.Rows[7].Cells[8].Value = 0.2794;
                    dataGridView2.Rows[7].Cells[9].Value = 0.2833;
                    dataGridView2.Rows[7].Cells[10].Value = 0.2852;

                    //fila .8
                    dataGridView2.Rows[8].Cells[1].Value = 0.2881;
                    dataGridView2.Rows[8].Cells[2].Value = 0.2910;
                    dataGridView2.Rows[8].Cells[3].Value = 0.2939;
                    dataGridView2.Rows[8].Cells[4].Value = 0.2967;
                    dataGridView2.Rows[8].Cells[5].Value = 0.2995;
                    dataGridView2.Rows[8].Cells[6].Value = 0.3023;
                    dataGridView2.Rows[8].Cells[7].Value = 0.3051;
                    dataGridView2.Rows[8].Cells[8].Value = 0.3078;
                    dataGridView2.Rows[8].Cells[9].Value = 0.3106;
                    dataGridView2.Rows[8].Cells[10].Value = 0.3133;

                    //fila .9
                    dataGridView2.Rows[9].Cells[1].Value = 0.3159;
                    dataGridView2.Rows[9].Cells[2].Value = 0.3186;
                    dataGridView2.Rows[9].Cells[3].Value = 0.3212;
                    dataGridView2.Rows[9].Cells[4].Value = 0.3238;
                    dataGridView2.Rows[9].Cells[5].Value = 0.3264;
                    dataGridView2.Rows[9].Cells[6].Value = 0.3289;
                    dataGridView2.Rows[9].Cells[7].Value = 0.3315;
                    dataGridView2.Rows[9].Cells[8].Value = 0.3340;
                    dataGridView2.Rows[9].Cells[9].Value = 0.3365;
                    dataGridView2.Rows[9].Cells[10].Value = 0.3389;

                    //fila 1.0
                    dataGridView2.Rows[10].Cells[1].Value = 0.3413;
                    dataGridView2.Rows[10].Cells[2].Value = 0.3438;
                    dataGridView2.Rows[10].Cells[3].Value = 0.3461;
                    dataGridView2.Rows[10].Cells[4].Value = 0.3485;
                    dataGridView2.Rows[10].Cells[5].Value = 0.3508;
                    dataGridView2.Rows[10].Cells[6].Value = 0.3531;
                    dataGridView2.Rows[10].Cells[7].Value = 0.3554;
                    dataGridView2.Rows[10].Cells[8].Value = 0.3577;
                    dataGridView2.Rows[10].Cells[9].Value = 0.3599;
                    dataGridView2.Rows[10].Cells[10].Value = 0.3621;

                    //fila 1.1
                    dataGridView2.Rows[11].Cells[1].Value = 0.3643;
                    dataGridView2.Rows[11].Cells[2].Value = 0.3665;
                    dataGridView2.Rows[11].Cells[3].Value = 0.3686;
                    dataGridView2.Rows[11].Cells[4].Value = 0.3708;
                    dataGridView2.Rows[11].Cells[5].Value = 0.3729;
                    dataGridView2.Rows[11].Cells[6].Value = 0.3749;
                    dataGridView2.Rows[11].Cells[7].Value = 0.3770;
                    dataGridView2.Rows[11].Cells[8].Value = 0.3790;
                    dataGridView2.Rows[11].Cells[9].Value = 0.3810;
                    dataGridView2.Rows[11].Cells[10].Value = 0.3830;

                    //fila 1.2
                    dataGridView2.Rows[12].Cells[1].Value = 0.3849;
                    dataGridView2.Rows[12].Cells[2].Value = 0.3869;
                    dataGridView2.Rows[12].Cells[3].Value = 0.3888;
                    dataGridView2.Rows[12].Cells[4].Value = 0.3907;
                    dataGridView2.Rows[12].Cells[5].Value = 0.3925;
                    dataGridView2.Rows[12].Cells[6].Value = 0.3944;
                    dataGridView2.Rows[12].Cells[7].Value = 0.3962;
                    dataGridView2.Rows[12].Cells[8].Value = 0.3980;
                    dataGridView2.Rows[12].Cells[9].Value = 0.3997;
                    dataGridView2.Rows[12].Cells[10].Value = 0.4015;

                    //fila 1.3
                    dataGridView2.Rows[13].Cells[1].Value = 0.4032;
                    dataGridView2.Rows[13].Cells[2].Value = 0.4049;
                    dataGridView2.Rows[13].Cells[3].Value = 0.4066;
                    dataGridView2.Rows[13].Cells[4].Value = 0.4082;
                    dataGridView2.Rows[13].Cells[5].Value = 0.4099;
                    dataGridView2.Rows[13].Cells[6].Value = 0.4115;
                    dataGridView2.Rows[13].Cells[7].Value = 0.4131;
                    dataGridView2.Rows[13].Cells[8].Value = 0.4147;
                    dataGridView2.Rows[13].Cells[9].Value = 0.4162;
                    dataGridView2.Rows[13].Cells[10].Value = 0.4177;

                    //fila 1.4
                    dataGridView2.Rows[14].Cells[1].Value = 0.4192;
                    dataGridView2.Rows[14].Cells[2].Value = 0.4207;
                    dataGridView2.Rows[14].Cells[3].Value = 0.4222;
                    dataGridView2.Rows[14].Cells[4].Value = 0.4236;
                    dataGridView2.Rows[14].Cells[5].Value = 0.4251;
                    dataGridView2.Rows[14].Cells[6].Value = 0.4265;
                    dataGridView2.Rows[14].Cells[7].Value = 0.4279;
                    dataGridView2.Rows[14].Cells[8].Value = 0.4292;
                    dataGridView2.Rows[14].Cells[9].Value = 0.4306;
                    dataGridView2.Rows[14].Cells[10].Value = 0.4319;

                    //fila 1.5
                    dataGridView2.Rows[15].Cells[1].Value = 0.4332;
                    dataGridView2.Rows[15].Cells[2].Value = 0.4345;
                    dataGridView2.Rows[15].Cells[3].Value = 0.4357;
                    dataGridView2.Rows[15].Cells[4].Value = 0.4370;
                    dataGridView2.Rows[15].Cells[5].Value = 0.4382;
                    dataGridView2.Rows[15].Cells[6].Value = 0.4394;
                    dataGridView2.Rows[15].Cells[7].Value = 0.4406;
                    dataGridView2.Rows[15].Cells[8].Value = 0.4418;
                    dataGridView2.Rows[15].Cells[9].Value = 0.4429;
                    dataGridView2.Rows[15].Cells[10].Value = 0.4441;

                    //fila 1.6
                    dataGridView2.Rows[16].Cells[1].Value = 0.4452;
                    dataGridView2.Rows[16].Cells[2].Value = 0.4463;
                    dataGridView2.Rows[16].Cells[3].Value = 0.4474;
                    dataGridView2.Rows[16].Cells[4].Value = 0.4484;
                    dataGridView2.Rows[16].Cells[5].Value = 0.4495;
                    dataGridView2.Rows[16].Cells[6].Value = 0.4505;
                    dataGridView2.Rows[16].Cells[7].Value = 0.4515;
                    dataGridView2.Rows[16].Cells[8].Value = 0.4525;
                    dataGridView2.Rows[16].Cells[9].Value = 0.4535;
                    dataGridView2.Rows[16].Cells[10].Value = 0.4545;

                    //fila 1.7
                    dataGridView2.Rows[17].Cells[1].Value = 0.4554;
                    dataGridView2.Rows[17].Cells[2].Value = 0.4564;
                    dataGridView2.Rows[17].Cells[3].Value = 0.4573;
                    dataGridView2.Rows[17].Cells[4].Value = 0.4582;
                    dataGridView2.Rows[17].Cells[5].Value = 0.4591;
                    dataGridView2.Rows[17].Cells[6].Value = 0.4599;
                    dataGridView2.Rows[17].Cells[7].Value = 0.4608;
                    dataGridView2.Rows[17].Cells[8].Value = 0.4616;
                    dataGridView2.Rows[17].Cells[9].Value = 0.4625;
                    dataGridView2.Rows[17].Cells[10].Value = 0.4633;

                    //fila 1.8
                    dataGridView2.Rows[18].Cells[1].Value = 0.4641;
                    dataGridView2.Rows[18].Cells[2].Value = 0.4649;
                    dataGridView2.Rows[18].Cells[3].Value = 0.4656;
                    dataGridView2.Rows[18].Cells[4].Value = 0.4664;
                    dataGridView2.Rows[18].Cells[5].Value = 0.4671;
                    dataGridView2.Rows[18].Cells[6].Value = 0.4678;
                    dataGridView2.Rows[18].Cells[7].Value = 0.4686;
                    dataGridView2.Rows[18].Cells[8].Value = 0.4693;
                    dataGridView2.Rows[18].Cells[9].Value = 0.4699;
                    dataGridView2.Rows[18].Cells[10].Value = 0.4706;

                    //fila 1.9
                    dataGridView2.Rows[19].Cells[1].Value = 0.4713;
                    dataGridView2.Rows[19].Cells[2].Value = 0.4719;
                    dataGridView2.Rows[19].Cells[3].Value = 0.4726;
                    dataGridView2.Rows[19].Cells[4].Value = 0.4732;
                    dataGridView2.Rows[19].Cells[5].Value = 0.4738;
                    dataGridView2.Rows[19].Cells[6].Value = 0.4744;
                    dataGridView2.Rows[19].Cells[7].Value = 0.4750;
                    dataGridView2.Rows[19].Cells[8].Value = 0.4756;
                    dataGridView2.Rows[19].Cells[9].Value = 0.4761;
                    dataGridView2.Rows[19].Cells[10].Value = 0.4767;

                    //fila 2.0
                    dataGridView2.Rows[20].Cells[1].Value = 0.4772;
                    dataGridView2.Rows[20].Cells[2].Value = 0.4778;
                    dataGridView2.Rows[20].Cells[3].Value = 0.4783;
                    dataGridView2.Rows[20].Cells[4].Value = 0.4788;
                    dataGridView2.Rows[20].Cells[5].Value = 0.4793;
                    dataGridView2.Rows[20].Cells[6].Value = 0.4898;
                    dataGridView2.Rows[20].Cells[7].Value = 0.4803;
                    dataGridView2.Rows[20].Cells[8].Value = 0.4808;
                    dataGridView2.Rows[20].Cells[9].Value = 0.4812;
                    dataGridView2.Rows[20].Cells[10].Value = 0.4817;

                    //fila 2.1
                    dataGridView2.Rows[21].Cells[1].Value = 0.4821;
                    dataGridView2.Rows[21].Cells[2].Value = 0.4826;
                    dataGridView2.Rows[21].Cells[3].Value = 0.4830;
                    dataGridView2.Rows[21].Cells[4].Value = 0.4834;
                    dataGridView2.Rows[21].Cells[5].Value = 0.4838;
                    dataGridView2.Rows[21].Cells[6].Value = 0.4842;
                    dataGridView2.Rows[21].Cells[7].Value = 0.4846;
                    dataGridView2.Rows[21].Cells[8].Value = 0.4850;
                    dataGridView2.Rows[21].Cells[9].Value = 0.4854;
                    dataGridView2.Rows[21].Cells[10].Value = 0.4857;

                    //fila 2.2
                    dataGridView2.Rows[22].Cells[1].Value = 0.4861;
                    dataGridView2.Rows[22].Cells[2].Value = 0.4864;
                    dataGridView2.Rows[22].Cells[3].Value = 0.4868;
                    dataGridView2.Rows[22].Cells[4].Value = 0.4871;
                    dataGridView2.Rows[22].Cells[5].Value = 0.4875;
                    dataGridView2.Rows[22].Cells[6].Value = 0.4878;
                    dataGridView2.Rows[22].Cells[7].Value = 0.4881;
                    dataGridView2.Rows[22].Cells[8].Value = 0.4884;
                    dataGridView2.Rows[22].Cells[9].Value = 0.4887;
                    dataGridView2.Rows[22].Cells[10].Value = 0.4890;

                    //fila 2.3
                    dataGridView2.Rows[23].Cells[1].Value = 0.4893;
                    dataGridView2.Rows[23].Cells[2].Value = 0.4896;
                    dataGridView2.Rows[23].Cells[3].Value = 0.4898;
                    dataGridView2.Rows[23].Cells[4].Value = 0.4901;
                    dataGridView2.Rows[23].Cells[5].Value = 0.4904;
                    dataGridView2.Rows[23].Cells[6].Value = 0.4906;
                    dataGridView2.Rows[23].Cells[7].Value = 0.4909;
                    dataGridView2.Rows[23].Cells[8].Value = 0.4911;
                    dataGridView2.Rows[23].Cells[9].Value = 0.4913;
                    dataGridView2.Rows[23].Cells[10].Value = 0.4916;

                    //fila 2.4
                    dataGridView2.Rows[24].Cells[1].Value = 0.4918;
                    dataGridView2.Rows[24].Cells[2].Value = 0.4920;
                    dataGridView2.Rows[24].Cells[3].Value = 0.4922;
                    dataGridView2.Rows[24].Cells[4].Value = 0.4925;
                    dataGridView2.Rows[24].Cells[5].Value = 0.4927;
                    dataGridView2.Rows[24].Cells[6].Value = 0.4929;
                    dataGridView2.Rows[24].Cells[7].Value = 0.4931;
                    dataGridView2.Rows[24].Cells[8].Value = 0.4932;
                    dataGridView2.Rows[24].Cells[9].Value = 0.4934;
                    dataGridView2.Rows[24].Cells[10].Value = 0.4936;

                    //fila 2.5
                    dataGridView2.Rows[25].Cells[1].Value = 0.4938;
                    dataGridView2.Rows[25].Cells[2].Value = 0.4940;
                    dataGridView2.Rows[25].Cells[3].Value = 0.4941;
                    dataGridView2.Rows[25].Cells[4].Value = 0.4943;
                    dataGridView2.Rows[25].Cells[5].Value = 0.4945;
                    dataGridView2.Rows[25].Cells[6].Value = 0.4946;
                    dataGridView2.Rows[25].Cells[7].Value = 0.4948;
                    dataGridView2.Rows[25].Cells[8].Value = 0.4949;
                    dataGridView2.Rows[25].Cells[9].Value = 0.4951;
                    dataGridView2.Rows[25].Cells[10].Value = 0.4952;

                    //fila 2.6
                    dataGridView2.Rows[26].Cells[1].Value = 0.4953;
                    dataGridView2.Rows[26].Cells[2].Value = 0.4955;
                    dataGridView2.Rows[26].Cells[3].Value = 0.4956;
                    dataGridView2.Rows[26].Cells[4].Value = 0.4957;
                    dataGridView2.Rows[26].Cells[5].Value = 0.4959;
                    dataGridView2.Rows[26].Cells[6].Value = 0.4960;
                    dataGridView2.Rows[26].Cells[7].Value = 0.4961;
                    dataGridView2.Rows[26].Cells[8].Value = 0.4962;
                    dataGridView2.Rows[26].Cells[9].Value = 0.4963;
                    dataGridView2.Rows[26].Cells[10].Value = 0.4964;

                    //fila 2.7
                    dataGridView2.Rows[27].Cells[1].Value = 0.4965;
                    dataGridView2.Rows[27].Cells[2].Value = 0.4966;
                    dataGridView2.Rows[27].Cells[3].Value = 0.4967;
                    dataGridView2.Rows[27].Cells[4].Value = 0.4968;
                    dataGridView2.Rows[27].Cells[5].Value = 0.4969;
                    dataGridView2.Rows[27].Cells[6].Value = 0.4970;
                    dataGridView2.Rows[27].Cells[7].Value = 0.4971;
                    dataGridView2.Rows[27].Cells[8].Value = 0.4972;
                    dataGridView2.Rows[27].Cells[9].Value = 0.4973;
                    dataGridView2.Rows[27].Cells[10].Value = 0.4974;

                    //fila 2.8
                    dataGridView2.Rows[28].Cells[1].Value = 0.4974;
                    dataGridView2.Rows[28].Cells[2].Value = 0.4975;
                    dataGridView2.Rows[28].Cells[3].Value = 0.4976;
                    dataGridView2.Rows[28].Cells[4].Value = 0.4977;
                    dataGridView2.Rows[28].Cells[5].Value = 0.4977;
                    dataGridView2.Rows[28].Cells[6].Value = 0.4978;
                    dataGridView2.Rows[28].Cells[7].Value = 0.4979;
                    dataGridView2.Rows[28].Cells[8].Value = 0.4979;
                    dataGridView2.Rows[28].Cells[9].Value = 0.4980;
                    dataGridView2.Rows[28].Cells[10].Value = 0.4981;

                    //fila 2.9
                    dataGridView2.Rows[29].Cells[1].Value = 0.4981;
                    dataGridView2.Rows[29].Cells[2].Value = 0.4982;
                    dataGridView2.Rows[29].Cells[3].Value = 0.4982;
                    dataGridView2.Rows[29].Cells[4].Value = 0.4983;
                    dataGridView2.Rows[29].Cells[5].Value = 0.4984;
                    dataGridView2.Rows[29].Cells[6].Value = 0.4984;
                    dataGridView2.Rows[29].Cells[7].Value = 0.4985;
                    dataGridView2.Rows[29].Cells[8].Value = 0.4985;
                    dataGridView2.Rows[29].Cells[9].Value = 0.4986;
                    dataGridView2.Rows[29].Cells[10].Value = 0.4986;

                    //fila 30
                    dataGridView2.Rows[30].Cells[0].Value = 3.0;
                    dataGridView2.Rows[30].Cells[1].Value = 0.4987;
                    dataGridView2.Rows[30].Cells[2].Value = 0.4987;
                    dataGridView2.Rows[30].Cells[3].Value = 0.4987;
                    dataGridView2.Rows[30].Cells[4].Value = 0.4988;
                    dataGridView2.Rows[30].Cells[5].Value = 0.4988;
                    dataGridView2.Rows[30].Cells[6].Value = 0.4989;
                    dataGridView2.Rows[30].Cells[7].Value = 0.4989;
                    dataGridView2.Rows[30].Cells[8].Value = 0.4989;
                    dataGridView2.Rows[30].Cells[9].Value = 0.4990;
                    dataGridView2.Rows[30].Cells[10].Value = 0.4990;


                    alpf2 = VaSig *8;

                    //for (int i = 0; i < 30; i++)
                    //{
                    //    for (int j = 0; j < 11; j++)
                    //    {
                    //        area2 = Double.Parse(dataGridView2.Rows[i].Cells[j].Value.ToString());
                    //        if (area2 == alpf2)
                    //        {
                    //            columnatabla = Double.Parse(dataGridView2.Rows[i].Cells[j].OwningColumn.HeaderText);
                    //            filatabla = Double.Parse(dataGridView2.Rows[i].Cells[0].Value.ToString());
                    //            //vtablas = columnatabla + filatabla;
                    //            intsup = columnatabla + filatabla;
                    //            //txtVtablas.Text = vtablas.ToString();

                    //            i = 30;
                    //            vtpasar = false;
                    //        }
                    //        else if (area2 < alpf2)
                    //        {
                    //            double.TryParse(dataGridView2.Rows[i].Cells[j].OwningColumn.HeaderText, out cct);
                    //            double.TryParse(dataGridView2.Rows[i].Cells[0].Value.ToString(), out rrt);

                    //            cct2 = double.Parse(dataGridView2.Rows[i].Cells[j].Value.ToString());
                    //            indexC = (dataGridView2.Rows[i].Cells[j].ColumnIndex);
                    //            indexR = dataGridView2.Rows[i].Cells[j].RowIndex;
                    //            vtpasar = true;

                    //        }
                    //    }
                    //}
                    //if (vtpasar == true)
                    //{
                    //    double c = double.Parse(dataGridView2.Rows[indexR].Cells[indexC + 1].Value.ToString());
                    //    double index = double.Parse(dataGridView2.Rows[indexR].Cells[indexC + 1].OwningColumn.HeaderText);
                    //    double tablasA = cct + rrt;
                    //    vtablas = (((c - alpf2) * (c - cct2)) / (index - cct)) + tablasA;
                    //    //txtVtablas.Text = vtablas.ToString();
                    //    intsup = columnatabla + filatabla;
                    //}
                    
                }
                //datos de los intervalos
                //invasig = 1 - VaSig;
                intinf = alpf2;

                intsup = VaSig * 12;

                LimIn.Text = intinf.ToString();
                
                LimSup.Text = intsup.ToString();
                teta = intsup - intinf;
                AlphM.Text = teta.ToString();

                //comparación de los numeros pseudoaleatorios y la probabilidad acumulada
                for (int i = 0; i < NcPS; i++)
                {
                    //comparación de rango
                    if (nps[i] < intinf)
                    {
                        contR++;
                    }
                    else if (nps[i] >= intinf && nps[i] <= intsup)
                    {
                        contA = true;
                    }
                    else if (nps[i] > intsup)
                    {
                        contR++;
                    }
                    //conteo de distancia // Optener FO
                    if (contA == true || i == NcPS-1)
                    {
                        if (contR == 0)
                        {
                            FOc1++;
                            contR = 0;
                            contA = false;
                        }
                        else if (contR == 1)
                        {
                            FOc2++;
                            contR = 0;
                            contA = false;
                        }
                        else if (contR >= 2)
                        {
                            FOc3++;
                            contR = 0;
                            contA = false;
                        }

                        
                    }

                }
                // optener probabilidad
                pro1 = teta * (Math.Pow((1 - teta), 0));
                pro2 = teta * (Math.Pow((1 - teta), 1));
                pro3 = 1 - (pro1 + pro2); //pro3= (Math.Pow((1 - teta), FOc2));
                                          //optener FE
                totalFO = FOc1 + FOc2 + FOc3;
                FE = totalFO * pro1;
                FE2 = totalFO * pro2;
                FE3 = totalFO * pro3;
                //Obtención del valor calculado.
                ValorCA = ((Math.Pow((FOc1 - FE), 2)) / FE) + ((Math.Pow((FOc2 - FE2), 2)) / FE2) + ((Math.Pow((FOc3 - FE3), 2)) / FE3);
                ValorCA = (Math.Round(ValorCA, 5));

                //Mostrar resutados en la tabla.
                for(int ro = 0; ro < 3; ro++)
                {
                    dataGridView1.Rows.Add();
                }
                dataGridView1.Rows[0].Cells[0].Value = 0;
                dataGridView1.Rows[0].Cells[1].Value = FOc1;
                dataGridView1.Rows[0].Cells[2].Value = pro1;
                dataGridView1.Rows[0].Cells[3].Value = FE;

                dataGridView1.Rows[1].Cells[0].Value = 1;
                dataGridView1.Rows[1].Cells[1].Value = FOc2;
                dataGridView1.Rows[1].Cells[2].Value = pro2;
                dataGridView1.Rows[1].Cells[3].Value = FE2;

                dataGridView1.Rows[2].Cells[0].Value = "2 a +";
                dataGridView1.Rows[2].Cells[1].Value = FOc3;
                dataGridView1.Rows[2].Cells[2].Value = pro3;
                dataGridView1.Rows[2].Cells[3].Value = FE3;

                //obtención del valor de tablas.
                {
                    if (CaG - GL == 1)
                    {
                        if (VaSig == 0.995)
                        {
                            valorT = 0.000;
                        }
                        else if (VaSig == 0.990)
                        {
                            valorT = 0.000;
                        }
                        else if (VaSig == 0.975)
                        {
                            valorT = 0.000;
                        }
                        else if (VaSig == 0.950)
                        {
                            valorT = 0.000;
                        }
                        else if (VaSig == 0.500)
                        {
                            valorT = 0.45;
                        }
                        else if (VaSig == 0.050)
                        {
                            valorT = 3.85;
                        }
                        else if (VaSig == 0.25)
                        {
                            valorT = 5.02;
                        }
                        else if (VaSig == 0.010)
                        {
                            valorT = 6.63;
                        }
                        else if (VaSig == 0.005)
                        {
                            valorT = 7.88;
                        }
                    }
                    else if (CaG - GL == 2)
                    {
                        if (VaSig == 0.995)
                        {
                            valorT = 0.01;
                        }
                        else if (VaSig == 0.990)
                        {
                            valorT = 0.02;
                        }
                        else if (VaSig == 0.975)
                        {
                            valorT = 0.05;
                        }
                        else if (VaSig == 0.950)
                        {
                            valorT = 0.10;
                        }
                        else if (VaSig == 0.500)
                        {
                            valorT = 1.39;
                        }
                        else if (VaSig == 0.050)
                        {
                            valorT = 5.99;
                        }
                        else if (VaSig == 0.25)
                        {
                            valorT = 7.38;
                        }
                        else if (VaSig == 0.010)
                        {
                            valorT = 9.21;
                        }
                        else if (VaSig == 0.005)
                        {
                            valorT = 10.60;
                        }
                    }
                    else if (CaG - GL == 3)
                    {
                        if (VaSig == 0.995)
                        {
                            valorT = 0.07;
                        }
                        else if (VaSig == 0.990)
                        {
                            valorT = 0.11;
                        }
                        else if (VaSig == 0.975)
                        {
                            valorT = 0.22;
                        }
                        else if (VaSig == 0.950)
                        {
                            valorT = 0.35;
                        }
                        else if (VaSig == 0.500)
                        {
                            valorT = 2.37;
                        }
                        else if (VaSig == 0.050)
                        {
                            valorT = 7.81;
                        }
                        else if (VaSig == 0.25)
                        {
                            valorT = 9.35;
                        }
                        else if (VaSig == 0.010)
                        {
                            valorT = 11.34;
                        }
                        else if (VaSig == 0.005)
                        {
                            valorT = 12.84;
                        }
                    }
                    else if (CaG - GL == 4)
                    {
                        if (VaSig == 0.995)
                        {
                            valorT = 0.21;
                        }
                        else if (VaSig == 0.990)
                        {
                            valorT = 0.30;
                        }
                        else if (VaSig == 0.975)
                        {
                            valorT = 0.48;
                        }
                        else if (VaSig == 0.950)
                        {
                            valorT = 0.71;
                        }
                        else if (VaSig == 0.500)
                        {
                            valorT = 3.36;
                        }
                        else if (VaSig == 0.050)
                        {
                            valorT = 9.49;
                        }
                        else if (VaSig == 0.25)
                        {
                            valorT = 11.14;
                        }
                        else if (VaSig == 0.010)
                        {
                            valorT = 13.28;
                        }
                        else if (VaSig == 0.005)
                        {
                            valorT = 14.86;
                        }
                    }
                    else if (CaG - GL == 5)
                    {
                        if (VaSig == 0.995)
                        {
                            valorT = 0.41;
                        }
                        else if (VaSig == 0.990)
                        {
                            valorT = 0.55;
                        }
                        else if (VaSig == 0.975)
                        {
                            valorT = 0.83;
                        }
                        else if (VaSig == 0.950)
                        {
                            valorT = 1.15;
                        }
                        else if (VaSig == 0.500)
                        {
                            valorT = 4.35;
                        }
                        else if (VaSig == 0.050)
                        {
                            valorT = 11.07;
                        }
                        else if (VaSig == 0.25)
                        {
                            valorT = 12.83;
                        }
                        else if (VaSig == 0.010)
                        {
                            valorT = 15.09;
                        }
                        else if (VaSig == 0.005)
                        {
                            valorT = 16.75;
                        }
                    }
                    else if (CaG - GL == 6)
                    {
                        if (VaSig == 0.995)
                        {
                            valorT = 0.68;
                        }
                        else if (VaSig == 0.990)
                        {
                            valorT = 0.87;
                        }
                        else if (VaSig == 0.975)
                        {
                            valorT = 1.24;
                        }
                        else if (VaSig == 0.950)
                        {
                            valorT = 1.64;
                        }
                        else if (VaSig == 0.500)
                        {
                            valorT = 5.35;
                        }
                        else if (VaSig == 0.050)
                        {
                            valorT = 12.59;
                        }
                        else if (VaSig == 0.25)
                        {
                            valorT = 14.45;
                        }
                        else if (VaSig == 0.010)
                        {
                            valorT = 16.81;
                        }
                        else if (VaSig == 0.005)
                        {
                            valorT = 18.55;
                        }
                    }
                    else if (CaG - GL == 7)
                    {
                        if (VaSig == 0.995)
                        {
                            valorT = 0.99;
                        }
                        else if (VaSig == 0.990)
                        {
                            valorT = 1.24;
                        }
                        else if (VaSig == 0.975)
                        {
                            valorT = 1.69;
                        }
                        else if (VaSig == 0.950)
                        {
                            valorT = 2.17;
                        }
                        else if (VaSig == 0.500)
                        {
                            valorT = 6.35;
                        }
                        else if (VaSig == 0.050)
                        {
                            valorT = 14.07;
                        }
                        else if (VaSig == 0.25)
                        {
                            valorT = 16.01;
                        }
                        else if (VaSig == 0.010)
                        {
                            valorT = 18.48;
                        }
                        else if (VaSig == 0.005)
                        {
                            valorT = 20.28;
                        }
                    }
                    else if (CaG - GL == 8)
                    {
                        if (VaSig == 0.995)
                        {
                            valorT = 1.34;
                        }
                        else if (VaSig == 0.990)
                        {
                            valorT = 1.65;
                        }
                        else if (VaSig == 0.975)
                        {
                            valorT = 2.18;
                        }
                        else if (VaSig == 0.950)
                        {
                            valorT = 2.73;
                        }
                        else if (VaSig == 0.500)
                        {
                            valorT = 7.34;
                        }
                        else if (VaSig == 0.050)
                        {
                            valorT = 15.51;
                        }
                        else if (VaSig == 0.25)
                        {
                            valorT = 17.53;
                        }
                        else if (VaSig == 0.010)
                        {
                            valorT = 20.09;
                        }
                        else if (VaSig == 0.005)
                        {
                            valorT = 21.96;
                        }
                    }
                    else if (CaG - GL == 9)
                    {
                        if (VaSig == 0.995)
                        {
                            valorT = 1.73;
                        }
                        else if (VaSig == 0.990)
                        {
                            valorT = 2.09;
                        }
                        else if (VaSig == 0.975)
                        {
                            valorT = 2.70;
                        }
                        else if (VaSig == 0.950)
                        {
                            valorT = 3.33;
                        }
                        else if (VaSig == 0.500)
                        {
                            valorT = 8.34;
                        }
                        else if (VaSig == 0.050)
                        {
                            valorT = 16.92;
                        }
                        else if (VaSig == 0.25)
                        {
                            valorT = 19.02;
                        }
                        else if (VaSig == 0.010)
                        {
                            valorT = 21.67;
                        }
                        else if (VaSig == 0.005)
                        {
                            valorT = 23.59;
                        }
                    }
                    else if (CaG - GL == 10)
                    {
                        if (VaSig == 0.995)
                        {
                            valorT = 2.16;
                        }
                        else if (VaSig == 0.990)
                        {
                            valorT = 2.56;
                        }
                        else if (VaSig == 0.975)
                        {
                            valorT = 3.25;
                        }
                        else if (VaSig == 0.950)
                        {
                            valorT = 3.94;
                        }
                        else if (VaSig == 0.500)
                        {
                            valorT = 9.34;
                        }
                        else if (VaSig == 0.050)
                        {
                            valorT = 18.31;
                        }
                        else if (VaSig == 0.25)
                        {
                            valorT = 20.48;
                        }
                        else if (VaSig == 0.010)
                        {
                            valorT = 23.21;
                        }
                        else if (VaSig == 0.005)
                        {
                            valorT = 25.19;
                        }
                    }
                    if (CaG - GL == 11)
                    {
                        if (VaSig == 0.995)
                        {
                            valorT = 2.60;
                        }
                        else if (VaSig == 0.990)
                        {
                            valorT = 3.05;
                        }
                        else if (VaSig == 0.975)
                        {
                            valorT = 3.82;
                        }
                        else if (VaSig == 0.950)
                        {
                            valorT = 4.57;
                        }
                        else if (VaSig == 0.500)
                        {
                            valorT = 10.34;
                        }
                        else if (VaSig == 0.050)
                        {
                            valorT = 19.68;
                        }
                        else if (VaSig == 0.25)
                        {
                            valorT = 21.92;
                        }
                        else if (VaSig == 0.010)
                        {
                            valorT = 24.72;
                        }
                        else if (VaSig == 0.005)
                        {
                            valorT = 26.76;
                        }
                    }
                    else if (CaG - GL == 12)
                    {
                        if (VaSig == 0.995)
                        {
                            valorT = 3.07;
                        }
                        else if (VaSig == 0.990)
                        {
                            valorT = 3.57;
                        }
                        else if (VaSig == 0.975)
                        {
                            valorT = 4.40;
                        }
                        else if (VaSig == 0.950)
                        {
                            valorT = 5.23;
                        }
                        else if (VaSig == 0.500)
                        {
                            valorT = 11.34;
                        }
                        else if (VaSig == 0.050)
                        {
                            valorT = 21.03;
                        }
                        else if (VaSig == 0.25)
                        {
                            valorT = 23.34;
                        }
                        else if (VaSig == 0.010)
                        {
                            valorT = 26.22;
                        }
                        else if (VaSig == 0.005)
                        {
                            valorT = 28.30;
                        }
                    }
                    else if (CaG - GL == 13)
                    {
                        if (VaSig == 0.995)
                        {
                            valorT = 3.57;
                        }
                        else if (VaSig == 0.990)
                        {
                            valorT = 4.11;
                        }
                        else if (VaSig == 0.975)
                        {
                            valorT = 5.01;
                        }
                        else if (VaSig == 0.950)
                        {
                            valorT = 5.89;
                        }
                        else if (VaSig == 0.500)
                        {
                            valorT = 12.34;
                        }
                        else if (VaSig == 0.050)
                        {
                            valorT = 22.36;
                        }
                        else if (VaSig == 0.25)
                        {
                            valorT = 24.74;
                        }
                        else if (VaSig == 0.010)
                        {
                            valorT = 27.69;
                        }
                        else if (VaSig == 0.005)
                        {
                            valorT = 29.82;
                        }
                    }
                    else if (CaG - GL == 14)
                    {
                        if (VaSig == 0.995)
                        {
                            valorT = 4.07;
                        }
                        else if (VaSig == 0.990)
                        {
                            valorT = 4.66;
                        }
                        else if (VaSig == 0.975)
                        {
                            valorT = 5.63;
                        }
                        else if (VaSig == 0.950)
                        {
                            valorT = 6.57;
                        }
                        else if (VaSig == 0.500)
                        {
                            valorT = 13.34;
                        }
                        else if (VaSig == 0.050)
                        {
                            valorT = 23.68;
                        }
                        else if (VaSig == 0.25)
                        {
                            valorT = 26.12;
                        }
                        else if (VaSig == 0.010)
                        {
                            valorT = 29.14;
                        }
                        else if (VaSig == 0.005)
                        {
                            valorT = 31.32;
                        }
                    }
                    else if (CaG - GL == 15)
                    {
                        if (VaSig == 0.995)
                        {
                            valorT = 4.60;
                        }
                        else if (VaSig == 0.990)
                        {
                            valorT = 5.23;
                        }
                        else if (VaSig == 0.975)
                        {
                            valorT = 6.27;
                        }
                        else if (VaSig == 0.950)
                        {
                            valorT = 7.26;
                        }
                        else if (VaSig == 0.500)
                        {
                            valorT = 14.34;
                        }
                        else if (VaSig == 0.050)
                        {
                            valorT = 25.00;
                        }
                        else if (VaSig == 0.25)
                        {
                            valorT = 27.49;
                        }
                        else if (VaSig == 0.010)
                        {
                            valorT = 30.58;
                        }
                        else if (VaSig == 0.005)
                        {
                            valorT = 32.80;
                        }
                    }
                    else if (CaG - GL == 16)
                    {
                        if (VaSig == 0.995)
                        {
                            valorT = 5.14;
                        }
                        else if (VaSig == 0.990)
                        {
                            valorT = 5.81;
                        }
                        else if (VaSig == 0.975)
                        {
                            valorT = 6.91;
                        }
                        else if (VaSig == 0.950)
                        {
                            valorT = 7.96;
                        }
                        else if (VaSig == 0.500)
                        {
                            valorT = 15.34;
                        }
                        else if (VaSig == 0.050)
                        {
                            valorT = 26.30;
                        }
                        else if (VaSig == 0.25)
                        {
                            valorT = 28.85;
                        }
                        else if (VaSig == 0.010)
                        {
                            valorT = 32.00;
                        }
                        else if (VaSig == 0.005)
                        {
                            valorT = 34.27;
                        }
                    }
                    else if (CaG - GL == 17)
                    {
                        if (VaSig == 0.995)
                        {
                            valorT = 5.70;
                        }
                        else if (VaSig == 0.990)
                        {
                            valorT = 6.41;
                        }
                        else if (VaSig == 0.975)
                        {
                            valorT = 7.56;
                        }
                        else if (VaSig == 0.950)
                        {
                            valorT = 8.67;
                        }
                        else if (VaSig == 0.500)
                        {
                            valorT = 16.34;
                        }
                        else if (VaSig == 0.050)
                        {
                            valorT = 27.59;
                        }
                        else if (VaSig == 0.25)
                        {
                            valorT = 30.19;
                        }
                        else if (VaSig == 0.010)
                        {
                            valorT = 33.41;
                        }
                        else if (VaSig == 0.005)
                        {
                            valorT = 35.72;
                        }
                    }
                    else if (CaG - GL == 18)
                    {
                        if (VaSig == 0.995)
                        {
                            valorT = 6.26;
                        }
                        else if (VaSig == 0.990)
                        {
                            valorT = 7.01;
                        }
                        else if (VaSig == 0.975)
                        {
                            valorT = 8.23;
                        }
                        else if (VaSig == 0.950)
                        {
                            valorT = 9.39;
                        }
                        else if (VaSig == 0.500)
                        {
                            valorT = 17.34;
                        }
                        else if (VaSig == 0.050)
                        {
                            valorT = 28.87;
                        }
                        else if (VaSig == 0.25)
                        {
                            valorT = 31.53;
                        }
                        else if (VaSig == 0.010)
                        {
                            valorT = 34.81;
                        }
                        else if (VaSig == 0.005)
                        {
                            valorT = 37.16;
                        }
                    }
                    else if (CaG - GL == 19)
                    {
                        if (VaSig == 0.995)
                        {
                            valorT = 6.84;
                        }
                        else if (VaSig == 0.990)
                        {
                            valorT = 7.63;
                        }
                        else if (VaSig == 0.975)
                        {
                            valorT = 8.91;
                        }
                        else if (VaSig == 0.950)
                        {
                            valorT = 10.12;
                        }
                        else if (VaSig == 0.500)
                        {
                            valorT = 18.34;
                        }
                        else if (VaSig == 0.050)
                        {
                            valorT = 30.14;
                        }
                        else if (VaSig == 0.25)
                        {
                            valorT = 32.85;
                        }
                        else if (VaSig == 0.010)
                        {
                            valorT = 36.19;
                        }
                        else if (VaSig == 0.005)
                        {
                            valorT = 38.58;
                        }
                    }
                    else if (CaG - GL == 20)
                    {
                        if (VaSig == 0.995)
                        {
                            valorT = 7.43;
                        }
                        else if (VaSig == 0.990)
                        {
                            valorT = 8.26;
                        }
                        else if (VaSig == 0.975)
                        {
                            valorT = 9.59;
                        }
                        else if (VaSig == 0.950)
                        {
                            valorT = 10.85;
                        }
                        else if (VaSig == 0.500)
                        {
                            valorT = 19.34;
                        }
                        else if (VaSig == 0.050)
                        {
                            valorT = 31.41;
                        }
                        else if (VaSig == 0.25)
                        {
                            valorT = 34.17;
                        }
                        else if (VaSig == 0.010)
                        {
                            valorT = 37.57;
                        }
                        else if (VaSig == 0.005)
                        {
                            valorT = 40.00;
                        }
                    }
                    else if (CaG - GL == 25)
                    {
                        if (VaSig == 0.995)
                        {
                            valorT = 10.52;
                        }
                        else if (VaSig == 0.990)
                        {
                            valorT = 11.52;
                        }
                        else if (VaSig == 0.975)
                        {
                            valorT = 13.12;
                        }
                        else if (VaSig == 0.950)
                        {
                            valorT = 14.61;
                        }
                        else if (VaSig == 0.500)
                        {
                            valorT = 24.34;
                        }
                        else if (VaSig == 0.050)
                        {
                            valorT = 37.65;
                        }
                        else if (VaSig == 0.25)
                        {
                            valorT = 40.65;
                        }
                        else if (VaSig == 0.010)
                        {
                            valorT = 44.31;
                        }
                        else if (VaSig == 0.005)
                        {
                            valorT = 46.93;
                        }
                    }
                    else if (CaG - GL == 30)
                    {
                        if (VaSig == 0.995)
                        {
                            valorT = 13.79;
                        }
                        else if (VaSig == 0.990)
                        {
                            valorT = 14.95;
                        }
                        else if (VaSig == 0.975)
                        {
                            valorT = 16.79;
                        }
                        else if (VaSig == 0.950)
                        {
                            valorT = 18.49;
                        }
                        else if (VaSig == 0.500)
                        {
                            valorT = 20.34;
                        }
                        else if (VaSig == 0.050)
                        {
                            valorT = 43.77;
                        }
                        else if (VaSig == 0.25)
                        {
                            valorT = 46.98;
                        }
                        else if (VaSig == 0.010)
                        {
                            valorT = 50.89;
                        }
                        else if (VaSig == 0.005)
                        {
                            valorT = 53.67;
                        }
                    }
                    else if (CaG - GL == 40)
                    {
                        if (VaSig == 0.995)
                        {
                            valorT = 20.71;
                        }
                        else if (VaSig == 0.990)
                        {
                            valorT = 22.16;
                        }
                        else if (VaSig == 0.975)
                        {
                            valorT = 24.43;
                        }
                        else if (VaSig == 0.950)
                        {
                            valorT = 26.51;
                        }
                        else if (VaSig == 0.500)
                        {
                            valorT = 39.34;
                        }
                        else if (VaSig == 0.050)
                        {
                            valorT = 55.76;
                        }
                        else if (VaSig == 0.25)
                        {
                            valorT = 59.34;
                        }
                        else if (VaSig == 0.010)
                        {
                            valorT = 63.69;
                        }
                        else if (VaSig == 0.005)
                        {
                            valorT = 66.77;
                        }
                    }
                    else if (CaG - GL == 50)
                    {
                        if (VaSig == 0.995)
                        {
                            valorT = 27.99;
                        }
                        else if (VaSig == 0.990)
                        {
                            valorT = 29.71;
                        }
                        else if (VaSig == 0.975)
                        {
                            valorT = 32.36;
                        }
                        else if (VaSig == 0.950)
                        {
                            valorT = 34.76;
                        }
                        else if (VaSig == 0.500)
                        {
                            valorT = 49.33;
                        }
                        else if (VaSig == 0.050)
                        {
                            valorT = 67.50;
                        }
                        else if (VaSig == 0.25)
                        {
                            valorT = 71.42;
                        }
                        else if (VaSig == 0.010)
                        {
                            valorT = 76.15;
                        }
                        else if (VaSig == 0.005)
                        {
                            valorT = 79.49;
                        }
                    }
                    else if (CaG - GL == 60)
                    {
                        if (VaSig == 0.995)
                        {
                            valorT = 35.53;
                        }
                        else if (VaSig == 0.990)
                        {
                            valorT = 37.48;
                        }
                        else if (VaSig == 0.975)
                        {
                            valorT = 40.48;
                        }
                        else if (VaSig == 0.950)
                        {
                            valorT = 43.19;
                        }
                        else if (VaSig == 0.500)
                        {
                            valorT = 59.33;
                        }
                        else if (VaSig == 0.050)
                        {
                            valorT = 79.08;
                        }
                        else if (VaSig == 0.25)
                        {
                            valorT = 83.30;
                        }
                        else if (VaSig == 0.010)
                        {
                            valorT = 88.38;
                        }
                        else if (VaSig == 0.005)
                        {
                            valorT = 91.95;
                        }
                    }
                    else if (CaG - GL == 70)
                    {
                        if (VaSig == 0.995)
                        {
                            valorT = 43.28;
                        }
                        else if (VaSig == 0.990)
                        {
                            valorT = 45.44;
                        }
                        else if (VaSig == 0.975)
                        {
                            valorT = 48.76;
                        }
                        else if (VaSig == 0.950)
                        {
                            valorT = 51.74;
                        }
                        else if (VaSig == 0.500)
                        {
                            valorT = 69.33;
                        }
                        else if (VaSig == 0.050)
                        {
                            valorT = 90.53;
                        }
                        else if (VaSig == 0.25)
                        {
                            valorT = 95.02;
                        }
                        else if (VaSig == 0.010)
                        {
                            valorT = 100.42;
                        }
                        else if (VaSig == 0.005)
                        {
                            valorT = 104.22;
                        }
                    }
                    else if (CaG - GL == 80)
                    {
                        if (VaSig == 0.995)
                        {
                            valorT = 51.17;
                        }
                        else if (VaSig == 0.990)
                        {
                            valorT = 53.54;
                        }
                        else if (VaSig == 0.975)
                        {
                            valorT = 57.15;
                        }
                        else if (VaSig == 0.950)
                        {
                            valorT = 60.39;
                        }
                        else if (VaSig == 0.500)
                        {
                            valorT = 79.33;
                        }
                        else if (VaSig == 0.050)
                        {
                            valorT = 101.88;
                        }
                        else if (VaSig == 0.25)
                        {
                            valorT = 106.63;
                        }
                        else if (VaSig == 0.010)
                        {
                            valorT = 112.33;
                        }
                        else if (VaSig == 0.005)
                        {
                            valorT = 116.32;
                        }
                    }
                    else if (CaG - GL == 90)
                    {
                        if (VaSig == 0.995)
                        {
                            valorT = 59.20;
                        }
                        else if (VaSig == 0.990)
                        {
                            valorT = 61.75;
                        }
                        else if (VaSig == 0.975)
                        {
                            valorT = 65.65;
                        }
                        else if (VaSig == 0.950)
                        {
                            valorT = 69.13;
                        }
                        else if (VaSig == 0.500)
                        {
                            valorT = 89.33;
                        }
                        else if (VaSig == 0.050)
                        {
                            valorT = 113.14;
                        }
                        else if (VaSig == 0.25)
                        {
                            valorT = 118.14;
                        }
                        else if (VaSig == 0.010)
                        {
                            valorT = 124.12;
                        }
                        else if (VaSig == 0.005)
                        {
                            valorT = 128.30;
                        }
                    }
                    else if (CaG - GL == 100)
                    {
                        if (VaSig == 0.995)
                        {
                            valorT = 67.33;
                        }
                        else if (VaSig == 0.990)
                        {
                            valorT = 70.06;
                        }
                        else if (VaSig == 0.975)
                        {
                            valorT = 74.22;
                        }
                        else if (VaSig == 0.950)
                        {
                            valorT = 77.93;
                        }
                        else if (VaSig == 0.500)
                        {
                            valorT = 99.33;
                        }
                        else if (VaSig == 0.050)
                        {
                            valorT = 124.34;
                        }
                        else if (VaSig == 0.25)
                        {
                            valorT = 129.56;
                        }
                        else if (VaSig == 0.010)
                        {
                            valorT = 135.81;
                        }
                        else if (VaSig == 0.005)
                        {
                            valorT = 140.17;
                        }
                    }
                }
                R2.Text = ValorCA.ToString();
                R1.Text = valorT.ToString();
                if (ValorCA <= valorT)
                {
                    txt = "SI Estan distribuidos uniformemente.";
                    R3.Text = txt;
                }
                else
                {
                    txt = "NO estan distribuidos uniformemente.";
                    R3.Text = txt;
                }

            }

        
        }

        

    }   
}
