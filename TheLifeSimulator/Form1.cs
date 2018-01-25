using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Diagnostics;
using System.Threading;

namespace TheLifeSimulator
{
    public partial class mainMenu : Form
    {
        int scene = 1;
        int perf = 0;
        int hunger = 120;
        int entertain = 120;
        int washroom = 120;
        int hygiene = 120;
        Boolean leftArrowDown, downArrowDown, rightArrowDown, upArrowDown;
        int drawX = 728; //728
        int drawY = 200; //340
        SolidBrush mainCharacterOne = new SolidBrush(Color.Tan);
        int bankSavings;
        Graphics onScreen, offScreen;
        Bitmap bm;

        Rectangle mainCharacter;
        Rectangle tubOne = new Rectangle(17, 290, 60, 5);
        Rectangle tubTwo = new Rectangle(72, 290, 5, 100);
        Rectangle tub = new Rectangle(17, 290, 60, 100);
        ////interactiveObjects(17, 290, 60, 100);
        Rectangle fridgeOne = new Rectangle(708, 340, 50, 50);
        Rectangle fridgeTwo = new Rectangle(708, 330, 50, 10);
        Rectangle doorAction;
        Rectangle toiletTwoCover1 = new Rectangle(207, 350, 5, 20);
        Rectangle toiletTwoCover2 = new Rectangle(207, 375, 50, 5);
        Rectangle deskCover1;
        Rectangle deskCover2;
        Rectangle deskCover3;
       

        public mainMenu()
        {
            InitializeComponent();

            bankmoneyLabel.Visible = false;
            bankLabel.Visible = false;
            workperfLabel.Visible = false;
            hungerlabel.Visible = false;
            hygienelabel.Visible = false;
            loolabel.Visible = false;
            entertainmentlabel.Visible = false;
            imageO.Visible = false;
            imageT.Visible = false;
            titleLabel.Visible = true;
            startLabel.Visible = true;
            howtoplaylabel.Visible = true;
            instructionlabel.Visible = true;

            titleLabel.Text = "Game Menu";
            startLabel.Text = "Start Gameplay";
            startLabel.Location = new Point(100, 120);
            howtoplaylabel.Location = new Point(100, 200);
            howtoplaylabel.Text = "How To Play";
            instructionlabel.Text = "Press Y to start, Press U for how to play";
            //startLabel.Location = new Point(100, 100);
            //startLabel.Text = "H";

            onScreen = this.CreateGraphics();
            bm = new Bitmap(this.Width, this.Height);
            offScreen = Graphics.FromImage(bm);
        }

        Pen draw = new Pen(Color.Black, 3);
        SolidBrush fill = new SolidBrush(Color.White);

        public void hungerBar(int needsX, int needsY)
        {
            //creating method to create the needsbar
            Graphics Draw = instructionlabel.CreateGraphics();
            Pen drawNeeds = new Pen(Color.Black, 3);
            SolidBrush fillNeeds = new SolidBrush(Color.LightGreen);
            Draw.DrawRectangle(drawNeeds, needsX, needsY, 120, 20);
            Draw.FillRectangle(fillNeeds, needsX, needsY, hunger, 20);

            if (scene == 10 || scene == 11 || scene == 12 || scene == 13)
            {
                hunger--;

                if (fridgeOne.IntersectsWith(mainCharacter))
                {
                    if (hunger < 120)
                    {
                        hunger = hunger + 5;
                    }
                }
                if (fridgeTwo.IntersectsWith(mainCharacter))
                {
                    if (hunger < 120)
                    {
                        hunger = hunger + 5;
                    }
                }
            }

        }
        //        Thread.Sleep(5);

        public void entertainmentBar(int needsX, int needsY)
        {
            //creating method to create the needsbar
            Graphics Draw = instructionlabel.CreateGraphics();
            Pen drawNeeds = new Pen(Color.Black, 3);
            SolidBrush fillNeeds = new SolidBrush(Color.LightGreen);
            Draw.DrawRectangle(drawNeeds, needsX, needsY, 120, 20);
            Draw.FillRectangle(fillNeeds, needsX, needsY, entertain, 20);
            //if (scene == 10 || scene == 11 || scene == 12 || scene == 13)
            //{
            //    while (entertain == 120)
            //    {
            //        entertain--;
            //    }
            //    if (doorAction.IntersectsWith(mainCharacter))
            //    {
            //        entertain = entertain + 20;
            //    }
            //}
        }
        
        public void loo(int needsX, int needsY)
        {
            //creating method to create the needsbar
            Graphics Draw = instructionlabel.CreateGraphics();
            Pen drawNeeds = new Pen(Color.Black, 3);
            SolidBrush fillNeeds = new SolidBrush(Color.LightGreen);
            Draw.DrawRectangle(drawNeeds, needsX, needsY, 120, 20);
            Draw.FillRectangle(fillNeeds, needsX, needsY, washroom, 20);
            if (scene == 10 || scene == 11 || scene == 12 || scene == 13)
            {
                washroom--;
                if (toiletTwoCover1.IntersectsWith(mainCharacter))
                {
                    //drawX = 222;
                    //drawY = 355;
                    if (washroom < 100)
                    {
                        washroom = 30 + washroom;
                    }

                }
                if (toiletTwoCover2.IntersectsWith(mainCharacter))
                {
                    //drawX = 222;
                    //drawY = 355;
                    if (washroom < 100)
                    {
                        washroom = 30 + washroom;
                    }
                   
                }
                
            }
        }
        public void hygieneBar(int needsX, int needsY)
        {
            //creating method to create the needsbar
            Graphics Draw = instructionlabel.CreateGraphics();
            Pen drawNeeds = new Pen(Color.Black, 3);
            SolidBrush fillNeeds = new SolidBrush(Color.LightGreen);
            Draw.DrawRectangle(drawNeeds, needsX, needsY, 120, 20);
            Draw.FillRectangle(fillNeeds, needsX, needsY, hygiene, 20);
            if (scene == 10 || scene == 11 || scene == 12 || scene == 13)
            {
                hygiene--;
                if (tub.IntersectsWith(mainCharacter))
                {
                    if (hygiene < 120)
                    {
                        hygiene = 10 + hygiene;
                    }

                }

                
            }
        }
        public void workperfBar(int workX, int workY)
        {
            //creating method to create the needsbar
            Graphics Draw = instructionlabel.CreateGraphics();
            Pen drawNeeds = new Pen(Color.Black, 3);
            SolidBrush fillNeeds = new SolidBrush(Color.Yellow);
            Draw.DrawRectangle(drawNeeds, workX, workY, 120, 20);
            Draw.FillRectangle(fillNeeds, workX, workY, perf, 20);
            if (deskCover1.IntersectsWith(mainCharacter))
            {
                if (perf < 120)
                {
                    perf++;
                }
                if (perf == 10)
                {
                    bankSavings = 20;
                    bankmoneyLabel.Text = bankSavings + "";
                }
                if (perf == 20)
                {
                    bankSavings = 40;
                    bankmoneyLabel.Text = "" + bankSavings;
                }
                if (perf == 40)
                {
                    bankSavings = 100;
                    bankmoneyLabel.Text = "" + bankSavings;
                }
                if (perf == 60)
                {
                    bankSavings = 250;
                    bankmoneyLabel.Text = "" + bankSavings;
                }
                if (perf > 60)
                {
                    bankSavings = bankSavings + 60;
                    bankmoneyLabel.Text = "" + bankSavings;
                }
                //e.Graphics.DrawRectangle(draw, 708, 55, 20, 20);

            }
            if (deskCover2.IntersectsWith(mainCharacter))
            {
                if (perf < 120)
                {
                    perf++;
                }
                if (perf == 10)
                {
                    bankSavings = 20;
                    bankmoneyLabel.Text = bankSavings + "";
                }
                if (perf == 20)
                {
                    bankSavings = 40;
                    bankmoneyLabel.Text = "" + bankSavings;
                }
                if (perf == 40)
                {
                    bankSavings = 100;
                    bankmoneyLabel.Text = "" + bankSavings;
                }
                if (perf == 60)
                {
                    bankSavings = 250;
                    bankmoneyLabel.Text = "" + bankSavings;
                }
                if (perf > 60)
                {
                    bankSavings = bankSavings + 60;
                    bankmoneyLabel.Text = "" + bankSavings;
                }

            }
            if (deskCover3.IntersectsWith(mainCharacter))
            {
                if (perf < 120)
                {
                    perf++;

                }
                if (perf == 10)
                {
                    bankSavings = 20;
                    bankmoneyLabel.Text = bankSavings + "";
                }
                if (perf == 20)
                {
                    bankSavings = 40;
                    bankmoneyLabel.Text = "" + bankSavings;
                }
                if (perf == 40)
                {
                    bankSavings = 100;
                    bankmoneyLabel.Text = "" + bankSavings;
                }
                if (perf == 60)
                {
                    bankSavings = 250;
                    bankmoneyLabel.Text = "" + bankSavings;
                }
                if (perf > 60)
                {
                    bankSavings = bankSavings + 60;
                    bankmoneyLabel.Text = "" + bankSavings;
                }
            }
            
        }


        //private void nameinput_KeyDown(object sender, KeyEventArgs e)
        //{
        //    Graphics name = instructionlabel.CreateGraphics();
        //    Font drawFont = new Font("Arial", 16, FontStyle.Bold);
        //    SolidBrush drawBrush = new SolidBrush(Color.Red);

        //    username = nameinput.Text;
        //    if (e.KeyCode == Keys.Enter)
        //    {
        //        if (scene == 6)
        //        {
        //            scene = 10;
        //            this.BackColor = Color.AntiqueWhite;


        //            bankLabel.Location = new Point(400, 420);
        //            bankLabel.BackColor = Color.Pink;
        //            bankLabel.Text = "Bank";
        //            bankLabel.Visible = true;
        //            bankmoneyLabel.BackColor = Color.White;
        //            bankmoneyLabel.Location = new Point(530, 410);
        //            bankmoneyLabel.Visible = true;
        //            workperfLabel.Location = new Point(400, 440);
        //            workperfLabel.BackColor = Color.Pink;
        //            workperfLabel.Text = "Work Performance";
        //            workperfLabel.Visible = true;

        //            workperfBar(520, 40);

        //            hungerlabel.BackColor = Color.Pink;
        //            entertainmentlabel.BackColor = Color.Pink;
        //            loolabel.BackColor = Color.Pink;
        //            hygienelabel.BackColor = Color.Pink;
        //            hungerlabel.Location = new Point(120, 420);
        //            entertainmentlabel.Location = new Point(120, 440);
        //            loolabel.Location = new Point(120, 460);
        //            hygienelabel.Location = new Point(120, 480);
        //            hungerlabel.Size = new Size(120, 20);
        //            entertainmentlabel.Size = new Size(120, 20);
        //            loolabel.Size = new Size(120, 20);
        //            hygienelabel.Size = new Size(120, 20);
        //            hungerlabel.Visible = true;
        //            hygienelabel.Visible = true;
        //            loolabel.Visible = true;
        //            entertainmentlabel.Visible = true;
        //            hungerlabel.Text = "Hunger";
        //            entertainmentlabel.Text = "Entertainment";
        //            loolabel.Text = "Loo";
        //            hygienelabel.Text = "Hygiene";

        //            hungerBar(250, 10);
        //            entertainmentBar(250, 40);
        //            loo(250, 70);
        //            hygieneBar(250, 100);

        //            imageO.Visible = true;///
        //            imageT.Visible = false;///
        //            titleLabel.Visible = false;///
        //            startLabel.Location = new Point(274, 400);
        //            startLabel.Visible = true;///
        //            startLabel.Text = username;
        //            howtoplaylabel.Visible = false;///
        //            instructionlabel.Visible = true;///
        //            nameinput.Visible = false;///

        //            mainCharacter = new Rectangle(drawX, drawY, 20, 20);

        //            if (drawX < 14) { drawX = 14; }
        //            if (drawY < 7) { drawY = 7; }
        //            if (drawX > 735) { drawX = 735; }
        //            if (drawY > 367) { drawY = 367; }

        //            this.Focus();
        //        }
        //        else if (scene == 7)
        //        {
        //            scene = 11;
        //            this.BackColor = Color.AntiqueWhite;


        //            bankLabel.Location = new Point(400, 420);
        //            bankLabel.BackColor = Color.LightBlue;
        //            bankLabel.Text = "Bank";
        //            bankLabel.Visible = true;
        //            bankmoneyLabel.BackColor = Color.White;
        //            bankmoneyLabel.Location = new Point(530, 410);
        //            bankmoneyLabel.Visible = true;
        //            workperfLabel.Location = new Point(400, 440);
        //            workperfLabel.BackColor = Color.LightBlue;
        //            workperfLabel.Text = "Work Performance";
        //            workperfLabel.Visible = true;

        //            workperfBar(520, 40);

        //            hungerlabel.BackColor = Color.LightBlue;
        //            entertainmentlabel.BackColor = Color.LightBlue;
        //            loolabel.BackColor = Color.LightBlue;
        //            hygienelabel.BackColor = Color.LightBlue;
        //            hungerlabel.Location = new Point(120, 420);
        //            entertainmentlabel.Location = new Point(120, 440);
        //            loolabel.Location = new Point(120, 460);
        //            hygienelabel.Location = new Point(120, 480);
        //            hungerlabel.Size = new Size(120, 20);
        //            entertainmentlabel.Size = new Size(120, 20);
        //            loolabel.Size = new Size(120, 20);
        //            hygienelabel.Size = new Size(120, 20);
        //            hungerlabel.Visible = true;
        //            hygienelabel.Visible = true;
        //            loolabel.Visible = true;
        //            entertainmentlabel.Visible = true;
        //            hungerlabel.Text = "Hunger";
        //            entertainmentlabel.Text = "Entertainment";
        //            loolabel.Text = "Loo";
        //            hygienelabel.Text = "Hygiene";

        //            hungerBar(250, 10);
        //            entertainmentBar(250, 40);
        //            loo(250, 70);
        //            hygieneBar(250, 100);

        //            imageO.Visible = true;///
        //            imageT.Visible = false;///
        //            titleLabel.Visible = false;///
        //            startLabel.Location = new Point(274, 400);
        //            startLabel.Visible = true;///
        //            startLabel.Text = username;
        //            howtoplaylabel.Visible = false;///
        //            instructionlabel.Visible = true;///
        //            nameinput.Visible = false;///

        //            mainCharacter = new Rectangle(drawX, drawY, 20, 20);

        //            if (drawX < 14) { drawX = 14; }
        //            if (drawY < 7) { drawY = 7; }
        //            if (drawX > 735) { drawX = 735; }
        //            if (drawY > 367) { drawY = 367; }

        //            this.Focus();
        //        }
        //        else if (scene == 8)
        //        {
        //            scene = 12;
        //            this.BackColor = Color.AntiqueWhite;


        //            bankLabel.Location = new Point(400, 420);
        //            bankLabel.BackColor = Color.Pink;
        //            bankLabel.Text = "Bank";
        //            bankLabel.Visible = true;
        //            bankmoneyLabel.BackColor = Color.White;
        //            bankmoneyLabel.Location = new Point(530, 410);
        //            bankmoneyLabel.Visible = true;
        //            workperfLabel.Location = new Point(400, 440);
        //            workperfLabel.BackColor = Color.Pink;
        //            workperfLabel.Text = "Work Performance";
        //            workperfLabel.Visible = true;

        //            workperfBar(520, 40);

        //            hungerlabel.BackColor = Color.Pink;
        //            entertainmentlabel.BackColor = Color.Pink;
        //            loolabel.BackColor = Color.Pink;
        //            hygienelabel.BackColor = Color.Pink;
        //            hungerlabel.Location = new Point(120, 420);
        //            entertainmentlabel.Location = new Point(120, 440);
        //            loolabel.Location = new Point(120, 460);
        //            hygienelabel.Location = new Point(120, 480);
        //            hungerlabel.Size = new Size(120, 20);
        //            entertainmentlabel.Size = new Size(120, 20);
        //            loolabel.Size = new Size(120, 20);
        //            hygienelabel.Size = new Size(120, 20);
        //            hungerlabel.Visible = true;
        //            hygienelabel.Visible = true;
        //            loolabel.Visible = true;
        //            entertainmentlabel.Visible = true;
        //            hungerlabel.Text = "Hunger";
        //            entertainmentlabel.Text = "Entertainment";
        //            loolabel.Text = "Loo";
        //            hygienelabel.Text = "Hygiene";

        //            hungerBar(250, 10);
        //            entertainmentBar(250, 40);
        //            loo(250, 70);
        //            hygieneBar(250, 100);

        //            imageO.Visible = true;///
        //            imageT.Visible = false;///
        //            titleLabel.Visible = false;///
        //            startLabel.Location = new Point(274, 400);
        //            startLabel.Visible = true;///
        //            startLabel.Text = username;
        //            howtoplaylabel.Visible = false;///
        //            instructionlabel.Visible = true;///
        //            nameinput.Visible = false;///

        //            mainCharacter = new Rectangle(drawX, drawY, 20, 20);

        //            if (drawX < 14) { drawX = 14; }
        //            if (drawY < 7) { drawY = 7; }
        //            if (drawX > 735) { drawX = 735; }
        //            if (drawY > 367) { drawY = 367; }

        //            this.Focus();
        //        }
        //        else if (scene == 9)
        //        {
        //            scene = 13;
        //            this.BackColor = Color.AntiqueWhite;


        //            bankLabel.Location = new Point(400, 420);
        //            bankLabel.BackColor = Color.LightBlue;
        //            bankLabel.Text = "Bank";
        //            bankLabel.Visible = true;
        //            bankmoneyLabel.BackColor = Color.White;
        //            bankmoneyLabel.Location = new Point(530, 410);
        //            bankmoneyLabel.Visible = true;
        //            workperfLabel.Location = new Point(400, 440);
        //            workperfLabel.BackColor = Color.LightBlue;
        //            workperfLabel.Text = "Work Performance";
        //            workperfLabel.Visible = true;

        //            workperfBar(520, 40);

        //            hungerlabel.BackColor = Color.LightBlue;
        //            entertainmentlabel.BackColor = Color.LightBlue;
        //            loolabel.BackColor = Color.LightBlue;
        //            hygienelabel.BackColor = Color.LightBlue;
        //            hungerlabel.Location = new Point(120, 420);
        //            entertainmentlabel.Location = new Point(120, 440);
        //            loolabel.Location = new Point(120, 460);
        //            hygienelabel.Location = new Point(120, 480);
        //            hungerlabel.Size = new Size(120, 20);
        //            entertainmentlabel.Size = new Size(120, 20);
        //            loolabel.Size = new Size(120, 20);
        //            hygienelabel.Size = new Size(120, 20);
        //            hungerlabel.Visible = true;
        //            hygienelabel.Visible = true;
        //            loolabel.Visible = true;
        //            entertainmentlabel.Visible = true;
        //            hungerlabel.Text = "Hunger";
        //            entertainmentlabel.Text = "Entertainment";
        //            loolabel.Text = "Loo";
        //            hygienelabel.Text = "Hygiene";

        //            hungerBar(250, 10);
        //            entertainmentBar(250, 40);
        //            loo(250, 70);
        //            hygieneBar(250, 100);

        //            imageO.Visible = true;///
        //            imageT.Visible = false;///
        //            titleLabel.Visible = false;///
        //            startLabel.Location = new Point(274, 400);
        //            startLabel.Visible = true;///
        //            startLabel.Text = username;
        //            howtoplaylabel.Visible = false;///
        //            instructionlabel.Visible = true;///
        //            nameinput.Visible = false;///

        //            mainCharacter = new Rectangle(drawX, drawY, 20, 20);

        //            if (drawX < 14) { drawX = 14; }
        //            if (drawY < 7) { drawY = 7; }
        //            if (drawX > 735) { drawX = 735; }
        //            if (drawY > 367) { drawY = 367; }

        //            this.Focus();
        //        }
        //    }
        //    name.DrawString(username, drawFont, drawBrush, 50, 40);
        //    Refresh();
        //}

        private void mainMenu_Paint(object sender, PaintEventArgs e)
        {
            if (scene == 10)
            {
                Pen draw = new Pen(Color.Black, 3);
                SolidBrush fill = new SolidBrush(Color.Black);
                e.Graphics.DrawRectangle(draw, 0, 0, 12, 390);
                e.Graphics.FillRectangle(fill, 0, 0, 12, 390);
                e.Graphics.DrawRectangle(draw, 0, 0, 1044, 5);
                e.Graphics.FillRectangle(fill, 0, 0, 1044, 5);

                e.Graphics.DrawRectangle(draw, 758, 0, 12, 390);
                e.Graphics.FillRectangle(fill, 758, 0, 12, 390);
                e.Graphics.DrawRectangle(draw, 0, 390, 1044, 8);
                e.Graphics.FillRectangle(fill, 0, 390, 1044, 8);

                //  onScreen.DrawImage(bm, 0, 0);
                //  offScreen.Clear(Color.Black);

                //drawhouse
                //Room 1

                fill = new SolidBrush(Color.SaddleBrown);
                e.Graphics.DrawRectangle(draw, 32, 5, 30, 40);
                e.Graphics.FillRectangle(fill, 32, 5, 30, 40);
                e.Graphics.DrawRectangle(draw, 212, 5, 30, 40);
                e.Graphics.FillRectangle(fill, 212, 5, 30, 40);
                fill = new SolidBrush(Color.SaddleBrown);
                e.Graphics.DrawRectangle(draw, 47, 185, 180, 40);
                e.Graphics.FillRectangle(fill, 47, 185, 180, 40);
                fill = new SolidBrush(Color.Beige);
                e.Graphics.DrawRectangle(draw, 82, 15, 50, 20);
                e.Graphics.FillRectangle(fill, 82, 15, 50, 20);
                e.Graphics.DrawRectangle(draw, 142, 15, 50, 20);
                e.Graphics.FillRectangle(fill, 142, 15, 50, 20);

                //interactiveObjects(62, 45, 150, 120);//design/patterns needeed
                fill = new SolidBrush(Color.Coral);
                e.Graphics.FillRectangle(fill, 62, 45, 150, 120);
                e.Graphics.DrawRectangle(draw, 62, 45, 150, 120);

                //interactiveObjects(62, 45, 150, 10);//Need to be colored
                fill = new SolidBrush(Color.LightBlue);
                e.Graphics.FillRectangle(fill, 62, 45, 150, 10);
                e.Graphics.DrawRectangle(draw, 62, 45, 150, 10);

                //interactiveObjects(62, 55, 150, 80);
                fill = new SolidBrush(Color.Coral);
                e.Graphics.FillRectangle(fill, 62, 55, 150, 80);
                e.Graphics.DrawRectangle(draw, 62, 55, 150, 80);
                //Room 2
                //interactiveObjects(17, 290, 60, 100);
                fill = new SolidBrush(Color.White);
                e.Graphics.FillRectangle(fill, 17, 290, 60, 100);
                e.Graphics.DrawRectangle(draw, 17, 290, 60, 100);

                fill = new SolidBrush(Color.LightGray);
                e.Graphics.FillRectangle(fill, 22, 305, 50, 70);
                e.Graphics.DrawRectangle(draw, 22, 305, 50, 70);
                fill = new SolidBrush(Color.White);
                e.Graphics.FillRectangle(fill, 202, 230, 60, 40);
                e.Graphics.DrawRectangle(draw, 202, 230, 60, 40);
                fill = new SolidBrush(Color.LightGray);
                e.Graphics.FillRectangle(fill, 207, 245, 50, 20);
                e.Graphics.DrawRectangle(draw, 207, 245, 50, 20);

                //interactiveObjects(207, 350, 50, 30);
                fill = new SolidBrush(Color.White);
                e.Graphics.FillRectangle(fill, 207, 350, 50, 30);
                e.Graphics.DrawRectangle(draw, 207, 350, 50, 30);

                //interactiveObjects(202, 380, 60, 10);
                fill = new SolidBrush(Color.White);
                e.Graphics.FillRectangle(fill, 202, 380, 60, 10);
                e.Graphics.DrawRectangle(draw, 202, 380, 60, 10);

                fill = new SolidBrush(Color.LightGray);
                e.Graphics.FillRectangle(fill, 212, 360, 40, 20);
                e.Graphics.DrawRectangle(draw, 212, 360, 40, 20);
                fill = new SolidBrush(Color.White);
                e.Graphics.FillRectangle(fill, 230, 240, 4, 8);
                e.Graphics.DrawRectangle(draw, 230, 240, 4, 8);
                e.Graphics.FillRectangle(fill, 45, 300, 4, 8);
                e.Graphics.DrawRectangle(draw, 45, 300, 4, 8);
                e.Graphics.DrawEllipse(draw, 207, 240, 4, 4);
                e.Graphics.DrawEllipse(draw, 253, 240, 4, 4);
                e.Graphics.DrawEllipse(draw, 22, 300, 4, 4);
                e.Graphics.DrawEllipse(draw, 68, 300, 4, 4);
                //Room 3
                fill = new SolidBrush(Color.Linen);
                e.Graphics.FillRectangle(fill, 308, 340, 50, 50);
                e.Graphics.FillRectangle(fill, 358, 340, 50, 50);
                e.Graphics.FillRectangle(fill, 408, 340, 50, 50);
                e.Graphics.FillRectangle(fill, 458, 340, 50, 50);
                e.Graphics.FillRectangle(fill, 658, 340, 50, 50);

                e.Graphics.DrawRectangle(draw, 308, 340, 50, 50);
                e.Graphics.DrawRectangle(draw, 358, 340, 50, 50);
                e.Graphics.DrawRectangle(draw, 408, 340, 50, 50);
                e.Graphics.DrawRectangle(draw, 458, 340, 50, 50);
                e.Graphics.DrawRectangle(draw, 658, 340, 50, 50);

                fill = new SolidBrush(Color.White);
                e.Graphics.FillRectangle(fill, 508, 340, 75, 50);
                e.Graphics.DrawRectangle(draw, 508, 340, 75, 50);
                fill = new SolidBrush(Color.LightGray);
                e.Graphics.FillRectangle(fill, 513, 345, 65, 30);
                e.Graphics.DrawRectangle(draw, 513, 345, 65, 30);
                e.Graphics.DrawEllipse(draw, 513, 380, 4, 4);
                e.Graphics.DrawEllipse(draw, 574, 380, 4, 4);
                fill = new SolidBrush(Color.White);
                e.Graphics.FillRectangle(fill, 544, 372, 4, 8);
                e.Graphics.DrawRectangle(draw, 544, 372, 4, 8);
                fill = new SolidBrush(Color.Plum);
                e.Graphics.FillRectangle(fill, 583, 340, 75, 50);
                e.Graphics.DrawRectangle(draw, 583, 340, 75, 50);
                e.Graphics.DrawEllipse(draw, 593, 350, 20, 10);
                e.Graphics.DrawEllipse(draw, 628, 350, 20, 10);
                e.Graphics.DrawEllipse(draw, 593, 375, 20, 10);
                e.Graphics.DrawEllipse(draw, 628, 375, 20, 10);

                fill = new SolidBrush(Color.White);
                //interactiveObjects(708, 340, 50, 50);
                e.Graphics.FillRectangle(fill, 708, 340, 50, 50);
                e.Graphics.DrawRectangle(draw, 708, 340, 50, 50);

                //interactiveObjects(708, 330, 50, 10);
                e.Graphics.FillRectangle(fill, 708, 330, 50, 10);
                e.Graphics.DrawRectangle(draw, 708, 330, 50, 10);

                fill = new SolidBrush(Color.Brown);
                e.Graphics.FillRectangle(fill, 468, 260, 30, 20);
                e.Graphics.FillRectangle(fill, 518, 260, 30, 20);
                e.Graphics.DrawRectangle(draw, 468, 260, 30, 20);
                e.Graphics.DrawRectangle(draw, 518, 260, 30, 20);
                fill = new SolidBrush(Color.SandyBrown);
                e.Graphics.FillRectangle(fill, 458, 270, 100, 40);
                e.Graphics.DrawRectangle(draw, 458, 270, 100, 40);

                //Room 4
                fill = new SolidBrush(Color.LightSalmon);
                //interactiveObjects(483, 55, 60, 20);
                e.Graphics.FillRectangle(fill, 483, 55, 60, 20);
                e.Graphics.DrawRectangle(draw, 483, 55, 60, 20);

                //interactiveObjects(483, 155, 60, 20);
                e.Graphics.FillRectangle(fill, 483, 155, 60, 20);
                e.Graphics.DrawRectangle(draw, 483, 155, 60, 20);

                fill = new SolidBrush(Color.LightSkyBlue);
                //interactiveObjects(493, 75, 50, 40);
                e.Graphics.FillRectangle(fill, 493, 75, 50, 40);
                e.Graphics.DrawRectangle(draw, 493, 75, 50, 40);

                //interactiveObjects(493, 115, 50, 40);
                e.Graphics.FillRectangle(fill, 493, 115, 50, 40);
                e.Graphics.DrawRectangle(draw, 493, 115, 50, 40);

                fill = new SolidBrush(Color.DarkBlue);
                //interactiveObjects(523, 75, 20, 80);
                e.Graphics.FillRectangle(fill, 523, 75, 20, 80);
                e.Graphics.DrawRectangle(draw, 523, 75, 20, 80);


                fill = new SolidBrush(Color.DimGray);
                e.Graphics.FillRectangle(fill, 363, 70, 20, 80);
                e.Graphics.DrawRectangle(draw, 363, 70, 20, 80);

                fill = new SolidBrush(Color.Brown);
                //interactiveObjects(708, 55, 20, 20);
                e.Graphics.FillRectangle(fill, 708, 55, 20, 20);
                e.Graphics.DrawRectangle(draw, 708, 55, 20, 20);

                fill = new SolidBrush(Color.White);
                //interactiveObjects(718, 25, 40, 80);
                e.Graphics.FillRectangle(fill, 718, 25, 40, 80);
                e.Graphics.DrawRectangle(draw, 718, 25, 40, 80);

                fill = new SolidBrush(Color.Gray);
                e.Graphics.FillRectangle(fill, 733, 55, 15, 20);
                e.Graphics.DrawRectangle(draw, 733, 55, 15, 20);

                //offScreen.DrawRectangle(draw, x, y, w, h);
                //offScreen.FillRectangle(fill, x, y, w, h);
                //house scene
                e.Graphics.DrawRectangle(draw, 12, 225, 255, 5);
                e.Graphics.DrawRectangle(draw, 262, 5, 5, 80);
                e.Graphics.DrawRectangle(draw, 262, 125, 5, 160);
                e.Graphics.DrawRectangle(draw, 262, 330, 5, 60);
                e.Graphics.DrawRectangle(draw, 308, 5, 5, 80);
                e.Graphics.DrawRectangle(draw, 308, 225, 200, 5);
                e.Graphics.DrawRectangle(draw, 558, 225, 200, 5);
                e.Graphics.DrawRectangle(draw, 308, 125, 5, 265);

                e.Graphics.FillRectangle(fill, 12, 225, 255, 5);
                e.Graphics.FillRectangle(fill, 262, 5, 5, 80);
                e.Graphics.FillRectangle(fill, 262, 125, 5, 160);
                e.Graphics.FillRectangle(fill, 262, 330, 5, 60);
                e.Graphics.FillRectangle(fill, 308, 5, 5, 80);
                e.Graphics.FillRectangle(fill, 308, 225, 200, 5);
                e.Graphics.FillRectangle(fill, 558, 225, 200, 5);
                e.Graphics.FillRectangle(fill, 308, 125, 5, 265);

                fill = new SolidBrush(Color.Black);
                e.Graphics.FillRectangle(fill, 748, 205, 10, 20);


                e.Graphics.FillRectangle(mainCharacterOne, drawX, drawY, 20, 20);
                mainCharacter = new Rectangle(drawX, drawY, 20, 20);
            }
            if (scene == 11)
            {
                Pen draw = new Pen(Color.Black, 3);
                SolidBrush fill = new SolidBrush(Color.Black);
                e.Graphics.DrawRectangle(draw, 0, 0, 12, 390);
                e.Graphics.FillRectangle(fill, 0, 0, 12, 390);
                e.Graphics.DrawRectangle(draw, 0, 0, 1044, 5);
                e.Graphics.FillRectangle(fill, 0, 0, 1044, 5);

                e.Graphics.DrawRectangle(draw, 758, 0, 12, 390);
                e.Graphics.FillRectangle(fill, 758, 0, 12, 390);
                e.Graphics.DrawRectangle(draw, 0, 390, 1044, 8);
                e.Graphics.FillRectangle(fill, 0, 390, 1044, 8);

                //  onScreen.DrawImage(bm, 0, 0);
                //  offScreen.Clear(Color.Black);

                //drawhouse
                //Room 1

                fill = new SolidBrush(Color.SaddleBrown);
                e.Graphics.DrawRectangle(draw, 32, 5, 30, 40);
                e.Graphics.FillRectangle(fill, 32, 5, 30, 40);
                e.Graphics.DrawRectangle(draw, 212, 5, 30, 40);
                e.Graphics.FillRectangle(fill, 212, 5, 30, 40);
                fill = new SolidBrush(Color.SaddleBrown);
                e.Graphics.DrawRectangle(draw, 47, 185, 180, 40);
                e.Graphics.FillRectangle(fill, 47, 185, 180, 40);
                fill = new SolidBrush(Color.Beige);
                e.Graphics.DrawRectangle(draw, 82, 15, 50, 20);
                e.Graphics.FillRectangle(fill, 82, 15, 50, 20);
                e.Graphics.DrawRectangle(draw, 142, 15, 50, 20);
                e.Graphics.FillRectangle(fill, 142, 15, 50, 20);

                //interactiveObjects(62, 45, 150, 120);//design/patterns needeed
                fill = new SolidBrush(Color.Coral);
                e.Graphics.FillRectangle(fill, 62, 45, 150, 120);
                e.Graphics.DrawRectangle(draw, 62, 45, 150, 120);

                //interactiveObjects(62, 45, 150, 10);//Need to be colored
                fill = new SolidBrush(Color.LightBlue);
                e.Graphics.FillRectangle(fill, 62, 45, 150, 10);
                e.Graphics.DrawRectangle(draw, 62, 45, 150, 10);

                //interactiveObjects(62, 55, 150, 80);
                fill = new SolidBrush(Color.Coral);
                e.Graphics.FillRectangle(fill, 62, 55, 150, 80);
                e.Graphics.DrawRectangle(draw, 62, 55, 150, 80);
                //Room 2
                //interactiveObjects(17, 290, 60, 100);
                fill = new SolidBrush(Color.White);
                e.Graphics.FillRectangle(fill, 17, 290, 60, 100);
                e.Graphics.DrawRectangle(draw, 17, 290, 60, 100);

                fill = new SolidBrush(Color.LightGray);
                e.Graphics.FillRectangle(fill, 22, 305, 50, 70);
                e.Graphics.DrawRectangle(draw, 22, 305, 50, 70);
                fill = new SolidBrush(Color.White);
                e.Graphics.FillRectangle(fill, 202, 230, 60, 40);
                e.Graphics.DrawRectangle(draw, 202, 230, 60, 40);
                fill = new SolidBrush(Color.LightGray);
                e.Graphics.FillRectangle(fill, 207, 245, 50, 20);
                e.Graphics.DrawRectangle(draw, 207, 245, 50, 20);

                //interactiveObjects(207, 350, 50, 30);
                fill = new SolidBrush(Color.White);
                e.Graphics.FillRectangle(fill, 207, 350, 50, 30);
                e.Graphics.DrawRectangle(draw, 207, 350, 50, 30);

                //interactiveObjects(202, 380, 60, 10);
                fill = new SolidBrush(Color.White);
                e.Graphics.FillRectangle(fill, 202, 380, 60, 10);
                e.Graphics.DrawRectangle(draw, 202, 380, 60, 10);

                fill = new SolidBrush(Color.LightGray);
                e.Graphics.FillRectangle(fill, 212, 360, 40, 20);
                e.Graphics.DrawRectangle(draw, 212, 360, 40, 20);
                fill = new SolidBrush(Color.White);
                e.Graphics.FillRectangle(fill, 230, 240, 4, 8);
                e.Graphics.DrawRectangle(draw, 230, 240, 4, 8);
                e.Graphics.FillRectangle(fill, 45, 300, 4, 8);
                e.Graphics.DrawRectangle(draw, 45, 300, 4, 8);
                e.Graphics.DrawEllipse(draw, 207, 240, 4, 4);
                e.Graphics.DrawEllipse(draw, 253, 240, 4, 4);
                e.Graphics.DrawEllipse(draw, 22, 300, 4, 4);
                e.Graphics.DrawEllipse(draw, 68, 300, 4, 4);
                //Room 3
                fill = new SolidBrush(Color.Linen);
                e.Graphics.FillRectangle(fill, 308, 340, 50, 50);
                e.Graphics.FillRectangle(fill, 358, 340, 50, 50);
                e.Graphics.FillRectangle(fill, 408, 340, 50, 50);
                e.Graphics.FillRectangle(fill, 458, 340, 50, 50);
                e.Graphics.FillRectangle(fill, 658, 340, 50, 50);

                e.Graphics.DrawRectangle(draw, 308, 340, 50, 50);
                e.Graphics.DrawRectangle(draw, 358, 340, 50, 50);
                e.Graphics.DrawRectangle(draw, 408, 340, 50, 50);
                e.Graphics.DrawRectangle(draw, 458, 340, 50, 50);
                e.Graphics.DrawRectangle(draw, 658, 340, 50, 50);

                fill = new SolidBrush(Color.White);
                e.Graphics.FillRectangle(fill, 508, 340, 75, 50);
                e.Graphics.DrawRectangle(draw, 508, 340, 75, 50);
                fill = new SolidBrush(Color.LightGray);
                e.Graphics.FillRectangle(fill, 513, 345, 65, 30);
                e.Graphics.DrawRectangle(draw, 513, 345, 65, 30);
                e.Graphics.DrawEllipse(draw, 513, 380, 4, 4);
                e.Graphics.DrawEllipse(draw, 574, 380, 4, 4);
                fill = new SolidBrush(Color.White);
                e.Graphics.FillRectangle(fill, 544, 372, 4, 8);
                e.Graphics.DrawRectangle(draw, 544, 372, 4, 8);
                fill = new SolidBrush(Color.Plum);
                e.Graphics.FillRectangle(fill, 583, 340, 75, 50);
                e.Graphics.DrawRectangle(draw, 583, 340, 75, 50);
                e.Graphics.DrawEllipse(draw, 593, 350, 20, 10);
                e.Graphics.DrawEllipse(draw, 628, 350, 20, 10);
                e.Graphics.DrawEllipse(draw, 593, 375, 20, 10);
                e.Graphics.DrawEllipse(draw, 628, 375, 20, 10);

                fill = new SolidBrush(Color.White);
                //interactiveObjects(708, 340, 50, 50);
                e.Graphics.FillRectangle(fill, 708, 340, 50, 50);
                e.Graphics.DrawRectangle(draw, 708, 340, 50, 50);

                //interactiveObjects(708, 330, 50, 10);
                e.Graphics.FillRectangle(fill, 708, 330, 50, 10);
                e.Graphics.DrawRectangle(draw, 708, 330, 50, 10);

                fill = new SolidBrush(Color.Brown);
                e.Graphics.FillRectangle(fill, 468, 260, 30, 20);
                e.Graphics.FillRectangle(fill, 518, 260, 30, 20);
                e.Graphics.DrawRectangle(draw, 468, 260, 30, 20);
                e.Graphics.DrawRectangle(draw, 518, 260, 30, 20);
                fill = new SolidBrush(Color.SandyBrown);
                e.Graphics.FillRectangle(fill, 458, 270, 100, 40);
                e.Graphics.DrawRectangle(draw, 458, 270, 100, 40);

                //Room 4
                fill = new SolidBrush(Color.LightSalmon);
                //interactiveObjects(483, 55, 60, 20);
                e.Graphics.FillRectangle(fill, 483, 55, 60, 20);
                e.Graphics.DrawRectangle(draw, 483, 55, 60, 20);

                //interactiveObjects(483, 155, 60, 20);
                e.Graphics.FillRectangle(fill, 483, 155, 60, 20);
                e.Graphics.DrawRectangle(draw, 483, 155, 60, 20);

                fill = new SolidBrush(Color.LightSkyBlue);
                //interactiveObjects(493, 75, 50, 40);
                e.Graphics.FillRectangle(fill, 493, 75, 50, 40);
                e.Graphics.DrawRectangle(draw, 493, 75, 50, 40);

                //interactiveObjects(493, 115, 50, 40);
                e.Graphics.FillRectangle(fill, 493, 115, 50, 40);
                e.Graphics.DrawRectangle(draw, 493, 115, 50, 40);

                fill = new SolidBrush(Color.DarkBlue);
                //interactiveObjects(523, 75, 20, 80);
                e.Graphics.FillRectangle(fill, 523, 75, 20, 80);
                e.Graphics.DrawRectangle(draw, 523, 75, 20, 80);


                fill = new SolidBrush(Color.DimGray);
                e.Graphics.FillRectangle(fill, 363, 70, 20, 80);
                e.Graphics.DrawRectangle(draw, 363, 70, 20, 80);

                fill = new SolidBrush(Color.Brown);
                //interactiveObjects(708, 55, 20, 20);
                e.Graphics.FillRectangle(fill, 708, 55, 20, 20);
                e.Graphics.DrawRectangle(draw, 708, 55, 20, 20);

                fill = new SolidBrush(Color.White);
                //interactiveObjects(718, 25, 40, 80);
                e.Graphics.FillRectangle(fill, 718, 25, 40, 80);
                e.Graphics.DrawRectangle(draw, 718, 25, 40, 80);

                fill = new SolidBrush(Color.Gray);
                e.Graphics.FillRectangle(fill, 733, 55, 15, 20);
                e.Graphics.DrawRectangle(draw, 733, 55, 15, 20);

                //offScreen.DrawRectangle(draw, x, y, w, h);
                //offScreen.FillRectangle(fill, x, y, w, h);
                //house scene
                e.Graphics.DrawRectangle(draw, 12, 225, 255, 5);
                e.Graphics.DrawRectangle(draw, 262, 5, 5, 80);
                e.Graphics.DrawRectangle(draw, 262, 125, 5, 160);
                e.Graphics.DrawRectangle(draw, 262, 330, 5, 60);
                e.Graphics.DrawRectangle(draw, 308, 5, 5, 80);
                e.Graphics.DrawRectangle(draw, 308, 225, 200, 5);
                e.Graphics.DrawRectangle(draw, 558, 225, 200, 5);
                e.Graphics.DrawRectangle(draw, 308, 125, 5, 265);

                e.Graphics.FillRectangle(fill, 12, 225, 255, 5);
                e.Graphics.FillRectangle(fill, 262, 5, 5, 80);
                e.Graphics.FillRectangle(fill, 262, 125, 5, 160);
                e.Graphics.FillRectangle(fill, 262, 330, 5, 60);
                e.Graphics.FillRectangle(fill, 308, 5, 5, 80);
                e.Graphics.FillRectangle(fill, 308, 225, 200, 5);
                e.Graphics.FillRectangle(fill, 558, 225, 200, 5);
                e.Graphics.FillRectangle(fill, 308, 125, 5, 265);

                fill = new SolidBrush(Color.Black);
                e.Graphics.FillRectangle(fill, 748, 205, 10, 20);


                e.Graphics.FillRectangle(mainCharacterOne, drawX, drawY, 20, 20);
                mainCharacter = new Rectangle(drawX, drawY, 20, 20);

            }
            if (scene == 12)
            {
                Pen draw = new Pen(Color.Black, 3);
                SolidBrush fill = new SolidBrush(Color.Black);
                e.Graphics.DrawRectangle(draw, 0, 0, 12, 390);
                e.Graphics.FillRectangle(fill, 0, 0, 12, 390);
                e.Graphics.DrawRectangle(draw, 0, 0, 1044, 5);
                e.Graphics.FillRectangle(fill, 0, 0, 1044, 5);

                e.Graphics.DrawRectangle(draw, 758, 0, 12, 390);
                e.Graphics.FillRectangle(fill, 758, 0, 12, 390);
                e.Graphics.DrawRectangle(draw, 0, 390, 1044, 8);
                e.Graphics.FillRectangle(fill, 0, 390, 1044, 8);

                //  onScreen.DrawImage(bm, 0, 0);
                //  offScreen.Clear(Color.Black);

                //drawhouse
                //Room 1

                fill = new SolidBrush(Color.SaddleBrown);
                e.Graphics.DrawRectangle(draw, 32, 5, 30, 40);
                e.Graphics.FillRectangle(fill, 32, 5, 30, 40);
                e.Graphics.DrawRectangle(draw, 212, 5, 30, 40);
                e.Graphics.FillRectangle(fill, 212, 5, 30, 40);
                fill = new SolidBrush(Color.SaddleBrown);
                e.Graphics.DrawRectangle(draw, 47, 185, 180, 40);
                e.Graphics.FillRectangle(fill, 47, 185, 180, 40);
                fill = new SolidBrush(Color.Beige);
                e.Graphics.DrawRectangle(draw, 82, 15, 50, 20);
                e.Graphics.FillRectangle(fill, 82, 15, 50, 20);
                e.Graphics.DrawRectangle(draw, 142, 15, 50, 20);
                e.Graphics.FillRectangle(fill, 142, 15, 50, 20);

                //interactiveObjects(62, 45, 150, 120);//design/patterns needeed
                fill = new SolidBrush(Color.Coral);
                e.Graphics.FillRectangle(fill, 62, 45, 150, 120);
                e.Graphics.DrawRectangle(draw, 62, 45, 150, 120);

                //interactiveObjects(62, 45, 150, 10);//Need to be colored
                fill = new SolidBrush(Color.LightBlue);
                e.Graphics.FillRectangle(fill, 62, 45, 150, 10);
                e.Graphics.DrawRectangle(draw, 62, 45, 150, 10);

                //interactiveObjects(62, 55, 150, 80);
                fill = new SolidBrush(Color.Coral);
                e.Graphics.FillRectangle(fill, 62, 55, 150, 80);
                e.Graphics.DrawRectangle(draw, 62, 55, 150, 80);
                //Room 2
                //interactiveObjects(17, 290, 60, 100);
                fill = new SolidBrush(Color.White);
                e.Graphics.FillRectangle(fill, 17, 290, 60, 100);
                e.Graphics.DrawRectangle(draw, 17, 290, 60, 100);

                fill = new SolidBrush(Color.LightGray);
                e.Graphics.FillRectangle(fill, 22, 305, 50, 70);
                e.Graphics.DrawRectangle(draw, 22, 305, 50, 70);
                fill = new SolidBrush(Color.White);
                e.Graphics.FillRectangle(fill, 202, 230, 60, 40);
                e.Graphics.DrawRectangle(draw, 202, 230, 60, 40);
                fill = new SolidBrush(Color.LightGray);
                e.Graphics.FillRectangle(fill, 207, 245, 50, 20);
                e.Graphics.DrawRectangle(draw, 207, 245, 50, 20);

                //interactiveObjects(207, 350, 50, 30);
                fill = new SolidBrush(Color.White);
                e.Graphics.FillRectangle(fill, 207, 350, 50, 30);
                e.Graphics.DrawRectangle(draw, 207, 350, 50, 30);

                //interactiveObjects(202, 380, 60, 10);
                fill = new SolidBrush(Color.White);
                e.Graphics.FillRectangle(fill, 202, 380, 60, 10);
                e.Graphics.DrawRectangle(draw, 202, 380, 60, 10);

                fill = new SolidBrush(Color.LightGray);
                e.Graphics.FillRectangle(fill, 212, 360, 40, 20);
                e.Graphics.DrawRectangle(draw, 212, 360, 40, 20);
                fill = new SolidBrush(Color.White);
                e.Graphics.FillRectangle(fill, 230, 240, 4, 8);
                e.Graphics.DrawRectangle(draw, 230, 240, 4, 8);
                e.Graphics.FillRectangle(fill, 45, 300, 4, 8);
                e.Graphics.DrawRectangle(draw, 45, 300, 4, 8);
                e.Graphics.DrawEllipse(draw, 207, 240, 4, 4);
                e.Graphics.DrawEllipse(draw, 253, 240, 4, 4);
                e.Graphics.DrawEllipse(draw, 22, 300, 4, 4);
                e.Graphics.DrawEllipse(draw, 68, 300, 4, 4);
                //Room 3
                fill = new SolidBrush(Color.Linen);
                e.Graphics.FillRectangle(fill, 308, 340, 50, 50);
                e.Graphics.FillRectangle(fill, 358, 340, 50, 50);
                e.Graphics.FillRectangle(fill, 408, 340, 50, 50);
                e.Graphics.FillRectangle(fill, 458, 340, 50, 50);
                e.Graphics.FillRectangle(fill, 658, 340, 50, 50);

                e.Graphics.DrawRectangle(draw, 308, 340, 50, 50);
                e.Graphics.DrawRectangle(draw, 358, 340, 50, 50);
                e.Graphics.DrawRectangle(draw, 408, 340, 50, 50);
                e.Graphics.DrawRectangle(draw, 458, 340, 50, 50);
                e.Graphics.DrawRectangle(draw, 658, 340, 50, 50);

                fill = new SolidBrush(Color.White);
                e.Graphics.FillRectangle(fill, 508, 340, 75, 50);
                e.Graphics.DrawRectangle(draw, 508, 340, 75, 50);
                fill = new SolidBrush(Color.LightGray);
                e.Graphics.FillRectangle(fill, 513, 345, 65, 30);
                e.Graphics.DrawRectangle(draw, 513, 345, 65, 30);
                e.Graphics.DrawEllipse(draw, 513, 380, 4, 4);
                e.Graphics.DrawEllipse(draw, 574, 380, 4, 4);
                fill = new SolidBrush(Color.White);
                e.Graphics.FillRectangle(fill, 544, 372, 4, 8);
                e.Graphics.DrawRectangle(draw, 544, 372, 4, 8);
                fill = new SolidBrush(Color.Plum);
                e.Graphics.FillRectangle(fill, 583, 340, 75, 50);
                e.Graphics.DrawRectangle(draw, 583, 340, 75, 50);
                e.Graphics.DrawEllipse(draw, 593, 350, 20, 10);
                e.Graphics.DrawEllipse(draw, 628, 350, 20, 10);
                e.Graphics.DrawEllipse(draw, 593, 375, 20, 10);
                e.Graphics.DrawEllipse(draw, 628, 375, 20, 10);

                fill = new SolidBrush(Color.White);
                //interactiveObjects(708, 340, 50, 50);
                e.Graphics.FillRectangle(fill, 708, 340, 50, 50);
                e.Graphics.DrawRectangle(draw, 708, 340, 50, 50);

                //interactiveObjects(708, 330, 50, 10);
                e.Graphics.FillRectangle(fill, 708, 330, 50, 10);
                e.Graphics.DrawRectangle(draw, 708, 330, 50, 10);

                fill = new SolidBrush(Color.Brown);
                e.Graphics.FillRectangle(fill, 468, 260, 30, 20);
                e.Graphics.FillRectangle(fill, 518, 260, 30, 20);
                e.Graphics.DrawRectangle(draw, 468, 260, 30, 20);
                e.Graphics.DrawRectangle(draw, 518, 260, 30, 20);
                fill = new SolidBrush(Color.SandyBrown);
                e.Graphics.FillRectangle(fill, 458, 270, 100, 40);
                e.Graphics.DrawRectangle(draw, 458, 270, 100, 40);

                //Room 4
                fill = new SolidBrush(Color.LightSalmon);
                //interactiveObjects(483, 55, 60, 20);
                e.Graphics.FillRectangle(fill, 483, 55, 60, 20);
                e.Graphics.DrawRectangle(draw, 483, 55, 60, 20);

                //interactiveObjects(483, 155, 60, 20);
                e.Graphics.FillRectangle(fill, 483, 155, 60, 20);
                e.Graphics.DrawRectangle(draw, 483, 155, 60, 20);

                fill = new SolidBrush(Color.LightSkyBlue);
                //interactiveObjects(493, 75, 50, 40);
                e.Graphics.FillRectangle(fill, 493, 75, 50, 40);
                e.Graphics.DrawRectangle(draw, 493, 75, 50, 40);

                //interactiveObjects(493, 115, 50, 40);
                e.Graphics.FillRectangle(fill, 493, 115, 50, 40);
                e.Graphics.DrawRectangle(draw, 493, 115, 50, 40);

                fill = new SolidBrush(Color.DarkBlue);
                //interactiveObjects(523, 75, 20, 80);
                e.Graphics.FillRectangle(fill, 523, 75, 20, 80);
                e.Graphics.DrawRectangle(draw, 523, 75, 20, 80);


                fill = new SolidBrush(Color.DimGray);
                e.Graphics.FillRectangle(fill, 363, 70, 20, 80);
                e.Graphics.DrawRectangle(draw, 363, 70, 20, 80);

                fill = new SolidBrush(Color.Brown);
                //interactiveObjects(708, 55, 20, 20);
                e.Graphics.FillRectangle(fill, 708, 55, 20, 20);
                e.Graphics.DrawRectangle(draw, 708, 55, 20, 20);

                fill = new SolidBrush(Color.White);
                //interactiveObjects(718, 25, 40, 80);
                e.Graphics.FillRectangle(fill, 718, 25, 40, 80);
                e.Graphics.DrawRectangle(draw, 718, 25, 40, 80);

                fill = new SolidBrush(Color.Gray);
                e.Graphics.FillRectangle(fill, 733, 55, 15, 20);
                e.Graphics.DrawRectangle(draw, 733, 55, 15, 20);

                //offScreen.DrawRectangle(draw, x, y, w, h);
                //offScreen.FillRectangle(fill, x, y, w, h);
                //house scene
                e.Graphics.DrawRectangle(draw, 12, 225, 255, 5);
                e.Graphics.DrawRectangle(draw, 262, 5, 5, 80);
                e.Graphics.DrawRectangle(draw, 262, 125, 5, 160);
                e.Graphics.DrawRectangle(draw, 262, 330, 5, 60);
                e.Graphics.DrawRectangle(draw, 308, 5, 5, 80);
                e.Graphics.DrawRectangle(draw, 308, 225, 200, 5);
                e.Graphics.DrawRectangle(draw, 558, 225, 200, 5);
                e.Graphics.DrawRectangle(draw, 308, 125, 5, 265);

                e.Graphics.FillRectangle(fill, 12, 225, 255, 5);
                e.Graphics.FillRectangle(fill, 262, 5, 5, 80);
                e.Graphics.FillRectangle(fill, 262, 125, 5, 160);
                e.Graphics.FillRectangle(fill, 262, 330, 5, 60);
                e.Graphics.FillRectangle(fill, 308, 5, 5, 80);
                e.Graphics.FillRectangle(fill, 308, 225, 200, 5);
                e.Graphics.FillRectangle(fill, 558, 225, 200, 5);
                e.Graphics.FillRectangle(fill, 308, 125, 5, 265);

                fill = new SolidBrush(Color.Black);
                e.Graphics.FillRectangle(fill, 748, 205, 10, 20);


                e.Graphics.FillRectangle(mainCharacterOne, drawX, drawY, 20, 20);
                mainCharacter = new Rectangle(drawX, drawY, 20, 20);

            }
            if (scene == 13)
            {
                Pen draw = new Pen(Color.Black, 3);
                SolidBrush fill = new SolidBrush(Color.Black);
                e.Graphics.DrawRectangle(draw, 0, 0, 12, 390);
                e.Graphics.FillRectangle(fill, 0, 0, 12, 390);
                e.Graphics.DrawRectangle(draw, 0, 0, 1044, 5);
                e.Graphics.FillRectangle(fill, 0, 0, 1044, 5);

                e.Graphics.DrawRectangle(draw, 758, 0, 12, 390);
                e.Graphics.FillRectangle(fill, 758, 0, 12, 390);
                e.Graphics.DrawRectangle(draw, 0, 390, 1044, 8);
                e.Graphics.FillRectangle(fill, 0, 390, 1044, 8);

                //  onScreen.DrawImage(bm, 0, 0);
                //  offScreen.Clear(Color.Black);

                //drawhouse
                //Room 1

                fill = new SolidBrush(Color.SaddleBrown);
                e.Graphics.DrawRectangle(draw, 32, 5, 30, 40);
                e.Graphics.FillRectangle(fill, 32, 5, 30, 40);
                e.Graphics.DrawRectangle(draw, 212, 5, 30, 40);
                e.Graphics.FillRectangle(fill, 212, 5, 30, 40);
                fill = new SolidBrush(Color.SaddleBrown);
                e.Graphics.DrawRectangle(draw, 47, 185, 180, 40);
                e.Graphics.FillRectangle(fill, 47, 185, 180, 40);
                fill = new SolidBrush(Color.Beige);
                e.Graphics.DrawRectangle(draw, 82, 15, 50, 20);
                e.Graphics.FillRectangle(fill, 82, 15, 50, 20);
                e.Graphics.DrawRectangle(draw, 142, 15, 50, 20);
                e.Graphics.FillRectangle(fill, 142, 15, 50, 20);

                //interactiveObjects(62, 45, 150, 120);//design/patterns needeed
                fill = new SolidBrush(Color.Coral);
                e.Graphics.FillRectangle(fill, 62, 45, 150, 120);
                e.Graphics.DrawRectangle(draw, 62, 45, 150, 120);

                //interactiveObjects(62, 45, 150, 10);//Need to be colored
                fill = new SolidBrush(Color.LightBlue);
                e.Graphics.FillRectangle(fill, 62, 45, 150, 10);
                e.Graphics.DrawRectangle(draw, 62, 45, 150, 10);

                //interactiveObjects(62, 55, 150, 80);
                fill = new SolidBrush(Color.Coral);
                e.Graphics.FillRectangle(fill, 62, 55, 150, 80);
                e.Graphics.DrawRectangle(draw, 62, 55, 150, 80);
                //Room 2
                //interactiveObjects(17, 290, 60, 100);
                fill = new SolidBrush(Color.White);
                e.Graphics.FillRectangle(fill, 17, 290, 60, 100);
                e.Graphics.DrawRectangle(draw, 17, 290, 60, 100);

                fill = new SolidBrush(Color.LightGray);
                e.Graphics.FillRectangle(fill, 22, 305, 50, 70);
                e.Graphics.DrawRectangle(draw, 22, 305, 50, 70);
                fill = new SolidBrush(Color.White);
                e.Graphics.FillRectangle(fill, 202, 230, 60, 40);
                e.Graphics.DrawRectangle(draw, 202, 230, 60, 40);
                fill = new SolidBrush(Color.LightGray);
                e.Graphics.FillRectangle(fill, 207, 245, 50, 20);
                e.Graphics.DrawRectangle(draw, 207, 245, 50, 20);

                //interactiveObjects(207, 350, 50, 30);
                fill = new SolidBrush(Color.White);
                e.Graphics.FillRectangle(fill, 207, 350, 50, 30);
                e.Graphics.DrawRectangle(draw, 207, 350, 50, 30);

                //interactiveObjects(202, 380, 60, 10);
                fill = new SolidBrush(Color.White);
                e.Graphics.FillRectangle(fill, 202, 380, 60, 10);
                e.Graphics.DrawRectangle(draw, 202, 380, 60, 10);

                fill = new SolidBrush(Color.LightGray);
                e.Graphics.FillRectangle(fill, 212, 360, 40, 20);
                e.Graphics.DrawRectangle(draw, 212, 360, 40, 20);
                fill = new SolidBrush(Color.White);
                e.Graphics.FillRectangle(fill, 230, 240, 4, 8);
                e.Graphics.DrawRectangle(draw, 230, 240, 4, 8);
                e.Graphics.FillRectangle(fill, 45, 300, 4, 8);
                e.Graphics.DrawRectangle(draw, 45, 300, 4, 8);
                e.Graphics.DrawEllipse(draw, 207, 240, 4, 4);
                e.Graphics.DrawEllipse(draw, 253, 240, 4, 4);
                e.Graphics.DrawEllipse(draw, 22, 300, 4, 4);
                e.Graphics.DrawEllipse(draw, 68, 300, 4, 4);
                //Room 3
                fill = new SolidBrush(Color.Linen);
                e.Graphics.FillRectangle(fill, 308, 340, 50, 50);
                e.Graphics.FillRectangle(fill, 358, 340, 50, 50);
                e.Graphics.FillRectangle(fill, 408, 340, 50, 50);
                e.Graphics.FillRectangle(fill, 458, 340, 50, 50);
                e.Graphics.FillRectangle(fill, 658, 340, 50, 50);

                e.Graphics.DrawRectangle(draw, 308, 340, 50, 50);
                e.Graphics.DrawRectangle(draw, 358, 340, 50, 50);
                e.Graphics.DrawRectangle(draw, 408, 340, 50, 50);
                e.Graphics.DrawRectangle(draw, 458, 340, 50, 50);
                e.Graphics.DrawRectangle(draw, 658, 340, 50, 50);

                fill = new SolidBrush(Color.White);
                e.Graphics.FillRectangle(fill, 508, 340, 75, 50);
                e.Graphics.DrawRectangle(draw, 508, 340, 75, 50);
                fill = new SolidBrush(Color.LightGray);
                e.Graphics.FillRectangle(fill, 513, 345, 65, 30);
                e.Graphics.DrawRectangle(draw, 513, 345, 65, 30);
                e.Graphics.DrawEllipse(draw, 513, 380, 4, 4);
                e.Graphics.DrawEllipse(draw, 574, 380, 4, 4);
                fill = new SolidBrush(Color.White);
                e.Graphics.FillRectangle(fill, 544, 372, 4, 8);
                e.Graphics.DrawRectangle(draw, 544, 372, 4, 8);
                fill = new SolidBrush(Color.Plum);
                e.Graphics.FillRectangle(fill, 583, 340, 75, 50);
                e.Graphics.DrawRectangle(draw, 583, 340, 75, 50);
                e.Graphics.DrawEllipse(draw, 593, 350, 20, 10);
                e.Graphics.DrawEllipse(draw, 628, 350, 20, 10);
                e.Graphics.DrawEllipse(draw, 593, 375, 20, 10);
                e.Graphics.DrawEllipse(draw, 628, 375, 20, 10);

                fill = new SolidBrush(Color.White);
                //interactiveObjects(708, 340, 50, 50);
                e.Graphics.FillRectangle(fill, 708, 340, 50, 50);
                e.Graphics.DrawRectangle(draw, 708, 340, 50, 50);

                //interactiveObjects(708, 330, 50, 10);
                e.Graphics.FillRectangle(fill, 708, 330, 50, 10);
                e.Graphics.DrawRectangle(draw, 708, 330, 50, 10);

                fill = new SolidBrush(Color.Brown);
                e.Graphics.FillRectangle(fill, 468, 260, 30, 20);
                e.Graphics.FillRectangle(fill, 518, 260, 30, 20);
                e.Graphics.DrawRectangle(draw, 468, 260, 30, 20);
                e.Graphics.DrawRectangle(draw, 518, 260, 30, 20);
                fill = new SolidBrush(Color.SandyBrown);
                e.Graphics.FillRectangle(fill, 458, 270, 100, 40);
                e.Graphics.DrawRectangle(draw, 458, 270, 100, 40);

                //Room 4
                fill = new SolidBrush(Color.LightSalmon);
                //interactiveObjects(483, 55, 60, 20);
                e.Graphics.FillRectangle(fill, 483, 55, 60, 20);
                e.Graphics.DrawRectangle(draw, 483, 55, 60, 20);

                //interactiveObjects(483, 155, 60, 20);
                e.Graphics.FillRectangle(fill, 483, 155, 60, 20);
                e.Graphics.DrawRectangle(draw, 483, 155, 60, 20);

                fill = new SolidBrush(Color.LightSkyBlue);
                //interactiveObjects(493, 75, 50, 40);
                e.Graphics.FillRectangle(fill, 493, 75, 50, 40);
                e.Graphics.DrawRectangle(draw, 493, 75, 50, 40);

                //interactiveObjects(493, 115, 50, 40);
                e.Graphics.FillRectangle(fill, 493, 115, 50, 40);
                e.Graphics.DrawRectangle(draw, 493, 115, 50, 40);

                fill = new SolidBrush(Color.DarkBlue);
                //interactiveObjects(523, 75, 20, 80);
                e.Graphics.FillRectangle(fill, 523, 75, 20, 80);
                e.Graphics.DrawRectangle(draw, 523, 75, 20, 80);


                fill = new SolidBrush(Color.DimGray);
                e.Graphics.FillRectangle(fill, 363, 70, 20, 80);
                e.Graphics.DrawRectangle(draw, 363, 70, 20, 80);

                fill = new SolidBrush(Color.Brown);
                //interactiveObjects(708, 55, 20, 20);
                e.Graphics.FillRectangle(fill, 708, 55, 20, 20);
                e.Graphics.DrawRectangle(draw, 708, 55, 20, 20);

                fill = new SolidBrush(Color.White);
                //interactiveObjects(718, 25, 40, 80);
                e.Graphics.FillRectangle(fill, 718, 25, 40, 80);
                e.Graphics.DrawRectangle(draw, 718, 25, 40, 80);

                fill = new SolidBrush(Color.Gray);
                e.Graphics.FillRectangle(fill, 733, 55, 15, 20);
                e.Graphics.DrawRectangle(draw, 733, 55, 15, 20);

                //offScreen.DrawRectangle(draw, x, y, w, h);
                //offScreen.FillRectangle(fill, x, y, w, h);
                //house scene
                e.Graphics.DrawRectangle(draw, 12, 225, 255, 5);
                e.Graphics.DrawRectangle(draw, 262, 5, 5, 80);
                e.Graphics.DrawRectangle(draw, 262, 125, 5, 160);
                e.Graphics.DrawRectangle(draw, 262, 330, 5, 60);
                e.Graphics.DrawRectangle(draw, 308, 5, 5, 80);
                e.Graphics.DrawRectangle(draw, 308, 225, 200, 5);
                e.Graphics.DrawRectangle(draw, 558, 225, 200, 5);
                e.Graphics.DrawRectangle(draw, 308, 125, 5, 265);

                e.Graphics.FillRectangle(fill, 12, 225, 255, 5);
                e.Graphics.FillRectangle(fill, 262, 5, 5, 80);
                e.Graphics.FillRectangle(fill, 262, 125, 5, 160);
                e.Graphics.FillRectangle(fill, 262, 330, 5, 60);
                e.Graphics.FillRectangle(fill, 308, 5, 5, 80);
                e.Graphics.FillRectangle(fill, 308, 225, 200, 5);
                e.Graphics.FillRectangle(fill, 558, 225, 200, 5);
                e.Graphics.FillRectangle(fill, 308, 125, 5, 265);

                fill = new SolidBrush(Color.Black);
                e.Graphics.FillRectangle(fill, 748, 205, 10, 20);


                e.Graphics.FillRectangle(mainCharacterOne, drawX, drawY, 20, 20);
                mainCharacter = new Rectangle(drawX, drawY, 20, 20);

            }
        }
        private void mainMenu_KeyUp(object sender, KeyEventArgs e)
        {
            switch (e.KeyCode)
            {
                case Keys.Left:
                    leftArrowDown = false;
                    break;
                case Keys.Right:
                    rightArrowDown = false;
                    break;
                case Keys.Up:
                    upArrowDown = false;
                    break;
                case Keys.Down:
                    downArrowDown = false;
                    break;
            }
        }

        private void mainMenu_KeyDown(object sender, KeyEventArgs e)
        {
            //Graphics Draw = this.CreateGraphics();

            if (e.KeyCode == Keys.Y)
            {
                if (scene == 1) { scene = 2; }
                else if (scene == 2) { scene = 4; }//girl
                else if (scene == 3) { scene = 2; }
                else if (scene == 4) { scene = 6; }//naming girlone
                else if (scene == 5) { scene = 7; }//naming guyone
                else if (scene == 6) { scene = 10; }//girlone house scene
                else if (scene == 7) { scene = 11; }//guyone house scene
                else if (scene == 8) { scene = 12; }//girltwo house scene
                else if (scene == 9) { scene = 13; }//guytwo house scene
                else if (scene == 10 && perf < 60) { scene = 15; }//girl
                else if (scene == 12 && perf < 60) { scene = 19; }//girl
                else if (scene == 11 && perf < 60) { scene = 14; }//boy
                else if (scene == 13 && perf < 60) { scene = 18; }//boy
                else if (scene == 10 && perf > 60) { scene = 17; }
                else if (scene == 12 && perf > 60) { scene = 21; }
                else if (scene == 11 && perf > 60) { scene = 16; }
                else if (scene == 13 && perf > 60) { scene = 20; }
                else if (scene == 15) { scene = 22; }
                else if (scene == 19) { scene = 26; }
                else if (scene == 14) { scene = 23; }
                else if (scene == 18) { scene = 27; }
                else if (scene == 17) { scene = 24; }
                else if (scene == 21) { scene = 28; }
                else if (scene == 16) { scene = 25; }
                else if (scene == 20) { scene = 29; }


            }
            if (e.KeyCode == Keys.U)
            {
                if (scene == 1) { scene = 3; }
                else if (scene == 2) { scene = 5; }//guy
                else if (scene == 4) { scene = 8; }//naming girltwo
                else if (scene == 5) { scene = 9; }//naming guytwo
                else if (scene == 22) { scene = 10; }
                else if (scene == 26) { scene = 12; }
                else if (scene == 23) { scene = 11; }
                else if (scene == 27) { scene = 13; }
                else if (scene == 24) { scene = 10; }
                else if (scene == 28) { scene = 12; }
                else if (scene == 25) { scene = 11; }
                else if (scene == 29) { scene = 13; }
            }
            if (e.KeyCode == Keys.I)
            {
                if (scene == 10) { Close(); }
                if (scene == 11) { Close(); }
                if (scene == 12) { Close(); }
                if (scene == 13) { Close(); }
            }

            //character 
            switch (e.KeyCode)
            {
                case Keys.Left:
                    leftArrowDown = true;
                    break;
                case Keys.Down:
                    downArrowDown = true;
                    break;
                case Keys.Right:
                    rightArrowDown = true;
                    break;
                case Keys.Up:
                    upArrowDown = true;
                    break;
            }
            if (leftArrowDown == true)
            {
                drawX = drawX - 3;
                Refresh();
            }
            if (rightArrowDown == true)
            {
                drawX = drawX + 3;
                Refresh();
            }
            if (upArrowDown == true)
            {
                drawY = drawY - 3;
                Refresh();
            }
            if (downArrowDown == true)
            {
                drawY = drawY + 3;
                Refresh();
            }

            switch (scene)
            {
                case 2: //Start Gameplay
                    bankmoneyLabel.Visible = false;
                    bankLabel.Visible = false;
                    workperfLabel.Visible = false;
                    hungerlabel.Visible = false;
                    hygienelabel.Visible = false;
                    loolabel.Visible = false;
                    entertainmentlabel.Visible = false;
                    imageO.Visible = false;
                    imageT.Visible = false;
                    titleLabel.Visible = true;
                    startLabel.Visible = true;
                    howtoplaylabel.Visible = true;
                    instructionlabel.Visible = true;
                    startLabel.Font = new Font("Impact", 12);
                    howtoplaylabel.Font = new Font("Impact", 12);
                    startLabel.Text = "Girl";
                    howtoplaylabel.Text = "Boy";
                    instructionlabel.Text = "Press Y to choose a girl character and Press U to choose a guy character";
                    break;
                case 3: //how to play
                    bankmoneyLabel.Visible = false;
                    bankLabel.Visible = false;
                    workperfLabel.Visible = false;
                    hungerlabel.Visible = false;
                    hygienelabel.Visible = false;
                    loolabel.Visible = false;
                    entertainmentlabel.Visible = false;
                    imageO.Visible = false;
                    imageT.Visible = false;
                    titleLabel.Visible = true;
                    startLabel.Visible = true;
                    howtoplaylabel.Visible = false;
                    instructionlabel.Visible = true;
                    titleLabel.Text = "How to Play";
                    startLabel.Font = new Font("Courier New", 10);
                    startLabel.Location = new Point(100, 120);
                    startLabel.Text = "The Living Simulator is inspired by Electronic Arts’ The Sims 3." + "\n" + "It allows players to choose which" + "\n" +
                        "character they want to be and to give their character " + "\n" + "creative and exclusive names that belong only to" + "\n" +
                        "them. Players can also fill their character’s needs by" + "\n" + " making their character “go to the washroom”, by" + "\n" +
                        "making their character “eat food”, by communicating with" + "\n" + " other characters present in the game, etc. This" + "\n" +
                        "of course means that players are able to move their " + "\n" + "character in desired directions. If needs are not up to a" + "\n" +
                        "certain level, the player’s character can be disliked " + "\n" + "and rejected by other characters or die in the worst" + "\n" +
                        "case scenario. If needs are fulfilled, the character can go" + "\n" + " to work to earn money so that there will be more" + "\n" +
                        "money present in their account. The more money a character has in" + "\n" + " his/her account, the higher the chance" + "\n" +
                        "of them earning likes from other characters. This allows other " + "\n" + "characters to accept certain interactions" + "\n" +
                        "from the player’s character."; //Instructions and such
                    instructionlabel.Text = "Press Y to proceed";
                    break;
                case 4: //girl
                    bankmoneyLabel.Visible = false;
                    bankLabel.Visible = false;
                    workperfLabel.Visible = false;
                    hungerlabel.Visible = false;
                    hygienelabel.Visible = false;
                    loolabel.Visible = false;
                    entertainmentlabel.Visible = false;
                    titleLabel.Visible = true;
                    startLabel.Visible = false;
                    howtoplaylabel.Visible = true;
                    instructionlabel.Visible = true;
                    imageO.Visible = true;
                    imageT.Visible = true;
                    titleLabel.Text = "Choosing your character";
                    imageO.Image = TheLifeSimulator.Properties.Resources.girlone;
                    imageT.Image = TheLifeSimulator.Properties.Resources.girltwo;
                    instructionlabel.Location = new Point(12, 350);
                    instructionlabel.Text = "Press Y for the girl on the right and press U for the girl on the left";
                    break;
                case 5: //guy
                    bankmoneyLabel.Visible = false;
                    bankLabel.Visible = false;
                    workperfLabel.Visible = false;
                    hungerlabel.Visible = false;
                    hygienelabel.Visible = false;
                    loolabel.Visible = false;
                    entertainmentlabel.Visible = false;
                    titleLabel.Visible = true;
                    startLabel.Visible = false;
                    howtoplaylabel.Visible = true;
                    instructionlabel.Visible = true;
                    imageO.Visible = true;
                    imageT.Visible = true;
                    titleLabel.Text = "Choosing your character";
                    imageO.Image = TheLifeSimulator.Properties.Resources.guyone;
                    imageT.Image = TheLifeSimulator.Properties.Resources.guytwo;
                    instructionlabel.Text = "Press Y for the guy on the right and press U for the guy on the left";
                    break;
                case 6: //girlone
                    bankmoneyLabel.Visible = false;
                    bankLabel.Visible = false;
                    workperfLabel.Visible = false;
                    hungerlabel.Visible = false;
                    hygienelabel.Visible = false;
                    loolabel.Visible = false;
                    entertainmentlabel.Visible = false;
                    titleLabel.Visible = true;
                    titleLabel.Text = "Naming";
                    startLabel.Location = new Point(100, 170);
                    startLabel.Visible = true;
                    startLabel.Text = "Caroline";
                    howtoplaylabel.Visible = true;
                    howtoplaylabel.Text = "Press Y to move on";
                    instructionlabel.Location = new Point(12, 400);
                    instructionlabel.Size = new Size(746, 130);
                    instructionlabel.Visible = true;
                    instructionlabel.Text = "";
                    instructionlabel.BackColor = Color.Pink;
                    imageO.Location = new Point(12, 400);
                    imageO.Size = new Size(100, 130);
                    imageO.Visible = true;
                    imageO.Image = TheLifeSimulator.Properties.Resources.girlone;
                    imageT.Visible = false;
                    break;
                case 7: //guyone
                    bankmoneyLabel.Visible = false;
                    bankLabel.Visible = false;
                    workperfLabel.Visible = false;
                    hungerlabel.Visible = false;
                    hygienelabel.Visible = false;
                    loolabel.Visible = false;
                    entertainmentlabel.Visible = false;
                    titleLabel.Visible = true;
                    titleLabel.Text = "Naming";
                    startLabel.Location = new Point(100, 170);
                    startLabel.Visible = true;
                    startLabel.Text = "Ethan";
                    howtoplaylabel.Visible = true;
                    howtoplaylabel.Text = "Press Y to move on";
                    instructionlabel.Location = new Point(12, 400);
                    instructionlabel.Size = new Size(746, 130);
                    instructionlabel.Visible = true;
                    instructionlabel.Text = "";
                    instructionlabel.BackColor = Color.LightBlue;
                    imageO.Location = new Point(12, 400);
                    imageO.Size = new Size(100, 130);
                    imageO.Visible = true;
                    imageO.Image = TheLifeSimulator.Properties.Resources.guyone;
                    imageT.Visible = false;
                    break;
                case 8: //girltwo
                    bankmoneyLabel.Visible = false;
                    bankLabel.Visible = false;
                    workperfLabel.Visible = false;
                    hungerlabel.Visible = false;
                    hygienelabel.Visible = false;
                    loolabel.Visible = false;
                    entertainmentlabel.Visible = false;
                    titleLabel.Visible = true;
                    titleLabel.Text = "Naming";
                    startLabel.Location = new Point(100, 170);
                    startLabel.Visible = true;
                    startLabel.Text = "Nikki";
                    howtoplaylabel.Visible = true;
                    howtoplaylabel.Text = "Press Y to move on";
                    instructionlabel.Location = new Point(12, 400);
                    instructionlabel.Size = new Size(746, 130);
                    instructionlabel.Visible = true;
                    instructionlabel.Text = "";
                    instructionlabel.BackColor = Color.Pink;
                    imageO.Location = new Point(12, 400);
                    imageO.Size = new Size(100, 130);
                    imageO.Visible = true;
                    imageO.Image = TheLifeSimulator.Properties.Resources.girltwo;
                    imageT.Visible = false;
                    break;
                case 9: //guytwo
                    bankmoneyLabel.Visible = false;
                    bankLabel.Visible = false;
                    workperfLabel.Visible = false;
                    hungerlabel.Visible = false;
                    hygienelabel.Visible = false;
                    loolabel.Visible = false;
                    entertainmentlabel.Visible = false;
                    titleLabel.Visible = true;
                    titleLabel.Text = "Naming";
                    startLabel.Location = new Point(100, 170);
                    startLabel.Visible = true;
                    startLabel.Text = "Mason";
                    howtoplaylabel.Visible = true;
                    howtoplaylabel.Text = "Press Y to move on";
                    instructionlabel.Location = new Point(12, 400);
                    instructionlabel.Size = new Size(746, 130);
                    instructionlabel.Visible = true;
                    instructionlabel.Text = "";
                    instructionlabel.BackColor = Color.LightBlue;
                    imageO.Location = new Point(12, 400);
                    imageO.Size = new Size(100, 130);
                    imageO.Visible = true;
                    imageO.Image = TheLifeSimulator.Properties.Resources.guytwo;
                    imageT.Visible = false;
                    break;

                case 10://girlone house scene
                        this.BackColor = Color.AntiqueWhite;

                        bankLabel.Location = new Point(400, 420);
                        bankLabel.BackColor = Color.Pink;
                        bankLabel.Text = "Bank";
                        bankLabel.Visible = true;
                        bankmoneyLabel.BackColor = Color.White;
                        bankmoneyLabel.Location = new Point(530, 410);
                        bankmoneyLabel.Visible = true;
                        workperfLabel.Location = new Point(400, 440);
                        workperfLabel.BackColor = Color.Pink;
                        workperfLabel.Text = "Work Performance";
                        workperfLabel.Visible = true;

                        workperfBar(520, 40);

                        hungerlabel.BackColor = Color.Pink;
                        entertainmentlabel.BackColor = Color.Pink;
                        loolabel.BackColor = Color.Pink;
                        hygienelabel.BackColor = Color.Pink;
                        hungerlabel.Location = new Point(120, 420);
                        entertainmentlabel.Location = new Point(120, 440);
                        loolabel.Location = new Point(120, 460);
                        hygienelabel.Location = new Point(120, 480);
                        hungerlabel.Size = new Size(120, 20);
                        entertainmentlabel.Size = new Size(120, 20);
                        loolabel.Size = new Size(120, 20);
                        hygienelabel.Size = new Size(120, 20);
                        hungerlabel.Visible = true;
                        hygienelabel.Visible = true;
                        loolabel.Visible = true;
                        entertainmentlabel.Visible = true;
                        hungerlabel.Text = "Hunger";
                        entertainmentlabel.Text = "Entertainment";
                        loolabel.Text = "Loo";
                        hygienelabel.Text = "Hygiene";

                        hungerBar(250, 10);
                        entertainmentBar(250, 40);
                        loo(250, 70);
                        hygieneBar(250, 100);

                        imageO.Visible = true;///
                        imageT.Visible = false;///
                        titleLabel.Visible = false;///
                        startLabel.Location = new Point(274, 400);
                        startLabel.Visible = true;///
                        howtoplaylabel.Visible = false;///
                        instructionlabel.Visible = true;///

                    mainCharacter = new Rectangle(drawX, drawY, 20, 20);

                    if (drawX < 14) { drawX = 14;}
                    if (drawY < 7) { drawY = 7; }
                    if (drawX > 735) { drawX = 735; }
                    if (drawY > 367) { drawY = 367; }

                    Rectangle divisionOne = new Rectangle(12, 225, 255, 5);
                    Rectangle divisionTwo = new Rectangle(262, 5, 5, 80);
                    Rectangle divisionThree = new Rectangle(262, 125, 5, 160);
                    Rectangle divisionFour = new Rectangle(262, 330, 5, 60);
                    Rectangle divisionFive = new Rectangle(308, 5, 5, 80);
                    Rectangle divisionSix = new Rectangle(308, 225, 200, 5);
                    Rectangle divisionSeven = new Rectangle(558, 225, 200, 5);
                    Rectangle divisionEight = new Rectangle(308, 125, 5, 265);

                    if (divisionOne.IntersectsWith(mainCharacter))
                    {
                        if (drawY < 225) { drawY = 205; }
                        if (drawY > 225) { drawY = 235; }
                    }
                    if (divisionTwo.IntersectsWith(mainCharacter))
                    {
                        if (drawX < 262) { drawX = 242; }
                        if (drawX > 262) { drawX = 272; }
                    }
                    if (divisionThree.IntersectsWith(mainCharacter))
                    {
                        if (drawX < 262) { drawX = 242; }
                        if (drawX > 262) { drawX = 272; }
                    }
                    if (divisionFour.IntersectsWith(mainCharacter))
                    {
                        if (drawX < 262) { drawX = 242; }
                        if (drawX > 262) { drawX = 272; }
                    }
                    if (divisionFive.IntersectsWith(mainCharacter))
                    {
                        if (drawX < 308) { drawX = 288; }
                        if (drawX > 308) { drawX = 318; }
                    }
                    if (divisionEight.IntersectsWith(mainCharacter))
                    {
                        if (drawX < 308) { drawX = 288; }
                        if (drawX > 308) { drawX = 318; }
                    }
                    if (divisionSix.IntersectsWith(mainCharacter))
                    {
                        if (drawY < 225) { drawY = 205; }
                        if (drawY > 225) { drawY = 235; }
                    }
                    if (divisionSeven.IntersectsWith(mainCharacter))
                    {
                        if (drawY < 225) { drawY = 205; }
                        if (drawY > 225) { drawY = 235; }
                    }

                    //Room 1

                    //e.Graphics.DrawRectangle(draw, 32, 5, 30, 40);
                    Rectangle sidetableOneCover2 = new Rectangle(32, 5, 30, 40);
                    //e.Graphics.DrawRectangle(draw, 212, 5, 30, 40);
                    Rectangle sidetableTwoCover1 = new Rectangle(212, 40, 30, 5);
                    Rectangle sidetableTwoCover2 = new Rectangle(237, 5, 5, 40);
                    //e.Graphics.DrawRectangle(draw, 47, 185, 180, 40);
                    Rectangle dresser = new Rectangle(47, 185, 180, 40);
                    Rectangle dressercover = new Rectangle(47, 185, 180, 3);
                    Rectangle dressercoverTwo = new Rectangle(224, 185, 3, 40);

                    //e.Graphics.DrawRectangle(draw, 82, 15, 50, 20);
                    //e.Graphics.DrawRectangle(draw, 142, 15, 50, 20);
                    
                    ////Objects(62, 45, 150, 120);
                    Rectangle bedOne = new Rectangle(62, 45, 5, 120);
                    Rectangle bedTwo = new Rectangle(207, 45, 5, 120);

                    //////Objects(62, 45, 150, 10);//Need to be colored
                    //Rectangle topBlanket = new Rectangle(62, 45, 150, 10); inside bed
                    //////Objects(62, 55, 150, 80);
                    Rectangle bottomBlanket = new Rectangle(62, 160, 150, 5); //inside bed
                    
                    
                    if (sidetableOneCover2.IntersectsWith(mainCharacter))
                    {
                        drawX = 45;
                        
                    }

                    if (bedOne.IntersectsWith(mainCharacter))
                    {
                        if (drawX > 42)
                        {
                            drawX = 42;
                        }
                       
                    }

                    if (bottomBlanket.IntersectsWith(mainCharacter))
                    {
                        if (drawY < 165)
                        {
                            drawY = 165;
                        }
                    }

                    if (bedTwo.IntersectsWith(mainCharacter))
                    {
                        if (drawX < 215)
                        {
                            drawX = 215;
                        }
                    }

                    if (dresser.IntersectsWith(mainCharacter))
                    {
                        if (drawX > 25 && drawX < 30)
                        {
                            drawX = 25;
                        }
                        
                    }
                    if (dressercover.IntersectsWith(mainCharacter))
                    {
                        if (drawY > 165)
                        {
                            drawY = 165;
                        }
                    }
                    if (dressercoverTwo.IntersectsWith(mainCharacter))
                    {
                        if (drawX < 230)
                        {
                            drawX = 230;
                        }
                    }
                    if (sidetableTwoCover1.IntersectsWith(mainCharacter))
                    {
                            drawY = 45;
                    }
                    if (sidetableTwoCover2.IntersectsWith(mainCharacter))
                    {
                        if (drawX < 242)
                        {
                            drawX = 242;
                        }
                    }
                    //Room 2
                    ////interactiveObjects(17, 290, 60, 100);
                    //tubOne = new Rectangle(17, 290, 60, 5);
                    //tubTwo = new Rectangle(72, 290, 5, 100);
                    //e.Graphics.DrawRectangle(draw, 22, 305, 50, 70); inside tub
                    if (tubOne.IntersectsWith(mainCharacter))
                    {
                        if (drawY > 270)
                        {
                            drawY = 270;
                        }

                    }
                    if (tubTwo.IntersectsWith(mainCharacter))
                    {
                        if (drawX < 77)
                        {
                            drawX = 77;
                        }
                    }

                    //e.Graphics.DrawRectangle(draw, 202, 230, 60, 40);
                    Rectangle sinkOne = new Rectangle(202, 230, 5, 40);
                    Rectangle sinkTwo = new Rectangle(202, 265, 60, 5);
                    if (sinkOne.IntersectsWith(mainCharacter))
                    {
                        if (drawX > 182)
                        {
                            drawX = 182;
                        }
                       
                    }
                    if (sinkTwo.IntersectsWith(mainCharacter))
                    {
                        if (drawY < 270)
                        {
                            drawY = 270;
                        }
                    }


                    //e.Graphics.DrawRectangle(draw, 207, 350, 50, 30);
                    
                    //if (toiletTwoCover1.IntersectsWith(mainCharacter))
                    //{
                    //        drawX = 207;
                        
                    //}
                    //if (toiletTwoCover2.IntersectsWith(mainCharacter))
                    //{
                    //     drawY = 245;
                    //}
                    ////interactiveObjects(207, 350, 50, 30); inside Sink

                    ////interactiveObjects(202, 380, 60, 10);
                    Rectangle toiletOne = new Rectangle(202, 380, 60, 10);
                    //e.Graphics.DrawRectangle(draw, 212, 360, 40, 20); inside toilet
                    //e.Graphics.DrawRectangle(draw, 230, 240, 4, 8); inside sink
                    //e.Graphics.DrawRectangle(draw, 45, 300, 4, 8); inside tub

                    ////Room 3

                    //e.Graphics.DrawRectangle(draw, 308, 340, 50, 50);
                    Rectangle counterOne = new Rectangle(308, 340, 50, 50);
                    if (counterOne.IntersectsWith(mainCharacter))
                    {
                        if (drawY > 320)
                        {
                            drawY = 320;
                        }
                    }
                    //e.Graphics.DrawRectangle(draw, 358, 340, 50, 50);
                    Rectangle counterTwo = new Rectangle(358, 340, 50, 50);
                    if (counterTwo.IntersectsWith(mainCharacter))
                    {
                        if (drawY > 320)
                        {
                            drawY = 320;
                        }
                    }
                    //e.Graphics.DrawRectangle(draw, 408, 340, 50, 50);
                    Rectangle counterThree = new Rectangle(408, 340, 50, 50);
                    if (counterThree.IntersectsWith(mainCharacter))
                    {
                        if (drawY > 320)
                        {
                            drawY = 320;
                        }
                    }
                    //e.Graphics.DrawRectangle(draw, 458, 340, 50, 50);
                    Rectangle counterFour = new Rectangle(458, 340, 50, 50);
                    if (counterFour.IntersectsWith(mainCharacter))
                    {
                        if (drawY > 320)
                        {
                            drawY = 320;
                        }
                    }
                    //e.Graphics.DrawRectangle(draw, 658, 340, 50, 50);
                    Rectangle counterFive = new Rectangle(658, 340, 50, 50);
                    if (counterFive.IntersectsWith(mainCharacter))
                    {
                        if (drawY > 320)
                        {
                            drawY = 320;
                        }
                    }


                    //e.Graphics.DrawRectangle(draw, 508, 340, 75, 50);
                    Rectangle kitchensink = new Rectangle(508, 340, 75, 50);
                    if (kitchensink.IntersectsWith(mainCharacter))
                    {
                        if (drawY > 320)
                        {
                            drawY = 320;
                        }
                    }

                    //e.Graphics.DrawRectangle(draw, 583, 340, 75, 50);
                    Rectangle stove = new Rectangle(583, 340, 75, 50);
                    if (stove.IntersectsWith(mainCharacter))
                    {
                        if (drawY > 320)
                        {
                            drawY = 320;
                        }
                    }

                    ////interactiveObjects(708, 340, 50, 50);
                    if (fridgeOne.IntersectsWith(mainCharacter))
                    {
                        if (drawY > 320)
                        {
                            drawY = 320;
                        }
                    }
                    ////interactiveObjects(708, 330, 50, 10);
                    if (fridgeTwo.IntersectsWith(mainCharacter))
                    {
                        if (drawY > 310)
                        {
                            drawY = 310;
                        }
                    }

                    //e.Graphics.DrawRectangle(draw, 468, 260, 30, 20);
                    Rectangle chairOne = new Rectangle(468, 260, 30, 20);
                    if (chairOne.IntersectsWith(mainCharacter))
                    {
                        if (drawY > 240)
                        {
                            drawY = 240;
                        }
                    }
                    //e.Graphics.DrawRectangle(draw, 518, 260, 30, 20);
                    Rectangle chairTwo = new Rectangle(518, 260, 30, 20);
                    if (chairTwo.IntersectsWith(mainCharacter))
                    {
                        if (drawY > 240)
                        {
                            drawY = 240;
                        }
                    }

                    //e.Graphics.DrawRectangle(draw, 458, 270, 100, 40);
                    Rectangle tableCover1 = new Rectangle(458, 270, 5, 40);
                    Rectangle tableCover2 = new Rectangle(458, 305, 100, 5);
                    Rectangle tableCover3 = new Rectangle(553, 270, 5, 40);
                    if (tableCover1.IntersectsWith(mainCharacter))
                    {
                        if (drawX > 438)
                        {
                            drawX = 438;
                        }
                    }
                    if (tableCover2.IntersectsWith(mainCharacter))
                    {
                        if (drawY < 310)
                        {
                            drawY = 310;
                        }
                    }
                    if (tableCover3.IntersectsWith(mainCharacter))
                    {
                        if (drawX < 558)
                        {
                            drawX = 558;
                        }
                    }
                    ////Room 4
                    //e.Graphics.DrawRectangle(draw, 483, 55, 60, 20);
                    Rectangle couchOneCover1 = new Rectangle(483, 55, 5, 20);
                    Rectangle couchOneCover2 = new Rectangle(483, 55, 60, 3);
                    Rectangle couchOneCover3 = new Rectangle(538, 55, 5, 20);
                    if (couchOneCover1.IntersectsWith(mainCharacter))
                    {
                        drawX = 463;
                    }
                    if (couchOneCover2.IntersectsWith(mainCharacter))
                    {
                        if (drawY > 25)
                        {
                            drawY = 25;
                        }
                    }
                    if (couchOneCover3.IntersectsWith(mainCharacter))
                    {
                        drawX = 543;
                    }
                    ////interactiveObjects(483, 155, 60, 20);
                    Rectangle couchTwoCover1 = new Rectangle(483, 155, 5, 20);
                    Rectangle couchTwoCover2 = new Rectangle(483, 172, 60, 3);
                    Rectangle couchTwoCover3 = new Rectangle(538, 155, 5, 20);
                    if (couchTwoCover1.IntersectsWith(mainCharacter))
                    {
                        drawX = 463;
                    }
                    if (couchTwoCover2.IntersectsWith(mainCharacter))
                    {
                        if (drawY < 175)
                        {
                            drawY = 175;
                        }
                    }
                    if (couchTwoCover3.IntersectsWith(mainCharacter))
                    {
                        drawX = 543;
                    }
                    //e.Graphics.DrawRectangle(draw, 493, 75, 50, 40);
                    Rectangle couchThree = new Rectangle(493, 75, 50, 40);
                    if (couchThree.IntersectsWith(mainCharacter))
                    {
                        drawX = 473;
                    }
                    //e.Graphics.DrawRectangle(draw, 493, 115, 50, 40);
                    Rectangle couchFour = new Rectangle(493, 115, 50, 40);
                    if (couchFour.IntersectsWith(mainCharacter))
                    {
                        drawX = 473;
                    }
                    //e.Graphics.DrawRectangle(draw, 523, 75, 20, 80);
                    Rectangle couchFive = new Rectangle(523, 75, 20, 80);
                    if (couchFive.IntersectsWith(mainCharacter))
                    {
                        drawX = 543;
                    }
                    //e.Graphics.DrawRectangle(draw, 363, 70, 20, 80);
                    Rectangle tvCover1 = new Rectangle(363, 70, 3, 80);
                    Rectangle tvCover2 = new Rectangle(363, 70, 20, 3);
                    Rectangle tvCover3 = new Rectangle(380, 70, 3, 80);
                    Rectangle tvCover4 = new Rectangle(363, 147, 20, 3);
                   if (tvCover1.IntersectsWith(mainCharacter))
                   {
                        if (drawX > 343)
                        {
                            drawX = 343;
                        }
                   }
                   if (tvCover2.IntersectsWith(mainCharacter))
                   {
                        drawY = 50;
                   }
                   if (tvCover3.IntersectsWith(mainCharacter))
                   {
                        drawX = 388;
                   }
                   if(tvCover4.IntersectsWith(mainCharacter))
                   {
                        drawY = 150;
                   }
                    //e.Graphics.DrawRectangle(draw, 708, 55, 20, 20);
                    Rectangle officechair = new Rectangle(708, 55, 20, 20);
                    if (officechair.IntersectsWith(mainCharacter))
                    {
                        drawX = 688;
                    }
                    //e.Graphics.DrawRectangle(draw, 718, 25, 40, 80);
                    deskCover1 = new Rectangle(718, 25, 3, 80);
                    deskCover2 = new Rectangle(718, 25, 40, 3);
                    deskCover3 = new Rectangle(718, 102, 40, 3);
                    if (deskCover1.IntersectsWith(mainCharacter))
                    {
                        drawX = 698;
                    }
                    if (deskCover2.IntersectsWith(mainCharacter))
                    {
                        drawY = 5;
                    }
                    if (deskCover3.IntersectsWith(mainCharacter))
                    {
                        drawY = 105;
                    }
                    Rectangle doorAction = new Rectangle(748, 205, 10, 20);
                    break;

                case 11://guyone house scene
                    this.BackColor = Color.AntiqueWhite;

                    bankLabel.Location = new Point(400, 420);
                    bankLabel.BackColor = Color.LightBlue;
                    bankLabel.Text = "Bank";
                    bankLabel.Visible = true;
                    bankmoneyLabel.BackColor = Color.White;
                    bankmoneyLabel.Location = new Point(530, 410);
                    bankmoneyLabel.Visible = true;
                    workperfLabel.Location = new Point(400, 440);
                    workperfLabel.BackColor = Color.LightBlue;
                    workperfLabel.Text = "Work Performance";
                    workperfLabel.Visible = true;

                    workperfBar(520, 40);

                    hungerlabel.BackColor = Color.LightBlue;
                    entertainmentlabel.BackColor = Color.LightBlue;
                    loolabel.BackColor = Color.LightBlue;
                    hygienelabel.BackColor = Color.LightBlue;
                    hungerlabel.Location = new Point(120, 420);
                    entertainmentlabel.Location = new Point(120, 440);
                    loolabel.Location = new Point(120, 460);
                    hygienelabel.Location = new Point(120, 480);
                    hungerlabel.Size = new Size(120, 20);
                    entertainmentlabel.Size = new Size(120, 20);
                    loolabel.Size = new Size(120, 20);
                    hygienelabel.Size = new Size(120, 20);
                    hungerlabel.Visible = true;
                    hygienelabel.Visible = true;
                    loolabel.Visible = true;
                    entertainmentlabel.Visible = true;
                    hungerlabel.Text = "Hunger";
                    entertainmentlabel.Text = "Entertainment";
                    loolabel.Text = "Loo";
                    hygienelabel.Text = "Hygiene";

                    hungerBar(250, 10);
                    entertainmentBar(250, 40);
                    loo(250, 70);
                    hygieneBar(250, 100);

                    imageO.Visible = true;///
                    imageT.Visible = false;///
                    titleLabel.Visible = false;///
                    startLabel.Location = new Point(274, 400);
                    startLabel.Visible = true;///
                    howtoplaylabel.Visible = false;///
                    instructionlabel.Visible = true;///

                    mainCharacter = new Rectangle(drawX, drawY, 20, 20);

                    if (drawX < 14) { drawX = 14; }
                    if (drawY < 7) { drawY = 7; }
                    if (drawX > 735) { drawX = 735; }
                    if (drawY > 367) { drawY = 367; }

                    divisionOne = new Rectangle(12, 225, 255, 5);
                    divisionTwo = new Rectangle(262, 5, 5, 80);
                    divisionThree = new Rectangle(262, 125, 5, 160);
                    divisionFour = new Rectangle(262, 330, 5, 60);
                    divisionFive = new Rectangle(308, 5, 5, 80);
                    divisionSix = new Rectangle(308, 225, 200, 5);
                    divisionSeven = new Rectangle(558, 225, 200, 5);
                    divisionEight = new Rectangle(308, 125, 5, 265);

                    if (divisionOne.IntersectsWith(mainCharacter))
                    {
                        if (drawY < 225) { drawY = 205; }
                        if (drawY > 225) { drawY = 235; }
                    }
                    if (divisionTwo.IntersectsWith(mainCharacter))
                    {
                        if (drawX < 262) { drawX = 242; }
                        if (drawX > 262) { drawX = 272; }
                    }
                    if (divisionThree.IntersectsWith(mainCharacter))
                    {
                        if (drawX < 262) { drawX = 242; }
                        if (drawX > 262) { drawX = 272; }
                    }
                    if (divisionFour.IntersectsWith(mainCharacter))
                    {
                        if (drawX < 262) { drawX = 242; }
                        if (drawX > 262) { drawX = 272; }
                    }
                    if (divisionFive.IntersectsWith(mainCharacter))
                    {
                        if (drawX < 308) { drawX = 288; }
                        if (drawX > 308) { drawX = 318; }
                    }
                    if (divisionEight.IntersectsWith(mainCharacter))
                    {
                        if (drawX < 308) { drawX = 288; }
                        if (drawX > 308) { drawX = 318; }
                    }
                    if (divisionSix.IntersectsWith(mainCharacter))
                    {
                        if (drawY < 225) { drawY = 205; }
                        if (drawY > 225) { drawY = 235; }
                    }
                    if (divisionSeven.IntersectsWith(mainCharacter))
                    {
                        if (drawY < 225) { drawY = 205; }
                        if (drawY > 225) { drawY = 235; }
                    }

                    //Room 1

                    //e.Graphics.DrawRectangle(draw, 32, 5, 30, 40);
                    sidetableOneCover2 = new Rectangle(32, 5, 30, 40);
                    //e.Graphics.DrawRectangle(draw, 212, 5, 30, 40);
                    sidetableTwoCover1 = new Rectangle(212, 40, 30, 5);
                    sidetableTwoCover2 = new Rectangle(237, 5, 5, 40);
                    //e.Graphics.DrawRectangle(draw, 47, 185, 180, 40);
                    dresser = new Rectangle(47, 185, 180, 40);
                    dressercover = new Rectangle(47, 185, 180, 3);
                    dressercoverTwo = new Rectangle(224, 185, 3, 40);

                    //e.Graphics.DrawRectangle(draw, 82, 15, 50, 20);
                    //e.Graphics.DrawRectangle(draw, 142, 15, 50, 20);

                    ////Objects(62, 45, 150, 120);
                    bedOne = new Rectangle(62, 45, 5, 120);
                    bedTwo = new Rectangle(207, 45, 5, 120);

                    //////Objects(62, 45, 150, 10);//Need to be colored
                    //Rectangle topBlanket = new Rectangle(62, 45, 150, 10); inside bed
                    //////Objects(62, 55, 150, 80);
                    bottomBlanket = new Rectangle(62, 160, 150, 5); //inside bed

                    if (sidetableOneCover2.IntersectsWith(mainCharacter))
                    {
                        drawY = 45;

                    }
                    if (bedOne.IntersectsWith(mainCharacter))
                    {
                        if (drawX > 42)
                        {
                            drawX = 42;
                        }

                    }

                    if (bottomBlanket.IntersectsWith(mainCharacter))
                    {
                        if (drawY < 165)
                        {
                            drawY = 165;
                        }
                    }

                    if (bedTwo.IntersectsWith(mainCharacter))
                    {
                        if (drawX < 215)
                        {
                            drawX = 215;
                        }
                    }
                    if (dresser.IntersectsWith(mainCharacter))
                    {
                        if (drawX > 25 && drawX < 30)
                        {
                            drawX = 25;
                        }

                    }
                    if (dressercover.IntersectsWith(mainCharacter))
                    {
                        if (drawY > 165)
                        {
                            drawY = 165;
                        }
                    }
                    if (dressercoverTwo.IntersectsWith(mainCharacter))
                    {
                        if (drawX < 230)
                        {
                            drawX = 230;
                        }
                    }
                    if (sidetableTwoCover1.IntersectsWith(mainCharacter))
                    {
                        drawY = 45;
                    }
                    if (sidetableTwoCover2.IntersectsWith(mainCharacter))
                    {
                        if (drawX < 242)
                        {
                            drawX = 242;
                        }
                    }

                    //Room 2
                    ////interactiveObjects(17, 290, 60, 100);
                    //e.Graphics.DrawRectangle(draw, 22, 305, 50, 70); inside tub
                    if (tubOne.IntersectsWith(mainCharacter))
                    {
                        if (drawY > 270)
                        {
                            drawY = 270;
                        }

                    }
                    if (tubTwo.IntersectsWith(mainCharacter))
                    {
                        if (drawX < 77)
                        {
                            drawX = 77;
                        }
                    }

                    //e.Graphics.DrawRectangle(draw, 202, 230, 60, 40);
                    sinkOne = new Rectangle(202, 230, 5, 40);
                    sinkTwo = new Rectangle(202, 265, 60, 5);
                    if (sinkOne.IntersectsWith(mainCharacter))
                    {
                        if (drawX > 182)
                        {
                            drawX = 182;
                        }

                    }
                    if (sinkTwo.IntersectsWith(mainCharacter))
                    {
                        if (drawY < 270)
                        {
                            drawY = 270;
                        }
                    }


                    //e.Graphics.DrawRectangle(draw, 207, 350, 50, 30);
                    
                    //if (toiletTwoCover1.IntersectsWith(mainCharacter))
                    //{
                    //        drawX = 207;

                    //}
                    //if (toiletTwoCover2.IntersectsWith(mainCharacter))
                    //{
                    //     drawY = 245;
                    //}
                    ////interactiveObjects(207, 350, 50, 30); inside Sink

                    ////interactiveObjects(202, 380, 60, 10);
                    toiletOne = new Rectangle(202, 380, 60, 10);
                    //e.Graphics.DrawRectangle(draw, 212, 360, 40, 20); inside toilet
                    //e.Graphics.DrawRectangle(draw, 230, 240, 4, 8); inside sink
                    //e.Graphics.DrawRectangle(draw, 45, 300, 4, 8); inside tub

                    ////Room 3

                    //e.Graphics.DrawRectangle(draw, 308, 340, 50, 50);
                    counterOne = new Rectangle(308, 340, 50, 50);
                    if (counterOne.IntersectsWith(mainCharacter))
                    {
                        if (drawY > 320)
                        {
                            drawY = 320;
                        }
                    }
                    //e.Graphics.DrawRectangle(draw, 358, 340, 50, 50);
                    counterTwo = new Rectangle(358, 340, 50, 50);
                    if (counterTwo.IntersectsWith(mainCharacter))
                    {
                        if (drawY > 320)
                        {
                            drawY = 320;
                        }
                    }
                    //e.Graphics.DrawRectangle(draw, 408, 340, 50, 50);
                    counterThree = new Rectangle(408, 340, 50, 50);
                    if (counterThree.IntersectsWith(mainCharacter))
                    {
                        if (drawY > 320)
                        {
                            drawY = 320;
                        }
                    }
                    //e.Graphics.DrawRectangle(draw, 458, 340, 50, 50);
                    counterFour = new Rectangle(458, 340, 50, 50);
                    if (counterFour.IntersectsWith(mainCharacter))
                    {
                        if (drawY > 320)
                        {
                            drawY = 320;
                        }
                    }
                    //e.Graphics.DrawRectangle(draw, 658, 340, 50, 50);
                    counterFive = new Rectangle(658, 340, 50, 50);
                    if (counterFive.IntersectsWith(mainCharacter))
                    {
                        if (drawY > 320)
                        {
                            drawY = 320;
                        }
                    }


                    //e.Graphics.DrawRectangle(draw, 508, 340, 75, 50);
                    kitchensink = new Rectangle(508, 340, 75, 50);
                    if (kitchensink.IntersectsWith(mainCharacter))
                    {
                        if (drawY > 320)
                        {
                            drawY = 320;
                        }
                    }

                    //e.Graphics.DrawRectangle(draw, 583, 340, 75, 50);
                    stove = new Rectangle(583, 340, 75, 50);
                    if (stove.IntersectsWith(mainCharacter))
                    {
                        if (drawY > 320)
                        {
                            drawY = 320;
                        }
                    }

                    ////interactiveObjects(708, 340, 50, 50);
                    
                    if (fridgeOne.IntersectsWith(mainCharacter))
                    {
                        if (drawY > 320)
                        {
                            drawY = 320;
                        }
                    }
                    ////interactiveObjects(708, 330, 50, 10);
                    if (fridgeTwo.IntersectsWith(mainCharacter))
                    {
                        if (drawY > 310)
                        {
                            drawY = 310;
                        }
                    }

                    //e.Graphics.DrawRectangle(draw, 468, 260, 30, 20);
                    chairOne = new Rectangle(468, 260, 30, 20);
                    if (chairOne.IntersectsWith(mainCharacter))
                    {
                        if (drawY > 240)
                        {
                            drawY = 240;
                        }
                    }
                    //e.Graphics.DrawRectangle(draw, 518, 260, 30, 20);
                    chairTwo = new Rectangle(518, 260, 30, 20);
                    if (chairTwo.IntersectsWith(mainCharacter))
                    {
                        if (drawY > 240)
                        {
                            drawY = 240;
                        }
                    }

                    //e.Graphics.DrawRectangle(draw, 458, 270, 100, 40);
                    tableCover1 = new Rectangle(458, 270, 5, 40);
                    tableCover2 = new Rectangle(458, 305, 100, 5);
                    tableCover3 = new Rectangle(553, 270, 5, 40);
                    if (tableCover1.IntersectsWith(mainCharacter))
                    {
                        if (drawX > 438)
                        {
                            drawX = 438;
                        }
                    }
                    if (tableCover2.IntersectsWith(mainCharacter))
                    {
                        if (drawY < 310)
                        {
                            drawY = 310;
                        }
                    }
                    if (tableCover3.IntersectsWith(mainCharacter))
                    {
                        if (drawX < 558)
                        {
                            drawX = 558;
                        }
                    }
                    ////Room 4
                    //e.Graphics.DrawRectangle(draw, 483, 55, 60, 20);
                    couchOneCover1 = new Rectangle(483, 55, 5, 20);
                    couchOneCover2 = new Rectangle(483, 55, 60, 3);
                    couchOneCover3 = new Rectangle(538, 55, 5, 20);
                    if (couchOneCover1.IntersectsWith(mainCharacter))
                    {
                        drawX = 463;
                    }
                    if (couchOneCover2.IntersectsWith(mainCharacter))
                    {
                        if (drawY > 25)
                        {
                            drawY = 25;
                        }
                    }
                    if (couchOneCover3.IntersectsWith(mainCharacter))
                    {
                        drawX = 543;
                    }
                    ////interactiveObjects(483, 155, 60, 20);
                    couchTwoCover1 = new Rectangle(483, 155, 5, 20);
                    couchTwoCover2 = new Rectangle(483, 172, 60, 3);
                    couchTwoCover3 = new Rectangle(538, 155, 5, 20);
                    if (couchTwoCover1.IntersectsWith(mainCharacter))
                    {
                        drawX = 463;
                    }
                    if (couchTwoCover2.IntersectsWith(mainCharacter))
                    {
                        if (drawY < 175)
                        {
                            drawY = 175;
                        }
                    }
                    if (couchTwoCover3.IntersectsWith(mainCharacter))
                    {
                        drawX = 543;
                    }
                    //e.Graphics.DrawRectangle(draw, 493, 75, 50, 40);
                    couchThree = new Rectangle(493, 75, 50, 40);
                    if (couchThree.IntersectsWith(mainCharacter))
                    {
                        drawX = 473;
                    }
                    //e.Graphics.DrawRectangle(draw, 493, 115, 50, 40);
                    couchFour = new Rectangle(493, 115, 50, 40);
                    if (couchFour.IntersectsWith(mainCharacter))
                    {
                        drawX = 473;
                    }
                    //e.Graphics.DrawRectangle(draw, 523, 75, 20, 80);
                    couchFive = new Rectangle(523, 75, 20, 80);
                    if (couchFive.IntersectsWith(mainCharacter))
                    {
                        drawX = 543;
                    }
                    //e.Graphics.DrawRectangle(draw, 363, 70, 20, 80);
                    tvCover1 = new Rectangle(363, 70, 3, 80);
                    tvCover2 = new Rectangle(363, 70, 20, 3);
                    tvCover3 = new Rectangle(380, 70, 3, 80);
                    tvCover4 = new Rectangle(363, 147, 20, 3);
                    if (tvCover1.IntersectsWith(mainCharacter))
                    {
                        if (drawX > 343)
                        {
                            drawX = 343;
                        }
                    }
                    if (tvCover2.IntersectsWith(mainCharacter))
                    {
                        drawY = 50;
                    }
                    if (tvCover3.IntersectsWith(mainCharacter))
                    {
                        drawX = 388;
                    }
                    if (tvCover4.IntersectsWith(mainCharacter))
                    {
                        drawY = 150;
                    }
                    //e.Graphics.DrawRectangle(draw, 708, 55, 20, 20);
                    officechair = new Rectangle(708, 55, 20, 20);
                    if (officechair.IntersectsWith(mainCharacter))
                    {
                        drawX = 688;
                    }
                    //e.Graphics.DrawRectangle(draw, 718, 25, 40, 80);
                    deskCover1 = new Rectangle(718, 25, 3, 80);
                    deskCover2 = new Rectangle(718, 25, 40, 3);
                    deskCover3 = new Rectangle(718, 102, 40, 3);
                    if (deskCover1.IntersectsWith(mainCharacter))
                    {
                        drawX = 698;
                    }
                    if (deskCover2.IntersectsWith(mainCharacter))
                    {
                        drawY = 5;
                    }
                    if (deskCover3.IntersectsWith(mainCharacter))
                    {
                        drawY = 105;
                    }
                    break;

                case 12://girltwo house scene
                    this.BackColor = Color.AntiqueWhite;

                    bankLabel.Location = new Point(400, 420);
                    bankLabel.BackColor = Color.Pink;
                    bankLabel.Text = "Bank";
                    bankLabel.Visible = true;
                    bankmoneyLabel.BackColor = Color.White;
                    bankmoneyLabel.Location = new Point(530, 410);
                    bankmoneyLabel.Visible = true;
                    workperfLabel.Location = new Point(400, 440);
                    workperfLabel.BackColor = Color.Pink;
                    workperfLabel.Text = "Work Performance";
                    workperfLabel.Visible = true;

                    workperfBar(520, 40);

                    hungerlabel.BackColor = Color.Pink;
                    entertainmentlabel.BackColor = Color.Pink;
                    loolabel.BackColor = Color.Pink;
                    hygienelabel.BackColor = Color.Pink;
                    hungerlabel.Location = new Point(120, 420);
                    entertainmentlabel.Location = new Point(120, 440);
                    loolabel.Location = new Point(120, 460);
                    hygienelabel.Location = new Point(120, 480);
                    hungerlabel.Size = new Size(120, 20);
                    entertainmentlabel.Size = new Size(120, 20);
                    loolabel.Size = new Size(120, 20);
                    hygienelabel.Size = new Size(120, 20);
                    hungerlabel.Visible = true;
                    hygienelabel.Visible = true;
                    loolabel.Visible = true;
                    entertainmentlabel.Visible = true;
                    hungerlabel.Text = "Hunger";
                    entertainmentlabel.Text = "Entertainment";
                    loolabel.Text = "Loo";
                    hygienelabel.Text = "Hygiene";

                    hungerBar(250, 10);
                    entertainmentBar(250, 40);
                    loo(250, 70);
                    hygieneBar(250, 100);

                    imageO.Visible = true;///
                    imageT.Visible = false;///
                    titleLabel.Visible = false;///
                    startLabel.Location = new Point(274, 400);
                    startLabel.Visible = true;///
                    howtoplaylabel.Visible = false;///
                    instructionlabel.Visible = true;///

                    mainCharacter = new Rectangle(drawX, drawY, 20, 20);

                    if (drawX < 14) { drawX = 14; }
                    if (drawY < 7) { drawY = 7; }
                    if (drawX > 735) { drawX = 735; }
                    if (drawY > 367) { drawY = 367; }

                    divisionOne = new Rectangle(12, 225, 255, 5);
                    divisionTwo = new Rectangle(262, 5, 5, 80);
                    divisionThree = new Rectangle(262, 125, 5, 160);
                    divisionFour = new Rectangle(262, 330, 5, 60);
                    divisionFive = new Rectangle(308, 5, 5, 80);
                    divisionSix = new Rectangle(308, 225, 200, 5);
                    divisionSeven = new Rectangle(558, 225, 200, 5);
                    divisionEight = new Rectangle(308, 125, 5, 265);

                    if (divisionOne.IntersectsWith(mainCharacter))
                    {
                        if (drawY < 225) { drawY = 205; }
                        if (drawY > 225) { drawY = 235; }
                    }
                    if (divisionTwo.IntersectsWith(mainCharacter))
                    {
                        if (drawX < 262) { drawX = 242; }
                        if (drawX > 262) { drawX = 272; }
                    }
                    if (divisionThree.IntersectsWith(mainCharacter))
                    {
                        if (drawX < 262) { drawX = 242; }
                        if (drawX > 262) { drawX = 272; }
                    }
                    if (divisionFour.IntersectsWith(mainCharacter))
                    {
                        if (drawX < 262) { drawX = 242; }
                        if (drawX > 262) { drawX = 272; }
                    }
                    if (divisionFive.IntersectsWith(mainCharacter))
                    {
                        if (drawX < 308) { drawX = 288; }
                        if (drawX > 308) { drawX = 318; }
                    }
                    if (divisionEight.IntersectsWith(mainCharacter))
                    {
                        if (drawX < 308) { drawX = 288; }
                        if (drawX > 308) { drawX = 318; }
                    }
                    if (divisionSix.IntersectsWith(mainCharacter))
                    {
                        if (drawY < 225) { drawY = 205; }
                        if (drawY > 225) { drawY = 235; }
                    }
                    if (divisionSeven.IntersectsWith(mainCharacter))
                    {
                        if (drawY < 225) { drawY = 205; }
                        if (drawY > 225) { drawY = 235; }
                    }

                    //Room 1

                    //e.Graphics.DrawRectangle(draw, 32, 5, 30, 40);
                    sidetableOneCover2 = new Rectangle(32, 5, 30, 40);
                    //e.Graphics.DrawRectangle(draw, 212, 5, 30, 40);
                    sidetableTwoCover1 = new Rectangle(212, 40, 30, 5);
                    sidetableTwoCover2 = new Rectangle(237, 5, 5, 40);
                    //e.Graphics.DrawRectangle(draw, 47, 185, 180, 40);
                    dresser = new Rectangle(47, 185, 180, 40);
                    dressercover = new Rectangle(47, 185, 180, 3);
                    dressercoverTwo = new Rectangle(224, 185, 3, 40);

                    //e.Graphics.DrawRectangle(draw, 82, 15, 50, 20);
                    //e.Graphics.DrawRectangle(draw, 142, 15, 50, 20);

                    ////Objects(62, 45, 150, 120);
                    bedOne = new Rectangle(62, 45, 5, 120);
                    bedTwo = new Rectangle(207, 45, 5, 120);

                    //////Objects(62, 45, 150, 10);//Need to be colored
                    //Rectangle topBlanket = new Rectangle(62, 45, 150, 10); inside bed
                    //////Objects(62, 55, 150, 80);
                    bottomBlanket = new Rectangle(62, 160, 150, 5); //inside bed

                    if (sidetableOneCover2.IntersectsWith(mainCharacter))
                    {
                        drawY = 45;

                    }
                    if (bedOne.IntersectsWith(mainCharacter))
                    {
                        if (drawX > 42)
                        {
                            drawX = 42;
                        }

                    }

                    if (bottomBlanket.IntersectsWith(mainCharacter))
                    {
                        if (drawY < 165)
                        {
                            drawY = 165;
                        }
                    }

                    if (bedTwo.IntersectsWith(mainCharacter))
                    {
                        if (drawX < 215)
                        {
                            drawX = 215;
                        }
                    }
                    if (dresser.IntersectsWith(mainCharacter))
                    {
                        if (drawX > 25 && drawX < 30)
                        {
                            drawX = 25;
                        }

                    }
                    if (dressercover.IntersectsWith(mainCharacter))
                    {
                        if (drawY > 165)
                        {
                            drawY = 165;
                        }
                    }
                    if (dressercoverTwo.IntersectsWith(mainCharacter))
                    {
                        if (drawX < 230)
                        {
                            drawX = 230;
                        }
                    }
                    if (sidetableTwoCover1.IntersectsWith(mainCharacter))
                    {
                        drawY = 45;
                    }
                    if (sidetableTwoCover2.IntersectsWith(mainCharacter))
                    {
                        if (drawX < 242)
                        {
                            drawX = 242;
                        }
                    }
                    //Room 2
                    ////interactiveObjects(17, 290, 60, 100);

                    //e.Graphics.DrawRectangle(draw, 22, 305, 50, 70); inside tub
                    if (tubOne.IntersectsWith(mainCharacter))
                    {
                        if (drawY > 270)
                        {
                            drawY = 270;
                        }

                    }
                    if (tubTwo.IntersectsWith(mainCharacter))
                    {
                        if (drawX < 77)
                        {
                            drawX = 77;
                        }
                    }

                    //e.Graphics.DrawRectangle(draw, 202, 230, 60, 40);
                    sinkOne = new Rectangle(202, 230, 5, 40);
                    sinkTwo = new Rectangle(202, 265, 60, 5);
                    if (sinkOne.IntersectsWith(mainCharacter))
                    {
                        if (drawX > 182)
                        {
                            drawX = 182;
                        }

                    }
                    if (sinkTwo.IntersectsWith(mainCharacter))
                    {
                        if (drawY < 270)
                        {
                            drawY = 270;
                        }
                    }


                    //e.Graphics.DrawRectangle(draw, 207, 350, 50, 30);
                    //if (toiletTwoCover1.IntersectsWith(mainCharacter))
                    //{
                    //        drawX = 207;

                    //}
                    //if (toiletTwoCover2.IntersectsWith(mainCharacter))
                    //{
                    //     drawY = 245;
                    //}
                    ////interactiveObjects(207, 350, 50, 30); inside Sink

                    ////interactiveObjects(202, 380, 60, 10);
                    toiletOne = new Rectangle(202, 380, 60, 10);
                    //e.Graphics.DrawRectangle(draw, 212, 360, 40, 20); inside toilet
                    //e.Graphics.DrawRectangle(draw, 230, 240, 4, 8); inside sink
                    //e.Graphics.DrawRectangle(draw, 45, 300, 4, 8); inside tub

                    ////Room 3

                    //e.Graphics.DrawRectangle(draw, 308, 340, 50, 50);
                    counterOne = new Rectangle(308, 340, 50, 50);
                    if (counterOne.IntersectsWith(mainCharacter))
                    {
                        if (drawY > 320)
                        {
                            drawY = 320;
                        }
                    }
                    //e.Graphics.DrawRectangle(draw, 358, 340, 50, 50);
                    counterTwo = new Rectangle(358, 340, 50, 50);
                    if (counterTwo.IntersectsWith(mainCharacter))
                    {
                        if (drawY > 320)
                        {
                            drawY = 320;
                        }
                    }
                    //e.Graphics.DrawRectangle(draw, 408, 340, 50, 50);
                    counterThree = new Rectangle(408, 340, 50, 50);
                    if (counterThree.IntersectsWith(mainCharacter))
                    {
                        if (drawY > 320)
                        {
                            drawY = 320;
                        }
                    }
                    //e.Graphics.DrawRectangle(draw, 458, 340, 50, 50);
                    counterFour = new Rectangle(458, 340, 50, 50);
                    if (counterFour.IntersectsWith(mainCharacter))
                    {
                        if (drawY > 320)
                        {
                            drawY = 320;
                        }
                    }
                    //e.Graphics.DrawRectangle(draw, 658, 340, 50, 50);
                    counterFive = new Rectangle(658, 340, 50, 50);
                    if (counterFive.IntersectsWith(mainCharacter))
                    {
                        if (drawY > 320)
                        {
                            drawY = 320;
                        }
                    }


                    //e.Graphics.DrawRectangle(draw, 508, 340, 75, 50);
                    kitchensink = new Rectangle(508, 340, 75, 50);
                    if (kitchensink.IntersectsWith(mainCharacter))
                    {
                        if (drawY > 320)
                        {
                            drawY = 320;
                        }
                    }

                    //e.Graphics.DrawRectangle(draw, 583, 340, 75, 50);
                    stove = new Rectangle(583, 340, 75, 50);
                    if (stove.IntersectsWith(mainCharacter))
                    {
                        if (drawY > 320)
                        {
                            drawY = 320;
                        }
                    }

                    ////interactiveObjects(708, 340, 50, 50);
                    if (fridgeOne.IntersectsWith(mainCharacter))
                    {
                        if (drawY > 320)
                        {
                            drawY = 320;
                        }
                    }
                    ////interactiveObjects(708, 330, 50, 10);
                    if (fridgeTwo.IntersectsWith(mainCharacter))
                    {
                        if (drawY > 310)
                        {
                            drawY = 310;
                        }
                    }

                    //e.Graphics.DrawRectangle(draw, 468, 260, 30, 20);
                    chairOne = new Rectangle(468, 260, 30, 20);
                    if (chairOne.IntersectsWith(mainCharacter))
                    {
                        if (drawY > 240)
                        {
                            drawY = 240;
                        }
                    }
                    //e.Graphics.DrawRectangle(draw, 518, 260, 30, 20);
                    chairTwo = new Rectangle(518, 260, 30, 20);
                    if (chairTwo.IntersectsWith(mainCharacter))
                    {
                        if (drawY > 240)
                        {
                            drawY = 240;
                        }
                    }

                    //e.Graphics.DrawRectangle(draw, 458, 270, 100, 40);
                    tableCover1 = new Rectangle(458, 270, 5, 40);
                    tableCover2 = new Rectangle(458, 305, 100, 5);
                    tableCover3 = new Rectangle(553, 270, 5, 40);
                    if (tableCover1.IntersectsWith(mainCharacter))
                    {
                        if (drawX > 438)
                        {
                            drawX = 438;
                        }
                    }
                    if (tableCover2.IntersectsWith(mainCharacter))
                    {
                        if (drawY < 310)
                        {
                            drawY = 310;
                        }
                    }
                    if (tableCover3.IntersectsWith(mainCharacter))
                    {
                        if (drawX < 558)
                        {
                            drawX = 558;
                        }
                    }
                    ////Room 4
                    //e.Graphics.DrawRectangle(draw, 483, 55, 60, 20);
                    couchOneCover1 = new Rectangle(483, 55, 5, 20);
                    couchOneCover2 = new Rectangle(483, 55, 60, 3);
                    couchOneCover3 = new Rectangle(538, 55, 5, 20);
                    if (couchOneCover1.IntersectsWith(mainCharacter))
                    {
                        drawX = 463;
                    }
                    if (couchOneCover2.IntersectsWith(mainCharacter))
                    {
                        if (drawY > 25)
                        {
                            drawY = 25;
                        }
                    }
                    if (couchOneCover3.IntersectsWith(mainCharacter))
                    {
                        drawX = 543;
                    }
                    ////interactiveObjects(483, 155, 60, 20);
                    couchTwoCover1 = new Rectangle(483, 155, 5, 20);
                    couchTwoCover2 = new Rectangle(483, 172, 60, 3);
                    couchTwoCover3 = new Rectangle(538, 155, 5, 20);
                    if (couchTwoCover1.IntersectsWith(mainCharacter))
                    {
                        drawX = 463;
                    }
                    if (couchTwoCover2.IntersectsWith(mainCharacter))
                    {
                        if (drawY < 175)
                        {
                            drawY = 175;
                        }
                    }
                    if (couchTwoCover3.IntersectsWith(mainCharacter))
                    {
                        drawX = 543;
                    }
                    //e.Graphics.DrawRectangle(draw, 493, 75, 50, 40);
                    couchThree = new Rectangle(493, 75, 50, 40);
                    if (couchThree.IntersectsWith(mainCharacter))
                    {
                        drawX = 473;
                    }
                    //e.Graphics.DrawRectangle(draw, 493, 115, 50, 40);
                    couchFour = new Rectangle(493, 115, 50, 40);
                    if (couchFour.IntersectsWith(mainCharacter))
                    {
                        drawX = 473;
                    }
                    //e.Graphics.DrawRectangle(draw, 523, 75, 20, 80);
                    couchFive = new Rectangle(523, 75, 20, 80);
                    if (couchFive.IntersectsWith(mainCharacter))
                    {
                        drawX = 543;
                    }
                    //e.Graphics.DrawRectangle(draw, 363, 70, 20, 80);
                    tvCover1 = new Rectangle(363, 70, 3, 80);
                    tvCover2 = new Rectangle(363, 70, 20, 3);
                    tvCover3 = new Rectangle(380, 70, 3, 80);
                    tvCover4 = new Rectangle(363, 147, 20, 3);
                    if (tvCover1.IntersectsWith(mainCharacter))
                    {
                        if (drawX > 343)
                        {
                            drawX = 343;
                        }
                    }
                    if (tvCover2.IntersectsWith(mainCharacter))
                    {
                        drawY = 50;
                    }
                    if (tvCover3.IntersectsWith(mainCharacter))
                    {
                        drawX = 388;
                    }
                    if (tvCover4.IntersectsWith(mainCharacter))
                    {
                        drawY = 150;
                    }
                    //e.Graphics.DrawRectangle(draw, 708, 55, 20, 20);
                    officechair = new Rectangle(708, 55, 20, 20);
                    if (officechair.IntersectsWith(mainCharacter))
                    {
                        drawX = 688;
                    }
                    //e.Graphics.DrawRectangle(draw, 718, 25, 40, 80);
                    deskCover1 = new Rectangle(718, 25, 3, 80);
                    deskCover2 = new Rectangle(718, 25, 40, 3);
                    deskCover3 = new Rectangle(718, 102, 40, 3);
                    if (deskCover1.IntersectsWith(mainCharacter))
                    {
                        drawX = 698;
                    }
                    if (deskCover2.IntersectsWith(mainCharacter))
                    {
                        drawY = 5;
                    }
                    if (deskCover3.IntersectsWith(mainCharacter))
                    {
                        drawY = 105;
                    }
                    break;

                case 13://guytwo house scene
                    this.BackColor = Color.AntiqueWhite;

                    bankLabel.Location = new Point(400, 420);
                    bankLabel.BackColor = Color.LightBlue;
                    bankLabel.Text = "Bank";
                    bankLabel.Visible = true;
                    bankmoneyLabel.BackColor = Color.White;
                    bankmoneyLabel.Location = new Point(530, 410);
                    bankmoneyLabel.Visible = true;
                    workperfLabel.Location = new Point(400, 440);
                    workperfLabel.BackColor = Color.LightBlue;
                    workperfLabel.Text = "Work Performance";
                    workperfLabel.Visible = true;

                    workperfBar(520, 40);

                    hungerlabel.BackColor = Color.LightBlue;
                    entertainmentlabel.BackColor = Color.LightBlue;
                    loolabel.BackColor = Color.LightBlue;
                    hygienelabel.BackColor = Color.LightBlue;
                    hungerlabel.Location = new Point(120, 420);
                    entertainmentlabel.Location = new Point(120, 440);
                    loolabel.Location = new Point(120, 460);
                    hygienelabel.Location = new Point(120, 480);
                    hungerlabel.Size = new Size(120, 20);
                    entertainmentlabel.Size = new Size(120, 20);
                    loolabel.Size = new Size(120, 20);
                    hygienelabel.Size = new Size(120, 20);
                    hungerlabel.Visible = true;
                    hygienelabel.Visible = true;
                    loolabel.Visible = true;
                    entertainmentlabel.Visible = true;
                    hungerlabel.Text = "Hunger";
                    entertainmentlabel.Text = "Entertainment";
                    loolabel.Text = "Loo";
                    hygienelabel.Text = "Hygiene";

                    hungerBar(250, 10);
                    entertainmentBar(250, 40);
                    loo(250, 70);
                    hygieneBar(250, 100);

                    imageO.Visible = true;///
                    imageT.Visible = false;///
                    titleLabel.Visible = false;///
                    startLabel.Location = new Point(274, 400);
                    startLabel.Visible = true;///
                    howtoplaylabel.Visible = false;///
                    instructionlabel.Visible = true;///

                    mainCharacter = new Rectangle(drawX, drawY, 20, 20);

                    if (drawX < 14) { drawX = 14; }
                    if (drawY < 7) { drawY = 7; }
                    if (drawX > 735) { drawX = 735; }
                    if (drawY > 367) { drawY = 367; }

                    divisionOne = new Rectangle(12, 225, 255, 5);
                    divisionTwo = new Rectangle(262, 5, 5, 80);
                    divisionThree = new Rectangle(262, 125, 5, 160);
                    divisionFour = new Rectangle(262, 330, 5, 60);
                    divisionFive = new Rectangle(308, 5, 5, 80);
                    divisionSix = new Rectangle(308, 225, 200, 5);
                    divisionSeven = new Rectangle(558, 225, 200, 5);
                    divisionEight = new Rectangle(308, 125, 5, 265);

                    if (divisionOne.IntersectsWith(mainCharacter))
                    {
                        if (drawY < 225) { drawY = 205; }
                        if (drawY > 225) { drawY = 235; }
                    }
                    if (divisionTwo.IntersectsWith(mainCharacter))
                    {
                        if (drawX < 262) { drawX = 242; }
                        if (drawX > 262) { drawX = 272; }
                    }
                    if (divisionThree.IntersectsWith(mainCharacter))
                    {
                        if (drawX < 262) { drawX = 242; }
                        if (drawX > 262) { drawX = 272; }
                    }
                    if (divisionFour.IntersectsWith(mainCharacter))
                    {
                        if (drawX < 262) { drawX = 242; }
                        if (drawX > 262) { drawX = 272; }
                    }
                    if (divisionFive.IntersectsWith(mainCharacter))
                    {
                        if (drawX < 308) { drawX = 288; }
                        if (drawX > 308) { drawX = 318; }
                    }
                    if (divisionEight.IntersectsWith(mainCharacter))
                    {
                        if (drawX < 308) { drawX = 288; }
                        if (drawX > 308) { drawX = 318; }
                    }
                    if (divisionSix.IntersectsWith(mainCharacter))
                    {
                        if (drawY < 225) { drawY = 205; }
                        if (drawY > 225) { drawY = 235; }
                    }
                    if (divisionSeven.IntersectsWith(mainCharacter))
                    {
                        if (drawY < 225) { drawY = 205; }
                        if (drawY > 225) { drawY = 235; }
                    }

                    //Room 1

                    //e.Graphics.DrawRectangle(draw, 32, 5, 30, 40);
                    sidetableOneCover2 = new Rectangle(32, 5, 30, 40);
                    //e.Graphics.DrawRectangle(draw, 212, 5, 30, 40);
                    sidetableTwoCover1 = new Rectangle(212, 40, 30, 5);
                    sidetableTwoCover2 = new Rectangle(237, 5, 5, 40);
                    //e.Graphics.DrawRectangle(draw, 47, 185, 180, 40);
                    dresser = new Rectangle(47, 185, 180, 40);
                    dressercover = new Rectangle(47, 185, 180, 3);
                    dressercoverTwo = new Rectangle(224, 185, 3, 40);

                    //e.Graphics.DrawRectangle(draw, 82, 15, 50, 20);
                    //e.Graphics.DrawRectangle(draw, 142, 15, 50, 20);

                    ////Objects(62, 45, 150, 120);
                    bedOne = new Rectangle(62, 45, 5, 120);
                    bedTwo = new Rectangle(207, 45, 5, 120);

                    //////Objects(62, 45, 150, 10);//Need to be colored
                    //Rectangle topBlanket = new Rectangle(62, 45, 150, 10); inside bed
                    //////Objects(62, 55, 150, 80);
                    bottomBlanket = new Rectangle(62, 160, 150, 5); //inside bed

                    if (sidetableOneCover2.IntersectsWith(mainCharacter))
                    {
                        drawY = 45;

                    }
                    if (bedOne.IntersectsWith(mainCharacter))
                    {
                        if (drawX > 42)
                        {
                            drawX = 42;
                        }

                    }

                    if (bottomBlanket.IntersectsWith(mainCharacter))
                    {
                        if (drawY < 165)
                        {
                            drawY = 165;
                        }
                    }

                    if (bedTwo.IntersectsWith(mainCharacter))
                    {
                        if (drawX < 215)
                        {
                            drawX = 215;
                        }
                    }
                    if (dresser.IntersectsWith(mainCharacter))
                    {
                        if (drawX > 25 && drawX < 30)
                        {
                            drawX = 25;
                        }

                    }
                    if (dressercover.IntersectsWith(mainCharacter))
                    {
                        if (drawY > 165)
                        {
                            drawY = 165;
                        }
                    }
                    if (dressercoverTwo.IntersectsWith(mainCharacter))
                    {
                        if (drawX < 230)
                        {
                            drawX = 230;
                        }
                    }
                    if (sidetableTwoCover1.IntersectsWith(mainCharacter))
                    {
                        drawY = 45;
                    }
                    if (sidetableTwoCover2.IntersectsWith(mainCharacter))
                    {
                        if (drawX < 242)
                        {
                            drawX = 242;
                        }
                    }
                    //Room 2
                    ////interactiveObjects(17, 290, 60, 100);
                    //tubOne = new Rectangle(17, 290, 60, 5);
                    //tubTwo = new Rectangle(72, 290, 5, 100);
                    //e.Graphics.DrawRectangle(draw, 22, 305, 50, 70); inside tub
                    if (tubOne.IntersectsWith(mainCharacter))
                    {
                        if (drawY > 270)
                        {
                            drawY = 270;
                        }

                    }
                    if (tubTwo.IntersectsWith(mainCharacter))
                    {
                        if (drawX < 77)
                        {
                            drawX = 77;
                        }
                    }

                    //e.Graphics.DrawRectangle(draw, 202, 230, 60, 40);
                    sinkOne = new Rectangle(202, 230, 5, 40);
                    sinkTwo = new Rectangle(202, 265, 60, 5);
                    if (sinkOne.IntersectsWith(mainCharacter))
                    {
                        if (drawX > 182)
                        {
                            drawX = 182;
                        }

                    }
                    if (sinkTwo.IntersectsWith(mainCharacter))
                    {
                        if (drawY < 270)
                        {
                            drawY = 270;
                        }
                    }


                    //e.Graphics.DrawRectangle(draw, 207, 350, 50, 30);
                    
                    //if (toiletTwoCover1.IntersectsWith(mainCharacter))
                    //{
                    //        drawX = 207;

                    //}
                    //if (toiletTwoCover2.IntersectsWith(mainCharacter))
                    //{
                    //     drawY = 245;
                    //}
                    ////interactiveObjects(207, 350, 50, 30); inside Sink

                    ////interactiveObjects(202, 380, 60, 10);
                    toiletOne = new Rectangle(202, 380, 60, 10);
                    //e.Graphics.DrawRectangle(draw, 212, 360, 40, 20); inside toilet
                    //e.Graphics.DrawRectangle(draw, 230, 240, 4, 8); inside sink
                    //e.Graphics.DrawRectangle(draw, 45, 300, 4, 8); inside tub

                    ////Room 3

                    //e.Graphics.DrawRectangle(draw, 308, 340, 50, 50);
                    counterOne = new Rectangle(308, 340, 50, 50);
                    if (counterOne.IntersectsWith(mainCharacter))
                    {
                        if (drawY > 320)
                        {
                            drawY = 320;
                        }
                    }
                    //e.Graphics.DrawRectangle(draw, 358, 340, 50, 50);
                    counterTwo = new Rectangle(358, 340, 50, 50);
                    if (counterTwo.IntersectsWith(mainCharacter))
                    {
                        if (drawY > 320)
                        {
                            drawY = 320;
                        }
                    }
                    //e.Graphics.DrawRectangle(draw, 408, 340, 50, 50);
                    counterThree = new Rectangle(408, 340, 50, 50);
                    if (counterThree.IntersectsWith(mainCharacter))
                    {
                        if (drawY > 320)
                        {
                            drawY = 320;
                        }
                    }
                    //e.Graphics.DrawRectangle(draw, 458, 340, 50, 50);
                    counterFour = new Rectangle(458, 340, 50, 50);
                    if (counterFour.IntersectsWith(mainCharacter))
                    {
                        if (drawY > 320)
                        {
                            drawY = 320;
                        }
                    }
                    //e.Graphics.DrawRectangle(draw, 658, 340, 50, 50);
                    counterFive = new Rectangle(658, 340, 50, 50);
                    if (counterFive.IntersectsWith(mainCharacter))
                    {
                        if (drawY > 320)
                        {
                            drawY = 320;
                        }
                    }


                    //e.Graphics.DrawRectangle(draw, 508, 340, 75, 50);
                    kitchensink = new Rectangle(508, 340, 75, 50);
                    if (kitchensink.IntersectsWith(mainCharacter))
                    {
                        if (drawY > 320)
                        {
                            drawY = 320;
                        }
                    }

                    //e.Graphics.DrawRectangle(draw, 583, 340, 75, 50);
                    stove = new Rectangle(583, 340, 75, 50);
                    if (stove.IntersectsWith(mainCharacter))
                    {
                        if (drawY > 320)
                        {
                            drawY = 320;
                        }
                    }

                    ////interactiveObjects(708, 340, 50, 50);
                    if (fridgeOne.IntersectsWith(mainCharacter))
                    {
                        if (drawY > 320)
                        {
                            drawY = 320;
                        }
                    }
                    ////interactiveObjects(708, 330, 50, 10);
                    if (fridgeTwo.IntersectsWith(mainCharacter))
                    {
                        if (drawY > 310)
                        {
                            drawY = 310;
                        }
                    }

                    //e.Graphics.DrawRectangle(draw, 468, 260, 30, 20);
                    chairOne = new Rectangle(468, 260, 30, 20);
                    if (chairOne.IntersectsWith(mainCharacter))
                    {
                        if (drawY > 240)
                        {
                            drawY = 240;
                        }
                    }
                    //e.Graphics.DrawRectangle(draw, 518, 260, 30, 20);
                    chairTwo = new Rectangle(518, 260, 30, 20);
                    if (chairTwo.IntersectsWith(mainCharacter))
                    {
                        if (drawY > 240)
                        {
                            drawY = 240;
                        }
                    }

                    //e.Graphics.DrawRectangle(draw, 458, 270, 100, 40);
                    tableCover1 = new Rectangle(458, 270, 5, 40);
                    tableCover2 = new Rectangle(458, 305, 100, 5);
                    tableCover3 = new Rectangle(553, 270, 5, 40);
                    if (tableCover1.IntersectsWith(mainCharacter))
                    {
                        if (drawX > 438)
                        {
                            drawX = 438;
                        }
                    }
                    if (tableCover2.IntersectsWith(mainCharacter))
                    {
                        if (drawY < 310)
                        {
                            drawY = 310;
                        }
                    }
                    if (tableCover3.IntersectsWith(mainCharacter))
                    {
                        if (drawX < 558)
                        {
                            drawX = 558;
                        }
                    }
                    ////Room 4
                    //e.Graphics.DrawRectangle(draw, 483, 55, 60, 20);
                    couchOneCover1 = new Rectangle(483, 55, 5, 20);
                    couchOneCover2 = new Rectangle(483, 55, 60, 3);
                    couchOneCover3 = new Rectangle(538, 55, 5, 20);
                    if (couchOneCover1.IntersectsWith(mainCharacter))
                    {
                        drawX = 463;
                    }
                    if (couchOneCover2.IntersectsWith(mainCharacter))
                    {
                        if (drawY > 25)
                        {
                            drawY = 25;
                        }
                    }
                    if (couchOneCover3.IntersectsWith(mainCharacter))
                    {
                        drawX = 543;
                    }
                    ////interactiveObjects(483, 155, 60, 20);
                    couchTwoCover1 = new Rectangle(483, 155, 5, 20);
                    couchTwoCover2 = new Rectangle(483, 172, 60, 3);
                    couchTwoCover3 = new Rectangle(538, 155, 5, 20);
                    if (couchTwoCover1.IntersectsWith(mainCharacter))
                    {
                        drawX = 463;
                    }
                    if (couchTwoCover2.IntersectsWith(mainCharacter))
                    {
                        if (drawY < 175)
                        {
                            drawY = 175;
                        }
                    }
                    if (couchTwoCover3.IntersectsWith(mainCharacter))
                    {
                        drawX = 543;
                    }
                    //e.Graphics.DrawRectangle(draw, 493, 75, 50, 40);
                    couchThree = new Rectangle(493, 75, 50, 40);
                    if (couchThree.IntersectsWith(mainCharacter))
                    {
                        drawX = 473;
                    }
                    //e.Graphics.DrawRectangle(draw, 493, 115, 50, 40);
                    couchFour = new Rectangle(493, 115, 50, 40);
                    if (couchFour.IntersectsWith(mainCharacter))
                    {
                        drawX = 473;
                    }
                    //e.Graphics.DrawRectangle(draw, 523, 75, 20, 80);
                    couchFive = new Rectangle(523, 75, 20, 80);
                    if (couchFive.IntersectsWith(mainCharacter))
                    {
                        drawX = 543;
                    }
                    //e.Graphics.DrawRectangle(draw, 363, 70, 20, 80);
                    tvCover1 = new Rectangle(363, 70, 3, 80);
                    tvCover2 = new Rectangle(363, 70, 20, 3);
                    tvCover3 = new Rectangle(380, 70, 3, 80);
                    tvCover4 = new Rectangle(363, 147, 20, 3);
                    if (tvCover1.IntersectsWith(mainCharacter))
                    {
                        if (drawX > 343)
                        {
                            drawX = 343;
                        }
                    }
                    if (tvCover2.IntersectsWith(mainCharacter))
                    {
                        drawY = 50;
                    }
                    if (tvCover3.IntersectsWith(mainCharacter))
                    {
                        drawX = 388;
                    }
                    if (tvCover4.IntersectsWith(mainCharacter))
                    {
                        drawY = 150;
                    }
                    //e.Graphics.DrawRectangle(draw, 708, 55, 20, 20);
                    officechair = new Rectangle(708, 55, 20, 20);
                    if (officechair.IntersectsWith(mainCharacter))
                    {
                        drawX = 688;
                    }
                    //e.Graphics.DrawRectangle(draw, 718, 25, 40, 80);
                    deskCover1 = new Rectangle(718, 25, 3, 80);
                    deskCover2 = new Rectangle(718, 25, 40, 3);
                    deskCover3 = new Rectangle(718, 102, 40, 3);
                    if (deskCover1.IntersectsWith(mainCharacter))
                    {
                        drawX = 698;
                    }
                    if (deskCover2.IntersectsWith(mainCharacter))
                    {
                        drawY = 5;
                    }
                    if (deskCover3.IntersectsWith(mainCharacter))
                    {
                        drawY = 105;
                    }
                    break;

                case 14:
                    bankmoneyLabel.Visible = false;
                    bankLabel.Visible = false;
                    workperfLabel.Visible = false;
                    hungerlabel.Visible = false;
                    hygienelabel.Visible = false;
                    loolabel.Visible = false;
                    entertainmentlabel.Visible = false;
                    imageO.Visible = false;
                    imageT.Visible = false;
                    titleLabel.Visible = false;
                    startLabel.Visible = false;
                    howtoplaylabel.Visible = false;
                    instructionlabel.Visible = false;

                    otherImage.Visible = true;
                    otherImage.Image = TheLifeSimulator.Properties.Resources.levelonegirl;
                    Graphics interact = this.CreateGraphics();
                    Font font = new Font("Arial", 12);
                    SolidBrush drawBrush = new SolidBrush(Color.Black);
                    interact.DrawString("Press Y to chat", Font, drawBrush, 100, 450);
                    break;

                case 15:

                    bankmoneyLabel.Visible = false;
                    bankLabel.Visible = false;
                    workperfLabel.Visible = false;
                    hungerlabel.Visible = false;
                    hygienelabel.Visible = false;
                    loolabel.Visible = false;
                    entertainmentlabel.Visible = false;
                    imageO.Visible = false;
                    imageT.Visible = false;
                    titleLabel.Visible = false;
                    startLabel.Visible = false;
                    howtoplaylabel.Visible = false;
                    instructionlabel.Visible = false;

                    interact = this.CreateGraphics();
                    font = new Font("Arial", 12);
                    drawBrush = new SolidBrush(Color.Black);

                    otherImage.Visible = true;
                    otherImage.Image = TheLifeSimulator.Properties.Resources.leveloneguy;
                    interact.DrawString("Press Y to chat", Font, drawBrush, 100, 450);

                    break;
                case 16:
                    bankmoneyLabel.Visible = false;
                    bankLabel.Visible = false;
                    workperfLabel.Visible = false;
                    hungerlabel.Visible = false;
                    hygienelabel.Visible = false;
                    loolabel.Visible = false;
                    entertainmentlabel.Visible = false;
                    imageO.Visible = false;
                    imageT.Visible = false;
                    titleLabel.Visible = false;
                    startLabel.Visible = false;
                    howtoplaylabel.Visible = false;
                    instructionlabel.Visible = false;

                    interact = this.CreateGraphics();
                    font = new Font("Arial", 12);
                    drawBrush = new SolidBrush(Color.Black);

                    otherImage.Visible = true;
                    otherImage.Image = TheLifeSimulator.Properties.Resources.leveltwogirl;
                    interact.DrawString("Press Y to chat", Font, drawBrush, 100, 450);
                    break; 

                case 17:
                    bankmoneyLabel.Visible = false;
                    bankLabel.Visible = false;
                    workperfLabel.Visible = false;
                    hungerlabel.Visible = false;
                    hygienelabel.Visible = false;
                    loolabel.Visible = false;
                    entertainmentlabel.Visible = false;
                    imageO.Visible = false;
                    imageT.Visible = false;
                    titleLabel.Visible = false;
                    startLabel.Visible = false;
                    howtoplaylabel.Visible = false;
                    instructionlabel.Visible = false;

                    interact = this.CreateGraphics();
                    font = new Font("Arial", 12);
                    drawBrush = new SolidBrush(Color.Black);

                    otherImage.Visible = true;
                    otherImage.Image = TheLifeSimulator.Properties.Resources.leveltwoguy;
                    interact.DrawString("Press Y to chat", Font, drawBrush, 100, 450);
                    break;
                case 18:
                    bankmoneyLabel.Visible = false;
                    bankLabel.Visible = false;
                    workperfLabel.Visible = false;
                    hungerlabel.Visible = false;
                    hygienelabel.Visible = false;
                    loolabel.Visible = false;
                    entertainmentlabel.Visible = false;
                    imageO.Visible = false;
                    imageT.Visible = false;
                    titleLabel.Visible = false;
                    startLabel.Visible = false;
                    howtoplaylabel.Visible = false;
                    instructionlabel.Visible = false;

                    interact = this.CreateGraphics();
                    font = new Font("Arial", 12);
                    drawBrush = new SolidBrush(Color.Black);

                    otherImage.Visible = true;
                    otherImage.Image = TheLifeSimulator.Properties.Resources.levelonegirl;
                    interact.DrawString("Press Y to chat", Font, drawBrush, 100, 450);
                    break;
                case 19:
                    bankmoneyLabel.Visible = false;
                    bankLabel.Visible = false;
                    workperfLabel.Visible = false;
                    hungerlabel.Visible = false;
                    hygienelabel.Visible = false;
                    loolabel.Visible = false;
                    entertainmentlabel.Visible = false;
                    imageO.Visible = false;
                    imageT.Visible = false;
                    titleLabel.Visible = false;
                    startLabel.Visible = false;
                    howtoplaylabel.Visible = false;
                    instructionlabel.Visible = false;

                    interact = this.CreateGraphics();
                    font = new Font("Arial", 12);
                    drawBrush = new SolidBrush(Color.Black);

                    otherImage.Visible = true;
                    otherImage.Image = TheLifeSimulator.Properties.Resources.leveloneguy;
                    interact.DrawString("Press Y to chat", Font, drawBrush, 100, 450);
                    break;

                case 20:
                    bankmoneyLabel.Visible = false;
                    bankLabel.Visible = false;
                    workperfLabel.Visible = false;
                    hungerlabel.Visible = false;
                    hygienelabel.Visible = false;
                    loolabel.Visible = false;
                    entertainmentlabel.Visible = false;
                    imageO.Visible = false;
                    imageT.Visible = false;
                    titleLabel.Visible = false;
                    startLabel.Visible = false;
                    howtoplaylabel.Visible = false;
                    instructionlabel.Visible = false;

                    interact = this.CreateGraphics();
                    font = new Font("Arial", 12);
                    drawBrush = new SolidBrush(Color.Black);

                    otherImage.Visible = true;
                    otherImage.Image = TheLifeSimulator.Properties.Resources.leveltwogirl;
                    interact.DrawString("Press Y to chat", Font, drawBrush, 100, 450);
                    break;

                case 21:
                    bankmoneyLabel.Visible = false;
                    bankLabel.Visible = false;
                    workperfLabel.Visible = false;
                    hungerlabel.Visible = false;
                    hygienelabel.Visible = false;
                    loolabel.Visible = false;
                    entertainmentlabel.Visible = false;
                    imageO.Visible = false;
                    imageT.Visible = false;
                    titleLabel.Visible = false;
                    startLabel.Visible = false;
                    howtoplaylabel.Visible = false;
                    instructionlabel.Visible = false;

                    interact = this.CreateGraphics();
                    font = new Font("Arial", 12);
                    drawBrush = new SolidBrush(Color.Black);

                    otherImage.Visible = true;
                    otherImage.Image = TheLifeSimulator.Properties.Resources.leveltwoguy;
                    interact.DrawString("Press Y to chat", Font, drawBrush, 100, 450);
                    break;

                //Interaction Reaction
                case 22:
                    imageT.Size = new Size(746, 385);
                    imageT.Image = TheLifeSimulator.Properties.Resources.levelonegirl;
                    instructionlabel.Visible = true;
                    startLabel.Visible = true;
                    interact = this.CreateGraphics();
                    font = new Font("Arial", 12);
                    drawBrush = new SolidBrush(Color.Black);
                    if (hygiene > 20 && hunger > 50 && bankSavings > 250)
                    {
                        interact.DrawString("Character accepts to chat with you", Font, drawBrush, 100, 450);
                        interact.DrawString("Press U to escape", Font, drawBrush, 100, 470);
                    }
                    else
                    {
                        interact.DrawString("Your character is rejected", Font, drawBrush, 100, 450);
                        interact.DrawString("Press U to escape", Font, drawBrush, 100, 470);
                    }
                    break;
                case 23:
                    imageT.Size = new Size(746, 385);
                    imageT.Image = TheLifeSimulator.Properties.Resources.leveloneguy;
                    instructionlabel.Visible = true;
                    startLabel.Visible = true;
                    interact = this.CreateGraphics();
                    font = new Font("Arial", 12);
                    drawBrush = new SolidBrush(Color.Black);
                    if (hygiene > 20 && hunger > 50 && bankSavings > 250)
                    {
                        interact.DrawString("Character accepts to chat with you", Font, drawBrush, 100, 450);
                        interact.DrawString("Press U to escape", Font, drawBrush, 100, 470);
                    }
                    else
                    {
                        interact.DrawString("Your character is rejected", Font, drawBrush, 100, 450);
                        interact.DrawString("Press U to escape", Font, drawBrush, 100, 470);
                    }
                    break;
                case 24:
                    imageT.Size = new Size(746, 385);
                    imageT.Image = TheLifeSimulator.Properties.Resources.leveltwogirl;
                    instructionlabel.Visible = true;
                    startLabel.Visible = true;
                    interact = this.CreateGraphics();
                    font = new Font("Arial", 12);
                    drawBrush = new SolidBrush(Color.Black);
                    if (hygiene > 20 && hunger > 50 && bankSavings > 750)
                    {
                        interact.DrawString("Character accepts to chat with you", Font, drawBrush, 100, 450);
                        interact.DrawString("Press U to escape", Font, drawBrush, 100, 470);
                    }
                    else
                    {
                        interact.DrawString("Your character is rejected", Font, drawBrush, 100, 450);
                        interact.DrawString("Press U to escape", Font, drawBrush, 100, 470);
                    }
                    break;
                case 25:
                    imageT.Size = new Size(746, 385);
                    imageT.Image = TheLifeSimulator.Properties.Resources.leveltwoguy;
                    instructionlabel.Visible = true;
                    startLabel.Visible = true;
                    interact = this.CreateGraphics();
                    font = new Font("Arial", 12);
                    drawBrush = new SolidBrush(Color.Black);
                    if (hygiene > 20 && hunger > 50 && bankSavings > 750)
                    {
                        interact.DrawString("Character accepts to chat with you", Font, drawBrush, 100, 450);
                        interact.DrawString("Press U to escape", Font, drawBrush, 100, 470);
                    }
                    else
                    {
                        interact.DrawString("Your character is rejected", Font, drawBrush, 100, 450);
                        interact.DrawString("Press U to escape", Font, drawBrush, 100, 470);
                    }
                    break;
                case 26:
                    imageT.Size = new Size(746, 385);
                    imageT.Image = TheLifeSimulator.Properties.Resources.levelonegirl;
                    instructionlabel.Visible = true;
                    startLabel.Visible = true;
                    interact = this.CreateGraphics();
                    font = new Font("Arial", 12);
                    drawBrush = new SolidBrush(Color.Black);
                    if (hygiene > 20 && hunger > 50 && bankSavings > 250)
                    {
                        interact.DrawString("Character accepts to chat with you", Font, drawBrush, 100, 450);
                        interact.DrawString("Press U to escape", Font, drawBrush, 100, 470);
                    }
                    else
                    {
                        interact.DrawString("Your character is rejected", Font, drawBrush, 100, 450);
                        interact.DrawString("Press U to escape", Font, drawBrush, 100, 470);
                    }
                    break;
                case 27:
                    imageT.Size = new Size(746, 385);
                    imageT.Image = TheLifeSimulator.Properties.Resources.leveloneguy;
                    instructionlabel.Visible = true;
                    startLabel.Visible = true;
                    interact = this.CreateGraphics();
                    font = new Font("Arial", 12);
                    drawBrush = new SolidBrush(Color.Black);
                    if (hygiene > 20 && hunger > 50 && bankSavings > 250)
                    {
                        interact.DrawString("Character accepts to chat with you", Font, drawBrush, 100, 450);
                        interact.DrawString("Press U to escape", Font, drawBrush, 100, 470);
                    }
                    else
                    {
                        interact.DrawString("Your character is rejected", Font, drawBrush, 100, 450);
                        interact.DrawString("Press U to escape", Font, drawBrush, 100, 470);
                    }
                    break;
                case 28:
                    imageT.Size = new Size(746, 385);
                    imageT.Image = TheLifeSimulator.Properties.Resources.leveltwogirl;
                    instructionlabel.Visible = true;
                    startLabel.Visible = true;
                    interact = this.CreateGraphics();
                    font = new Font("Arial", 12);
                    drawBrush = new SolidBrush(Color.Black);
                    if (hygiene > 20 && hunger > 50 && bankSavings > 750)
                    {
                        interact.DrawString("Character accepts to chat with you", Font, drawBrush, 100, 450);
                        interact.DrawString("Press U to escape", Font, drawBrush, 100, 470);
                    }
                    else
                    {
                        interact.DrawString("Your character is rejected", Font, drawBrush, 100, 450);
                        interact.DrawString("Press U to escape", Font, drawBrush, 100, 470);
                    }
                    break;
                case 29:
                    imageT.Size = new Size(746, 385);
                    imageT.Image = TheLifeSimulator.Properties.Resources.leveltwoguy;
                    instructionlabel.Visible = true;
                    startLabel.Visible = true;
                    interact = this.CreateGraphics();
                    font = new Font("Arial", 12);
                    drawBrush = new SolidBrush(Color.Black);
                    if (hygiene > 20 && hunger > 50 && bankSavings > 750)
                    {
                        interact.DrawString("Character accepts to chat with you", Font, drawBrush, 100, 450);
                        interact.DrawString("Press U to escape", Font, drawBrush, 100, 470);
                    }
                    else
                    {
                        interact.DrawString("Your character is rejected", Font, drawBrush, 100, 450);
                        interact.DrawString("Press U to escape", Font, drawBrush, 100, 470);
                    }
                    break;

            }

        }
    }
}
