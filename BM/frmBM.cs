using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing;
using System.Windows.Forms;

namespace BM
{
    public partial class frmBM : Form
    {
        //bool[,] bombasBoolGrid;
        Mina[,] minas;
        List<Button> botones;

        Color[] colores = new Color[] { Color.Black, Color.Blue, Color.Green, Color.Red, Color.Purple, Color.Black, Color.Gray, Color.Maroon, Color.Turquoise };

        // Minas visibles
        bool pruebas = false;

        // Control del juego
        int bombasRestantes;
        int alto, ancho, bombasCantidadInicial;
        //int lado = 10;
        int casillasRestantes;

        Stopwatch temp;

        public frmBM()
        {
            InitializeComponent();

            botones = new List<Button>();
            temp = new Stopwatch();

            // Valores por defecto
            alto = ancho = 10;
            bombasCantidadInicial = 10;
        }

        private void frmBM_Load(object sender, EventArgs e)
        {
            IniciarInterfaz();
        }

        private void AsignarBombas()
        {
            Random rand = new Random();
            //bombasBoolGrid = new bool[alto, ancho];
            minas = new Mina[alto, ancho];

            int pendientes = bombasCantidadInicial;

            bombasRestantes = pendientes;
            tsmRestantes.Text = "Minas restantes: " + bombasRestantes;
            casillasRestantes = alto * ancho - bombasRestantes;

            for (int i = 0; i < alto; i++)
                for (int j = 0; j < ancho; j++)
                    minas[i, j] = new Mina(i, j);

            while (pendientes > 0)
            {
                int x = rand.Next(0, alto);
                int y = rand.Next(0, ancho);

                if (!minas[x, y].esBomba)
                {
                    minas[x, y].esBomba = true;
                    pendientes--;
                }
            }
        }

        private void IniciarInterfaz()
        {
            AsignarBombas();

            for (int i = 0; i < alto; i++)
            {
                for (int j = 0; j < ancho; j++)
                {
                    bool esBomba = minas[i, j].esBomba;

                    // Generamos el boton
                    Button btn = new Button();
                    btn.BackColor = Color.DarkGray;
                    if (pruebas && esBomba) btn.BackColor = Color.Black;
                    btn.Font = new Font(btn.Font.Name, btn.Font.Size, FontStyle.Bold);
                    btn.FlatStyle = FlatStyle.Flat;
                    btn.Dock = DockStyle.Fill;
                    btn.Margin = new Padding(1);
                    //btn.Click += new EventHandler(btn_Click);
                    btn.MouseDown += new MouseEventHandler(btn_MouseDown);
                    botones.Add(btn);

                    tlpMain.Controls.Add(btn, i, j);

                    // Objeto
                    //Mina m = new Mina(esBomba, i, j, btn);
                    //minas[i, j] = m;

                    minas[i, j].btn = btn;
                    btn.Tag = minas[i, j];
                }
            }

            AutoStart();

            temp = new Stopwatch();
            temp.Start();
        }

        private void AutoStart()
        {
            for (int i = botones.Count / 3; i < botones.Count - 1; i++)
            //foreach (Mina m in minas)
            {
                Mina m = (Mina)botones[i].Tag;

                if (Alrededor(m, true) == 0)
                {
                    Alrededor(m);
                    break;
                }
            }
        }

        private void btn_MouseDown(Object sender, MouseEventArgs e)
        {
            Button btn = (Button)sender;
            Mina m = (Mina)btn.Tag;

            if (e.Button == MouseButtons.Left)
            {
                if (!m.protegida) Apuntar(m);
            }
            if (e.Button == MouseButtons.Right)
            {
                Proteger(m);
            }
        }

        private void Apuntar(Mina m)
        {
            if (m.esBomba)
            {
                m.btn.Text = "X";
                m.btn.BackColor = Color.LightCoral;

                temp.Stop();
                string t = temp.Elapsed.ToString(@"m\:ss\.fff");

                MessageBox.Show("BOOOOM\n" + t);
                if (!pruebas) Reset();
            }
            else
            {
                Alrededor(m);
                if (CasillasRestantes() < 1)
                {
                    temp.Stop();
                    string t = temp.Elapsed.ToString(@"m\:ss\.fff");

                    MessageBox.Show("Has ganado!\n" + t);
                    if (!pruebas) Reset();
                }
            }
        }

        private void Proteger(Mina m)
        {
            if (!m.pulsada)
            {
                if (m.protegida)
                {
                    m.btn.Text = "";
                    m.btn.BackColor = Color.DarkGray;
                    if (pruebas && m.esBomba) m.btn.BackColor = Color.Black;
                    bombasRestantes++;
                }
                else
                {
                    m.btn.Text = "P";
                    m.btn.BackColor = Color.LightGreen;
                    bombasRestantes--;
                }

                m.protegida = !m.protegida;

                tsmRestantes.Text = "Minas restantes: " + bombasRestantes;
            }
        }

        private int Alrededor(Mina m, bool readOnly = false)
        {
            int res = 0;

            List<Mina> adjacentes = new List<Mina>();
            // Cruz
            try { adjacentes.Add(minas[m.x, m.y - 1]); } catch { }
            try { adjacentes.Add(minas[m.x + 1, m.y]); } catch { }
            try { adjacentes.Add(minas[m.x, m.y + 1]); } catch { }
            try { adjacentes.Add(minas[m.x - 1, m.y]); } catch { }
            // X
            try { adjacentes.Add(minas[m.x - 1, m.y - 1]); } catch { }
            try { adjacentes.Add(minas[m.x - 1, m.y + 1]); } catch { }
            try { adjacentes.Add(minas[m.x + 1, m.y - 1]); } catch { }
            try { adjacentes.Add(minas[m.x + 1, m.y + 1]); } catch { }

            /*
            int xMax = m.x >= alto - 1 ? alto - 2 : m.x + 1;
            int yMax = m.y >= ancho - 1 ? ancho - 2 : m.y + 1;
            int xMin = m.x < 2 ? 0 : m.x - 1;
            int yMin = m.y < 2 ? 0 : m.y - 1;

            
            for (int i = xMin; i <= xMax; i++)
            {
                for (int j = yMin; j <= yMax; j++)
                {
                    if (minas[i, j].esBomba)
                        res++;
                }
            }*/

            foreach (Mina aux in adjacentes) if (aux.esBomba) res++;

            if (readOnly) return res;

            casillasRestantes--;
            if (!m.esBomba) m.pulsada = true;

            m.btn.Text = res.ToString();
            m.btn.ForeColor = colores[res];

            if (pruebas) this.Text = "Restantes contando al momento: " + CasillasRestantes() + " - " + casillasRestantes.ToString() + " de 1 en 1 ";

            if (res == 0)
            {
                foreach (Mina aux in adjacentes) if (!aux.pulsada && !aux.esBomba) Alrededor(aux);

                /*
                for (int i = xMin; i <= xMax; i++)
                    for (int j = yMin; j <= yMax; j++)
                        if (i == m.x && j == m.y)
                        {
                            //MessageBox.Show("Si mismo");
                        }
                        else
                        {
                            Mina aux = minas[i, j];
                            if (!aux.pulsada && !aux.esBomba) Alrededor(minas[i, j]);
                        }
                */
            }

            return res;
        }

        private int CasillasRestantes()
        {
            int restantes = alto * ancho - bombasCantidadInicial;
            foreach (Button btn in botones)
            {
                Mina m = (Mina)btn.Tag;
                if (m.pulsada) restantes--;
            }
            return restantes;
        }

        private void tsmNueva_Click(object sender, EventArgs e)
        {
            frmMenu frm = new frmMenu();
            frm.ShowDialog();

            if (frm.nueva)
            {
                alto = frm.alto;
                ancho = frm.ancho;
                bombasCantidadInicial = frm.bombasCantidadInicial;

                //bombasBoolGrid = new bool[alto, ancho];

                tlpMain.RowCount = ancho;
                tlpMain.ColumnCount = alto;

                RowStyle rsDef = tlpMain.RowStyles[0];
                tlpMain.RowStyles.Clear();
                for (int i = 0; i < tlpMain.RowCount; i++)
                {
                    RowStyle rsAux = new RowStyle(rsDef.SizeType, rsDef.Height);
                    tlpMain.RowStyles.Add(rsAux);
                }

                ColumnStyle csDef = tlpMain.ColumnStyles[0];
                tlpMain.ColumnStyles.Clear();
                for (int i = 0; i < tlpMain.RowCount; i++)
                {
                    ColumnStyle csAux = new ColumnStyle(csDef.SizeType, csDef.Width);
                    tlpMain.ColumnStyles.Add(csAux);
                }

                //MessageBox.Show("Se crearia una partida con alto=" + alto + ", ancho=" + ancho + ", minas=" + bombasCantidadInicial);

                Reset();
            }
        }

        private void pruebasToolStripMenuItem_Click(object sender, EventArgs e)
        {
            pruebas = !pruebas;
            if (pruebas) pruebasToolStripMenuItem.ForeColor = Color.Red;
            else pruebasToolStripMenuItem.ForeColor = Color.Black;
        }

        private void Reset()
        {
            tlpMain.Visible = false;

            VaciarBotones();

            IniciarInterfaz();

            tlpMain.Visible = true;
        }

        private void VaciarBotones()
        {
            // Elimina los botones de la cuadricula
            foreach (Button btn in botones) btn.Visible = false;
            botones.Clear();
        }
    }

    public class Mina
    {
        public bool esBomba, pulsada, protegida;
        public int x, y;
        public Button btn;

        public Mina(int x, int y)
        {
            this.x = x;
            this.y = y;

            pulsada = false;
            protegida = false;
        }
    }
}
