using System;
using System.Windows.Forms;
using System.Threading;
using System.ComponentModel;
using System.Collections;
using System.Data;
using System.Drawing;

public class Airport : Form
{
    private Container components = null;
    private ButtonPanelThread p1, p2, p3, p10;
    private Button btn1, btn2, btn3, btn4;
    private WaitPanelThread p4, p5, p6, p7, p8, p9;
    private Thread thread1, thread2, thread3, thread4, thread5, thread6, thread7, thread8, thread9, thread10;
    private Semaphore semaphore1, semaphore2, semaphore3, semaphore4, semaphore5, semaphore6, semaphore7, semaphore8, semaphore9, semaphore10;
    private Buffer buffer1, buffer2, buffer3, buffer4, buffer5, buffer6, buffer7, buffer8, buffer9, buffer10;
    //private Thread semThread1, semThread2, semThread3, semThread4, semThread5, semThread6, semThread7, semThread8, semThread9;
    //private Thread buffThread1, buffThread2, buffThread3, buffThread4, buffThread5, buffThread6, buffThread7, buffThread8, buffThread9;
    private Panel pnl1, pnl2, pnl3, pnl4, pnl5, pnl6, pnl7, pnl8, pnl9, pnl10;
    private GroupBox destinationRadGroup;
    private RadioButton takeOffRadBtn, hub1RadBtn, hub2RadBtn, hub3RadBtn;

    public Airport()
    {
        InitializeComponent();

        //Semaphore Declarations
        semaphore1  = new Semaphore();
        semaphore2  = new Semaphore();
        semaphore3  = new Semaphore();
        semaphore4  = new Semaphore();
        semaphore5  = new Semaphore();
        semaphore6  = new Semaphore();
        semaphore7  = new Semaphore();
        semaphore8  = new Semaphore();
        semaphore9  = new Semaphore();
        semaphore10 = new Semaphore();


        //Buffer Declarations
        buffer1  = new Buffer(1);
        buffer2  = new Buffer(2);
        buffer3  = new Buffer(3);
        buffer4  = new Buffer(4);
        buffer5  = new Buffer(5);
        buffer6  = new Buffer(6);
        buffer7  = new Buffer(7);
        buffer8  = new Buffer(8);
        buffer9  = new Buffer(9);
        buffer10 = new Buffer(10);


        //Panel Declarations
        //Button Panel Declarations
        //Plane Hubs
        p1 = new ButtonPanelThread(new Point(10, 40), 100, true, pnl1, Color.Red, 2, semaphore1, semaphore4, buffer1, buffer4, btn1);
        p2 = new ButtonPanelThread(new Point(10, 40), 100, true, pnl2, Color.Blue, 2, semaphore2, semaphore5, buffer2, buffer5, btn2);
        p3 = new ButtonPanelThread(new Point(10, 40), 100, true, pnl3, Color.Yellow, 2, semaphore3, semaphore6, buffer3, buffer6, btn3);

        //Arrival Hub
        p10 = new ButtonPanelThread(new Point(0, 10), 100, true, pnl10, Color.Green,  3, semaphore10, semaphore8, buffer10, buffer8, btn4);

        //Wait Panel Declarations
        p4 = new WaitPanelThread(new Point(0, 10),   100, true, pnl4, Color.White, 4, semaphore4, semaphore5, semaphore2, buffer4, buffer5, buffer2);
        p5 = new WaitPanelThread(new Point(0, 10),   100, true, pnl5, Color.White, 4, semaphore5, semaphore6, semaphore3, buffer5, buffer6, buffer3);
        p6 = new WaitPanelThread(new Point(0, 10),   100, true, pnl6, Color.White, 4, semaphore6, semaphore7, buffer6, buffer7);
        p7 = new WaitPanelThread(new Point(10, 0),   100, true, pnl7, Color.White, 2, semaphore7, semaphore8, buffer7, buffer8);
        p8 = new WaitPanelThread(new Point(780, 10), 100, true, pnl8, Color.White, 3, semaphore8, semaphore9, buffer8, buffer9);
        p9 = new WaitPanelThread(new Point(10, 260), 100, true, pnl9, Color.White, 1, semaphore9, semaphore4, semaphore1, buffer9, buffer4, buffer1);

        ////Semaphore Thread Declarations
        //semThread1 = new Thread(new ThreadStart(semaphore4.Start));
        //semThread2 = new Thread(new ThreadStart(semaphore5.Start));
        //semThread3 = new Thread(new ThreadStart(semaphore6.Start));
        //semThread4 = new Thread( new ThreadStart(semaphore4.Start));
        //semThread5 = new Thread( new ThreadStart(semaphore5.Start));
        //semThread6 = new Thread( new ThreadStart(semaphore6.Start));
        //semThread7 = new Thread( new ThreadStart(semaphore7.Start));
        //semThread8 = new Thread( new ThreadStart(semaphore8.Start));
        //semThread9 = new Thread( new ThreadStart(semaphore9.Start));

        ////Buffer Thread Declarations
        //buffThread1 = new Thread(new ThreadStart(buffer4.Start));
        //buffThread2 = new Thread(new ThreadStart(buffer5.Start));
        //buffThread3 = new Thread(new ThreadStart(buffer6.Start));
        //buffThread4 = new Thread( new ThreadStart(buffer4.Start));
        //buffThread5 = new Thread( new ThreadStart(buffer5.Start));
        //buffThread6 = new Thread( new ThreadStart(buffer6.Start));
        //buffThread7 = new Thread( new ThreadStart(buffer7.Start));
        //buffThread8 = new Thread( new ThreadStart(buffer8.Start));
        //buffThread9 = new Thread( new ThreadStart(buffer9.Start));

        //Thread Declarations
        thread1  = new Thread(new ThreadStart(p1.Start));
        thread2  = new Thread(new ThreadStart(p2.Start));
        thread3  = new Thread(new ThreadStart(p3.Start));
        thread4  = new Thread(new ThreadStart(p4.Start));
        thread5  = new Thread(new ThreadStart(p5.Start));
        thread6  = new Thread(new ThreadStart(p6.Start));
        thread7  = new Thread(new ThreadStart(p7.Start));
        thread8  = new Thread(new ThreadStart(p8.Start));
        thread9  = new Thread(new ThreadStart(p9.Start));
        thread10 = new Thread(new ThreadStart(p10.Start));

        this.Closing += new CancelEventHandler(this.Form1_Closing);

        //semThread4.Start();
        //semThread5.Start();
        //semThread6.Start();
        //semThread7.Start();
        //semThread8.Start();
        //semThread9.Start();

        //buffThread4.Start();
        //buffThread5.Start();
        //buffThread6.Start();
        //buffThread7.Start();
        //buffThread8.Start(); 
        //buffThread9.Start();

        //???????? What are these needed for

        thread1.Start();
        thread2.Start();
        thread3.Start();
        thread4.Start();
        thread5.Start();
        thread6.Start();
        thread7.Start();
        thread8.Start();
        thread9.Start();
        thread10.Start();
    }

    protected override void Dispose(bool disposing)
    {
        if (disposing)
        {
            if (components != null)
            {
                components.Dispose();
            }
        }

        base.Dispose(disposing);
    }

    private void InitializeComponent()
    {
        this.Text = "Bermuda Triangle Airways";
        this.Size = new System.Drawing.Size(950, 700);
        this.BackColor = Color.LightGray;

        //Button Panels
        this.pnl1 = new Panel();
        this.pnl1.Location = new Point(50, 50);
        this.pnl1.Size = new Size(30, 260);
        this.pnl1.BackColor = Color.White;

        this.btn1 = new Button();
        this.btn1.Size = new Size(30, 30);
        this.btn1.BackColor = Color.Pink;
        this.btn1.Location = new System.Drawing.Point(0, 0);

        this.pnl2 = new Panel();
        this.pnl2.Location = new Point(310, 50);
        this.pnl2.Size = new Size(30, 260);
        this.pnl2.BackColor = Color.White;

        this.btn2 = new Button();
        this.btn2.Size = new Size(30, 30);
        this.btn2.BackColor = Color.Pink;
        this.btn2.Location = new System.Drawing.Point(0, 0);

        this.pnl3 = new Panel();
        this.pnl3.Location = new Point(570, 50);
        this.pnl3.Size = new Size(30, 260);
        this.pnl3.BackColor = Color.White;

        this.btn3 = new Button();
        this.btn3.Size = new Size(30, 30);
        this.btn3.BackColor = Color.Pink;
        this.btn3.Location = new System.Drawing.Point(0, 0);

        this.pnl10 = new Panel();
        this.pnl10.Location = new Point(830, 600);
        this.pnl10.Size = new Size(60, 30);
        this.pnl10.BackColor = Color.White;

        this.btn4 = new Button();
        this.btn4.Size = new Size(30, 30);
        this.btn4.BackColor = Color.Pink;
        this.btn4.Location = new System.Drawing.Point(30, 0);

        //Wait Panels
        this.pnl4 = new Panel();
        this.pnl4.Location = new Point(50, 310);
        this.pnl4.Size = new Size(260, 30);
        this.pnl4.BackColor = Color.White;

        this.pnl5 = new Panel();
        this.pnl5.Location = new Point(310, 310);
        this.pnl5.Size = new Size(260, 30);
        this.pnl5.BackColor = Color.White;

        this.pnl6 = new Panel();
        this.pnl6.Location = new Point(570, 310);
        this.pnl6.Size = new Size(260, 30);
        this.pnl6.BackColor = Color.White;

        this.pnl7 = new Panel();
        this.pnl7.Location = new Point(800, 340);
        this.pnl7.Size = new Size(30, 260);
        this.pnl7.BackColor = Color.White;

        this.pnl8 = new Panel();
        this.pnl8.Location = new Point(50, 600);
        this.pnl8.Size = new Size(780, 30);
        this.pnl8.BackColor = Color.White;

        this.pnl9 = new Panel();
        this.pnl9.Location = new Point(50, 340);
        this.pnl9.Size = new Size(30, 260);
        this.pnl9.BackColor = Color.White;


        //Destination Radio Button Group
        this.destinationRadGroup = new System.Windows.Forms.GroupBox();

        this.takeOffRadBtn       = new System.Windows.Forms.RadioButton();
        this.hub1RadBtn          = new System.Windows.Forms.RadioButton();
        this.hub2RadBtn          = new System.Windows.Forms.RadioButton();
        this.hub3RadBtn          = new System.Windows.Forms.RadioButton();

        // destinationRadGroup
        this.destinationRadGroup.Controls.Add(this.hub3RadBtn);
        this.destinationRadGroup.Controls.Add(this.hub2RadBtn);
        this.destinationRadGroup.Controls.Add(this.hub1RadBtn);
        this.destinationRadGroup.Controls.Add(this.takeOffRadBtn);

        this.destinationRadGroup.Location = new System.Drawing.Point(836, 478);
        this.destinationRadGroup.Size = new System.Drawing.Size(95, 116);
        this.destinationRadGroup.Text = "Destination";

        // takeOffRadBtn
        this.takeOffRadBtn.Checked = true;
        this.takeOffRadBtn.Location = new System.Drawing.Point(4, 20);
        this.takeOffRadBtn.Size = new System.Drawing.Size(67, 17);
        this.takeOffRadBtn.Text = "Take Off";
        this.takeOffRadBtn.CheckedChanged += new System.EventHandler(this.takeOffRadBtn_CheckedChanged);

        // hub1RadBtn
        this.hub1RadBtn.Location = new System.Drawing.Point(4, 44);
        this.hub1RadBtn.Size = new System.Drawing.Size(68, 17);
        this.hub1RadBtn.Text = "Hub One";
        this.hub1RadBtn.CheckedChanged += new System.EventHandler(this.hub1RadBtn_CheckedChanged);

        // hub2RadBtn
        this.hub2RadBtn.Location = new System.Drawing.Point(4, 68);
        this.hub2RadBtn.Size = new System.Drawing.Size(69, 17);
        this.hub2RadBtn.Text = "Hub Two";
        this.hub2RadBtn.CheckedChanged += new System.EventHandler(this.hub2RadBtn_CheckedChanged);

        // hub3RadBtn
        this.hub3RadBtn.Location = new System.Drawing.Point(4, 90);
        this.hub3RadBtn.Size = new System.Drawing.Size(76, 17);
        this.hub3RadBtn.Text = "Hub Three";
        this.hub3RadBtn.CheckedChanged += new System.EventHandler(this.hub3RadBtn_CheckedChanged);

        //Add Controls
        this.Controls.Add(this.destinationRadGroup);

        this.Controls.Add(pnl1);
        this.Controls.Add(pnl2);
        this.Controls.Add(pnl3);
        this.Controls.Add(pnl4);
        this.Controls.Add(pnl5);
        this.Controls.Add(pnl6);
        this.Controls.Add(pnl7);
        this.Controls.Add(pnl8);
        this.Controls.Add(pnl9);
        this.Controls.Add(pnl10);

        //Add Button Controls
        this.pnl1.Controls.Add(btn1);
        this.pnl2.Controls.Add(btn2);
        this.pnl3.Controls.Add(btn3);
        this.pnl10.Controls.Add(btn4);

        this.Closing += new CancelEventHandler(this.Form1_Closing);
    }

    private void Form1_Closing(object sender, CancelEventArgs e)
    {
        Environment.Exit(Environment.ExitCode);
    }

    private void takeOffRadBtn_CheckedChanged(object sender, EventArgs e)
    {
        p10.setDestination(0);
    }

    private void hub1RadBtn_CheckedChanged(object sender, EventArgs e)
    {
        p10.setDestination(1);
        p1.hubOpen = true;
    }

    private void hub2RadBtn_CheckedChanged(object sender, EventArgs e)
    {
        p10.setDestination(2);
        p2.hubOpen = true;
    }

    private void hub3RadBtn_CheckedChanged(object sender, EventArgs e)
    {
        p10.setDestination(3);
        p3.hubOpen = true;
    }
}

public class Buffer
{
    private Color planeColor; 
    private bool empty = true;
    private int planeDestination;
    private int bufferIDNum;

    public Buffer(int bufferIDNum)
    {
        empty = true;
        planeDestination = -1;
        this.bufferIDNum = bufferIDNum;
    }

    public void Read(ref Color planeColor)
    {
        lock(this)
        {
            if (empty)
            {
                Monitor.Wait(this);
            }

            empty = true;
            planeColor = this.planeColor;
            Monitor.Pulse(this);
        }
    }

    public void Write(Color planeColor)
    {
        lock (this)
        {
            if (!empty)
            {
                Monitor.Wait(this);
            }

            empty = false;
            this.planeColor = planeColor;
            Monitor.Pulse(this);
        }
    }

    public void WriteDestination(int planeDestination)
    {
        this.planeDestination = planeDestination;
    }

    public int ReadDestination()
    {
        return planeDestination;
    }

    public int ReadBufferIDNum()
    {
        return bufferIDNum;
    }
         
    public void Start()
    {
    }
}

public class Semaphore
{
    private int count = 1;

    public void Wait()
    {
        lock(this)
        {
            while (count == 0)
            {
                Monitor.Wait(this);
            }

            count = 0;
        }
    }

    public void Signal()
    { 
        lock(this)
        { 
            count = 1;
            Monitor.Pulse(this);
        }
    }
         
    public void Start()
    {
    }
}

public class ButtonPanelThread
{
    private Point       origin;
    private int         delay;
    private Panel       panel;
    private Color       colour;
    private Point       plane;
    private int         xDelta;
    private int         yDelta;
    private Semaphore   semaphoreThis;
    private Semaphore   semaphoreNext;
    private Buffer      bufferThis;
    private Buffer      bufferNext;
    private Button      btn;
    private bool        locked = true;
    private bool        hubFull = true;
    public  bool        hubOpen = false;
    private int         planeMoves;
    private int         direction;
    private int         planeDestination;
      
    public ButtonPanelThread(Point       origin,
                             int         delay,
                             bool        sectionActive,
                             Panel       panel,
                             Color       colour,
                             int         direction,
                             Semaphore   semaphoreThis,
                             Semaphore   semaphoreNext,
                             Buffer      bufferThis,
                             Buffer      bufferNext,
                             Button      btn)
    {
        this.origin        = origin;
        this.delay         = delay;
        this.panel         = panel;
        this.colour        = colour;
        this.plane         = origin;
        this.direction     = direction;
        this.panel.Paint  += new PaintEventHandler(this.panel_Paint);

        planeDestination = 0;
        planeMoves = 20;

        switch (direction)
        {
            case 1:
                this.xDelta = 0;
                this.yDelta = -10;
                break;

            case 2:
                this.xDelta = 0;
                this.yDelta = +10;
                break;

            case 3:
                this.xDelta = -10;
                this.yDelta = 0;
                planeMoves  = 1;
                this.delay  = 30;
                break;

            case 4:
                this.xDelta = +10;
                this.yDelta = 0;
                break;
        }

        this.semaphoreNext = semaphoreNext;
        this.semaphoreThis = semaphoreThis;
        this.bufferNext = bufferNext;
        this.bufferThis = bufferThis;
        this.btn = btn;
        this.btn.Click += new System.EventHandler(this.btn_Click);
    }

    private void btn_Click(object sender, System.EventArgs e)
    {
        if (hubFull)
        {
            locked = !locked;
            this.btn.BackColor = locked ? Color.Pink : Color.LightGreen;

            lock (this)
            {
                if (!locked)
                {
                    Monitor.Pulse(this);
                }
            }
        }
    }

    public void Start()
    {
        Color signal = Color.Red;
        Thread.Sleep(delay);
          
        while(hubFull)
        {
            if (colour != Color.Empty)
            {
                this.zeroPlane();
                panel.Invalidate();

                if (hubOpen)
                {
                    bufferThis.Read(ref this.colour);
                }

                if (!hubOpen)
                {
                    lock (this)
                    {
                        while (locked)
                        {
                            Monitor.Wait(this);
                        }
                    }
                }

                for (int i = 1; i <= planeMoves; i++)
                {
                    this.movePlane(xDelta, yDelta);
                    Thread.Sleep(delay);
                    panel.Invalidate();
                }

                semaphoreNext.Wait();
                bufferNext.Write(this.colour);
                bufferNext.WriteDestination(planeDestination);
                colour = Color.Empty;
                panel.Invalidate();
                semaphoreThis.Signal();
            }
        }
    }

    private void zeroPlane( )
    {
        plane.X = origin.X; 
        plane.Y = origin.Y;
    }

    private void movePlane(int xDelta, int yDelta)
    {
        plane.X += xDelta;
        plane.Y += yDelta;
    }

    public void setDestination(int destination)
    {
        this.planeDestination = destination;
    }

    private void panel_Paint( object sender, PaintEventArgs e)
    {
        Graphics g = e.Graphics;
          
        SolidBrush brush = new SolidBrush(colour);
        g.FillRectangle(brush, plane.X, plane.Y, 10, 10);

        brush.Dispose();
        g.Dispose();
    } 
}

public class WaitPanelThread
{
    private Point      origin;
    private int        delay;
    private Panel      panel;
    private Color      colour;
    private Point      plane;
    private int        xDelta;
    private int        yDelta;
    private int        direction;
    private Semaphore  semaphoreThis;
    private Semaphore  semaphoreNext;
    private Semaphore  semaphoreNext2;
    private Buffer     bufferThis;
    private Buffer     bufferNext;
    private Buffer     bufferNext2;
    private int        planeMoves;
    private int        destination;
    private bool       sectionActive;


    public WaitPanelThread(Point       origin,
                           int         delay,
                           bool        sectionActive,
                           Panel       panel,
                           Color       colour,
                           int         direction,
                           Semaphore   semaphoreThis,
                           Semaphore   semaphoreNext,
                           Buffer      bufferThis,
                           Buffer      bufferNext)
    { 
        this.origin        = origin;
        this.delay         = delay;
        this.panel         = panel;
        this.colour        = colour;
        this.plane         = origin;
        this.panel.Paint  += new PaintEventHandler(this.panel_Paint);
        this.sectionActive = sectionActive;

        destination = 0;
        planeMoves = 25;

        switch(direction)
        {
            case 1:
                this.xDelta = 0;
                this.yDelta = -10;
                break;

            case 2:
                this.xDelta = 0;
                this.yDelta = +10;
                break;

            case 3:
                this.xDelta = -10;
                this.yDelta = 0;
                planeMoves = 78;
                this.delay = 30;
                break;

            case 4:
                this.xDelta = +10;
                this.yDelta = 0;
                break;
        }
       
        this.direction = direction;
        this.semaphoreThis = semaphoreThis;
        this.semaphoreNext = semaphoreNext;
        this.bufferThis = bufferThis;
        this.bufferNext = bufferNext;

        bufferNext2 = null;
        semaphoreNext2 = null;
    }

    public WaitPanelThread(Point origin,
                           int delay,
                           bool sectionActive,
                           Panel panel,
                           Color colour,
                           int direction,
                           Semaphore semaphoreThis,
                           Semaphore semaphoreNext,
                           Semaphore semaphoreNext2,
                           Buffer bufferThis,
                           Buffer bufferNext,
                           Buffer bufferNext2)
    {
        this.origin = origin;
        this.delay = delay;
        this.panel = panel;
        this.colour = colour;
        this.plane = origin;
        this.panel.Paint += new PaintEventHandler(this.panel_Paint);
        this.sectionActive = sectionActive;

        destination = 0;
        planeMoves = 25;

        switch (direction)
        {
            case 1:
                this.xDelta = 0;
                this.yDelta = -10;
                break;

            case 2:
                this.xDelta = 0;
                this.yDelta = +10;
                break;

            case 3:
                this.xDelta = -10;
                this.yDelta = 0;
                planeMoves = 78;
                this.delay = 30;
                break;

            case 4:
                this.xDelta = +10;
                this.yDelta = 0;
                break;
        }

        this.direction = direction;
        this.semaphoreThis = semaphoreThis;
        this.semaphoreNext = semaphoreNext;
        this.semaphoreNext = semaphoreNext2;
        this.bufferThis = bufferThis;
        this.bufferNext = bufferNext;
        this.bufferNext2 = bufferNext2;
    }

    public void Start()
    {
        this.colour = Color.White;

        while(sectionActive)
        {
            if (colour != Color.Empty)
            {
                this.zeroPlane();
                bufferThis.Read(ref this.colour);
                panel.Invalidate();
                destination = bufferThis.ReadDestination();

                for (int i = 1; i <= planeMoves; i++)
                {
                    this.movePlane(xDelta, yDelta);
                    Thread.Sleep(delay);
                    panel.Invalidate();
                }

                if (bufferNext2 != null && bufferThis.ReadDestination() == bufferNext2.ReadBufferIDNum())
                {
                    semaphoreNext.Wait();
                    semaphoreThis.Signal();
                    bufferNext2.Write(this.colour);
                    bufferNext2.WriteDestination(destination);
                    panel.Invalidate();
                }
                else
                {
                    semaphoreNext.Wait();
                    bufferNext.Write(this.colour);
                    this.colour = Color.Empty;
                    //bufferNext.WriteDestination(destination);
                    semaphoreThis.Signal();
                    panel.Invalidate();
                }
            }
        }
    }

    private void zeroPlane( )
    {
        plane.X = origin.X; 
        plane.Y = origin.Y;
    }

    private void movePlane(int xDelta, int yDelta)
    {
        plane.X += xDelta; 
        plane.Y += yDelta;
    }

    private void panel_Paint( object sender, PaintEventArgs e)
    {
        Graphics g = e.Graphics;
        SolidBrush brush = new SolidBrush(colour);
        g.FillRectangle(brush, plane.X, plane.Y, 10, 10);
        brush.Dispose();
        g.Dispose(); 
    } 
}

public class CNA_Assignment
{
    public static void Main()
    {
        Application.Run(new Airport());
    }
}