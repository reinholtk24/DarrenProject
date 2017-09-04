using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DrawPointsFromCSV
{
    public partial class Form1 : Form
    {
        Graphics drawArea;
        List<int> points= new List<int>(); 

        public Form1()
        {
            InitializeComponent();
            drawArea = drawingArea.CreateGraphics();
            getPoints(); 
        }


        public void getPoints() // Reads in a txt file or csv file (Change file path in stream reader line 33), Then it converts each number to an int 
                                // and adds the number to a list. The list of points called -> points, is later used to draw lines. 
        {

            int counter = 0;
            string line;

            // Read the file and display it line by line.
            System.IO.StreamReader file = new System.IO.StreamReader(@"c:\Users\Gon Freecs\points.txt");
            while ((line = file.ReadLine()) != null)
            {
                line.Trim(); 
                string[] lines = line.Split(',');

                int max = lines.Length;

                for (int i = 0; i < max; i++ )
                {
                    int tempPoint; 
                    bool result = Int32.TryParse(lines[i], out tempPoint);
                    
                    if(result)
                    {
                        points.Add(tempPoint);
                    }

                }
            }

            file.Close();
            
        }
        private void drawButton_Click(object sender, EventArgs e)
        {
            Pen blackPen = new Pen(Color.Black, 3);

            for(int j = 0; j < points.Count; j++)
            {
                if(j + 3 == points.Count)
                {
                    drawArea.DrawLine(blackPen, points.ElementAt(j-1), points.ElementAt(j), points.ElementAt(j + 1), points.ElementAt(j +2)); 

                    break; 
                }
                else
                {
                    drawArea.DrawLine(blackPen, points.ElementAt(j), points.ElementAt(j + 1), points.ElementAt(j + 2), points.ElementAt(j + 3));
                }

            }

        }
    }
}
