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
    public List<string> emails;
    public List<string> answers;

    public Contest()
    {
        emails = new List<string>();
        answers = new List<string>();
        readEmails();
        readAnswers();
    }

    public void writeEmails()
    {
        using (System.IO.StreamWriter file = new System.IO.StreamWriter("C:/inetpub/wwwroot/Contest/emails3.txt"))
        {
            foreach (string e in emails)
            {
                file.WriteLine(e);
            }
        }
    }

    public void writeAnswers()
    {
        using (System.IO.StreamWriter file = new System.IO.StreamWriter("C:/inetpub/wwwroot/Contest/answers3.txt"))
        {
            foreach (string a in answers)
            {
                file.WriteLine(a);
            }
        }
    }

    public void readEmails()
    {
        string line;
        using (System.IO.StreamReader file = new System.IO.StreamReader("C:/inetpub/wwwroot/Contest/emails3.txt"))
        {
            while ((line = file.ReadLine()) != null)
            {
                this.emails.Add(line);
            }
        }
    }

    public void readAnswers()
    {
        string line;
        using (System.IO.StreamReader file = new System.IO.StreamReader("C:/inetpub/wwwroot/Contest/answers3.txt"))
        {
            while ((line = file.ReadLine()) != null)
            {
                this.answers.Add(line);
            }
        }
    }
}

public partial class _Default : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        DateTime today = DateTime.Now;
        if(today.Day > 0)
        {
            ww.ImageUrl = "/Contest/img/ph1.png";
            outer.NavigateUrl = "/Contest/img/ph1.png";
        }
        if(today.Day > 7)
        {
            ww.ImageUrl = "/Contest/img/ph2.jpg";
            outer.NavigateUrl = "/Contest/img/ph2.jpg";
        }
        if(today.Day > 14)
        {
            ww.ImageUrl = "/Contest/img/ph3.jpg";
            outer.NavigateUrl = "/Contest/img/ph3.jpg";
        }
        if(today.Day > 21)
        {
            ww.ImageUrl = "/Contest/img/ph4.jpg";
            outer.NavigateUrl = "/Contest/img/ph4.jpg";
        }
        if(today.Day > 27)
        {
            ww.ImageUrl = "/Contest/img/ph5.png";
            outer.NavigateUrl = "/Contest/img/ph5.png";
        }
        if(today.Month == 4)
        {
            ww.ImageUrl = "/Contest/img/ph5.png";
            outer.NavigateUrl = "/Contest/img/ph5.png";
        }
    }

    protected void Submit_Click(object sender, EventArgs e)
    {
        if (Page.IsValid)
        {
            Contest results = new Contest();
            results.emails.Add(email.Text + " " + DateTime.Now.Day);
            results.answers.Add(answer.Text + " " + DateTime.Now.Day);
            results.writeAnswers();
            results.writeEmails();

            content.InnerHtml = "<h1>Thanks for participating!</h1>\n";
            content.InnerHtml += "<h1>Check back every Wednesday for another picture and another chance to win!</h1>\n";
        }
    }
}
