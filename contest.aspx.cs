using System;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Formatters.Binary;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.IO;
using System.Collections.Generic;

[Serializable]
public class Contest
{
    public enum Color { red, blue, gray, green, brown, purple, yellow, silver, white, terracotta };
    public int red { get; set; }
    public int blue { get; set; }
    public int gray { get; set; }
    public int green { get; set; }
    public int brown { get; set; }
    public int purple { get; set; }
    public int yellow { get; set; }
    public int silver { get; set; }
    public int white { get; set; }
    public int terracotta { get; set; }
    public int total { get; set; }
    public List<string> emails;

    public Contest()
    {
        red = 0;
        blue = 0;
        gray = 0;
        green = 0;
        brown = 0;
        purple = 0;
        yellow = 0;
        silver = 0;
        white = 0;
        terracotta = 0;
        total = 0;
        emails = new List<string>();
        readEmails();
        readResults();
    }

    public void addColor(Color c)
    {
        if (c == Color.red)
        {
            red++;
            total++;
        }
        if (c == Color.blue)
        {
            blue++;
            total++;
        }
        if (c == Color.gray)
        {
            gray++;
            total++;
        }
        if (c == Color.green)
        {
            green++;
            total++;
        }
        if (c == Color.brown)
        {
            brown++;
            total++;
        }
        if (c == Color.purple)
        {
            purple++;
            total++;
        }
        if (c == Color.yellow)
        {
            yellow++;
            total++;
        }
        if (c == Color.silver)
        {
            silver++;
            total++;
        }
        if (c == Color.white)
        {
            white++;
            total++;
        }
        if (c == Color.terracotta)
        {
            terracotta++;
            total++;
        }
    }

    public void writeEmails()
    {
        using (System.IO.StreamWriter file = new System.IO.StreamWriter("C:/inetpub/wwwroot/Contest/emails.txt"))
        {
            foreach (string e in emails)
            {
                file.WriteLine(e);
            }
        }
    }

    public void readEmails()
    {
        string line;
        using (System.IO.StreamReader file = new System.IO.StreamReader("C:/inetpub/wwwroot/Contest/emails.txt"))
        {
            while((line = file.ReadLine()) != null)
            {
                this.emails.Add(line);
            }
        }
    }

    public void readResults()
    {
        using (System.IO.StreamReader file = new System.IO.StreamReader("C:/inetpub/wwwroot/Contest/results.txt"))
        {
            this.red = Int32.Parse(file.ReadLine());
            this.blue = Int32.Parse(file.ReadLine());
            this.gray = Int32.Parse(file.ReadLine());
            this.green = Int32.Parse(file.ReadLine());
            this.brown = Int32.Parse(file.ReadLine());
            this.purple = Int32.Parse(file.ReadLine());
            this.yellow = Int32.Parse(file.ReadLine());
            this.silver = Int32.Parse(file.ReadLine());
            this.white = Int32.Parse(file.ReadLine());
            this.terracotta = Int32.Parse(file.ReadLine());
            this.total = this.red + this.blue + this.gray + this.green + this.brown + this.purple + this.yellow + this.silver + this.white + this.terracotta;
        }
    }

    public void writeResults()
    {
        using (System.IO.StreamWriter file = new System.IO.StreamWriter("C:/inetpub/wwwroot/Contest/results.txt"))
        {
            file.WriteLine(this.red);
            file.WriteLine(this.blue);
            file.WriteLine(this.gray);
            file.WriteLine(this.green);
            file.WriteLine(this.brown);
            file.WriteLine(this.purple);
            file.WriteLine(this.yellow);
            file.WriteLine(this.silver);
            file.WriteLine(this.white);
            file.WriteLine(this.terracotta);
        }
    }
}

public partial class _Default : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {

    }

    protected void serverVal(object source, ServerValidateEventArgs args)
    {
        args.IsValid = blue.Checked || red.Checked || gray.Checked || green.Checked || brown.Checked || terracotta.Checked || purple.Checked || silver.Checked || white.Checked || yellow.Checked;
    }
    protected void Submit_Click(object sender, EventArgs e)
    {
        if (Page.IsValid)
        {
            //Load results if exists
            Contest results = new Contest();

            if (blue.Checked)
            {
                results.addColor(Contest.Color.blue);
            }
            if (red.Checked)
            {
                results.addColor(Contest.Color.red);
            }
            if (gray.Checked)
            {
                results.addColor(Contest.Color.gray);
            }
            if (green.Checked)
            {
                results.addColor(Contest.Color.green);
            }
            if(brown.Checked)
            {
                results.addColor(Contest.Color.brown);
            }
            if(terracotta.Checked)
            {
                results.addColor(Contest.Color.terracotta);
                results.emails.Add(email.Text);
            }
            if(purple.Checked)
            {
                results.addColor(Contest.Color.purple);
            }
            if(silver.Checked)
            {
                results.addColor(Contest.Color.silver);
            }
            if(white.Checked)
            {
                results.addColor(Contest.Color.white);
            }
            if(yellow.Checked)
            {
                results.addColor(Contest.Color.yellow);
            }

            results.writeResults();
            results.writeEmails();

            int bluePercent = (int)Math.Round((double)(100 * results.blue) / results.total);
            int redPercent = (int)Math.Round((double)(100 * results.red) / results.total);
            int grayPercent = (int)Math.Round((double)(100 * results.gray) / results.total);
            int greenPercent = (int)Math.Round((double)(100 * results.green) / results.total);
            int brownPercent = (int)Math.Round((double)(100 * results.brown) / results.total);
            int purplePercent = (int)Math.Round((double)(100 * results.purple) / results.total);
            int terracottaPercent = (int)Math.Round((double)(100 * results.terracotta) / results.total);
            int yellowPercent = (int)Math.Round((double)(100 * results.yellow) / results.total);
            int silverPercent = (int)Math.Round((double)(100 * results.silver) / results.total);
            int whitePercent = (int)Math.Round((double)(100 * results.white) / results.total);

            content.InnerHtml = "<h1>This is how others are voting so far... Purple: " + purplePercent + "%, Blue: " + bluePercent + "%, Red: " + redPercent + "%, Terracotta: " + terracottaPercent + "%, Green: " + greenPercent + "%, Yellow: " + yellowPercent + "%, Brown: " + brownPercent + "%, Gray: " + grayPercent + "%, Silver: " + silverPercent + "%, White: " + whitePercent + "%</h1>\n";
            content.InnerHtml += "<h1>Thanks for participating!</h1>\n";
            content.InnerHtml += "<h1>Check back at the end of January</h1>\n";
            content.InnerHtml += "<h1>A winner will be randomly selected from those picking the correct color for the answer!</h1>\n";
        }
    }
}
